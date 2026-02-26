using Application.DTOS.TrainersDTOS;
using Application.ServiceInterfaces;
using Application.Services;
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


        [HttpPost]
        public async Task<IActionResult> CreateTrainer(CreateTrainerDTO createTrainerDTO)
        {
            var result = await _TrainersService.CreateTrainerUsingSP(createTrainerDTO);

            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteTrainer(int id)
        {
            var result = await _TrainersService.DeleteTrainerUsingSP(id);

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTrainers()
        {
            return Ok(await _TrainersService.GetAllTrainersUsingSP());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTrainerById(int id)
        {
            var result = await _TrainersService.GetTrainerByIdUsingSP(id);

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTrainerTeachingSubject(string TeachingSubject, int id)
        {
            var result = await _TrainersService.UpdateTrainerTeachingSubjectUsingSP(TeachingSubject, id);

            return Ok(result);
        }

    }
}
