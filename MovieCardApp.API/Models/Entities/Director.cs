using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieCardApp.API.Models.Entities
{
    [Table("director")]
    public class Director
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public required string FirstName { get; set; }
        [Required]
        public required string LastName { get; set; }
        public string? DateOfBirth { get; set; }
        public ICollection<Movie>? Movies { get; set; }
        public ContactInformation? ContactInformation { get; set; }
        public string? DirectorFirstName { get; }
        public string? DirectorLastName { get; }
    }
}
