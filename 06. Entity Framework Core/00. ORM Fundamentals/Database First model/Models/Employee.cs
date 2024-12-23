using System;
using System.Collections.Generic;

namespace Database_First_model.Models;

public partial class Employee
{
    public int Id { get; set; }

    public string? FirstName { get; set; }

    public string? MiddleName { get; set; }

    public string? LastName { get; set; }

    public bool? IsEmpolyed { get; set; }

    public int? DepartmentId { get; set; }

    public virtual Department? Department { get; set; }
}
