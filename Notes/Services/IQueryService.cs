using Notes_Web.Notes.Dtos;

namespace Notes_Web.Notes.Services
{
    public interface IQueryService
    {

        Task<GetAllNotesDto> GetAllNotesAsync();



        Task<GetAllNotesDto> FindByTitleAsync(string Title);

        Task<NotesResponse> FindByIdAsync(int id);

        Task<GetAllNotes> GetAllTitleAsync();











    }
}
