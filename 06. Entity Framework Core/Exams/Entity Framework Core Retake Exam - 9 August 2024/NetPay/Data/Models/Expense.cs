using Microsoft.EntityFrameworkCore.Metadata.Internal;
using NetPay.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetPay.Data.Models;

public class Expense
{
    [Key]
    public int Id { get; set; }

    [Required,MinLength(5),MaxLength(50)]
    public string ExpenseName {  get; set; }

    [Column(TypeName = "decimal(18,2)"), Required]
    public decimal Amount { get; set; }

    [Required]
    public DateTime DueDate { get; set; }

    [Required]
    public PaymentStatus PaymentStatus { get; set; }

    [ForeignKey(nameof(Household)), Required]
    public int HouseholdId { get; set; }
    public Household Household { get; set; }

    [Required]
    [ForeignKey(nameof(Service))]
    public int ServiceId { get; set; }
    public Service Service { get; set; }
}
