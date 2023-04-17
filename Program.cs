using MyDbContextApi.Data;
using Microsoft.EntityFrameworkCore;
using UserApi.Service;
using Microsoft.AspNetCore.Identity;
using UserApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = "server=localhost; port=3306; database=betEwt; user=root; password=root;";
var serverVersion = new MySqlServerVersion(new Version(8, 0, 32));

builder.Services.AddDbContext<MyDbContext>(
            dbContextOptions => dbContextOptions
                .UseMySql(connectionString, serverVersion));

builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<IPasswordHasher<UserModels>, PasswordHasher<UserModels>>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
