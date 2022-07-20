using quanlyquantrahoasua.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quanlyquantrahoasua.DAL
{
     public class FoodDAL
    {
        private static FoodDAL instance;

        public static FoodDAL Instance
        {
            get { if (instance == null) instance = new FoodDAL(); return FoodDAL.instance; }
            private set { FoodDAL.instance = value; }
        }

        private FoodDAL() { }

        public List<FoodDTO> GetFoodByCategoryID(int id)
        {
            List<FoodDTO> list = new List<FoodDTO>();

            string query = "select * from Food where idCategory = " + id;

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                FoodDTO food = new FoodDTO(item);
                list.Add(food);
            }

            return list;
        }

        public List<FoodDTO> GetListFood()
        {
            List<FoodDTO> list = new List<FoodDTO>();

            string query = "select * from Food";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                FoodDTO food = new FoodDTO(item);
                list.Add(food);
            }

            return list;
        }

       
        public bool insert_food(string name,int idCategory,float price)
        {
            //DataProvider.Instance.ExecuteNonQuery("exec them_Food @name, @idCategory, @price", new object[] {name,idCategory,price});
            SqlConnection co = DataProvider.Instance.conect();
            co.Open();
            string query = "them_Food";
            SqlCommand cm = new SqlCommand(query, co);
            cm.CommandType = CommandType.StoredProcedure;
            cm.Parameters.Add("@name", SqlDbType.NVarChar).Value = name;
            cm.Parameters.Add("@idCategory", SqlDbType.Int).Value = idCategory;
            cm.Parameters.Add("@price", SqlDbType.Float).Value = price;
            cm.ExecuteNonQuery();
            return true;
        }
        public bool update_food(int id, string name, int idCategory, float price)
        {
            //DataProvider.Instance.ExecuteNonQuery("them_TableFood @name", new object[] {t.Name});
            SqlConnection co = DataProvider.Instance.conect();
            co.Open();
            string query = "sua_Food";
            SqlCommand cm = new SqlCommand(query, co);
            cm.CommandType = CommandType.StoredProcedure;
            cm.Parameters.Add("@name", SqlDbType.NVarChar).Value = name;
            cm.Parameters.Add("@id", SqlDbType.Int).Value = id;
            cm.Parameters.Add("@idCategory", SqlDbType.Int).Value = idCategory;
            cm.Parameters.Add("@price", SqlDbType.Float).Value = price;
            cm.ExecuteNonQuery();
            return true;
        }
        public bool delete_food(int id)
        {
            //DataProvider.Instance.ExecuteNonQuery("them_TableFood @name", new object[] {t.Name});
            SqlConnection co = DataProvider.Instance.conect();
            co.Open();
            string query = "xoa_Food";
            SqlCommand cm = new SqlCommand(query, co);
            cm.CommandType = CommandType.StoredProcedure;

            cm.Parameters.Add("@id", SqlDbType.Int).Value = id;

            cm.ExecuteNonQuery();
            return true;
        }
        public DataTable select_food(string name)
        {
            SqlConnection co = DataProvider.Instance.conect();
            co.Open();
            string query = "tim_Food";
            SqlCommand cm = new SqlCommand(query, co);
            cm.CommandType = CommandType.StoredProcedure;

            cm.Parameters.Add("@name", SqlDbType.NVarChar).Value = name;

            cm.ExecuteNonQuery();
            DataTable table = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(cm);
            adapter.Fill(table);
            return table;

        }
    }
}
