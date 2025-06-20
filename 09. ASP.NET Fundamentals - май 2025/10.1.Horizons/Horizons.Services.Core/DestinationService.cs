using Horizons.Data;
using Horizons.Data.Models;
using Horizons.Services.Core.Contracts;
using Horizons.Web.ViewModels.Destination;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using static Horizons.GCommon.ValidationConstants.Destination;

namespace Horizons.Services.Core;

public class DestinationService : IDestinationService
{
    private readonly HorizonDbContext dbContext;
    private readonly UserManager<IdentityUser> userManager;

    public DestinationService(HorizonDbContext dbContext, UserManager<IdentityUser> userManager)
    {
        this.dbContext = dbContext ?? throw new ArgumentNullException($"Missing dbContext: {nameof(dbContext)}");
        this.userManager = userManager;
    }

    public async Task<bool> AddDestinationAsync(string userId, DestinationAddInputModel inputModel)
    {
        IdentityUser? user = await this.userManager.FindByIdAsync(userId);
        Terrain? terrainRef = await this.dbContext.Terrains.FindAsync(inputModel.TerrainId);
        bool isPublishedOnDateValid = DateTime.TryParseExact(inputModel.PublishedOn,
            PublishedOnDateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime publishedOnDate);

        if (user != null && terrainRef != null && isPublishedOnDateValid)
        {
            Destination newDestination = new Destination()
            {
                Name = inputModel.Name,
                Description = inputModel.Description,
                ImageUrl = inputModel.ImageUrl,
                PublishedOn = publishedOnDate,
                PublisherId = userId,
                TerrainId = inputModel.TerrainId,
            };

            await this.dbContext.Destinations.AddAsync(newDestination);
            await this.dbContext.SaveChangesAsync();

        }

        throw new NotImplementedException();
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

    public async Task<DestinationDeleteInputModel?> GetDestinationForDeletingAsync(string userId, int? destId)
    {
        DestinationDeleteInputModel? deleteInputModel = null;

        if (destId.HasValue)
        {
            Destination? deleteDestinationModel = await dbContext
                .Destinations
                .Include(d => d.Publisher)
                .AsNoTracking()
                .SingleOrDefaultAsync(d => d.Id == destId);

            if (deleteDestinationModel != null && deleteDestinationModel.PublisherId.ToLower() == userId.ToLower())
            {
                deleteInputModel = new DestinationDeleteInputModel()
                {
                    Id = deleteDestinationModel.Id,
                    Name = deleteDestinationModel.Name,
                    Publisher = deleteDestinationModel.Publisher.NormalizedUserName,
                    PublisherId = deleteDestinationModel.PublisherId,
                };
            }
        }

        return deleteInputModel;
    }

    public async Task<DestinationEditInputModel?> GetDestinationForEditAsync(string userId, int? destId)
    {
        DestinationEditInputModel? editInputModel = null;

        if (destId.HasValue)
        {
            Destination? editDestinationModel = await dbContext.Destinations
                .AsNoTracking()
                .SingleOrDefaultAsync(d => d.Id == destId);

            if (editDestinationModel != null && editDestinationModel.PublisherId.ToLower() == userId.ToLower())
            {
                editInputModel = new DestinationEditInputModel()
                {
                    Id = editDestinationModel.Id,
                    Name = editDestinationModel.Name,
                    Description = editDestinationModel.Description,
                    ImageUrl = editDestinationModel.ImageUrl,
                    TerrainId = editDestinationModel.TerrainId,
                    PublishedOn = editDestinationModel.PublishedOn.ToString(PublishedOnDateFormat),
                    PublisherId = editDestinationModel.PublisherId,
                };
            }
        }

        return editInputModel;
    }

    public async Task<IEnumerable<DestinationFavoriteViewModel>?> GetDestinationUserFavoriteViewModelAsync(string userId)
    {
        IEnumerable<DestinationFavoriteViewModel?> favDestinations = null;
        IdentityUser? user = await this.userManager.FindByIdAsync(userId);

        if (user != null)
        {
            favDestinations = await this.dbContext
                .UsersDestinations
                .Include(d => d.Destination)
                .ThenInclude(d => d.Terrain)
                .Where(ud => ud.UserId.ToLower() == userId.ToLower())
                .Select(ud => new DestinationFavoriteViewModel()
                {
                    Id = ud.DestinationId,
                    Name = ud.Destination.Name,
                    ImageUrl =ud.Destination.ImageUrl,
                    Terrain = ud.Destination.Terrain.Name,
                }).ToArrayAsync();
        }
        return favDestinations;
    }

    public async Task<bool> AddDestinationToUserFavoriteListAsync(string userId, int destId)
    {
        bool operationResult = false;

        IdentityUser? user = await this.userManager.FindByIdAsync(userId);

        Destination? favDest = await this.dbContext
            .Destinations
            .FindAsync(destId);

        if (user != null && favDest != null && favDest.PublisherId.ToLower() != userId.ToLower())
        {
            UserDestination? userFavoriteDest = await this.dbContext
                .UsersDestinations
                .SingleOrDefaultAsync(x => x.UserId.ToLower() == userId.ToLower() && x.DestinationId == destId);

            if (userFavoriteDest == null)
            {
                userFavoriteDest = new UserDestination()
                {
                    UserId = userId,
                    DestinationId = destId,
                };

                await this.dbContext.UsersDestinations.AddAsync(userFavoriteDest);
                await this.dbContext.SaveChangesAsync();
                operationResult = true;
            }
        }

        return operationResult;
    }

    public async Task<bool> PersistUpdateDestinationAsync(string userId, DestinationEditInputModel inputModel)
    {
        bool operationResult = false;

        IdentityUser? user = await this.userManager.FindByIdAsync(userId);
        Terrain? terrainRef = await this.dbContext
            .Terrains
            .FindAsync(inputModel.TerrainId);

        bool isPublishedOnDateValid = DateTime.TryParseExact(inputModel.PublishedOn,
            PublishedOnDateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime publishedOnDate);

        Destination? updatedDest = await this.dbContext
            .Destinations
            .FindAsync(inputModel.Id);

        if (user != null && terrainRef != null && updatedDest != null
            && isPublishedOnDateValid && updatedDest.PublisherId.ToLower() == userId.ToLower())
        {
            updatedDest.Name = inputModel.Name;
            updatedDest.Description = inputModel.Description;
            updatedDest.PublishedOn = publishedOnDate;
            updatedDest.TerrainId = inputModel.TerrainId;
            updatedDest.ImageUrl = inputModel.ImageUrl;
            updatedDest.TerrainId = inputModel.TerrainId;

            await this.dbContext.SaveChangesAsync();

            operationResult = true;
        }

        return operationResult;
    }

    public async Task<bool> SoftDeleteDestinationAsync(string userId, DestinationDeleteInputModel inputModel)
    {
        bool operationResult = false;

        IdentityUser? user = await this.userManager.FindByIdAsync(userId);

        Destination? deletedDest = await this.dbContext
            .Destinations
            .FindAsync(inputModel.Id);

        if (user != null && deletedDest != null && deletedDest.PublisherId.ToLower() == userId.ToLower())
        {
            deletedDest.IsDeleted = true;
            await this.dbContext.SaveChangesAsync();
            operationResult = true;
        }

        return operationResult;
    }
}
