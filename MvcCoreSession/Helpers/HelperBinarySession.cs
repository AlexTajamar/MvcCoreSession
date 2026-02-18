using System.Runtime.Serialization.Formatters.Binary;

namespace MvcCoreSession.Helpers
{
    public class HelperBinarySession
    {
        //VAMOS A CREAR LOS METODOS DE TIPO STATIC PARA PODER USARLO DESDE CUALQUIER CONTROLADOR DE NUESTRA APLICACION
        //ONJETO A BYTE

        public static byte[] ObjetoByte(object obj)
        {
#pragma warning disable SYSLIB0011 // Type or member is obsolete
            var formatter = new BinaryFormatter();
#pragma warning restore SYSLIB0011 // Type or member is obsolete
            using var stream = new MemoryStream();
            formatter.Serialize(stream, obj);
            return stream.ToArray();
        }

        public static object ByteObjeto(byte[] data)
        {
#pragma warning disable SYSLIB0011 // Type or member is obsolete
            var formatter = new BinaryFormatter();
#pragma warning restore SYSLIB0011 // Type or member is obsolete
            using var stream = new MemoryStream();
            stream.Write(data, 0, data.Length);
            stream.Seek(0, SeekOrigin.Begin);
            return formatter.Deserialize(stream);
        }
    }
}

