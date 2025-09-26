using System.ComponentModel.DataAnnotations;

namespace LoginService.DTO
{
    public record class LoginDTO(
    [Required] string Username,
    [Required] string Password
    );
}
