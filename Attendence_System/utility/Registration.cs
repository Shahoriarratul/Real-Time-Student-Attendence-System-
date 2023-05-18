using Attendence_System.Activity;
using Attendence_System.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Attendence_System.utility
{
    public class Registration
    {
        public void plusReg(string type ,TrainingDbContext context)
        {
            if (type == "Teacher")
            {

                Console.WriteLine("Teachers name with Id");

                List <Teacher> teacher = context.Teachers.ToList();
                foreach (var t in teacher)
                {
                    Console.WriteLine($"ID:{t.id} Name:{t.Name}");
                }

                Console.Write("Enter Teacher Name :");
                string TeacherName = Console.ReadLine();
                Console.Write("Enter Teacher ID :");
                int TeacherId = Convert.ToInt32(Console.ReadLine());
                Teacher T1 = context.Teachers.Where(x => x.Name == TeacherName &&  x.id == TeacherId).FirstOrDefault();
                if (T1 != null)
                {
                    Console.WriteLine("Available courses ");
                    List<Course> courseList = context.Courses.ToList();

                    foreach (var item in courseList)
                    {


                        Console.WriteLine($"ID:{item.Id} Course Name:{item.CourseName}");

                    }
                    Console.Write("Enter course Name :");
                    string CourseName = Console.ReadLine();

                    Course C1 = context.Courses.Where(x => x.CourseName == CourseName).FirstOrDefault();
                    if (C1 != null)
                    {
                        C1.TeacherID = T1.id;
                        context.SaveChanges();
                        Console.Write("Teacher assinged \n");
                        AdminActivity adminActivity = new AdminActivity();
                    }
                    else
                    {
                        Console.WriteLine("course does not exist");
                        Registration registration = new Registration();
                        registration.plusReg(type, context);
                    }
                }
                else
                {
                    Console.WriteLine("There is no teacher by this name or id");
                    Registration registration = new Registration();
                    registration.plusReg(type, context);

                }


            }

            else if (type == "Student")
            {
                Console.WriteLine("Students name with Id");

                List<Student> students = context.Students.ToList();

                foreach(var s in students)
                {
                    Console.WriteLine($"ID:{s.Id} Name:{s.Name}");
                }

                Console.Write("Enter Student Name :");
                string StudentName = Console.ReadLine();
                Console.Write("Enter Student Id :");
                int Sid =  Convert.ToInt32(Console.ReadLine());

                Student S1 = context.Students.Where(x => x.Name == StudentName && x.Id == Sid).FirstOrDefault();
                if (S1 != null)
                {
                    Console.WriteLine("Available courses ");
                    List<Course> courseList = context.Courses.ToList();

                    foreach (var item in courseList)
                    {


                        Console.WriteLine($"ID:{item.Id} Course Name:{item.CourseName}");

                    }
                    Console.Write("Enter course Name :");
                    string CourseName = Console.ReadLine();

                    Course C1 = context.Courses.Where(x => x.CourseName == CourseName).FirstOrDefault();
                    if (C1 != null)
                    {
                        CourseRegistration Registration = new CourseRegistration();

                        Registration.StudentId = S1.Id;
                        Registration.CourseId = C1.Id;
                        context.Add(Registration);
                        context.SaveChanges();
                        Console.Write("Student assinged \n");
                        AdminActivity adminActivity = new AdminActivity();
                    }
                    else
                    {
                        Console.WriteLine("There is no course by this name");
                        Registration registration = new Registration();
                        registration.plusReg(type, context);
                    }
                }
                else
                {
                    Console.WriteLine("There is no student by this name");
                    Registration registration = new Registration();
                    registration.plusReg(type, context);
                }

            }
        }
    }
}
