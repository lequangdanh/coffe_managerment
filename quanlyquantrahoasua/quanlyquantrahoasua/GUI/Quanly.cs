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
using quanlyquantrahoasua.DTO;
using quanlyquantrahoasua.BUS;


namespace quanlyquantrahoasua.GUI
{

    public partial class Quanly : Form
    {

        TableBUS tb;
        FoodBUS fb;
        CategoryBUS cb;
        BillBUS bb;
        

        public Quanly()
        {
            tb = new TableBUS();
            fb = new FoodBUS();
            cb = new CategoryBUS();
            bb = new BillBUS();
            InitializeComponent();
            loadtable();
            loadfood();
            loadcombofood();
            loadcomboidfood();
            loadcomboidcategory();
            loadCategory();
            loadcombonameCategory();
            thongke_Bill(dtfrom.Value, dtto.Value);
            
        
        }
        public void loadtable()
        {
            dataGridView3.DataSource = tb.LoadTableList();
        }
        public void loadCategory()
        {
            dataGridView2.DataSource = cb.GetListCategory();
        }
        public void loadfood()
        {
            dataGridView1.DataSource = fb.GetListFood();
        }
        public void loadcombofood()
        {
            List<FoodDTO> listfood = fb.GetListFood();
            cbtenmonan.DataSource = listfood;
            cbtenmonan.DisplayMember = "name";

        }
        public void loadcombonameCategory()
        {
            List<Category> listfood = cb.GetListCategory();
           txttenloai.DataSource = listfood;
            txttenloai.DisplayMember = "name";

        }
        public void loadcomboidCategory()
        {
            List<Category> listfood = cb.GetListCategory();
            cbmaloair.DataSource = listfood;
            cbmaloair.DisplayMember = "ID";

        }
        public void loadcomboidfood()
        {
            List<FoodDTO> listfood = fb.GetListFood();
            cbmamonan.DataSource = listfood;
            cbmamonan.DisplayMember = "id";

        }
        
        public void loadcomboidcategory()
        {
            List<FoodDTO> listfood = fb.GetListFood();
            cbmaloai.DataSource = listfood;
            cbmaloai.DisplayMember = "CategoryID";

        }
        public void loadbill()
        {

        }
        private void Quanly_Load(object sender, EventArgs e)
        {
            

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
           // Table t = new Table(int.Parse(txtmaban.Text),txttenban.Text,txttrangthai.Text);
           // t.ID = int.Parse(txtmaban.Text);
           // t.Name = txttenban.Text;
           // t.Status = txttrangthai.Text;
           if(tb.insert_table(txttenban.Text))
            {
                MessageBox.Show("Thêm thành công!");
                loadtable();
                Trangchu tc = new Trangchu();
                tc.LoadTable();
            } 
           else
                MessageBox.Show("Thêm thất bại!");
          

        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (tb.update_table(int.Parse(txtmaban.Text), txttenban.Text, txttrangthai.Text))
            {
                MessageBox.Show("sửa thành công!");
                loadtable();
            }
            else
                MessageBox.Show("sửa thất bại!");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (tb.delete_table(int.Parse(txtmaban.Text)))
            {
                MessageBox.Show("xóa thành công!");
                loadtable();
            }
            else
                MessageBox.Show("xóa thất bại!");
        }

        private void button7_Click(object sender, EventArgs e)

        {

            dataGridView3.DataSource = TableDAL.Instance.select_table(txttenban.Text);
        }

        private void dataGridView3_Click(object sender, EventArgs e)
        {
            int r = dataGridView3.CurrentCell.RowIndex;
            txtmaban.Text = dataGridView3.Rows[r].Cells["ID"].Value.ToString();
            txttenban.Text = dataGridView3.Rows[r].Cells["Name"].Value.ToString();
            txttrangthai.Text = dataGridView3.Rows[r].Cells["Status"].Value.ToString();
            
        }

        private void btthemthucdon_Click(object sender, EventArgs e)
        {
            if (fb.insert_food(cbtenmonan.Text,int.Parse(cbmaloai.Text),float.Parse(txtgia.Text)))
            {
                MessageBox.Show("Thêm thành công!");
                loadfood();
                loadcombofood();
                loadcomboidfood();
                loadcomboidcategory();
            }
            else
                MessageBox.Show("Thêm thất bại!");
        }

