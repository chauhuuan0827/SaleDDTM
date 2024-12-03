using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.LinkLabel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

namespace G202CHAnSaleDDTM
{
    public partial class Fr2QLDMSPDD_DDTM02 : Form
    {
        public Fr2QLDMSPDD_DDTM02()
        {
            InitializeComponent();
        }

        //KHAI BÁO CÁC THAM SỐ TOÀN CỤC 
        static string name = "", pass = ""; //dùng cho thủ tục đăng nhập
        string apppath = System.IO.Path.GetDirectoryName(System.IO.Path.GetDirectoryName(Application.StartupPath)) + "\\Images\\";  //BIẾN TOÀN CỤC LƯU ĐƯỜNG DẪN ĐẾ THƯ MỤC LƯU APP BÀI LÀM NAY


        private void Fr2QLDMSPDD_DDTM02_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the '_1G202AnSaleDDTNDataSet1.NSX' table. You can move, or remove it, as needed.
            this.nSXTableAdapter.Fill(this._1G202AnSaleDDTNDataSet1.NSX);
            // TODO: This line of code loads data into the '_1G202AnSaleDDTNDataSet.DMSPDD' table. You can move, or remove it, as needed.
            this.dMSPDDTableAdapter.Fill(this._1G202AnSaleDDTNDataSet.DMSPDD);

        }
        /// <summary>
        /// Thoát
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
        /// <summary>
        /// đóng form này, về màn hình chính
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMain_Click(object sender, EventArgs e)
        {
            DialogResult ch = MessageBox.Show("THIỆT VỀ MÀN HÌNH TRƯỚC KHÔNG (Y/N)?", "XÁC NHẬN", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ch == DialogResult.Yes)//NSD đã chọn Yes
            {
                this.Close();
            }
        }


       
      
       

