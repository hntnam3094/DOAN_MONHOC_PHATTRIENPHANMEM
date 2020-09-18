using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLa.Database
{
    public class CT_Room
    {

        public CT_Room(string name, int vip, string username, DateTime checkin,string namenv)
        {
            this.Name = name;
            this.Vip = vip;
            this.Username = username;
            this.Checkin = checkin;
            this.namenv = Namenv;
        }

        public CT_Room(DataRow row)
        {
            this.Name = row["Name"].ToString();
            this.Vip = (int)row["VIP"];
            this.Username = row["UserName"].ToString();
            this.Checkin = DateTime.Parse(row["DateIn"].ToString());
            this.Namenv = row["NameNV"].ToString();
        }

        private string namenv;
        public string Namenv
        {
            get { return namenv; }
            set { namenv = value; }
        }

        private DateTime checkin;
        public DateTime Checkin
        {
            get { return checkin; }
            set { checkin = value; }
        }
        private string username;
        public string Username
        {
            get { return username; }
            set { username = value; }
        }
        private int vip;
        public int Vip
        {
            get { return vip; }
            set { vip = value; }
        }
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
    }
}
