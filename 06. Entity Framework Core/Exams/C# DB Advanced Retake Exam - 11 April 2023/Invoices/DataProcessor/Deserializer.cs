namespace Invoices.DataProcessor
{
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Text;
    using Invoices.Data;
    using Invoices.Data.Models;
    using Invoices.Data.Models.Enums;
    using Invoices.DataProcessor.ImportDto;
    using Invoices.Utilities;
    using Newtonsoft.Json;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedClients
            = "Successfully imported client {0}.";

        private const string SuccessfullyImportedInvoices
            = "Successfully imported invoice with number {0}.";

        private const string SuccessfullyImportedProducts
            = "Successfully imported product - {0} with {1} clients.";


        public static string ImportClients(InvoicesContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();
            const string XmlRoot = "Clients";
            ImportClientDto[] deserializedClients = XmlHelper.Deserialize<ImportClientDto[]>(xmlString, XmlRoot);

            ICollection<Client> clientsToImport = new List<Client>();

            foreach (ImportClientDto clientDto in deserializedClients)
            {
                if (!IsValid(clientDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                ICollection<Address> addressesToImport = new List<Address>();

                foreach (ImportAddressDto addressDto in clientDto.Addresses)
                {
                    if (!IsValid(addressDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    Address address = new Address()
                    {
                        StreetName = addressDto.StreetName,
                        StreetNumber = addressDto.StreetNumber,
                        PostCode = addressDto.PostCode,
                        City = addressDto.City,
                        Country = addressDto.Country,
                    };

                    addressesToImport.Add(address);
                }

                Client newClient = new Client()
                {
                    Name = clientDto.Name,
                    NumberVat = clientDto.NumberVat,
                    Addresses = addressesToImport,
                };

                clientsToImport.Add(newClient);
                sb.AppendLine(String.Format(SuccessfullyImportedClients,clientDto.Name));
            }

            context.Clients.AddRange(clientsToImport);
            context.SaveChanges();

            return sb.ToString();
        }


        public static string ImportInvoices(InvoicesContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            ImportInvoiceDto[]? deserializedInvoices =
                JsonConvert.DeserializeObject<ImportInvoiceDto[]>(jsonString);

            ICollection<Invoice> invoices = new List<Invoice>();
            
            foreach (ImportInvoiceDto invoiceDto in deserializedInvoices)
            {
                if (!IsValid(invoiceDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                bool isIssueDateValid = 
                    DateTime.TryParse(invoiceDto.IssueDate, CultureInfo.InvariantCulture, DateTimeStyles.None, out var issueDate);
                bool isDueDateValid = 
                    DateTime.TryParse(invoiceDto.DueDate, CultureInfo.InvariantCulture, DateTimeStyles.None, out var dueDate);

                bool isDueDateBigIssueDate = DateTime.Compare(dueDate, issueDate) < 0;

                if (invoiceDto.Amount <=0 || !isIssueDateValid || !isDueDateValid ||
                    isDueDateBigIssueDate || !isClientExsist(context, invoiceDto.ClientId))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Invoice newInvoice = new Invoice()
                {
                    Number = invoiceDto.Number,
                    IssueDate = issueDate,
                    DueDate = dueDate,
                    Amount = invoiceDto.Amount,
                    CurrencyType = (CurrencyType)invoiceDto.CurrencyType,
                    ClientId = invoiceDto.ClientId,
                };

                invoices.Add(newInvoice);
                sb.AppendLine(String.Format(SuccessfullyImportedInvoices, newInvoice.Number));
            }

            context.Invoices.AddRange(invoices);
            context.SaveChanges();

            return sb.ToString();
        }

        public static string ImportProducts(InvoicesContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();
            
            ImportProductDto[]? deserializedProducts =
                JsonConvert.DeserializeObject<ImportProductDto[]>(jsonString);

            ICollection<Product> productsToImport = new HashSet<Product>();

            foreach (ImportProductDto productDto in deserializedProducts)
            {
                if (!IsValid(productDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Product newProduct = new Product()
                {
                    Name = productDto.Name,
                    Price = productDto.Price,
                    CategoryType = (CategoryType)productDto.CategoryType,
                };

                ICollection<ProductClient> productClientsToImport = new HashSet<ProductClient>();

                foreach (int clientId in productDto.Clients.Distinct())
                {
                    if(!isClientExsist(context, clientId))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    ProductClient newProductClient = new ProductClient() 
                    {
                        Product = newProduct,
                        ClientId = clientId 
                    };

                    productClientsToImport.Add(newProductClient);
                }

                newProduct.ProductsClients = productClientsToImport;
                productsToImport.Add(newProduct);
                sb.AppendLine(String.Format(SuccessfullyImportedProducts, productDto.Name, productClientsToImport.Count));
            }

            context.Products.AddRange(productsToImport);
            context.SaveChanges();

            return sb.ToString();
        }

        public static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }

        public static bool isClientExsist(InvoicesContext context , int clientId)
        {
            return context.Clients.Select(x => x.Id).Any(id => id == clientId);
        }

    } 
}
