using Microsoft.Extensions.Logging;

namespace Horizons.Web.ViewModels.Destination;

public class DestinationViewModel
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string? ImageUrl { get; set; }
    public string Terrain { get; set; } = null!;
    public long FavoritesCount { get; set; }
    public bool IsFavorite { get; set; }
    public bool IsPublisher { get; set; }



}
