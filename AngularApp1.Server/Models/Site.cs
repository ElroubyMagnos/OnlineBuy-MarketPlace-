using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBuyDB.Models
{
    public class Site
    {
        public int ID { get; set; }
        public byte[] Logo { get; set; }
        public string Facebook { get; set; }
        public string WhatsApp { get; set; }
    }
}
