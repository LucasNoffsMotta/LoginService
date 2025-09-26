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
    public Task<User?> GetUser(string userName);
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
        var userName = _dbContext.User.Where(u => u.Username == providedUsername).Select(u => u.Id);
        return userName.IsNullOrEmpty();
    }

    public bool UniqueEmail(string providedEmail)
    {
        var email = _dbContext.User.Where(u => u.Email == providedEmail);
        return email.IsNullOrEmpty();
    }

    public async Task<User> CreateUser(User user)
    {
        _dbContext.Add(user);
        await _dbContext.SaveChangesAsync();
        return user;
    }

    public async Task<User?> GetUser(string userName)
    {
        return await _dbContext.User
        .FirstOrDefaultAsync(user => user.Username == userName)
        ;
    }
}
