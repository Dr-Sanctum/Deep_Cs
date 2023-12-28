using MessageSourceLib;
using System.Net;
using System.Net.Sockets;

namespace ChatNetworkLib
{
    /*
    public class ReciverSendUDP : IMessageSource<IPEndPoint, UdpClient>
    {
        public byte[] Resiver(UdpClient thisUDPClient, ref IPEndPoint clientIPEndPoint)
        {

            return thisUDPClient.Receive(ref clientIPEndPoint);

        }

        public void Sender(IPEndPoint server, IPEndPoint client, byte[] byteMessage)
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
    */

}