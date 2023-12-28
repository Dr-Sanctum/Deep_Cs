using MessageSourceLib;
using System.Net.Sockets;

namespace ChatNetwokMQLib
{
    public class ReciveSendMQ : IMessageSource<>
    {
{
        public byte[] UdpResiver(UdpClient thisUDPClient, ref T clientIPEndPoint)
        {
            throw new NotImplementedException();
        }

        public void UdpSender(T server, T client, byte[] byteMessage)
        {
            throw new NotImplementedException();
        }
    }
}
}