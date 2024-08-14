using Microsoft.EntityFrameworkCore;

namespace OpusClassical.Models;

public class ApplicationDbContext(EnvironmentConfig env) : DbContext
{
    public DbSet<Period> Periods { get; init; }
    public DbSet<Composer> Composers { get; init; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .UseNpgsql(env.DatabaseConnectionString)
            .UseSnakeCaseNamingConvention();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Period>().ToTable("periods");
        modelBuilder.Entity<Composer>().ToTable("composers_with_countries");
    }
}