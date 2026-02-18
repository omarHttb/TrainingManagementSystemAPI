using Application;
using Application.Models;
using Application.RepositoryInterfaces;
using Infastructure.Data;
using Infastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace Infastructure
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly AppDbContext _context;

        public IAttendenceRepository AttendenceRepository { get; private set; }

        public ICourseRepository CourseRepository { get; private set; }


        public IEnrollmentRepository EnrollmentRepository { get; private set; }

        public IGradeRepository GradeRepository { get; private set; }

        public IRoleRepository RoleRepository { get; private set; }

        public ITraineeRepository TraineeRepository { get; private set; }

        public ITrainerRepository TrainerRepository { get; private set; }

        public IUserRepository UserRepository { get; private set; }

        public IUserRoleRepository UserRoleRepository { get; private set; }


        public UnitOfWork(AppDbContext context)
        {
            _context = context;

            AttendenceRepository = new AttendenceRepository(_context);
            CourseRepository = new CourseRepository(_context);
            EnrollmentRepository = new EnrollmentRepository(_context);
            GradeRepository = new GradeRepository(_context);
            RoleRepository = new RoleRepository(_context);
            TraineeRepository = new TraineeRepository(_context);
            TrainerRepository = new TrainerRepository(_context);
            UserRepository = new UserRepository(_context);
            UserRoleRepository = new UserRoleRepository(_context);
        }


        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
