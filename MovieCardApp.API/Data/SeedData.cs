using Microsoft.EntityFrameworkCore;
using MovieCardApp.API.Models.Entities;

namespace MovieCardApp.API.Data
{
    internal class SeedData
    {
        internal static async Task InitAsync(MovieCardAppContext context)
        {
            if (await context.Movie.AnyAsync() ||
                await context.Director.AnyAsync() ||
                await context.Actor.AnyAsync())
                return;
            List<Director> directors = GenerateDirectors();
            List<Actor> actors = GenerateActors();
            List<Genre> genres = GenerateGenres();
            List<Movie> movies = GenerateMovies(directors, actors, genres);

            context.Director.AddRange(directors);
            context.Actor.AddRange(actors);
            context.Genre.AddRange(genres);
            context.Movie.AddRange(movies);

            await context.SaveChangesAsync();
        }

        private static List<Genre> GenerateGenres()
        {
            Genre horror = new Genre { Name = "Horror" };
            Genre sciFi = new Genre { Name = "Sci-Fi" };
            Genre action = new Genre { Name = "Action" };
            Genre comedy = new Genre { Name = "Comedy" };
            Genre drama = new Genre { Name = "Drama" };

            return [horror, sciFi, action, comedy, drama];
        }

        private static List<Actor> GenerateActors()
        {
            Actor weaver = new Actor { FirstName = "Sigourney", LastName = "Weaver", DateOfBirth = "1949-10-08" };
            Actor culkin = new Actor { FirstName = "Macaulay", LastName = "Culkin", DateOfBirth = "1980-08-26" };
            Actor pesci = new Actor { FirstName = "Joe", LastName = "Pesci", DateOfBirth = "1943-02-09" };
            Actor holm = new Actor { FirstName = "Ian", LastName = "Holm", DateOfBirth = "1931-09-12" };
            Actor shaw = new Actor { FirstName = "Robert", LastName = "Shaw", DateOfBirth = "1927-08-09" };

            return [weaver, culkin, pesci, holm, shaw];
        }

        private static List<Director> GenerateDirectors()
        {
            Director columbus = new Director()
            {
                FirstName = "Chris",
                LastName = "Columbus",
                DateOfBirth = "1958-09-10",
                ContactInformation = new ContactInformation()
                {
                    Email = "ChrisIsHome@mail.com",
                    PhoneNumber = "555-456123"
                }
            };

            Director scott = new Director()
            {
                FirstName = "Ridley",
                LastName = "Scott",
                DateOfBirth = "1937-11-30",
                ContactInformation = new ContactInformation()
                {
                    Email = "AreYouNotEntertained@mail.com",
                    PhoneNumber = "555-741852"
                }
            };

            Director spielberg = new Director()
            {
                FirstName = "Steven",
                LastName = "Spielberg",
                DateOfBirth = "1946-12-18",
                ContactInformation = new ContactInformation()
                {
                    Email = "BiggerBoat@mail.com",
                    PhoneNumber = "555-89898"
                }
            };

            Director jeunet = new Director()
            {
                FirstName = "Jean-Pierre",
                LastName = "Jeunet",
                DateOfBirth = "1953-09-03",
                ContactInformation = new ContactInformation()
                {
                    Email = "montmarte@mail.com",
                    PhoneNumber = "788455654"
                }
            };

            return [columbus, scott, spielberg, jeunet];
        }

        private static List<Movie> GenerateMovies(List<Director> directors, List<Actor> actors, List<Genre> genres)
        {
            var horror = genres.First(g => g.Name == "Horror");
            var sciFi = genres.First(g => g.Name == "Sci-Fi");
            var drama = genres.First(g => g.Name == "Drama");
            var comedy = genres.First(g => g.Name == "Comedy");

            var weaver = actors.First(a => a.LastName == "Weaver");
            var holm = actors.First(a => a.LastName == "Holm");
            var shaw = actors.First(a => a.LastName == "Shaw");
            var culkin = actors.First(a => a.LastName == "Culkin");
            var pesci = actors.First(a => a.LastName == "Pesci");

            var scott = directors.First(d => d.LastName == "Scott");
            var spielberg = directors.First(d => d.LastName == "Spielberg");
            var columbus = directors.First(d => d.LastName == "Columbus");
            var jeunet = directors.First(d => d.LastName == "Jeunet");

            Movie alien = new Movie
            {
                Title = "Alien",
                Rating = 9,
                ReleaseDate = "1979-05-25",
                Description = "After investigating a mysterious transmission of unknown origin, the crew of a commercial spacecraft encounters a deadly lifeform.",
                Director = scott,
                Actors = new List<Actor> { weaver, holm },
                Genres = new List<Genre> { sciFi, horror }
            };

            Movie jaws = new Movie
            {
                Title = "Jaws",
                Rating = 8,
                ReleaseDate = "1975-06-20",
                Description = "When a killer shark unleashes chaos on a beach community off Cape Cod, it's up to a local sheriff, a marine biologist, and an old seafarer to hunt the beast down.",
                Director = spielberg,
                Actors = new List<Actor> { shaw },
                Genres = new List<Genre> { drama, horror }
            };

            Movie homeAlone = new Movie
            {
                Title = "Home Alone",
                Rating = 8,
                ReleaseDate = "1990-11-10",
                Description = "An eight-year-old troublemaker, mistakenly left home alone, must defend his home against a pair of burglars on Christmas Eve.",
                Director = columbus,
                Actors = new List<Actor> { culkin, pesci },
                Genres = new List<Genre> { comedy }
            };

            Movie alien4 = new Movie
            {
                Title = "Alien: Resurrection",
                Rating = 6,
                ReleaseDate = "1997-11-06",
                Description = "Two centuries after her death, a powerful human/alien hybrid clone of Ellen Ripley aids a crew of space pirates in stopping the aliens from reaching Earth.",
                Director = jeunet,
                Actors = new List<Actor> { weaver },
                Genres = new List<Genre> { sciFi, horror }
            };

            return [alien, jaws, homeAlone, alien4];
        }
    }
}
