using DeserializationLibStandard.DataTypes;
using DeserializationLibFull;
using DotNetSecurityLabWeb.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using static DeserializationLibStandard.DeserializerEnums;
using static DotNetSecurityLabWeb.Models.DotNetSecurityLabEnums;

namespace DotNetSecurityLabWeb.Controllers
{
    public class DeserializationController : Controller
    {
        // GET: Json
        public ActionResult Index()
        {
            var model = BuildModel();
            model.Data = model.DefaultData[0];
            return View(model);
        }

        // POST: Deserialize
        //Security Warning: Intentionally vulnerable to CSRF
        [ValidateInput(false)]//Security Warning: Unsafe, can lead to XSS
        public ActionResult Deserialize(string data, int library)
        {
            var model = BuildModel();
            model.Data = data;
            model.Library = (SerializationTypeEnum)library;

            var factory = new DeserializerFactory<Person>();
            var deserializer = factory.GetDeserializer((DeserializerTypeEnum)library);
            var person = deserializer.Deserialize(data);
            model.Output = person.ToString();

            return View("Index", model);
        }

        private DeserializationViewModel BuildModel()
        {
            var factory = new DeserializerFactory<Person>();
            var ret = new DeserializationViewModel();
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

            for(int i = 0; i < Enum.GetNames(typeof(DeserializerTypeEnum)).Length; i++)
            {
                var ser = factory.GetDeserializer((DeserializerTypeEnum)i);
                var serialized = ser.Serialize(defaultObj);
                ret.DefaultData.Add(serialized);
            }

            return ret;
        }
    }
}