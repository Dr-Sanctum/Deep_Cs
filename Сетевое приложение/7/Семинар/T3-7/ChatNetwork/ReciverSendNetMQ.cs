using MessageSourceLib;
using NetMQ;
using NetMQ.Sockets;
using System.Net;

namespace ChatNetworkLib
{
    public class ReciverSendNetMQ : IMessageSource<IPEndPoint, DealerSocket>
    {
        public byte[] Resiver(DealerSocket thisClient, ref IPEndPoint clientAdress)
        {


            var resiveMessageByte = thisClient.ReceiveMultipartMessage();

            string[] ipEndPort = resiveMessageByte.First.ConvertToString().Substring(6).Split(":");
            clientAdress = new IPEndPoint(IPAddress.Parse(ipEndPort[0]), int.Parse(ipEndPort[1]));
            return resiveMessageByte.Last.Buffer;



        }

        public void Sender(DealerSocket thisClient, IPEndPoint client, byte[] byteMessage)
        {

            thisClient.Connect($"tcp://{client}");
            var sendMessage = new NetMQMessage();
            sendMessage.Append(thisClient.Options.LastEndpoint);
            sendMessage.Append(byteMessage);
            thisClient.SendMultipartMessage(sendMessage);

        }
    }
}
