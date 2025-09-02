using System;
using LoginService.Data;
using LoginService.Models;
using Microsoft.EntityFrameworkCore;

namespace LoginService.Repo;

public interface IUserRepo
{
    public Task CreateUser(User user);
    public Task<List<string?>> GetUsers();
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


    public async Task CreateUser(User user)
    {
        _dbContext.Add(user);
        await _dbContext.SaveChangesAsync();
    }
}
