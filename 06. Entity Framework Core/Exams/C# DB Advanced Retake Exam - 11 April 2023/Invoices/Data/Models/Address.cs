﻿using static Invoices.Common.ValidationConstants;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Invoices.Data.Models;

public class Address
{
    [Key]
    public int Id { get; set; }
    [Required]
    [MaxLength(AddressStreetNameMaxLenght)]
    public string StreetName { get; set; } = null!;
    public int StreetNumber { get; set; }
    [Required]
    public String PostCode { get; set; } = null!;
    [Required]
    [MaxLength(AddressCityMaxLenght)]
    public string City { get; set; } = null!;
    [Required]
    [MaxLength(AddressCountryMaxLenght)]
    public string Country { get; set; } = null!;

    [ForeignKey(nameof(Client))]
    [Required]
    public int ClientId { get; set; }
    public virtual Client Client { get; set; } = null!;
}
