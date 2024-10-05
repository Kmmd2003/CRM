using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class User
    {
        public User()
        {
            DeleteStatus = false;
        }
        public int id { get; set; }
        public string name { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Pic { get; set; }
        public bool status { get; set; }
        public DateTime RegDate { get; set; }
        public List<Activity> activities { get; set; } = new List<Activity>();
        public List<Reminder> reminders { get; set; } = new List<Reminder>();
        public List<Invoice> invoices { get; set; } = new List<Invoice>();
        public bool DeleteStatus { get; set; }
        public UserGroup userGroup { get; set; }
    }
}
