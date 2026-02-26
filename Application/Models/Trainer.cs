using System;
using System.Collections.Generic;

namespace Application.Models;

public partial class Trainer
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public string TeachingSubject { get; set; } = null!;

    public bool IsActive { get; set; }

    public string Headline { get; set; } = null!;

    public string Bio { get; set; } = null!;

    public short ExperienceYears { get; set; }

    public DateTime? JoinDate { get; set; }

    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();

    public virtual User User { get; set; } = null!;
}
