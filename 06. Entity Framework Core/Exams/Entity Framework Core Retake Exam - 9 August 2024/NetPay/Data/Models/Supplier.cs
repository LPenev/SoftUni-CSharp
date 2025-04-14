using NetPay.Common;
using System.ComponentModel.DataAnnotations;

namespace NetPay.Data.Models;

public class Supplier
{
    public Supplier()
    {
        this.SuppliersServices = new HashSet<SupplierService>();
    }

    [Key]
    public int Id { get; set; }

    [Required]
    [MinLength(ValidationConstants.SupplierNameMinLength)]
    [MaxLength(ValidationConstants.SupplierNameMaxLength)]
    public string SupplierName { get; set; }

    public virtual ICollection<SupplierService> SuppliersServices { get; set; }
}
