using System;
using System.Collections.Generic;

namespace Application.Models;

public partial class Quizz
{
    public int Id { get; set; }

    public int LessonId { get; set; }

    public short GradeEarned { get; set; }

    public short MaxGrade { get; set; }

    public DateTime QuizzDate { get; set; }

    public int EnrollmentId { get; set; }

    public virtual Enrollment Enrollment { get; set; } = null!;

    public virtual Lesson Lesson { get; set; } = null!;
}
