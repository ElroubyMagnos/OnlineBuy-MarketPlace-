using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Buy_Plus
{
    public class Employee
    {
        public int ID { get; set; }
        [MaxLength(50)]
        public string Username { get; set; }
        [MaxLength(50)]
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
    }
}
