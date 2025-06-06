using System.Xml.Serialization;
using static Medicines.Common.ValidationConstants;

namespace Medicines.DataProcessor.ExportDtos;

[XmlType("Medicine")]
public class ExportMedicineDto
{
    public string Name { get; set; }
    public string Price { get; set; }
    public string Producer { get; set; }

    [XmlAttribute(nameof(Category))]
    public string Category { get; set; }

    [XmlElement(MedicineExportExpireDate)]
    public string ExpiryDate { get; set; }
}
