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
    public partial class FromDanhSachHoaDon : Form
    {
        public FromDanhSachHoaDon()
        {
            InitializeComponent();
            LoadALL();
        }

        void LoadALL()
        {
            DateTime currentday = DateTime.Now;
            dgv_dsHoaDon.DataSource = BillDAO.Instance.getListData(currentday.AddDays(-1), currentday.AddDays(1));
        }

        private void dgv_dsHoaDon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        void LoadListBillInfo(int idbill)
        {
            lsvOldBill.Items.Clear();

            List<BLLa.Database.Menu> listMenu = Bill_Info_DAO.Instance.getListBillInfo_byIDBill(idbill);

            foreach (BLLa.Database.Menu menu in listMenu)
            {
                ListViewItem lsvItem = new ListViewItem(menu.Name.ToString());
                lsvItem.SubItems.Add(menu.Count.ToString());
                lsvItem.SubItems.Add(menu.Thanhtien.ToString());
                lsvOldBill.Items.Add(lsvItem);
            }
        }

        private void dgv_dsHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int id = int.Parse(dgv_dsHoaDon.CurrentRow.Cells[0].Value.ToString());
                LoadListBillInfo(id);
            }
            catch
            {
                MessageBox.Show("Có lỗi khi thao tác!");
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            lsvOldBill.Items.Clear();
            int id = BillDAO.Instance.getMaxIDBill();
            BLLa.Database.Menu menu = BillDAO.Instance.getLastBill(id);
            ListViewItem lsvItem = new ListViewItem(menu.Name.ToString());
            lsvItem.SubItems.Add(menu.Count.ToString());
            lsvItem.SubItems.Add(menu.Thanhtien.ToString());
            lsvOldBill.Items.Add(lsvItem);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("In thành công!");
        }
    }
}
