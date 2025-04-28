using System.ComponentModel.DataAnnotations;
using static Invoices.Common.ValidationConstants;

namespace Invoices.DataProcessor.ImportDto;

public class ImportInvoiceDto
{
    [Range(InvoiceMinNumber, InvoiceMaxNumber)]
    public int Number { get; set; }
    [Required]
    public string IssueDate { get; set; } = null!;
    [Required]
    public string DueDate { get; set; } = null!;
    public decimal Amount { get; set; }
    
    [Range(InvoiceMinCurrencyType, InvoiceMaxCurrencyType)]
    public int CurrencyType { get; set; }
    public int ClientId { get; set; }
}
