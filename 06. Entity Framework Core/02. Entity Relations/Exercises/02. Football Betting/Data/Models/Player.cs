using System.ComponentModel.DataAnnotations.Schema;

namespace P02_FootballBetting.Data.Models;
public class Player
{
    public int PlayerId { get; set; }
    public string Name { get; set; } = null!;
    public int SquadNumber { get; set; }
    public bool IstInjured { get; set; }
    public int PositionId { get; set; }
    public int TeamId { get; set; }
    public int TownId { get; set; }
}
