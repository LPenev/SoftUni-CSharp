using Microsoft.EntityFrameworkCore;
using RecipeSharingPlatform.Data;
using RecipeSharingPlatform.Services.Core.Contracts;
using RecipeSharingPlatform.ViewModels.Recipe;

namespace RecipeSharingPlatform.Services.Core;

public class CategoryService : ICategoryService
{
    private readonly ApplicationDbContext dbContext;

    public CategoryService(ApplicationDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<IEnumerable<CategoriesViewModel>> GetCategoriesAsync()
    {

        IEnumerable<CategoriesViewModel> allCategories = await this.dbContext
            .Categories
            .AsNoTracking()
            .Select(c => new CategoriesViewModel()
            {
                Id = c.Id,
                Name = c.Name,
            }).ToArrayAsync();

        return allCategories;
    }
}

