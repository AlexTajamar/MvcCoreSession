using Newtonsoft.Json;

namespace MvcCoreSession.Helpers
{
    public class HelperJsonSession
    {

        public static string SerializeObject<T>(T obj)
        {
            string json = JsonConvert.SerializeObject(obj);
            return json;
        }

        public static T DeserializeObject<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}
