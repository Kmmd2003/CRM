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
    public class ProductBLL
    {
        ProductDAL dal = new ProductDAL();
        public string Create(Product p)
        {
            if (dal.Read(p))
            {
                return dal.Create(p);
            }
            else
            {
                return "محصول قبلا در سیستم ثبت شده است!";
            }
        }
        public DataTable Read()
        {
              return dal.Read();
        }
        public DataTable Read(string s)
        {
            return dal.Read(s);
        }
        public Product Read(int id)
        {
            return dal.Read(id);
        }
        public bool Read(Product p)
        {
            return dal.Read(p);
        }
        public string Update(Product p,int id)
        {
            return dal.Update(p,id);
        }
        public string Delete(int id)
        {
            return dal.Delete(id);
        }
    }
}