        /// <summary>
        /// thêm sp mới DĐTM
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnThem_Click(object sender, EventArgs e)
        {       //B1: ĐÓNG _ MỞ : ĐƯỢC PHÉP HAY KHÔNG ĐƯỢC THAY ĐỔI CÁC TEXTBOX THÔNG TIN MẶT HÀNG
            txtmsmh.Enabled = !txtmsmh.Enabled;
            txttenmh.Enabled = !txttenmh.Enabled;
            txtgiaban.Enabled = !txtgiaban.Enabled;
            txtchip.Enabled = !txtchip.Enabled;
            txtmota.Enabled = !txtmota.Enabled;
            dateTimePickerNgayn.Enabled = !dateTimePickerNgayn.Enabled;
            txtBh.Enabled = !txtBh.Enabled;
            checkBoxConhang.Enabled = !checkBoxConhang.Enabled;
            txtt.Enabled = !txtt.Enabled;
            txts.Enabled = !txts.Enabled;
            comboBoxNhasx.Enabled = !comboBoxNhasx.Enabled;
            txtpin.Enabled = !txtpin.Enabled;
            txtmh.Enabled = !txtmh.Enabled;
            txtmau.Enabled = !txtmau.Enabled;   
            
            //khóa các nút lệnh khác (ngoại trừ được Đóng form)
            btnSua.Enabled = !btnSua.Enabled;
            btnXoa.Enabled = !btnXoa.Enabled;
            btnExit.Enabled = !btnExit.Enabled;
            btnMain.Enabled = !btnMain.Enabled;           
            if (btnThem.Text == "Thêm SP mới")//CHUẨN BỊ THÊM MH//CHUẨN BỊ THÊM TU
            {
                //MỞ CHẾ ĐỘ CHO NSD CHỌN HÌNH CHO SP MỚI
                pictureBoxHinh.ImageLocation = apppath + "ImageChoose.png";
                //hiện hình ảnh thông báo NSD chọn hình
                pictureBoxHinh.Click += new EventHandler(pictureBoxHinh_Click);
                // cho phép NSD click vào PictureBox để chọn hình (Gán Event Click vào PictureBox Hình)

                //XÓA CÁC Ô TEXTBOX TRONG CHI TIẾT Ở BÊN PHẢI ĐỂ CHUẨN BỊ CHO NSD NHẬP THÔNG TIN TU MỚI
                txtmsmh.Text = "";
                txttenmh.Text = "";
                txtgiaban.Text = "";
                txtchip.Text = "";
                txtmota.Text = "";
                dateTimePickerNgayn.Text = "";
                txtBh.Text = "";
                checkBoxConhang.Checked = true;
                txtt.Text = "";
                txts.Text = "";
                //                comboBoxNhasx.SelectedValue.ToString = "";
                txtpin.Text = "";
                txtmh.Text = "";
                txtmau.Text = "";
                btnThem.Text = "Lưu (Thêm)"; ;//đổi nhãn Thêm => Lưu (sau khi NSD đã nhập đủ các thông tin MH mới)
            }
            else//THÊM MH MỚI VÀO DATABASE VÀ HIỆN LÊN DATAGRIDVIEW
            {   //1. THÊM SP MỚI VÀO DB 
                try
                {

                    dMSPDDTableAdapter.Insert(txtmsmh.Text, txttenmh.Text, double.Parse(txtgiaban.Text.Trim()), txtmota.Text, apppath + txtmsmh.Text.Trim() + imagechoose, dateTimePickerNgayn.Value, comboBoxNhasx.SelectedValue.ToString().Trim(), txtmh.Text, txtt.Text, txts.Text, txtpin.Text, txtchip.Text, txtBh.Text, txtmau.Text, checkBoxConhang.Checked);
               
                    MessageBox.Show("THÊM XONG, XEM ĐI");
                }
                catch (System.Exception ex) { MessageBox.Show("Lỗi thêm SP mới : " + ex.Message); }

                //2. TẢI LẠI DL SAU KHI THÊM SP MỚI TỪ DB LÊN DATAGRIDWIEW ĐỂ NSD BIẾT KQ [COPY code TỪ form_load OR Combobox_selectIndexChange]
                try
                {
                    this.dMSPDDTableAdapter.Fill(this._1G202AnSaleDDTNDataSet.DMSPDD);
                }
                catch (System.Exception) { }

                //3. THAY ĐỔI TRANG THÁI THÊM TU MỚI
                btnThem.Text = "Thêm SP mới";//đổi nhãn trả lại Lưu => Thêm (thêm thêm mới MH khác)
                //pictureBoxHinh.Click -= ImageChoose;//KHÔNG CHO NSD click vào PictureBoX hình  
                //(Xóa Event Click của PictureBox Hình) 
                //pictureBoxHinh.ImageLocation = ""; //GỠ BỎ hình ảnh thông báo chọn hình                 
            }
        }
        //CHỌN HÌNH MẪU CHO SẢN PHẨM
        static string oldimage, imagechoose = "";//Biến toàn cục Lưu tên file hình mà NSD đã chọn (Thêm/Sửa) đối với PictureBox

        private void pictureBoxHinh_Click(object sender, EventArgs e)
        {
            DialogResult ch = openFileDialog1.ShowDialog();//Mở hộp thoại cho phép NSD chọn hình cho nhân sự
            if (ch == DialogResult.OK)//NSD đồng ý với hình đã chọn 
            {
                //1. Lưu tên file của hình vừa copy nêu trên vào biến toàn cục để sau này (Thêm/Sửa) sẽ cập nhật vào thuộc tính hình trong Table NS của DB
                imagechoose = System.IO.Path.GetFileName(openFileDialog1.FileName);                 //chỉ lấy tên file ko lấy đường dẫn 

                //2. Copy hình vừa chọn vào thư mục hình Images của App(để sau này Copy App đi nơi khác thư mục hình sẽ tự đi theo)
                try
                {
                    System.IO.File.Copy(openFileDialog1.FileName, apppath + txtmsmh.Text.Trim() + imagechoose, true); //Chồng lên hình cũ nếu có 
                }
                catch (System.Exception ex) { MessageBox.Show("Có lỗi sao chép hình vào thư mục của App" + ex.Message); }
            }
        }

