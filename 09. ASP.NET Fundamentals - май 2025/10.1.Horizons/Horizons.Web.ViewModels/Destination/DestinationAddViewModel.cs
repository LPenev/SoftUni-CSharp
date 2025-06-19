using Horizons.Web.ViewModels.Terrain;
using System.ComponentModel.DataAnnotations;
using static Horizons.GCommon.ValidationConstants.Destination;

namespace Horizons.Web.ViewModels.Destination;

public class DestinationAddViewModel
{
    [Required]
    [MinLength(NameMinLength)]
    [MaxLength(NameMaxLength)]
    public string Name { get; set; } = null!;
    [Required]
    [MinLength(DescriltionMinLength)]
    [MaxLength(DescriptionMaxLength)]
    public string Description { get; set; } = null!;
    public string? ImageUrl { get; set; }
    public int TerrainId { get; set; }
    public IEnumerable<TerrainViewModel>? Terrains { get; set; }
    [Required]
    [MinLength(PublishedOnLength)]
    [MaxLength(PublishedOnLength)]
    public string PublishedOn { get; set; } = null!;
}
