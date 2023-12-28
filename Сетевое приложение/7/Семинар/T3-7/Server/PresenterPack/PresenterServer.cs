
using System.Net.Sockets;
using System.Net;
using System.Text;
using MessageSourceLib;
using ModelDBLib;
using NetMQ.Sockets;

namespace Server
{

    public class PresenterServer
    {
        private static CancellationTokenSource _cts = new CancellationTokenSource();
        private static CancellationToken _ct = _cts.Token;

        private Dictionary<string, IPEndPoint> clientList = new Dictionary<string, IPEndPoint>();
        private IPEndPoint ServerIPEndPoint = new IPEndPoint(IPAddress.Parse("192.168.0.103"), 1234);
       
        public IMessageSource<IPEndPoint, DealerSocket> MessageSource;

        public PresenterServer(IMessageSource<IPEndPoint, DealerSocket> messageSource)
        {
            MessageSource = messageSource;
        }



        public void UdpServer()
        {
            //Сервер предварительно добавляет себя в список возможных клиентов

            AddClient("Сервер", ServerIPEndPoint);

            using (var client = new DealerSocket())
            {
                
                client.Bind($"tcp://{ServerIPEndPoint}");

                var clientIPEndPoint = new IPEndPoint(IPAddress.Any, 0000);

                new Task(() =>
                {
                    Console.ReadKey(true);
                    Console.WriteLine("Сервер завершает свою работу");
                    _cts.Cancel();
                }).Start();


                while (!_ct.IsCancellationRequested)

                {
                    var recv = MessageSource.Resiver(client, ref clientIPEndPoint);

                   

                    string messageJSON = Encoding.Default.GetString(recv);

                    MessageDB reciveMessage = MessageDB.DeserialiseFromJason(messageJSON);



                    Console.WriteLine(reciveMessage);

                    if (reciveMessage.NickNameTo.ToLower().Equals("сервер"))
                    {
                        switch (reciveMessage.Text.ToLower())
                        {
                            case "register":
                                AddClient(reciveMessage.NickNameFrom, clientIPEndPoint);
                                break;
                            case "delete":
                                clientList.Remove(reciveMessage.NickNameFrom);
                                break;
                            case "clients":
                                StringBuilder stringBuilder = new StringBuilder();
                                stringBuilder.Append("Список адресатов: ");
                                foreach (var item in clientList.Keys)
                                {
                                    stringBuilder.Append($"{item} ");
                                }
                                var messageByteServer = MakeMessageToSend(stringBuilder.ToString(), DateTime.Now, "Сервер", reciveMessage.NickNameFrom);

                                new Task(() => { MessageSource.Sender(client, clientList[reciveMessage.NickNameFrom], messageByteServer); }).Start();
                                break;
                            default:
                                break;
                        }
                        continue;
                    }
                    if (!clientList.ContainsKey(reciveMessage.NickNameFrom))
                    {
                        var messageByteServer = MakeMessageToSend("Вы не зарегистрированы", DateTime.Now, "Сервер", reciveMessage.NickNameFrom);

                        new Task(() => { MessageSource.Sender(client, clientIPEndPoint, messageByteServer); }).Start();

                        continue;
                    }

                    // Отправка сообщения всем зарегистрированным адерсатам кроме сервера
                    if (reciveMessage.NickNameTo == string.Empty)
                    {
                        MessageDB messageAll = reciveMessage.Clone();
                        messageAll.NickNameTo = "Всем";

                        foreach (var nameClient in clientList.Keys)
                        {
                            if (nameClient.Equals("Сервер"))
                            {
                                continue;
                            }

                            new Task(() => { MessageSource.Sender(client, clientList[nameClient], Encoding.Default.GetBytes(messageAll.SerializeMessageToJson())); }).Start();
                        }
                        continue;
                    }

                    if (!clientList.ContainsKey(reciveMessage.NickNameTo))
                    {
                        var messageByteServer = MakeMessageToSend("Клиента с таким именем не зарегистрировано", DateTime.Now, "Сервер", reciveMessage.NickNameFrom);

                        new Task(() => { MessageSource.Sender(client, clientList[reciveMessage.NickNameFrom], messageByteServer); }).Start();
                        continue;
                    }

                    // Отправка сообщения адресату если он есть
                    new Task(() => { MessageSource.Sender(client, clientList[reciveMessage.NickNameTo], recv); }).Start();

                }
            }
        }


        private byte[] MakeMessageToSend(string text, DateTime dataTime, string nickNameFrom, string nickNameTo)
        {
            var messageServer = new MessageDB(text, dataTime, nickNameFrom, nickNameTo);
            return Encoding.Default.GetBytes(messageServer.SerializeMessageToJson());
        }

        private void AddClient(string clientName, IPEndPoint iPEndPointClient)
        {
            clientList.TryAdd(clientName, iPEndPointClient);
        }


    }
}
