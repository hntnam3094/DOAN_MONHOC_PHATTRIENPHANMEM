using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLa.Database
{
    public class Menu
    {
        public Menu(string name, int count, float thanhtien)
        {
            this.Name = name;
            this.Count = count;
            this.Thanhtien = thanhtien;
        }

        public Menu(DataRow Row)
        {
            this.Name = Row["NAME"].ToString();
            this.Count = (int)Row["COUNT"];
            this.Thanhtien = float.Parse(Row["ThanhTien"].ToString());
        }

        private float thanhtien;

        public float Thanhtien
        {
            get { return thanhtien; }
            set { thanhtien = value; }
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
