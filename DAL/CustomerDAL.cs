using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using System.Data.SqlClient;
using System.Data;
    

namespace DAL
{
    public class CustomerDAL
    {
        DB db = new DB();
        public string Create(customer c)
        {
            try
            {
                db.customers.Add(c);
                db.SaveChanges();
                return "ثبت اطلاعات مشتری با موفقیت انجام شد!";
            }
            catch (Exception e)
            {

                return " هنگام ثبت اطلاعات سیستم با مشکلی مواجهه شد:\n" + e.Message ; 
            }
        }
        public bool Read(customer c)
        {
            var q = db.customers.Where(i => c.Phone == i.Phone);
            if (q.Count() == 0)
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
            string cmd = "SELECT  id AS [آیدی], Name AS [نام و نام خانوادگی], Phone AS [شماره تلفن همراه], Regdate AS [تاریخ ثبت]FROM dbo.customers WHERE(DeleteStatus = 0)";
            SqlConnection con = new SqlConnection("Data Source =.; Initial catalog = CRM-F2; Integrated Security = true");
            var sqladapter = new SqlDataAdapter(cmd, con);
            var commandbuilder = new SqlCommandBuilder(sqladapter);
            var ds = new DataSet();
            sqladapter.Fill(ds);
            return ds.Tables[0];    
        }
        public DataTable Read(string s ,int Index)
        {
            SqlCommand cmd = new SqlCommand();
            if (Index == 0)
            {
                cmd.CommandText = "dbo.SerchCustomer";
            }
            else if (Index == 1)
            {
                cmd.CommandText = "dbo.SerchCustomer.Name";

            }
            else if (Index == 2)
            {
                cmd.CommandText = "dbo.SerchCustomer.Phone";

            }
            SqlConnection con = new SqlConnection("Data Source =.; Initial catalog =CRM-F; Integrated Security = true");
            cmd.Parameters.AddWithValue("@SerchCustomer", s);
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            var sqladapter = new SqlDataAdapter();
            sqladapter.SelectCommand = cmd;
            var commandbuilder = new SqlCommandBuilder(sqladapter);
            var ds = new DataSet();
            sqladapter.Fill(ds);
            return ds.Tables[0];
        }
        public customer Read(int id)        
        {
            return db.customers.Where(i => i.id == id).FirstOrDefault();
        }
        public customer ReadC(string s)
        {
            return db.customers.Where(i => i.Phone == s).SingleOrDefault();
        }
        public List<string> ReadPhoneNumber()
        {
            return db.customers.Select(i=>i.Phone).ToList();
        }
        public string Update(customer c , int id)
        {
            var q = db.customers.Where(i => i.id == id).FirstOrDefault();

            try
            {
                if (q!=null)
                {
                    q.Name = c.Name;
                    q.Phone = c.Phone;
                    db.SaveChanges();
                    return "ویرایش اطلاعات با موفقیت انجام شد!";

                }
                else
                {
                    return " کاربر مورد نظر یافت نشد";
                }
            }
            catch (Exception e)
            {

                return "هنگام ویرایش اطلاعات سیستم با مشکلی مواجهه شد:\n" + e.Message;
            }
        }
        public string Delete(int id)
        {
                var q = db.customers.Where(i => i.id == id).FirstOrDefault();
            try
            {
                if (q!=null)
                {
                    q.DeleteStatus = true;
                    db.SaveChanges();
                    return "حذف اطلاعات با موفقیت انجام شد!";
                }
                else
                {
                    return "کاربر مورد نظر یافت نشد ";
                }
            }
            catch (Exception e)
            {

                return "هنگام حذف اطلاعات سیستم با مشکلی مواجه شد:\n" + e.Message;
            }
        }
    }
}