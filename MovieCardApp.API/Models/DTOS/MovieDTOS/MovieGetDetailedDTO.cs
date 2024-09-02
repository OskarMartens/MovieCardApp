using MovieCardApp.API.Models.DTOS.ActorDTOS;
using MovieCardApp.API.Models.DTOS.DirectorDTOS;
using MovieCardApp.API.Models.DTOS.GenreDTOS;

namespace MovieCardApp.API.Models.DTOS.MovieDTOS
{
    public record MovieGetDetailedDTO
        (
            MovieGetDTO movie,
            DirectorGetDTO director,
            ICollection<ActorGetDTO> actors,
            ICollection<GenreGetDTO> genres
        );
}
