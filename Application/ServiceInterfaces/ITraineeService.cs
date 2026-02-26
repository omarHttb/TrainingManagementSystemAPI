using Application.DTOS.TraineeDTOS;
using Application.DTOS.TraineesDTOS;
using Application.Models;

namespace Application.ServiceInterfaces
{
    public interface ITraineeService
    {
        Task<bool> CreateTraineeUsingSP(CreateTraineeDTO trainee);


        //Task<bool> DeleteTraineeUsingSP(int id);

        Task<List<TraineeDetailsDTO>> GetAllTrainesWithPaginationUsingSP(int pageNumber, int pageSize);

        //Task<List<TraineeDetailsDTO>> SeachTraineeByEmailOrNameUsingSP(string FirstName = "", string LastName = "", string email = "");
    }
}
