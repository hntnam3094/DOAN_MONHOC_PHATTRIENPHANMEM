using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.NghiepVu_LinQ
{
    public class Bill_LINQ
    {
        qlyspaDataContext spa = new qlyspaDataContext();
        private static Bill_LINQ instance;

        public static Bill_LINQ Instance
        {
            get { if (instance == null) instance = new Bill_LINQ(); return Bill_LINQ.instance; }
            private set { Bill_LINQ.instance = value; }
        }

        private Bill_LINQ() { }

        public void CreateBill(int idKH, int idRoom, float totalprice, DateTime datecheckin, int status)
        {
            BILL1 bill = new BILL1();
            bill.IdKH = idKH;
            bill.IdRoom = idRoom;
            bill.TOTALPRICE = totalprice;
            bill.DATEIN = datecheckin;
            bill.Status = status;
            bill.Discount = 0;
            spa.BILL1s.InsertOnSubmit(bill);
            spa.SubmitChanges();
        }
    }
}
