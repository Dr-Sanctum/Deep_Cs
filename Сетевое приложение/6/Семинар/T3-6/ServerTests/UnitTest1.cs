using Server;
using Moq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;

namespace ServerTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestSendMessage()
        {
            IPEndPoint iPEndPointServer = new IPEndPoint(IPAddress.Any, 0);
            IPEndPoint iPEndPointClient = new IPEndPoint(IPAddress.Any, 1);

            byte[] message = Encoding.Default.GetBytes(new Message("Привет", DateTime.Now, "Клиент1", "Клиент2").SerializeMessageToJson());
            


            using (var client = new UdpClient(4565))
            {
                var mock = new Mock<IMessageSource>();

                mock.Setup(x => x.UdpResiver(client, ref iPEndPointClient)).Returns(message);
                //mock.Setup(x => x.UdpSender(iPEndPointClient, iPEndPointServer, message));

                var pres = new Presenter(mock.Object);
                pres.UdpServer();
                
                mock.Verify(x => x.UdpSender(iPEndPointClient, iPEndPointServer, message), Times.Once);
            }
            
        }
    }
}