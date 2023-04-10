using BetsApi.Models;
using Microsoft.EntityFrameworkCore;

namespace MyDbContextApi.Data;
public class MyDbContext : DbContext
{
    public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
    {
    }

    public DbSet<BetsModels> Bets { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    { 
        modelBuilder.Entity<BetsModels>(entity =>
        {
            entity.HasKey(e => e.id);
            entity.Property(e => e.id).HasColumnName("id");
            entity.Property(e => e.title).HasColumnName("title");
            entity.Property(e => e.price).HasColumnName("price");
            entity.Property(e => e.description).HasColumnName("description");
            entity.Property(e => e.created_at).HasColumnName("created_at");
            entity.ToTable("bets");
        });
    }
}