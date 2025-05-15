using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace collectCoreBLL.Models
{
    public class User
    {
        public int UserID { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string AdressStreet { get; set; }

        public int AdressNumber { get; set; }

        public string Biography { get; set; }
    }
}
