using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace RockServer
{
    class JsonUtil
    {
        /*
        public static string converterObjetoParaJson<T>(T obj)
        {
            MemoryStream stream = new MemoryStream();
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T));
            serializer.WriteObject(stream, obj);
            stream.Position = 0;
            StreamReader sr = new StreamReader(stream);

            return sr.ReadToEnd();
        }

        public static Object converterJsonParaObjeto<T>(String json)
        {
            MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(json));
            stream.Position = 0;
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T));
            T obj = (T)serializer.ReadObject(stream);
            return obj;
        }
        */
        public static string converterObjetoParaJson<T>(T obj)
        {
            var serializer = new JavaScriptSerializer();
            var serializedResult = serializer.Serialize(obj);
            return serializedResult;
        }

        public static T converterJsonParaObjeto<T>(String json)
        {
            var serializer = new JavaScriptSerializer();
            var deserializedResult = serializer.Deserialize<T>(json);
            return deserializedResult;
        }
    }
}
