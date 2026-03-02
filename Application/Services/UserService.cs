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
        private readonly IValidator<LoginDTO> _LoginValidator;
        

        public UserService(IUnitOfWork unitOfWork, IMapper mapper , IValidator<RegisterUserDTO> RegisterUserValidator,
            IValidator<LoginDTO> LoginValidator) 
        {
            _mapper = mapper;
            _UnitOfWork = unitOfWork;
            _RegisterUserValidator = RegisterUserValidator;
            _LoginValidator = LoginValidator;
        }

        public async Task<LoginDTO> LoginUser(LoginDTO loginDTO)
        {
           await _LoginValidator.ValidateAndThrowAsync(loginDTO);

            var userLoginDTO = await _UnitOfWork.UserRepository.Login(loginDTO.Email, loginDTO.Password);

            if (userLoginDTO == null) 
            {
                loginDTO.Password = BCrypt.Net.BCrypt.HashPassword(loginDTO.Password);
                userLoginDTO = await _UnitOfWork.UserRepository.Login(loginDTO.Email, loginDTO.Password);
            }

            if (userLoginDTO == null) 
            {
                return new LoginDTO();
            }

            userLoginDTO.Roles = await _UnitOfWork.UserRepository.GetUserRoles(userLoginDTO.Id);

            return userLoginDTO;
            
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
