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
    public partial class Fr2SPDD_DDTM02RBTV : Form
    {
        static string ms, ten;

        public Fr2SPDD_DDTM02RBTV(string mssp, string tensp)
        {
            InitializeComponent();
            ms = mssp;
            ten = tensp;
        }
        /// <summary>
        /// Nút thoát
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult ch = MessageBox.Show("THIỆT THOÁT (Y/N)?", "XÁC NHẬN", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ch == DialogResult.Yes)//NSD đã chọn Yes
            {
                Application.Exit();//thoát chương trình
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult ch = MessageBox.Show("THIỆT VỀ MÀN HÌNH CHÍNH KHÔNG (Y/N)?", "XÁC NHẬN", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ch == DialogResult.Yes)//NSD đã chọn Yes
            {
                this.Close();
            }
        }

      

        private void Fr2SPDD_DDTM02RBTV_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'g22AnSaleDDTNtkRBTV.TonKho' table. You can move, or remove it, as needed.
            //    this.tonKhoTableAdapter.Fill(this.g22AnSaleDDTNtkRBTV.TonKho);
            // TODO: This line of code loads data into the 'g22AnSaleDDTNctiRBTV.CT_HD' table. You can move, or remove it, as needed.
            //   this.cT_HDTableAdapter.Fill(this.g22AnSaleDDTNctiRBTV.CT_HD);
            // TODO: This line of code loads data into the 'g22AnSleDDTNctbRBTV.CT_BILL' table. You can move, or remove it, as needed.
            //   this.cT_BILLTableAdapter.Fill(this.g22AnSleDDTNctbRBTV.CT_BILL);
            // TODO: This line of code loads data into the 'g22AnSleDDTMdvRBTV.DMDVBH' table. You can move, or remove it, as needed.
            //  this.dMDVBHTableAdapter.Fill(this.g22AnSleDDTMdvRBTV.DMDVBH,ms);
//            MessageBox.Show("Quý vị đang muốn XÓA mặt hàng có mã:" + ms + " tên:" + ten + " => nhưng mặt hàng này còn RBTV sau cần phải xử lý trước kho Xóa.");
            lbTitle.Text = "G202: CHÂU HỮU ÂN: XỬ LÝ RBTV DL KHI DỪNG BÁN SẢN PHẨM:" + ms + ": " + ten;
            gBTon.Text = "MẶT HÀNG CẦN 'XOÁ':" + ms + ": " + ten + " ĐANG CÒN TỒN TẠI CÁC CƠ SỞ BÁN HÀNG SAU";
            gBBill.Text = "MẶT HÀNG CẦN 'XOÁ':" + ms + ": " + ten + " ĐANG CÒN CÁC PHIẾU TÍNH TIỀN (BILLs) SAU";
            gBInvoice.Text = "MẶT HÀNG CẦN 'XOÁ':" + ms + ": " + ten + " ĐANG CÒN CÁC HÓA ĐƠN (INVOICEs) SAU";
        }//private void Fr2SPDD_DDTM02RBTV_Load(object sender, EventArgs e)



        ///////////////////////////////////////
        ///CHỌN 1 CHI TIẾT / CÁC DATAGRIDVIEW///////////////
        //////////////////////////////////////


        /// <summary>
        /// THỦ TỤC CHỌN TỒN HÀNG ......CẦN THANH LÝ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        static int vtton = 0; //Biến toàn cục static lưu vị trí Tồn hàng đang chọn để Thanh lý
        static string macs = "";//Biến toàn cục static mã Cơ sở bán hàng đang chọn để Thanh lý
        private void dataGridViewTon_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            vtton = e.RowIndex;//vị trí chọn
            macs = dataGridViewTon.Rows[vtton].Cells[0].Value.ToString().Trim();
            btn1Ton.Enabled = true; //cho Hủy 1...
        }//private void dataGridViewTon_CellContentClick_1
        /// <summary>
        /// THỦ TỤC CHỌN CHI TIẾT Invoce ......CẦN HỦY
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        static int vti = 0; //Biến toàn cục static lưu vị trí CT BILL đang chọn để Hủy
        static string mai = "";//Biến toàn cục static mã Phiếu tính tiền đang chọn để Hủy
        private void dataGridViewInvoice_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            vti = e.RowIndex;//vị trí chọn
            mai = dataGridViewBill.Rows[vtctbill].Cells[0].Value.ToString().Trim();
            btn1Invoice.Enabled = true; //cho Hủy 1...
        }
        /// <summary>
        /// THỦ TỤC CHỌN CHI TIẾT BILL ......CẦN HỦY
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        static int vtctbill = 0; //Biến toàn cục static lưu vị trí CT BILL đang chọn để Hủy
        static string map = "";//Biến toàn cục static mã Phiếu tính tiền đang chọn để Hủy
        private void dataGridViewBill_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

            vtctbill = e.RowIndex;//vị trí chọn
            map = dataGridViewBill.Rows[vtctbill].Cells[0].Value.ToString().Trim();
            btn1Bill.Enabled = true; //cho Hủy 1...
        }

        ///////////////////////////////////////
        ///LOAD CÁC DATAGRIDVIEW///////////////
        //////////////////////////////////////
        /// <summary>
        /// LOAD TỒN HÀNG
        /// </summary>
        private void TonHang_Load()
        {
            try
            {
                // TODO: This line of code loads data into the 'g206VXTSaleDSTON.TONHANG' table. You can move, or remove it, as needed.
                this.tonKhoTableAdapter.Fill(this.g22AnSaleDDTNtkRBTV.TonKho, ms);
            }
            catch (System.Exception) { }

            if (dataGridViewTon.Rows.Count < 2)//luôn có 1 dòng "chờ", nên phải từ 2 rows trở lên = xem là có dữ liệu
            {
                btn1Ton.Enabled = false; //khóa lại
                btnATon.Enabled = false;
            }
            else
            {
//                btn1Ton.Enabled = true; //mở ra
                btnATon.Enabled = true;
            }
        }//private void TonHang_Load()

        /// <summary>
        /// LOAD CHI TIẾT PHIẾU TÍNH TIỀN (BILL)
        /// </summary>
        private void ctBill_Load()
        {
            try
            {
                // TODO: This line of code loads data into the 'g206VXTSaleDSBILL.CT_BILL' table. You can move, or remove it, as needed.
                this.cT_BILLTableAdapter.Fill(this.g22AnSleDDTNctbRBTV.CT_BILL, ms);
            }
            catch (System.Exception) { }

            if (dataGridViewBill.Rows.Count < 2)
            {
                btn1Bill.Enabled = false; //khóa lại
                btnABill.Enabled = false;
            }
            else
            {
//                btn1Bill.Enabled = true; //Mở
                btnABill.Enabled = true;
            }
        }//private void ctBill_Load()



        /// <summary>
        /// LOAD CHI TIẾT HÓA ĐƠN (INVOICE)
        /// </summary>
        private void ctHD_Load()
        {
            try
            {
                // TODO: This line of code loads data into the 'g206VXTSaleDSHD.CT_HD' table. You can move, or remove it, as needed.
                this.cT_HDTableAdapter.Fill(this.g22AnSaleDDTNctiRBTV.CT_HD, ms);
            }
            catch (System.Exception) { }

            if (dataGridViewInvoice.Rows.Count < 2)
            {
                btn1Invoice.Enabled = false; //khóa lại
                btnAInvoice.Enabled = false;
            }
            else
            {
 //               btn1Invoice.Enabled = true; //Mở
                btnAInvoice.Enabled = true;
            }
        }//private void ctHD_Load()












        /// <summary>
        /// THANH LÝ 1 TỒN
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn1Ton_Click(object sender, EventArgs e)
        {
            //B1: Hỏi xác nhận 
            DialogResult ch = MessageBox.Show("Thiệt Thanh lý tồn kho của mặt hàng: " + ten + ": tại cơ sở bán hàng có mã: " + macs + ": đúng không (Y/N)?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //B2: XÓA
            if (ch == DialogResult.Yes)
            {
                try
                {
                    tonKhoTableAdapter.Delete(macs, ms);
                    MessageBox.Show("Xóa xong rồi, xem đi !");
                }
                catch (System.Exception ex) { MessageBox.Show("Lỗi Thanh lý 1 tồn hàng: " + ex.Message); }
            }
            //B3: Tải BD lên DataGridView sau khi xóa
            TonHang_Load();
            btn1Ton.Enabled = false; //khóa lại
        }//private void btn1Ton_Click(object sender, EventArgs e)
        /// <summary>
        /// THANH LÝ TẤT CẢ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnATon_Click(object sender, EventArgs e)
        {
            //B1: Hỏi xác nhận 
            DialogResult ch = MessageBox.Show("Thiệt Thanh lý tồn kho của mặt hàng: " + ten + ": tại TẤT CẢ các cơ sở bán hàng đúng không (Y/N)?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //B2: XÓA
            if (ch == DialogResult.Yes)
            {
                try
                {
                    tonKhoTableAdapter.XoaAtk(ms);
                    MessageBox.Show("Xóa xong rồi, xem đi !");
                }
                catch (System.Exception ex) { MessageBox.Show("Lỗi Thanh lý ALL tồn hàng: " + ex.Message); }
            }
            //B3: Tải BD lên DataGridView sau khi xóa
            TonHang_Load();
            btn1Ton.Enabled = false; //khóa lại

        }//btnATon_Click(object sender, EventArgs e)

        /// <summary>
        /// HỦY 1 BILL
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn1Bill_Click(object sender, EventArgs e)
        {
            //B1: Hỏi xác nhận 
            DialogResult ch = MessageBox.Show("Thiệt Hủy chi tiết Bill của mặt hàng: " + ten + ": trên Bill có mã: " + map + ": đúng không (Y/N)?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //B2: XÓA
            if (ch == DialogResult.Yes)
            {
                try
                {
                    cT_BILLTableAdapter.Delete(map, ms);
                    MessageBox.Show("Xóa xong rồi, xem đi !");
                }
                catch (System.Exception ex) { MessageBox.Show("Lỗi Hủy 1 chi tiết: " + ex.Message); }
            }
            //B3: Tải BD lên DataGridView sau khi xóa
            ctBill_Load();
            btn1Bill.Enabled = false; //khóa lại
        }

      

        /// <summary>
        /// HỦY TẤT CẢ BILL
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnABill_Click(object sender, EventArgs e)
        {
            //B1: Hỏi xác nhận 
            DialogResult ch = MessageBox.Show("Thiệt Hủy TẤT CẢ chi tiết Bill của mặt hàng: " + ten + ": đúng không (Y/N)?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //B2: XÓA
            if (ch == DialogResult.Yes)
            {
                try
                {
                    cT_BILLTableAdapter.XoaAb(ms);
                    MessageBox.Show("Xóa xong rồi, xem đi !");
                }
                catch (System.Exception ex) { MessageBox.Show("Lỗi Hủy ALL chi tiết: " + ex.Message); }
            }
            //B3: Tải BD lên DataGridView sau khi xóa
            ctBill_Load();
            btn1Bill.Enabled = false; //khóa lại

        }

        


        /// <summary>
        /// huy 1 invoice
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn1Invoice_Click(object sender, EventArgs e)
        {
            //B1: Hỏi xác nhận 
            DialogResult ch = MessageBox.Show("Thiệt Hủy chi tiết Invoice của mặt hàng: " + ten + ": trên Invoice có mã: " + mai + ": đúng không (Y/N)?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //B2: XÓA
            if (ch == DialogResult.Yes)
            {
                try
                {
                    cT_HDTableAdapter.Delete(mai, ms);
                    MessageBox.Show("Xóa xong rồi, xem đi !");
                }
                catch (System.Exception ex) { MessageBox.Show("Lỗi Hủy 1 chi tiết: " + ex.Message); }
            }
            //B3: Tải BD lên DataGridView sau khi xóa
            ctBill_Load();
            btn1Bill.Enabled = false; //khóa lại
        }
        /// <summary>
        /// huy tat ca hd
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAInvoice_Click(object sender, EventArgs e)
        {
            //B1: Hỏi xác nhận 
            DialogResult ch = MessageBox.Show("Thiệt Hủy TẤT CẢ chi tiết Invoice của mặt hàng: " + ten + ": đúng không (Y/N)?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //B2: XÓA
            if (ch == DialogResult.Yes)
            {
                try
                {
                    cT_HDTableAdapter.XoaAHD(ms);
                    MessageBox.Show("Xóa xong rồi, xem đi !");
                }
                catch (System.Exception ex) { MessageBox.Show("Lỗi Hủy ALL chi tiết: " + ex.Message); }
            }
            //B3: Tải BD lên DataGridView sau khi xóa
            ctBill_Load();
            btn1Bill.Enabled = false; //khóa lại
        }//private void btnAInvoice_Click
    }
}
