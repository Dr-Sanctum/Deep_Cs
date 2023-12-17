using System;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Net;
using System.Net.Sockets;
using System.Text;
using static System.Net.Mime.MediaTypeNames;


namespace Chat

{
    internal class ProgramServer
    {
        static private CancellationTokenSource _cts = new CancellationTokenSource();
        static private CancellationToken _ct = _cts.Token;
        

        static void UdpServerReciver()
        {
            //Сервер предварительно добавляет себя в список возможных клиентов
            var clientList = new Dictionary<string, IPEndPoint>
            {
                { "Сервер", new IPEndPoint(IPAddress.Parse("192.168.0.103"), 1234) }
            };

            using (var client = new UdpClient())
            {
                client.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
                client.Client.Bind(new IPEndPoint(IPAddress.Parse("192.168.0.103"), 1234));
                var lp = new IPEndPoint(IPAddress.Any, 1111);
                while (!_ct.IsCancellationRequested)
                {
                    var recv = client.Receive(ref lp);
                    
                    string messageJSON = Encoding.Default.GetString(recv);

                    Message reciveMessage = Message.DeserialiseFromJason(messageJSON);

                    

                    Console.WriteLine(reciveMessage);

                    if (reciveMessage.NickNameTo.Equals("Сервер"))
                    {
                        switch (reciveMessage.Text.ToLower())
                        {
                            case "register":
                                clientList.TryAdd(reciveMessage.NickNameFrom, lp);
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

                                new Task(() => { UdpClientSender(clientList[reciveMessage.NickNameFrom], messageByteServer); }).Start();
                                break;
                            default:
                                break;
                        }
                        continue;
                    }
                    if (!clientList.ContainsKey(reciveMessage.NickNameFrom))
                    {
                        var messageByteServer = MakeMessageToSend("Вы не зарегистрированы", DateTime.Now, "Сервер", reciveMessage.NickNameFrom);

                        new Task(() => { UdpClientSender(lp, messageByteServer); }).Start();
                        continue;
                    }

                    if (reciveMessage.NickNameTo == string.Empty)
                    {
                        Message messageAll = reciveMessage.Clone();
                        messageAll.NickNameTo = "Всем";

                        foreach (var nameClient in clientList.Keys)
                        {
                            if (nameClient.Equals("Сервер"))
                            {
                                continue;
                            }
                            
                            new Task(() => { UdpClientSender(clientList[nameClient], Encoding.Default.GetBytes(messageAll.SerializeMessageToJson())); }).Start();
                        }
                        continue;
                    }

                    if (!clientList.ContainsKey(reciveMessage.NickNameTo))
                    {
                        var messageByteServer = MakeMessageToSend("Клиента с таким именем не зарегистрировано", DateTime.Now, "Сервер", reciveMessage.NickNameFrom);

                        new Task(() => { UdpClientSender(clientList[reciveMessage.NickNameFrom], messageByteServer); }).Start();
                        continue;
                    }
                    new Task(() => { UdpClientSender(clientList[reciveMessage.NickNameTo], recv); }).Start();
                    
                }
               
            }
        }


        static byte[] MakeMessageToSend(string text, DateTime dataTime, string nickNameFrom, string nickNameTo)
        {
            var messageServer = new Message(text, dataTime, nickNameFrom, nickNameTo);
            return Encoding.Default.GetBytes(messageServer.SerializeMessageToJson());
        }

        static void UdpClientSender(IPEndPoint client, byte[] byteMessage)
        {
            using (var newClient = new UdpClient())
            {
                newClient.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
                newClient.Client.Bind(new IPEndPoint(IPAddress.Parse("192.168.0.103"), 1234));
                newClient.Connect(client);
                newClient.Send(byteMessage);
            }
        }

        static void Main(string[] args)
        {
            
            new Task(() =>
            {
                Console.ReadKey(true);
                Console.WriteLine("Сервер завершает свою работу.");
                _cts.Cancel();
            
            }).Start();
            
            IPEndPoint IPClient = new IPEndPoint(IPAddress.Any, 1234);
            var serverReciver = new Task(UdpServerReciver) ;
            serverReciver.Start();
            
            serverReciver.Wait();
            

        }
    }
}