        private void btsuathucdon_Click(object sender, EventArgs e)
        {
            if (fb.update_food(int.Parse(cbmamonan.Text),cbtenmonan.Text, int.Parse(cbmaloai.Text), float.Parse(txtgia.Text)))
            {
                MessageBox.Show("sửa thành công!");
                loadfood();
                loadcombofood();
                loadcomboidfood();
                loadcomboidcategory();
            }
            else
                MessageBox.Show("sửa thất bại!");
        }

        private void bttxoathucdon_Click(object sender, EventArgs e)
        {
            if (fb.delete_food(int.Parse(cbmamonan.Text)))
            {
                MessageBox.Show("xóa thành công!");
                loadfood();
                loadcombofood();
                loadcomboidfood();
                loadcomboidcategory();
            }
            else
                MessageBox.Show("xóa thất bại!");
        }

        private void bttimkiemthucdon_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = fb.select_food(cbtenmonan.Text);
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            int r = dataGridView1.CurrentCell.RowIndex;
            cbmamonan.Text = dataGridView1.Rows[r].Cells["ID"].Value.ToString();
            cbtenmonan.Text = dataGridView1.Rows[r].Cells["Name"].Value.ToString();
            cbmaloai.Text = dataGridView1.Rows[r].Cells["CategoryID"].Value.ToString();
            txtgia.Text = dataGridView1.Rows[r].Cells["Price"].Value.ToString();
        }
        
       

        private void dataGridView2_Click(object sender, EventArgs e)
        {
            
        }

      
        private void dataGridView4_Click(object sender, EventArgs e)
        {
            
        }


      

        private void dataGridView5_Click(object sender, EventArgs e)
        {
        }

        private void dataGridView6_Click(object sender, EventArgs e)
        {
            
        }

        private void dataGridView9_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tabPage7_Click(object sender, EventArgs e)
        {

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }
           private void txtsodienthoai_TextChanged(object sender, EventArgs e)
        {
            
            if (txttenban.Text == "")
                loadtable();
        }
        
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (cb.insert_category(txttenloai.Text))
            {
                MessageBox.Show("Thêm thành công!");
                loadcomboidcategory();
                loadCategory();
                loadcombonameCategory();
            }
            else
                MessageBox.Show("Thêm thất bại!");
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            if (cb.update_category(int.Parse(cbmaloair.Text),txttenloai.Text))
            {
                MessageBox.Show("sửa thành công!");
                loadcomboidcategory();
                loadCategory();
                loadcombonameCategory();
            }
            else
                MessageBox.Show("sửa thất bại!");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (cb.delete_category(int.Parse(cbmaloair.Text)))
            {
                MessageBox.Show("xóa thành công!");
                loadcomboidcategory();
                loadCategory();
                loadcombonameCategory();
            }
            else
                MessageBox.Show("xóa thất bại!");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView2.DataSource = cb.select_category(txttenloai.Text);
        }

        private void dataGridView2_Click_1(object sender, EventArgs e)
        {
            int r = dataGridView2.CurrentCell.RowIndex;
            cbmaloair.Text = dataGridView2.Rows[r].Cells["ID"].Value.ToString();
            txttenloai.Text = dataGridView2.Rows[r].Cells["Name"].Value.ToString();
            
        }
        void thongke_Bill(DateTime checkIn, DateTime checkOut)
        {
            dataGridView7.DataSource = bb.GetBillListByDate(checkIn, checkOut);
        }
        private void btthongke_Click(object sender, EventArgs e)
        {
            thongke_Bill(dtfrom.Value, dtto.Value);
        }
        void baocao(DateTime checkIn, DateTime checkOut)
        {
            crthongke thongke = new crthongke();
            thongke.SetDataSource(bb.GetBillListByDate_report(checkIn, checkOut));
            Baocaothongke baocao = new Baocaothongke();
            baocao.crystalReportViewer1.ReportSource = thongke;
            baocao.ShowDialog();
        }

        private void btdoanhthu_Click(object sender, EventArgs e)
        {
            
            baocao(dtfrom.Value, dtto.Value);
        }

        private void cbtenmonan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbtenmonan.Text == "")
                loadfood();
        }

        private void txttenloai_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txttenloai.Text == "")
                loadCategory();
        }
    }
}
