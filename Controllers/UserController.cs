using System;
using LoginService.Data;
using LoginService.Models;
using LoginService.Repo;
using LoginService.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace LoginService.Controllers;

[ApiController]
[Route("user")]
public class UserController
{   
    private ILoginHelper _loginHelper;
    private IUserRepo _userRepo;

    public UserController(ILoginHelper loginHelper, IUserRepo userRepo)
    {
        _loginHelper = loginHelper;
        _userRepo = userRepo;
    }

    [HttpPost("login")]
    public ActionResult Login([FromBody] string username, string password)
    {
        return new OkObjectResult(200);
    }

    [HttpPost("createuser")]
    public ActionResult CreateUser([FromForm] string username, [FromForm] string password, [FromForm]string email, [FromForm] string birth, [FromForm]string street,
    [FromForm] string number, [FromForm] string postalCode)
    {
        User user = new User();
        Adress adress = new Adress()
        {
            Street = street,
            Number = int.Parse(number),
            PostalCode = postalCode
        };

        var hashedPassowrd = _loginHelper.HashPassword(user, password);
        user.Username = username;
        user.Birth = DateOnly.Parse(birth);
        user.Password = hashedPassowrd;
        user.Email = email;
        user.Adress = adress;
        _userRepo.CreateUser(user);
        return new OkObjectResult(200);
    }
}
