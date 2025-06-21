using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RecipeSharingPlatform.Data.Models;
using static RecipeSharingPlatform.GCommon.ValidationConstants.Category;

namespace RecipeSharingPlatform.Data.Configurations;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder
            .HasKey(x => x.Id);

        builder
            .Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(NameMaxLength);

        builder
            .HasData(this.GenerateSeedTerains());
    }

    private List<Category> GenerateSeedTerains()
    {
        List<Category> seedCategories = new List<Category>()
        {
                new Category { Id = 1, Name = "Appetizer" },
                new Category { Id = 2, Name = "Main Dish" },
                new Category { Id = 3, Name = "Dessert" },
                new Category { Id = 4, Name = "Soup" },
                new Category { Id = 5, Name = "Salad" },
                new Category { Id = 6, Name = "Beverage" }
        };

        return seedCategories;
    }
}