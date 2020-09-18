using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.NghiepVu_Database
{
    public class KhachHangDB
    {
        private static KhachHangDB instance;

        public static KhachHangDB Instance
        {
            get { if (instance == null) instance = new KhachHangDB(); return KhachHangDB.instance; }
            private set { KhachHangDB.instance = value; }
        }

        private KhachHangDB() { }

        public int getIDKH_inBillUncheck(int idroom)
        {
            string query = "SELECT IdKH FROM dbo.BILL WHERE IdRoom = " + idroom + " AND Status = 0";
            int result = (int)DataProvider.Instance.ExcuteScalar(query);
            return result;
        }

        public DataTable getListKhachHang_notBlock()
        {
            string query = "SELECT * FROM dbo.KHACHHANG WHERE HOATDONG = 0";
            DataTable data = DataProvider.Instance.ExcuteQuery(query);
            return data;
        }

    }
}
