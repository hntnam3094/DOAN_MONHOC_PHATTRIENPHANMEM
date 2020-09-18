using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.NghiepVu_Database
{
    public class NhanVienDB
    {
         private static NhanVienDB instance;

        public static NhanVienDB Instance
        {
            get { if (instance == null) instance = new NhanVienDB(); return NhanVienDB.instance; }
            private set { NhanVienDB.instance = value; }
        }

        private NhanVienDB() { }

        public DataTable getListNhanvien_notBlock()
        {
            string query = "SELECT * FROM dbo.NV_TuVan WHERE HoatDong_TV = 0 and ID_LOAINV = 1";
            DataTable data = DataProvider.Instance.ExcuteQuery(query);
            return data;
        }

        public DataTable getListNhanVien()
        {
            string query = "  SELECT dbo.NV_TuVan.ID, dbo.NV_TuVan.NAME, NamSinh, GioiTinh, DIACHI, CMND, SDT, dbo.LOAI_NV.NAME AS [NameNV], HoatDong_TV FROM dbo.NV_TuVan, dbo.LOAI_NV WHERE dbo.NV_TuVan.ID_LOAINV = dbo.LOAI_NV.ID ";
            DataTable data = DataProvider.Instance.ExcuteQuery(query);
            return data;
        }

        public DataTable getLoaiNV()
        {
            string query = "SELECT * FROM dbo.LOAI_NV";
            DataTable data = DataProvider.Instance.ExcuteQuery(query);
            return data;
        }

        public DataTable getListNhanVien_by_KhachHang(int idkh, DateTime getdate)
        {
            string query = string.Format("SELECT dbo.NV_TuVan.ID, dbo.NV_TuVan.NAME FROM dbo.LICHHEN_NV, dbo.NV_TuVan  WHERE dbo.LICHHEN_NV.ID_NV_TV = dbo.NV_TuVan.ID AND Id_KH = {0}  AND Ngay = '{1}' GROUP BY dbo.NV_TuVan.ID, dbo.NV_TuVan.NAME", idkh, getdate);
            DataTable data = DataProvider.Instance.ExcuteQuery(query);
            return data;
        }
    }
}
