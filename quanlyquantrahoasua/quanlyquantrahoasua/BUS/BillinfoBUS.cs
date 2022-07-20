using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using quanlyquantrahoasua.DAL;
using quanlyquantrahoasua.DTO;

namespace quanlyquantrahoasua.BUS
{
    public class BillinfoBUS
    {
        public List<billinfor> GetListBillInfo(int id)
        {


            return BillinforDAL.Instance.GetListBillInfo(id);
        }
    }
}
