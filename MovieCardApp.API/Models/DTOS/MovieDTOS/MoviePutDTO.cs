namespace MovieCardApp.API.Models.DTOS.MovieDTOS
{
    public record MoviePutDTO(int Id, string Title, int? Rating, string ReleaseDate, string? Description);

}
