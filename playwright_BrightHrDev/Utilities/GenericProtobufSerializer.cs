namespace playwright_newintegrationtests.Utilities
{
    /// <summary>
    /// Very simple protobuf serializer which works without a generated csharp concrete type
    /// The idea is you can use this to transform a specflow datatable to a protobuf object
    ///
    /// Should the limitations be a problem you would have to define csharp classes or generate them from .proto files
    /// and use the concrete types from those.
    /// 
    /// Has many limitations!
    /// 1. Number of fields = Tags maximum 31 (because we only support single byte tags).
    /// 2. Only int, long, bool, string and DateTimeOffsetAsString are currently fully supported.
    /// 3. Coding to Google.Protobuf.WellKnownType.Timestamp is supported but un tested and NO deserialising from timestamp
    /// 4. No arrays or sub types supported.
    /// 
    /// https://mikehadlow.com/posts/2022-03-18-use-google-protobuf-without-code-generation/
    /// </summary>
    public class GenericProtobufSerializer
    {
        private readonly IDictionary<uint, System.Type> messageDefinition;
        private readonly HashSet<uint> fieldSet;

        public GenericProtobufSerializer(IDictionary<uint, System.Type> messageDefinition)
        {
            this.messageDefinition = messageDefinition;
            fieldSet = new HashSet<uint>(messageDefinition.Keys);
        }

        public byte[] Serialize(IDictionary<uint, object> value)
        {
            var valueFieldSet = new HashSet<uint>(value.Keys);
            if (fieldSet.Except(valueFieldSet).Any())
            {
                throw new ArgumentException("Input value key set differs from messageDefinition.");
            }

            var bytes = new byte[CalculateMessageSize(value)];
            var output = new CodedOutputStream(bytes);

            foreach (var (key, input) in value)
            {
                output.WriteRawTag(CreateTag(key));
                switch (messageDefinition[key])
                {
                    case System.Type t when t == typeof(int):
                        output.WriteInt32((int)(input ?? 0));
                        break;
                    case System.Type t when t == typeof(long):
                        output.WriteInt64((long)(input ?? 0));
                        break;
                    case System.Type t when t == typeof(string):
                        output.WriteString((string)(input ?? ""));
                        break;
                    case System.Type t when t == typeof(bool):
                        output.WriteBool((bool)(input ?? ""));
                        break;
                    case System.Type t when t == typeof(Timestamp):
                        Timestamp timestamp = Timestamp.FromDateTime(DateTime.SpecifyKind((DateTime)input, DateTimeKind.Utc));
                        timestamp.WriteTo(output);
                        break;
                    case System.Type t when t == typeof(DateTimeOffsetAsString):
                        output.WriteString((string)(input ?? ""));
                        break;
                    default:
                        throw new InvalidOperationException($"Invalid type.");
                }
            }
            output.CheckNoSpaceLeft();
            return bytes;

            int CalculateMessageSize(IDictionary<uint, object> value)
            {
                var size = 0;
                foreach (var (key, input) in value)
                {
                    size += 1 + messageDefinition[key] switch
                    {
                        System.Type t when t == typeof(int) => CodedOutputStream.ComputeInt32Size((int)(input ?? 0)),
                        System.Type t when t == typeof(long) => CodedOutputStream.ComputeInt64Size((long)(input ?? 0)),
                        System.Type t when t == typeof(bool) => CodedOutputStream.ComputeBoolSize((bool)(input ?? 0)),
                        System.Type t when t == typeof(string) => CodedOutputStream.ComputeStringSize((string)(input ?? "")),
                        System.Type t when t == typeof(Timestamp) => Timestamp.FromDateTime(DateTime.SpecifyKind((DateTime)input, DateTimeKind.Utc)).CalculateSize(),
                        System.Type t when t == typeof(DateTimeOffsetAsString) => CodedOutputStream.ComputeStringSize((string)(input ?? "")),
                        System.Type t => throw new InvalidOperationException($"Unsupported type {t.Name}")
                    };
                }
                return size;
            }

            // tag byte format is AAAAA_BBB where A bits are the tag number and B bits are the wire type.
            byte CreateTag(uint key)
            {
                uint wiretype = messageDefinition[key] switch
                {
                    System.Type t when t == typeof(int) => 0,
                    System.Type t when t == typeof(long) => 0,
                    System.Type t when t == typeof(bool) => 0,
                    System.Type t when t == typeof(Timestamp) => 0,
                    System.Type t when t == typeof(string) => 2, // delimited
                    System.Type t when t == typeof(DateTimeOffsetAsString) => 2, // delimited
                    System.Type t => throw new InvalidOperationException($"Unsupported type {t.Name}")
                };

                return BitConverter.GetBytes((key << 3) + wiretype)[0];
            }
        }

        public IDictionary<uint, object> Deserialize(byte[] bytes)
        {
            using var input = new CodedInputStream(bytes);
            var value = new Dictionary<uint, object>();

            uint tag;
            while ((tag = input.ReadTag()) != 0)
            {
                var field = tag >> 3;

                if (!messageDefinition.ContainsKey(field))
                {
                    throw new InvalidOperationException($"Unexpected field value: {field}");
                }

                switch (messageDefinition[field])
                {
                    case System.Type t when t == typeof(int):
                        value.Add(field, input.ReadInt32());
                        break;
                    case System.Type t when t == typeof(long):
                        value.Add(field, input.ReadInt64());
                        break;
                    case System.Type t when t == typeof(bool):
                        value.Add(field, input.ReadBool());
                        break;
                    case System.Type t when t == typeof(string):
                        value.Add(field, input.ReadString());
                        break;
                    case System.Type t when t == typeof(Timestamp):
                        // Couldn't work out a way to do this
                        break;

                    case System.Type t when t == typeof(DateTimeOffsetAsString):
                        value.Add(field, DateTimeOffset.Parse(input.ReadString()));
                        break;
                    default:
                        throw new InvalidOperationException($"Invalid type.");
                }
            }

            return value;
        }

        public static object GetCastObject(string typeString, object value)
        {
            object result = new();

            result = typeString switch
            {
                "System.Int32" => int.Parse(value.ToString()),
                "System.Int64" => long.Parse(value.ToString()),
                "System.Boolean" => bool.Parse(value.ToString()),
                "System.String" => value.ToString(),
                "Utilities.DateTimeOffsetAsString" => value.ToString(),
                "Google.Protobuf.WellKnownTypes.Timestamp" => Timestamp.FromDateTime(DateTime.Parse(value.ToString())),
                _ => new()
            };

            return result;
        }
    }
}
