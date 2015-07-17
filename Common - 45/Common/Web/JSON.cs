using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;

namespace Common.Web
{
    public static class JSON
    {
        public static T Parse<T>(string json)
        {
            var serializer = new JavaScriptSerializer();
            return serializer.Deserialize<T>(json);
        }

        public static object Parse(string json, Type t)
        {
            var serializer = new JavaScriptSerializer();
            return serializer.Deserialize(json, t);
        }

        public static string Stringify(object obj)
        {
            var serializer = new JavaScriptSerializer();
            return serializer.Serialize(obj);
        }
    }
}
