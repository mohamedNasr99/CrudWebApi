using System.ComponentModel.DataAnnotations;

namespace bookproject.DTOs
{
    public class categoryDto
    {
        [Required]
        public string Name { get; set; }
        public List<bookDto> Books { get; set; }
    }
}
