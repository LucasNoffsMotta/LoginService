using System.ComponentModel.DataAnnotations;

namespace LoginService.DTO;

public record class NewUserDTO(
    [Required] string Username,
    [Required] string Password,
    [Required] string Email,
    [Required] DateOnly Birthday
);
