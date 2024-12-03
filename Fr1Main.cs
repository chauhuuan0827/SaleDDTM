using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace G202CHAnSaleDDTM
{
    public partial class Fr1Main : Form
    {
        public Fr1Main()
        {
            InitializeComponent();
        }

        private void thoátKhỏiChươngTrìnhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult ch = MessageBox.Show("THIỆT THOÁT (Y/N)?", "XÁC NHẬN", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ch == DialogResult.Yes)//NSD đã chọn Yes
            {
                Application.Exit();//thoát chương trình
            }
        }

        private void lậpPhiếuTínhTiềnBillToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Fr3Bill_DDTM02 fr = new Fr3Bill_DDTM02();
            fr.ShowDialog();
        }

        private void lậpHóaĐơnInvoiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Fr4Invoice_DDTM02 fr = new Fr4Invoice_DDTM02();
            fr.ShowDialog();
        }

        private void danhMụcSảnPhẩmDiĐộngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Fr2QLDMSPDD_DDTM02 fr = new Fr2QLDMSPDD_DDTM02();
            fr.ShowDialog();
        }
/// <summary>
/// lấy ngày hiện tại
/// </summary>
/// <param name="sender"></param>
/// <param name="e"></param>
        private void Fr1Main_Load(object sender, EventArgs e)
        {
            lbDate.Text = StatusLbDate.Text = "Hôm nay: " + DateTime.Now.ToShortDateString(); //lấy ngày hiện tại của hệ thống
        }
        /// <summary>
        /// kích hoạt đồng hồ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            lbTime.Text = StatuslbTime.Text = System.DateTime.Now.ToLongTimeString();
        }
    }
}
