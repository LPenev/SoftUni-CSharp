using Microsoft.EntityFrameworkCore;
using P02_FootballBetting.Data.Models;

namespace P02_FootballBetting.Data;

public class FootballBettingContext: DbContext
{
    public FootballBettingContext(DbContextOptions options) : base(options) { }

    public DbSet<Bet> Bets { get; set; }
    public DbSet<Color> Colors { get; set; }
    public DbSet<Game> Games { get; set; }
    public DbSet<Player> Players { get; set; }
    public DbSet<PlayerStatistic> PlayerStatistics { get; set; }
    public DbSet<Position> Positions { get; set; }
    public DbSet<Team> Teams { get; set; }
    public DbSet<Town> Towns { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=FootballBetting;User=demo;Password=Demo1234");
        }

        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Team>( t => { 
            t.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(50);

        });

        base.OnModelCreating(modelBuilder);
    }
}
