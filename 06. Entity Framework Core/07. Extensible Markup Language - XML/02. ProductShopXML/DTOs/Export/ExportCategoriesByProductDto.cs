﻿using System.Xml.Serialization;

namespace ProductShop.DTOs.Export;

[XmlType("CategoryProduct")]
public class ExportCategoriesByProductDto
{
    [XmlElement("name")]
    public string Name { get; set; }

    [XmlElement("count")]
    public int Count { get; set; }

    [XmlElement("averagePrice")]
    public decimal AveragePrice { get; set; }

    [XmlElement("totalRevenue")]
    public decimal TotalRevenue { get; set; }
}
