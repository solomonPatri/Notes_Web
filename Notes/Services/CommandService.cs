using Notes_Web.Notes.Dtos;
using Notes_Web.Notes.Repository;
using Notes_Web.Notes.Exceptions;
using AutoMapper.Configuration.Annotations;
using System.Runtime.ExceptionServices;
using Microsoft.EntityFrameworkCore.Migrations.Operations.Builders;

namespace Notes_Web.Notes.Services
{
    public class CommandService:ICommandService
    {

        private readonly INoteRepo _repo;

        public CommandService(INoteRepo repo)
        {
            this._repo = repo;


        }


       public async Task<NotesResponse> CreateNotesAsync(NotesRequest create)
        {
            NotesResponse responseexist = await _repo.FindNoteByTitleASync(create.Title);
            if (responseexist == null)
            {
                NotesResponse response = await _repo.CreateNotesAsync(create);

                return response;
            }
            throw new NotesAlreadyExistDto();

        }

        public async Task<NotesResponse> DeleteAsync(int id)
        {
            NotesResponse exist = await this._repo.FindByIdAsync(id);
            if (exist != null)
            {
                NotesResponse response = await this._repo.DeleteAsync(id);
                return response;

            }
            throw new NotesNotFoundException();



        }

       public  async Task<NotesResponse> UpdateAsync(int id, NoteUpdateRequest update)
        {
            NotesResponse exist = await this._repo.FindByIdAsync(id);
            if(exist != null)
            { 
                if(exist is NotesRequest)
                {
                    exist.Title = update.Title ?? exist.Title;
                    exist.Content = update.Content ?? exist.Content;
                    exist.Priority = update.Priority ?? exist.Priority;
                    exist.Favorite = update.Favorite ?? exist.Favorite;
                    exist.Color = update.Color ?? exist.Color;
                    exist.Date_Created = update.Date_Created ?? exist.Date_Created;
                    exist.Date_Modified = update.Date_Modified ?? exist.Date_Modified;

                    NotesResponse response = await this._repo.UpdateAsync(id,update);

                    return response;




                }
                throw new NotesNotUpdateException();
            }
            throw new NotesNotFoundException();





        }























    }
}
