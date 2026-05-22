using Anota.Api.Data;
using Anota.Api.Entities;
using Anota.Api.Models.Notes;
using Microsoft.EntityFrameworkCore;

namespace Anota.Api.Services.Notes
{
    public class NoteService(AppDbContext context) : INoteService
    {
        public async Task<CreateNoteResponse> CreateNoteAsync(CreateNoteRequest request)
        {
            var newNote = new Note
            {
                Title = request.Title,
                Subtitle = request.Subtitle,
                Description = request.Description,
                Category = request.Category,
                CreatedAt = DateTime.UtcNow
            };

            context.Notes.Add(newNote);
            await context.SaveChangesAsync();

            var result = new CreateNoteResponse(
                newNote.Id,
                newNote.Title,
                newNote.Subtitle,
                newNote.Description,
                newNote.Category,
                newNote.CreatedAt
            );

            return result;
        }

        public async Task<List<Note>> GetNotesAsync()
        {
            var notes = await context.Notes
                .AsNoTracking()
                .OrderByDescending(n => n.CreatedAt)
                .ToListAsync();

            return notes;
        }
    }
}
