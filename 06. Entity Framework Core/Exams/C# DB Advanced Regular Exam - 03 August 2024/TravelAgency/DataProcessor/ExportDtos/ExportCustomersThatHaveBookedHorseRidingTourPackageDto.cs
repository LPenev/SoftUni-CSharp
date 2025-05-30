using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace TravelAgency.DataProcessor.ExportDtos;

public class ExportCustomersThatHaveBookedHorseRidingTourPackageDto
{
    public string FullName { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public ExportBookingDto[] Bookings { get; set; } = null!;
}
