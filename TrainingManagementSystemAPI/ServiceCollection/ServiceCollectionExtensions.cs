using Application;
using Application.DTOS;
using Application.RepositoryInterfaces;
using Application.ServiceInterfaces;
using Application.Services;
using Application.Validators;
using FluentValidation;
using Infastructure;
using Infastructure.Repositories;

namespace TrainingManagementSystemAPI.ServiceCollection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IAttendenceService, AttendenceService>();
            services.AddScoped<ICourseService, CourseService>();
            services.AddScoped<IEnrollmentService, EnrollmentService>();
            services.AddScoped<IGradeService, GradeService>();
            services.AddScoped<ILessonService, LessonService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<ITrainerService, TrainerService>();
            services.AddScoped<IUserRoleService, UserRoleService>();
            services.AddScoped<IUserService, UserService>();


            return services;
        }

        public static IServiceCollection AddValidatorsFromAssemblies(this IServiceCollection services)
        {

            services.AddValidatorsFromAssemblyContaining<AddTraineeGradeValidatorDTO>();
            services.AddValidatorsFromAssemblyContaining<AttendanceDTOValidator>();
            services.AddValidatorsFromAssemblyContaining<CreateCourseDTOValidator>();
            services.AddValidatorsFromAssemblyContaining<EnrollmentDTOValidator>();
            services.AddValidatorsFromAssemblyContaining<UpdateCourseValidatorDTO>();

            return services;
        }
    }
}