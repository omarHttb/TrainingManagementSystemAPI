using Application.DTOS;
using Application.DTOS.AttendanceDTOS;
using Application.DTOS.EnrollmensDTOS;
using Application.DTOS.GradesDTOS;
using Application.DTOS.TrainersDTOS;
using AutoMapper;
using Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOS.UsersDTOS;

namespace Application.Mapping
{
    public class MappingProfile : Profile
    {
   
        public MappingProfile() 
        {
            CreateMap<CreateCourseDTO, Course>();

            CreateMap<UpdateCourseDTO, Course>()
             .ForAllMembers(opt =>
                opt.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<User, UsersDTO>()
      .ForMember(dest => dest.FullName,
              opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}")).ForMember(
                dest => dest.age, opt => opt.MapFrom(src => CalculateAge(src.DateOfBirth))
                );


            CreateMap<CreateEnrollmentDTO, Enrollment>();

            CreateMap<AddTraineeGradeDTO,Grade>();

            CreateMap<RegisterUserDTO, User>();


            CreateMap<CreateTrainerDTO, Trainer>();

            CreateMap<CreateAttendanceDTO, Attendence>();

            CreateMap<UpdateTrainerDTO, Trainer>();

            CreateMap<UpdateUserDTO, User>();
        }
        private static int CalculateAge(DateOnly dob)
        {
            var today = DateOnly.FromDateTime(DateTime.Today);
            var age = today.Year - dob.Year;

            // Adjust if the birthday hasn't happened yet this year
            if (dob > today.AddYears(-age))
                age--;

            return age;
        }
    }
}
