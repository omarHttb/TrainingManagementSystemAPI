using System;
using System.Collections.Generic;

namespace Application.Data.Models;

public partial class Course
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public virtual ICollection<CourseSemester> CourseSemesters { get; set; } = new List<CourseSemester>();
}
