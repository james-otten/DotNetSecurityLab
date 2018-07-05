using System;
using System.Runtime.Serialization;

namespace DeserializationLibStandard.DataTypes
{
    [Serializable]
    public class Address: ISerializable
    {
        public string Street { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public Address()
        {
        }

        protected Address(SerializationInfo info, StreamingContext context)
        {
            Street = (string)info.GetValue("Street", typeof(string));
            City = (string)info.GetValue("City", typeof(string));
            State = (string)info.GetValue("State", typeof(string));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Street", Street);
            info.AddValue("City", City);
            info.AddValue("State", State);
        }

        public override string ToString()
        {
            return Street + ", " + City + ", " + State;
        }
    }
}
