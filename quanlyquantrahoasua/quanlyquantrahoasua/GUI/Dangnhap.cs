using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using quanlyquantrahoasua.DAL;

namespace quanlyquantrahoasua.GUI
{
    
    public partial class Dangnhap : Form
    {
       
        public Dangnhap()
        {
            
            InitializeComponent();
        }

        private void Dangnhap_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection co = DataProvider.Instance.conect();
            co.Open();
           string query = "select *from dbo.Account where Username='"+txtdangnhap.Text+"' and PassWord='"+txtmatkhau.Text+"'";
            SqlCommand cm = new SqlCommand(query,co);
            SqlDataReader reader = cm.ExecuteReader();
            if (reader.Read()==true)
            {
                MessageBox.Show("Đăng nhập thành công");
                Trangchu tc = new Trangchu();
                tc.ShowDialog();
                this.Visible = true;
                co.Close();
                
            }
            else
             MessageBox.Show("Đăng nhập thất bại!Mời nhập lại");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CHANGEPASS ce = new CHANGEPASS();
            ce.ShowDialog();
            this.Visible = true;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
                txtmatkhau.PasswordChar = '\0';
            else
                txtmatkhau.PasswordChar = '*';
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
