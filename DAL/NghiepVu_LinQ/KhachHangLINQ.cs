using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.NghiepVu_LinQ
{
    public class KhachHangLINQ
    {
        qlyspaDataContext spa = new qlyspaDataContext();
        private static KhachHangLINQ instance;

        public static KhachHangLINQ Instance
        {
            get { if (instance == null) instance = new KhachHangLINQ(); return KhachHangLINQ.instance; }
            private set { KhachHangLINQ.instance = value; }
        }

        private KhachHangLINQ() { }

        public void AddnewKhachHang(string sdt, string username, string gioitinh, DateTime namsinh, string cmnnd, string address, string email, int hoatdong, int tichdiem)
        {
            KHACHHANG kh = new KHACHHANG();
            kh.SDT = sdt;
            kh.USERNAME = username;
            kh.GioiTinh = gioitinh;
            kh.NamSinh = namsinh;
            kh.CMND = cmnnd;
            kh.ADDRESS = address;
            kh.EMAIL = email;
            kh.HOATDONG = hoatdong;
            kh.TICHDIEM = tichdiem;
            spa.KHACHHANGs.InsertOnSubmit(kh);
            spa.SubmitChanges();
        }

        public void UpdateKhachHang(int id, string sdt, string username, string gioitinh, DateTime namsinh, string cmnnd, string address, string email, int hoatdong, int tichdiem)
        {
            KHACHHANG kh = spa.KHACHHANGs.Where(t => t.Id == id).FirstOrDefault();
            if (kh != null)
            {
                kh.SDT = sdt;
                kh.USERNAME = username;
                kh.GioiTinh = gioitinh;
                kh.NamSinh = namsinh;
                kh.CMND = cmnnd;
                kh.ADDRESS = address;
                kh.EMAIL = email;
                kh.HOATDONG = hoatdong;
                kh.TICHDIEM = tichdiem;
                spa.SubmitChanges();
            }
        }

        public void DeleteKhachHang(int id)
        {
            KHACHHANG kh = spa.KHACHHANGs.Where(t => t.Id == id).FirstOrDefault();
            if (kh != null)
            {
                spa.KHACHHANGs.DeleteOnSubmit(kh);
                spa.SubmitChanges();
            }
        }

        public void BlockKhachHang(int id, int hoatdong)
        {
            KHACHHANG kh = spa.KHACHHANGs.Where(t => t.Id == id).FirstOrDefault();
            if (kh != null)
            {
                kh.HOATDONG = hoatdong;
                spa.SubmitChanges();
            }
        }

        public IQueryable LoadKHbyHoatDong()
        {
            return (from kh in spa.KHACHHANGs.Where(t => t.HOATDONG == 0) select kh);
        }

   
    }
}
