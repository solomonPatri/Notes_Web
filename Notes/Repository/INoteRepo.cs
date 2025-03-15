using Notes_Web.Notes.Dtos;
using Notes_Web.Notes;

namespace Notes_Web.Notes.Repository
{
    public interface INoteRepo
    {

        Task<GetAllNotesDto> GetAllNotesAsync();
     
        Task<NotesResponse> CreateNotesAsync(NotesRequest create);

        Task<NotesResponse> DeleteAsync(int id);

       Task<NotesResponse> UpdateAsync(int id, NoteUpdateRequest update);

        Task<GetAllNotesDto> FindByTitleAsync(string Title);

       Task<NotesResponse> FindByIdAsync(int id);

       Task<GetAllNotes> GetAllTitleAsync();

        Task<NotesResponse> FindNoteByTitleASync(string title);




    }
}
