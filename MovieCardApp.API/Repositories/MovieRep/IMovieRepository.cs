using MovieCardApp.API.Models.Entities;

namespace MovieCardApp.API.Repositories.MovieRep
{
    public interface IMovieRepository
    {
        public Task<Movie?> GetMovieById(int id);
        public Task<Movie?> GetDetailedMovieById(int id);
        public Task<IEnumerable<Movie?>> GetMovies();
        public Task<Movie?> PostMovie(Movie movie);
    }
}
