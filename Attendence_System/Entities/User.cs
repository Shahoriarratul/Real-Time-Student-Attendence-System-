using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attendence_System.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string UserName { get; set; }

        public string password { get; set; }   

        public int userType { get; set; }
    }
}
