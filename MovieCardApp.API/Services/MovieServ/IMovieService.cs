using MovieCardApp.API.Models.DTOS.MovieDTOS;

namespace MovieCardApp.API.Services.MovieServ
{
    public interface IMovieService
    {
        public Task<MovieGetDTO?> GetMovieById(int id);
        public Task<IEnumerable<MovieGetDTO?>> GetMovies();
        public Task<MovieGetDetailedDTO?> GetDetailedMovieById(int id);
        public Task<MovieGetDTO> PostMovie(MoviePostDTO post);
    }
}
