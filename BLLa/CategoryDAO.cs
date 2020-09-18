using BLLa.Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.NghiepVu_Database;
using DAL.NghiepVu_LinQ;
namespace BLLa
{
    public class CategoryDAO
    {
        private static CategoryDAO instance;

        public static CategoryDAO Instance
        {
            get { if (instance == null) instance = new CategoryDAO(); return CategoryDAO.instance; }
            private set { CategoryDAO.instance = value; }
        }

        public CategoryDAO() { }

        public List<Category> getListCategory()
        {
            List<Category> listCategory = new List<Category>();
            DataTable data = CategoryDB.Instance.getListCategory();
            foreach (DataRow item in data.Rows)
            {
                Category category = new Category(item);
                listCategory.Add(category);
            }

            return listCategory;
        }

        public DataTable getListCategory2()
        {
            return CategoryDB.Instance.getListCategory();
        }

        public void Addnew_Category(string name)
        {
            Category_LINQ.Instance.Addnew_Category(name);
        }

        public void UpdateCategory(int id, string name)
        {
            Category_LINQ.Instance.UpdateCategory(id, name);
        }

        public void DeleteCategory(int id)
        {
            Category_LINQ.Instance.DeleteCategory(id);
        }
    }
}
