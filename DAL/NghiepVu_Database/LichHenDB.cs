
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.NghiepVu_Database
{
    public class LichHenDB
    {
        private static LichHenDB instance;

        public static LichHenDB Instance
        {
            get { if (instance == null) instance = new LichHenDB(); return LichHenDB.instance; }
            private set { LichHenDB.instance = value; }
        }

        private LichHenDB() { }

        public DataTable getListLichHen(DateTime startDay, DateTime endDay)
        {
         
            string query = string.Format("EXECUTE dbo.USP_GetLichHen @Startday = '{0}' , @Endday = '{1}'", startDay, endDay);
            DataTable data = DataProvider.Instance.ExcuteQuery(query);
            
            return data;
        }

        public bool ThemLichHen(int idGio, int idNV, int idKH, string noidung,int status, DateTime ngayhen)
        {
            string query = string.Format("INSERT INTO dbo.LICHHEN_NV VALUES( " + idGio + " , " + idNV + " , "+idKH+" , N'"+noidung+"' , "+status+" ,'"+ngayhen+"' )");
            int result = (int)DataProvider.Instance.ExcuteNonQuery(query);
            return result > 0;
        }

        public DataTable getChitietLichHen_by_IDLH(int id)
        {
            string query = "EXEC dbo.USP_GetChitiet_LichHen @idLH = " + id;
            DataTable data = DataProvider.Instance.ExcuteQuery(query);
            return data;
        }

        public bool HoanThanhLichHen(int id)
        {
            string query = "UPDATE dbo.LICHHEN_NV SET Status = 1 WHERE ID = " + id;
            int rs = DataProvider.Instance.ExcuteNonQuery(query);
            return rs > 0;
        }

        public bool DeleteLichHen(int id)
        {
            string query = "DELETE dbo.LICHHEN_NV WHERE ID = " + id;
            int rs = DataProvider.Instance.ExcuteNonQuery(query);
            return rs > 0;
        }

       
    }
}
