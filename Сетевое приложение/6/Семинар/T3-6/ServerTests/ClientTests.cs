using Client1;

using System.Net;
using System.Net.Sockets;
using System.Text;
using Moq;

namespace ServerTests
{
    public class TestsClient
    {
        [SetUp]
        public void Setup()
        {
        }
        [Test]
        public void TestSendMessage()
        {
            var mock = new Mock<MockMessageSource>();
            //mock.Setup(mock => mock.UdpSender(It.IsAny<IPEndPoint>(), It.IsAny<IPEndPoint>(), It.IsAny<byte[]>()));

            var pres = new Presenter(mock.Object);
            pres.UDPClient();

            mock.Verify(mock => mock.UdpSender(It.IsAny<IPEndPoint>(), It.IsAny<IPEndPoint>(), It.IsAny<byte[]>()), Times.Once);



        }
        [Test]
        public void TestReciveMessage()
        {
            var mock = new Mock<MockMessageSource>();
            //mock.Setup(mock => mock.UdpSender(It.IsAny<IPEndPoint>(), It.IsAny<IPEndPoint>(), It.IsAny<byte[]>()));

            var pres = new Presenter(mock.Object);
            pres.UDPClient();
            var testIPEP = new IPEndPoint(IPAddress.Any, 0000);
            mock.Verify(mock => mock.UdpResiver(It.IsAny<UdpClient>(), ref testIPEP), Times.Never);

           



        }
    }
}