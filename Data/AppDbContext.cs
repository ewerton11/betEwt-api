using UserApi.Models;
using BetsApi.Models;
using Microsoft.EntityFrameworkCore;

namespace MyDbContextApi.Data;
public class MyDbContext : DbContext
{
    public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
    {
    }

    public DbSet<UserModels> Users { get; set; } = null!;
    public DbSet<BetsModels> Bets { get; set; } = null!;
}