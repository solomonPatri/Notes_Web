using AutoMapper;
using Notes_Web.Notes.Dtos;
using Notes_Web.Notes.Model;

namespace Notes_Web.Notes.Mappers
{
    public class NotesMappingProfile:Profile
    {
      
        public NotesMappingProfile()
        {


            CreateMap <NotesRequest, Note>();
            CreateMap<Note, NotesResponse>();
            CreateMap<NotesResponse, NotesRequest>();
            CreateMap< NotesResponse, GetAllNotesDto>();
            CreateMap<NotesResponse, GetAllNotesDto>();
                



        }






    }
}
