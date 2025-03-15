using Microsoft.EntityFrameworkCore.Storage.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Policy;

namespace Notes_Web.Notes.Model
{
    [Table("notes")]
    public class Note
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id")]
        public int Id { get; set; }

        [Required]
        [Column("Title")]
        public string Title { get; set; }

        [Required]
        [Column("Content")]
        public string Content { get; set; }


        [Required]
        [Column("Date_created")]
        public DateOnly Date_Created { get; set; }

        [Required]
        [Column("Date_modified")]
        public DateOnly Date_Modified { get; set; }

        [Required]
        [Column("Color")]
        public string  Color { get; set; }

        [Required]
        [Column("Priority")]
        public int Priority { get; set; }


        [Required]
        [Column("Favorite")]
        public bool Favorite { get; set; }











    }
}
