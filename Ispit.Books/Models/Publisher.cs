using System.ComponentModel.DataAnnotations;

namespace Ispit.Books.Models
{
    public class Publisher
    {
        [Key]
        public int Id { get; set; }

        
        [Required]
        [StringLength(100, MinimumLength =2)]
        public string Name { get; set; }
    }
}
