﻿using DeserializationLibFull.Binary;
using DeserializationLibFull.Json;
using DeserializationLibFull.Xml;
using DeserializationLibStandard;
using DeserializationLibStandard.Binary;
using DeserializationLibStandard.Json;
using DeserializationLibStandard.Xml;
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
                case DeserializerEnums.DeserializerTypeEnum.FSPicklerJson:
                    return new FSPicklerJsonDeserializer<T>();
                case DeserializerEnums.DeserializerTypeEnum.FSPicklerXml:
                    return new FSPicklerXmlDeserializer<T>();
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
                case DeserializerEnums.DeserializerTypeEnum.XmlSerializer:
                    return new XmlSerializerDeserializer<T>();
                default:
                    throw new Exception("Unsupported serializer");
            }
        }
    }
}
