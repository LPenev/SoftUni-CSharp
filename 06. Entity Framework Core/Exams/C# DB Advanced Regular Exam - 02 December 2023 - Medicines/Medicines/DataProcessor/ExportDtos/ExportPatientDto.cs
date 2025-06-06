using Medicines.Data.Models;
using System.Xml.Serialization;
using static Medicines.Common.ValidationConstants;

namespace Medicines.DataProcessor.ExportDtos;

[XmlType(nameof(Patient))]
public class ExportPatientDto
{
    [XmlElement("Name")]
    public string FullName { get; set; }
    public string AgeGroup { get; set; }
    
    [XmlAttribute(nameof(Gender))]
    public string Gender { get; set; } = null!;
    public ExportMedicineDto[] Medicines { get; set; }
}
