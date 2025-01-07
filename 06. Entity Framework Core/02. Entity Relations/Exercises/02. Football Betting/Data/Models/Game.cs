﻿using System.ComponentModel.DataAnnotations.Schema;

namespace P02_FootballBetting.Data.Models;
public class Game
{
    public Game()
    {
        this.PlayerStatistic = new HashSet<PlayerStatistic>();
        this.Bets = new HashSet<Bet>();
    }

    public int GameId { get; set; }

    [ForeignKey(nameof(HomeTeam))]
    public int HomeTeamId { get; set; }
    public Team HomeTeam { get; set; }

    [ForeignKey(nameof(AwayTeam))]
    public int AwayTeamId { get; set; }
    public Team AwayTeam { get; set; }

    public int HomeTeamGoals {  get; set; }
    public int AwayTeamGoals { get; set;}
    public decimal HomeTeamBetRate { get; set; }
    public decimal AwayTeamBetRate { get;set; }
    public decimal DrawBetRate { get; set; }
    public DateTime DateTime { get; set; }
    public string? Result { get; set; }

    public virtual ICollection<PlayerStatistic> PlayerStatistic { get; set; }
    public virtual ICollection<Bet> Bets { get; set; }
}
