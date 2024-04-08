using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBuyDB.Models
{
    public class MoneyStorage
    {
        public int ID { get; set; }
        public int Earnings { get; set; }
        public int BillNumber { get; set; }
        public DateTime When { get; set; }
    }
}
