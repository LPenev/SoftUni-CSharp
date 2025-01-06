using System.ComponentModel.DataAnnotations.Schema;

namespace P02_FootballBetting.Data.Models;
public class Color
{
    public int ColorId { get; set; }
    public string Name { get; set; } = null!;
}
