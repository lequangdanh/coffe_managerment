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
    public class CategoryDAL
    {
        private static CategoryDAL instance;

        public static CategoryDAL Instance
        {
            get { if (instance == null) instance = new CategoryDAL(); return CategoryDAL.instance; }
            private set { CategoryDAL.instance = value; }
        }

        private CategoryDAL() { }

        public List<Category> GetListCategory()
        {
            List<Category> list = new List<Category>();

            string query = "select * from FoodCategory";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                Category category = new Category(item);
                list.Add(category);
            }

            return list;
        }
        public bool insert_category(string name)
        {
            //DataProvider.Instance.ExecuteNonQuery("them_TableFood @name", new object[] {t.Name});
            SqlConnection co = DataProvider.Instance.conect();
            co.Open();
            string query = "them_Category";
            SqlCommand cm = new SqlCommand(query, co);
            cm.CommandType = CommandType.StoredProcedure;
            cm.Parameters.Add("@name", SqlDbType.NVarChar).Value = name;
            cm.ExecuteNonQuery();
            return true;
        }
        public bool update_category(int id, string name)
        {
            //DataProvider.Instance.ExecuteNonQuery("them_TableFood @name", new object[] {t.Name});
            SqlConnection co = DataProvider.Instance.conect();
            co.Open();
            string query = "sua_Category";
            SqlCommand cm = new SqlCommand(query, co);
            cm.CommandType = CommandType.StoredProcedure;
            cm.Parameters.Add("@name", SqlDbType.NVarChar).Value = name;
            cm.Parameters.Add("@id", SqlDbType.Int).Value = id;
           
            cm.ExecuteNonQuery();
            return true;
        }
        public bool delete_category(int id)
        {
            //DataProvider.Instance.ExecuteNonQuery("them_TableFood @name", new object[] {t.Name});
            SqlConnection co = DataProvider.Instance.conect();
            co.Open();
            string query = "xoa_Category";
            SqlCommand cm = new SqlCommand(query, co);
            cm.CommandType = CommandType.StoredProcedure;

            cm.Parameters.Add("@id", SqlDbType.Int).Value = id;

            cm.ExecuteNonQuery();
            return true;
        }
        public DataTable select_category(string name)
        {
            SqlConnection co = DataProvider.Instance.conect();
            co.Open();
            string query = "tim_Category";
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
