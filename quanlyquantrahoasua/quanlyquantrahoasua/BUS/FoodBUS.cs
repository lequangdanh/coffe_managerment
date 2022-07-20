using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using quanlyquantrahoasua.DAL;
using quanlyquantrahoasua.DTO;

namespace quanlyquantrahoasua.BUS
{
    public class FoodBUS
    {
        public List<FoodDTO> GetFoodByCategoryID(int id)
        {

            return FoodDAL.Instance.GetFoodByCategoryID(id);
        }

        public List<FoodDTO> GetListFood()
        {

            return FoodDAL.Instance.GetListFood();
        }

        public bool insert_food(string name, int idCategory, float price)
        {
            return FoodDAL.Instance.insert_food(name, idCategory, price);
        }
        public bool update_food(int id, string name, int idCategory, float price)
        {
            return FoodDAL.Instance.update_food(id, name, idCategory, price);
        }
        public bool delete_food(int id)
        {
            return FoodDAL.Instance.delete_food(id);
        }
        public DataTable select_food(string name)
        {
            return FoodDAL.Instance.select_food(name);
        }
    }
}
