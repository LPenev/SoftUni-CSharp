using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Horizons.Data.Models;

public class Destination
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string? ImageUrl { get; set; }
    public string PublisherId { get; set; } = string.Empty;
    public virtual IdentityUser Publisher { get; set; } = null!;

    public DateTime PublishedOn { get; set; }

    public int TerrainId { get; set; }
    public Terrain Terrain { get; set; } = null!;

    public bool IsDeleted { get; set; }

    public virtual ICollection<UserDestination> UsersDestinations { get; set; } = new HashSet<UserDestination>();
}
