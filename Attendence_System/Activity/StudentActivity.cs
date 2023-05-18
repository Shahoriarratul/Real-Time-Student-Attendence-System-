using Attendence_System.Entities;
using Attendence_System.Migrations;
using Attendence_System.utility;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attendence_System.Activity
{
    public class StudentActivity
    {
        public StudentActivity(int id)
        {
        
            TrainingDbContext context = new TrainingDbContext();

            Student student = context.Students.Where(x => x.Id == id)
              .Include(x => x.StudentCourses)
              .FirstOrDefault();

            Console.WriteLine($"Welcome {student.Name}");
            Console.WriteLine("\nEnrolled courses with CourseID ");
            if (student.StudentCourses.Count > 0)
            {


                foreach (var item in student.StudentCourses)
                {
                    Course course = context.Courses.Where(x => x.Id == item.CourseId).FirstOrDefault();

                    Console.WriteLine($"ID:{item.CourseId} Course Name:{course.CourseName}");

                }


                plusAttendence attendence = new plusAttendence();
                attendence.GiveAttendence(student.Id, student.Name, context);

            }
            else
            {
                Console.WriteLine("You are not enrolled in any courses");
                Home home = new Home();
            }




        }
    }
}
