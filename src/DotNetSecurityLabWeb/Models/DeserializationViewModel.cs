using System.Collections.Generic;
using static DotNetSecurityLabWeb.Models.DotNetSecurityLabEnums;

namespace DotNetSecurityLabWeb.Models
{
    public class DeserializationViewModel
    {
        public DeserializationViewModel()
        {
            DefaultData = new List<string>();
        }

        public string Data { get; set; }

        public string Output { get; set; }

        public SerializationTypeEnum Library { get; set; }

        public List<string> DefaultData { get; set; }
    }
}