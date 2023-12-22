

using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Client1
{
    public class Presenter
    {
        private static IPEndPoint iPEndPointServer = new IPEndPoint(IPAddress.Parse("192.168.0.103"), 1234);
        private static IPEndPoint iPEndPointThisClient = new IPEndPoint(IPAddress.Parse("192.168.0.103"), 3333);

        public IMessageSource MessageSource;
        public Presenter(IMessageSource messageSource)
        {
            MessageSource = messageSource;
        }
        public void UDPClient()
        {
            bool flag = true;
            while (flag)
            {
                Thread.Sleep(100);

                Console.WriteLine("Введите сообщение, для выхода введите exit");
               // string text = Console.ReadLine();
                string text = "Привет";
                if (text != null && text.ToLower().Equals("exit"))
                {
                    break;
                }

                Console.WriteLine("Введите адресат");
                //string addressee = Console.ReadLine();
                string addressee = "Клиент2";

                var message = new Message(text, DateTime.Now, "Клиент1", addressee);

                byte[] messageByte = Encoding.Default.GetBytes(message.SerializeMessageToJson());

                var cli = new Task(() => { MessageSource.UdpSender(iPEndPointThisClient,iPEndPointServer, messageByte); });
                cli.Start();
                cli.Wait();

                new Task(UdpClientResiver).Start();
                flag = false;
            }

        }

        void UdpClientSender(string message)
        {
            using (var client = new UdpClient())
            {
                client.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
                client.Client.Bind(new IPEndPoint(IPAddress.Parse("192.168.0.103"), 3333));
                client.Connect(iPEndPointServer);
                byte[] messageByte = Encoding.Default.GetBytes(message);
                client.Send(messageByte);
            }
        }

        void UdpClientResiver()
        {
            var lp = new IPEndPoint(IPAddress.Any, 1);
            while (true)
            {
                using (var client = new UdpClient())
                {
                    client.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
                    client.Client.Bind(iPEndPointThisClient);
                    var recv = MessageSource.UdpResiver(client,ref lp);
                    string messageJSON = Encoding.Default.GetString(recv);

                    Message reciveMessage = Message.DeserialiseFromJason(messageJSON);

                    Console.WriteLine(reciveMessage);
                }
            }
        }
    }
}
