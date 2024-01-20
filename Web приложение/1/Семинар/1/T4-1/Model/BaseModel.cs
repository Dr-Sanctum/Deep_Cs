using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace T4_1.Model
{
    public abstract class BaseModel
    {
        [Key, Column("Id")]
        public int Id { get; set; }

        [Column("Название")]
        public string? Name { get; set; }
        [Column("Описание")]
        public string? Description { get; set; }
    }
}
