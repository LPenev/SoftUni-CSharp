using Microsoft.EntityFrameworkCore.Metadata.Internal;
using NetPay.Common;
using NetPay.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetPay.Data.Models;

public class Expense
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(ValidationConstants.ExpenceNameMaxLength)]
    public string ExpenseName {  get; set; }

    public decimal Amount { get; set; }

    public DateTime DueDate { get; set; }

    [Required]
    public PaymentStatus PaymentStatus { get; set; }

    [ForeignKey(nameof(Household))]
    public int HouseholdId { get; set; }
    public Household Household { get; set; } = null!;

    [ForeignKey(nameof(Service))]
    public int ServiceId { get; set; }
    public Service Service { get; set; } = null!;
}
