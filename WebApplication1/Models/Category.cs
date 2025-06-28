using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        [MinLength(1)]
        public string Name { get; set; }
        [Required]
        [MaxLength(100)]
        [MinLength(5)]
        public string Description { get; set; }

      
        public List<Product> ? product { get; set;}
    }
}
