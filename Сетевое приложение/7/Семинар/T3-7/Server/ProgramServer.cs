
using ChatNetworkLib;
using MessageSourceLib;
using NetMQ.Sockets;
using System.Net;
using System.Net.Sockets;

namespace Server
{
    internal class ProgramServer
    {
        static void Main(string[] args)
        {
            IMessageSource<IPEndPoint, DealerSocket> newMessageSource = new ReciverSendNetMQ();
            PresenterServer newPresenter = new PresenterServer(newMessageSource);
            var serverReciver = new Task(newPresenter.UdpServer);
            serverReciver.Start();
            serverReciver.Wait();
        }
    }
}