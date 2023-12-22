using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Client1
{
    public class MockMessageSource : IMessageSource
    {
        public virtual byte[] UdpResiver(UdpClient thisUDPClient, ref IPEndPoint clientIPEndPoint)
        {

            return thisUDPClient.Receive(ref clientIPEndPoint);

        }

        public virtual void UdpSender(IPEndPoint server, IPEndPoint client, byte[] byteMessage)
        {

        }
    }
}
