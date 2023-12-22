
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;

namespace Server
{
    [Table("Messages")]
    public partial class Message
    {
        [Key, Column("Id")]
        public int Id { get; set; }

        [Column("Message")]
        public string Text { get; set; }

        [Column("Дата_Время")]
        public DateTime DataTime { get; set; }

        [Column("Отправитель")]
        public string NickNameFrom { get; set; }

        [Column("Получатель")]
        public string NickNameTo { get; set; }

        [ForeignKey("User_Id")]
        public virtual User user { get; set; }

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