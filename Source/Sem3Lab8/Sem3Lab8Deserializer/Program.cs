using System.Xml.Serialization;
using Sem3Lab8;

namespace Sem3Lab8Deserializer
{
    class Program
    {
        static void Main()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Animal));
            using (FileStream fileStream = new FileStream("1.xml", FileMode.Open))
            {
                Animal deserializator = (Animal)serializer.Deserialize(fileStream);
                Console.WriteLine(deserializator.ToString());
            }
        }
    }
}