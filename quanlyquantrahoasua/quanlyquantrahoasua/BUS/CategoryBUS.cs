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
    public class CategoryBUS
    {
        public List<Category> GetListCategory()
        {


            return CategoryDAL.Instance.GetListCategory();
        }
        public bool insert_category(string name)
        {
            //DataProvider.Instance.ExecuteNonQuery("them_TableFood @name", new object[] {t.Name});

            return CategoryDAL.Instance.insert_category(name);
        }
        public bool update_category(int id, string name)
        {
            //DataProvider.Instance.ExecuteNonQuery("them_TableFood @name", new object[] {t.Name});
            
            return CategoryDAL.Instance.update_category(id,name);
        }
        public bool delete_category(int id)
        {
            //DataProvider.Instance.ExecuteNonQuery("them_TableFood @name", new object[] {t.Name});
            
            return CategoryDAL.Instance.delete_category(id);
        }
        public DataTable select_category(string name)
        {
            
            return CategoryDAL.Instance.select_category(name);

        }
    }
}
