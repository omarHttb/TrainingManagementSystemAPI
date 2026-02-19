using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOS
{
    public class GetCourseDetailsDTO
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public DateTime CreationDate { get; set; }
        public int Capacity { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string TeachingSubject { get; set; } = string.Empty;
    }
}
