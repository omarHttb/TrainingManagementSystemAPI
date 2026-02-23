using Application.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace TrainingManagementSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainersController : ControllerBase 
    {
        private readonly ITrainerService _TrainersService;


        public TrainersController(ITrainerService TrainersService)
        {

            _TrainersService = TrainersService;
        }    
    }
}
