using System.Net;
using System.Net.Sockets;

namespace Server
{
    public class MessageSource : IMessageSource
    {
        public byte[] UdpResiver(UdpClient thisUDPClient, ref IPEndPoint clientIPEndPoint)
        {
            
            return thisUDPClient.Receive(ref clientIPEndPoint);
            
        }

        public void UdpSender(IPEndPoint server, IPEndPoint client, byte[] byteMessage)
        {
            using (var newClient = new UdpClient())
            {
                newClient.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
                newClient.Client.Bind(server);
                newClient.Connect(client);
                newClient.Send(byteMessage);
            }
        }
    }
}
