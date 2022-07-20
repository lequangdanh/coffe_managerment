using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using quanlyquantrahoasua.DAL;

namespace quanlyquantrahoasua.BUS
{
   public class BillBUS
    {
        public int GetUncheckBillIDByTableID(int id)
        {


            return BillDAL.Instance.GetUncheckBillIDByTableID(id);
        }
        
        

        public DataTable GetBillListByDate(DateTime checkIn, DateTime checkOut)
        {
            return BillDAL.Instance.GetBillListByDate(checkIn, checkOut);
        }
        public DataTable GetBillListByDate_report(DateTime checkIn, DateTime checkOut)
        {
            return BillDAL.Instance.GetBillListByDate_report(checkIn, checkOut);
        }
        public int GetMaxIDBill()
        {
            return BillDAL.Instance.GetMaxIDBill();
        }
    }
}
