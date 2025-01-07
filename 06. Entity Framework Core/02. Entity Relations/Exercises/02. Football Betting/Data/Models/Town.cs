﻿using System.ComponentModel.DataAnnotations.Schema;

namespace P02_FootballBetting.Data.Models;
public class Town
{
    public Town()
    {
        this.Teams = new HashSet<Team>();
    }

    public int TownId { get; set; }
    public string Name { get; set; } = null!;

    [ForeignKey(nameof(Country))]
    public int CountryId { get; set; }
    public Country Country { get; set; }

    public virtual ICollection<Team> Teams { get; set; }
}
