using Application.DTOS.TraineeDTOS;
using Application.DTOS.TraineesDTOS;
using Application.Models;
using Application.ServiceInterfaces;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class TraineeService : ITraineeService
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;
        public TraineeService(IUnitOfWork unitOfWork, IMapper mapper) 
        {
            _UnitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> CreateTraineeUsingSP(CreateTraineeDTO traineeDTO)
        {
            var course = _mapper.Map<Trainee>(traineeDTO);

            var result = await _UnitOfWork.TraineeRepository.CreateTraineeUsingSP(course);   

            await _UnitOfWork.CompleteAsync();

            return result;
        }

        //public async Task<bool> DeleteTraineeUsingSP(int id)
        //{
        //    var result = await _UnitOfWork.TraineeRepository.DeleteTraineeUsingSP(id);

        //    return result;
        //}

        public Task<List<TraineeDetailsDTO>> GetAllTrainesWithPaginationUsingSP(int pageNumber, int pageSize)
        {
            return _UnitOfWork.TraineeRepository.GetAllTrainesWithPaginationUsingSP(pageNumber, pageSize);
        }

        //public Task<List<TraineeDetailsDTO>> SeachTraineeByEmailOrNameUsingSP(string FirstName = "", string LastName = "", string email = "")
        //{
        //    return _UnitOfWork.TraineeRepository.SeachTraineeByEmailOrNameUsingSP(FirstName, LastName,email);
        //}


    }
}
