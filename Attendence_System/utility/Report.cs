using Attendence_System.Activity;
using Attendence_System.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace Attendence_System.utility
{
    public class Report
    {
        public void ShowReport (TrainingDbContext context)
        {
            CultureInfo provider = CultureInfo.InvariantCulture;
            int i = 0;
            Console.WriteLine("To see Report of individual course type Course Id, press 0 to logout ");
            int CourseId = Convert.ToInt32(Console.ReadLine());

            if (CourseId != 0)
            {
                Course C1 = context.Courses.Where(c => c.Id == CourseId)
                    .Include(x => x.CourseStudents)
                    .Include(y => y.StudentAttendence)
                    .FirstOrDefault();
                bool flag = false;

                string save = "";
                List<string> dates = new List<string>();

                string day = C1.ClssStartTime;
                string format1 = "dd/MM/yyyy";

                DateTime result1 = DateTime.ParseExact(day, format1, provider);

                string COM1 = result1.ToString("dddd", provider);

                string COM2 = C1.FirstClssDay;
                string COM3 = C1.SecondClssDay;
                string COM4 = C1.ThirdClssDay;
                string space = " ";
                Console.Write("{0,30}", space);
                while (i < C1.Totalclass)
                {
                    COM1 = result1.ToString("dddd", provider);
                    if (COM2 == COM1 || COM3 == COM1 || COM4 == COM1)
                    {
                        save = result1.ToString("dd/MM/yyyy ddd", provider);
                        Console.Write("|{0,10}|", save);
                        dates.Add(save);
                        i++;
                    }
                    result1 = result1.AddDays(1);
                }
                foreach (var item in C1.CourseStudents)
                {
                    Student student = context.Students.Where(x => x.Id == item.StudentId).FirstOrDefault();

                    Console.Write("\n Name:{0,15} Id.{1,2} ", student.Name, item.StudentId);


                    foreach (string date in dates)
                    {
                        flag = false;


                        foreach (var atDate in C1.StudentAttendence)
                        {

                            if (student.Name == atDate.studentName && date == atDate.Date)
                            {

                                flag = true;
                                continue;
                            }
                            else
                            {

                                continue;
                            }
                        }
                        string LblTick = ((char)0x221A).ToString();
                        string cross = "x";
                        if (flag)
                            Console.Write("{0,10}      ", LblTick);
                        else Console.Write("{0,10}      ", cross);
                    }



                }

                Console.WriteLine();
                Report report = new Report();
                report.ShowReport(context);


            }
            else
            {

                    Home home = new Home();

                

            }
        }
    }
}
