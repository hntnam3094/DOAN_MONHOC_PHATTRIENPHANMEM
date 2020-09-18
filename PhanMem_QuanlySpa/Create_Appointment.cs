using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLLa;
using BLLa.Database;
namespace PhanMem_QuanlySpa
{
    public partial class Create_Appointment : Form
    {
        public Create_Appointment()
        {
            InitializeComponent();
            LoadALL();
           
        }

        void LoadALL()
        {
            LoadComboboxKhachHang();
            LoadComboboxNhanVien();
        }

        

       


        void LoadComboboxKhachHang()
        {
            combobox_khachhang.DataSource = KhachHangDAO.Instance.getListKH_notblock();
            combobox_khachhang.DisplayMember = "USERNAME";
            combobox_khachhang.ValueMember = "Id";
        }

        void LoadComboboxNhanVien()
        {
            combobox_nhanvien.DataSource = NhanVienDAO.Instance.getListNV_notBlock();
            combobox_nhanvien.DisplayMember = "NAME";
            combobox_nhanvien.ValueMember = "ID";

        }

        
        
    
      
        private void btn_them_Click(object sender, EventArgs e)
        {
            try
            {
                int idKhachHang = int.Parse(combobox_khachhang.SelectedValue.ToString());
                int idNV = int.Parse(combobox_nhanvien.SelectedValue.ToString());
                DateTime ngayhen = datetime_ngayhen.Value;
                int idGio = int.Parse(combobox_gio.SelectedValue.ToString());
                string noidung = txt_noidung.Text;
                int sogiomuon = int.Parse(combobox_giômngmuon.Text);
                for (int i = 0; i < sogiomuon; i++) {

                    LichHenDAO.Instance.ThemLichHen(idGio, idNV, idKhachHang, noidung, 0, ngayhen);
                    idGio += 1;
                       
                    
                }
                MessageBox.Show("Thêm thành công!");
                this.Close();
                    
            }
            catch
            {
                MessageBox.Show("Có lỗi trong quá trình xử lý");
                this.Close();
            }

            
        }

      

        private void datetime_ngayhen_ValueChanged(object sender, EventArgs e)
        {
            int idNV = int.Parse(combobox_nhanvien.SelectedValue.ToString());
            DateTime ngayhen = datetime_ngayhen.Value;
            combobox_gio.DataSource = LichHenDAO.Instance.getList_GioTV(ngayhen, idNV);
            combobox_gio.DisplayMember = "Gio";
            combobox_gio.ValueMember = "ID";
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn chưa thêm lịch hẹn, bạn có muốn thoát không?", "Thông báo!", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.Cancel)
            {
                this.Close();
            }
        }

        
    }
}
