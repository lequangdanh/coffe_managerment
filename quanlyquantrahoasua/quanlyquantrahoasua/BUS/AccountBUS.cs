using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using quanlyquantrahoasua.DAL;

namespace quanlyquantrahoasua.BUS
{
    public class AccountBUS
    {
        public bool UpdateAccount(string userName, string pass, string newPass, string comfirmpass)
        {


            return AccountDAL.Instance.UpdateAccount(userName,pass,newPass,comfirmpass);
        }
    }
}
