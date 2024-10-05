using BE;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DAL
{
    public class ProductDAL
    {
        DB db = new DB();
        public string Create(Product p)
        {
            try
            {
                db.products.Add(p);
                db.SaveChanges();
                return "محصول با موفقیت ثبت شد";
            }
            catch (Exception e)
            {

                return "هنگام ثبت اطلاعات،سیستم با مشکلی مواجه شد";
            }
        }
        public bool Read(Product p)
        {
            var q = db.products.Where(i => p.id == i.id);
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
            string cmd = "SELECT id AS[آیدی], Name AS [نام محصول], Price AS [قیمت محصول], Stock AS [تعداد موجودی]FROM dbo.Products where DeletStatus=0";
            SqlConnection con = new SqlConnection("Data Source =.; Initial catalog =CRM-F; Integrated Security = true");
            var sqladapter = new SqlDataAdapter(cmd, con);
            var commandBuilder = new SqlCommandBuilder(sqladapter);
            var ds = new DataSet();
            sqladapter.Fill(ds);
            return ds.Tables[0];


        }
        public DataTable Read(string s)
        {
            SqlCommand cmd = new SqlCommand("dbo.SearchProduct2");
            SqlConnection con = new SqlConnection("Data Source =.; Initial catalog =CRM-F; Integrated Security = true");
            cmd.Parameters.AddWithValue("@SearchProduct2", s);
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            var sqladapter = new SqlDataAdapter();
            sqladapter.SelectCommand = cmd;
            var commandBuilder = new SqlCommandBuilder(sqladapter);
            var ds = new DataSet();
            sqladapter.Fill(ds);
            return ds.Tables[0];

        }
        public Product Read(int id)
        {
            return db.products.Where(i => i.id == id).FirstOrDefault();
        }
        public string Update(Product p,int id)
        {
            var q = db.products.Where(i => i.id == id).FirstOrDefault();
            try
            {
                if (q != null)
                {
                    q.Name = p.Name;
                    q.Price = p.Price;
                    q.Stock = p.Stock;
                    db.SaveChanges();
                    return "ویرایش اطلاعات با موفقیت انجام شد!";

                }
                else
                {
                    return "کالای مورد نظر یافت نشد!";
                }
            }
            catch (Exception e)
            {

                return "هنگام ویرایش اطلاعات،سیستم با مشکلی مواجه شد!\n"+e.Message;
            }
           
        }
        public string Delete(int id)
        {
            var q = db.products.Where(i => i.id == id).FirstOrDefault();

            try
            {
                if (q!=null)
                {
                    q.DeletStatus = true;
                    db.SaveChanges();
                    return "حذف اطلاعات با موفقیت انجام شد!";
                }
                else
                {
                    return "کالای مورد نظر یافت نشد!";
                }
            }
            catch (Exception e)
            {

                return "هنگام حذف اطلاعات،سیستم با مشکلی مواجه شد!\n"+e.Message;
            }
           
        }

    }
}
