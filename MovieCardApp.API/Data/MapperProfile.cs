using AutoMapper;
using MovieCardApp.API.Models.DTOS.ActorDTOS;
using MovieCardApp.API.Models.DTOS.DirectorDTOS;
using MovieCardApp.API.Models.DTOS.GenreDTOS;
using MovieCardApp.API.Models.DTOS.MovieDTOS;
using MovieCardApp.API.Models.Entities;

namespace MovieCardApp.API.Data
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Movie, MovieGetDTO>();
            CreateMap<MoviePostDTO, Movie>()
            .ForMember(dest => dest.Director, optional => optional.Ignore())
            .ForMember(dest => dest.Genres, optional => optional.Ignore());

            CreateMap<Director, DirectorGetDTO>()
                .ConstructUsing(src => new DirectorGetDTO(
                    src.Id,
                    src.FirstName,
                    src.LastName,
                    src.DateOfBirth,
                    src.ContactInformation.Email,
                    src.ContactInformation.PhoneNumber));

            CreateMap<Actor, ActorGetDTO>()
                .ConstructUsing(src => new ActorGetDTO(src.Id, src.FirstName, src.LastName, src.DateOfBirth));

            CreateMap<Genre, GenreGetDTO>()
                .ConstructUsing(src => new GenreGetDTO(src.Id, src.Name));

            CreateMap<MoviePostDTO, Director>()
                .ForMember(dest => dest.FirstName, optional => optional.MapFrom(src => src.DirectorFirstName))
                .ForMember(dest => dest.LastName, optional => optional.MapFrom(src => src.DirectorLastName));
        }
    }
}
