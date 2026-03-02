using System;
using System.Collections.Generic;

namespace Application.Models;

public partial class Lesson
{
    public int Id { get; set; }

    public string LessonName { get; set; } = null!;

    public string LessonDescription { get; set; } = null!;

    public int CourseId { get; set; }

    public bool IsActive { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<Attendence> Attendences { get; set; } = new List<Attendence>();

    public virtual Course Course { get; set; } = null!;

    public virtual ICollection<Quizz> Quizzs { get; set; } = new List<Quizz>();
}
