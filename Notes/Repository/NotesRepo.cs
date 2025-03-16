using AutoMapper;
using FluentMigrator.Expressions;
using Notes_Web.Data;
using Notes_Web.Notes.Dtos;
using Notes_Web.Notes.Model;
using System.Data.Entity;
using Microsoft.EntityFrameworkCore;
using Notes_Web.Notes.Repository;
using System.Globalization;

namespace Notes_Web.Notes.Repository
{
    public class NotesRepo:INoteRepo
    {

        private readonly AppDbContext _appdbcontext;
        private readonly IMapper _mapper;

        public NotesRepo(AppDbContext context,IMapper mapper)
        {
            this._appdbcontext = context;
            this._mapper = mapper;

        }

        public async Task<GetAllNotesDto> GetAllNotesAsync()
        {
           List<Note> data = await _appdbcontext.Notes.ToListAsync();

            var responsenote = data.Select(m => _mapper.Map<NotesResponse>(m)).ToList();
            GetAllNotesDto response = new GetAllNotesDto();
            response.Notes = responsenote;
            return response;



        }
        public async Task<NotesResponse> CreateNotesAsync(NotesRequest create)
        {
            Note note = _mapper.Map<Note>(create);

            _appdbcontext.Notes.Add(note);

            await _appdbcontext.SaveChangesAsync();

            NotesResponse response = _mapper.Map<NotesResponse>(note);
            return response;



        }





       public  async Task<NotesResponse> DeleteAsync(int id)
        {
            Note note = await _appdbcontext.Notes.FindAsync(id);

            NotesResponse response = _mapper.Map<NotesResponse>(note);

            _appdbcontext.Remove(note);
            await _appdbcontext.SaveChangesAsync();

            return response;


        }

        public async Task<NotesResponse> UpdateAsync(int id, NoteUpdateRequest update)
        {
            Note note = await _appdbcontext.Notes.FindAsync(id);

            if(update.Title != null)
            {
                note.Title = update.Title;

            }

            if (update.Content != null)
            {
                note.Content = update.Content;

            }
            if(update.Color != null)
            {
                note.Color = update.Color;
            }
            if (update.Favorite.HasValue)
            {
                note.Favorite = update.Favorite.Value;
            }
            if (update.Priority.HasValue)
            {
                note.Priority = update.Priority.Value;
            }
            if(update.Date_Created.HasValue){

                note.Date_Created = update.Date_Created.Value;

            }
            if (update.Date_Modified.HasValue)
            {
                note.Date_Modified = update.Date_Modified.Value;
            }

            _appdbcontext.Notes.Update(note);
            await _appdbcontext.SaveChangesAsync();

            NotesResponse response = _mapper.Map<NotesResponse>(note);

            return response;

        }

       public async  Task<GetAllNotesDto> FindByTitleAsync(string title)
        {
            var notite = await _appdbcontext.Notes.Where(n => n.Title.Equals(title)).ToListAsync();
            var noteresponse = notite.Select(s => _mapper.Map<NotesResponse>(s)).ToList();

            GetAllNotesDto response = new GetAllNotesDto();
            response.Notes = noteresponse;
            return response;



        }

       public async Task<NotesResponse> FindByIdAsync(int id)
        {

            Note notite = await _appdbcontext.Notes.FindAsync(id);
            NotesResponse response = _mapper.Map<NotesResponse>(notite);
            return response;




        }

       public async Task<GetAllNotes> GetAllTitleAsync()
        {
            List<string> names = await _appdbcontext.Notes.Select(n => n.Title).ToListAsync();
            GetAllNotes response = new GetAllNotes();
            response.Titles = names;

            return response;



        }

      public async Task<NotesResponse?> FindNoteByTitleAsync(NotesRequest request)
        {
            var entity = await _appdbcontext.Notes
                     .Where(m => m.Title == request.Title
                            && m.Content != request.Content
                            && m.Color != request.Color
                            && m.Date_Created != request.Date_Created
                            && m.Date_Modified != request.Date_Modified
                            && m.Priority!=request.Priority
                            && m.Favorite!=request.Favorite)
                            .FirstOrDefaultAsync();

            if(entity == null)
            {
                return null;
            }

            return _mapper.Map<NotesResponse>(entity);



        }













    }
}
