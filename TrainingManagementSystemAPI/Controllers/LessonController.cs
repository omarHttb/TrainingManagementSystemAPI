using Application.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace TrainingManagementSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LessonController : ControllerBase 
    {
        private readonly ILessonService _LessonService;


        public LessonController(ILessonService LessonService)
        {

            _LessonService = LessonService;
        }    
    }
}
