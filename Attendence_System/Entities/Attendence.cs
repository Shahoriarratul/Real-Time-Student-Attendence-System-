using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attendence_System.Entities
{
    public class Attendence
    {
        public int Id { get; set; }

        public int StudentId { get; set; }
        public string studentName { get; set; }
        public string Date { get; set; }

        public int CourseID { get; set; }
        public Course Course { get; set; }

    }
}
