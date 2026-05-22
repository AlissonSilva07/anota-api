using Anota.Api.Entities;
using Anota.Api.Models.Notes;
using Anota.Api.Services.Auth;
using Anota.Api.Services.Notes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
            if (result is null)
            {
                return BadRequest("Um usuário com este nome já existe.");
            }

            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<List<Note>>> GetAllNotes()
        {
            var result = await noteService.GetNotesAsync();

            return Ok(result);
        }
    }
}
