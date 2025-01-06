using System.ComponentModel.DataAnnotations.Schema;

namespace P02_FootballBetting.Data.Models;
public class Game
{
    public Game()
    {
        var Games = new HashSet<Game>();
        var PlayerStatistics = new HashSet<PlayerStatistic>();
    }
    public int GameId { get; set; }
    public int HomeTeamId { get; set; }
    public int AwayTeamId { get; set; }
    public int HomeTeamGoals {  get; set; }
    public int AwayTeamGoals { get; set;}
    public decimal HomeTeamBetRate { get; set; }
    public decimal AwayTeamBetRate { get;set; }
    public decimal DrawBetRate { get; set; }
    public DateTime DateTime { get; set; }
    public string? Result { get; set; }
}
