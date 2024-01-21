using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace T4_1.Model
{
    [Table("Продукт")]
    public class Product : BaseModel
    {
        [Column("Цена")]
        public int Cost { get; set; }

        [ForeignKey("Category_Id")]
        public virtual Category? Category { get; set; }

        [ForeignKey("Store_Id")]
        public virtual Store? Stores { get; set; }

        public Product(string name, string description, int cost)
        {
            base.Name = name;
            base.Description = description;
            this.Cost = cost;
        }
        public override string? ToString()
        {
            return $"Название: {base.Name}, Описание: {base.Description}, Цена: {Cost}";
        }
    }

    
}
