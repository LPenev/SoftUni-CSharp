namespace Invoices.DataProcessor
{
    using Invoices.Data;
    using Invoices.DataProcessor.ExportDto;
    using Newtonsoft.Json;

    public class Serializer
    {
        public static string ExportClientsWithTheirInvoices(InvoicesContext context, DateTime date)
        {
            throw new NotImplementedException();
        }

        public static string ExportProductsWithMostClients(InvoicesContext context, int nameLength)
        {

            var productsToExport = context.Products
                .Where(x => x.ProductsClients.Any())
                .Where(x => x.ProductsClients.Any(pc => pc.Client.Name.Length >= nameLength))
                .Select(x => new ExportProductWithClientsDto()
                {
                    Name = x.Name,
                    Price = x.Price,
                    Category = x.CategoryType.ToString(),
                    Clients = x.ProductsClients
                        .Where(x => x.Client.Name.Length >= nameLength)
                        .Select(x => new ExportClientDto()
                        {
                            Name = x.Client.Name,
                            NumberVat = x.Client.NumberVat,
                        })
                        .OrderBy(x => x.Name)
                        .ToArray()
                })
                .OrderByDescending(x => x.Clients.Length)
                .ThenBy(x => x.Name)
                .Take(5)
                .ToArray();

            return JsonConvert.SerializeObject(productsToExport, Formatting.Indented);
        }
    }
}