        /// <summary>
        /// Sửa sp
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSua_Click(object sender, EventArgs e)
        {
            //B1: ĐÓNG _ MỞ : ĐƯỢC PHÉP HAY KHÔNG ĐƯỢC SỬA
            //txtCTmsmh.Enabled = !txtCTmsmh.Enabled;
            txttenmh.Enabled = !txttenmh.Enabled;
            txtgiaban.Enabled = !txtgiaban.Enabled;
            txtchip.Enabled = !txtchip.Enabled;
            txtmota.Enabled = !txtmota.Enabled;
            dateTimePickerNgayn.Enabled = !dateTimePickerNgayn.Enabled;
            txtBh.Enabled = !txtBh.Enabled;
            checkBoxConhang.Enabled = !checkBoxConhang.Enabled;
            txtt.Enabled = !txtt.Enabled;
            txts.Enabled = !txts.Enabled;
            comboBoxNhasx.Enabled = !comboBoxNhasx.Enabled;
            txtpin.Enabled = !txtpin.Enabled;
            txtmh.Enabled = !txtmh.Enabled;
            txtmau.Enabled = !txtmau.Enabled;

            //khóa các nút lệnh khác (ngoại trừ được Đóng form)
            btnThem.Enabled = !btnThem.Enabled;
            btnXoa.Enabled = !btnXoa.Enabled;
            btnExit.Enabled = !btnExit.Enabled;
            btnMain.Enabled = !btnMain.Enabled;
                       if (btnSua.Text == "Sửa SP")//Bắt đầu sửa
                       {//MỞ CHẾ ĐỘ CHO NSD CHỌN HÌNH MỚI CHO SP
                           oldimage = pictureBoxHinh.ImageLocation;
                           pictureBoxHinh.ImageLocation = apppath + "ImageChoose.png"; //hiện hình ảnh thông báo NSD chọn hình
                           pictureBoxHinh.Click += new EventHandler(pictureBoxHinh_Click);// cho phép NSD click vào PictureBox để chọn hình (Gán Event Click vào PictureBox Hình))
                                                                                          //B2: HƯỚNG DẪN CÁCH SỬA
                           MessageBox.Show("Quý vị SỬA trong các ô Text bên trên, CHỌN LẠI HÌNH BẰNG CÁCH CLICK VÀO HÌNH ĐỂ CHỌN HÌNH MỚI THAY THẾ");
                           btnSua.Text = "Lưu (Sửa)";
                       }
                       else //LƯU SAU KHI SỬA XONG
                       {//KIỂM TRA NSD CÓ THAY ĐỔI HÌNH HAY KHÔNG: NẾU CHỌN HÌNH MỚI THÌ THAY; NẾU KHÔNG THÌ GIỮ LẠI HÌNH CŨ
                           if (imagechoose == "") imagechoose = oldimage; //NSD KHÔNG THAY ĐỔI HÌNH (NÊN giữa lại hình cũ)
                           if (oldimage != null)
                           {
                               DialogResult c = MessageBox.Show("Có giữ lại hình cũ không ?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question); //NSD KHÔNG THAY ĐỔI HÌNH (NÊN giữa lại hình cũ)
                               if (c == DialogResult.Yes)
                               {
                                   System.IO.File.Copy(oldimage, apppath + "z\\" + imagechoose, true);
                                   MessageBox.Show("hình cũ copy vao  .....\\z nha !");
                               }
                               else
                               {
                                   MessageBox.Show("Xóa hình cũ nha !");
                               }
                               System.IO.File.Delete(apppath + oldimage);
                               }
                           try
                           { //B3: lưu DB double.Parse(txtgiaban.Text.Trim()), txtmota.Text, "", dateTimePickerNgayn.Value, comboBoxNhasx.SelectedValue.ToString().Trim(), txtmh.Text, txtt.Text, txts.Text, txtpin.Text, txtchip.Text, txtBh.Text, txtmau.Text, checkBoxConhang.Checked, txtmsmh.Text
                               dMSPDDTableAdapter.Update(txttenmh.Text, double.Parse(txtgiaban.Text.Trim()), txtmota.Text, apppath + txtmsmh.Text.Trim() + imagechoose, dateTimePickerNgayn.Text, comboBoxNhasx.SelectedValue.ToString().Trim(), txtmh.Text, txtt.Text, txts.Text, txtpin.Text, txtchip.Text, txtBh.Text, txtmau.Text, checkBoxConhang.Checked, txtmsmh.Text);
                               MessageBox.Show("Sửa xong rồi, xem đi !");
                               pictureBoxHinh.ImageLocation = "";
                           }
                           catch (System.Exception ex) { MessageBox.Show("Có lỗi sửa chữa thông tin sản phẩm " + ex.Message); }
                           //B4: ĐỔI NHÃN 
                           btnSua.Text = "Sửa SP";
                           //                pictureBoxHinh.Click -= pictureBoxHinh_Click;
                           //KHÔNG CHO NSD click vào PictureBoX hình (Xóa Event Click của PictureBox Hình)
                           //             pictureBoxHinh.ImageLocation = ""; //GỠ BỎ hình ảnh thông báo chọn hình

                           //B5: Tải BD lên DataGridView sau khi xóa
                           try
                           {
                               // Tai ds cac MH vao DataGridView ben duoi theo Nhom MH da chon trong ComboBox phia tren
                          this.dMSPDDTableAdapter.Fill(this._1G202AnSaleDDTNDataSet.DMSPDD);
                           }
                           catch (System.Exception) { } //bat moi he thong = tranh truong hop ctr bi dung  dot ngot
                       }         
        }


        /// <summary>
        /// Xóa sp
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnXoa_Click(object sender, EventArgs e)
        {
            /*  //B1: Hỏi xác nhận 
              DialogResult ch = MessageBox.Show("Thiệt xóa sản phẩm có mã " + txtmsmh.Text.Trim() + " không(Y / N) ? ", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

              //B2: XÓA          
              if (ch == DialogResult.Yes)
              {
                  try
                  {
                      dMSPDDTableAdapter.Delete(txtmsmh.Text.Trim());
                      MessageBox.Show("Xóa xong rồi, xem đi !");


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
                  catch (System.Exception ex) { MessageBox.Show("Có lỗi XÓA sản phẩm"); }
                  Fr2SPDD_DDTM02RBTV fr = new Fr2SPDD_DDTM02RBTV(txtmsmh.Text.Trim(), txttenmh.Text.Trim());
                  fr.ShowDialog();
              }
              //B3: Tải BD lên DataGridView sau khi xóa
              try
              {
                  this.dMSPDDTableAdapter.Fill(this._1G202AnSaleDDTNDataSet.DMSPDD);
              }
              catch (System.Exception) { } //bat moi he thong = tranh truong hop ctr bi dung  dot ngot
              */
            //B1: Hỏi xác nhận 
            DialogResult ch = MessageBox.Show("Thiệt xóa sản phẩm có mã " + txtmsmh.Text.Trim() + " không(Y / N) ? ", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //B2: XÓA
            if (ch == DialogResult.Yes)
            {
                try
                {
                    dMSPDDTableAdapter.Delete(txtmsmh.Text.Trim());
                    MessageBox.Show("Xóa xong rồi, xem đi !");
                    DialogResult c = MessageBox.Show("Có xóa luôn hình không?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (c == DialogResult.No)
                    {
                        try
                        {
                            oldimage = System.IO.Path.GetFileName(pictureBoxHinh.ImageLocation); //Lấy tên hình cũ 
                            System.IO.File.Copy(pictureBoxHinh.ImageLocation, apppath + "z\\" + oldimage);
                            MessageBox.Show("Hình cũ copy vào thư mục D:\\G202CHAnSaleDDTM\\Images\\z nha !");
                        }
                        catch (System.Exception ex) { MessageBox.Show("Lỗi Lưu hình cũ vào thư mục z: " + ex.Message); }
                    }
                    else
                    {
                        MessageBox.Show("Xóa hình cũ nha !");
                    }
                    System.IO.File.Delete(pictureBoxHinh.ImageLocation);//Xóa hình trong thư mục Images   

                }
                catch (System.Exception ex)// KHÔNG XÓA ĐƯỢC DO CÒN RBTV DL
                {
                    MessageBox.Show("Có lỗi xóa thức uống " + ex.Message);
                    //gọi Form xử lý RBTV trước khi Xóa
                    Fr2SPDD_DDTM02RBTV fr = new Fr2SPDD_DDTM02RBTV(txtmsmh.Text.Trim(), txttenmh.Text.Trim());
                    fr.ShowDialog();
                }
            }
            //B3: Tải BD lên DataGridView sau khi xóa
            try
            {
                // TODO: This line of code loads data into the 'g211TTNgaSaleToCoDS.DSThucUong' table. You can move, or remove it, as needed.
                this.dMSPDDTableAdapter.Fill(this._1G202AnSaleDDTNDataSet.DMSPDD);
            }
            catch (System.Exception) { }
        }


    }
}
