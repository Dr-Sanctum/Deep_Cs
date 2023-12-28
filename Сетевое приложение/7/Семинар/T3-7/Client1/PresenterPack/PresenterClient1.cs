

using MessageSourceLib;
using System.Net;
using System.Net.Sockets;
using System.Text;
using ModelDBLib;
using NetMQ.Sockets;

namespace Client1
{
    public class PresenterClient1
    {
        private static IPEndPoint iPEndPointServer = new IPEndPoint(IPAddress.Parse("192.168.0.103"), 1234);
        private static IPEndPoint iPEndPointThisClient = new IPEndPoint(IPAddress.Parse("192.168.0.103"), 3333);

        public IMessageSource<IPEndPoint, DealerSocket> MessageSource;
        public PresenterClient1(IMessageSource<IPEndPoint, DealerSocket> messageSource)
        {
            MessageSource = messageSource;
        }
        public void Client()
        {

            using (var client = new DealerSocket())
            {
                client.Bind($"tcp://{iPEndPointThisClient}");
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


                    var message = new Message(text, DateTime.Now, "Клиент1", addressee);

                    byte[] messageByte = Encoding.Default.GetBytes(message.SerializeMessageToJson());

                    var cli = new Task(() => { MessageSource.Sender(client, iPEndPointServer, messageByte); });
                    cli.Start();
                    cli.Wait();
                    Thread.Sleep(100);
                    new Task(() => { UdpClientResiver(client); }).Start();
                }
            }
        }


        void UdpClientResiver(DealerSocket client)
        {
            var lp = new IPEndPoint(IPAddress.Any, 1);
            while (true)
            {

                    var recv = MessageSource.Resiver(client,ref lp);
                    string messageJSON = Encoding.Default.GetString(recv);

                    Message reciveMessage = Message.DeserialiseFromJason(messageJSON);

                    Console.WriteLine(reciveMessage);
                
            }
        }
    }
}
