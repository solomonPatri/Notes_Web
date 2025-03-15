namespace Notes_Web.Notes.Dtos
{
    public class NoteUpdateRequest
    {

        public string? Title { get; set; }

        public string ?Content { get; set; }

        public DateOnly? Date_Created { get; set; }

        public DateOnly ?Date_Modified { get; set; }

        public string ?Color { get; set; }

        public int? Priority { get; set; }

        public bool? Favorite { get; set; }
















    }
}
