namespace Invoices.DataProcessor
{
    using Castle.Components.DictionaryAdapter;
    using Invoices.Data;
    using Invoices.DataProcessor.ExportDto;
    using Invoices.Utilities;
    using Newtonsoft.Json;
    using System.Globalization;
    using System.Xml.Serialization;

    public class Serializer
    {
        public static string ExportClientsWithTheirInvoices(InvoicesContext context, DateTime date)
        {
            const string XmlRoot = "Clients";

            var clientsWithInvoices = context.Clients
                .Where(x => x.Invoices.Any(d => DateTime.Compare(d.IssueDate, date) > 0))
                .Select(x => new ExportClientWithInvoicesDto()
                {
                    ClientName = x.Name,
                    VatNumber = x.NumberVat,
                    Invoices = x.Invoices
                        .OrderBy(i => i.IssueDate)
                        .ThenByDescending(i => i.DueDate)
                        .Select(x => new ExportInvoiceDto()
                        {
                            InvoiceNumber = x.Number,
                            InvoiceAmount = x.Amount,
                            Currency = x.CurrencyType.ToString(),
                            DueDate = x.DueDate.ToString("d", CultureInfo.InvariantCulture)
                        })
                        .ToArray(),
                    InvoicesCount = x.Invoices.Count
                })

                .ToArray();

            return XmlHelper.Serialize(clientsWithInvoices, XmlRoot);
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