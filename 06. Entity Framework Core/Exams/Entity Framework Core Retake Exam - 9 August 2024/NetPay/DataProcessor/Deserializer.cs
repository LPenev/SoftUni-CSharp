using NetPay.Data;
using NetPay.Data.Models;
using NetPay.Data.Models.Enums;
using NetPay.DataProcessor.ImportDtos;
using NetPay.Utilities;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text;

namespace NetPay.DataProcessor
{
    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data format!";
        private const string DuplicationDataMessage = "Error! Data duplicated.";
        private const string SuccessfullyImportedHousehold = "Successfully imported household. Contact person: {0}";
        private const string SuccessfullyImportedExpense = "Successfully imported expense. {0}, Amount: {1}";

        public static string ImportHouseholds(NetPayContext context, string xmlString)
        {
            const string XmlRoot = "Households";
            var housholdDtos = XmlHelper.Deserialize<ImportHausholdXmlDto[]>(xmlString, XmlRoot);

            StringBuilder sb = new StringBuilder();
            ICollection<Household> households = new HashSet<Household>();

            foreach (var householdDto in housholdDtos)
            {
                if (!IsValid(householdDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }


                Household newHousehold = new Household()
                {
                    ContactPerson = householdDto.ContactPerson,
                    Email = householdDto.Email,
                    PhoneNumber = householdDto.PhoneNumber,
                };

                bool isDuplicationInContext = context.Households.Any(x => x.ContactPerson == newHousehold.ContactPerson) ||
                                              context.Households.Any(x => x.Email == newHousehold.Email) ||
                                              context.Households.Any(x => x.PhoneNumber == newHousehold.PhoneNumber);

                bool isDuplicationInHouseholds = households.Any(h => h.ContactPerson == newHousehold.ContactPerson) ||
                                                 households.Any(h => h.Email == newHousehold.Email) ||
                                                 households.Any(h => h.PhoneNumber == newHousehold.PhoneNumber);

                if (isDuplicationInContext || isDuplicationInHouseholds)
                {
                    sb.AppendLine(DuplicationDataMessage);
                    continue;
                }

                households.Add(newHousehold);
                sb.AppendLine(string.Format(SuccessfullyImportedHousehold, newHousehold.ContactPerson));
            }

            context.AddRange(households);
            context.SaveChanges();

            return sb.ToString();
        }

        public static string ImportExpenses(NetPayContext context, string jsonString)
        {
            var sb = new StringBuilder();
            var expensesDto = JsonConvert.DeserializeObject<ImportExpenseJsonDto[]>(jsonString);

            ICollection<Expense> expenses = new HashSet<Expense>();

            foreach (var expenseDto in expensesDto)
            {
                if (!IsValid(expenseDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                bool isServiceIdValid = context.Services.Any(x => x.Id == expenseDto.ServiceId);
                
                bool isHouseholdIdValid = context.Households.Any(x => x.Id == expenseDto.HouseholdId);

                bool isDueDateValid = DateTime.TryParseExact(expenseDto.DueDate, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out var dueDate);
                bool isPaymentStatusValid = Enum.TryParse<PaymentStatus>(expenseDto.PaymentStatus, out var PaymentStatus);

                if (!isServiceIdValid || !isHouseholdIdValid || !isDueDateValid || !isPaymentStatusValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var exprense = new Expense()
                {
                    ExpenseName = expenseDto.ExpenseName,
                    Amount = expenseDto.Amount,
                    DueDate = dueDate,
                    PaymentStatus = Enum.Parse<PaymentStatus>(expenseDto.PaymentStatus),
                    HouseholdId = expenseDto.HouseholdId,
                    ServiceId = expenseDto.ServiceId,
                };

                expenses.Add(exprense);
                sb.AppendLine(String.Format(SuccessfullyImportedExpense, exprense.ExpenseName, exprense.Amount.ToString("F2")));
                Console.WriteLine(String.Format(SuccessfullyImportedExpense, exprense.ExpenseName, exprense.Amount.ToString("F2")));
            }

            context.Expenses.AddRange(expenses);
            context.SaveChanges();

            return sb.ToString();
        }

        public static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResults = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(dto, validationContext, validationResults, true);

            foreach(var result in validationResults)
            {
                string currvValidationMessage = result.ErrorMessage;
            }

            return isValid;
        }
    }
}
