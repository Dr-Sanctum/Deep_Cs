using System.ComponentModel.DataAnnotations.Schema;

namespace T4_1.Model
{
    [Table("Склад")]
    public class Store : BaseModel

    {
        public Store(string name, string description)
        {
            Name = name;
            Description = description;
        }
        [Column("Количество")]
        public int Count { get; set; }


        public virtual ICollection<Product>? Products { get; set; }
    }
}
