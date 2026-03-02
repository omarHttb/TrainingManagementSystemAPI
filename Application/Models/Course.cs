using System;
using System.Collections.Generic;

namespace Application.Models;

public partial class Course
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;

    public decimal Price { get; set; }

    public DateTime CreationDate { get; set; }

    public int? TrainerId { get; set; }

    public int Capacity { get; set; }

    public bool IsActive { get; set; }

    public bool  IsVerified { get; set; }   

    public string? Thumbnail { get; set; }

    public int? VerifiedBy { get; set; }

    public DateTime? VerifiedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? CreatedAt { get; set; } = DateTime.Now;

    public virtual ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();

    public virtual ICollection<Lesson> Lessons { get; set; } = new List<Lesson>();

    public virtual Trainer? Trainer { get; set; }


}
