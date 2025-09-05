using System;
using System.Threading.Tasks;
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

    [HttpGet("login")]
    public ActionResult Login([FromForm] string username, [FromForm] string password)
    {
        if (_userRepo.UniqueUsername(username))
        {
            return new BadRequestResult();
        }

        var user = _userRepo.GetUser(username);

        if (!_loginHelper.VerifyPassword(user!, user!.Password!, password))
        {
            return new BadRequestResult();
        }

        return new OkObjectResult(user);
    }


    [HttpPost("createuser")]
    public async Task<ActionResult> CreateUser([FromForm] string username, [FromForm] string password, [FromForm] string email, [FromForm] string birth)
    {
        if (_userRepo.UniqueEmail(email) && _userRepo.UniqueUsername(username))
        {
            User user = new User()
            {
                Username = username,
                Birth = DateOnly.Parse(birth),
                Password = string.Empty,
                Email = email
            };

            user.Password = _loginHelper.HashPassword(user, password);
            var createdUser = await _userRepo.CreateUser(user);
            return new OkObjectResult(createdUser);
        }
        return new BadRequestResult();
    }
}
