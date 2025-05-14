namespace Boardgames.DataProcessor
{
    using Boardgames.Data;
    using Boardgames.DataProcessor.ExportDto;
    using Invoices.Utilities;
    using Newtonsoft.Json;

    public class Serializer
    {
        public static string ExportCreatorsWithTheirBoardgames(BoardgamesContext context)
        {
            var creatorsWithTheirBoardgames = context.Creators
                .Where(x => x.Boardgames.Any())
                .Select(x => new ExportCreatorWithBroardgamesDto()
                {
                    CreatorName = x.FirstName + " " + x.LastName,
                    Boardgames = x.Boardgames
                        .Select(bg => new ExportBoardgameDto()
                        {
                            BoardgameName = bg.Name,
                            BoardgameYearPublished = bg.YearPublished
                        })
                        .OrderBy(x => x.BoardgameName)
                        .ToArray(),
                    BoardgamesCount = x.Boardgames.Count.ToString()
                })
                .OrderByDescending(c => c.BoardgamesCount)
                .ThenBy(c => c.CreatorName)
                .ToArray();

            const string XmlRoot = "Clients";

            return XmlHelper.Serialize(creatorsWithTheirBoardgames, XmlRoot);
        }

        public static string ExportSellersWithMostBoardgames(BoardgamesContext context, int year, double rating)
        {
            var sellersWithMostBoardgames = context.Sellers
                .Where(x => x.BoardgamesSellers.Any(x => x.Boardgame.YearPublished >= year && x.Boardgame.Rating <= rating))
                .Select(s => new ExportSellersWithMostBoardgames()
                {
                    Name = s.Name,
                    Website = s.Website,
                    Boardgames = s.BoardgamesSellers
                            .Where(x => x.Boardgame.YearPublished >= year && x.Boardgame.Rating <= rating)
                            .OrderByDescending(x => x.Boardgame.Rating)
                            .ThenBy(x => x.Boardgame.Name)
                            .Select(x => new ExportBoardgameWithRatingDto()
                            {
                                Name = x.Boardgame.Name,
                                Rating = x.Boardgame.Rating,
                                Mechanics = x.Boardgame.Mechanics,
                                Category = x.Boardgame.CategoryType.ToString(),
                            })
                            .ToArray(),
                })
                .OrderByDescending(x => x.Boardgames.Length)
                .ThenBy(x => x.Name)
                .Take(5)
                .ToArray();

            return JsonConvert.SerializeObject(sellersWithMostBoardgames, Formatting.Indented);
        }
    }
}