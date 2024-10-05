using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using BE;


namespace DAL
{
    public class DB : DbContext
    {
        public DB() : base("constr")
        {

        }
        public DbSet<customer> customers { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<Activity> activities { get; set; }
        public DbSet<ActivityCategory> ActivityCategories { get; set; }
        public DbSet<User> users { get; set; }
        public DbSet<Reminder> reminders { get; set; }
        public DbSet<Invoice> invoices { get; set; }
        public DbSet<UserAccessRole> userAccessRoles { get; set; }
        public DbSet<UserGroup> userGroups { get; set; }    
    }
}
