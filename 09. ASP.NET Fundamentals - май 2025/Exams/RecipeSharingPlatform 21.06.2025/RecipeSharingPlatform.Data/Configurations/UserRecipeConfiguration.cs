using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RecipeSharingPlatform.Data.Models;

namespace RecipeSharingPlatform.Data.Configurations;

public class UserRecipeConfiguration : IEntityTypeConfiguration<UserRecipe>
{
    public void Configure(EntityTypeBuilder<UserRecipe> builder)
    {
        builder
            .HasKey(x => new { x.UserId, x.RecipeId });

        builder
            .HasQueryFilter(x => x.Recipe.IsDeleted == false);

        builder
            .HasOne(x => x.User)
            .WithMany() // Navigation Collection missing in build-in Identity User
            .HasForeignKey(x => x.UserId);

        builder
            .HasOne(x => x.Recipe)
            .WithMany(x => x.UsersRecipes)
            .HasForeignKey(x => x.RecipeId);
    }
}
