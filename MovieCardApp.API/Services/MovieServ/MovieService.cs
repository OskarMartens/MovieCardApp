using AutoMapper;
using MovieCardApp.API.Models.DTOS.ActorDTOS;
using MovieCardApp.API.Models.DTOS.DirectorDTOS;
using MovieCardApp.API.Models.DTOS.GenreDTOS;
using MovieCardApp.API.Models.DTOS.MovieDTOS;
using MovieCardApp.API.Repositories.DirectorRep;
using MovieCardApp.API.Repositories.MovieRep;

namespace MovieCardApp.API.Services.MovieServ
{
    public class MovieService : IMovieService
    {
        private readonly IDirectorRepository _directorRepository;
        private readonly IMovieRepository _movieRepository;
        private readonly IMapper _mapper;


        public MovieService(
            IDirectorRepository directorRepository,
            IMovieRepository repository,
            IMapper mapper)
        {
            _directorRepository = directorRepository;
            _movieRepository = repository;
            _mapper = mapper;
        }

        public async Task<MovieGetDTO?> GetMovieById(int id)
        {
            var movie = await _movieRepository.GetMovieById(id);

            if (movie == null)
                return null;

            var movieDto = _mapper.Map<MovieGetDTO>(movie);

            return movieDto;
        }

        public async Task<IEnumerable<MovieGetDTO>?> GetMovies()
        {
            var movies = await _movieRepository.GetMovies();
            if (!movies.Any())
                return null;

            var movieDtoList = movies.Select(movie => _mapper.Map<MovieGetDTO>(movie)).ToList();

            return movieDtoList;
        }

        public async Task<MovieGetDetailedDTO?> GetDetailedMovieById(int id)
        {
            var movie = await _movieRepository.GetDetailedMovieById(id);
            if (movie == null)
                return null;

            var directorDetails = _mapper.Map<DirectorGetDTO>(movie?.Director);
            var movieDetails = _mapper.Map<MovieGetDTO>(movie);
            var actorDetails = movie?.Actors.Select(actor => _mapper.Map<ActorGetDTO>(actor)).ToList();
            var genreDetails = movie?.Genres.Select(genre => _mapper.Map<GenreGetDTO>(genre)).ToList();

            var detailedMovie = new MovieGetDetailedDTO
                (
                movieDetails,
                directorDetails,
                actorDetails,
                genreDetails
                );

            return detailedMovie;
        }

        public Task<MovieGetDTO> PostMovie(MoviePostDTO post)
        {
            /*            Director? director = null;
                        if (post.DirectorId != null)
                        {
                            director = await _directorRepository.GetDirectorById(post.DirectorId);
                        }

                        else if (director == null)
                        {
                            director = new Director
                            {
                                FirstName = post.DirectorFirstName!,
                                LastName = post.DirectorLastName!
                            };
                        }*/

            throw new NotImplementedException();
        }

        /*        public async Task<MovieGetDTO> PostMovie(MoviePostDTO post)
                {
                    Director? director = null;
                    if (post.DirectorId != null)
                    {
                        director = await _directorRepository.GetDirectorById(post.DirectorId);
                    }

                    else if (director == null)
                    {
                        director = new Director
                        {
                            FirstName = post.DirectorFirstName!,
                            LastName = post.DirectorLastName!
                        };
                    }
                }*/
    }
}
