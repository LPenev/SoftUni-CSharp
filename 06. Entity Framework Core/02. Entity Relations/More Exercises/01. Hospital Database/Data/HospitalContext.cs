using Microsoft.EntityFrameworkCore;

namespace P01_HospitalDatabase.Data;
public class HospitalContext : DbContext
{
    public HospitalContext(DbContextOptions options) : base(options) { }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=FootballBetting;User=demo;Password=Demo1234");
            base.OnConfiguring(optionsBuilder);
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        //
        base.OnModelCreating(modelBuilder);
    }
}
