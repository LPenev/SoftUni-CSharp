﻿using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
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

                bool isDuplicatedInContext = context.Customers
                    .Any(x => x.FullName == customerDto.FullName || x.PhoneNumber == customerDto.PhoneNumber 
                    || x.Email == customerDto.Email);

                if (isDuplicatedInContext) 
                {
                    sb.AppendLine(DuplicationDataMessage);
                    continue;
                }

                Customer customer = new Customer() 
                {
                    FullName = customerDto.FullName,
                    PhoneNumber = customerDto.PhoneNumber,
                    Email = customerDto.Email,
                };

                customers.Add(customer);
                sb.AppendLine(string.Format(SuccessfullyImportedCustomer, customer.FullName));
            }

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportBookings(TravelAgencyContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();
            ICollection<Booking> bookings = new HashSet<Booking>();

            var bookingDtos = JsonConvert.DeserializeObject<ImportBookingDto[]>(jsonString);

            if (bookingDtos is null)
            {
                sb.AppendLine("Imported File ist empty");
                return sb.ToString();
            }

            foreach (var bookingDto in bookingDtos)
            {
                if (!IsValid(bookingDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (!DateTime.TryParseExact(bookingDto.BookingDate, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out var bookingDate))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var customer = context.Customers.FirstOrDefault(x => x.FullName == bookingDto.CustomerName);
                var tourPackage = context.TourPackages.FirstOrDefault(x => x.PackageName == bookingDto.TourPackageName);

                if(customer is null || tourPackage is null)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var booking = new Booking()
                {
                    BookingDate = bookingDate,
                    CustomerId = customer.Id,
                    TourPackageId = tourPackage.Id,
                };

                bookings.Add(booking);
                sb.AppendLine(string.Format(SuccessfullyImportedBooking, tourPackage.PackageName, bookingDate.ToString("yyyy-MM-dd")));
            }
            
            context.AddRange(bookings);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
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
