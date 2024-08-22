using System.ComponentModel.DataAnnotations;

namespace MovieCardApp.API.Models.Entities
{
    public class Actor
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string? DateOfBirth { get; set; }
    }
}
