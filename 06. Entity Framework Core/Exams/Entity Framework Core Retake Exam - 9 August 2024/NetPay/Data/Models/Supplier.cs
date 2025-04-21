using NetPay.Common;
using System.ComponentModel.DataAnnotations;

namespace NetPay.Data.Models;

public class Supplier
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(ValidationConstants.SupplierNameMaxLength)]
    public string SupplierName { get; set; }

    public virtual ICollection<SupplierService> SuppliersServices { get; set; } = new HashSet<SupplierService>();
}
