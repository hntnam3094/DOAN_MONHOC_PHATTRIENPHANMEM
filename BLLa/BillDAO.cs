using BLLa.Database;
using DAL.NghiepVu_Database;
using DAL.NghiepVu_LinQ;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLa
{
    public class BillDAO
    {
        private static BillDAO instance;

        public static BillDAO Instance
        {
            get { if (instance == null) instance = new BillDAO(); return BillDAO.instance; }
            private set { BillDAO.instance = value; }
        }

        private BillDAO() { }

        public void createNewbIll(int idKH, int idRoom, float totalprice, DateTime datecheckin, int status)
        {
            BillDB.Instance.createNewBill(idKH, idRoom, totalprice, datecheckin, status);
        }

        public int GetBillUnCheckByIDRomm(int idRoom)
        {
            DataTable data = BillDB.Instance.GetBillUnCheck_byIDRoom(idRoom);
            return new Bill(data.Rows[0]).Id;
        }

        public bool ThanhToan(int idkh, int idroom, float totalprice, int discount)
        {
            return BillDB.Instance.ThanhToanBill(idkh, idroom, totalprice, discount);
        }

        public DataTable getListData(DateTime datefrom, DateTime dateto)
        {
            return BillDB.Instance.getListBill(datefrom, dateto);
        }


        public CT_Room getCTRomm(int idRoom)
        {
            DataTable data = BillDB.Instance.getChiTietRoom(idRoom);
            return new CT_Room(data.Rows[0]);
        }

        public int getMaxIDBill()
        {
            return BillDB.Instance.getMaxIDBill();
        }

        public Menu getLastBill(int idbillMax)
        {
            return new Menu(BillDB.Instance.getLastBill(idbillMax).Rows[0]);
        }

        public DataTable getListChiTietThongke(DateTime datefrom, DateTime dateto)
        {
            return BillDB.Instance.getListChiTietThongke(datefrom, dateto);
        }

        public List<HoaDOn> getListHoadONThongke(DateTime datefrom, DateTime dateto)
        {
            List<HoaDOn> listHoaDon = new List<HoaDOn>();
            DataTable data = BillDB.Instance.getListChiTietThongke(datefrom, dateto);
            foreach (DataRow item in data.Rows)
            {
                listHoaDon.Add(new HoaDOn(item));
            }
            return listHoaDon;
        }

        public List<HoaDOn> getListHoadONThongke(DateTime datefrom, DateTime dateto, int id)
        {
            List<HoaDOn> listHoaDon = new List<HoaDOn>();
            DataTable data = BillDB.Instance.getListThongkeByNhanVien(datefrom, dateto, id);
            foreach (DataRow item in data.Rows)
            {
                listHoaDon.Add(new HoaDOn(item));
            }
            return listHoaDon;
        }



        public bool createNewBill2(int idKH, int idRoom, float totalprice, DateTime datecheckin, int status)
        {
            return BillDB.Instance.CreateNewBill2(idKH, idRoom, totalprice, datecheckin, status);
        }
    }
}
