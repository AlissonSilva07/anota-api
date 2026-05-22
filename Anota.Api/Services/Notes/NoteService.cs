using Anota.Api.Data;
using Anota.Api.Entities;
using Anota.Api.Models.Notes;
using Microsoft.EntityFrameworkCore;

namespace Anota.Api.Services.Notes
{
    public class NoteService(AppDbContext context) : INoteService
    {
        public async Task<Note?> CreateNoteAsync(CreateNoteRequest request)
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

            return newNote;
        }

        public async Task<List<Note>> GetNotesAsync()
        {
            var notes = await context.Notes
                .AsNoTracking()
                .OrderByDescending(n => n.CreatedAt)
                .ToListAsync();

            return notes;
        }

        public async Task<Note?> GetNoteById(int noteId)
        {
            var note = await context.Notes.FirstOrDefaultAsync(n => n.Id == noteId);

            if (note is null)
            {
                return null;
            }

            return note;
        }

        public async Task<Note?> EditNoteAsync(int noteId, CreateNoteRequest request)
        {
            var existingNote = await context.Notes
                .FirstOrDefaultAsync(note => note.Id == noteId);

            if (existingNote is null)
            {
                return null;
            }

            existingNote.Title = request.Title;
            existingNote.Subtitle = request.Subtitle;
            existingNote.Description = request.Description;
            existingNote.Category = request.Category;
            existingNote.UpdatedAt = DateTime.UtcNow;

            await context.SaveChangesAsync();

            return existingNote;
        }
    }
}
