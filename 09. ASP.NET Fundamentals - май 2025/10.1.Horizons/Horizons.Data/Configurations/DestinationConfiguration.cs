using Horizons.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static Horizons.GCommon.ValidationConstants.Destination;

namespace Horizons.Data.Configurations;

public class DestinationConfiguration : IEntityTypeConfiguration<Destination>
{
    public void Configure(EntityTypeBuilder<Destination> builder)
    {
        builder
            .HasKey(x => x.Id);

        builder
            .Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(NameMaxLength);

        builder
            .Property(x => x.Description)
            .IsRequired()
            .HasMaxLength(DescriptionMaxLength);

        builder
            .Property(x => x.PublisherId)
            .IsRequired();

        builder
            .HasQueryFilter(d => d.IsDeleted == false);

        builder
            .HasOne(x => x.Publisher)
            .WithMany() // Navigation Collection missing in build-in Identity User
            .HasForeignKey(x => x.PublisherId)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasOne(x => x.Terrain)
            .WithMany(x => x.Destinations)
            .HasForeignKey(x => x.TerrainId)
            .OnDelete(DeleteBehavior.Restrict);

        //builder
        //    .HasData(this.GenerateDesinations);
    }

    private List<Destination> GenerateDesinations()
    {
        List<Destination> seedDesinations = new List<Destination>() {

            new Destination
            {
                Id = 1,
                Name = "Rila Monastery",
                Description = "A stunning historical landmark nestled in the Rila Mountains.",
                ImageUrl = "https://img.etimg.com/thumb/msid-112831459,width-640,height-480,imgsize-2180890,resizemode-4/rila-monastery-bulgaria.jpg",
                PublisherId = "7699db7d-964f-4782-8209-d76562e0fece",
                PublishedOn = DateTime.Now,
                TerrainId = 1,
                IsDeleted = false
            },
            new Destination
            {
                Id = 2,
                Name = "Durankulak Beach",
                Description = "The sand at Durankulak Beach showcases a pristine golden color, creating a beautiful contrast against the azure waters of the Black Sea.",
                ImageUrl = "https://travelplanner.ro/blog/wp-content/uploads/2023/01/durankulak-beach-1-850x550.jpg.webp",
                PublisherId = "7699db7d-964f-4782-8209-d76562e0fece",
                PublishedOn = DateTime.Now,
                TerrainId = 2,
                IsDeleted = false
            },
            new Destination
            {
                Id = 3,
                Name = "Devil's Throat Cave",
                Description = "A mysterious cave located in the Rhodope Mountains.",
                ImageUrl = "https://detskotobnr.binar.bg/wp-content/uploads/2017/11/Diavolsko_garlo_17.jpg",
                PublisherId = "7699db7d-964f-4782-8209-d76562e0fece",
                PublishedOn = DateTime.Now,
                TerrainId = 7,
                IsDeleted = false
            },
        };

        return seedDesinations;
    }
}
