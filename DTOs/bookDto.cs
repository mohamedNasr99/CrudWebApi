using System.ComponentModel.DataAnnotations;

namespace bookproject.DTOs
{
    public class bookDto
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public int authorId { get; set; }
        [Required]
        public int categoryId { get; set; }

    }
}
