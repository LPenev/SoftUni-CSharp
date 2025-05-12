namespace Boardgames.DataProcessor
{
    using System.ComponentModel.DataAnnotations;
    using System.Text;
    using Boardgames.Data;
    using Boardgames.Data.Models;
    using Boardgames.Data.Models.Enums;
    using Boardgames.DataProcessor.ImportDto;
    using Invoices.Utilities;
    using Newtonsoft.Json;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedCreator
            = "Successfully imported creator – {0} {1} with {2} boardgames.";

        private const string SuccessfullyImportedSeller
            = "Successfully imported seller - {0} with {1} boardgames.";

        public static string ImportCreators(BoardgamesContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();

            const string XmlRootName = "Creators";
            ImportCreatorDto[] deserializedCreatorsDto = XmlHelper.Deserialize<ImportCreatorDto[]>(xmlString, XmlRootName);

            ICollection<Creator> creatorsToImport = new HashSet<Creator>();

            foreach (var creatorDto in deserializedCreatorsDto)
            {
                if (!IsValid(creatorDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                ICollection<Boardgame> boardgamesToImport = new HashSet<Boardgame>();
                foreach (var boardgameDto in creatorDto.Boardgames)
                {
                    if (!IsValid(boardgameDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    Boardgame newBoardgame = new Boardgame() 
                    {
                        Name = boardgameDto.Name,
                        Rating = boardgameDto.Rating,
                        YearPublished = boardgameDto.YearPublished,
                        CategoryType = (CategoryType)boardgameDto.CategoryType,
                        Mechanics = boardgameDto.Mechanics,
                    };

                    boardgamesToImport.Add(newBoardgame);
                }

                Creator newCreator = new Creator()
                {
                    FirstName = creatorDto.FirstName,
                    LastName = creatorDto.LastName,
                    Boardgames = boardgamesToImport,
                };

                creatorsToImport.Add(newCreator);
                sb.AppendLine(String.Format(SuccessfullyImportedCreator, newCreator.FirstName, newCreator.LastName, newCreator.Boardgames.Count));
            }

            context.Creators.AddRange(creatorsToImport);
            context.SaveChanges();
            return sb.ToString();
        }

        public static string ImportSellers(BoardgamesContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            var deserializedSellers = JsonConvert.DeserializeObject<ImportSellerDto[]>(jsonString);

            if (deserializedSellers != null)
            {
                ICollection<Seller> sellers = new HashSet<Seller>();

                foreach (var sellerDto in deserializedSellers)
                {
                    if (!IsValid(sellerDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    Seller newSeller = new Seller()
                    {
                        Name = sellerDto.Name,
                        Address = sellerDto.Address,
                        Country = sellerDto.Country,
                        Website = sellerDto.Website,
                    };

                    foreach (var boardgameId in sellerDto.Boardgames.Distinct())
                    {
                        Boardgame currentBoardgame = context.Boardgames.Find(boardgameId);

                        if (currentBoardgame == null)
                        {
                            sb.AppendLine(ErrorMessage);
                            continue;
                        }

                        var newBoardgame = new BoardgameSeller()
                        {
                            Boardgame = currentBoardgame,
                        };

                        newSeller.BoardgamesSellers.Add(newBoardgame);
                    }

                    sellers.Add(newSeller);
                    sb.AppendLine(string.Format(SuccessfullyImportedSeller,newSeller.Name, newSeller.BoardgamesSellers.Count));
                }

                context.Sellers.AddRange(sellers);
                context.SaveChanges();
            }
            return sb.ToString();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}
