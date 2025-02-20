﻿
using System.ComponentModel.DataAnnotations;

namespace P01_HospitalDatabase.Data.Models;
public class Medicament
{
    public int MedicamentId { get; set; }

    public string Name { get; set; }

    public virtual ICollection<PatientMedicament> Prescriptions { get; set; } = null!;
}
