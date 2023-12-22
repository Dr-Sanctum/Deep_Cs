
namespace Server
{
    internal class ProgramServer
    {
        static void Main(string[] args)
        {
            Presenter newPresenter = new Presenter(new MessageSourcetest());
            var serverReciver = new Task(newPresenter.UdpServer);
            serverReciver.Start();
            serverReciver.Wait();
        }
    }
}