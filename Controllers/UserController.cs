using System;
using LoginService.Data;
using LoginService.Models;
using LoginService.Repo;
using LoginService.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace LoginService.Controllers;

//TODO: Criar service para lidar com banco de dados diretamente
[ApiController]
public class UserController
{   
    private LoginHelper _loginHelper;
    private IUserRepo _userRepo;

    public UserController(LoginHelper loginHelper, IUserRepo userRepo)
    {
        _loginHelper = loginHelper;
        _userRepo = userRepo;
    }

    [HttpPost]
    public ActionResult Login([FromBody] string username, string password)
    {
        return new OkObjectResult(200);
    }

    [HttpPost]
    public ActionResult CreateUser([FromBody] string username, string password, string email, string street, int number, string postalCode)
    {
        User user = new User();
        Adress adress = new Adress()
        {
            Street = street,
            Number = number,
            PostalCode = postalCode
        };

        var hashedPassowrd = _loginHelper.HashPassword(user, password);
        user.Username = username;
        user.Password = hashedPassowrd;
        user.Email = email;
        user.Adress = adress;
        _userRepo.CreateUser(user);
        return new OkObjectResult(200);
    }
}
