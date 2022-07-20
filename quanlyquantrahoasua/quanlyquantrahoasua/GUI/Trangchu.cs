using quanlyquantrahoasua.DAL;
using quanlyquantrahoasua.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using quanlyquantrahoasua.BUS;
using System.IO;

namespace quanlyquantrahoasua.GUI
{
    public partial class Trangchu : Form
    {
        MenuBUS mb;
        TableBUS tb;
        BillinfoBUS bib;
        FoodBUS fb;
        BillBUS bb;
        public Trangchu()
        {
            InitializeComponent();
            mb = new MenuBUS();
            tb = new TableBUS();
            bib = new BillinfoBUS();
            fb = new FoodBUS();
            bb = new BillBUS();
            LoadTable();
            LoadComboboxTable(comboBox3);
           
           
        }
        #region Method
       public void LoadTable()

        {
            flowLayoutPanel1.Controls.Clear();
            List<Table> tableList = tb.LoadTableList();

            foreach (Table item in tableList)
            {
                Button btn = new Button() { Width = TableDAL.TableWidth, Height = TableDAL.TableHeight };
                
                btn.Text = item.Name + Environment.NewLine + item.Status;
                btn.Click += btn_Click;
                btn.Tag = item;

                switch (item.Status)
                {
                    case "Trống":
                        btn.BackColor = Color.Aqua;
                        break;
                    default:
                        btn.BackColor = Color.LightPink;
                        break;
                }

                flowLayoutPanel1.Controls.Add(btn);
            }
        }
        #endregion
        void ShowBill(int id)
        {
            listView1.Items.Clear();
            List<quanlyquantrahoasua.DTO.MenuDTO> listBillInfo = mb.GetListMenuByTable(id);
            float totalPrice = 0;
            foreach (quanlyquantrahoasua.DTO.MenuDTO item in listBillInfo)
            {
                ListViewItem lsvItem = new ListViewItem(item.FoodName.ToString());
                lsvItem.SubItems.Add(item.Count.ToString());
                lsvItem.SubItems.Add(item.Price.ToString());
                lsvItem.SubItems.Add(item.TotalPrice.ToString());
                totalPrice += item.TotalPrice;
                listView1.Items.Add(lsvItem);
            }
            
            txttongtien.Text = totalPrice.ToString();
            
            
        }
        void btn_Click(object sender, EventArgs e)
        {
            int tableID = ((sender as Button).Tag as Table).ID;
            listView1.Tag = (sender as Button).Tag;
            ShowBill(tableID);
        }
        

        #region Events

        private void kháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Quanly ql = new Quanly();
            ql.ShowDialog();
            this.Visible = true;
            
            
        }

        #endregion
       public void loadcombofood()
        {
            List<FoodDTO> listfood = fb.GetListFood();
            cbfood.DataSource = listfood;
            cbfood.DisplayMember = "name";
           
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void Trangchu_Load(object sender, EventArgs e)
        {
            loadcombofood();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Table table = listView1.Tag as Table;

            if (table == null)
            {
                MessageBox.Show("Hãy chọn bàn");
                return;
            }

            int idBill = bb.GetUncheckBillIDByTableID(table.ID);
            int foodID = (cbfood.SelectedItem as FoodDTO).ID;
            int count = (int)numericUpDown1.Value;

            if (idBill == -1)
            {
                BillDAL.Instance.InsertBill(table.ID);
                BillinforDAL.Instance.InsertBillInfo(bb.GetMaxIDBill(), foodID, count);
            }
            else
            {
                BillinforDAL.Instance.InsertBillInfo(idBill, foodID, count);
            }

            ShowBill(table.ID);

           LoadTable();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Table table = listView1.Tag as Table;

            int idBill = bb.GetUncheckBillIDByTableID(table.ID);
            int discount = (int)numericUpDown2.Value;


            //double totalPrice = Convert.ToDouble(txttongtien.Text);
            int totalPrice = int.Parse(txttongtien.Text);
            double finalTotalPrice = totalPrice - (totalPrice / 100) * discount;

            if (idBill != -1)
            {
                if (MessageBox.Show(string.Format("Bạn có chắc thanh toán hóa đơn cho bàn {0}\nTổng tiền - (Tổng tiền / 100) x Giảm giá\n=> {1} - ({1} / 100) x {2} = {3}", table.Name, totalPrice, discount, finalTotalPrice), "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                {
                    BillDAL.Instance.CheckOut(idBill,discount,totalPrice);
                    ShowBill(table.ID);

                    LoadTable();
                }
            }
            StreamWriter writer = new StreamWriter("bill.txt",true);
            writer.WriteLine(listView1+"\n Discount: " +discount+ "\n finalTotalPrice: "+ finalTotalPrice);
            writer.Close();

        }
        void LoadComboboxTable(ComboBox cb)
        {
            cb.DataSource = tb.LoadTableList();
            cb.DisplayMember = "Name";
        }
        private void button4_Click(object sender, EventArgs e)
        {
            int id1 = (listView1.Tag as Table).ID;

            int id2 = (comboBox3.SelectedItem as Table).ID;
            if (MessageBox.Show(string.Format("Bạn có thật sự muốn chuyển bàn {0} qua bàn {1}", (listView1.Tag as Table).Name, (comboBox3.SelectedItem as Table).Name), "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                TableDAL.Instance.SwitchTable(id1, id2);

                LoadTable();
            }
        }

        private void đổiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CHANGEPASS ce = new CHANGEPASS();
            ce.ShowDialog();
            this.Visible = true;
        }
    }
}

