namespace LoginService.DTO
{
    public record class CreatedUserDTO(
    string Username,
    string Email,
    DateOnly Birthday
    );
}
