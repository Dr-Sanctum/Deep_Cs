using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Chat
{
    internal class ProgramClient2
    {
        private static IPEndPoint ep = new IPEndPoint(IPAddress.Parse("192.168.0.103"), 1234);
        static void Main(string[] args)
        {
            while (true)
            {
                Thread.Sleep(100);

                Console.WriteLine("Введите сообщение, для выхода введите exit");
                string text = Console.ReadLine();
                if (text != null && text.ToLower().Equals("exit"))
                {
                    break;
                }

                Console.WriteLine("Введите адресат");
                string addressee = Console.ReadLine();

                var message = new Message() { Text = text, DataTime = DateTime.Now, NickNameFrom = "Клиент2", NickNameTo = addressee };

                var cli = new Task(() => { UdpClientSender(message.SerializeMessageToJson()); });
                cli.Start();
                cli.Wait();

                new Task(UdpClientResiver).Start();
            }
        }
        static void UdpClientSender(string message)
        {
            using (var client = new UdpClient())
            {
                client.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
                client.Client.Bind(new IPEndPoint(IPAddress.Parse("192.168.0.103"), 4444));
                client.Connect(ep);
                byte[] messageByte = Encoding.Default.GetBytes(message);
                client.Send(messageByte);
            }
        }

        static void UdpClientResiver()
        {
            var lp = new IPEndPoint(IPAddress.Any, 1);
            while (true)
            {
                using (var client = new UdpClient())
                {
                    client.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
                    client.Client.Bind(new IPEndPoint(IPAddress.Parse("192.168.0.103"), 4444));
                    var recv = client.Receive(ref lp);
                    string messageJSON = Encoding.Default.GetString(recv);

                    Message reciveMessage = Message.DeserialiseFromJason(messageJSON);

                    Console.WriteLine(reciveMessage);
                }
            }
        }
    }
}