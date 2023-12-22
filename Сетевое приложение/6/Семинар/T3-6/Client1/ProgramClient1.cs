


namespace Client1
{
    internal class ProgramClient1
    {
        
        static void Main(string[] args)
        {
            var messageSource = new MessageSource();
            var client = new Presenter(messageSource);
            client.UDPClient();
        }

    }
}