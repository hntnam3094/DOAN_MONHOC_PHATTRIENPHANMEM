using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.NghiepVu_Database
{
    public class CategoryDB
    {
        private static CategoryDB instance;

        public static CategoryDB Instance
        {
            get { if (instance == null) instance = new CategoryDB(); return CategoryDB.instance; }
            private set { CategoryDB.instance = value; }
        }

        private CategoryDB() { }

        public DataTable getListCategory()
        {
            DataTable data = new DataTable();
            data = DataProvider.Instance.ExcuteQuery("SELECT * FROM dbo.CATEGORY");
            return data;
        }
    }
}
