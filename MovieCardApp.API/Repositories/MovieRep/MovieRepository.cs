using Microsoft.EntityFrameworkCore;
using MovieCardApp.API.Data;
using MovieCardApp.API.Models.Entities;

namespace MovieCardApp.API.Repositories.MovieRep
{
    public class MovieRepository : IMovieRepository
    {
        private readonly MovieCardAppContext _context;

        public MovieRepository(MovieCardAppContext context)
        {
            _context = context;
        }

        public async Task<Movie?> GetMovieById(int id)
        {
            return await _context.Movie.FindAsync(id);
        }

        public async Task<Movie?> GetDetailedMovieById(int id)
        {
            return await _context.Movie
                .Include(m => m.Director)
                .ThenInclude(d => d.ContactInformation)
                .Include(m => m.Actors)
                .Include(m => m.Genres)
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<IEnumerable<Movie?>> GetMovies()
        {
            return await _context.Movie.ToListAsync();
        }

        public async Task<Movie?> PostMovie(Movie movie)
        {
            _context.Movie.Add(movie);
            await _context.SaveChangesAsync();
            return movie;
        }
    }
}
