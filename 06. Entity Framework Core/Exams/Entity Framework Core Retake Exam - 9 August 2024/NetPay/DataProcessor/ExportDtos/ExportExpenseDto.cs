using NetPay.Data.Models;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using static NetPay.Common.ValidationConstants;

namespace NetPay.DataProcessor.ExportDtos;

[XmlType(nameof(Expense))]
public class ExportExpenseDto
{
    
    [XmlElement(nameof(ExpenseName))]
    public string ExpenseName { get; set; } = null!;

    [XmlElement(nameof(Amount))]
    public decimal Amount { get; set; }

    [XmlElement(nameof(PaymentDate))]
    public string PaymentDate { get; set; } = null!;

    [XmlElement(nameof(ServiceName))]
    public string ServiceName { get; set; } = null!;
}
