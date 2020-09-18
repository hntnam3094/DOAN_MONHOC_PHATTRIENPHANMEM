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
    public partial class CreateBill : Form
    {
        public CreateBill(Room rom)
        {
            InitializeComponent();
            this.Room = rom;
            loadRoom();
            LoadCombox();
        }

        private Room room;

        public Room Room
        {
            get { return room; }
            set { room = value; }
        }


        void LoadCombox()
        {
            combobox_khachhang.DataSource = KhachHangDAO.Instance.getListKHbyHD();
            combobox_khachhang.DisplayMember = "USERNAME";
            combobox_khachhang.ValueMember = "Id";
        }
        void loadRoom()
        {
            lb_phong.Text = room.Name;
            lb_loaiphong.Text = "NORMAL";
            txt_tamtinh.Text = "0";
            if (room.Vip == 1)
            {
                lb_loaiphong.Text = "VIP";
                txt_tamtinh.Text = "30000";
            }
            lb_checkin.Text = DateTime.Now.ToString();
            if (room.Status == 1)
            {
                btn_mophong.Enabled = false;

            }

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void btn_mophong_Click(object sender, EventArgs e)
        {
            int idKH = int.Parse(combobox_khachhang.SelectedValue.ToString());
            int idroom = room.Id;
            float price = float.Parse(txt_tamtinh.Text);
            DateTime datecheck = DateTime.Parse(lb_checkin.Text);

            if (MessageBox.Show("Bạn có muốn mở phòng này không?", "Thông báo!", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.Cancel)
            {
                try
                {
                    BillDAO.Instance.createNewBill2(idKH, idroom, price, datecheck, 0);
                    MessageBox.Show("Đã mở " + room.Name);
                    this.Close();
                }
                catch
                {
                    MessageBox.Show("Có lỗi!");

                }
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            
        }
    }
}
