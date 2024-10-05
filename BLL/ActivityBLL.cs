using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;

namespace BLL
{
    public class ActivityBLL
    {
        ActivityDAL dal = new ActivityDAL();
        public string Create(Activity a, User u, customer c, ActivityCategory ac)
        {
            return dal.Create(a, u, c, ac);
        }
        public ActivityCategory ReadByName(string Name)
        {
            return dal.ReadByName(Name);
        }
        public DataTable Read()
        {
            return dal.Read();
        }
        public List<string> ReadActivityNames()
        {
            return dal.ReadActivityNames();
        }
        public Activity ReadA(string s)
        {
            return dal.ReadA(s);
        }
        public Activity Read(int id)
        {
            return dal.Read(id);
        }
        public customer Read(string name)
        {
            return dal.Read(name);  
        }
        public User Readu(string Name)
        {
            return dal.Readu(Name);
        }
        public string Update(Activity a,int id)
        {
            return dal.Update(a,id);
        }
        public string Delete(int id)
        {
            return dal.Delete(id);
        }
    }
}
