using System;
using System.Collections.Generic;

namespace Infastructure.Data.Models;

public partial class Trainer
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public string TeachingSubject { get; set; } = null!;

    public DateTime? JoinDate { get; set; }

    public virtual ICollection<CourseSemester> CourseSemesters { get; set; } = new List<CourseSemester>();

    public virtual User User { get; set; } = null!;
}
