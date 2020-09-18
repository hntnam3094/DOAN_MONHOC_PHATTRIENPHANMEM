using BLLa;
using BLLa.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhanMem_QuanlySpa
{
    public partial class ChiTietThongKe : Form
    {
        public ChiTietThongKe(DateTime datefrom, DateTime dateto)
        {
            InitializeComponent();
            LoadALL(datefrom, dateto);
        }

        void LoadALL(DateTime datefrom, DateTime dateto)
        {
            DataTable datta = BillDAO.Instance.getListChiTietThongke(datefrom, dateto);
            dataGridView1.DataSource = datta;
            float gia=0;
            float giamgia=0;
            List<HoaDOn> listHoadon = BillDAO.Instance.getListHoadONThongke(datefrom, dateto);
            foreach (HoaDOn hd in listHoadon)
            {
                gia += hd.Price;
                giamgia += hd.Afterdiscount;
            }
            CultureInfo culture = new CultureInfo("vi-VN");

            //Thread.CurrentThread.CurrentCulture = culture;

            label3.Text = gia.ToString("c", culture);
            label4.Text = giamgia.ToString("c", culture);
        }
    }
}
