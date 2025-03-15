using Microsoft.AspNetCore.Mvc;
using Notes_Web.Notes.Dtos;
using Notes_Web.Notes.Exceptions;
using Notes_Web.Notes.Services;
using Notes_Web.Notes.Repository;
using System.Security.AccessControl;

namespace Notes_Web.Notes
{
    [ApiController]
    [Route("api/v1/[Controller]")]
    public class NotesController:ControllerBase
    {
        private readonly IQueryService _query;
        private readonly ICommandService _command;


        public NotesController(IQueryService query,ICommandService command)
        {
            this._command = command;
            this._query = query;
        }

        [HttpGet("all")]

        public async Task<ActionResult<GetAllNotesDto>> GetAllNotesAsync()
        {
            try
            {
                GetAllNotesDto response = await this._query.GetAllNotesAsync();

               return Ok(response);

            }catch(NotesNotFoundException ex)
            {
                return NotFound(ex.Message);


            }





        }

        [HttpPost("create")]
        public async Task<ActionResult<NotesResponse>> CreateNoteASync([FromBody]NotesRequest create)
        {
            try
            {
                NotesResponse response = await this._command.CreateNotesAsync(create);
                return Created("", response);


            }catch(NotesAlreadyExistDto ex)
            {
                return BadRequest(ex.Message);
            }



        }

        [HttpDelete("delete/{id}")]
        public async Task<ActionResult<NotesResponse>> DeleteNoteAsync([FromRoute] int id)
        {

            try
            {
                NotesResponse response = await _command.DeleteAsync(id);
                return Accepted("", response);

            }catch(NotesNotFoundException nf)
            {
                return NotFound(nf.Message);
            }






        }

        [HttpPut("edit/{id}")]
        
        public async Task<ActionResult<NotesResponse>> EditNoteAsync([FromRoute]int id, [FromBody]NoteUpdateRequest update)
        {
            try
            {
                NotesResponse response = await this._command.UpdateAsync(id, update);
                return Accepted("", response);

            }catch(NotesNotUpdateException up)
            {
                return NotFound(up.Message);

            }catch(NotesNotFoundException nf)
            {
                return NotFound(nf.Message);
            }



        }


        [HttpGet("find/Title/{title}")]

        public async Task<ActionResult<GetAllNotesDto>> GetNotesByTitle([FromRoute]string title)
        {
            try
            {
                GetAllNotesDto response = await this._query.FindByTitleAsync(title);
                return Accepted("", response);


            }catch(NotesNotFoundException nf)
            {
                return NotFound(nf.Message);
            }


        }

        [HttpGet("find/Id/{id}")]
        public async Task<ActionResult<NotesResponse>> GetNoteById([FromRoute]int id)
        {
            try
            {

                NotesResponse response= await this._query.FindByIdAsync(id);

                return Accepted("", response);


            }catch(NotesNotFoundException nf)
            {
                return NotFound(nf.Message);
            }


        }

        [HttpGet("GetAllTitles")]

        public async Task<ActionResult<GetAllNotes>> GetAllNooteTitle()
        {
            try
            {
                GetAllNotes response = await this._query.GetAllTitleAsync();
                return Ok(response);

            }catch(NotesNotFoundException nf)
            {
                return NotFound(nf.Message);

            }




        }

       






    }
}
