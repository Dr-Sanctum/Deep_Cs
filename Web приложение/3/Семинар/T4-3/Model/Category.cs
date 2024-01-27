using System.ComponentModel.DataAnnotations.Schema;

namespace T4_1.Model
{
    [Table("Категория")]
    public class Category : BaseModel
    {
        public Category(string name, string description) { 
            base.Name = name;
            base.Description = description;
        }
    }
}
