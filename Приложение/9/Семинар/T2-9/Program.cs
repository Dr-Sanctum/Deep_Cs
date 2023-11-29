using System.Text.Json;
using System.Xml.Serialization;

namespace T2_9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var serialiser = new XmlSerializer(typeof(MyClass));

            /*
            MyClass s = new MyClass() { g = 5 };

            using (var stream = File.OpenWrite("serial.xml"))
            {
                serialiser.Serialize(stream, s);
            }
            */

            using (var streamXML = File.OpenRead("serial.xml"))
            {
                MyClass? newMyClass = (MyClass?)serialiser.Deserialize(streamXML);

                string str = JsonSerializer.Serialize<MyClass>(newMyClass, new JsonSerializerOptions { IncludeFields = true });
                using (var streamJSON = new StreamWriter("serial.json"))
                {
                    streamJSON.Write(str);
                }
            }


        }
    }

    public class MyClass
    {
        public string[] str = new string[] { "One", "Two", "Three" };
        public int g = 1;

        public IncludeMyClass include = new IncludeMyClass() { l = 50 };
    }

    public class IncludeMyClass
    {
        public long l = 15;
    }

}