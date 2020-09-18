using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using BLLa;
using BLLa.Database;
using DAL.NghiepVu_Database;
using System.Globalization;
using GUI;
namespace PhanMem_QuanlySpa
{
    public partial class FromMain : DevExpress.XtraEditors.XtraForm
    {
        public FromMain(Account acc)
        {
            InitializeComponent();
            LoadAll();
            if (acc.Type == 0)
            {
                tabContro_vertical1.TabPages.Remove(tab_cuaHang);
                tabContro_vertical1.TabPages.Remove(tab_thongke);
                tabContro_vertical1.TabPages.Remove(tab_baocao);
            }
        }


        private static int cohieu = 0;
        void LoadAll()
        {
            addLichHen();
            AddRoom();
            LoadCategory();
            LoadKH();
            LoadRoomUnCheck();
            LoadRoomtab();
            LoadNV_TuVan();
            LoadCategory2();
            LoadComboxbox_Category();
            LoadDgv_Sanpham();
            LoadDateTimepicker();
            LoadAccount();
            LoadNhanVien();
            LoadNhanVien2();
            
        }
#region thongke
        DateTime currentdate = DateTime.Now;


        void LoadDateTimepicker()
        {
            LoadDateThisMonth(currentdate);
        }

        void LoadDateThisMonth(DateTime day)
        {
            DateTime from = new DateTime(day.Year, currentdate.Month, 1);
            DateTime to = from.AddMonths(1).AddDays(-1);
            datetime_from.Value = from;
            datetiem_to.Value = to;
        }
        void LoadBill(){
            dgv_bill.DataSource = BillDAO.Instance.getListData(datetime_from.Value, datetiem_to.Value);

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            LoadBill();
        }
#endregion




        #region 3starttab


     
        void LoadRoomUnCheck()
        {
            cobo_room2.DataSource = RoomDAO.Instance.getListRoom_uncheck();
            cobo_room2.DisplayMember = "Name";
            cobo_room2.ValueMember = "ID";
        }

        void addLichHen()
        {
            LichhHen lh = new LichhHen();
            lh.TopLevel = false;
            tab_LichHen.Controls.Add(lh);
            lh.Show();
        }


        void LoadCategory()
        {
            cbb_category.DataSource = CategoryDAO.Instance.getListCategory();
            cbb_category.DisplayMember = "NAME";
            cbb_category.ValueMember = "ID";
            cbb_category.SelectedIndexChanged += cbb_category_SelectedIndexChanged;
        }

        void cbb_category_SelectedIndexChanged(object sender, EventArgs e)
        {
             int idcategory = int.Parse(cbb_category.SelectedValue.ToString());
             LoadProSer(idcategory);
        }

        void LoadProSer(int id)
        {
            cbb_proser.DataSource = ProSerDAO.Instance.getListPro_ser(id);
            cbb_proser.DisplayMember = "NAME";
            cbb_proser.ValueMember = "ID";
        }

        void AddRoom()
        {
            flp_room.Controls.Clear();
            List<Room> listRoom = RoomDAO.Instance.getListRoom();
            foreach (Room room in listRoom)
            {
                Button btnRoom = new Button();
                btnRoom.Name = room.Id.ToString();
                btnRoom.Text = room.Name + Environment.NewLine + "Normal" + Environment.NewLine;
                btnRoom.Width = 120;
                btnRoom.Height = 120;
                btnRoom.BackColor = Color.Beige;
                if (room.Vip == 1)
                {
                    btnRoom.BackColor = Color.Brown;
                    btnRoom.Text = room.Name + Environment.NewLine + "VIP";
                    

                }

                if (room.Status == 1)
                {
                    btnRoom.BackColor = Color.GreenYellow;
                }
                btnRoom.Tag = room;
                btnRoom.Click+=btnRoom_Click;
              
                flp_room.Controls.Add(btnRoom);
            }

        }

       

        void btnRoom_Click(object sender, EventArgs e)
        {
            Room room = ((sender as Button).Tag as Room);
            int idromm = room.Id;
            lvsBill.Tag = (sender as Button).Tag;
            if (room.Status == 0)
            {
                CreateBill frmCreate = new CreateBill(room);
                frmCreate.ShowDialog();
                AddRoom();
                LoadRoomUnCheck();
            }
            if (room.Status == 1)
            {
                txtThanhtien.Text = "0";
                ShowBill(idromm);
                ShowCTRoom(idromm);
                BTN_VIPCARRD.Enabled = true;
                BTN_FAMILYCARRD.Enabled = true;
            }
      
        }

