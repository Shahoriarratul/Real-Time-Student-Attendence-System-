using Attendence_System.Activity;
using Attendence_System.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attendence_System.utility
{
    public class AddSchedule
    {
        public void plusSchedule(TrainingDbContext context)
        {
            Console.WriteLine("List of available courses");
            List<Course> courses = context.Courses.ToList();
            foreach (var c in courses)
            {
                Console.WriteLine($"ID:{c.Id} Name:{c.CourseName}");
            }

            Console.WriteLine("Enter Course Name :");
            string CourseName = Console.ReadLine();

            Course C1 = context.Courses.Where(c => c.CourseName == CourseName).FirstOrDefault();

            if (C1 != null)
            {
                Console.WriteLine(" Number of classes");

                int ClassNumber = Convert.ToInt32(Console.ReadLine());
                C1.Totalclass = ClassNumber;

                Console.WriteLine("Class Starting Date Example: 01/11/2022");

                string ClassStart = Console.ReadLine();
                C1.ClssStartTime = ClassStart;


                Console.WriteLine("How many classes every week (Maximum 3 classes)");
                int i = Convert.ToInt32(Console.ReadLine());

                if (i == 1)
                {
                    Console.WriteLine("Calss day Example: Friday ");
                    string ClassDay1 = Console.ReadLine();
                    Console.WriteLine("Calss Time Example: 08:30 PM to 11:30 PM ");
                    string ClassTime1 = Console.ReadLine();
                    C1.FirstClssDay = ClassDay1;
                    C1.FirstClssTime = ClassTime1;

                }
                else if (i == 2)
                {
                    Console.WriteLine("1st calss day Example: Friday ");
                    string ClassDay1 = Console.ReadLine();
                    Console.WriteLine("1st calss Time Example: 08:30 PM to 11:30 PM ");
                    string ClassTime1 = Console.ReadLine();
                    Console.WriteLine("2nd calss day Example: Friday ");
                    string ClassDay2 = Console.ReadLine();
                    Console.WriteLine("2nd calss Time Example: 08:30 PM to 11:30 PM ");
                    string ClassTime2 = Console.ReadLine();
                    C1.FirstClssDay = ClassDay1;
                    C1.FirstClssTime = ClassTime1;
                    C1.SecondClssDay = ClassDay2;
                    C1.SecondClassTime = ClassTime2;


                }
                else if (i == 3)
                {
                    Console.WriteLine("1st calss day Example: Friday ");
                    string ClassDay1 = Console.ReadLine();
                    Console.WriteLine("1st calss Time Example: 08:30 PM to 11:30 PM ");
                    string ClassTime1 = Console.ReadLine();
                    Console.WriteLine("2nd calss day \n");
                    string ClassDay2 = Console.ReadLine();
                    Console.WriteLine("2nd calss Time Example: 08:30 PM to 11:30 PM ");
                    string ClassTime2 = Console.ReadLine();
                    Console.WriteLine("3rd calss day \n");
                    string ClassDay3 = Console.ReadLine();
                    Console.WriteLine("2nd calss Time Example: 08:30 PM to 11:30 PM ");
                    string ClassTime3 = Console.ReadLine();
                    C1.FirstClssDay = ClassDay1;
                    C1.FirstClssTime = ClassTime1;
                    C1.SecondClssDay = ClassDay2;
                    C1.SecondClassTime = ClassTime2;
                    C1.ThirdClssDay = ClassDay3;
                    C1.ThirdClassTime = ClassTime3;

                }
                else
                {
                    Console.WriteLine("wrong input please enter number between 1-3");
                    AddSchedule ad = new AddSchedule();
                    ad.plusSchedule(context);
                }

                context.SaveChanges();
                Console.Write($"Schedule added for {C1.CourseName} \n");
                AdminActivity adminActivity = new AdminActivity();


            }
            else
            {
                Console.Write("Wrong course name \n");
                AddSchedule ad = new AddSchedule();
                ad.plusSchedule(context);
            }


        }
    }
}
