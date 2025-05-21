using NetPay.Data.Models;

namespace NetPay.DataProcessor.ExportDtos;

public class ExportServicesWithSuppliersDto
{
    public string ServiceName { get; set; } = null!;
    public ExportSuppliersDto[] Suppliers { get; set; } = null!;
}