        void ShowCTRoom(int idroom)
        {
            try
            {
                CT_Room ctroom = BillDAO.Instance.getCTRomm(idroom);
                lbl_tenphong.Text = ctroom.Name;
                lbl_tenkh.Text = ctroom.Username;
                lbl_gionhanphong.Text = ctroom.Checkin.ToString();
                label35.Text = ctroom.Namenv.ToString();

                if (ctroom.Vip == 1)
                {
                    lbl_loaiphong.Text = "VIP";
                }
                if (ctroom.Vip == 0)
                {
                    lbl_loaiphong.Text = "NORMAL";
                }
            }
            catch
            {
                MessageBox.Show("Khách hàng này không có lịch hẹn hôm nay!", "Thông báo!");
            }
        }

        void ShowBill(int idroom)
        {
            lvsBill.Items.Clear();

            float thanhtien = 0;
            List<BLLa.Database.Menu> listMenu = Bill_Info_DAO.Instance.getListMenu_byIDRoom(idroom);

            foreach (BLLa.Database.Menu menu in listMenu)
            {
                ListViewItem lsvItem = new ListViewItem(menu.Name.ToString());
                lsvItem.SubItems.Add(menu.Count.ToString());
                lsvItem.SubItems.Add(menu.Thanhtien.ToString());
                thanhtien += menu.Thanhtien;
                txtThanhtien.Text = thanhtien.ToString();
                lvsBill.Items.Add(lsvItem);
            }

        }

        private void ribbonControl1_Click(object sender, EventArgs e)
        {

        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LichhHen lh = new LichhHen();
            lh.TopLevel = false;
            pannel_cuahang.Controls.Add(lh);
            lh.Show();

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadKH();
        }


        void LoadKH()
        {
            dtg_khachhang.DataSource = KhachHangDAO.Instance.getListKhachHang();
        }

