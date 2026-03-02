using Application;
using Application.DTOS;
using Application.DTOS.UsersDTOS;
using Application.RepositoryInterfaces;
using Application.ServiceInterfaces;
using Application.Services;
using Application.Validators;
using FluentValidation;
using Infastructure;
using Infastructure.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;

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
            services.AddScoped<IQuizzService, QuizzService>();
            services.AddScoped<IUserRepository, UserRepository>();



            return services;
        }

        public static IServiceCollection AddValidatorsFromAssemblies(this IServiceCollection services)
        {

            services.AddValidatorsFromAssemblyContaining<AddTraineeGradeValidatorDTO>();
            services.AddValidatorsFromAssemblyContaining<AttendanceDTOValidator>();
            services.AddValidatorsFromAssemblyContaining<CreateCourseDTOValidator>();
            services.AddValidatorsFromAssemblyContaining<EnrollmentDTOValidator>();
            services.AddValidatorsFromAssemblyContaining<UpdateCourseValidatorDTO>();
            services.AddValidatorsFromAssemblyContaining<RegisterUserValidator>();  
            services.AddValidatorsFromAssemblyContaining<LoginDTO>();

            return services;
        }

        public static IServiceCollection AddSwaggerGenWithAuth(this IServiceCollection services)
        {
            services.AddSwaggerGen(o =>
            {
                var securityScheme = new OpenApiSecurityScheme
                {
                    Name = "JWT Authentication",
                    Description = "Enter your jwt token in this field",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = JwtBearerDefaults.AuthenticationScheme,
                    BearerFormat = "JWT"
                    
                };

                o.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, securityScheme);

                var securityRequirement = new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference= new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = JwtBearerDefaults.AuthenticationScheme
                            }
                        },[]
                    }
                };
                o.AddSecurityRequirement(securityRequirement);
            });

            return services;
        }
    }
}