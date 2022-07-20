using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using quanlyquantrahoasua.DAL;
using quanlyquantrahoasua.BUS;

namespace quanlyquantrahoasua.GUI
{
    public partial class CHANGEPASS : Form
    {
        AccountBUS ab;
        public CHANGEPASS()
        {
            InitializeComponent();
            ab = new AccountBUS();
        }

        private void btdoipass_Click(object sender, EventArgs e)
        {
            if (ab.UpdateAccount(txttendangnhap.Text, txtmatkhau.Text, txtmatkhaumoi.Text, txtnhaplaimatkhau.Text)==true)

            MessageBox.Show("Đổi mật khẩu thành công");
            else
                MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
