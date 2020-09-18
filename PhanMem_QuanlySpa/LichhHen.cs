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


namespace PhanMem_QuanlySpa
{
    public partial class LichhHen : DevExpress.XtraEditors.XtraForm
    {
        public LichhHen()
        {
            InitializeComponent();
            currentday = DateTime.Now;
            Load_tatca_velichhen();
        }

        private List<FlowLayoutPanel> listFlowplayoutPanel = new List<FlowLayoutPanel>();
        private DateTime currentday;

        void Load_tatca_velichhen(){
           
            them_ngay(50);
            HienthingayHientai();
        }

        void them_ngay(int totalDay)
        {
            listFlowplayoutPanel.Clear();
            for (int i = 1; i < totalDay; i++)
            {
                FlowLayoutPanel flp = new FlowLayoutPanel();
                flp.Name = i.ToString();
                flp.Size = new Size(230, 150);
                flp.BorderStyle = BorderStyle.FixedSingle;
                flp.BackColor = Color.White;
                flp.AutoScroll = true;
                flp.Margin = new Padding(0,3,7,3);
                flp_Day.Controls.Add(flp);
                listFlowplayoutPanel.Add(flp);

            }
        }


        void HienthingayHientai()
        {
            lb_Month_year.Text = currentday.ToString("MMMM , yyyy");
            int NgayDauCuaThangTrongTuan = Get_NgayDauTienCuaThangTrongTuan();
            if (NgayDauCuaThangTrongTuan == 0)
                NgayDauCuaThangTrongTuan += 7;
            int NgayCuaThang = Get_NgayCuaThang();
            NgayCuaThang += 1;
            ThemNgay_in_FLP(NgayDauCuaThangTrongTuan, NgayCuaThang);
            ThemLichHen_list_Flp(NgayDauCuaThangTrongTuan);
        }

        int Get_NgayDauTienCuaThangTrongTuan()
        {
            DateTime NgayDauThang = new DateTime(currentday.Year, currentday.Month, 1);
            return (int)NgayDauThang.DayOfWeek; 
        }

        int Get_NgayCuaThang()
        {
            DateTime ngayCuaThang = new DateTime(currentday.Year, currentday.Month, 1);
            return ngayCuaThang.AddMonths(1).AddDays(-1).Day;
        }

        void ThemNgay_in_FLP(int NgayDauCuaThangTrongTuan, int NgayCuaThang)
        {
            foreach (FlowLayoutPanel flp in listFlowplayoutPanel)
            {
                flp.Controls.Clear();
                flp.Tag = 0;
                flp.BackColor = Color.White;
            }

            for (int i = 1; i < NgayCuaThang; i++)
            {
                Label lb = new Label();
                lb.Name = "day " + i.ToString();
                lb.AutoSize = false;
                lb.TextAlign = ContentAlignment.TopLeft;
                lb.Text = i.ToString();
                listFlowplayoutPanel[(i - 1) + (NgayDauCuaThangTrongTuan - 1)].Tag = i;
                listFlowplayoutPanel[(i - 1) + (NgayDauCuaThangTrongTuan - 1)].Controls.Add(lb);
                

                if (new DateTime(currentday.Year, currentday.Month, i) == DateTime.Today)
                {
                    listFlowplayoutPanel[(i - 1) + (NgayDauCuaThangTrongTuan - 1)].BackColor = Color.BurlyWood;
                }
            }
        }


        void ThemLichHen_list_Flp(int NgayDauThangCuaTuan)
        {
            DateTime startDay = new DateTime(currentday.Year, currentday.Month, 1);
            DateTime endDay = startDay.AddMonths(1).AddDays(-1);

            DataTable data = LichHenDAO.Instance.getListLichHen(startDay, endDay);
            foreach (DataRow item in data.Rows)
            {
                LichHen LH = new LichHen(item);
                DateTime NgayHen = LH.Ngay;
                LinkLabel Link = new LinkLabel();
                Link.Tag = LH;
                Link.Name = LH.Id.ToString();
                Link.Text = LH.Username.ToString() + " (" + LH.Gio + ")";
                Link.Click += Link_Click;
                listFlowplayoutPanel[(NgayHen.Day - 1) + (NgayDauThangCuaTuan - 1)].Controls.Add(Link);
            }

        }

        void Link_Click(object sender, EventArgs e)
        {
            int idLH = ((sender as LinkLabel).Tag as LichHen).Id;
            LichHen lh = LichHenDAO.Instance.getChitietLichHen(idLH);
            ChiTietLichHen ctlh = new ChiTietLichHen(lh);
            ctlh.ShowDialog();
            flp_Day.Controls.Clear();
            Load_tatca_velichhen();

        }

        void PrevMonth()
        {
            currentday = currentday.AddMonths(-1);
            HienthingayHientai();
        }

        void NextMonth()
        {
            currentday = currentday.AddMonths(1);
            HienthingayHientai();
        }

        void Today()
        {
            currentday = DateTime.Now;
            HienthingayHientai();
        }


        private void simpleButton3_Click(object sender, EventArgs e)
        {
            NextMonth();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            PrevMonth();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Today();
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
           
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            flp_Day.Controls.Clear();
            Load_tatca_velichhen();
        }

        private void simpleButton8_Click(object sender, EventArgs e)
        {
            Create_Appointment newApp = new Create_Appointment();
            newApp.ShowDialog();
            flp_Day.Controls.Clear();
            Load_tatca_velichhen();
        }

      
    }
}