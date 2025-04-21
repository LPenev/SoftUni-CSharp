﻿using NetPay.Common;
using System.ComponentModel.DataAnnotations;

namespace NetPay.Data.Models;

public class Service
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(ValidationConstants.SupplierNameMaxLength)]
    public string ServiceName { get; set; } = null!;

    public virtual ICollection<Expense> Expenses { get; set; } = new HashSet<Expense>();
    public virtual ICollection<SupplierService> SuppliersServices { get; set; } = new HashSet<SupplierService>();
}
