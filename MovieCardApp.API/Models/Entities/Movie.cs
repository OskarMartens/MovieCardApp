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

    }
}
