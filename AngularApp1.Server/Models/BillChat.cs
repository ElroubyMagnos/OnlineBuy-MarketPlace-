using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBuyDB.Models
{
    public class BillChat
    {
        public int ID { get; set; }
        public string Sender { get; set; }
        public string Message { get; set; }
        public int BillNumber { get; set; }
        public bool SeenByEmployee { get; set; }
    }
}
