using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.NghiepVu_Database;
using System.Data;
using BLLa.Database;
namespace BLLa
{
    public class LichHenDAO
    {
        private static LichHenDAO instance;

        public static LichHenDAO Instance
        {
            get { if (instance == null) instance = new LichHenDAO(); return LichHenDAO.instance; }
            private set { LichHenDAO.instance = value; }
        }
        private LichHenDAO() { }


        public DataTable getListLichHen(DateTime startDay, DateTime endDay)
        {
            return LichHenDB.Instance.getListLichHen(startDay, endDay);
        }

        public DataTable getList_GioTV(DateTime date, int idNV)
        {
            return GioTVDB.Instance.getList_Gio(date,idNV);
        }

        public bool ThemLichHen(int idGio, int idNV, int idkh, string noidung, int status, DateTime ngayhen)
        {
            return LichHenDB.Instance.ThemLichHen(idGio, idNV, idkh, noidung, status, ngayhen);
        }

        public LichHen getChitietLichHen(int id)
        {
            DataTable data = LichHenDB.Instance.getChitietLichHen_by_IDLH(id);
            return new LichHen(data.Rows[0]);
        }

        public bool HoanThanhLichHen(int id)
        {
            return LichHenDB.Instance.HoanThanhLichHen(id);
        }

        public bool DeleteLichHen(int id)
        {
            return LichHenDB.Instance.DeleteLichHen(id);
        }
    }
}