using Anota.Api.Entities;
using Anota.Api.Models.Notes;
using Anota.Api.Services.Notes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Anota.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController(INoteService noteService) : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<CreateNoteResponse>> CreateNote(CreateNoteRequest request)
        {
            var result = await noteService.CreateNoteAsync(request);

            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<List<Note>>> GetAllNotes()
        {
            var result = await noteService.GetNotesAsync();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Note?>> GetNotesById(int id)
        {
            var result = await noteService.GetNoteById(id);
            if (result is null)
            {
                return NotFound($"Note with id {id} was not found.");
            }

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Note?>> EditNote(int id, CreateNoteRequest request)
        {
            var result = await noteService.EditNoteAsync(id, request);
            if (result is null)
            {
                return NotFound($"Note with id {id} was not found.");
            }

            return Ok(result);
        }
    }
}
