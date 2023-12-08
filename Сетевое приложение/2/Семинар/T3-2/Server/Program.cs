using System.Net;
using System.Net.Sockets;

namespace Chat

{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool flag = true;
            var listener = new TcpListener(IPAddress.Any, 12345);
            listener.Start();

            using (TcpClient client = listener.AcceptTcpClient())
            {
                Console.WriteLine("Connected");
                var reader = new StreamReader(client.GetStream());
                var writer = new StreamWriter(client.GetStream());
                new Thread(() =>
                {
                    Console.ReadKey(true);
                    Console.WriteLine("Сервер завершает свою работу");
                    flag = false;
                }).Start();

                while (flag)
                {
                    Thread.Sleep(500);
                    new Thread(() =>
                    {



                        var messageFromClient = Message.DeserialiseFromJason(reader.ReadLine());
                        Console.WriteLine($"{messageFromClient}");

                        var messageServer = new Message() { Text = "Привет клиент, получил твоё сообщение", DataTime = DateTime.Now, NickNameFrom = "Сервер", NickNameTo = messageFromClient.NickNameFrom };
                        writer.WriteLine(messageServer.SerializeMessageToJson());
                        writer.Flush();
                    }).Start();
                }

            }

        }
    }
}