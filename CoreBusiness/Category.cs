﻿using System.ComponentModel.DataAnnotations;

namespace CoreBusiness
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;

        public List<Book>? Books { get; set; }
    }
}
