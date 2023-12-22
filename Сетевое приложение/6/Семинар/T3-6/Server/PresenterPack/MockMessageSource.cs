using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Server
{
    public class MockMessageSource : IMessageSource
    {
        public byte[] UdpResiver(UdpClient thisUDPClient, ref IPEndPoint clientIPEndPoint)
        {
            
            return Encoding.Default.GetBytes(new Message("Привет", DateTime.Now, "Клиент1", "Клиент2").SerializeMessageToJson());

        }

        public virtual void UdpSender(IPEndPoint server, IPEndPoint client, byte[] byteMessage)
        {
            
        }
    }
}
