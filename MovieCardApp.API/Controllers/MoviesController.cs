using AutoMapper;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieCardApp.API.Data;
using MovieCardApp.API.Models.DTOS.MovieDTOS;
using MovieCardApp.API.Models.Entities;
using MovieCardApp.API.Models.Validators;
using MovieCardApp.API.Services.MovieServ;

namespace MovieCardApp.API.Controllers
{
    [Route("api/movies")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly MovieCardAppContext _context;
        private readonly IMapper _mapper;
        private readonly IMovieService _movieService;


        public MoviesController(
            MovieCardAppContext context,
            IMapper mapper,
            IMovieService movieService)
        {
            _context = context;
            _mapper = mapper;
            _movieService = movieService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovieGetDTO?>>> GetMovies()
        {
            var movies = await _movieService.GetMovies();
            if (movies == null)
                return BadRequest();

            return Ok(movies);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MovieGetDTO?>> GetMovie(int id)
        {
            var movieDto = await _movieService.GetMovieById(id);
            if (movieDto == null)
                return NotFound();

            return Ok(movieDto);
        }

        [HttpGet("{id}/details")]
        public async Task<ActionResult<MovieGetDetailedDTO>> GetDetailedMovie(int id)
        {
            var detailedMovieDTO = await _movieService.GetDetailedMovieById(id);
            if (detailedMovieDTO == null)
                return BadRequest();

            return Ok(detailedMovieDTO);
        }


        [HttpPost]
        public async Task<ActionResult<Movie>> PostMovie(MoviePostDTO movieDTO)
        {
            var movie2 = _movieService.PostMovie(movieDTO);

            if (movieDTO.DirectorId == null &&
                movieDTO.DirectorFirstName != null &&
                movieDTO.DirectorLastName != null)
                return BadRequest();

            Director director;
            if (movieDTO.DirectorId != null)
                director = await _context.Director.FindAsync(movieDTO.DirectorId);
            else
            {
                director = new Director()
                {
                    FirstName = movieDTO.DirectorFirstName!,
                    LastName = movieDTO.DirectorLastName!
                };
            }


            //var directorFromDB2 = await _context.Director.Where(
            //    d => d.LastName.ToUpper().Equals(movieDTO.DirectorLastName.ToUpper()) &&
            //        d.FirstName.ToUpper().Equals(movieDTO.DirectorFirstName.ToUpper()))
            //       .FirstOrDefaultAsync();

            var movie = _mapper.Map<Movie>(movieDTO);
            movie.Director = director!;

            if (movieDTO.GenreIds.Any())
            {
                movie.Genres = new List<Genre>();
                foreach (var genreId in movieDTO.GenreIds)
                {
                    var genre = await _context.Genre.FindAsync(genreId);
                    if (genre != null)
                    {
                        movie.Genres.Add(genre);
                    };
                };
            };

            //var movie = new Movie()
            //{
            //    Title = movieDTO.Title,
            //    Rating = movieDTO.Rating,
            //    ReleaseDate = movieDTO.ReleaseDate,
            //    Description = movieDTO.Description,
            //    Director = director,
            //    Genres = genres
            //};


            _context.Movie.Add(movie);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMovie", new { id = movie.Id }, movieDTO);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutMovie(int id, MoviePutDTO movieDTO)
        {

            if (id != movieDTO.Id)
            {
                return BadRequest();
            };

            var validator = new MoviePutDTOValidator();
            ValidationResult results = validator.Validate(movieDTO);

            if (!results.IsValid)
            {
                foreach (var failure in results.Errors)
                {
                    await Console.Out.WriteLineAsync(
                        $"Property {failure.PropertyName} failed validation. " +
                        $"Error was: {failure.ErrorMessage}");
                };
            };

            Movie? movieFromDB = await _context.Movie.FindAsync(id);
            if (movieFromDB == null)
            {
                return NotFound();
            };

            movieFromDB.Title = movieDTO.Title;
            movieFromDB.Rating = movieDTO.Rating;
            movieFromDB.ReleaseDate = movieDTO.ReleaseDate;
            movieFromDB.Description = movieDTO.Description;

            _context.Entry(movieFromDB).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            };

            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            var movie = await _context.Movie.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }

            _context.Movie.Remove(movie);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
