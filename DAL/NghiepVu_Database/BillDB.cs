using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.NghiepVu_Database
{
    public class BillDB
    {
        private static BillDB instance;

        public static BillDB Instance
        {
            get { if (instance == null) instance = new BillDB(); return BillDB.instance; }
            private set { BillDB.instance = value; }
        }

        private BillDB() { }
        public bool createNewBill(int idKH, int idRoom, float totalprice, DateTime datecheckin, int status)
        {
            string query = "INSERT INTO dbo.BILL VALUES  ("+idKH+" ,"+idRoom+" , "+totalprice+" ,'"+datecheckin+"' , "+status+" , 0 )";
            int rs = DataProvider.Instance.ExcuteNonQuery(query);
            return rs > 0;
        }
        public DataTable GetBillUnCheck_byIDRoom(int idroom)
        {
            string query = "SELECT * FROM dbo.BILL WHERE IdRoom = " + idroom + " AND Status = 0";
            DataTable data = DataProvider.Instance.ExcuteQuery(query);
            return data;
        }

        public bool ThanhToanBill(int idkh, int idroom, float totalprice, int discount)
        {
            string query = "EXEC dbo.USP_ThanhToan @IdKH , @idRoom , @totalPrice ,  @Discount ";
            int result = DataProvider.Instance.ExcuteNonQuery(query, new object[] { idkh, idroom, totalprice, discount });
            return result > 0;

        }

        public DataTable getListBill(DateTime datefrom, DateTime dateto)
        {
            string query = "SELECT * FROM dbo.BILL WHERE DATEIN BETWEEN '" + datefrom + "' AND '" + dateto + "'";
            DataTable data = DataProvider.Instance.ExcuteQuery(query);
            return data;
        }

        public DataTable getChiTietRoom(int idRoom)
        {
            string query = "EXEC dbo.getKhachHangRoom @idRoom = " + idRoom;
            DataTable data = DataProvider.Instance.ExcuteQuery(query);
            return data;
        }

        public int getMaxIDBill()
        {
            string query = "SELECT MAX(ID) FROM dbo.BILL";
            int rs = (int)DataProvider.Instance.ExcuteScalar(query);
            return rs;
        }

        public DataTable getLastBill(int id)
        {
            string query = "SELECT dbo.PRO_SER.NAME, dbo.BILLINFO.COUNT, dbo.BILLINFO.COUNT*dbo.PRO_SER.Price AS ThanhTien FROM dbo.Room, dbo.BILL, dbo.BILLINFO, dbo.PRO_SER WHERE dbo.Room.ID = dbo.BILL.IdRoom AND dbo.BILL.ID = dbo.BILLINFO.IDBILL AND dbo.BILLINFO.IDPRO_SER = dbo.PRO_SER.ID AND BILL.Status = 1 AND BILL.ID = " + id;
            DataTable data = DataProvider.Instance.ExcuteQuery(query);
            return data;
        }

        public DataTable getListChiTietThongke(DateTime datefrom, DateTime dateto)
        {
            string query = "EXEC dbo.USP_GetThongKe @datefrom = '" + datefrom + "', @dateto = '" + dateto + "'";
            DataTable data = DataProvider.Instance.ExcuteQuery(query);
            return data;
        }

        public DataTable getListThongkeByNhanVien(DateTime datefrom, DateTime dateto, int idNV)
        {
            string query = "EXEC dbo.Usp_getThongKeByNhanVien @datefrom = '"+datefrom+"', @dateto = '"+dateto+"', @idnv = "+idNV+" ";
            DataTable data = DataProvider.Instance.ExcuteQuery(query);
            return data;
        }

        public bool CreateNewBill2(int idKH, int idRoom, float totalprice, DateTime datecheckin, int status)
        {
            string query = "EXEC dbo.USP_MoPhong @idRoom , @idKH , @totalprice , @datein  , @status , @discount  ";
            int rs = DataProvider.Instance.ExcuteNonQuery(query, new object[] { idRoom, idKH, totalprice, datecheckin, status, 0 });
            return rs > 0;
        }
    }
}
