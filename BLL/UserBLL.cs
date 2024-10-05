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
    public class UserBLL
    {
        private string Encode(String pass)
        {
            byte[] encData_Byte = new byte[pass.Length];
            encData_Byte = System.Text.Encoding.UTF8.GetBytes(pass);
            string encodedData = Convert.ToBase64String(encData_Byte);
            return encodedData;
        }
        private string Decode(string EncodedPass)
        {
            System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
            System.Text.Decoder utf8Decoder = encoder.GetDecoder();
            byte[] todecode_byte = Convert.FromBase64String(EncodedPass);
            int charCount = utf8Decoder.GetCharCount(todecode_byte,0,todecode_byte.Length);
            char[] decoded_char = new char[charCount];
            utf8Decoder.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
            string result = new string (decoded_char);
            return result;
        }
        UserDAL dal = new UserDAL();    
        public string Create(User u)
        {
            u.Password = Encode(u.Password);
           return dal.Create(u);
        }
        public bool Read(User u)
        {
           return dal.Read(u);
        }
        public User Read(int id)
        {
            return dal.Read(id);
        }
        public DataTable Read()
        {
            return dal.Read();
        }
        public List<string> ReadUserNames()
        {
            return dal.ReadUserNames();
        }
        public List<string> ReadUserNameActivity()
        {
            return dal.ReadUserNames();
        }
        public User ReadSearch(string s)
        {
            return dal.ReadSearch(s);
        }
        public string Update(User u,int id)
        {
            u.Password=Encode(u.Password);  
            return dal.Update(u,id);
        }
        public string Delete(int id)
        {
            return dal.Delete(id);
        }
    }
}
