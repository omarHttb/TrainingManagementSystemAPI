using Application.DTOS.AttendanceDTOS;
using Application.DTOS.UsersDTOS;
using Application.Models;
using Application.ServiceInterfaces;
using AutoMapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;
        private readonly IValidator<RegisterUserDTO> _RegisterUserValidator;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper , IValidator<RegisterUserDTO> RegisterUserValidator) 
        {
            _mapper = mapper;
            _UnitOfWork = unitOfWork;
            _RegisterUserValidator = RegisterUserValidator;
        }    

        public async Task<bool> RegisterNewUser(RegisterUserDTO registerUserDTO)
        {
            await _RegisterUserValidator.ValidateAndThrowAsync(registerUserDTO);

            registerUserDTO.PasswordHash = BCrypt.Net.BCrypt.HashPassword(registerUserDTO.PasswordHash);

            var user = _mapper.Map<User>(registerUserDTO);

            var result = await _UnitOfWork.UserRepository.RegisterUserUsingSP(user);

            await _UnitOfWork.CompleteAsync();

            return result;

        }
    }
}
