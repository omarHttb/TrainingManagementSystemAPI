using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOS.CoursesDTOS
{
    public class GetCoursesDTO
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = null!;

        public decimal Price { get; set; }

        public DateTime CreationDate { get; set; }

        public int TrainerId { get; set; }

        public int Capacity { get; set; }

        public int StudentsRolledIn { get; set; }



    }
}
