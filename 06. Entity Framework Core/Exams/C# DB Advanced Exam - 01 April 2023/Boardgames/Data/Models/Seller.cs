using Boardgames.Common;
using System.ComponentModel.DataAnnotations;

namespace Boardgames.Data.Models;

public class Seller
{
    [Key]
    public int Id { get; set; }
    [Required]
    [MinLength(ValidationConstants.SellerNameMinLenght)]
    public string Name { get; set; } = null!;
    [Required]
    [MinLength(ValidationConstants.SellerAddressMinLenght)]
    public string Address { get; set; } = null!;
    [Required]
    public string Country { get; set; } = null!;
    [Required]
    public string Website { get; set; } = null!;

    public ICollection<BoardgameSeller> BoardgamesSellers { get; set; } = new HashSet<BoardgameSeller>();
}
