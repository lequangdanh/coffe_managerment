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
    class TableDAL
    {
        private static TableDAL instance;

        public static TableDAL Instance
        {
            get { if (instance == null) instance = new TableDAL(); return TableDAL.instance; }
            private set { TableDAL.instance = value; }
        }

        public static int TableWidth = 90;
        public static int TableHeight = 90;

        private TableDAL() { }

        public List<Table> LoadTableList()
        {
            List<Table> tableList = new List<Table>();

            DataTable data = DataProvider.Instance.ExecuteQuery("xem_ban");

            foreach (DataRow item in data.Rows)
            {
                Table table = new Table(item);
                tableList.Add(table);
            }

            return tableList;
        }
        public void SwitchTable(int id1, int id2)
        {
            DataProvider.Instance.ExecuteQuery("chuyenban @idTable1 , @idTabel2", new object[] { id1, id2 });
        }
        public bool insert_table(string name)
        {
            //DataProvider.Instance.ExecuteNonQuery("them_TableFood @name", new object[] {t.Name});
            SqlConnection co = DataProvider.Instance.conect();
            co.Open();
            string query = "them_TableFood";
            SqlCommand cm = new SqlCommand(query, co);
            cm.CommandType = CommandType.StoredProcedure;
            cm.Parameters.Add("@name", SqlDbType.NVarChar).Value = name;
            cm.ExecuteNonQuery();
            return true;
        }
        public bool update_table(int id,string name,string status)
        {
            //DataProvider.Instance.ExecuteNonQuery("them_TableFood @name", new object[] {t.Name});
            SqlConnection co = DataProvider.Instance.conect();
            co.Open();
            string query = "sua_TableFood";
            SqlCommand cm = new SqlCommand(query, co);
            cm.CommandType = CommandType.StoredProcedure;
            cm.Parameters.Add("@name", SqlDbType.NVarChar).Value = name;
            cm.Parameters.Add("@id", SqlDbType.Int).Value = id;
            cm.Parameters.Add("@status", SqlDbType.NVarChar).Value = status;
            cm.ExecuteNonQuery();
            return true;
        }
        public bool delete_table(int id)
        {
            //DataProvider.Instance.ExecuteNonQuery("them_TableFood @name", new object[] {t.Name});
            SqlConnection co = DataProvider.Instance.conect();
            co.Open();
            string query = "xoa_TableFood";
            SqlCommand cm = new SqlCommand(query, co);
            cm.CommandType = CommandType.StoredProcedure;
            
            cm.Parameters.Add("@id", SqlDbType.Int).Value = id;
           
            cm.ExecuteNonQuery();
            return true;
        }
        public DataTable select_table(string name)
        {
            SqlConnection co = DataProvider.Instance.conect();
            co.Open();
            string query = "tim_TableFood";
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
