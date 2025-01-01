using Confluent.Kafka;

namespace playwright_newintegrationtests.InterfacePoints.KafkaInterface
{
    public class KafkaReader : IKafkaReader
    {
        private readonly IConfigurationRoot _configuration;
        private ConsumerConfig _consumerConfig = new();
        private AdminClientConfig _adminClientConfig = new();

        public KafkaReader(IConfigurationRoot configuration)
        {
            _configuration = configuration;
        }

        public IEnumerable<KafkaMessage> ReadTopic(string topicName, string server)
        {
            SetupConfig(server);
            List<PartitionMetadata> partitions = GetPartitions(topicName);
            List<KafkaMessage> messages = new();

            using var consumer = new ConsumerBuilder<byte[], byte[]>(_consumerConfig).Build();

            try
            {
                foreach (var partition in partitions)
                {
                    var topicPartition = new TopicPartition(topicName, partition.PartitionId);

                    ReadPartitionData(topicPartition, messages, consumer);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                consumer.Close();
            }

            return messages;
        }

        private List<PartitionMetadata> GetPartitions(string topicName)
        {
            List<PartitionMetadata> partitions = new();

            using (var adminClient = new AdminClientBuilder(_adminClientConfig).Build())
            {
                var meta = adminClient.GetMetadata(TimeSpan.FromSeconds(20));

                var topic = meta.Topics.FirstOrDefault(t => t.Topic.ToLower() == topicName.ToLower())
                    ?? throw new InvalidOperationException($"{topicName} does not exist");

                partitions = topic.Partitions;
            };

            return partitions;
        }

        private static void ReadPartitionData(TopicPartition topicPartition, List<KafkaMessage> messages, IConsumer<byte[], byte[]> consumer)
        {
            CancellationTokenSource cts = new();

            var offsets = consumer.QueryWatermarkOffsets(topicPartition, TimeSpan.FromSeconds(30));
            var partitionSize = offsets.High - offsets.Low;

            if (partitionSize <= 0)
            {
                return;
            }

            consumer.Assign(new TopicPartitionOffset(topicPartition, offsets.Low));

            for (int currentPosition = 0; currentPosition < partitionSize; currentPosition++)
            {
                var result = consumer.Consume(cts.Token);

                var message = new KafkaMessage()
                {
                    Key = result.Message.Key,
                    Value = result.Message.Value
                };

                ReadMessageHeaders(result, message);

                messages.Add(message);
            }
        }

        private static void ReadMessageHeaders(ConsumeResult<byte[], byte[]> result, KafkaMessage message)
        {
            var headers = result.Message.Headers;

            foreach (var header in headers)
            {
                message.Headers.Add(header.Key, header.GetValueBytes());
            }
        }

        private void SetupConfig(string server)
        {
            var virtualsConfiguration = _configuration.GetSection(server);
            var username = virtualsConfiguration.GetSection("Username");
            var password = virtualsConfiguration.GetSection("Password");
            var groupId = virtualsConfiguration.GetSection("GroupId");
            var bootstrapServers = virtualsConfiguration.GetSection("BootstrapServers");

            _consumerConfig = new()
            {
                BootstrapServers = bootstrapServers.Value,
                SecurityProtocol = SecurityProtocol.SaslPlaintext,
                SaslMechanism = SaslMechanism.ScramSha256,
                AutoOffsetReset = AutoOffsetReset.Earliest,
                SaslUsername = username.Value,
                SaslPassword = password.Value,
                GroupId = groupId.Value
            };

            _adminClientConfig = new()
            {
                BootstrapServers = bootstrapServers.Value,
                SecurityProtocol = SecurityProtocol.SaslPlaintext,
                SaslMechanism = SaslMechanism.ScramSha256,
                SaslUsername = username.Value,
                SaslPassword = password.Value,
            };
        }
    }
}