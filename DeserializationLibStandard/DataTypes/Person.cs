using DeserializationLibStandard.Json;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DeserializationLibStandard.DataTypes
{
    [Serializable]
    [KnownType(typeof(Name))]
    [KnownType(typeof(Dictionary<string, Object>))]
    [KnownType(typeof(Address))]
    [KnownType(typeof(Object))]
    [JsonConverter(typeof(CustomConverter))]
    public class Person: ISerializable
    {
        public Name Name { get; set; }

        public int Age { get; set; }

        public Object Address { get; set; }

        public Dictionary<string, Object> Properties { get; set; }

        public Person()
        {
            Name = new Name();
            Properties = new Dictionary<string, object>();
        }

        protected Person(SerializationInfo info, StreamingContext context)
        {
            Properties = new Dictionary<string, object>();
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
                        Properties.Add(entry.Name, array);
                        break;
                }
            }
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Name", Name);
            info.AddValue("Age", Age);
            info.AddValue("Address", Address);
            foreach (string key in Properties.Keys)
            {
                info.AddValue(key, Properties[key]);
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
                foreach (var key in Properties.Keys)
                {
                    ret += "\nProperty: " + key + " Value: " + Properties[key].ToString();
                }
            }
            return ret;
        }
    }
}
