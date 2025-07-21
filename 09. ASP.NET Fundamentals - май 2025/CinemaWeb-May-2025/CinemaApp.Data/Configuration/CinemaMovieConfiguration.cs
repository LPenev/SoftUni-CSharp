using CinemaApp.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CinemaApp.Data.Configuration;

public class CinemaMovieConfiguration : IEntityTypeConfiguration<CinemaMovie>
{
    public void Configure(EntityTypeBuilder<CinemaMovie> builder)
    {
        builder
            .HasKey(cm => new { cm.CinemaId, cm.MovieId });

        builder
            .Property(cm => cm.AvailableTickets)
            .IsRequired();

        builder
            .Property(cm => cm.Showtimes)
            .HasColumnType("Varchar(5)")
            .HasDefaultValue("00000");

        builder
            .HasOne(cm => cm.Cinema)
            .WithMany(c => c.CinemaMovies)
            .HasForeignKey(cm => cm.CinemaId)
            .IsRequired(false);

        builder
            .HasOne(cm => cm.Movie)
            .WithMany(cm => cm.CinemaMovies)
            .HasForeignKey(cm => cm.MovieId)
            .IsRequired(false);
    }
}

