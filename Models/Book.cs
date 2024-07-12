using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bookproject.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public required string Title { get; set; }
        [ForeignKey("Author")]
        public int AuthorId { get; set; }
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public Author Author { get; set; }

    }
}
