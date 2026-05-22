using Anota.Api.Entities;
using Anota.Api.Models.Auth;
using Anota.Api.Models.Notes;

namespace Anota.Api.Services.Notes
{
    public interface INoteService
    {
        Task<CreateNoteResponse> CreateNoteAsync(CreateNoteRequest request);
        Task<List<Note>> GetNotesAsync();
    }
}
