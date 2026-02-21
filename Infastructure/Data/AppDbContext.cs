using Application.DTOS;
using Application.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Infastructure.Data;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Attendence> Attendences { get; set; }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<Enrollment> Enrollments { get; set; }

    public virtual DbSet<Grade> Grades { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Trainee> Trainees { get; set; }

    public virtual DbSet<Trainer> Trainers { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserRole> UserRoles { get; set; }

    public virtual DbSet<Lessons> Lessons { get; set; }

    public DbSet<GetCourseDetailsDTO> getCourseDetailsDTO { get; set; }
    public DbSet<GetAllCoursesTraineesDTO> getAllCoursesTraineesDTO { get; set; }
    public DbSet<GetAttendanceReportPerCourseDTO> getAttendanceReportPerCourseDTO { get; set; }
    public DbSet<AverageGradeForCourseDTO> AverageGradeForCourseDTO { get; set; }
    public DbSet<TrainerWithDetailsDTO> TrainerWithDetailsDTO { get; set; }
    public DbSet<TraineeDetailsDTO> TraineeDetailsDTO { get; set; }

    

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {



        modelBuilder.Entity<Attendence>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Attenden__3214EC07944E5F8E");

            entity.ToTable("Attendence");

            entity.Property(e => e.AttendanceDate).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Enrollment).WithMany(p => p.Attendences)
                .HasForeignKey(d => d.EnrollmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Attendence_Enrollments");

            entity.HasOne(d => d.Lessons).WithMany(p => p.Attendences).
            HasForeignKey(d => d.LessonId)
            .OnDelete(DeleteBehavior.ClientSetNull).
            HasConstraintName("FK_Attendence_Lesson");
        });


        modelBuilder.Entity<Lessons>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.ToTable("Lessons");

            entity.HasOne(d => d.course).WithMany(p => p.Lessons)
            .HasForeignKey(d => d.CourseId).OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Lesson_Course");
        });

        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Courses__3214EC07CE5EA62B");

            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Title).HasMaxLength(50);

            entity.HasOne(d => d.Trainer).WithMany(p => p.Courses)
                .HasForeignKey(d => d.TrainerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Courses_Trainers");
        });

        modelBuilder.Entity<Enrollment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Enrollme__3214EC076D19D3C3");

            entity.HasIndex(e => new { e.CourseId, e.TraineeId }, "UQ_COURSE_TRAINEE").IsUnique();

            entity.Property(e => e.EnrollmentDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.Course).WithMany(p => p.Enrollments)
                .HasForeignKey(d => d.CourseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Erollments_Courses");

            entity.HasOne(d => d.Trainee).WithMany(p => p.Enrollments)
                .HasForeignKey(d => d.TraineeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Trainees_CourseSemester");
        });

        modelBuilder.Entity<Grade>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Grades__3214EC0731E85DB3");

            entity.Property(e => e.Grade1).HasColumnName("Grade");

            entity.HasOne(d => d.Enrollment).WithMany(p => p.Grades)
                .HasForeignKey(d => d.EnrollmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Grades_Enrollments");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Roles__3214EC070A8EE0B9");

            entity.HasIndex(e => e.RoleName, "UQ__Roles__8A2B61606EA3483F").IsUnique();

            entity.Property(e => e.RoleName).HasMaxLength(50);
        });

        modelBuilder.Entity<Trainee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Trainees__3214EC076D37624D");

            entity.Property(e => e.JoinDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.User).WithMany(p => p.Trainees)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Trainees_Users");
        });

        modelBuilder.Entity<Trainer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Trainers__3214EC07A5D57AF5");

            entity.Property(e => e.JoinDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.TeachingSubject).HasMaxLength(50);
            entity.Property(e => e.UserId).HasColumnName("userId");

            entity.HasOne(d => d.User).WithMany(p => p.Trainers)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Trainers_Users");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3214EC07CD7C93B1");

            entity.HasIndex(e => e.Email, "UQ__Users__A9D10534B5377010").IsUnique();

            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.Gender)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.PasswordHash).HasMaxLength(255);
            entity.Property(e => e.UserCreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<UserRole>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__UserRole__3214EC073E14292C");

            entity.HasIndex(e => new { e.UserId, e.RoleId }, "UQ_User_Role").IsUnique();

            entity.Property(e => e.RoleAssignDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.Role).WithMany(p => p.UserRoles)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserRoles_Roles");

            entity.HasOne(d => d.User).WithMany(p => p.UserRoles)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserRoles_Users");
        });
        
        modelBuilder.Entity<TraineeDetailsDTO>().HasNoKey();
        modelBuilder.Entity<GetCourseDetailsDTO>().HasNoKey();
        modelBuilder.Entity<GetAllCoursesTraineesDTO>().HasNoKey();
        modelBuilder.Entity<GetAttendanceReportPerCourseDTO>().HasNoKey();
        modelBuilder.Entity<AverageGradeForCourseDTO>().HasNoKey();
        modelBuilder.Entity<TrainerWithDetailsDTO>().HasNoKey();

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
