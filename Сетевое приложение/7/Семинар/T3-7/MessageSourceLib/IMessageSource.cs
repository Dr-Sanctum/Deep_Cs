namespace MessageSourceLib
{
    public interface IMessageSource <T, T1>
    {

        void Sender(T1 server, T client, byte[] byteMessage);

        byte[] Resiver(T1 thisClient, ref T clientAdress);
    }
}