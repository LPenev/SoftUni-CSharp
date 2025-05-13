namespace Boardgames.DataProcessor.ExportDto;

public class ExportSellersWithMostBoardgames
{
    public string Name { get; set; } = null!;
    public string Website { get; set; } = null!;
    public ExportBoardgameWithRatingDto[] Boardgames { get; set; } = null!;
}
