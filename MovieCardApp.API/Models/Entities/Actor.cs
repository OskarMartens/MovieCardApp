using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieCardApp.API.Models.Entities
{
    [Table("actor")]
    public class Actor
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string? DateOfBirth { get; set; }

        public ICollection<Movie> movies { get; set; }
    }
}
