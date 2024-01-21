﻿

using System.ComponentModel.DataAnnotations.Schema;

namespace T4_1.Model.DTO
{
   
    public class CategoryDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
}
