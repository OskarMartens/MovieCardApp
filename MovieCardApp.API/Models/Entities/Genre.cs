using System.ComponentModel.DataAnnotations;

namespace MovieCardApp.API.Models.Entities
{
    public class Genre
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
