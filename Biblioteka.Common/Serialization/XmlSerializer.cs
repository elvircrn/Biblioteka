using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Biblioteka.Common.Serialization
{
    public class XMLSerializer
    {
        public static T DeserializeXmlString<T>(string xmlString)
        {
            T tempObject;

            using (var memoryStream = new MemoryStream(StringToUTF8ByteArray(xmlString)))
            {
                var xs = new XmlSerializer(typeof(T));
                tempObject = (T)xs.Deserialize(memoryStream);
            }

            return tempObject;
        }

        public static string SerializeToXmlString<T>(ICollection<T> toSerialize)
        {
            string xmlstream;

            using (var memstream = new MemoryStream())
            {
                var xmlSerializer = new XmlSerializer(typeof(T));
                var xmlWriter = new XmlTextWriter(memstream, Encoding.UTF8);

                xmlSerializer.Serialize(xmlWriter, toSerialize);
                xmlstream = UTF8ByteArrayToString(((MemoryStream)xmlWriter.BaseStream).ToArray());
            }

            return xmlstream;
        }


        public static string SerializeToXmlString<T>(T toSerialize)
        {
            string xmlstream;

            using (var memstream = new MemoryStream())
            {
                var xmlSerializer = new XmlSerializer(typeof(T));
                var xmlWriter = new XmlTextWriter(memstream, Encoding.UTF8);

                xmlSerializer.Serialize(xmlWriter, toSerialize);
                xmlstream = UTF8ByteArrayToString(((MemoryStream)xmlWriter.BaseStream).ToArray());
            }

            return xmlstream;
        }

        private static byte[] StringToUTF8ByteArray(string xmlString)
        {
            return new UTF8Encoding().GetBytes(xmlString);
        }

        private static string UTF8ByteArrayToString(byte[] arrBytes)
        {
            return new UTF8Encoding().GetString(arrBytes);
        }
    }
}
