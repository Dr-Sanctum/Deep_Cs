using System.Text.Json;

namespace Chat
{
    public class Message
    {
        public string Text { get; set; }
        public DateTime DataTime { get; set; }

        public string NickNameFrom { get; set; }

        public string NickNameTo { get; set; }

        public Message(string text, DateTime dataTime, string nickNameFrom, string nickNameTo)
        {
            Text = text;
            DataTime = dataTime;
            NickNameFrom = nickNameFrom;
            NickNameTo = nickNameTo;
        }

        public string SerializeMessageToJson() => JsonSerializer.Serialize(this);

        public static Message DeserialiseFromJason(string message) => JsonSerializer.Deserialize<Message>(message);

        public override string ToString()
        {
            return $"Время: {DataTime}, От кого: {NickNameFrom}, Кому: {NickNameTo} \n {Text}";
        }

        public Message Clone()
        {
            return new Message(Text, DataTime, NickNameFrom, NickNameTo);
        }
    }

}