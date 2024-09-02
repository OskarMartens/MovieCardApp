using MovieCardApp.API.Models.Entities;

namespace MovieCardApp.API.Repositories.DirectorRep
{
    public interface IDirectorRepository
    {
        public Task<Director?> GetDirectorById(int? id);
    }
}
