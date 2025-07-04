﻿using System.ComponentModel.DataAnnotations;
using TravelAgency.Data.Models.Enums;
using static TravelAgency.Common.ValidationConstants;

namespace TravelAgency.Data.Models;

public class Guide
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(GuideFullNameMaxLength)]
    public string FullName { get; set; } = null!;

    public Language Language { get; set; }

    public virtual ICollection<TourPackageGuide> TourPackageGuides { get; set; } = new HashSet<TourPackageGuide>();
}
