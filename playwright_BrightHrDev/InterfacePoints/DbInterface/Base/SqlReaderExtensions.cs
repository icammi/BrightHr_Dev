namespace playwright_newintegrationtests.InterfacePoints.DbInterface.Base
{
    public static class SqlReaderExtensions
    {
        private static List<Func<object, PropertyInfo, object, bool>> Converters = new()
        {
            (object recordInstance, PropertyInfo propertyInfo, object dbValue) =>
            {
                if (propertyInfo.PropertyType == typeof(DateTimeOffset) && dbValue is DateTime dateTime)
                {
                    var offset = new DateTimeOffset(dateTime);
                    propertyInfo.SetValue(recordInstance, offset, null);
                    return true;
                }
                return false;
            }
        };

        public static T Deserialize<T>(this IDataRecord record) where T : class, new()
        {
            T recordInstance = new();

            var propertyInfos = recordInstance.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (PropertyInfo propertyInfo in propertyInfos)
            {
                ApplyDataToField(record, recordInstance, propertyInfo);
            }

            return recordInstance;
        }

        private static void ApplyDataToField<T>(IDataRecord record, T recordInstance, PropertyInfo propertyInfo) where T : class, new()
        {
            if (propertyInfo.GetCustomAttributes(typeof(SqlDataFieldAttribute), false) is SqlDataFieldAttribute[] fieldNameAttributes && fieldNameAttributes.Length == 1)
            {
                var fieldNameAttribute = fieldNameAttributes[0];

                var dbValue = record[fieldNameAttribute.Name];
                if (dbValue != null)
                {
                    SetDataValue(recordInstance, propertyInfo, dbValue);
                }
            }
        }

        private static void SetDataValue<T>(T recordInstance, PropertyInfo propertyInfo, object dbValue) where T : class, new()
        {
            var converted = PerformConversions(recordInstance, propertyInfo, dbValue);

            if (converted)
            {
                return;
            }

            propertyInfo.SetValue(
                recordInstance,
                Convert.ChangeType(dbValue, propertyInfo.PropertyType, CultureInfo.InvariantCulture),
                null
            );
        }

        private static bool PerformConversions<T>(T recordInstance, PropertyInfo propertyInfo, object dbValue) where T : class, new()
        {
            var converted = false;
            foreach (var converter in Converters)
            {
                if (converter(recordInstance, propertyInfo, dbValue))
                {
                    converted = true;
                    break;
                }
            }

            return converted;
        }
    }
}
