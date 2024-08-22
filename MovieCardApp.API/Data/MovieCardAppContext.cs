using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MovieCardApp.API.Models.Entities;

namespace MovieCardApp.API.Data
{
    public class MovieCardAppContext : DbContext
    {
        public MovieCardAppContext (DbContextOptions<MovieCardAppContext> options)
            : base(options)
        {
        }

        public DbSet<MovieCardApp.API.Models.Entities.Movie> Movie { get; set; } = default!;
    }
}
