using Boardgames.Data.Models;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Boardgames.DataProcessor.ExportDto;

[XmlType(nameof(Creator))]
public class ExportCreatorWithBroardgamesDto
{
    public string CreatorName { get; set; } = null!;

    [XmlArray(nameof(Boardgames))]
    public ExportBoardgameDto[] Boardgames { get; set; } = null!;

    [XmlAttribute(nameof(BoardgamesCount))]
    public string BoardgamesCount { get; set; } = null!;

}
