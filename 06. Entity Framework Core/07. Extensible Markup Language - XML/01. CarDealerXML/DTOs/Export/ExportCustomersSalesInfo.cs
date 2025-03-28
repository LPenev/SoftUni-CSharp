using CarDealer.Models;
using System;
using System.Security.Principal;
using System.Xml.Serialization;

namespace CarDealer.DTOs.Export;

[XmlType("customer")]
public class ExportCustomersSalesInfo
{
    [XmlAttribute("full-name")]
    public string FullName { get; set; }

    [XmlAttribute("bought-cars")]
    public int BoughtCars { get; set; }

    [XmlAttribute("spent-money")]
    public string SpentMoney { get; set; }
}
