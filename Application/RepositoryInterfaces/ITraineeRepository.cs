using Application.DTOS;
using Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.RepositoryInterfaces
{
    public interface ITraineeRepository : IBaseRepository<Trainee>
    {
        Task<bool> CreateTraineeUsingSP(Trainee trainee);

        Task<bool> UpdateTraineeUsingSP(Trainee trainee , int Id);

        Task<bool> DeleteTraineeUsingSP(int id);

        Task<List<TraineeDetailsDTO>> GetAllTrainesWithPaginationUsingSP(int pageNumber, int pageSize);

        Task<TraineeDetailsDTO> SeachTraineeByEmailOrNameUsingSP(string name = "", string email = "");

    }
}
