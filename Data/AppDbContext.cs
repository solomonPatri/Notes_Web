using Notes_Web.Notes.Model;
using Microsoft.EntityFrameworkCore;

namespace Notes_Web.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {


        }

        public virtual DbSet<Note> Notes 
        {
            get;
            set;
            
        }








    }
}
