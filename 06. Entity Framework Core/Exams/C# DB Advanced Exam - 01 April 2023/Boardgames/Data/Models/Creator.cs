using Boardgames.Common;
using System.ComponentModel.DataAnnotations;

namespace Boardgames.Data.Models;

public class Creator
{
    [Key]
    public int Id { get; set; }
    [Required]
    [MinLength(ValidationConstants.CreatorFirstNameMinLenght)]
    public string FirstName { get; set; } = null!;
    [Required]
    [MinLength(ValidationConstants.CreatorLastNameMinLenght)]
    public string LastName { get; set; } = null!;

    public ICollection<Boardgame> Boardgames { get; set; } = new HashSet<Boardgame>();
}
