using System.Runtime.Serialization.Formatters.Binary;

namespace MvcCoreSession.Helpers
{
    public class HelperBinarySession
    {
        // CONVERTIMOS OBJETO A BYTE
        public static byte[] ObjectToByte(Object objeto)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (MemoryStream stream = new MemoryStream())
            {
                formatter.Serialize(stream, objeto);
                return stream.ToArray();
            }
        }

        // CONVERTIMOS DE BYTE A OBJETO
        public static Object ByteToObject(byte[] datos)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (MemoryStream stream = new MemoryStream())
            {
                stream.Write(datos, 0, datos.Length);
                stream.Seek(0, SeekOrigin.Begin);
                return (Object)formatter.Deserialize(stream);
            }
        }
    }
}
