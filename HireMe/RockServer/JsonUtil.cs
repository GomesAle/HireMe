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
    //Metodos para converter de/para json.
    class JsonUtil
    {
        
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
