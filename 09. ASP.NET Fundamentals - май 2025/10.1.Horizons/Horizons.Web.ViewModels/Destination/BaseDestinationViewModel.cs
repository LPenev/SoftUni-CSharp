namespace Horizons.Web.ViewModels.Destination;

public abstract class BaseDestinationViewModel
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string? ImageUrl { get; set; }
    public string Terrain { get; set; } = null!;
    public bool IsFavorite { get; set; }
    public bool IsPublisher { get; set; }
}
