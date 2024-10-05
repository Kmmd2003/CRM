using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace DAL
{
    public class UserGroupDAL
    {
        DB db = new DB();

        public string Create(UserGroup ug)
        {
            try
            {
                db.userGroups.Add(ug);
                db.SaveChanges();
                return "ثبت گروه کاربری با موفقیت انجام شد";
            }
            catch (Exception e)
            {

                return "در ثبت گروه کاربری مشکلی رخ داد!" + e.Message;
            }
        }
    }
}
