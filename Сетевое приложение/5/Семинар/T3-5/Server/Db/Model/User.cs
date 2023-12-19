using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Server.Db.Model
{
    [Table("Users")]
    public partial class User
    {
        [Key, Column("Id")]
        public int Id { get; set; }

        [Column("Name")]
        public string Name { get; set; }

        public virtual ICollection<Message> Messages { get; set;}
    }
}
