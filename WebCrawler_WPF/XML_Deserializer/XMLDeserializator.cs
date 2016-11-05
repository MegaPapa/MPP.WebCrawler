using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WebCrawler_WPF.XML_Deserializer
{
    public static class XMLDeserializator
    {
        public static List<String> DeserializeStringList(String fileName)
        {
            List<String> result = new List<String>();
            var serializer = new XmlSerializer(typeof(List<string>));
            using (var stream = File.OpenRead(fileName))
            {
                var other = (List<String>)(serializer.Deserialize(stream));
                result.AddRange(other);
            }
            return result;
        }
    }
}
