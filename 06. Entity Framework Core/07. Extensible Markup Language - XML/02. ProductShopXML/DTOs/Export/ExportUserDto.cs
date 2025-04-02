using ProductShop.Models;
using System.Xml.Serialization;

namespace ProductShop.DTOs.Export;

[XmlType("User")]
public class ExportUserDto
{
    [XmlElement("firstName")]
    public string FirstName { get; set; }

    [XmlElement("lastName")]
    public string LastName { get; set; }
    [XmlArray("soldProducts")]
    public SoldProductDto[] SoldedProducts { get; set; }

}
