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
    public class ProSerDAO
    {
        private static ProSerDAO instance;

        public static ProSerDAO Instance
        {
            get { if (instance == null) instance = new ProSerDAO(); return ProSerDAO.instance; }
            private set { ProSerDAO.instance = value; }
        }

        private ProSerDAO() { }

        public List<Pro_Ser> getListPro_ser(int idCategory)
        {
            List<Pro_Ser> listProSer = new List<Pro_Ser>();
            DataTable data = Pro_Ser_DB.Instance.getListPro_ser(idCategory);
            foreach (DataRow item in data.Rows)
            {
                listProSer.Add(new Pro_Ser(item));
            }
            return listProSer;
        }


        public DataTable getListPro_Ser2(int idCategory)
        {
            return Pro_Ser_DB.Instance.getListPro_ser(idCategory);
        }

        public void AddNew_ProSer(string name, int idcategory, int soluong, string mota, float price)
        {
             ProSer_LINQ.Instance.addnewProSer(name, idcategory, soluong, mota, price);
        }

        public bool UpdateProSer(int id, string name, int soluong, string mota, float price)
        {
             return Pro_Ser_DB.Instance.UpdateProSer(id, name, soluong, mota, price);
        }

        public bool DeleteProser(int id)
        {
            return Pro_Ser_DB.Instance.DeleteProser(id);
        }
    }
}
