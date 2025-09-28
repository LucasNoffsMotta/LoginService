using System;
using LoginService.Models;
using Microsoft.EntityFrameworkCore;

namespace LoginService.Data;

public class LoginServiceContext : DbContext
{
    public LoginServiceContext(DbContextOptions<LoginServiceContext> options) : base(options)
    {
        
    }

    public DbSet<User> User => Set<User>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    }
}
