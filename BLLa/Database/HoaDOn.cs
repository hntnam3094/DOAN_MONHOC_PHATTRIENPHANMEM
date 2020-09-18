using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLa.Database
{
    public class HoaDOn
    {

        public HoaDOn(DataRow row)
        {
            this.Name = row["NAME"].ToString();
            this.Count = (int)row["COUNT"];
            this.Price = float.Parse(row["PRICE"].ToString());
            this.Discount = (int)row["DISCOUNT"];
            this.Afterdiscount = float.Parse(row["AFTERDISCOUNT"].ToString());
        }
        private float afterdiscount;
        public float Afterdiscount
        {
            get { return afterdiscount; }
            set { afterdiscount = value; }
        }

        private int discount;
        public int Discount
        {
            get { return discount; }
            set { discount = value; }
        }

        private float price;
        public float Price
        {
            get { return price; }
            set { price = value; }
        }

        private int count;
        public int Count
        {
            get { return count; }
            set { count = value; }
        }

        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
    }
}
