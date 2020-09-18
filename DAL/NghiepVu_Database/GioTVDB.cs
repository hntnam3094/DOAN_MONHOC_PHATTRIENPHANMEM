using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.NghiepVu_Database
{
    public class GioTVDB
    {
        private static GioTVDB instance;

        public static GioTVDB Instance
        {
            get { if (instance == null) instance = new GioTVDB(); return GioTVDB.instance; }
            private set { GioTVDB.instance = value; }
        }

        private GioTVDB() { }

        public DataTable getList_Gio(DateTime date, int idNV)
        {
            string query = string.Format("SELECT * FROM dbo.Gio_TV  WHERE ID NOT IN (SELECT dbo.Gio_TV.ID FROM dbo.Gio_TV, dbo.LICHHEN_NV, dbo.NV_TuVan WHERE dbo.Gio_TV.ID = dbo.LICHHEN_NV.ID_Gio_TV AND dbo.LICHHEN_NV.ID_NV_TV = dbo.NV_TuVan.ID AND Ngay = '{0}' AND ID_NV_TV = {1} )", date, idNV);
            DataTable data = DataProvider.Instance.ExcuteQuery(query);
            return data;
        }


    }
}
