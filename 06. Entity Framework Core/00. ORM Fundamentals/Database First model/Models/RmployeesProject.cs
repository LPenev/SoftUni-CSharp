using System;
using System.Collections.Generic;

namespace Database_First_model.Models;

public partial class RmployeesProject
{
    public int? ProjectId { get; set; }

    public int? EmployeeId { get; set; }

    public virtual Employee? Employee { get; set; }

    public virtual Project? Project { get; set; }
}
