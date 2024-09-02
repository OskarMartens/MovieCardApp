using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieCardApp.API.Models.Entities
{
    [Table("contact_information")]
    public class ContactInformation
    {
        [Key]
        public int Id { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public int DirectorId { get; set; }
        public Director Director { get; set; }
    }
}
