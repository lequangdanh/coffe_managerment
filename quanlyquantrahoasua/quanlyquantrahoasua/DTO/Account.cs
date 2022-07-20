using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quanlyquantrahoasua.DTO
{
    public class Account
    {
        public Account(string userName,string password)
        {
            this.UserName = userName;
           
            this.Password = password;
        }
        public Account(DataRow row)
        {
            this.UserName = row["userName"].ToString();
            
            this.Password = row["password"].ToString();
        }
        private string password;
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
 
        private string userName;
        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }
    }
}
