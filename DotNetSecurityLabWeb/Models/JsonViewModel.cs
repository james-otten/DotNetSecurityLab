using System.Collections.Generic;
using static DotNetSecurityLabWeb.Models.DotNetSecurityLabEnums;

namespace DotNetSecurityLabWeb.Models
{
    public class JsonViewModel
    {
        public JsonViewModel()
        {
            DefaultJson = new List<string>();
        }

        public string Data { get; set; }

        public string Output { get; set; }

        public SerializationTypeEnum Library { get; set; }

        public List<string> DefaultJson { get; set; }
    }
}