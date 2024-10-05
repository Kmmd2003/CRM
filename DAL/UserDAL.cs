using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace DAL
{
    public class UserDAL
    {
        DB db = new DB();
        public string Create(User u)
        {
            try
            {
                if (Read(u))
                {
                    db.users.Add(u);
                    db.SaveChanges();
                    return "ثبت با موفقیت انجام شد";
                }
                else
                {
                    return "کاربر قبلا در سیستم ثبت شده است!";
                }
            }
            catch (Exception e)
            {

                return "سیستم با مشکلی مواجه شد!" + e.Message;
            }
           
        }
        public bool Read(User u)
        {
            var q = db.users.Where(i => i.UserName == u.UserName);
            if(q.Count() == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }
        public DataTable Read()
        {
            SqlCommand cmd = new SqlCommand("dbo.ReadUser");
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
        public User Read(int id)
        {
            return db.users.Where(i => i.id == id).FirstOrDefault();
        }
        public User ReadSearch(string s)
        {
            return db.users.Where(i=> i.UserName== s).SingleOrDefault();
        }
        public List<string> ReadUserNames()
        {
            return db.users.Select(i => i.UserName).ToList();
        }
        public List<string> ReadUserNameActivity()
        {
            return db.users.Select(i =>i.name).ToList();
        }
        public string Update(User u,int id)
        {
            try
            {
                var q = db.users.Where(i => i.id == id).FirstOrDefault();
                if (q != null)
                {
                    q.name = u.name;
                    q.UserName = u.UserName;
                    q.Password = u.Password;
                    q.Pic = u.Pic;
                    db.SaveChanges();
                    return "ویرایش اطلاعات با موفقیت انجام شد!";
                }
                else
                {
                    return "کاربر مورد نظر یافت نشد!";
                }
            }
            catch (Exception e)
            {

               return"ویرایش اطلاعات با مشکلی مواجه شد!\n"+ e.Message;
            }
            
        }
        public string Delete(int id)
        {
            var q = db.users.Where(i=> i.id == id).FirstOrDefault();
            try
            {
                if (q!=null)
                {
                    q.DeleteStatus = true;
                    db.SaveChanges();
                    return "حذف کاربر با موفقیت انجام شد";
                }
                else
                {
                    return "حذف کاربر انجام نشد!";
                }
            }
            catch (Exception e)
            {

                return "سیستم با مشکلی مواجه شد!" + e.Message;
            }
        }
    }
}
