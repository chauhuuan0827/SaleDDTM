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
    public partial class BFrQLDDTM02An : Form
    {
        public BFrQLDDTM02An()
        {
            InitializeComponent();
        }
        //KHAI BÁO CÁC THAM SỐ TOÀN CỤC 
        static string name = "", pass = ""; //dùng cho thủ tục đăng nhập
        string apppath = System.IO.Path.GetDirectoryName(System.IO.Path.GetDirectoryName(Application.StartupPath)) + "\\Images\\";  //BIẾN TOÀN CỤC LƯU ĐƯỜNG DẪN ĐẾ THƯ MỤC LƯU APP BÀI LÀM NAY

        private void BFrQLDDTM02An_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'bG202AnSaleDDTNNSX.NSX' table. You can move, or remove it, as needed.
            this.nSXTableAdapter.Fill(this.bG202AnSaleDDTNNSX.NSX);
            // TODO: This line of code loads data into the 'bG22AnSaleDDTMSP.DMSPDD' table. You can move, or remove it, as needed.
            this.dMSPDDTableAdapter.Fill(this.bG22AnSaleDDTMSP.DMSPDD);

        }

        /// <summary>
        /// thoat
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bbtnExit_Click(object sender, EventArgs e)
        {
            DialogResult ch = MessageBox.Show("THIỆT THOÁT (Y/N)?", "XÁC NHẬN", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ch == DialogResult.Yes)//NSD đã chọn Yes
            {
                Application.Exit();//thoát chương trình
            }
        }// private void bbtnExit_Click(object sender, EventArgs e)

        private void bbtnMain_Click(object sender, EventArgs e)
        {
            DialogResult ch = MessageBox.Show("THIỆT VỀ MÀN HÌNH TRƯỚC KHÔNG (Y/N)?", "XÁC NHẬN", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ch == DialogResult.Yes)//NSD đã chọn Yes
            {
                this.Close();
            }
        }
        /// <summary>
        /// chon hinh
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //CHỌN HÌNH MẪU CHO SẢN PHẨM
        static string oldimage, imagechoose = "";//Biến toàn cục Lưu tên file hình mà NSD đã chọn (Thêm/Sửa) đối với PictureBox

        private void pictureBoxHinh_Click(object sender, EventArgs e)
        {
            DialogResult ch = openFileDialog1.ShowDialog();//Mở hộp thoại cho phép NSD chọn hình cho sản phẩm
            if (ch == DialogResult.OK)//NSD đồng ý với hình đã chọn
            {
                //1. Lưu tên file của hình vừa copy nêu trên vào biến toàn cục để sau này (Thêm/Sửa) sẽ cập nhật vào thuộc tính hinh trong Table DMSPDD của DB
                imagechoose = System.IO.Path.GetFileName(openFileDialog1.FileName);
                //chỉ lấy tên file ko lấy đường dẫn

                //2. Copy hình vừa chọn vào thư mục hình Images của App (để sau này Copy App đi nơi khác thư mục hình sẽ tự đi theo)
                try
                {
                    System.IO.File.Copy(openFileDialog1.FileName, apppath + imagechoose, true); // chồng lên hình cũ nếu có
                }
                catch (System.Exception ex) { MessageBox.Show("Có lỗi sao chép hình vào thư mục của App" + ex.Message); }
            }
        }

        private void bbtnThem_Click(object sender, EventArgs e)
        {
            //B1: ĐÓNG _ MỞ : ĐƯỢC PHÉP HAY KHÔNG ĐƯỢC THAY ĐỔI CÁC TEXTBOX THÔNG TIN MẶT HÀNG
            btxtmsmh.Enabled = !btxtmsmh.Enabled;
            btxttenmh.Enabled = !btxttenmh.Enabled;
            btxtgiaban.Enabled = !btxtgiaban.Enabled;
            btxtchip.Enabled = !btxtchip.Enabled;
            btxtmota.Enabled = !btxtmota.Enabled;
            bdateTimePickerNgayn.Enabled = !bdateTimePickerNgayn.Enabled;
            btxtBh.Enabled = !btxtBh.Enabled;
            bcheckBoxConhang.Enabled = !bcheckBoxConhang.Enabled;
            btxtt.Enabled = !btxtt.Enabled;
            btxts.Enabled = !btxts.Enabled;
            bcomboBoxNhasx.Enabled = !bcomboBoxNhasx.Enabled;
            btxtpin.Enabled = !btxtpin.Enabled;
            btxtmh.Enabled = !btxtmh.Enabled;
            btxtmau.Enabled = !btxtmau.Enabled;

            //khóa các nút lệnh khác (ngoại trừ được Đóng form)
            bbtnSua.Enabled = !bbtnSua.Enabled;
            bbtnXoa.Enabled = !bbtnXoa.Enabled;
            bbtnExit.Enabled = !bbtnExit.Enabled;
            bbtnMain.Enabled = !bbtnMain.Enabled;
            if (bbtnThem.Text == "Thêm SP mới")//CHUẨN BỊ THÊM MH
            {//MỞ CHẾ ĐỘ CHO NSD CHỌN HÌNH CHO SP MỚI
                pictureBoxHinh.ImageLocation = apppath + "ImageChoose.png";
                //hiện hình ảnh thông báo NSD chọn hình
                pictureBoxHinh.Click += new EventHandler(pictureBoxHinh_Click);
                // cho phép NSD click vào PictureBox để chọn hình (Gán Event Click vào PictureBox Hình)
                //XÓA CÁC Ô TEXTBOX TRONG CHI TIẾT Ơ BÊN trên ĐỂ CHUẨN BỊ CHO NSD NHẬP THÔNG TIN SP MỚI
                btxtmsmh.Text = "";
                btxttenmh.Text = "";
                btxtgiaban.Text = "";
                btxtchip.Text = "";
                btxtmota.Text = "";
                bdateTimePickerNgayn.Text = "";
                btxtBh.Text = "";
                bcheckBoxConhang.Checked = true;
                btxtt.Text = "";
                btxts.Text = "";
                //                comboBoxNhasx.SelectedValue.ToString = "";
                btxtpin.Text = "";
                btxtmh.Text = "";
                btxtmau.Text = "";
                bbtnThem.Text = "Lưu (Thêm)";
                //đổi nhãn Thêm => Lưu (sau khi NSD đã nhập đủ các thông tin MH mới)
            }
            else //THÊM MH MỚI VÀO DATABASE VÀ HIỆN LÊN DATAGRIDVIEW
            {//1. THÊM SP MỚI VÀO DB 
                try
                {//nếu NSD ko chọn hình thì biến toàn cục imagechoose = "" và có nghĩa là SP mới chưa có hình ảnh & ComboBox...ValueMenber = msnhom
                    if (imagechoose != "") imagechoose = apppath + btxtmsmh.Text.Trim() + imagechoose;
                    dMSPDDTableAdapter.Insert(btxtmsmh.Text, btxttenmh.Text, double.Parse(btxtgiaban.Text.Trim()), btxtmota.Text, imagechoose, bdateTimePickerNgayn.Value, bcomboBoxNhasx.SelectedValue.ToString().Trim(), btxtmh.Text, btxtt.Text, btxts.Text, btxtpin.Text, btxtchip.Text, btxtBh.Text, btxtmau.Text, bcheckBoxConhang.Checked);
                    MessageBox.Show("THÊM XONG, XEM ĐI");
                }
                catch (System.Exception ex) { MessageBox.Show("CÓ LỖI KHI THÊM SP MỚI " + ex.Message); }

                //2. TẢI LẠI DL SAU KHI THÊM SP MỚI TỪ DB LÊN DATAGRIDWIEW ĐỂ NSD BIẾT KQ [COPY code TỪ form_load OR Combobox_selectIndexChanhe]
                try
                {
                    // Tai ds cac MH vao DataGridView ben duoi theo Nhom MH da chon trong ComboBox phia tren
                    this.dMSPDDTableAdapter.Fill(this.bG22AnSaleDDTMSP.DMSPDD);
                }
                catch (System.Exception) { } //bat moi he thong = tranh truong hop ctr bi dung  dot ngot

                //3. THAY ĐỔI TRANG THÁI THÊM SP MỚI
                //               pictureBoxHinh.Click -= pictureBoxHinh_Click;//KHÔNG CHO NSD click vào PictureBoX hình 
                //              (Xóa Event Click của PictureBox Hình)
                //               pictureBoxHinh.ImageLocation = ""; //GỠ BỎ hình ảnh thông báo chọn hình
                bbtnThem.Text = "Thêm sản phẩm mới";//đổi nhãn trả lại Lưu => Thêm (thêm thêm mới MH khác)
            }


        }

        private void bbtnXoa_Click(object sender, EventArgs e)
        {
            //B1: Hỏi xác nhận 
            DialogResult ch = MessageBox.Show("Thiệt xóa sản phẩm có mã " + btxtmsmh.Text.Trim() + " không(Y / N) ? ", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            //B2: XÓA
            if (ch == DialogResult.Yes)
            {
                try
                {
                    dMSPDDTableAdapter.Delete(btxtmsmh.Text.Trim());
                    MessageBox.Show("Xóa xong rồi, xem đi !");
                    System.IO.File.Delete(pictureBoxHinh.ImageLocation);//xóa hình trong tm  
                    DialogResult c = MessageBox.Show("Có xóa luôn hình không?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question); if (c == DialogResult.No)
                    {
                        try
                        {
                            imagechoose = System.IO.Path.GetFileName(pictureBoxHinh.ImageLocation); //lay ten hinh cu 
                            System.IO.File.Copy(pictureBoxHinh.ImageLocation, apppath + "z\\" + imagechoose);
                            MessageBox.Show("hình cũ copy vao thu muc ...\\z nha !");
                        }
                        catch (System.Exception ex) { MessageBox.Show("Lỗi lưu lại hình cũ vào khỏi hệ thống" + ex.Message); }
                    }
                    else
                    {
                        MessageBox.Show("Xóa hình cũ nha !");
                    }
                    System.IO.File.Delete(pictureBoxHinh.ImageLocation);//xóa hình trong tm  

                }
                catch (System.Exception ex) { MessageBox.Show("Có lỗi XÓA sản phẩm");               }
                Fr2SPDD_DDTM02RBTV fr = new Fr2SPDD_DDTM02RBTV(btxtmsmh.Text.Trim(), btxttenmh.Text.Trim());
                fr.ShowDialog();
            }
            //B3: Tải BD lên DataGridView sau khi xóa
            try
            {
                this.dMSPDDTableAdapter.Fill(this.bG22AnSaleDDTMSP.DMSPDD);
            }
            catch (System.Exception) { } //bat moi he thong = tranh truong hop ctr bi dung  dot ngot
        }

        private void bbtnSua_Click(object sender, EventArgs e)
        {
            //B1: ĐÓNG _ MỞ : ĐƯỢC PHÉP HAY KHÔNG ĐƯỢC SỬA
            //txtCTmsmh.Enabled = !txtCTmsmh.Enabled;
            btxttenmh.Enabled = !btxttenmh.Enabled;
            btxtgiaban.Enabled = !btxtgiaban.Enabled;
            btxtchip.Enabled = !btxtchip.Enabled;
            btxtmota.Enabled = !btxtmota.Enabled;
            bdateTimePickerNgayn.Enabled = !bdateTimePickerNgayn.Enabled;
            btxtBh.Enabled = !btxtBh.Enabled;
            bcheckBoxConhang.Enabled = !bcheckBoxConhang.Enabled;
            btxtt.Enabled = !btxtt.Enabled;
            btxts.Enabled = !btxts.Enabled;
            bcomboBoxNhasx.Enabled = !bcomboBoxNhasx.Enabled;
            btxtpin.Enabled = !btxtpin.Enabled;
            btxtmh.Enabled = !btxtmh.Enabled;
            btxtmau.Enabled = !btxtmau.Enabled;

            //khóa các nút lệnh khác (ngoại trừ được Đóng form)
            bbtnThem.Enabled = !bbtnThem.Enabled;
            bbtnXoa.Enabled = !bbtnXoa.Enabled;
            bbtnExit.Enabled = !bbtnExit.Enabled;
            bbtnMain.Enabled = !bbtnMain.Enabled;

            if (bbtnSua.Text == "Sửa SP")//Bắt đầu sửa
            {//MỞ CHẾ ĐỘ CHO NSD CHỌN HÌNH MỚI CHO SP
                oldimage = pictureBoxHinh.ImageLocation; // lưu giữ path và filename của hình cũ trước khi bị thay thế
                pictureBoxHinh.ImageLocation = apppath + "ImageChoose.png";   //hiện hình ảnh thông báo NSD chọn hình
                pictureBoxHinh.Click += new EventHandler(pictureBoxHinh_Click);  // cho phép NSD click vào PictureBox để chọn hình (Gán Event Click vào PictureBox Hình)
                //B2: HƯỚNG DẪN CÁCH SỬA
                MessageBox.Show("Quý vị SỬA trong các ô Text bên phải, CHỌN LẠI HÌNH BẰNG CÁCH CLICK VÀO HÌNH ĐỂ CHỌN HÌNH MỚI THAY THẾ");

                bbtnSua.Text = "Lưu (Sửa)";
            }
            else //LƯU SAU KHI SỬA XONG
            {
                //KIỂM TRA NSD CÓ THAY ĐỔI HÌNH HAY KHÔNG: NẾU CHỌN HÌNH MỚI THÌ THAY; NẾU KHÔNG THÌ GIỮ LẠI HÌNH CŨ
                if (imagechoose == "") imagechoose = oldimage;  //NSD KHÔNG THAY ĐỔI HÌNH (NÊN giữa lại hình cũ)               
                try
                { //B3: lưu DB double.Parse(txtgiaban.Text.Trim()), txtmota.Text, "", dateTimePickerNgayn.Value, comboBoxNhasx.SelectedValue.ToString().Trim(), txtmh.Text, txtt.Text, txts.Text, txtpin.Text, txtchip.Text, txtBh.Text, txtmau.Text, checkBoxConhang.Checked, txtmsmh.Text
                    dMSPDDTableAdapter.Update(btxttenmh.Text, double.Parse(btxtgiaban.Text.Trim()), btxtmota.Text, imagechoose, bdateTimePickerNgayn.Text, bcomboBoxNhasx.SelectedValue.ToString().Trim(), btxtmh.Text, btxtt.Text, btxts.Text, btxtpin.Text, btxtchip.Text, btxtBh.Text, btxtmau.Text, bcheckBoxConhang.Checked, btxtmsmh.Text);
                    MessageBox.Show("Sửa xong rồi, xem đi !");
                }
                catch (System.Exception ex) { MessageBox.Show("Có lỗi sửa chữa thông tin sản phẩm " + ex.Message); }
                //B4: ĐỔI NHÃN 
                bbtnSua.Text = "Sửa Sản phẩm";
                //                pictureBoxHinh.Click -= pictureBoxHinh_Click;
                //KHÔNG CHO NSD click vào PictureBoX hình (Xóa Event Click của PictureBox Hình)
                pictureBoxHinh.ImageLocation = ""; //GỠ BỎ hình ảnh thông báo chọn hình

                //B5: Tải BD lên DataGridView sau khi xóa
                try
                {
                    // Tai ds cac MH vao DataGridView ben duoi theo Nhom MH da chon trong ComboBox phia tren
                    this.dMSPDDTableAdapter.Fill(this.bG22AnSaleDDTMSP.DMSPDD);
                }
                catch (System.Exception) { } //bat moi he thong = tranh truong hop ctr bi dung  dot ngot
            }

        }
    }//public partial class BFrQLDDTM02An : Form
}
