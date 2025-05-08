namespace Invoices.DataProcessor.ExportDto;

public class ExportProductWithClientsDto
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Category { get; set; }
    public ExportClientDto[] Clients { get; set; }
}
