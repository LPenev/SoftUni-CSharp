namespace MusicHub.Data
{
    using Microsoft.EntityFrameworkCore;
    using MusicHub.Data.Models;

    public class MusicHubDbContext : DbContext
    {
        public MusicHubDbContext()
        {
        }

        public MusicHubDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Producer> Producers { get; set; }

        public DbSet<Album> Albums { get; set; }

        public DbSet<Song> Songs { get; set; }

        public DbSet<Writer> Writers { get; set; }

        public DbSet<Performer> Performers { get; set; }

        public DbSet<SongPerformer> songPerformers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<SongPerformer>( sp => 
            {
                sp.HasKey(sp => new { sp.SongId, sp.PerformerId });
            });

            builder.Entity<Song>(s => 
            {
                s.Property(s => s.CreatedOn)
                    .HasColumnType("Date");
            });

            builder.Entity<Album>( a => 
            {
                a.Property(a => a.ReleaseDate)
                    .HasColumnType("Date");
            });
        }
    }
}
