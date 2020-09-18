using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.NghiepVu_LinQ
{
    public class ProSer_LINQ
    {
         qlyspaDataContext spa = new qlyspaDataContext();
        private static ProSer_LINQ instance;

        public static ProSer_LINQ Instance
        {
            get { if (instance == null) instance = new ProSer_LINQ(); return ProSer_LINQ.instance; }
            private set { ProSer_LINQ.instance = value; }
        }

        private ProSer_LINQ() { }

        public void addnewProSer(string name, int idcategory, int soluong, string mota, float price)
        {
            PRO_SER proser = new PRO_SER();
            proser.NAME = name;
            proser.IDCATEGORY = idcategory;
            proser.SOLUONG = soluong;
            proser.MOTA = mota;
            proser.Price = price;

            spa.PRO_SERs.InsertOnSubmit(proser);
            spa.SubmitChanges();
        }

        public void UpdateProSer(int id,string name, int soluong, string mota, float price)
        {
            PRO_SER proser = spa.PRO_SERs.Where(t => t.ID == id).FirstOrDefault();
            if (proser != null)
            {
                proser.NAME = name;
                proser.SOLUONG = soluong;
                proser.MOTA = mota;
                proser.Price = price;

                spa.SubmitChanges();
            }
        }

        public void DeleteProser(int id)
        {
          
        }
    }
}
