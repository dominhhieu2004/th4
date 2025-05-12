using System.ComponentModel.DataAnnotations;

namespace th4.Application.DTOs.Comment
{
    public class CreateComment
    {
        [Required]
        [StringLength(500000, MinimumLength = 1)]
        public string Title { get; set; } = string.Empty;
        [Required]
        [StringLength(500000, MinimumLength = 1)]
        public string Content { get; set; } = string.Empty;
    }
}
