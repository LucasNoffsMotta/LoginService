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
    public DbSet<Adress> Adress => Set<Adress>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
        .HasOne(u => u.Adress)
        .WithMany()
        .HasForeignKey(u => u.AdressId);
    }
}
