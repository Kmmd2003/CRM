using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;
using System.Data;

namespace BLL
{
    public class CustomerBLL
    {
        CustomerDAL dal = new CustomerDAL();    
        public string Create(customer c)
        {
            if (dal.Read(c))
            {
                return dal.Create(c);
            }
            else
            {
                return "کاربری با همین شماره تماس در سیستم قبلا ذخیره شده است!";
            }
        }
        public bool Read(customer c)
        {
            return dal.Read(c);
        }
        public DataTable Raed(string s,int Index)
        {
            return dal.Read(s,Index);
        }
        public DataTable Read()
        {
            return dal.Read();
        }
        public customer Read(int id)
        {
            return dal.Read(id);
        }
        public customer ReadC(string s)
        {
            return dal.ReadC(s);
        }
        public List<string> ReadPhoneNumber()
        {
            return dal.ReadPhoneNumber();
        }
        public string Update(customer c,int id)
        {
            return dal.Update(c,id);
        }
        public string Delete(int id)
        {
           return dal.Delete(id);
        }

        
    }
}
