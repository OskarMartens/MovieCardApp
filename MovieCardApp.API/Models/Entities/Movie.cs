using System.ComponentModel.DataAnnotations;

namespace MovieCardApp.API.Models.Entities
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public int? Rating { get; set; }

        [Required]
        public string ReleaseDate { get; set; }

        public string Description { get; set; }

    }
}
