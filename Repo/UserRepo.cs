using System;
using LoginService.Data;
using LoginService.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace LoginService.Repo;

public interface IUserRepo
{
    public Task<User> CreateUser(User user);
    public Task<List<string?>> GetUsers();
    public bool UniqueUsername(string providedUsername);
    public bool UniqueEmail(string providedEmail);
    public User? GetUser(string userName);
}

public class UserRepo : IUserRepo
{
    private LoginServiceContext _dbContext;

    public UserRepo(LoginServiceContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<List<string?>> GetUsers()
    {
        return _dbContext.User
        .Select(u => u.Username)
        .ToListAsync();
    }

    public bool UniqueUsername(string providedUsername)
    {
        var userNames = _dbContext.User.Where(u => u.Username == providedUsername).Select(u => u.Id);
        return userNames.IsNullOrEmpty();
    }

    public bool UniqueEmail(string providedEmail)
    {
        var emails = _dbContext.User.Where(u => u.Email == providedEmail);
        return emails.IsNullOrEmpty();
    }

    public async Task<User> CreateUser(User user)
    {
        _dbContext.Add(user);
        await _dbContext.SaveChangesAsync();
        return user;
    }

    public User? GetUser(string userName)
    {
        return _dbContext.User
        .FirstOrDefault(user => user.Username == userName)
        ;
    }
}
