using System;
using System.Collections.Generic;

namespace Application.Data.Models;

public partial class CourseSemester
{
    public int Id { get; set; }

    public int CourseId { get; set; }

    public int? TrainerId { get; set; }

    public string Semester { get; set; } = null!;

    public int Capacity { get; set; }

    public DateOnly? CourseYear { get; set; }

    public virtual Course Course { get; set; } = null!;

    public virtual ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();

    public virtual Trainer Trainer { get; set; } = null!;
}
