using Microsoft.EntityFrameworkCore;
using MovieCardApp.API.Models.Entities;

namespace MovieCardApp.API.Data
{
    public class MovieCardAppContext : DbContext
    {
        public MovieCardAppContext(DbContextOptions<MovieCardAppContext> options)
            : base(options)
        {
        }

        public DbSet<Movie> Movie { get; set; } = default!;
        public DbSet<Actor> Actor { get; set; } = default!;
        public DbSet<Director> Director { get; set; } = default!;
        public DbSet<Genre> Genre { get; set; } = default!;
        public DbSet<ContactInformation> ContactInformation { get; set; } = default!;
    }
}
