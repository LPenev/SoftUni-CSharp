using CinemaApp.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static CinemaApp.Data.Common.EntityConstants.Ticket;

namespace CinemaApp.Data.Configuration;

public class TicketConfiguration : IEntityTypeConfiguration<Ticket>
{
    public void Configure(EntityTypeBuilder<Ticket> builder)
    {
        builder
            .HasKey(t => t.Id);

        builder
            .Property(t => t.Price)
            .HasColumnType(PriceSqlType)
            .IsRequired();

        builder
            .HasOne(t => t.Cinema)
            .WithMany(t => t.Tickets)
            .HasForeignKey(t => t.CinemaId)
            .IsRequired(false);

        builder
            .HasOne(t => t.Movie)
            .WithMany(t => t.Tickets)
            .HasForeignKey(t => t.MovieId)
            .IsRequired(false);

        builder
            .HasOne(t => t.User)
            .WithMany()
            .HasForeignKey(t => t.UserId);
    }
}

