namespace Anota.Api.Models.Notes
{
    public record CreateNoteResponse(
        int Id,
        string Title,
        string Subtitle,
        string Description,
        string? Category,
        DateTime CreatedAt
    );
}
