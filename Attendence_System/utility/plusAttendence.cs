using Attendence_System.Activity;
using Attendence_System.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attendence_System.utility
{
    public class plusAttendence
    {
        public void GiveAttendence(int Studentid, string Studentname ,TrainingDbContext context)
        {
            CultureInfo provider = CultureInfo.InvariantCulture;
            Console.WriteLine("\nTo give attendence type Id of your enrolled course and press 0 to Logout ");
            int CourseId = Convert.ToInt32(Console.ReadLine());

            if (CourseId != 0)
            {
                Course C1 = context.Courses.Where(c => c.Id == CourseId).FirstOrDefault();

                if (C1 != null)
                {

                    DateTime today = DateTime.Now;

                    string date = today.ToString("dddd", provider);
                    string format1 = "h:mm tt";



                    if (date == C1.FirstClssDay)
                    {
                        string s = C1.FirstClssTime;
                        string[] str = s.Split(' ');


                        DateTime start = DateTime.ParseExact(($"{str[0]} {str[1]}"), format1, provider);
                        DateTime end = DateTime.ParseExact(($"{str[3]} {str[4]}"), format1, provider);
                        DateTime now = DateTime.Now;

                        if ((now > start) && (now < end))
                        {
                            Attendence attendence = new Attendence();
                            attendence.StudentId = Studentid;
                            attendence.studentName = Studentname;
                            attendence.CourseID = CourseId;
                            string atDate = today.ToString("dd/MM/yyyy ddd");

                            attendence.Date = atDate;
                            context.Add(attendence);

                            context.SaveChanges();
                            Console.WriteLine(DateTime.Now);
                            Console.WriteLine("attendence taken \n");

                            StudentActivity studentActivity = new StudentActivity(Studentid);

                        }
                        else
                        {
                            Console.WriteLine(DateTime.Now);
                            Console.WriteLine("class date and time dont match");
                            StudentActivity studentActivity = new StudentActivity(Studentid);
                        }

                    }


                    else if (date == C1.SecondClssDay)
                    {
                        string s = C1.SecondClassTime;
                        string[] str = s.Split(' ');


                        DateTime start = DateTime.ParseExact(($"{str[0]} {str[1]}"), format1, provider);
                        DateTime end = DateTime.ParseExact(($"{str[3]} {str[4]}"), format1, provider);
                        DateTime now = DateTime.Now;

                        if ((now > start) && (now < end))
                        {
                            Attendence attendence = new Attendence();
                            attendence.StudentId = Studentid;
                            attendence.studentName = Studentname;
                            attendence.CourseID = CourseId;
                            string atDate = today.ToString("dd/MM/yyyy ddd");
                            attendence.Date = atDate;

                            context.Add(attendence);

                            context.SaveChanges();
                            Console.WriteLine(DateTime.Now);
                            Console.WriteLine("attendence taken \n");
                            StudentActivity studentActivity = new StudentActivity(Studentid);
                        }
                        else
                        {
                            Console.WriteLine(DateTime.Now);
                            Console.WriteLine("class date and time dont match");
                            StudentActivity studentActivity = new StudentActivity(Studentid);
                        }

                    }
                    else if (date == C1.ThirdClssDay)
                    {
                        string s = C1.ThirdClassTime;
                        string[] str = s.Split(' ');


                        DateTime start = DateTime.ParseExact(($"{str[0]} {str[1]}"), format1, provider);
                        DateTime end = DateTime.ParseExact(($"{str[3]} {str[4]}"), format1, provider);
                        DateTime now = DateTime.Now;
                      

                        if ((now > start) && (now < end))
                        {
                            Attendence attendence = new Attendence();
                            attendence.StudentId = Studentid;
                            attendence.studentName = Studentname;
                            attendence.CourseID = CourseId;
                            string atDate = today.ToString("dd/MM/yyyy ddd");
                            attendence.Date = atDate;

                            context.Add(attendence);

                            context.SaveChanges();
                            Console.WriteLine(DateTime.Now);
                            Console.WriteLine("attendence taken \n");
                            StudentActivity studentActivity = new StudentActivity(Studentid);
                        }
                        else
                        {
                            Console.WriteLine(DateTime.Now);
                            Console.WriteLine("class date and time dont match");
                            StudentActivity studentActivity = new StudentActivity(Studentid);
                        }



                    }
                    else
                    {
                        Console.WriteLine(DateTime.Now);
                        Console.WriteLine("class date and time dont match");
                        StudentActivity studentActivity = new StudentActivity(Studentid);
                    }


                }
                else
                {
                    Console.WriteLine("wrong input. try again");
                    plusAttendence p1 = new plusAttendence();
                    p1.GiveAttendence(Studentid, Studentname, context);

                }



            }
            else
            {
               
                Home home = new Home();

            }
  





            




        }
      
    }

    
}
