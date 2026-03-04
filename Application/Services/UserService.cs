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
        private readonly IValidator<UpdateUserDTO> _UpdateUserValidator;


        public UserService(IUnitOfWork unitOfWork, IMapper mapper , IValidator<RegisterUserDTO> RegisterUserValidator,
            IValidator<LoginDTO> LoginValidator, IValidator<UpdateUserDTO> UpdateUserValidator) 
        {
            _mapper = mapper;
            _UnitOfWork = unitOfWork;
            _RegisterUserValidator = RegisterUserValidator;
            _LoginValidator = LoginValidator;
            _UpdateUserValidator = UpdateUserValidator;
        }

        public async Task<List<UsersDTO>> GetUsersByRolesUsingSP(int RoleId)
        {
            return await _UnitOfWork.UserRepository.GetUsersByRolesUsingSP(RoleId);
        }

        public async Task<LoginDTO> LoginUserUsingSP(LoginDTO loginDTO)
        {
           await _LoginValidator.ValidateAndThrowAsync(loginDTO);

            var userLoginDTO = await _UnitOfWork.UserRepository.LoginUsingSP(loginDTO.Email, loginDTO.Password);

            if (userLoginDTO == null) 
            {
                loginDTO.Password = BCrypt.Net.BCrypt.HashPassword(loginDTO.Password);
                userLoginDTO = await _UnitOfWork.UserRepository.LoginUsingSP(loginDTO.Email, loginDTO.Password);
            }

            if (userLoginDTO == null) 
            {
                return new LoginDTO();
            }

            userLoginDTO.Roles = await _UnitOfWork.UserRepository.GetUserRolesUsingSP(userLoginDTO.Id);

            return userLoginDTO;
            
        }

        public async Task<bool> RegisterNewUserUsingSP(RegisterUserDTO registerUserDTO)
        {
            await _RegisterUserValidator.ValidateAndThrowAsync(registerUserDTO);

            registerUserDTO.PasswordHash = BCrypt.Net.BCrypt.HashPassword(registerUserDTO.PasswordHash);

            var user = _mapper.Map<User>(registerUserDTO);

            var result = await _UnitOfWork.UserRepository.RegisterUserUsingSP(user);


            return result;

        }

        public async Task<bool> UpdateUserUsingSP(UpdateUserDTO updateUserDTO)
        {
            var existingUser = await _UnitOfWork.UserRepository.GetByIdAsync(updateUserDTO.Id);

            if(existingUser == null)
            {
                throw new ArgumentException("User with the Id does not exist");
            }
             await _UpdateUserValidator.ValidateAndThrowAsync(updateUserDTO);


            var user = _mapper.Map<User>(updateUserDTO);

            var result = await _UnitOfWork.UserRepository.UpdateUserUsingSP(user);


            return result;


        }
    }
}
