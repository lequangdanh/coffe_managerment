using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quanlyquantrahoasua.DAL
{
    public class AccountDAL
    {
        private static AccountDAL instance;

        public static AccountDAL Instance
        {
            get { if (instance == null) instance = new AccountDAL(); return instance; }
            private set { instance = value; }
        }

        private AccountDAL() { }

        
        public bool UpdateAccount(string userName, string pass, string newPass,string comfirmpass)
        {
            DataProvider.Instance.ExecuteNonQuery("exec changepass @Username , @PassWord , @NewPassword , @ComfirmPassWord ", new object[] { userName, pass, newPass,comfirmpass });

            return true;
        }
    }
}
