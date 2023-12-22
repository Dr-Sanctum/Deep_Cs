
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Server
{
    [Table("Users")]
    public partial class User
    {
        [Key, Column("Id")]
        public int Id { get; set; }

        [Column("Name")]
        public string Name { get; set; }

        public virtual ICollection<Message> Messages { get; set; }
    }
}
