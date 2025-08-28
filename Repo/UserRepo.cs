using System;
using LoginService.Data;
using LoginService.Models;

namespace LoginService.Repo;

public interface IUserRepo
{
    public void CreateUser(User user);
}

public class UserRepo : IUserRepo
{
    private LoginServiceContext _dbContext;

    public UserRepo(LoginServiceContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void CreateUser(User user)
    {
        _dbContext.User.Add(user);
        
        _dbContext.SaveChangesAsync();
    }
}
