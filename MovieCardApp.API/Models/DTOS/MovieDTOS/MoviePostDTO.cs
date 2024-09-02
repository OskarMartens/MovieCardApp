namespace MovieCardApp.API.Models.DTOS.MovieDTOS
{
    public record MoviePostDTO
        (
            string Title,
            int? Rating,
            string ReleaseDate,
            string? Description,
            int? DirectorId,
            string? DirectorFirstName,
            string? DirectorLastName,
            IEnumerable<int> GenreIds
        )
    {
    }
}
