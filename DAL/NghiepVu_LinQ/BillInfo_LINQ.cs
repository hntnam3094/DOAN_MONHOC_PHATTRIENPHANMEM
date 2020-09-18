using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.NghiepVu_LinQ
{
    public class BillInfo_LINQ
    {
        qlyspaDataContext spa = new qlyspaDataContext();
        private static BillInfo_LINQ instance;

        public static BillInfo_LINQ Instance
        {
            get { if (instance == null) instance = new BillInfo_LINQ(); return BillInfo_LINQ.instance; }
            private set { BillInfo_LINQ.instance = value; }
        }

        private BillInfo_LINQ() { }

        public void CreateNewBillInfo(int idbill, int idproser, int count)
        {
            BILLINFO bi = new BILLINFO();
            bi.IDBILL = idbill;
            bi.IDPRO_SER = idproser;
            bi.COUNT = count;
            spa.BILLINFOs.InsertOnSubmit(bi);
            spa.SubmitChanges();
        }
    }
}
