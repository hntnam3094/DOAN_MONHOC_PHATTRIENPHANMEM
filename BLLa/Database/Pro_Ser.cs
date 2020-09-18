using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLa.Database
{
    public class Pro_Ser
    {
        public Pro_Ser(int id, string name, int idcategory, int soluong, string mota, float price)
        {
            this.Id = id;
            this.Name = name;
            this.IdCategory = idcategory;
            this.Soluong = soluong;
            this.Mota = mota;
            this.Price = price;
        }

        public Pro_Ser(DataRow Row)
        {
            this.Id = (int)Row["ID"];
            this.Name = Row["NAME"].ToString();
            this.IdCategory = (int)Row["IDCATEGORY"];
            this.Soluong = (int)Row["SOLUONG"];
            this.Mota = Row["MOTA"].ToString();
            this.Price = float.Parse(Row["Price"].ToString());
        }

        private float price;

        public float Price
        {
            get { return price; }
            set { price = value; }
        }
        private string mota;

        public string Mota
        {
            get { return mota; }
            set { mota = value; }
        }
        private int soluong;

        public int Soluong
        {
            get { return soluong; }
            set { soluong = value; }
        }
        private int idCategory;

        public int IdCategory
        {
            get { return idCategory; }
            set { idCategory = value; }
        }

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
    }
}
