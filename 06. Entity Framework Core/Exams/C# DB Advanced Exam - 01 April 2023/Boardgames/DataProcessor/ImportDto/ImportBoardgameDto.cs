using Boardgames.Data.Models;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using static Boardgames.Common.ValidationConstants;

namespace Boardgames.DataProcessor.ImportDto;

[XmlType(nameof(Boardgame))]
public class ImportBoardgameDto
{
    [XmlElement(nameof(Name))]
    [MinLength(BoardgameNameMinLenght)]
    [MaxLength(BoardgameNameMaxLenght)]
    public string Name { get; set; } = null!;
    [XmlElement(nameof(Rating))]
    [Range(BoardgameRatingMinLenght, BoardgameRatingMaxLenght)]
    public double Rating { get; set; }
    [XmlElement(nameof(YearPublished))]
    [Range(BoardgameYearPublishedMin, BoardgameYearPublishedMax)]
    public int YearPublished { get; set; }
    [XmlElement(nameof(CategoryType))]
    [Range(BoardgameCategoryTypeMin, BoardgameCategoryTypeMax)]
    public int CategoryType { get; set; }
    [XmlElement(nameof(Mechanics))]
    [Required]
    public string Mechanics { get; set; } = null!;
}
