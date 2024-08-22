using System.ComponentModel.DataAnnotations;

namespace MovieCardApp.API.Models.Entities
{
    public class ContactInformation
    {
        [Key]
        public int Id { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
    }
}
