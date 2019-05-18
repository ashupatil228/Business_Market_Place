using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BusinessMarketPlace
{
    internal class Mystorage
    {

        internal static T GetEmbeddedXml<T>(string file)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var nameSpace = assembly.GetName().Name;

            try
            {
                using (Stream stream = assembly.GetManifestResourceStream(nameSpace + "." + file))
                {
                    using (var reader = new StreamReader(stream))
                    {
                        XmlSerializer xmlSer = new XmlSerializer(typeof(T));
                        return (T)xmlSer.Deserialize(stream);
                    }
                }
            }
            catch (Exception x)
            {
                return default(T);
            }
        }

        internal static void WriteXML<T>(string file, T data)
        {
            FileStream stream;
            XmlSerializer xmlSer = new XmlSerializer(typeof(T));
            stream = new FileStream(file, FileMode.Create);
            xmlSer.Serialize(stream, data);
            stream.Close();
        }

        internal static T ReadXML<T>(string file)
        {
            try
            {
                using (StreamReader sr = new StreamReader(file))
                {
                    XmlSerializer xmlSer = new XmlSerializer(typeof(T));
                    return (T)xmlSer.Deserialize(sr);
                }
            }
            catch (Exception x)
            {
                return default(T);
            }
        }

        internal static void StoreXML<T>(string file, T workouts)
        {
            FileStream stream;
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            stream = new FileStream(file, FileMode.Create);
            serializer.Serialize(stream, workouts);
            stream.Close();
        }
    }
}