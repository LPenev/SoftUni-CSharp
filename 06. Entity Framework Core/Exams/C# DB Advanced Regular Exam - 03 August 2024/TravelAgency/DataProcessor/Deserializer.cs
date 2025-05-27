using System.ComponentModel.DataAnnotations;
using System.Text;
using TravelAgency.Data;
using TravelAgency.Data.Models;
using TravelAgency.DataProcessor.ImportDtos;
using TravelAgency.Utilities;

namespace TravelAgency.DataProcessor
{
    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data format!";
        private const string DuplicationDataMessage = "Error! Data duplicated.";
        private const string SuccessfullyImportedCustomer = "Successfully imported customer - {0}";
        private const string SuccessfullyImportedBooking = "Successfully imported booking. TourPackage: {0}, Date: {1}";

        public static string ImportCustomers(TravelAgencyContext context, string xmlString)
        {
            const string XmlRoot = "Customers";
            var customerDtos = XmlHelper.Deserialize<ImportCustomerDto[]>(xmlString, XmlRoot);

            StringBuilder sb = new StringBuilder();
            ICollection<Customer> customers = new HashSet<Customer>();

            foreach (ImportCustomerDto customerDto in customerDtos)
            {
                if (!IsValid(customerDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                bool isDuplicatedInContext = context.Customer
                    .Any(x => x.FulName == customerDto.FullName || x.PhoneNumber == customerDto.PhoneNumber 
                    || x.Email == customerDto.Email);

                if (isDuplicatedInContext) 
                {
                    sb.AppendLine(DuplicationDataMessage);
                    continue;
                }

                Customer customer = new Customer() 
                {
                    FulName = customerDto.FullName,
                    PhoneNumber = customerDto.PhoneNumber,
                    Email = customerDto.Email,
                };

                customers.Add(customer);
                sb.AppendLine(string.Format(SuccessfullyImportedCustomer, customer.FulName));
            }

            return sb.ToString().TrimEnd();
        }

        public static string ImportBookings(TravelAgencyContext context, string jsonString)
        {
            return string.Empty;
        }

        public static bool IsValid(object dto)
        {
            var validateContext = new ValidationContext(dto);
            var validationResults = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(dto, validateContext, validationResults, true);

            foreach (var validationResult in validationResults)
            {
                string currValidationMessage = validationResult.ErrorMessage;
            }

            return isValid;
        }
    }
}
