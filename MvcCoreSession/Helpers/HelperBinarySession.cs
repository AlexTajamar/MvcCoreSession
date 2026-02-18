using System.Runtime.Serialization.Formatters.Binary;

namespace MvcCoreSession.Helpers
{
    public class HelperBinarySession
    {
        //VAMOS A CREAR LOS METODOS DE TIPO STATIC PARA PODER USARLO DESDE CUALQUIER CONTROLADOR DE NUESTRA APLICACION
        //ONJETO A BYTE

        public static byte[] ObjetoByte(Object obj)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (MemoryStream stream = new MemoryStream())
            {
                formatter.Serialize(stream, obj);
                return stream.ToArray();
            }
        }


        public static Object ByteObjeto(byte[] data)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (MemoryStream stream = new MemoryStream())
            {
                stream.Write(data, 0, data.Length);
                stream.Seek(0, SeekOrigin.Begin);
                Object object = (Object)formatter.Deserialize(stream);
                return object;
            }
        }


    }
    }

