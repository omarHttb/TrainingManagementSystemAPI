using Application.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public interface IUnitOfWork : IDisposable
    {
        IAttendenceRepository AttendenceRepository { get; }

        ICourseRepository CourseRepository { get; }

        IEnrollmentRepository EnrollmentRepository { get; }

        IGradeRepository GradeRepository { get; }

        IRoleRepository RoleRepository { get; }

        ITraineeRepository TraineeRepository { get; }

        ITrainerRepository TrainerRepository { get; }

        IUserRepository UserRepository { get; }

        IUserRoleRepository UserRoleRepository { get; }

        int Complete();
    }
}
