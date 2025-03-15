using Notes_Web.Notes.Dtos;
using Notes_Web.Notes.Repository;
using Notes_Web.Notes.Exceptions;

namespace Notes_Web.Notes.Services
{
    public class QueryService:IQueryService
    {

        private readonly INoteRepo _repo;
        public QueryService(INoteRepo repo)
        {

            this._repo = repo;

        }


       public async Task<GetAllNotesDto> GetAllNotesAsync()
        {

            GetAllNotesDto response = await this._repo.GetAllNotesAsync();
            if(response != null)
            {

                return response;

            }
            throw new NotesAlreadyExistDto();
        }

      
       public async  Task<GetAllNotesDto> FindByTitleAsync(string Title)
        {
            GetAllNotesDto response = await this._repo.FindByTitleAsync(Title);
          if(response != null)
            {
                return response;

            }

            throw new NotesNotFoundException();

        }

        public async Task<NotesResponse> FindByIdAsync(int id)
        {
            NotesResponse response = await this._repo.FindByIdAsync(id);
            if(response != null)
            {
                return response;
            }
            throw new NotesNotFoundException();
        }

       public async  Task<GetAllNotes> GetAllTitleAsync()
        {

            GetAllNotes response = await this._repo.GetAllTitleAsync();
            if (response != null)
            {
                return response;



            }
            throw new NotesNotFoundException();

        }


























    }
}
