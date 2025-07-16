using CinemaApp.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CinemaApp.Data.Configuration;

public class WatchlistConfiguration : IEntityTypeConfiguration<Watchlist>
{
    public void Configure(EntityTypeBuilder<Watchlist> builder)
    {
        builder.HasKey(um => new { um.UserId, um.MovieId });

        builder.HasOne(um => um.User)
            .WithMany()
            .HasForeignKey(um => um.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(um => um.Movie)
            .WithMany()
            .HasForeignKey(um => um.MovieId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Property(x => x.IsDeleted)
            .HasDefaultValue(false);

        builder.HasQueryFilter(um => um.Movie.IsDeleted == false);
        
        builder.HasQueryFilter(um => um.IsDeleted == false);

    }
}
