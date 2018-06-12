using DeserializationLibFull.Json.Deserializers;
using DeserializationLibStandard;
using DeserializationLibStandard.Json.Deserializers;
using System;

namespace DeserializationLibFull.Json
{
    public class JsonDeserializerFactory<T>
    {
        public IVulnerableDeserializer<T> GetDeserializer(DeserializerEnums.JsonDeserializerTypeEnum type)
        {
            switch (type)
            {
                case DeserializerEnums.JsonDeserializerTypeEnum.FastJSON:
                    return new FastJSONDeserializer<T>();
                case DeserializerEnums.JsonDeserializerTypeEnum.JsonDotNet:
                    return new JsonDotNetDeserializer<T>();
                case DeserializerEnums.JsonDeserializerTypeEnum.FSPickler:
                    return new FSPicklerDeserializer<T>();
                case DeserializerEnums.JsonDeserializerTypeEnum.SweetJayson:
                    return new SweetJaysonDeserializer<T>();
                case DeserializerEnums.JsonDeserializerTypeEnum.JavascriptSerializer:
                    return new JavascriptSerializerDeserializer<T>();
                case DeserializerEnums.JsonDeserializerTypeEnum.DataContractJsonSerializer:
                    return new DataContractJsonSerializerDeserializer<T>();
                default:
                    throw new Exception("Unsupported serializer");
            }
        }
    }
}
