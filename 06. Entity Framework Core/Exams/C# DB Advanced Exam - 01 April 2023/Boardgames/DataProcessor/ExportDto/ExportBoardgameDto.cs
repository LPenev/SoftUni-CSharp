using Boardgames.Data.Models;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Boardgames.DataProcessor.ExportDto;

[XmlType(nameof(Boardgame))]
public class ExportBoardgameDto
{
    [Required]
    public string BoardgameName { get; set; } = null!;

    public int BoardgameYearPublished { get; set; }

}
