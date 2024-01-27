using System.ComponentModel.DataAnnotations.Schema;

namespace T4_1.Model.DTO
{
    [Table("Категория")]
    public class StoreDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int Count { get; set; }
    }
}
