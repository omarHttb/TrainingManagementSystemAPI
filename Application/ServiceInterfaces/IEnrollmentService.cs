
using Application.Models;

namespace Application.ServiceInterfaces
{
    public interface IEnrollmentService
    {
        Task<bool> EnrollTraineeIntoACourseUsingSp(Enrollment enrollment);
    }
}
