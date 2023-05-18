using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace Attendence_System.Entities
{
    public class Course
    {
        public int Id { get; set; }
        public string CourseName { get; set; }
        public int fees { get; set; }       
        public string FirstClssDay { get; set; }
        public string FirstClssTime { get; set; }
        public string SecondClssDay { get; set; }
        public string SecondClassTime { get; set; }
        public string ThirdClssDay { get; set; }
        public string ThirdClassTime { get; set; }
        public string ClssStartTime { get; set; }
        public int Totalclass { get; set; }

        public int TeacherID { get; set; }

        public List<CourseRegistration> CourseStudents { get; set; }

        public List<Attendence> StudentAttendence { get; set; }



    }
}
