using System.ComponentModel.DataAnnotations.Schema;

namespace P02_FootballBetting.Data.Models;
public class Color
{
    public Color()
    {
        this.PrimaryKitTeams = new HashSet<Color>();
        this.SecondaryKitTeams = new HashSet<Color>();
    }
    
    public int ColorId { get; set; }
    public string Name { get; set; } = null!;

    [InverseProperty(nameof(Team.PrimaryKitColor))]
    public virtual ICollection<Color> PrimaryKitTeams { get; set; }

    [InverseProperty(nameof(Team.SecondaryKitColor))]
    public virtual ICollection<Color> SecondaryKitTeams { get; set; }
}
