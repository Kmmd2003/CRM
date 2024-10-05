using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using System.Data;
using System.Data.SqlClient;


namespace DAL
{
    public class ActivityDAL
    {
        DB db = new DB();
        public string Create(Activity a, User u, customer c, ActivityCategory ac)
        {
            try
            {
                a.customer = db.customers.Find(c.id);
                a.User = db.users.Find(u.id);
                a.ActivityCategory = db.ActivityCategories.Find(ac.id);
                db.activities.Add(a);
                db.SaveChanges();
                return "ثبت فعالیت با موفقیت انجام شد";
            }
            catch (Exception e)
            {

                return "هنگام ثبت فعالیت ، سیستم با مشکلی مواجه شد! " + e.Message;
            }
        }

        public ActivityCategory ReadByName(string Name)
        {
            var q = db.ActivityCategories.Where(u => u.CategoryName == Name);
            ActivityCategory a = new ActivityCategory();
            a.CategoryName = Name;
            if (q.Count() == 0)
            {
                db.ActivityCategories.Add(a);
                db.SaveChanges();
                return a;
            }
            else
            {
                return q.Single();
            }
        }

        public customer Read(string name)
        {
            return db.customers.Where(u => u.Phone == name).FirstOrDefault();
        }
        //برای جستوجو کاستومر

        public User Readu(string Name)
        {
            return db.users.Where(u => u.UserName == Name).FirstOrDefault();
        }
        //برای جستوجو یوزر


        public DataTable Read()
        {
            SqlCommand cmd = new SqlCommand("dbo.ReadActivity");
            SqlConnection con = new SqlConnection("Data Source =.; Initial catalog = CRM-F2; Integrated Security = true");
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            var sqladapter = new SqlDataAdapter();
            sqladapter.SelectCommand = cmd;
            var commandbuilder = new SqlCommandBuilder(sqladapter);
            var ds = new DataSet();
            sqladapter.Fill(ds);
            return ds.Tables[0];
        }
        public List<string> ReadActivityNames()
        {
             return db.activities.Select(i =>i.Info).ToList();
        }
        public Activity ReadA(string s)
        {
            return db.activities.Where(i => i.Info == s).SingleOrDefault();
        }
        public Activity Read(int id)
        {
            return db.activities.Where(i=>i.id == id).SingleOrDefault();
        }
        public string Update(Activity a,int id)
        {
            var q = db.activities.Where(i => i.id == id).SingleOrDefault();
            try
            {
                if (q!=null)
                {
                    q.Title = a.Title;
                    q.RegDate = a.RegDate;
                    
                    db.SaveChanges();
                    return "ویرایش اطلاعات با موفقیت انجام شد";
                }
                else
                {
                    return "کاربر مورد نظر یافت نشد!";
                }
            }
            catch (Exception e)
            {

                return "هنگام ویرایش اطلاعات ، سیستم با مشکلی مواجه شد!" + e.Message;
            }
        }
        public string Delete(int id)
        {
            var q = db.activities.Where(i => i.id == id).SingleOrDefault();
            try
            {
                if (q != null)
                {
                    q.DeletStatus = true;
                    db.SaveChanges();
                    return "فعالیت مورد نظر با موفقیت حذف شد";
                }
                else
                {
                    return "فعالیت مورد نظر یافت نشد!";
                }
            }
            catch (Exception e)
            {

                return "هنگام حذف اطلاعات ، سیستم با مشکلی مواجه شد!" + e.Message;
            }
          
        }
    }
}
