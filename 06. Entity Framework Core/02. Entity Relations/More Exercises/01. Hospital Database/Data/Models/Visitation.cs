﻿using System.ComponentModel.DataAnnotations;

namespace P01_HospitalDatabase.Data.Models;
public class Visitation
{
    [Key]
    public int VisitationId { get; set; }
    
    [Required]
    public DateTime? Date { get; set; }

    [MaxLength(250)]
    public string Comments { get; set; }
    public int PatientId { get; set; }
}
