using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;

namespace Chat

{
    internal class Program
    {
        static private CancellationTokenSource _cts = new CancellationTokenSource();
        static private CancellationToken _ct = _cts.Token;
        static void Main(string[] args)
        {
           
            
            var listener = new TcpListener(IPAddress.Any, 12345);
            listener.Start();

            using (TcpClient client = listener.AcceptTcpClient())
            {
                Console.WriteLine("Connected");
                var reader = new StreamReader(client.GetStream());
                var writer = new StreamWriter(client.GetStream());
                new Task(() =>
                {
                    Console.ReadKey(true);
                    Console.WriteLine("Сервер завершает свою работу");
                    _cts.Cancel();
                }).Start();

                while (!_ct.IsCancellationRequested)
                {
                    Thread.Sleep(500);
                    new Task(() =>
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