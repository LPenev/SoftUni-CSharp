using Horizons.Data;
using Horizons.Data.Models;
using Horizons.Services.Core.Contracts;
using Horizons.Web.ViewModels.Destination;
using Microsoft.EntityFrameworkCore;
using static Horizons.GCommon.ValidationConstants.Destination;

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

    public async Task<DestinationDetailsViewModel?> GetDestinationDetailsAsync(int? id, string? userId)
    {
        DestinationDetailsViewModel destinationDetailsVM = null;

        if (id.HasValue)
        {
            bool isUserIdValid = userId != null;

            Destination? destination = await this.dbContext.Destinations
                .AsNoTracking()
                .Include(d => d.Terrain)
                .Include(d => d.Publisher)
                .Include(d => d.UsersDestinations)
                .SingleOrDefaultAsync(d => d.Id == id.Value);

            if (destination != null)
            {
                destinationDetailsVM = new DestinationDetailsViewModel()
                {
                    Id = destination.Id,
                    Name = destination.Name,
                    ImageUrl = destination.ImageUrl,
                    Description = destination.Description,
                    PublishedOn = destination.PublishedOn.ToString(PublishedOnDateFormat),
                    Terrain = destination.Terrain.Name,
                    Publisher = destination.Publisher.UserName,
                    IsPublisher = isUserIdValid ? destination.PublisherId.ToLower() == userId.ToLower() : false,
                    IsFavorite = isUserIdValid ? destination.UsersDestinations.Any(ud => ud.UserId.ToLower() == userId.ToLower()) : false
                };
            }
        }

        return destinationDetailsVM;
    }

}
