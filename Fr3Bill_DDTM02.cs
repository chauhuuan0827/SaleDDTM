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
    public partial class Fr3Bill_DDTM02 : Form
    {
        public Fr3Bill_DDTM02()
        {
            InitializeComponent();
        }

        private void Fr3Bill_DDTM02_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'g202AnSaleDDTNDataSetbill.DMBILL' table. You can move, or remove it, as needed.
            this.dMBILLTableAdapter.Fill(this.g202AnSaleDDTNDataSetbill.DMBILL);
            // TODO: This line of code loads data into the 'g202AnSaleDDTNDSKH.DMKH' table. You can move, or remove it, as needed.
            this.dMKHTableAdapter.Fill(this.g202AnSaleDDTNDSKH.DMKH);

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult ch = MessageBox.Show("THIỆT THOÁT (Y/N)?", "XÁC NHẬN", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ch == DialogResult.Yes)//NSD đã chọn Yes
            {
                Application.Exit();//thoát chương trình
            }
        }

        private void btnMain_Click(object sender, EventArgs e)
        {
            DialogResult ch = MessageBox.Show("THIỆT VỀ MÀN HÌNH TRƯỚC KHÔNG (Y/N)?", "XÁC NHẬN", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ch == DialogResult.Yes)//NSD đã chọn Yes
            {
                this.Close();
            }
        }
    }
}
