﻿using System.Xml.Serialization;

namespace CarDealer.DTOs.Export;

[XmlType("sale")]
public class ExportSalesDiscountDto
{
    [XmlElement("car")]
    public CarDto Car { get; set; }

    [XmlElement("discount")]
    public int Discount { get; set; }

    [XmlElement("customer-name")]
    public string Customer { get; set; }
    
    [XmlElement("price")]
    public decimal Price { get; set; }
    
    [XmlElement("price-with-discount")]
    public double DiscountPrice { get; set; }
}
