using System.Xml.Serialization;

namespace CarDealer.DTOs.Import;

[XmlType("Supplier")]
[XmlRoot("Suppliers")]
public class SupplierImportDto
{
    [XmlElement("name")]
    public string Name { get; set; }
    [XmlElement("isImporter")]
    public bool IsImporter { get; set; }
}
