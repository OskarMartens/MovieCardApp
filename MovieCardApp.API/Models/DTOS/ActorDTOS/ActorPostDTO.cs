namespace MovieCardApp.API.Models.DTOS.ActorDTOS
{
    public class ActorPostDTO
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string? DateofBirth { get; set; }
    }
}
