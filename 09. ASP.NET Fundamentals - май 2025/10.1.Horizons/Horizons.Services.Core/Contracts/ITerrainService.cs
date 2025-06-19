using Horizons.Web.ViewModels.Destination;
using Horizons.Web.ViewModels.Terrain;

namespace Horizons.Services.Core.Contracts;

public interface ITerrainService
{
    Task<IEnumerable<TerrainViewModel>> GetAllTerrainsAsync();
}
