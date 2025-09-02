using LoginService.Data;
using LoginService.Models;
using LoginService.Repo;
using LoginService.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<LoginServiceContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("LoginServiceContext") ?? throw new InvalidOperationException("Connection string 'LoginServiceContext' not found.")));

builder.Services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();
builder.Services.AddScoped<ILoginHelper, LoginHelper>();
builder.Services.AddScoped<IUserRepo, UserRepo>();
builder.Services.AddControllers();

builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Logging.SetMinimumLevel(LogLevel.Debug);



var app = builder.Build();
app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<LoginServiceContext>();
    if (!await db.Database.CanConnectAsync())
    {
        throw new Exception("Não foi possível conectar ao banco LoginService");
    }

    else
    {
        Console.WriteLine("Conectado");
    }
}

app.Run();
