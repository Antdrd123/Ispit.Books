using System.ComponentModel.DataAnnotations;

namespace Ispit.Books.Models
{
    public class Author
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string Name { get; set; }
    }
    
}
