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
    public class ReminderDAL
    {
        DB db = new DB();
        public string Create(Reminder r)
        {
            try
            {
                db.reminders.Add(r);
                db.SaveChanges();
                return "ثبت یادآور با موفقیت انجام شد";
            }
            catch (Exception e)
            {

                return "ثبت یادآور با مشکلی مواجه شد!" + e.Message;
            }
          
        }
        public DataTable Read()
        {
            SqlCommand cmd = new SqlCommand("dbo.ReadReminders");
            SqlConnection con = new SqlConnection("Data Source =.; Initial catalog = CRM-F; Integrated Security = true");
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            var sqladapter = new SqlDataAdapter();
            sqladapter.SelectCommand = cmd;
            var commandbuilder = new SqlCommandBuilder(sqladapter);
            var ds = new DataSet();
            sqladapter.Fill(ds);
            return ds.Tables[0];
        }
        public DataTable Read(string s)
        {
            SqlCommand cmd = new SqlCommand("dbo.SearchReadReminders");
            SqlConnection con = new SqlConnection("Data Source =.; Initial catalog = CRM-F; Integrated Security = true");
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            var sqladapter = new SqlDataAdapter();
            sqladapter.SelectCommand = cmd;
            var commandbuilder = new SqlCommandBuilder(sqladapter);
            var ds = new DataSet();
            sqladapter.Fill(ds);
            return ds.Tables[0];
        }
        public string Update(Reminder r,int id)
        {
            var q = db.reminders.Where(i => i.id == id).FirstOrDefault();
            try
            {
                if (q!=null)
                {
                    q.ReminderInfo = r.ReminderInfo;
                    q.Title = r.Title;
                    q.IsDone = r.IsDone;
                    db.SaveChanges();
                    return "ویرایش یادآور با موفقیت انجام شد";
                }
                else
                {
                    return "ویرایش یادآور پیدا نشد!";
                }
               

            }
            catch (Exception e)
            {

                return "ویرایش اطلاعات با مشکلی مواجه شد!" + e.Message;
            }
        }
        public string Delete(int id)
        {
            var q = db.reminders.Where(i => i.id == id).FirstOrDefault();
            try
            {
                if (q!=null)
                {
                    q.DeleteStatus = true;
                    db.SaveChanges();
                    return "حذف اطلاعات با موفقیت انجام شد";
                }
                else
                {
                    return "حذف اطلاعات با مشکلی مواجه شد!";
                }
            }
            catch (Exception e)
            {

                return "سیستم با مشکلی مواجه شد!" + e.Message;
            }
        }
        public string Done(int id)
        {
            var q = db.reminders.Where(i => i.id == id).FirstOrDefault();
            try
            {
                if (q != null)
                {
                    q.IsDone = true;
                    db.SaveChanges();
                    return "انجام شد";
                }
                else
                {
                    return "انجام نشده";
                }
            }
            catch (Exception e)
            {

                return "سیستم با مشکلی مواجه شد!" + e.Message;
            }
           
        }
    }
}
