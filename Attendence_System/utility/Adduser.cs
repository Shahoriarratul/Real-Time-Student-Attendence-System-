using Attendence_System.Activity;
using Attendence_System.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attendence_System.utility
{
    public class AddUser
    {
       public void plusUser(string type, TrainingDbContext context)
        {
            Console.Write("Enter Name :");
            string Name = Console.ReadLine();
            Console.Write("Enter username :");
            string username = Console.ReadLine();
            Console.Write("Enter password :");
            string password = Console.ReadLine();

            User newUser = new User();
            newUser.Name = Name;
            newUser.UserName = username;
            newUser.password = password;

     


            if (type == "Teacher")
            {
                newUser.userType = 1;

                Teacher newT = new Teacher();
                newT.Name = Name;
                context.Add(newT);
                context.Add(newUser);
                context.SaveChanges();
                Console.Write("Teacher added \n");
                AdminActivity adminActivity = new AdminActivity();

            }
               
                    
                    
            else if (type == "Student")
            {
                newUser.userType = 2;
                Student newS = new Student();
                newS.Name = Name;
                context.Add(newS);
                context.Add(newUser);
                context.SaveChanges();
                Console.Write("Student added \n");
                AdminActivity adminActivity = new AdminActivity();
            }
               
      

           



        }
    }
}
