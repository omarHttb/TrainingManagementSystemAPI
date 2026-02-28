using System;
using System.Collections.Generic;

namespace Application.Models;

public partial class Lesson
{
    public int Id { get; set; }

    public string LessonName { get; set; } = null!;

    public string LessonDescription { get; set; } = null!;

    public int CourseId { get; set; }

    public virtual ICollection<Attendence> Attendences { get; set; } = new List<Attendence>();

    public virtual Course Course { get; set; } = null!;
}
