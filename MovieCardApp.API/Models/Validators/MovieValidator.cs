using FluentValidation;
using MovieCardApp.API.Models.Entities;

namespace MovieCardApp.API.Models.Validators
{
    public class MovieValidator : AbstractValidator<Movie>
    {
        public MovieValidator()
        {
            RuleFor(movie => movie.Id).NotEmpty();
            RuleFor(movie => movie.Title).NotEmpty();
            RuleFor(movie => movie.ReleaseDate).Matches("^\\d{4}-((0\\d)|(1[012]))-(([012]\\d)|3[01])$\r\n");
        }
    }
}
