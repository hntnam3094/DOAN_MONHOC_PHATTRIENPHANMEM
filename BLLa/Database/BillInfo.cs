using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLa.Database
{
    public class BillInfo
    {
        public BillInfo(int id, int idbill, int idproser, int count)
        {
            this.Id = id;
            this.Idbill = idbill;
            this.Idproser = idproser;
            this.Count = count;
        }

        public BillInfo(DataRow Row)
        {
            this.Id = (int)Row["ID"];
            this.Idbill = (int)Row["IDBILL"];
            this.Idproser = (int)Row["IDPRO_SER"];
            this.Count = (int)Row["COUNT"];
        }
        private int count;

        public int Count
        {
            get { return count; }
            set { count = value; }
        }
        private int idproser;

        public int Idproser
        {
            get { return idproser; }
            set { idproser = value; }
        }
        private int idbill;

        public int Idbill
        {
            get { return idbill; }
            set { idbill = value; }
        }
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
    }
}
