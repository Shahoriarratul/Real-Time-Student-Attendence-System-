using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attendence_System.Entities
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<CourseRegistration> StudentCourses { get; set; }
    }
}
