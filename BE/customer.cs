using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class customer
    {
        public customer()
        {
            DeleteStatus = false;
        }
        public int id { get; set; }
        public string Name { get; set; }
        public bool DeleteStatus { get; set; }
        public string Phone { get; set; }
        public DateTime Regdate { get; set; }
        public List<Invoice> invoices { get; set; } = new List<Invoice>();
        public List<Activity> activities { get; set; } = new List<Activity>();  
    }
}
