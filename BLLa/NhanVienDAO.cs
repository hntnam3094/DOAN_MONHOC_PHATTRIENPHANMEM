using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data;
using DAL.NghiepVu_LinQ;
using DAL.NghiepVu_Database;
namespace BLLa
{
    public class NhanVienDAO
    {
        private static NhanVienDAO instance;

        public static NhanVienDAO Instance
        {
            get { if (instance == null) instance = new NhanVienDAO(); return NhanVienDAO.instance; }
            private set { NhanVienDAO.instance = value; }
        }

        private NhanVienDAO() { }


        public DataTable getListNV_notBlock()
        {
            return NhanVienDB.Instance.getListNhanvien_notBlock();
        }


        public DataTable getListNhanVien()
        {
            return NhanVienDB.Instance.getListNhanVien();
        }

        public void AddnewNhanVien(string name, DateTime namsinh,string sdt, string gioitinh, string diachi, string cmnd, int loainv, int hoatdong)
        {
            NhanVien_LINQ.Instance.addnew_NhanVien(name, namsinh, gioitinh,sdt, diachi, cmnd, loainv, hoatdong);
        }

        public void DeleteNhanVien(int id)
        {
            NhanVien_LINQ.Instance.deleteNhanVien(id);
        }

        public void SuaNhanVien(int id,string name, DateTime namsinh, string sdt, string gioitinh, string diachi, string cmnd, int loainv, int hoatdong)
        {
            NhanVien_LINQ.Instance.SuaNhanVien(id, name, namsinh, sdt, gioitinh, diachi, cmnd, loainv, hoatdong);
        }


        public void Block_NhanVien(int id, int hoatdong)
        {
            NhanVien_LINQ.Instance.Block_NhanVien(id, hoatdong);
        }

        public DataTable getListLoaiNhanVien()
        {
            return NhanVienDB.Instance.getLoaiNV();
        }

        public DataTable getListNhanVien_by_KhachHang(int idkh, DateTime getdate)
        {
            return NhanVienDB.Instance.getListNhanVien_by_KhachHang(idkh, getdate);
        }
    }
}
