using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetPay.Data.Models;

public class SupplierService
{
    [Key]
    [ForeignKey(nameof(SupplierId))]
    public int SupplierId { get; set; }
    public Supplier Supplier { get; set; }

    [Key]
    [ForeignKey(nameof(ServiceId))]
    public int ServiceId { get; set; }
    public Service Service { get; set; }
}
