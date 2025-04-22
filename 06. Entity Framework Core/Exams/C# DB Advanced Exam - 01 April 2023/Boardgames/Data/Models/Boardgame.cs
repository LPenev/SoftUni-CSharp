using Boardgames.Common;
using Boardgames.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace Boardgames.Data.Models;

public class Boardgame
{
    [Key]
    public int Id { get; set; }
    [Required]
    [MinLength(ValidationConstants.BoardgameNameMinLenght)]
    public string Name { get; set; } = null!;
    public double Rating { get; set; }
    public int YearPublished { get; set; }
    public CategoryType CategoryType { get; set; }
    [Required]
    public string Mechanics { get; set; } = null!;
    public int CreatorId { get; set; }
    public Creator Creator { get; set; } = null!;
    public ICollection<BoardgameSeller> BoardgamesSellers { get; set; } = new HashSet<BoardgameSeller>();
}
