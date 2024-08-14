using Microsoft.EntityFrameworkCore;

namespace OpusClassical.Models;

public class ApplicationDbContext(EnvironmentConfig env) : DbContext
{
    public DbSet<Period> Periods { get; init; }
    public DbSet<Composer> Composers { get; init; }
    public DbSet<Work> Works { get; init; }
    public DbSet<Recording> Recordings { get; init; }
    public DbSet<Performer> Performers { get; init; }
    public DbSet<Link> Links { get; init; }

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
        modelBuilder.Entity<Work>().ToTable("works_with_genres");
        modelBuilder.Entity<Recording>().ToTable("recordings_with_labels");
        modelBuilder.Entity<Performer>().ToTable("performers_with_instruments");
        modelBuilder.Entity<Link>().ToTable("links_with_streamers");
    }
}