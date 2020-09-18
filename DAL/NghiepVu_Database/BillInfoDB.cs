using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.NghiepVu_Database
{
    public class BillInfoDB
    {
        private static BillInfoDB instance;

        public static BillInfoDB Instance
        {
            get { if (instance == null) instance = new BillInfoDB(); return BillInfoDB.instance; }
            private set { BillInfoDB.instance = value; }
        }

        private BillInfoDB() { }

        public DataTable getMenuList(int idroom)
        {
            string query = "SELECT dbo.PRO_SER.NAME, dbo.BILLINFO.COUNT, dbo.BILLINFO.COUNT*dbo.PRO_SER.Price AS ThanhTien FROM dbo.Room, dbo.BILL, dbo.BILLINFO, dbo.PRO_SER WHERE dbo.Room.ID = dbo.BILL.IdRoom and dbo.BILL.ID = dbo.BILLINFO.IDBILL AND dbo.BILLINFO.IDPRO_SER = dbo.PRO_SER.ID AND BILL.Status = 0 AND dbo.Room.ID = " + idroom;
            DataTable data = DataProvider.Instance.ExcuteQuery(query);
            return data;
        }

        public DataTable getListBillInfobyIDBill(int idbill)
        {
            string query = "  SELECT * FROM dbo.BILLINFO WHERE IDBILL = " + idbill;
            DataTable data = DataProvider.Instance.ExcuteQuery(query);
            return data;
        }

         public bool addnew_ProSer(int idbill, int idproser, int count)
        {
            string query = " dbo.USP_ADDNewProSer @IdBill , @IdroSer , @Count";
            int result = DataProvider.Instance.ExcuteNonQuery(query, new object[] { idbill, idproser, count });
            return result > 0;
        }

         public DataTable getListBillInfo(int idbill)
         {
             string query = "SELECT dbo.PRO_SER.NAME, dbo.BILLINFO.COUNT, dbo.BILLINFO.COUNT*dbo.PRO_SER.Price AS ThanhTien FROM dbo.Room, dbo.BILL, dbo.BILLINFO, dbo.PRO_SER WHERE dbo.Room.ID = dbo.BILL.IdRoom AND dbo.BILL.ID = dbo.BILLINFO.IDBILL AND dbo.BILLINFO.IDPRO_SER = dbo.PRO_SER.ID AND BILL.Status = 1 AND BILL.ID = " + idbill;
             DataTable data = DataProvider.Instance.ExcuteQuery(query);
             return data;
         }
    }
}
