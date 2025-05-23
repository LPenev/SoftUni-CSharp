﻿using Invoices.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Invoices.Data.Models;

public class Invoice
{
    [Key]
    public int Id { get; set; }
    public int Number { get; set; }
    public DateTime IssueDate { get; set; }
    [Required]
    public DateTime DueDate { get; set; }
    [Required]
    public decimal Amount { get; set; }
    [Required]
    public CurrencyType CurrencyType { get; set; }

    [Required]
    [ForeignKey(nameof(Client))]
    public int ClientId { get; set; }
    public virtual Client Client { get; set; } = null!;

}
