using Application.DTOS;
using Application.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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


            CreateMap<CreateEnrollmentDTO, Enrollment>();

            CreateMap<AddTraineeGradeDTO,Grade>();

            CreateMap<CreateTraineeDTO, Trainee>();

            CreateMap<CreateTrainerDTO, Trainer>();
        } 
    }
}
