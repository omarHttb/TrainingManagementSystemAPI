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

        Task<List<Trainee>> GetAllTrainesWithPaginationUsingSP(int pageNumber, int pageSize);

        Task<Trainee> SeachTraineeByEmailOrNameUsingSP(string name = "", string email = "");

    }
}
