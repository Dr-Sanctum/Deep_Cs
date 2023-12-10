using System.Net;
using System.Net.Sockets;

namespace Chat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            new Task(() =>
            {
                using (TcpClient client = new TcpClient())
                {
                    client.Connect(IPAddress.Parse("127.0.0.2"), 12345);
                    var reader = new StreamReader(client.GetStream());
                    var writer = new StreamWriter(client.GetStream());


                    for (int i = 0; i < 100; i++)
                    {
                        Thread.Sleep(1500);
                        var messageClient = new Message() { Text = "Привет сервер", DataTime = DateTime.Now, NickNameFrom = "Клиент " + i, NickNameTo = "Сервер" };

                        writer.WriteLine(messageClient.SerializeMessageToJson());
                        writer.Flush();

                        var messageFromServer = Message.DeserialiseFromJason(reader.ReadLine());

                        Console.WriteLine(messageFromServer);

                        Console.WriteLine("Введите exit для завершения");
                        string exit = Console.ReadLine();
                        if (exit != null && exit.ToLower().Equals("exit"))
                        {
                            break;
                        }

                    }

                }
            }).Start();
        }
    }
}