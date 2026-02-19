using Newtonsoft.Json;

namespace MvcCoreSession.Helpers
{
    public class HelperJsonSession
    {
        /* VAMOS A ALMACENAR DATOS EN SESSION MEDIANTE EL METDODO GetString, SetSring */
        public static string SerializableObject<T>(T datos)
        {
            return JsonConvert.SerializeObject(datos);
        }

        // RECIBIMOS UN STRING Y DEVOLVEMOS CUALQUIER OBJETO
        public static T DeserializeObject<T>(string datos)
        {
            return JsonConvert.DeserializeObject<T>(datos);
        }
    }
}
