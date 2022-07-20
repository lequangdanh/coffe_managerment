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
    public class TableBUS
    {
        public List<Table> LoadTableList()
        {


            return TableDAL.Instance.LoadTableList();
        }
        
        public bool insert_table(string name)
        {

            return TableDAL.Instance.insert_table(name);
        }
        public bool update_table(int id, string name, string status)
        {
            //DataProvider.Instance.ExecuteNonQuery("them_TableFood @name", new object[] {t.Name});

            return TableDAL.Instance.update_table(id, name, status);
        }
        public bool delete_table(int id)
        {
            //DataProvider.Instance.ExecuteNonQuery("them_TableFood @name", new object[] {t.Name});

            return TableDAL.Instance.delete_table(id);
        }
        public DataTable select_table(string name)
        {

            return TableDAL.Instance.select_table(name);

        }
    }
}
