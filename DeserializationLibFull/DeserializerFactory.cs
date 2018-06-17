using DeserializationLibFull.Json.Deserializers;
using DeserializationLibStandard;
using DeserializationLibStandard.Json.Deserializers;
using System;

namespace DeserializationLibFull
{
    public class DeserializerFactory<T>
    {
        public IVulnerableDeserializer<T> GetDeserializer(DeserializerEnums.DeserializerTypeEnum type)
        {
            switch (type)
            {
                case DeserializerEnums.DeserializerTypeEnum.FastJSON:
                    return new FastJSONDeserializer<T>();
                case DeserializerEnums.DeserializerTypeEnum.JsonDotNet:
                    return new JsonDotNetDeserializer<T>();
                case DeserializerEnums.DeserializerTypeEnum.FSPickler:
                    return new FSPicklerDeserializer<T>();
                case DeserializerEnums.DeserializerTypeEnum.SweetJayson:
                    return new SweetJaysonDeserializer<T>();
                case DeserializerEnums.DeserializerTypeEnum.JavascriptSerializer:
                    return new JavascriptSerializerDeserializer<T>();
                case DeserializerEnums.DeserializerTypeEnum.DataContractJsonSerializer:
                    return new DataContractJsonSerializerDeserializer<T>();
                default:
                    throw new Exception("Unsupported serializer");
            }
        }
    }
}
