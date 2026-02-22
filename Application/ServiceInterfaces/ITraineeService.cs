
using Application.DTOS;
using Application.Models;

namespace Application.ServiceInterfaces
{
    public interface ITraineeService
    {
        Task<bool> CreateTraineeUsingSP(Trainee trainee);

        Task<bool> UpdateTraineeUsingSP(Trainee trainee, int Id);

        Task<bool> DeleteTraineeUsingSP(int id);

        Task<List<TraineeDetailsDTO>> GetAllTrainesWithPaginationUsingSP(int pageNumber, int pageSize);

        Task<List<TraineeDetailsDTO>> SeachTraineeByEmailOrNameUsingSP(string FirstName = "", string LastName = "", string email = "");
    }
}
