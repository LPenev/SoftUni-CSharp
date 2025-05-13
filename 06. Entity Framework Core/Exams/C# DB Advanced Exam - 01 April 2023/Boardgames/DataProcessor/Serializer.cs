namespace Boardgames.DataProcessor
{
    using Boardgames.Data;
    using Boardgames.DataProcessor.ExportDto;
    using Newtonsoft.Json;
    using System.Text.Json.Nodes;

    public class Serializer
    {
        public static string ExportCreatorsWithTheirBoardgames(BoardgamesContext context)
        {
            throw new NotImplementedException();
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