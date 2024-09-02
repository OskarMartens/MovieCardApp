namespace MovieCardApp.API.Models.DTOS.ActorDTOS
{
    public record ActorGetDTO(
            int Id,
            string FirstName,
            string LastName,
            string DateOfBirth
        );
}