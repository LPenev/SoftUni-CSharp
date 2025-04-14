using NetPay.Common;
using System.ComponentModel.DataAnnotations;

namespace NetPay.Data.Models;

public class Service
{
    public Service()
    {
        this.Expenses = new HashSet<Expense>();
        this.SuppliersServices = new HashSet<SupplierService>();
    }

    [Key]
    public int Id { get; set; }

    [Required]
    [MinLength(ValidationConstants.ServiceNameMinLength)]
    [MaxLength(ValidationConstants.SupplierNameMaxLength)]
    public string ServiceName { get; set; }

    public virtual ICollection<Expense> Expenses { get; set; }
    public virtual ICollection<SupplierService> SuppliersServices { get; set; }
}
