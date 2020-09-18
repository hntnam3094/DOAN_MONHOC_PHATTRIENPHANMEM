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
    public partial class ChiTietLichHen : Form
    {
        private BLLa.Database.LichHen lh;

        public BLLa.Database.LichHen LH
        {
            get { return lh; }
            set { lh = value; }
        }


        public ChiTietLichHen(BLLa.Database.LichHen lichHen)
        {
            InitializeComponent();
            LoadChiTietlichHen(lichHen);
            this.LH = lichHen;
        }


        void LoadChiTietlichHen(BLLa.Database.LichHen lh)
        {
            
            label6.Text = lh.Username;
            label7.Text = lh.Name_nv;
            label8.Text = lh.Ngay.ToString();
            label9.Text = lh.Gio.ToString();
            txt_noidung.Text = lh.Noidung;
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc khách hàng này đã đến?", "Thông báo!", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.Cancel)
            {
                if (LichHenDAO.Instance.HoanThanhLichHen(LH.Id))
                {
                    MessageBox.Show("Cập nhật thành công!");
                    this.Close();
                }
            }
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc xóa khách hàng này?", "Thông báo!", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.Cancel)
            {
                if (LichHenDAO.Instance.DeleteLichHen(LH.Id))
                {
                    MessageBox.Show("Cập nhật thành công!");
                    this.Close();
                }
            }
        }
        

       

      
    }
}
