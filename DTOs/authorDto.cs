using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace bookproject.DTOs
{
    public class authorDto
    {
        [Required]
        public string Name { get; set; }
        public ICollection<bookDto> Books { get; set; }
    }
}
