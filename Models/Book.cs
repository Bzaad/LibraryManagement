using System.ComponentModel.DataAnnotations;

namespace LibraryApp.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Category")]
        public int? CategoryId { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public int? Quantity { get; set; }

        public Category? Category { get; set; }
        
    }
}
