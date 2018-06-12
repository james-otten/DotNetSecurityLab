using DeserializationLibStandard.DataTypes;
using DeserializationLibFull.Json;
using DotNetSecurityLabWeb.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using static DeserializationLibStandard.DeserializerEnums;
using static DotNetSecurityLabWeb.Models.DotNetSecurityLabEnums;

namespace DotNetSecurityLabWeb.Controllers
{
    public class JsonController : Controller
    {
        // GET: Json
        public ActionResult Index()
        {
            var model = BuildModel();
            model.Data = model.DefaultJson[0];
            return View(model);
        }

        // POST: Deserialize
        //Security Warning: Intentionally vulnerable to CSRF
        public ActionResult Deserialize(string data, int library)
        {
            var model = BuildModel();
            model.Data = data;
            model.Library = (SerializationTypeEnum)library;

            var factory = new JsonDeserializerFactory<Person>();
            var deserializer = factory.GetDeserializer((JsonDeserializerTypeEnum)library);
            var person = deserializer.Deserialize(data);
            model.Output = person.ToString();

            return View("Index", model);
        }

        private JsonViewModel BuildModel()
        {
            var factory = new JsonDeserializerFactory<Person>();
            var ret = new JsonViewModel();
            var defaultObj = new Person()
            {
                Name = new Name()
                {
                    FirstName = "Firsty",
                    MiddleName = "Midler",
                    LastName = "Laster"
                },
                Age = 26,
                Address = new Address { Street = "123 Some Street", City = "Some City", State = "MN" },
                Properties = new Dictionary<string, object>()
            };
            defaultObj.Properties.Add("address", new Address { Street = "123 Some Street", City = "Some City", State = "MN" });

            for(int i = 0; i < Enum.GetNames(typeof(JsonDeserializerTypeEnum)).Length; i++)
            {
                var ser = factory.GetDeserializer((JsonDeserializerTypeEnum)i);
                var serialized = ser.Serialize(defaultObj);
                ret.DefaultJson.Add(serialized);
            }

            return ret;
        }
    }
}