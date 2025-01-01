using playwright_newintegrationtests.InterfacePoints.KafkaInterface;

namespace playwright_newintegrationtests.InterfacePoints.KafkaInterface
{
    public interface IKafkaReader
    {
        public IEnumerable<KafkaMessage> ReadTopic(string topicName, string server);
    }
}