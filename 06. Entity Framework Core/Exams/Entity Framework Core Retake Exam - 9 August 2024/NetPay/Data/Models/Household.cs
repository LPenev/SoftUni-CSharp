using NetPay.Common;
using System.ComponentModel.DataAnnotations;

namespace NetPay.Data.Models;

public class Household
{
    [Key]
    public int Id { get; set; }

    [Required] 
    [MinLength(ValidationConstants.HouseholdContactPersonMinLength)]
    [MaxLength(ValidationConstants.HouseholdContactPersonMaxLength)]
    public string ContactPerson {  get; set; }

    [MinLength(ValidationConstants.EmailMinLength)]
    [MaxLength(ValidationConstants.EmailMaxLength)]
    public string? Email {  get; set; }

    [Required]
    [MaxLength(ValidationConstants.PhoneNumberLength)]
    [RegularExpression(ValidationConstants.PhoneNumberPattern)]
    public string PhoneNumber { get; set; }

    public virtual ICollection<Expense> Expenses { get; set; }

}
