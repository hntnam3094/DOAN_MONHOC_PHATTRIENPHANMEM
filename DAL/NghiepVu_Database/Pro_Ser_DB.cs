using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.NghiepVu_Database
{
    public class Pro_Ser_DB
    {
        private static Pro_Ser_DB instance;

        public static Pro_Ser_DB Instance
        {
            get { if (instance == null) instance = new Pro_Ser_DB(); return Pro_Ser_DB.instance; }
            private set { Pro_Ser_DB.instance = value; }
        }

        private Pro_Ser_DB() { }

        public DataTable getListPro_ser(int idCategory)
        {
            DataTable data = DataProvider.Instance.ExcuteQuery("  SELECT * FROM dbo.PRO_SER WHERE IDCATEGORY = " + idCategory);
            return data;
        }

        public bool UpdateProSer(int id, string name, int soluong, string mota, float price)
        {
            string query = "UPDATE dbo.PRO_SER SET NAME = N'" + name + "', SOLUONG = " + soluong + ", MOTA = N'" + mota + "', Price = " + price + " WHERE ID = " + id;
            int rs = DataProvider.Instance.ExcuteNonQuery(query);
            return rs > 0;
        }

        public bool DeleteProser(int id)
        {
            string query = "DELETE FROM dbo.PRO_SER WHERE ID = " + id;
            int rs = DataProvider.Instance.ExcuteNonQuery(query);
            return rs > 0;
        }
    }
}