        private void barButtonItem1_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            From_ThongTinKhachHang ttkh = new From_ThongTinKhachHang();
            ttkh.ShowDialog();
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int idKH = int.Parse(dtg_khachhang.CurrentRow.Cells[9].Value.ToString());
            KhachHang kh = KhachHangDAO.Instance.getKHbyID(idKH);
            From_SuaTTKhachHang stkk = new From_SuaTTKhachHang(kh);
            stkk.ShowDialog();

        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (MessageBox.Show("Bạn có muốn xóa khách hàng này không?", "Thông báo!", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.Cancel)
                {
                    int idKH = int.Parse(dtg_khachhang.CurrentRow.Cells[9].Value.ToString());
                    KhachHangDAO.Instance.DeleteKhachHang(idKH);
                    MessageBox.Show("Xóa Thành Công!");
                    LoadKH();
                }
            }catch{
                MessageBox.Show("Xóa thất bại!");
            }
        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int idKH = int.Parse(dtg_khachhang.CurrentRow.Cells[9].Value.ToString());
            int hoatdong = int.Parse(dtg_khachhang.CurrentRow.Cells[4].Value.ToString());
            try
            {
                if (hoatdong == 0)
                {
                    if (MessageBox.Show("Bạn có muốn khóa khách hàng này không?", "Thông báo!", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.Cancel)
                    {
                        KhachHangDAO.Instance.BlockKhachHANG(idKH);
                        MessageBox.Show("Cập nhật thành Công!");
                        LoadKH();
                    }
                }
                if (hoatdong == 1)
                {
                    if (MessageBox.Show("Bạn có muốn mở khóa khách hàng này không?", "Thông báo!", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.Cancel)
                    {
                        KhachHangDAO.Instance.BlockKhachHANG(idKH);
                        MessageBox.Show("Cập nhật thành Công!");
                        LoadKH();
                    }
                }
            }catch{
                MessageBox.Show("Cập nhật thất bại!");
            }
        }

        private void btnMophong_Click(object sender, EventArgs e)
        {
            
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            ThemNew_BillInfo();
        }

        void ThemNew_BillInfo()
        {
            try
            {
                Room room = lvsBill.Tag as Room;
                int idromm = room.Id;
                int idBillUnCheck = BillDAO.Instance.GetBillUnCheckByIDRomm(idromm);
                int idProser = int.Parse(cbb_proser.SelectedValue.ToString());
                int count = int.Parse(nmSoLuong.Value.ToString());
                if (Bill_Info_DAO.Instance.AddnewPorser(idBillUnCheck, idProser, count))
                {
                    MessageBox.Show("Cập nhật thành công!");
                    ShowBill(idromm);
                    AddRoom();
                }
                else
                {
                    MessageBox.Show("Cập nhật thất bại!");
                }
            }
            catch
            {
                MessageBox.Show("Vui lòng chọn phòng!");
            }
            
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            ThanhToan();
        }

        void ThanhToan()
        {
            try
            {
                Room room = lvsBill.Tag as Room;
                int idroom = room.Id;
                int idKH = KhachHangDAO.Instance.getIDKH_intbIllb_idRoom(idroom);
                float totalprice = float.Parse(txtThanhtien.Text);
                int discount = 0;
                if (cohieu == 0)
                {
                    discount = 0;
                    if (room.Vip == 1)
                    {
                        if (MessageBox.Show("Bạn có chắc muốn thanh toán " + room.Name + "?\nPhụ thu phòng VIP: 30.000\nGiảm giá: " + discount.ToString() + "%" + "\nTổng tiền: " + (totalprice + 30000).ToString(), "Thông báo!", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.Cancel)
                        {
                            BillDAO.Instance.ThanhToan(idKH, idroom, totalprice + 30000, discount);
                            MessageBox.Show("Thanh toán thành công!");
                            LoadAll();
                            lvsBill.Clear();
                            return;
                        }
                    }
                    else
                    {
                        if (MessageBox.Show("Bạn có chắc muốn thanh toán " + room.Name + "?\nGiảm giá: " + discount.ToString() + "%" + "\nTổng tiền: " + totalprice.ToString(), "Thông báo!", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.Cancel)
                        {
                            BillDAO.Instance.ThanhToan(idKH, idroom, totalprice, discount);
                            MessageBox.Show("Thanh toán thành công!");
                            LoadAll();
                            lvsBill.Clear();
                            return;
                        }
                    }
                }
                if (cohieu == 1)
                {
                    discount = 10;
                    if (room.Vip == 1)
                    {
                        if (MessageBox.Show("Bạn có chắc muốn thanh toán " + room.Name + "?\nPhụ thu phòng VIP: 30.000\nGiảm giá: " + discount.ToString() +"%"+ "\nTổng tiền: " + (totalprice + 30000).ToString(), "Thông báo!", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.Cancel)
                        {
                            BillDAO.Instance.ThanhToan(idKH, idroom, totalprice + 30000, discount);
                            MessageBox.Show("Thanh toán thành công!");
                            LoadAll();
                            lvsBill.Clear();
                            return;
                        }
                    }
                    else
                    {
                        if (MessageBox.Show("Bạn có chắc muốn thanh toán " + room.Name + "?\nGiảm giá: " + discount.ToString() + "%" + "\nTổng tiền: " + totalprice.ToString(), "Thông báo!", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.Cancel)
                        {
                            BillDAO.Instance.ThanhToan(idKH, idroom, totalprice, discount);
                            MessageBox.Show("Thanh toán thành công!");
                            LoadAll();
                            lvsBill.Clear();
                            return;
                        }
                    }
                }

                if (cohieu == 2)
                {
                    discount = 20;
                    if (room.Vip == 1)
                    {
                        if (MessageBox.Show("Bạn có chắc muốn thanh toán " + room.Name + "?\nPhụ thu phòng VIP: 30.000\nGiảm giá: " + "%" + discount.ToString() + "\nTổng tiền: " + (totalprice + 30000).ToString(), "Thông báo!", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.Cancel)
                        {
                            BillDAO.Instance.ThanhToan(idKH, idroom, totalprice + 30000, discount);
                            MessageBox.Show("Thanh toán thành công!");
                            LoadAll();
                            lvsBill.Clear();
                            return;
                        }
                    }
                    else
                    {
                        if (MessageBox.Show("Bạn có chắc muốn thanh toán " + room.Name + "?\nGiảm giá: " + discount.ToString() + "%" + "\nTổng tiền: " + totalprice.ToString(), "Thông báo!", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.Cancel)
                        {
                            BillDAO.Instance.ThanhToan(idKH, idroom, totalprice, discount);
                            MessageBox.Show("Thanh toán thành công!");
                            LoadAll();
                            lvsBill.Clear();
                            return;
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("Hóa đơn bạn không thể thanh toán!");
            }

        }

       

        private void btngiamgia_Click(object sender, EventArgs e)
        {
            Room room = lvsBill.Tag as Room;
            int vip = room.Vip;
            cohieu = 1;
            if (vip == 1)
            {
                double giamgia = 0.1;
                double Thanhtien = double.Parse(txtThanhtien.Text);
                double tiengiamgia = giamgia * Thanhtien;
                double thanhtiensaukhigamgia = (Thanhtien - tiengiamgia) + 30000;
                txtThanhtien.Text = thanhtiensaukhigamgia.ToString();
            }
            else
            {
                double giamgia = 0.1;
                double Thanhtien = double.Parse(txtThanhtien.Text);
                double tiengiamgia = giamgia * Thanhtien;
                double thanhtiensaukhigamgia = Thanhtien - tiengiamgia;
                txtThanhtien.Text = thanhtiensaukhigamgia.ToString();
            }

            BTN_FAMILYCARRD.Enabled = false;
            BTN_VIPCARRD.Enabled = false;
        }

        private void btnChuyenphong_Click(object sender, EventArgs e)
        {
            ChuyenPhong();
        }

        void ChuyenPhong()
        {
            try
            {
                Room room = lvsBill.Tag as Room;
                int idroom1 = room.Id;
                int idroom2 = int.Parse(cobo_room2.SelectedValue.ToString());
                Room rom2 = RoomDAO.Instance.getRoom_byUncheckID(idroom2);
                if (MessageBox.Show("Bạn có muốn chuyển " + room.Name + " sang " + rom2.Name, "Thông báo!", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.Cancel)
                {
                    if (RoomDAO.Instance.ChuyenPhong(idroom1, idroom2))
                    {
                        MessageBox.Show("Chuyển phòng thành công!");
                        LoadAll();
                    }
                }
            }
            catch
            {
                MessageBox.Show("Vui lòng chọn phòng!", "Thông báo!");
            }
        }

        private void btnDongPhong_Click(object sender, EventArgs e)
        {
            Room room = lvsBill.Tag as Room;
            int idroom = room.Id;
            try
            {
                if (txtThanhtien.Text != "0")
                {
                    MessageBox.Show("Bạn không thể đóng phòng này! Bạn phải thanh toán");
                    return;
                }
                else
                {
                    if (MessageBox.Show("Bạn có muốn đóng phòng nay không?", "Thông báo!", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.Cancel)
                    {
                        if (RoomDAO.Instance.DongPhong(idroom))
                        {
                            MessageBox.Show("Cập nhật thành công!");
                            LoadAll();
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("Có lỗi khi thao tác!","Thông báo!");
            }
        }
#endregion 

        #region 3endtab


        void LoadAccount()
        {
            dgv_taikhoan.DataSource = AccountDAO.Instance.getListAccount();
        }
        void LoadRoomtab()
        {
            dgv_room.DataSource = RoomDAO.Instance.getListRoom();
        }


        void LoadNV_TuVan()
        {
            dgv_nhanvien.DataSource = NhanVienDAO.Instance.getListNhanVien();
            suaNhanVien.Enabled = false;

        }

        void LoadCategory2()
        {
            dgv_category.DataSource = CategoryDAO.Instance.getListCategory2();
            lưuToolStripMenuItem1.Enabled = false;
        }

        void LoadComboxbox_Category()
        {
            combobox_loai.DataSource = CategoryDAO.Instance.getListCategory2();
            combobox_loai.DisplayMember = "NAME";
            combobox_loai.ValueMember = "ID";
        }

        private void thêmToolStripMenuItem_Click(object sender, EventArgs e)
        {


        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

            ControlNhanVien(true);
            textBox1.Clear();
            txt_hoten.Clear();
            txt_diachi.Clear();
            txt_cmnd.Clear();
            txt_dienthoai.Clear();
            suaNhanVien.Enabled = true;

        }

        void ControlNhanVien(bool a)
        {
            txt_hoten.Enabled = a;
            datePicker_Nhanvien.Enabled = a;
            rd_nam.Enabled = a;
            rd_nu.Enabled = a;
            txt_diachi.Enabled = a;
            txt_cmnd.Enabled = a;
            txt_dienthoai.Enabled = a;
            comboBox1.Enabled = a;
        }

        private void FromMain_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'sALON_AND_SPADataSet.LOAI_NV' table. You can move, or remove it, as needed.
            this.lOAI_NVTableAdapter.Fill(this.sALON_AND_SPADataSet.LOAI_NV);

        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            ControlNhanVien(true);
            suaNhanVien.Enabled = true;
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            int id = int.Parse(dgv_nhanvien.CurrentRow.Cells[0].Value.ToString());
            if (id.ToString() != "")
            {
                if (MessageBox.Show("Bạn có muốn xóa nhân viên này không?", "Thông báo!", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.Cancel)
                {
                    NhanVienDAO.Instance.DeleteNhanVien(id);
                    MessageBox.Show("Xóa thành công!");
                    LoadNV_TuVan();
                }
            }
        }

        private void suaNhanVien_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                try
                {
                    int loainv = int.Parse(comboBox1.SelectedValue.ToString());
                    string cmnd = txt_cmnd.Text;
                    string sdt = txt_dienthoai.Text;
                    if (!DinhDangAll.Instance.isCMND(cmnd))
                    {
                        MessageBox.Show("Vui lòng nhập đúng định dạng chứng minh nhân dân!");
                    }
                    else if (!DinhDangAll.Instance.isNumberPhone(sdt))
                    {
                        MessageBox.Show("Vui lòng nhập đúng đạnh dạng số điện thoại!");
                    }
                    else
                    {
                        string name = txt_hoten.Text;
                        DateTime namsinh = datePicker_Nhanvien.Value;
                        string gioitinh = "";
                        if (rd_nam.Checked)
                            gioitinh = "Nam";
                        if (rd_nu.Checked)
                            gioitinh = "Nữ";
                        string diachi = txt_diachi.Text;

                        NhanVienDAO.Instance.AddnewNhanVien(name, namsinh, gioitinh, sdt, diachi, cmnd, loainv, 0);
                        MessageBox.Show("Thêm thành công!");
                        LoadNV_TuVan();
                    }
                }
                catch
                {
                    MessageBox.Show("Xảy ra lỗi!, vui lòng kiểm tra lại!");
                }
            }
            else
            {

                int id = int.Parse(dgv_nhanvien.CurrentRow.Cells[0].Value.ToString());
                if (id.ToString() != "")
                {
                    if (MessageBox.Show("Bạn có muốn sửa thông tin nhân viên này không?", "Thông báo!", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.Cancel)
                    {
                        try
                        {
                            int tenloainv = int.Parse(comboBox1.SelectedValue.ToString());
                            string cmnd = txt_cmnd.Text;
                            string sdt = txt_dienthoai.Text;
                            if (!DinhDangAll.Instance.isCMND(cmnd))
                            {
                                MessageBox.Show("Vui lòng nhập đúng định dạng chứng minh nhân dân!");
                            }
                            else if (!DinhDangAll.Instance.isNumberPhone(sdt))
                            {
                                MessageBox.Show("Vui lòng nhập đúng đạnh dạng số điện thoại!");
                            }

                            else
                            {
                                string name = txt_hoten.Text;
                                DateTime namsinh = datePicker_Nhanvien.Value;
                                string gioitinh = "";
                                if (rd_nam.Checked)
                                    gioitinh = "Nam";
                                if (rd_nu.Checked)
                                    gioitinh = "Nữ";
                                string diachi = txt_diachi.Text;

                                
                                NhanVienDAO.Instance.SuaNhanVien(id, name, namsinh, sdt, gioitinh, diachi, cmnd, tenloainv, 0);
                                MessageBox.Show("Thêm thành công!");
                                LoadNV_TuVan();
                            }
                        }
                        catch
                        {
                            MessageBox.Show("Xảy ra lỗi!, vui lòng kiểm tra lại!");
                        }
                    }
                }
            }
        }

        private void khóaHoạtĐộngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id = int.Parse(dgv_nhanvien.CurrentRow.Cells[0].Value.ToString());
            int hoatdong = int.Parse(dgv_nhanvien.CurrentRow.Cells[8].Value.ToString());
            if (id.ToString() != "")
            {
                if (hoatdong == 0)
                {
                    if (MessageBox.Show("Bạn có muốn khóa nhân viên này không?", "Thông báo!", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.Cancel)
                    {
                        NhanVienDAO.Instance.Block_NhanVien(id, 1);
                        LoadNV_TuVan();
                    }
                }
                if (hoatdong == 1)
                {
                    if (MessageBox.Show("Bạn có muốn mở khóa nhân viên này không?", "Thông báo!", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.Cancel)
                    {
                        NhanVienDAO.Instance.Block_NhanVien(id, 0);
                        LoadNV_TuVan();
                    }
                }
            }
        }


        private void dgv_category_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_ténanpham_dichvu.Text = dgv_category.CurrentRow.Cells[1].Value.ToString();
            txt_idsanphamdichvu.Text = dgv_category.CurrentRow.Cells[0].Value.ToString();
            txt_ténanpham_dichvu.Enabled = false;
            txt_idsanphamdichvu.Enabled = false;
        }

        private void thêmToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            txt_ténanpham_dichvu.Enabled = true;
            txt_idsanphamdichvu.Clear();
            txt_ténanpham_dichvu.Clear();
            lưuToolStripMenuItem1.Enabled = true;
        }

        private void lưuToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_idsanphamdichvu.Text == "")
                {
                    string name = txt_ténanpham_dichvu.Text;
                    CategoryDAO.Instance.Addnew_Category(name);
                    MessageBox.Show("Thêm thành công!");
                    LoadCategory2();
                    LoadAll();
                    
                }
                else
                {
                    string namesua = txt_ténanpham_dichvu.Text;
                    int id = int.Parse(txt_idsanphamdichvu.Text);
                    if (id.ToString() != "")
                    {
                        CategoryDAO.Instance.UpdateCategory(id, namesua);
                        MessageBox.Show("Sửa thành công!");
                        LoadCategory2();
                        LoadAll();
                    }
                }
            }
            catch
            {
                MessageBox.Show("Có lỗi trong quá trình xử lý!, Vui lòng kiểm tra lại!");
            }

        }
    
        

        private void lưuToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void suaCategory_Click(object sender, EventArgs e)
        {
            lưuToolStripMenuItem1.Enabled = true;
            txt_ténanpham_dichvu.Enabled = true;
        }

        private void xóaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int id = int.Parse(dgv_category.CurrentRow.Cells[0].Value.ToString());
            if (id.ToString() != "")
            {
                CategoryDAO.Instance.DeleteCategory(id);
                MessageBox.Show("Xóa thành công!");
                LoadCategory2();
            }
        }


        void LoadDgv_Sanpham()
        {

            string maloai = combobox_loai.SelectedValue.ToString();
            if (maloai != null)
            {
                combobox_loai.SelectedValueChanged += combobox_loai_SelectedValueChanged;
            }
        }

        void combobox_loai_SelectedValueChanged(object sender, EventArgs e)
        {
            string maloai = combobox_loai.SelectedValue.ToString();
            Load_dgvProser(int.Parse(maloai));
        }


        void Load_dgvProser(int idcategory)
        {

            dgv_sanpham.DataSource = ProSerDAO.Instance.getListPro_Ser2(idcategory);
        }

        private void dgv_sanpham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                textBox2.Text = dgv_sanpham.CurrentRow.Cells[0].Value.ToString();
                txt_sanphamdichvu.Text = dgv_sanpham.CurrentRow.Cells[1].Value.ToString();
                txt_soluong.Text = dgv_sanpham.CurrentRow.Cells[3].Value.ToString();
                txt_mota.Text = dgv_sanpham.CurrentRow.Cells[4].Value.ToString();
                txt_gia.Text = dgv_sanpham.CurrentRow.Cells[5].Value.ToString();
                Loadtxt(false);
                lưuToolStripMenuItem2.Enabled = false;
            }
            catch
            {
                MessageBox.Show("Vui lòng chọn danh mục sản phẩm!");
            }
        }

        private void thêmToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            textBox2.Clear();
            txt_sanphamdichvu.Clear();
            txt_soluong.Clear();
            txt_mota.Clear();
            txt_gia.Clear();
            Loadtxt(true);
            lưuToolStripMenuItem2.Enabled = true;
        }

        private void sửaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Loadtxt(true);
            lưuToolStripMenuItem2.Enabled = true;
        }

        void Loadtxt(bool a)
        {
            txt_sanphamdichvu.Enabled = a;
            txt_soluong.Enabled = a;
            txt_gia.Enabled = a;
            txt_mota.Enabled = a;

        }

        private void lưuToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox2.Text == "")
                {
                    int idcategory = int.Parse(combobox_loai.SelectedValue.ToString());
                    string name = txt_sanphamdichvu.Text;
                    int soluong = int.Parse(txt_soluong.Text);
                    string mota = txt_mota.Text;
                    float price = float.Parse(txt_gia.Text);

                    ProSerDAO.Instance.AddNew_ProSer(name, idcategory, soluong, mota, price);
                    MessageBox.Show("Thêm thành công!");
                    Load_dgvProser(idcategory);
                    LoadAll();
                }
                else
                {


                    int id = int.Parse(textBox2.Text);
                    string name = txt_sanphamdichvu.Text;
                    int soluong = int.Parse(txt_soluong.Text);
                    string mota = txt_mota.Text;
                    float price = float.Parse(txt_gia.Text);

                    if (ProSerDAO.Instance.UpdateProSer(id, name, soluong, mota, price))
                    {
                        MessageBox.Show("Sửa thành công!", "Thông báo!");
                        Load_dgvProser(int.Parse(combobox_loai.SelectedValue.ToString()));
                    }
                }
            }
            catch
            {
                MessageBox.Show("Có lỗi trong quá trình xử lý!, Vui lòng kiểm tra lại!", "Thông báo!");
            }
        }

       
        #endregion

        private void dgv_bill_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int idbill = int.Parse(dgv_bill.CurrentRow.Cells[0].Value.ToString());
                LoadListBillInfo(idbill);
            }
            catch
            {
                MessageBox.Show("Thao tác qua nhanh!", "Thông báo!");
            }
        }



