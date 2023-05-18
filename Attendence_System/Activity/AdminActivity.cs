using Attendence_System.Entities;
using Attendence_System.utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attendence_System.Activity
{
    public class AdminActivity
    {   
     
        public AdminActivity()
        {

            TrainingDbContext context = new TrainingDbContext();

           
            Console.WriteLine("press 1 to add Teacher");
            Console.WriteLine("press 2 to add student");
            Console.WriteLine("press 3 to create courses ");
            Console.WriteLine("press 4 to assign a teacher in a course ");
            Console.WriteLine("press 5 assign students in a course ");
            Console.WriteLine("press 6 set schedule a course ");
            Console.WriteLine("press 0 to logout");

          

            int input = Convert.ToInt32(Console.ReadLine());

            if (input == 0)
            {

                    Home home = new Home();


            }

            else if (input == 1)
            {
                AddUser addTeacher = new AddUser();
                addTeacher.plusUser("Teacher", context);

            }
             

           else if (input == 2)
            {
                AddUser addStudent = new AddUser();
                addStudent.plusUser("Student", context);
               

            }
               
            else if (input == 3)
            {
                AddCourse addCourse = new AddCourse();
                addCourse.plusCourse(context);
            }
            else if (input == 4)
            {
                Registration TRegistration = new Registration();
                TRegistration.plusReg("Teacher", context);
            }

            else if (input == 5)
            {
                Registration SRegistration = new Registration();
                SRegistration.plusReg("Student",context);
            }
            else if (input == 6)
            {
                AddSchedule addSchedule = new AddSchedule();
                addSchedule.plusSchedule(context);

                
            }
            else
            {

                Console.WriteLine("please enter number between 0-6");
               
               
            }


        }


    }
}
