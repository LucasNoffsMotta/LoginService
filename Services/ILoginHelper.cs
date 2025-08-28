using System;
using LoginService.Models;

namespace LoginService.Services;

public interface ILoginHelper
{
    public bool VerifyPassword(User user, string hashedPassowrd, string providedPassword);
    public string HashPassword(User user, string providedPassword);
}
