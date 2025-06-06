namespace Medicines.DataProcessor
{
    using Medicines.Data;
    using Medicines.DataProcessor.ExportDtos;
    using Medicines.DataProcessor.ImportDtos;
    using Medicines.Utilities;
    using Microsoft.EntityFrameworkCore;
    using System.Text;

    public class Serializer
    {
        public static string ExportPatientsWithTheirMedicines(MedicinesContext context, string date)
        {
            if (!DateTime.TryParse(date, out var givenDate))
            {
                throw new ArgumentException("Invalid date format!");
            }

            ExportPatientDto[] patients = context.Patients.AsNoTracking()
                .Where(p => p.PatientsMedicines.Any(pm => pm.Medicine.ProductionDate >= givenDate))
                .Select(p => new ExportPatientDto
                {
                    FullName = p.FullName,
                    AgeGroup = p.AgeGroup.ToString(),
                    Gender = p.Gender.ToString().ToLower(),
                    Medicines = p.PatientsMedicines
                    .Where(pm => pm.Medicine.ProductionDate >= givenDate)
                    .Select(pm => pm.Medicine)
                    .OrderByDescending(m => m.ExpiryDate)
                    .ThenBy(m => m.Price)
                    .Select(m => new ExportMedicineDto
                    {
                        Name = m.Name,
                        Price = m.Price.ToString("F2"),
                        Category = m.Category.ToString().ToLower(),
                        Producer = m.Producer,
                        ExpiryDate = m.ExpiryDate.ToString("yyyy-MM-dd")
                    })
                    .ToArray()
                })
                .OrderByDescending(p => p.Medicines.Length)
                .ThenBy(p => p.FullName)
                .ToArray();


            const string XmlRoot = "Patients";
            const bool OmitXmlDeclaration = false;
            return XmlHelper.Serialize(patients, XmlRoot, OmitXmlDeclaration);
        }

        public static string ExportMedicinesFromDesiredCategoryInNonStopPharmacies(MedicinesContext context, int medicineCategory)
        {
            return null;
        }
    }
}
