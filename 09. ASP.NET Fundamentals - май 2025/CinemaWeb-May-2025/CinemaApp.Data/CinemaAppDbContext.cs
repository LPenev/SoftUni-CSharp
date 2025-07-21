namespace CinemaApp.Data
{
    using CinemaApp.Data.Models;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using System.Reflection;

    public class CinemaAppDbContext : IdentityDbContext
    {
        public virtual DbSet<Movie> Movies { get; set; } = null!;
        
        public DbSet<Watchlist> Watchlists { get; set; }

        public CinemaAppDbContext(DbContextOptions<CinemaAppDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // apply all Entity Configuration Files
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
