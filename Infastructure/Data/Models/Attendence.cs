using System;
using System.Collections.Generic;

namespace Infastructure.Data.Models;

public partial class Attendence
{
    public int Id { get; set; }

    public int EnrollmentId { get; set; }

    public bool DidAttend { get; set; }

    public DateOnly? AttendanceDate { get; set; }

    public virtual Enrollment Enrollment { get; set; } = null!;
}
