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
    [MinLength(ValidationConstants.ExpenceNameMinLength)]
    [MaxLength(ValidationConstants.ExpenceNameMaxLength)]
    public string ExpenseName {  get; set; }

    [Required]
    [Range(typeof(decimal), ValidationConstants.MinAmount, ValidationConstants.MaxAmount)]
    [Column(TypeName = "decimal(18,2)")]
    public decimal Amount { get; set; }

    [Required]
    public DateTime DueDate { get; set; }

    [Required]
    public PaymentStatus PaymentStatus { get; set; }

    [Required]
    [ForeignKey(nameof(Household))]
    public int HouseholdId { get; set; }
    public Household Household { get; set; }

    [Required]
    [ForeignKey(nameof(Service))]
    public int ServiceId { get; set; }
    public Service Service { get; set; }
}
