using Application.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace TrainingManagementSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TraineeController : ControllerBase 
    {
        private readonly ITraineeService _TraineeService;


         public TraineeController(ITraineeService TraineeService)
         {

            _TraineeService = TraineeService;
         }    
    }
}
