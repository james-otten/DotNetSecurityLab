
namespace DeserializationLibStandard
{
    public interface IVulnerableDeserializer<T>
    {
        T Deserialize(string data);
        string Serialize(T obj);
    }
}
