using System;
using System.Collections.Generic;

namespace Application.Models;

public partial class Trainee
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public DateTime? JoinDate { get; set; }

    public virtual ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();

    public virtual User User { get; set; } = null!;
}
