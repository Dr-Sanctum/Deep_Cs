using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Server
{
    public interface IMessageSource
    {

        void UdpSender(IPEndPoint server, IPEndPoint client, byte[] byteMessage);

        byte[] UdpResiver(UdpClient thisUDPClient, ref IPEndPoint clientIPEndPoint);
    }
}
