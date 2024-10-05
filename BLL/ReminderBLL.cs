using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using BE;
using DAL;

namespace BLL
{
    public class ReminderBLL
    {
        ReminderDAL dal = new ReminderDAL();
        public String Create(Reminder r)
        {
            return dal.Create(r);
        }
        public DataTable Read()
        {
            return dal.Read();
        }
        public DataTable Read(string s)
        {
            return dal.Read(s);
        }
        public string Update(Reminder r,int id)
        {
            return dal.Update(r,id);
        }
        public string Delete(int id)
        {
            return dal.Delete(id);
        }
        public string Done(int id)
        {
            return dal.Done(id);
        }
    }
}
