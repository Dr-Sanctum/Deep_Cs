using System.Net;
using System.Net.Sockets;

namespace Chat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using(TcpClient client = new TcpClient())
            {
                client.Connect(IPAddress.Parse("127.0.0.1"), 12345);

                var reader = new StreamReader(client.GetStream());
                var writer = new StreamWriter(client.GetStream());

                var messageClient = new Message() {Text = "Привет сервер", DataTime = DateTime.Now, NickNameFrom = "Клиент", NickNameTo = "Сервер" };

                writer.WriteLine(messageClient.SerializeMessageToJson());
                writer.Flush();

                var messageFromServer = Message.DeserialiseFromJason(reader.ReadLine());

                Console.WriteLine(messageFromServer);
            }
            Console.ReadKey();
        }
    }
}