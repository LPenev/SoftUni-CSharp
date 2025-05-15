using NetPay.Common;
using System.ComponentModel.DataAnnotations;

namespace NetPay.Data.Models;

public class Household
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(ValidationConstants.HouseholdContactPersonMaxLength)]
    public string ContactPerson { get; set; } = null!;

    [MaxLength(ValidationConstants.EmailMaxLength)]
    public string? Email {  get; set; }

    [Required]
    [MaxLength(ValidationConstants.PhoneNumberLength)]
    public string PhoneNumber { get; set; } = null!;

    public virtual ICollection<Expense> Expenses { get; set; } = new HashSet<Expense>();

}
