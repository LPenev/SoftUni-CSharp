using Horizons.Web.ViewModels.Destination;

namespace Horizons.Services.Core.Contracts;

public interface IDestinationService
{
    Task<IEnumerable<DestinationViewModel>> GetAllDestinationsAsync(string? userId);
}
