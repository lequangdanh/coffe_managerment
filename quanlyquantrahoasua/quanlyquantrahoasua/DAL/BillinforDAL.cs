using quanlyquantrahoasua.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quanlyquantrahoasua.DAL
{
     public class BillinforDAL
    {
        private static BillinforDAL instance;

        public static BillinforDAL Instance
        {
            get { if (instance == null) instance = new BillinforDAL(); return BillinforDAL.instance; }
            private set { BillinforDAL.instance = value; }
        }

        private BillinforDAL() { }

        public List<billinfor> GetListBillInfo(int id)
        {
            List<billinfor> listBillInfo = new List<billinfor>();

            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.BillInfo WHERE idBill = " + id);

            foreach (DataRow item in data.Rows)
            {
                billinfor info = new billinfor(item);
                listBillInfo.Add(info);
            }

            return listBillInfo;
        }
        public void InsertBillInfo(int idBill, int idFood, int count)
        {
            DataProvider.Instance.ExecuteNonQuery("them_BillInfo @idBill , @idFood , @count", new object[] { idBill, idFood, count });
        }
    }
}
