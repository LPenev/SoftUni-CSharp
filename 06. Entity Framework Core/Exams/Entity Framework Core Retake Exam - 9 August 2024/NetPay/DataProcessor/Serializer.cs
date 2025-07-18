﻿using NetPay.Data;
using NetPay.Data.Models.Enums;
using NetPay.DataProcessor.ExportDtos;
using NetPay.Utilities;
using Newtonsoft.Json;
using System.Globalization;
using System.Text.Json.Nodes;

namespace NetPay.DataProcessor
{
    public class Serializer
    {
        public static string ExportHouseholdsWhichHaveExpensesToPay(NetPayContext context)
        {
            const string XmlRoot = "Households";

            var householdsWhichHaveExpenses = context.Households
                .Where(h => h.Expenses.Any(e => e.PaymentStatus != PaymentStatus.Paid))
                .OrderBy(x => x.ContactPerson)
                .Select(x => new ExportHouseholdXmlDto()
                {
                    ContactPerson = x.ContactPerson,
                    Email = x.Email,
                    PhoneNumber = x.PhoneNumber,
                    Expenses = x.Expenses.Where(x => x.PaymentStatus != PaymentStatus.Paid)
                    .OrderBy(x => x.DueDate)
                    .ThenBy(x => x.Amount)
                    .Select(x => new ExportExpenseDto()
                    {
                        ExpenseName = x.ExpenseName,
                        Amount = x.Amount,
                        PaymentDate = x.DueDate.ToString("d", CultureInfo.InvariantCulture),
                        ServiceName = x.Service.ServiceName
                    })
                    .ToArray()
                })
                .ToArray();

            bool omiXmlDeclaration = false;
            return XmlHelper.Serialize(householdsWhichHaveExpenses, XmlRoot, omiXmlDeclaration);
        }

        public static string ExportAllServicesWithSuppliers(NetPayContext context)
        {
            var allServicesWithSuppliers = context.Services
                .Select(s => new ExportServicesWithSuppliersDto
                {
                    ServiceName = s.ServiceName,
                    Suppliers = s.SuppliersServices.Select(x => new ExportSuppliersDto
                    {
                        SupplierName = x.Supplier.SupplierName,
                    })
                    .OrderBy(x => x.SupplierName)
                    .ToArray()
                })
                .OrderBy(x => x.ServiceName)
                .ToArray();

            return JsonConvert.SerializeObject(allServicesWithSuppliers, Formatting.Indented);
        }
    }
}
