using Application.DTOS.TraineeDTOS;
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

        [HttpPost]
        public async Task<IActionResult> CreateTrainee(CreateTraineeDTO createTraineeDTO)
        {
            var result =  await _TraineeService.CreateTraineeUsingSP(createTraineeDTO);

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTraineesWithPagination(int pageNumber, int pageSize)
        {
            var result = await _TraineeService.GetAllTrainesWithPaginationUsingSP(pageNumber, pageSize);

            return Ok(result);
        }

        //[HttpGet("searchtrainee")]
        //public async Task <IActionResult> SearchTraineesByNameOrEmail(string fisrtName,string LastName , string Email)
        //{
        //    //var result = await _TraineeService.SeachTraineeByEmailOrNameUsingSP(fisrtName, LastName, Email);

        //    return Ok(result);
        //}
    }
}
