using System.ComponentModel.DataAnnotations;

namespace bookproject.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public required string Name { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}
