using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.NghiepVu_LinQ
{
    public class NhanVien_LINQ
    {
       qlyspaDataContext spa = new qlyspaDataContext();
        private static NhanVien_LINQ instance;

        public static NhanVien_LINQ Instance
        {
            get { if (instance == null) instance = new NhanVien_LINQ(); return NhanVien_LINQ.instance; }
            private set { NhanVien_LINQ.instance = value; }
        }

        private NhanVien_LINQ() { }

        public void addnew_NhanVien(string name, DateTime namsinh,string sdt, string gioitinh, string diachi, string cmnd, int loainv, int hoatdong)
        {
            NV_TuVan nv = new NV_TuVan();
            nv.NAME = name;
            nv.NamSinh = namsinh;
            nv.GioiTinh = gioitinh;
            nv.DIACHI = diachi;
            nv.CMND = cmnd;
            nv.SDT = sdt;
            nv.ID_LOAINV = loainv;
            nv.HoatDong_TV = hoatdong;
            spa.NV_TuVans.InsertOnSubmit(nv);
            spa.SubmitChanges();
        }

        public void SuaNhanVien(int id, string name, DateTime namsinh, string sdt, string gioitinh, string diachi, string cmnd, int loainv, int hoatdong)
        {
            NV_TuVan nv = spa.NV_TuVans.Where(t => t.ID == id).FirstOrDefault();
            if (nv != null)
            {
                nv.NAME = name;
                nv.NamSinh = namsinh;
                nv.GioiTinh = gioitinh;
                nv.DIACHI = diachi;
                nv.CMND = cmnd;
                nv.SDT = sdt;
                nv.ID_LOAINV = loainv;
                nv.HoatDong_TV = hoatdong;
                spa.SubmitChanges();
            }
        }

        public void deleteNhanVien(int id)
        {
            NV_TuVan nv = spa.NV_TuVans.Where(t => t.ID == id).FirstOrDefault();
            if (nv != null)
            {
                spa.NV_TuVans.DeleteOnSubmit(nv);
                spa.SubmitChanges();
            }
        }

        public void Block_NhanVien(int id, int hoatdong)
        {
            NV_TuVan nv = spa.NV_TuVans.Where(t => t.ID == id).FirstOrDefault();
            if (nv != null)
            {
                nv.HoatDong_TV = hoatdong;
                spa.SubmitChanges();
            }
        }
    }
}
