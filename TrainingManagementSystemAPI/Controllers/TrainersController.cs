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
        public async Task<IActionResult> UpdateTrainer(UpdateTrainerDTO updateTrainerDTO, int id)
        {
            var result = await _TrainersService.UpdateTrainerUsingSP(updateTrainerDTO, id);

            return Ok(result);
        }

        [HttpPatch("activate")]
        public async Task<IActionResult> ActivateTrainer(int trainerId, bool isActive)
        {
            var result = await _TrainersService.SetActivateTrainerUsingSP(trainerId, isActive);

            return Ok("Activation Proccess Completed");
        }

        [HttpPatch("verify")]
        public async Task<IActionResult> VerifyCourse(int trainerId, int verifiedById, bool isVerfie)
        {
            var result = await _TrainersService.SetVerifyTrainerUsingSP(trainerId, isVerfie, verifiedById);

            return Ok("Verification Proccess Completed");
        }
    }
}
