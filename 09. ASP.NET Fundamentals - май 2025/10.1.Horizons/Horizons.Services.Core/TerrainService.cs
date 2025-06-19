using Horizons.Data;
using Horizons.Services.Core.Contracts;
using Horizons.Web.ViewModels.Destination;
using Horizons.Web.ViewModels.Terrain;
using Microsoft.EntityFrameworkCore;

namespace Horizons.Services.Core;

public class TerrainService : ITerrainService
{
    private readonly HorizonDbContext dbContext;

    public TerrainService(HorizonDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<IEnumerable<TerrainViewModel>> GetAllTerrainsAsync()
    {
        IEnumerable<TerrainViewModel> allTerrains = await this.dbContext.Terrains
            .AsNoTracking()
            .Select(t => new TerrainViewModel()
            {
                Id = t.Id,
                Name = t.Name,
            }).ToArrayAsync();

        return allTerrains;
    }
}
