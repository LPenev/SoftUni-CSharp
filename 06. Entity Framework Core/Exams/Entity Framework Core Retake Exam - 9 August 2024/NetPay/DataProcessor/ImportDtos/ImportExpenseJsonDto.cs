using NetPay.Data.Models.Enums;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using static NetPay.Common.ValidationConstants;

namespace NetPay.DataProcessor.ImportDtos;

public class ImportExpenseJsonDto
{
    [Required]
    [JsonProperty("ExpenseName")]
    [MinLength(ExpenceNameMinLength)]
    [MaxLength(ExpenceNameMaxLength)]
    public string ExpenseName { get; set; } = null!;

    [JsonProperty("Amount")]
    [Range(ExpenceMinAmount, ExpenceMaxAmount)]
    public decimal Amount { get; set; }

    [Required]
    [JsonProperty("DueDate")]
    public string DueDate { get; set; } = null!;

    [Required]
    [EnumDataType(typeof(PaymentStatus))]
    [JsonProperty("PaymentStatus")]
    public string PaymentStatus { get; set; } = null!;

    [JsonProperty("HouseholdId")]
    public int HouseholdId { get; set; }

    [JsonProperty("ServiceId")]
    public int ServiceId { get; set; }
}
