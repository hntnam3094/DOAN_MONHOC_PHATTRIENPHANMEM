using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLa.Database
{
    public class Bill
    {
        public Bill(int id, int idkh, int idroom, float totalprice, DateTime datecheckin, int status)
        {
            this.Id = id;
            this.Idkh = idkh;
            this.Idroom = idroom;
            this.Totalprice = totalprice;
            this.Datecheckin = datecheckin;
            this.Status = status;
        }

        public Bill(DataRow Row)
        {
            this.Id = (int)Row["ID"];
            this.Idkh = (int)Row["IdKH"];
            this.Idroom = (int)Row["IdRoom"];
            this.Totalprice = float.Parse(Row["TOTALPRICE"].ToString());
            this.Datecheckin = (DateTime)Row["DATEIN"];
            this.Status = (int)Row["Status"];
        }
        private int status;

        public int Status
        {
            get { return status; }
            set { status = value; }
        }
        private DateTime datecheckin;

        public DateTime Datecheckin
        {
            get { return datecheckin; }
            set { datecheckin = value; }
        }
        private float totalprice;

        public float Totalprice
        {
            get { return totalprice; }
            set { totalprice = value; }
        }
        private int idroom;

        public int Idroom
        {
            get { return idroom; }
            set { idroom = value; }
        }

        private int idkh;

        public int Idkh
        {
            get { return idkh; }
            set { idkh = value; }
        }

        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
    }
}
