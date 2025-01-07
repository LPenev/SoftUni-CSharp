using System.ComponentModel.DataAnnotations.Schema;

namespace P02_FootballBetting.Data.Models;
public class Player
{
    public Player()
    {
        this.PlayerStatistics = new HashSet<PlayerStatistic>();
    }

    public int PlayerId { get; set; }
    public string Name { get; set; } = null!;
    public int SquadNumber { get; set; }
    public bool IstInjured { get; set; }

    [ForeignKey(nameof(Position))]
    public int PositionId { get; set; }
    public Position Position { get; set; }

    [ForeignKey(nameof(Team))]
    public int TeamId { get; set; }
    public Team Team { get; set; }
   
    public int TownId { get; set; }

    public virtual ICollection<PlayerStatistic> PlayerStatistics { get; set; }

}
