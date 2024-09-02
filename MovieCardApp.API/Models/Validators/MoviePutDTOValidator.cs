using FluentValidation;
using MovieCardApp.API.Models.DTOS.MovieDTOS;

namespace MovieCardApp.API.Models.Validators
{
    public class MoviePutDTOValidator : AbstractValidator<MoviePutDTO>
    {
        public MoviePutDTOValidator()
        {
            RuleFor(movieDto => movieDto.Id).NotEmpty().NotNull();
            RuleFor(movieDto => movieDto.Title).NotEmpty().NotNull();
            RuleFor(movieDto => movieDto.ReleaseDate).NotNull().NotEmpty().Matches("^\\d{4}-((0\\d)|(1[012]))-(([012]\\d)|3[01])$\r\n");
        }
    }
}
