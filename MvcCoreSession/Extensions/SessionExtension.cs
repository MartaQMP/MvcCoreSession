using Microsoft.CodeAnalysis.CSharp.Syntax;
using MvcCoreSession.Helpers;
using Newtonsoft.Json;

namespace MvcCoreSession.Extensions
{
    public static class SessionExtension
    {
        // METODO PARA RECUPERAR CUALQUIER OBJETO DE SESSION
        public static T GetObject<T>(this ISession session, string key)
        {
            /* AHORA MISMO YA TENEMOS DENTRO DE LA VARIABLE SESSION EL OBJETO HttpContext.Session
            *  DEBEMOS RECUPERAR EL OBJETO Json DE SESSION */
            string json = session.GetString(key);
            // EN SESSION SI ALGO NO EXISTE DEVUELVE null
            if(json == null)
            {
                return default(T);
            }
            else
            {
                // RECUPERAMOS EL OBJETO Y LO CONVERTIMOS CON NUESTRO Helper
                return JsonConvert.DeserializeObject<T>(json);
            }
        }

        public static void SetObject(this ISession session, string key, object value)
        {
            string datos = JsonConvert.SerializeObject(value);
            session.SetString(key, datos);
        }
    }
}
