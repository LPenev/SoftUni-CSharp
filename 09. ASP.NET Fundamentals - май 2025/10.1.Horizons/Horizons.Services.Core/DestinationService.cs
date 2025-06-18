using Horizons.Data;
using Horizons.Services.Core.Contracts;
using Horizons.Web.ViewModels.Destination;
using Microsoft.EntityFrameworkCore;

namespace Horizons.Services.Core;

public class DestinationService : IDestinationService
{
    private readonly HorizonDbContext dbContext;

    public DestinationService(HorizonDbContext dbContext)
    {
        this.dbContext = dbContext ?? throw new ArgumentNullException($"Missing dbContext: {nameof(dbContext)}");
    }

    public async Task<IEnumerable<DestinationViewModel>> GetAllDestinationsAsync(string? userId)
    {
        bool isUserIdValid = !string.IsNullOrEmpty(userId);

        IEnumerable<DestinationViewModel> allDestinations = await this.dbContext
            .Destinations
            .Include(x => x.Terrain)
            .Include(x => x.UsersDestinations)
            .AsNoTracking()
            .Select(x => new DestinationViewModel()
            {
                Id = x.Id,
                Name = x.Name,
                ImageUrl = x.ImageUrl,
                Terrain = x.Terrain.Name,
                FavoritesCount = x.UsersDestinations.Count(),
                IsPublisher = isUserIdValid ? 
                    x.PublisherId.ToLower() == userId!.ToLower() : false,
                IsFavorite = isUserIdValid ? 
                    x.UsersDestinations.Any(ud => ud.UserId.ToLower() == userId!.ToLower()) : false,
            }).ToArrayAsync();

        return allDestinations;
    }

}
