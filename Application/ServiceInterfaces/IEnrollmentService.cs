using Application.DTOS.EnrollmensDTOS;
using Application.Models;

namespace Application.ServiceInterfaces
{
    public interface IEnrollmentService
    {
        Task<bool> EnrollTraineeIntoACourseUsingSp(CreateEnrollmentDTO enrollment);
    }
}
