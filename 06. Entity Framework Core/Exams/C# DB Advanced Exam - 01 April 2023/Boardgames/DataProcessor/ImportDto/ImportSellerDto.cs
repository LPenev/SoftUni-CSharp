using System.ComponentModel.DataAnnotations;
using static Boardgames.Common.ValidationConstants;

namespace Boardgames.DataProcessor.ImportDto;

public class ImportSellerDto
{
    [Required]
    [MinLength(SellerNameMinLenght)]
    [MaxLength(SellerNameMaxLenght)]
    public string Name { get; set; } = null!;

    [Required]
    [MinLength(SellerAddressMinLenght)]
    [MaxLength(SellerAddressMaxLenght)]
    public string Address { get; set; } = null!;
    
    [Required]
    public string Country { get; set; } = null!;

    [Required]
    [RegularExpression(SellerWebsiteRegExpression)]
    public string Website { get; set; } = null!;

    public int[] Boardgames { get; set; } = null!;

}
