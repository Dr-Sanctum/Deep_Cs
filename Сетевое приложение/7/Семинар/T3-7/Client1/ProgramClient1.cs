using ChatNetworkLib;
using MessageSourceLib;
using NetMQ.Sockets;
using System.Net;
using System.Net.Sockets;

namespace Client1
{
    internal class ProgramClient1
    {
        
        static void Main(string[] args)
        {
            //IMessageSource<IPEndPoint, UdpClient> newMessageSource = new ReciveSendUDP();
            IMessageSource<IPEndPoint, DealerSocket> newMessageSource = new ReciverSendNetMQ();
            var client = new PresenterClient1(newMessageSource);
            client.Client();
        }

    }
}