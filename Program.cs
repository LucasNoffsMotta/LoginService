using LoginService.Data;
using LoginService.DTO;
using LoginService.Models;
using LoginService.Repo;
using LoginService.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<LoginServiceContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("LoginServiceContext") ?? throw new InvalidOperationException("Connection string 'LoginServiceContext' not found.")));


builder.Services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();
builder.Services.AddScoped<ILoginHelper, LoginHelper>();
builder.Services.AddScoped<IUserRepo, UserRepo>();
builder.Services.AddScoped<IRandomPasswordService, RandomPasswordService>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Logging.SetMinimumLevel(LogLevel.Debug);

 
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();
app.Run();
