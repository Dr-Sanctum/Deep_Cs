using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Client1
{
    public interface IMessageSource
    {

        void UdpSender(IPEndPoint server, IPEndPoint client, byte[] byteMessage);

        byte[] UdpResiver(UdpClient thisUDPClient, ref IPEndPoint clientIPEndPoint);
    }
}
