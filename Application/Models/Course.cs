using System;
using System.Collections.Generic;

namespace Infastructure.Models;

public partial class Course
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;

    public decimal Price { get; set; }

    public DateTime CreationDate { get; set; }

    public int TrainerId { get; set; }

    public int Capacity { get; set; }

    public virtual ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();

    public virtual Trainer Trainer { get; set; } = null!;
}
