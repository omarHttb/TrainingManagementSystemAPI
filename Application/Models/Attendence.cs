using System;
using System.Collections.Generic;

namespace Application.Models;

public partial class Attendence
{
    public int Id { get; set; }

    public int EnrollmentId { get; set; }

    public bool DidAttend { get; set; }

    public int LessonId { get; set; }

    public DateTime? AttendanceDate { get; set; } = DateTime.Now;

    public virtual Enrollment Enrollment { get; set; } = null!;

    public virtual Lesson Lesson { get; set; } = null!;
}