        void LoadListBillInfo(int idbill)
        {
            lsv_billinfo.Items.Clear();

            List<BLLa.Database.Menu> listMenu = Bill_Info_DAO.Instance.getListBillInfo_byIDBill(idbill);

            foreach (BLLa.Database.Menu menu in listMenu)
            {
                ListViewItem lsvItem = new ListViewItem(menu.Name.ToString());
                lsvItem.SubItems.Add(menu.Count.ToString());
                lsvItem.SubItems.Add(menu.Thanhtien.ToString());
                lsv_billinfo.Items.Add(lsvItem);
            }
        }

        private void thêmToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            ThemAccount fThemaccount = new ThemAccount();
            fThemaccount.ShowDialog();
            LoadAccount();
        }

        private void sửaToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            try
            {
                string username = dgv_taikhoan.CurrentRow.Cells[0].Value.ToString();
                string password = "123";
                AccountDAO.Instance.reset_Account(username, password);
                MessageBox.Show("Cập nhật thành công!");
                LoadAccount();
            }
            catch {
                MessageBox.Show("Có lỗi trong quá trình xử lý!, Vui lòng kiểm tra lại!", "Thông báo!");
            }
        }

        private void khóaTàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string username = dgv_taikhoan.CurrentRow.Cells[0].Value.ToString();
                int hoatdong = 1;
                AccountDAO.Instance.BlockAccount(username, hoatdong);
                MessageBox.Show("Cập nhật thành công!");
                LoadAccount();
            }
            catch
            {
                MessageBox.Show("Có lỗi trong quá trình xử lý!, Vui lòng kiểm tra lại!", "Thông báo!");
            }
        }

        private void xóaToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            try
            {
                string username = dgv_taikhoan.CurrentRow.Cells[0].Value.ToString();
                AccountDAO.Instance.DeleteAccount(username);
                MessageBox.Show("Cập nhật thành công!");
                LoadAccount();
            }
            catch
            {
                MessageBox.Show("Có lỗi trong quá trình xử lý!, Vui lòng kiểm tra lại!", "Thông báo!");
            }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            FromDanhSachHoaDon dshd = new FromDanhSachHoaDon();
            dshd.ShowDialog();
        }

        DateTime currentday = DateTime.Now;
     

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            DateTime datefrom = new DateTime(currentday.Year, currentday.Month, 1);
            DateTime dateto = datefrom.AddMonths(1).AddDays(-1);
            Load_dgv_BillbyCurrentday(datefrom, dateto);
        }

        void Load_dgv_BillbyCurrentday(DateTime datefrom, DateTime dateto)
        {
            datetime_from.Value = datefrom;
            datetiem_to.Value = dateto;
            dgv_bill.DataSource = BillDAO.Instance.getListData(datefrom, dateto);
        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {
            int quy = (currentday.Month/4)+1;
            DateTime datefrom = new DateTime(currentday.Year, ((quy * 4)-4), 1);
            DateTime dateto = datefrom.AddMonths(4).AddDays(30);
            Load_dgv_BillbyCurrentday(datefrom, dateto);
            
        }

        private void simpleButton7_Click(object sender, EventArgs e)
        {
            DateTime datefrom = new DateTime(currentday.Year, 1, 1);
            DateTime dateto = datefrom.AddYears(1).AddDays(-1);
            Load_dgv_BillbyCurrentday(datefrom, dateto);
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            ChiTietThongKe cttk = new ChiTietThongKe(datetime_from.Value, datetiem_to.Value);
            cttk.ShowDialog();
        }

        private void BTN_FAMILYCARRD_Click(object sender, EventArgs e)
        {
            Room room = lvsBill.Tag as Room;
            int vip = room.Vip;
            cohieu = 2;
            if (vip == 1)
            {
                double giamgia = 0.2;
                double Thanhtien = float.Parse(txtThanhtien.Text);
                double tiengiamgia = giamgia * Thanhtien;
                double thanhtiensaukhigamgia = (Thanhtien - tiengiamgia) + 30000;
                txtThanhtien.Text = thanhtiensaukhigamgia.ToString();
            }
            else
            {
                double giamgia = 0.2;
                double Thanhtien = double.Parse(txtThanhtien.Text);
                double tiengiamgia = giamgia * Thanhtien;
                double thanhtiensaukhigamgia = Thanhtien - tiengiamgia;
                txtThanhtien.Text = thanhtiensaukhigamgia.ToString();
            }

            BTN_FAMILYCARRD.Enabled = false;
            BTN_VIPCARRD.Enabled = false;
        }

        private void simpleButton8_Click(object sender, EventArgs e)
        {
        }

        private void dgv_nhanvien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_hoten.Text = dgv_nhanvien.CurrentRow.Cells[1].Value.ToString();
            datePicker_Nhanvien.Text = dgv_nhanvien.CurrentRow.Cells[2].Value.ToString();
            string gioitinh = dgv_nhanvien.CurrentRow.Cells[3].Value.ToString();
            if (gioitinh == "Nam")
                rd_nam.Checked = true;
            if (gioitinh == "Nữ")
                rd_nu.Checked = true;
            txt_diachi.Text = dgv_nhanvien.CurrentRow.Cells[4].Value.ToString();
            txt_cmnd.Text = dgv_nhanvien.CurrentRow.Cells[5].Value.ToString();
            txt_dienthoai.Text = dgv_nhanvien.CurrentRow.Cells[6].Value.ToString();
            comboBox1.Text = dgv_nhanvien.CurrentRow.Cells[7].Value.ToString();
            textBox1.Text = dgv_nhanvien.CurrentRow.Cells[0].Value.ToString();
            ControlNhanVien(false);
            suaNhanVien.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //WordExport w = new WordExport();
            //w.QuyetDinhKhenThuong("1", "2", "3", "4", "5", "6", "7", "8", "9");

            
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
          
        }

        private void simpleButton8_Click_1(object sender, EventArgs e)
        {
            WordExport w = new WordExport();
            DateTime datebc = date_ngaybaocao.Value;
            w.BaoCaoDoanhThu(datebc.Day.ToString(), datebc.Month.ToString(), datebc.Year.ToString(), "Báo cáo doanh thu", txt_hotenbaocao.Text, txt_chinhanhbaocao.Text, datebc.ToString(), txt_doanhthubaocao.Text, txt_giamgiabaocao.Text, txt_giôcngbaocao.Text, txt_sodienbaocao.Text, txt_sonuocbaocao.Text);
        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void xóaToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(textBox2.Text);
                ProSerDAO.Instance.DeleteProser(id);
                MessageBox.Show("Xóa thành công!");
                LoadAll();
            }
            catch
            {
                MessageBox.Show("Có lỗi phát sinh!", "Thông báo!");
            }
        }

        
        

      



    }
}