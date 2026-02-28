using System;
using System.Collections.Generic;

namespace Application.Models;

public partial class Grade
{
    public int Id { get; set; }

    public int EnrollmentId { get; set; }

    public decimal Grade1 { get; set; }

    public bool? IsPass { get; set; }

    public virtual Enrollment Enrollment { get; set; } = null!;
}
