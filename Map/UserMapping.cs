using LoginService.DTO;
using LoginService.Models;

namespace LoginService.Map
{
    public static class UserMapping
    {
        public static User UserDtoToModel(NewUserDTO userDTO)
        {
            return new User()
            {
                Username = userDTO.Username,
                Password = userDTO.Password,
                Email = userDTO.Email,
                Birth = userDTO.Birthday
            };
        }

        public static User LogInUserDTOToEntity(LoginDTO loginUserDTO)
        {
            return new User()
            {
                Username = loginUserDTO.Username,
                Password = loginUserDTO.Password,
                Email = string.Empty,
                Birth = DateOnly.MinValue
            };
        }

        public static CreatedUserDTO UserToCreatedDTO(User user)
        {
            return new CreatedUserDTO(
                user.Username!,
                user.Email!,
                user.Birth
                );
        }
    }
}
