using Server;

using System.Net;
using System.Net.Sockets;
using System.Text;
using Moq;

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

                var mock = new Mock<MockMessageSource>();
                mock.Setup(mock => mock.UdpSender(It.IsAny<IPEndPoint>(), It.IsAny<IPEndPoint>(), It.IsAny<byte[]>()));

                var pres = new Presenter(mock.Object);
                pres.UdpServer();

                mock.Verify(mock => mock.UdpSender(It.IsAny<IPEndPoint>(), It.IsAny<IPEndPoint>(), It.IsAny<byte[]>()),Times.Once);

            
            
        }
    }
}