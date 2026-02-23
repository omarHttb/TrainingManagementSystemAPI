using Application.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace TrainingManagementSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GradeController : ControllerBase 
    {
        private readonly IGradeService _GradeService;


         public GradeController(IGradeService GradeService)
         {
        
                    _GradeService = GradeService;
                
         }    
    }
}
