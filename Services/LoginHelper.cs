using System;
using LoginService.Data;
using LoginService.Services;
using Microsoft.AspNetCore.Identity;

namespace LoginService.Models;

public class LoginHelper : ILoginHelper
{
    private IPasswordHasher<User> _passwordHasher;
    public LoginHelper(IPasswordHasher<User> passwordHasher)
    {
        _passwordHasher = passwordHasher;
    }

    public string HashPassword(User user, string providedPassword)
    {
        return _passwordHasher.HashPassword(user, providedPassword);
    }

    public bool VerifyPassword(User user, string hashedPassowrd, string providedPassword)
    {
        throw new NotImplementedException();
    }  
}
