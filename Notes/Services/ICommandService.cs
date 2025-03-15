using Notes_Web.Notes.Dtos;
using Notes_Web.Notes.Exceptions;

namespace Notes_Web.Notes.Services
{
    public interface ICommandService
    {

        Task<NotesResponse> CreateNotesAsync(NotesRequest create);

        Task<NotesResponse> DeleteAsync(int id);

        Task<NotesResponse> UpdateAsync(int id, NoteUpdateRequest update);















    }
}
