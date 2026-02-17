using System;
using System.Collections.Generic;

namespace Infastructure.Data.Models;

public partial class User
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Gender { get; set; } = null!;

    public DateOnly DateOfBirth { get; set; }

    public DateTime? UserCreationDate { get; set; }

    public virtual ICollection<Trainee> Trainees { get; set; } = new List<Trainee>();

    public virtual ICollection<Trainer> Trainers { get; set; } = new List<Trainer>();

    public virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
}
