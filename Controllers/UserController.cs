using System;
using System.Threading.Tasks;
using LoginService.Data;
using LoginService.DTO;
using LoginService.Error;
using LoginService.Map;
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
    public async Task<ActionResult<User>> Login([FromBody]LoginDTO loginUser)
    {
        if (_userRepo.UniqueUsername(loginUser.Username))
        {
            return new BadRequestObjectResult("Wrong username.");
        }

        var user = await _userRepo.GetUser(loginUser.Username);

        if (!_loginHelper.VerifyPassword(user!, user!.Password!, loginUser.Password))
        {
            return new BadRequestObjectResult("Wrong password." );
        }

        return new OkObjectResult(UserMapping.UserToCreatedDTO(user));
    }

    [HttpPost("createuser")]
    public async Task<ActionResult> CreateUser([FromBody] NewUserDTO userDTO)
    {
        var newUser = UserMapping.UserDtoToModel(userDTO);

        if (_userRepo.UniqueEmail(newUser.Email!) && _userRepo.UniqueUsername(newUser.Username!))
        {
            newUser.Password = _loginHelper.HashPassword(newUser, newUser.Password!);
            var createdUser = await _userRepo.CreateUser(newUser);
            return new OkObjectResult(UserMapping.UserToCreatedDTO(newUser));
        }
        return new BadRequestObjectResult("Username or email already exists");
    }
}
