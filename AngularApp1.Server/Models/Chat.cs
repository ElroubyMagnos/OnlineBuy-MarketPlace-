using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBuyDB.Models
{
    public class Chat
    {
        public int ID { get; set; }
        public string Receiver { get; set; }
        public string Sender { get; set; }
        public string MessageText { get; set; }
    }
}
