using System.ComponentModel.DataAnnotations.Schema;

namespace P02_FootballBetting.Data.Models;
public class Team
{
    public int TeamId { get; set; }
    public string Name { get; set; } = null!;
    public string LogoUrl { get; set; } = null!;
    public string Initials { get; set; } = null!;
    public decimal Budget { get; set; }
    public int PrimaryKitColorId { get; set; }
    public int SecondaryKitColorId { get; set;}
    public int TownId { get; set; }
}
