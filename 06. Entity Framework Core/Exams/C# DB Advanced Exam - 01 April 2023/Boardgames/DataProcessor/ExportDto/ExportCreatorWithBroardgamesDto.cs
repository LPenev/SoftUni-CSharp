using Boardgames.Data.Models;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Boardgames.DataProcessor.ExportDto;

[XmlType(nameof(Creator))]
public class ExportCreatorWithBroardgamesDto
{
    [Required]
    public string CreatorName { get; set; } = null!;

    [Required]
    [XmlArray(nameof(Boardgames))]
    public Boardgame[] Boardgames { get; set; } = null!;

}
