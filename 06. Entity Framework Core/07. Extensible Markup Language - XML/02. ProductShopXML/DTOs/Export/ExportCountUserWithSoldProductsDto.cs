using System.Xml.Serialization;

namespace ProductShop.DTOs.Export;

[XmlType("count")]
public class ExportCountUserWithSoldProductsDto
{
    [XmlElement("count")]
    public int Count { get; set; }

    [XmlElement("users")]
    public UsersWithAgeAndSoldProductsDto[] Users { get; set; }
}

[XmlType("User")]
public class UsersWithAgeAndSoldProductsDto
{
    [XmlElement("firstName")]
    public string FirstName { get; set; }
    
    [XmlElement("lastName")]
    public string LastName { get; set; }

    [XmlElement("age")]
    public int? Age { get; set; }

    [XmlElement("SoldProducts")]
    public SoldProductsWrapperDto SoldProducts { get; set; }
}

[XmlType("SoldProducts")]
public class SoldProductsWrapperDto
{
    [XmlElement("count")]
    public int Count { get; set; }

    [XmlArray("products")]
    public ExportProductNameAndPriceDto[] Products { get; set; }
}

[XmlType("Product")]
public class ExportProductNameAndPriceDto
{
    [XmlElement("name")]
    public string Name { get; set; }

    [XmlElement("price")]
    public decimal Price { get; set; }
}