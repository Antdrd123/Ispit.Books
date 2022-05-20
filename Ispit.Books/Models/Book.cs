using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ispit.Books.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }


        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string Title { get; set; }

       
        [ForeignKey("AuthorId")]
        public Author Author { get; set; }
        public int AuthorId { get; set; }

        
        [ForeignKey("PublisherId")]
        public Publisher Publisher { get; set; }
        public int PublisherId { get; set; }

        
        [ForeignKey("UserId")]
        public IdentityUser User { get; set; }
        public string UserId { get; set; }
    }
}
