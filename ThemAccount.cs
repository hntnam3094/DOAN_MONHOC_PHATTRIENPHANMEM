using BLLa;
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
    public partial class ThemAccount : Form
    {
        public ThemAccount()
        {
            InitializeComponent();
        }

        private void btn_taotaikhoan_Click(object sender, EventArgs e)
        {
            TaoTaiKhoan();
        }

        void TaoTaiKhoan()
        {
            try
            {
                if (string.IsNullOrEmpty(txt_tendangnhap.Text))
                {
                    MessageBox.Show("Vui lòng điền vào tên đăng nhập!");
                    return;
                }
                if (string.IsNullOrEmpty(txt_matkhau.Text))
                {
                    MessageBox.Show("Vui lòng điền vào mật khẩu!");
                    return;
                }
                if (string.IsNullOrEmpty(txt_nhaplaimatkhau.Text) || txt_nhaplaimatkhau.Text != txt_matkhau.Text)
                {
                    MessageBox.Show("Vui lòng nhập đúng mật khẩu");
                    return;
                }

                string username = txt_tendangnhap.Text;
                string matkhau = txt_matkhau.Text;
                string nhaplaimatkhau = txt_nhaplaimatkhau.Text;
                int quyen = 0;
                if (rd_quanli.Checked)
                    quyen = 1;
                if (rd_nhanvien.Checked)
                    quyen = 0;

                AccountDAO.Instance.AddnewAccount(username, nhaplaimatkhau, quyen);
                MessageBox.Show("Thêm thành công!");
                this.Close();
            }
            catch
            {
                MessageBox.Show("Có lỗi phát sinh! vui lòng thử lại sau!", "Thông báo!");
            }
        }

        private void btnHuytaotaikhoan_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
