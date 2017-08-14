using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileAshApi.Models
{
    public class JSonResultParser
    {
        internal T Parse<T>(string json)
        {
            var root = JObject.Parse(json);
            var d = root["d"];
            var result = JsonConvert.DeserializeObject<T>(d.ToString());
            return result;
        }
    }
}