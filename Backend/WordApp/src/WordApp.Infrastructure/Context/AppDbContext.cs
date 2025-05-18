using Microsoft.EntityFrameworkCore;
using System.Reflection;
using WordApp.Domain.Synonms;
using WordApp.Domain.Words;

namespace WordApp.Infrastructure.Context;

public class AppDbContext : DbContext
{
    public AppDbContext()
    {
        
    }


    public AppDbContext(DbContextOptions options) :base(options)
    {
        
    }

    public DbSet<Word> Words { get; set; }
    public DbSet<Synonm> Synonms { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
