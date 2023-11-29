//Напишите приложение, конвертирующее произвольный JSON в XML.

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

            
            */

            using (var streamJSON = File.OpenRead("serial.json"))
            {
                
                MyClass? newMyClass = JsonSerializer.Deserialize<MyClass>(streamJSON);

                using (var stream = File.OpenWrite("serial1.xml"))
                {
                    serialiser.Serialize(stream, newMyClass);
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