using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace ModelDBLib
{
    [Table("Messages")]
    public partial class MessageDB
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
        public virtual UserDB user { get; set; }

        public MessageDB(string text, DateTime dataTime, string nickNameFrom, string nickNameTo)
        {
            Text = text;
            DataTime = dataTime;
            NickNameFrom = nickNameFrom;
            NickNameTo = nickNameTo;
        }

        public string SerializeMessageToJson() => JsonSerializer.Serialize(this);

        public static MessageDB DeserialiseFromJason(string message) => JsonSerializer.Deserialize<MessageDB>(message);

        public override string ToString()
        {
            return $"Время: {DataTime}, От кого: {NickNameFrom}, Кому: {NickNameTo} \n {Text}";
        }

        public MessageDB Clone()
        {
            return new MessageDB(Text, DataTime, NickNameFrom, NickNameTo);
        }
    }
}