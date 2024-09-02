using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieCardApp.API.Models.Entities
{
    [Table("movie")]
    public class Movie
    {

        [Key]
        public int Id { get; set; }

        public required string Title { get; set; }

        public int? Rating { get; set; }

        public required string ReleaseDate { get; set; }

        public string? Description { get; set; }

        public Director Director { get; set; }
        public ICollection<Actor> Actors { get; set; }
        public ICollection<Genre> Genres { get; set; }

    }
}
