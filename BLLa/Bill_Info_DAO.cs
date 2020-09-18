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
    public class Bill_Info_DAO
    {
        private static Bill_Info_DAO instance;

        public static Bill_Info_DAO Instance
        {
            get { if (instance == null) instance = new Bill_Info_DAO(); return Bill_Info_DAO.instance; }
            private set { Bill_Info_DAO.instance = value; }
        }

        private Bill_Info_DAO() { }


        public void CreateNewBillInfo(int idbill, int idproser, int count)
        {
            BillInfo_LINQ.Instance.CreateNewBillInfo(idbill, idproser, count);
        }

        public List<Menu> getListMenu_byIDRoom(int idRoom)
        {
            List<Menu> listmenu = new List<Menu>();
            DataTable data = BillInfoDB.Instance.getMenuList(idRoom);
            foreach (DataRow item in data.Rows)
            {
                Menu menu = new Menu(item);
                listmenu.Add(menu);
            }
            return listmenu;
        }

        public bool AddnewPorser(int idbill, int idproser, int count)
        {
            return BillInfoDB.Instance.addnew_ProSer(idbill, idproser, count);
        }

        public List<Menu> getListBillInfo_byIDBill(int idbill)
        {
            List<Menu> listmenu = new List<Menu>();
            DataTable data = BillInfoDB.Instance.getListBillInfo(idbill);
            foreach (DataRow item in data.Rows)
            {
                Menu menu = new Menu(item);
                listmenu.Add(menu);
            }
            return listmenu;
        }
    }
}
