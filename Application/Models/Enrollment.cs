using System;
using System.Collections.Generic;

namespace Infastructure.Models;

public partial class Enrollment
{
    public int Id { get; set; }

    public int CourseId { get; set; }

    public int TraineeId { get; set; }

    public DateTime EnrollmentDate { get; set; }

    public virtual ICollection<Attendence> Attendences { get; set; } = new List<Attendence>();

    public virtual Course Course { get; set; } = null!;

    public virtual ICollection<Grade> Grades { get; set; } = new List<Grade>();

    public virtual Trainee Trainee { get; set; } = null!;
}
