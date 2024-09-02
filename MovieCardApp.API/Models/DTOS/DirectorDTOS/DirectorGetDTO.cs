namespace MovieCardApp.API.Models.DTOS.DirectorDTOS
{
    public record DirectorGetDTO(int Id, string Firstname, string Lastname, string DateOfBirth, string Email, string PhoneNumber)
    {
    }
}
