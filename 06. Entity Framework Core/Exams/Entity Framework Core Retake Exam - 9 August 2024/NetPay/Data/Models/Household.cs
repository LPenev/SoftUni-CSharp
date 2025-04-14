using System.ComponentModel.DataAnnotations;

namespace NetPay.Data.Models;

public class Household
{
    [Key]
    public int Id { get; set; }

    [Required, MinLength(5), MaxLength(50)]
    public string ContactPerson {  get; set; }

    [MinLength(6),MaxLength(80)]
    public string? Email {  get; set; }

    [Required, MaxLength(15)]
    [RegularExpression(@"^\+\d{3}/\d{3}-\d{6}$")]
    public string PhoneNumber { get; set; }

    public virtual ICollection<Expense> Expenses { get; set; }

}
