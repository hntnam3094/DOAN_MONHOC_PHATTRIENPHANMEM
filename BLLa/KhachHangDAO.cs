using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data;
using BLLa.Database;
using DAL.NghiepVu_LinQ;
using DAL.NghiepVu_Database;
namespace BLLa
{
    public class KhachHangDAO
    {
        private static KhachHangDAO instance;

        public static KhachHangDAO Instance
        {
            get { if (instance == null) instance = new KhachHangDAO(); return KhachHangDAO.instance; }
            private set { KhachHangDAO.instance = value; }
        }

        public List<KhachHang> getListKhachHang()
        {
            List<KhachHang> listKH = new List<KhachHang>();
            string query = "SELECT * FROM dbo.KHACHHANG";
            DataTable data = DataProvider.Instance.ExcuteQuery(query);
            foreach (DataRow ietm in data.Rows)
            {
                listKH.Add(new KhachHang(ietm));
            }

            return listKH;
        }

        public void insertKhachHang(string sdt, string username, string gioitinh, DateTime namsinh, string cmnnd, string address, string email, int hoatdong, int tichdiem)
        {
            KhachHangLINQ.Instance.AddnewKhachHang(sdt, username, gioitinh, namsinh, cmnnd, address, email, hoatdong, tichdiem);
        }


        public KhachHang getKHbyID(int id)
        {
            string query = "SELECT * FROM dbo.KHACHHANG WHERE Id =" + id;
            DataTable data = DataProvider.Instance.ExcuteQuery(query);
            return new KhachHang(data.Rows[0]);

        }

        public void UpdateKhachHang(int id, string sdt, string username, string gioitinh, DateTime namsinh, string cmnnd, string address, string email, int hoatdong, int tichdiem)
        {
            KhachHangLINQ.Instance.UpdateKhachHang(id, sdt, username, gioitinh, namsinh, cmnnd, address, email, hoatdong, tichdiem);
        }

        public void DeleteKhachHang(int id)
        {
            KhachHangLINQ.Instance.DeleteKhachHang(id);
        }

        public void BlockKhachHANG(int id)
        {
            KhachHang kh = getKHbyID(id);
            if (kh.Hoatdong == 0)
                KhachHangLINQ.Instance.BlockKhachHang(id, 1);
            else if (kh.Hoatdong == 1)
                KhachHangLINQ.Instance.BlockKhachHang(id, 0);
        }

        public IQueryable getListKHbyHD()
        {
            return KhachHangLINQ.Instance.LoadKHbyHoatDong();
        }

        public int getIDKH_intbIllb_idRoom(int idroom)
        {
            return KhachHangDB.Instance.getIDKH_inBillUncheck(idroom);
        }

        public DataTable getListKH_notblock()
        {
            return KhachHangDB.Instance.getListKhachHang_notBlock();
        }

        

       
    }
}
