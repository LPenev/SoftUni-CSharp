using Horizons.Web.ViewModels.Destination;

namespace Horizons.Services.Core.Contracts;

public interface IDestinationService
{
    Task<IEnumerable<DestinationViewModel>> GetAllDestinationsAsync(string? userId);

    Task<DestinationDetailsViewModel?> GetDestinationDetailsAsync(int? id, string? userId);

    Task<bool> AddDestinationAsync(string userId, DestinationAddInputModel inputModel);

    Task<DestinationEditInputModel?> GetDestinationForEditAsync(string userId, int? destId);

    Task<bool> PersistUpdateDestinationAsync(string userId, DestinationEditInputModel inputModel);
}
