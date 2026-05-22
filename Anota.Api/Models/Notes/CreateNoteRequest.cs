using System.ComponentModel.DataAnnotations;

namespace Anota.Api.Models.Notes
{
    public record CreateNoteRequest(
        [Required(ErrorMessage = "Title is required.")]
        [StringLength(150, ErrorMessage = "Title cannot exceed 150 characters.")]
        string Title,
        [StringLength(250, ErrorMessage = "Subtitle cannot exceed 250 characters.")]
        string Subtitle,
        string Description,
        [StringLength(50, ErrorMessage = "Category cannot exceed 50 characters.")]
        string? Category
    );
}
