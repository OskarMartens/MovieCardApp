namespace MovieCardApp.API.Models.DTOS.MovieDTOS
{
    public record MovieGetDTO(int Id, string Title, int? Rating, string ReleaseDate, string Description);
}
