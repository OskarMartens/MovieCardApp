using MovieCardApp.API.Data;
using MovieCardApp.API.Models.Entities;

namespace MovieCardApp.API.Repositories.DirectorRep
{
    public class DirectorRepository : IDirectorRepository
    {
        private readonly MovieCardAppContext _context;

        public async Task<Director?> GetDirectorById(int id)
        {
            return await _context.Director.FindAsync(id);
        }

        public Task<Director?> GetDirectorById(int? id)
        {
            throw new NotImplementedException();
        }
    }
}
