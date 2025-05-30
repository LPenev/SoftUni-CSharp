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
            var customersThatHaveBookedHorseRidingTP = context.Customers
                .Where(c => c.Bookings.Any(b => b.TourPackage.PackageName == "Horse Riding Tour"))
                .Select(x => new ExportCustomersThatHaveBookedHorseRidingTourPackageDto()
                {
                    FullName = x.FullName,
                    PhoneNumber = x.PhoneNumber,
                    Bookings = x.Bookings
                        .Where(x => x.TourPackage.PackageName == "Horse Riding Tour")
                        .OrderBy(x => x.BookingDate)
                        .Select(x => new ExportBookingDto()
                        {
                            TourPackageName = x.TourPackage.PackageName,
                            Date = x.BookingDate.ToString("yyyy-MM-dd"),
                        })
                        .ToArray()
                })
                .OrderByDescending(x => x.Bookings.Length)
                .ThenBy(x => x.FullName)
                .ToArray();

            return JsonConvert.SerializeObject(customersThatHaveBookedHorseRidingTP, Formatting.Indented);
        }
    }
}
