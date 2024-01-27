using System.ComponentModel.DataAnnotations.Schema;

namespace T4_1.Model.DTO
{

    public class ProductDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int Cost { get; set; }

        public virtual Category? Category { get; set; }

        public virtual Store? Stores { get; set; }
    }
}
