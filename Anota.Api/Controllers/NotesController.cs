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
        public async Task<ActionResult<User>> CreateNote(CreateNoteRequest request)
        {
            var note = await noteService.CreateNoteAsync(request);
            if (note is null)
            {
                return BadRequest("Um usuário com este nome já existe.");
            }

            return Ok(note);
        }
    }
}
