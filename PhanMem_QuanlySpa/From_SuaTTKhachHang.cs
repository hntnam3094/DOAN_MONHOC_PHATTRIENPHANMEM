using BLLa;
using BLLa.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhanMem_QuanlySpa
{
    public partial class From_SuaTTKhachHang : Form
    {
        public From_SuaTTKhachHang(KhachHang kh)
        {
            InitializeComponent();
            this.Kh = kh;
            LoadTTKH();
        }



        private KhachHang kh;

        public KhachHang Kh
        {
            get { return kh; }
            set { kh = value; }
        }

        void LoadTTKH()
        {
            
            txt_id.Text = kh.Id.ToString();
            txt_sdt.Text = kh.Sdt.ToString();
            txt_hovaten.Text = kh.Username.ToString();
            if (kh.Gioitinh == "Nam")
                rd_nam.Checked = true;
            else if (kh.Gioitinh == "Nữ")
                rd_nu.Checked = true;
            else
                rd_khac.Checked = true;
            dtp_namsinh.Value = kh.Namsinh;
            txt_cmnd.Text = kh.Cmnd.ToString();
            txt_diachi.Text = kh.Diachi.ToString();
            txt_email.Text = kh.Email.ToString();
            label_Tichdiem.Text = kh.Tichdiem.ToString();
            lable_Hoatdong.Text = kh.Hoatdong.ToString();

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Bạn có muốn sửa thông tin khách hàng này không?", "Thông báo!", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.Cancel)
                {
                    int id = int.Parse(txt_id.Text);
                    string sdt = null;
                    string username = txt_hovaten.Text;
                    string gioitinh = null;
                    if (rd_nam.Checked)
                        gioitinh = "Nam";
                    if (rd_nu.Checked)
                        gioitinh = "Nữ";
                    if (rd_khac.Checked)
                        gioitinh = "Khác";
                    DateTime namsinh = dtp_namsinh.Value;
                    string cmnnd = null;
                    string address = txt_diachi.Text;
                    string email = null;
                    int hoatdong = 0;
                    int tichdiem = 0;
                    if (!DinhDangAll.Instance.isNumberPhone(txt_sdt.Text))
                    {
                        MessageBox.Show("Vui lòng nhập đúng số điện thoại");
                        return;
                    }
                    sdt = txt_sdt.Text;
                    if (!DinhDangAll.Instance.isCMND(txt_cmnd.Text))
                    {
                        MessageBox.Show("Vui lòng nhập đúng số chứng minh nhân dân");
                        return;
                    }
                    cmnnd = txt_cmnd.Text;
                    if (!DinhDangAll.Instance.isValidEmail(txt_email.Text))
                    {
                        MessageBox.Show("Vui lòng nhập đúng email");
                        return;
                    }
                    email = txt_email.Text;

                    KhachHangDAO.Instance.UpdateKhachHang(id, sdt, username, gioitinh, namsinh, cmnnd, address, email, hoatdong, tichdiem);
                    MessageBox.Show("Sửa thành công!");
                    this.Close();
                }
            }
            catch
            {
                MessageBox.Show("Sửa thất bại!");
            }
        }


    }
}
