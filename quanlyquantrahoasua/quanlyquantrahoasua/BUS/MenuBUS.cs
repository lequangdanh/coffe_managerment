using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using quanlyquantrahoasua.DAL;
using quanlyquantrahoasua.DTO;

namespace quanlyquantrahoasua.BUS
{
   public class MenuBUS
    {
        public List<MenuDTO> GetListMenuByTable(int id)
        {
            return MenuDAL.Instance.GetListMenuByTable(id);
        }
    }
}
