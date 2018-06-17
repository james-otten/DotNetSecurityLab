
namespace DeserializationLibStandard.DataTypes
{
    public class Property
    {
        public string Key { get; set; }
        public object Value { get; set; }

        public Property()
        {
        }

        public Property(string key, object value)
        {
            Key = key;
            Value = value;
        }
    }
}
