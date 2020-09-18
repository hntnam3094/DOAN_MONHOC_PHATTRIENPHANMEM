using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLa.Database
{
    public class Room
    {
        public Room(int id, string name, int status, int vip)
        {
            this.Id = id;
            this.Name = name;
            this.Status = status;
            this.Vip = vip;
        }

        public Room(DataRow Row)
        {
            this.Id = (int)Row["Id"];
            this.Name = Row["Name"].ToString();
            this.Status = (int)Row["Status"];
            this.Vip = (int)Row["VIP"];
        }
        private int vip;

        public int Vip
        {
            get { return vip; }
            set { vip = value; }
        }
        private int status;

        public int Status
        {
            get { return status; }
            set { status = value; }
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
