using System.Net;
using System.Net.Sockets;

namespace Chat

{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            var listener = new TcpListener(IPAddress.Any, 12345);
            listener.Start();

            using (TcpClient client = listener.AcceptTcpClient())
            {
                Console.WriteLine("Connected");

                var reader = new StreamReader(client.GetStream());
                var writer = new StreamWriter(client.GetStream());

                var messageFromClient = Message.DeserialiseFromJason(reader.ReadLine());
                Console.WriteLine($"{messageFromClient}");

                var messageServer = new Message() { Text = "Привет клиент, получил твоё сообщение", DataTime = DateTime.Now, NickNameFrom = "Сервер", NickNameTo = "Клиент" };
                writer.WriteLine(messageServer.SerializeMessageToJson());
                writer.Flush();
                

            }
        }
    }
}