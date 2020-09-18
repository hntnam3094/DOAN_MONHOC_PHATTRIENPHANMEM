using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.NghiepVu_LinQ
{
    public class Category_LINQ
    {
        qlyspaDataContext spa = new qlyspaDataContext();
        private static Category_LINQ instance;

        public static Category_LINQ Instance
        {
            get { if (instance == null) instance = new Category_LINQ(); return Category_LINQ.instance; }
            private set { Category_LINQ.instance = value; }
        }

        private Category_LINQ() { }

        public void Addnew_Category(string name)
        {
            CATEGORY category = new CATEGORY();
            category.NAME = name;
            spa.CATEGORies.InsertOnSubmit(category);
            spa.SubmitChanges();
        }

        public void UpdateCategory(int id, string name)
        {
            CATEGORY catte = spa.CATEGORies.Where(t => t.ID == id).FirstOrDefault();
            if (catte != null)
            {
                catte.NAME = name;
                spa.SubmitChanges();
            }
        }

        public void DeleteCategory(int id)
        {
            CATEGORY cate = spa.CATEGORies.Where(t => t.ID == id).FirstOrDefault();
            if (cate != null)
            {
                spa.CATEGORies.DeleteOnSubmit(cate);
                spa.SubmitChanges();
            }
        }
    }
}
