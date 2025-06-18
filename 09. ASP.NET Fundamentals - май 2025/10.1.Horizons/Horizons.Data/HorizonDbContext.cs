using Horizons.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Horizons.Data;

public class HorizonDbContext : IdentityDbContext
{
    public HorizonDbContext(DbContextOptions<HorizonDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Destination> Destinations { get; set; }
    public virtual DbSet<Terrain> Terrains { get; set; }
    public virtual DbSet<UserDestination> UsersDestinations { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
