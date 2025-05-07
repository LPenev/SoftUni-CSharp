using Boardgames.Data.Models;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using static Boardgames.Common.ValidationConstants;

namespace Boardgames.DataProcessor.ImportDto;

[XmlType(nameof(Creator))]
public class ImportCreatorDto
{
    [XmlElement(nameof(FirstName))]
    [MinLength(CreatorFirstNameMinLenght)]
    [MaxLength(CreatorFirstNameMaxLenght)]
    public string FirstName { get; set; } = null!;

    [XmlElement(nameof(LastName))]
    [MinLength(CreatorLastNameMinLenght)]
    [MaxLength(CreatorLastNameMaxLenght)]
    public string LastName { get; set; } = null!;

    [XmlArray(nameof(Boardgames))]
    [Required]
    public ImportBoardgameDto[] Boardgames { get; set; } = null!;
    
}
