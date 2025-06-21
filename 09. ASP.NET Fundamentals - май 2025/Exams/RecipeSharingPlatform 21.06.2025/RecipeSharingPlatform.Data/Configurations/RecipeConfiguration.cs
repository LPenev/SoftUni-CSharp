using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RecipeSharingPlatform.Data.Models;
using static RecipeSharingPlatform.GCommon.ValidationConstants.Recipe;

namespace RecipeSharingPlatform.Data.Configurations;

public class RecipeConfiguration : IEntityTypeConfiguration<Recipe>
{
    public void Configure(EntityTypeBuilder<Recipe> builder)
    {
        builder
            .HasKey(x => x.Id);

        builder
            .Property(x => x.Title)
            .IsRequired()
            .HasMaxLength(TitleMaxLength);

        builder
            .Property(x => x.Instructions)
            .IsRequired()
            .HasMaxLength(InstructionsMaxLength);

        builder
            .Property(x => x.AuthorId)
            .IsRequired();

        builder
            .HasOne(x => x.Author)
            .WithMany() // Navigation Collection missing in build-in Identity User
            .HasForeignKey(x => x.AuthorId)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasOne(x => x.Category)
            .WithMany(x => x.Recipes)
            .HasForeignKey(x => x.CategoryId)
            .OnDelete(DeleteBehavior.Restrict);

        builder
           .HasQueryFilter(d => d.IsDeleted == false);

        builder
            .HasData(this.GenerateDesinations());
    }

    private List<Recipe> GenerateDesinations()
    {
        List<Recipe> seedRecipes = new List<Recipe>()
        {
            new Recipe
                {
                    Id = 1,
                    Title = "Classic Bruschetta",
                    Instructions = "Chop tomatoes, mix with basil and garlic, then spoon onto toasted bread.",
                    ImageUrl = "https://www.unicornsinthekitchen.com/wp-content/uploads/2024/04/Bruschetta-sq-500x500.jpg",
                    AuthorId = "df1c3a0f-1234-4cde-bb55-d5f15a6aabcd",
                    CreatedOn = DateTime.Now,
                    CategoryId = 1,
                    IsDeleted = false
                },
                new Recipe
                {
                    Id = 2,
                    Title = "Grilled Salmon",
                    Instructions = "Season salmon with herbs and grill skin-side down for 6–8 minutes.",
                    ImageUrl = "https://feelgoodfoodie.net/wp-content/uploads/2025/04/Grilled-Salmon-09-500x500.jpg",
                    AuthorId = "df1c3a0f-1234-4cde-bb55-d5f15a6aabcd",
                    CreatedOn = DateTime.Now,
                    CategoryId = 2,
                    IsDeleted = false
                },
                new Recipe
                {
                    Id = 3,
                    Title = "Chocolate Lava Cake",
                    Instructions = "Prepare cake mix, bake at high heat for 12 min. Serve warm with ice cream.",
                    ImageUrl = "https://www.cookingclassy.com/wp-content/uploads/2022/02/molten-lava-cake-17-500x500.jpg",
                    AuthorId = "df1c3a0f-1234-4cde-bb55-d5f15a6aabcd",
                    CreatedOn = DateTime.Now,
                    CategoryId = 3,
                    IsDeleted = false
                }
        };

        return seedRecipes;
    }
}
