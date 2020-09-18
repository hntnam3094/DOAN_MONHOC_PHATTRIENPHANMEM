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
    public partial class From_ThongTinKhachHang : Form
    {
        public From_ThongTinKhachHang()
        {
            InitializeComponent();
        }

        public From_ThongTinKhachHang(int id)
        {
            this.Id = id;
        }

       

        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
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

                ThemKhachHang(sdt, username, gioitinh, namsinh, cmnnd, address, email, hoatdong, tichdiem);
                MessageBox.Show("Thêm thành công!");
                this.Close();
            }
            catch
            {
                MessageBox.Show("Thêm thất bại!");
            }
        }

        void ThemKhachHang(string sdt, string username, string gioitinh, DateTime namsinh, string cmnnd, string address, string email, int hoatdong, int tichdiem)
        {
            //string sdt, string username, int gioitinh, int namsinh, string cmnnd, string address, string email, int hoatdong, int tichdiem

            KhachHangDAO.Instance.insertKhachHang(sdt, username, gioitinh, namsinh, cmnnd, address, email, hoatdong, tichdiem);
        }
    }
}
