using Anota.Api.Entities;
using Anota.Api.Models.Auth;
using Anota.Api.Models.Notes;

namespace Anota.Api.Services.Notes
{
    public interface INoteService
    {
        Task<Note?> CreateNoteAsync(CreateNoteRequest request);
        Task<List<Note>> GetNotesAsync();
        Task<Note?> GetNoteById(int noteId);
        Task<Note?> EditNoteAsync(int noteId, CreateNoteRequest request);
    }
}
