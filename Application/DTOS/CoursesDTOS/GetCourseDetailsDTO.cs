using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOS.CoursesDTOS
{
    public class GetCourseDetailsDTO
    {
        public int Id { get; set; }
        public string CourseTitle { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public DateTime CreationDate { get; set; }
        public int Capacity { get; set; }
        public string TrainerName { get; set; } = string.Empty;
        public string TeachingSubject { get; set; } = string.Empty;
    }
}
