using DeserializationLibStandard.Json.Converters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace DeserializationLibStandard.DataTypes
{
    [Serializable]
    [KnownType(typeof(Name))]
    [KnownType(typeof(List<Property>))]
    [KnownType(typeof(Address))]
    [KnownType(typeof(Object))]
    [JsonConverter(typeof(CustomConverter))]
    [XmlInclude(typeof(Name))]
    [XmlInclude(typeof(Address))]
    public class Person: ISerializable
    {
        public Name Name { get; set; }

        public int Age { get; set; }

        public Object Address { get; set; }

        public List<Property> Properties { get; set; }

        public Person()
        {
            Name = new Name();
            Properties = new List<Property>();
        }

        protected Person(SerializationInfo info, StreamingContext context)
        {
            Properties = new List<Property>();
            foreach (var entry in info)
            {
                switch(entry.Name)
                {
                    case "Name":
                        Name = (Name)info.GetValue("Name", typeof(Name));
                        break;
                    case "Age":
                        Age = (int)info.GetValue("Age", typeof(int));
                        break;
                    case "Address":
                        Address = info.GetValue("Address", typeof(Object));
                        break;
                    default:
                        object array = entry.Value as object;
                        Properties.Add(new Property(entry.Name, array));
                        break;
                }
            }
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Name", Name);
            info.AddValue("Age", Age);
            info.AddValue("Address", Address);
            foreach (var item in Properties)
            {
                info.AddValue(item.Key, item.Value);
            }
        }

        public override string ToString()
        {
            var ret = "";
            if (Name != null)
            {
                ret += "Name: " + Name.ToString();
            }

            ret += "\nAge: " + Age;

            if (Address != null)
            {
                ret += "\nAddress: " + Address.ToString();
            }

            if (Properties != null)
            {
                foreach (var item in Properties)
                {
                    ret += "\nProperty: " + item.Key + " Value: " + item.Value.ToString();
                }
            }
            return ret;
        }
    }
}
