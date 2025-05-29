using Newtonsoft.Json;
using System.Text;
using TravelAgency.Data;
using TravelAgency.Data.Models.Enums;
using TravelAgency.DataProcessor.ExportDtos;
using TravelAgency.Utilities;

namespace TravelAgency.DataProcessor
{
    public class Serializer
    {
        public static string ExportGuidesWithSpanishLanguageWithAllTheirTourPackages(TravelAgencyContext context)
        {

            var guidesSpeakingSpanish = context.Guides
                .Where(g => g.Language == Language.Spanish)
                .Select(x => new ExportGuideDto()
                {
                    FullName = x.FullName,
                    TourPackages = x.TourPackageGuides.Select(t => new ExportTourPackageDto
                    {
                        Name = t.TourPackage.PackageName,
                        Description = t.TourPackage.Description,
                        Price = t.TourPackage.Price,
                    })
                    .OrderByDescending(x => x.Price)
                    .ThenBy(x => x.Name)
                    .ToArray()
                })
                .ToArray();

            const string XmlRoot = "Guides";
            const bool OmiXmlDeclaration = false;

            return XmlHelper.Serialize(guidesSpeakingSpanish, XmlRoot, OmiXmlDeclaration);
        }

        public static string ExportCustomersThatHaveBookedHorseRidingTourPackage(TravelAgencyContext context)
        {
            return String.Empty;
        }
    }
}
