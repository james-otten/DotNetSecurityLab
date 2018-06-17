using DeserializationLibFull.Binary.Deserializers;
using DeserializationLibFull.Json.Deserializers;
using DeserializationLibFull.Xml.Deserializers;
using DeserializationLibStandard;
using DeserializationLibStandard.Binary.Deserializers;
using DeserializationLibStandard.Json.Deserializers;
using DeserializationLibStandard.Xml.Deserializers;
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
                case DeserializerEnums.DeserializerTypeEnum.BinaryFormatter:
                    return new BinaryFormatterDeserializer<T>();
                case DeserializerEnums.DeserializerTypeEnum.SoapFormatter:
                    return new SoapFormatterDeserializer<T>();
                case DeserializerEnums.DeserializerTypeEnum.NetDataContractSerializer:
                    return new NetDataContractSerializerDeserializer<T>();
                case DeserializerEnums.DeserializerTypeEnum.DataContractSerializer:
                    return new DataContractSerializerDeserializer<T>();
                case DeserializerEnums.DeserializerTypeEnum.ObjectStateFormatter:
                    return new ObjectStateFormatterDeserializer<T>();
                case DeserializerEnums.DeserializerTypeEnum.LosFormatter:
                    return new LosFormatterDeserializer<T>();
                default:
                    throw new Exception("Unsupported serializer");
            }
        }
    }
}
