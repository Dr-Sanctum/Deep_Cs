
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ModelDBLib
{
    [Table("Users")]
    public partial class UserDB
    {
        [Key, Column("Id")]
        public int Id { get; set; }

        [Column("Name")]
        public string Name { get; set; }

        public virtual ICollection<MessageDB> Messages { get; set; }
    }
}
