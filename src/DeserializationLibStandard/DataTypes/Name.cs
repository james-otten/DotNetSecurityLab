using System;
using System.Runtime.Serialization;

namespace DeserializationLibStandard.DataTypes
{
    [Serializable]
    public class Name: ISerializable
    {
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public Name()
        {
        }

        protected Name(SerializationInfo info, StreamingContext context)
        {
            FirstName = (string)info.GetValue("FirstName", typeof(string));
            MiddleName = (string)info.GetValue("MiddleName", typeof(string));
            LastName = (string)info.GetValue("LastName", typeof(string));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("FirstName", FirstName);
            info.AddValue("MiddleName", MiddleName);
            info.AddValue("LastName", LastName);
        }

        public override string ToString()
        {
            return FirstName + " " + MiddleName + " " + LastName;
        }
    }
}
