using System;
using System.Collections.Generic;

namespace DatabaseFirstModel.Models;

public partial class EmployeesProject
{
    public int? ProjectId { get; set; }

    public int? EmployeeId { get; set; }

    public virtual Employee? Employee { get; set; }

    public virtual Project? Project { get; set; }
}
