using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieCardApp.API.Models.Entities
{
    [Table("genre")]
    public class Genre
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public required string Name { get; set; }
        public ICollection<Movie>? Movies { get; set; }

    }
}
