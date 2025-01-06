using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Metrics;

namespace P02_FootballBetting.Data.Models;
public class Town
{
    public int TownId { get; set; }
    public string Name { get; set; } = null!;
    public int CountryId { get; set; }
}
