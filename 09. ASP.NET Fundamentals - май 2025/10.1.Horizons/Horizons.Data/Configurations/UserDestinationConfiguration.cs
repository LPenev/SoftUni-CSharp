using Horizons.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Horizons.Data.Configurations;

public class UserDestinationConfiguration : IEntityTypeConfiguration<UserDestination>
{
    public void Configure(EntityTypeBuilder<UserDestination> builder)
    {
        builder
            .HasKey(x => new { x.UserId, x.DestinationId });

        builder
            .HasQueryFilter(x => x.Destination.IsDeleted == false);

        builder
            .HasOne(x => x.User)
            .WithMany() // Navigation Collection missing in build-in Identity User
            .HasForeignKey(x => x.UserId);

        builder
            .HasOne(x => x.Destination)
            .WithMany(x => x.UsersDestinations)
            .HasForeignKey(x => x.DestinationId);
    }
}
