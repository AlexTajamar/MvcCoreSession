using MvcCoreSession.Helpers;

namespace MvcCoreSession.Extensions
{
    public static class SessionExtensions
    {
        //METODO PARA RECUPERAR CUALQUIER OBJETO DE SESSION
        public static T GetObject<T>(this ISession session, string key)
        {
            //DEBEMOS RECUPERAR EL OBJETO JSON DE SESSION
            string json = session.GetString(key);
            //Si algo no existe siempre devuelve null
            if (json == null)
            {
                return default(T);
            }
            else
            { 
            //RECUPERAMOS EL OBJETO Y LO CONVERTIMOS CON NUESTRO HELPER
            T data = HelperJsonSession.DeserializeObject<T>(json);
                            return data;
             }
        }

        public static void SetObject(this ISession session,string key,object value) 
        {
            string data = HelperJsonSession.SerializeObject(value);
            session.SetString(key, data);
        }



    }
}
