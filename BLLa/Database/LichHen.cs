using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLa.Database
{
    public class LichHen
    {

        public LichHen(int id, int id_gio, string username, string email, int gio, string name_nv, string address, string sdt, string noidung, DateTime ngay)
        {
            this.Id = id;
            this.Id_gio = id_gio;
            this.Username = username;
            this.Email = email;
            this.Gio = gio;
            this.Name_nv = name_nv;
            this.Address = address;
            this.Sdt = sdt;
            this.Noidung = noidung;
            this.Ngay = ngay;
        }

        public LichHen(DataRow Row)
        {
            this.Id = (int)Row["ID"];
            this.Id_gio = (int)Row["ID_Gio_TV"];
            this.Username = Row["USERNAME"].ToString();
            this.Email = Row["EMAIL"].ToString();
            this.Gio = (int)Row["Gio"];
            this.Name_nv = Row["NAME"].ToString();
            this.Address = Row["ADDRESS"].ToString();
            this.Sdt = Row["SDT"].ToString();
            this.Noidung = Row["NOIDUNG"].ToString();
            this.Ngay = System.Convert.ToDateTime(Row["Ngay"].ToString());
        }
        private DateTime ngay;

        public DateTime Ngay
        {
            get { return ngay; }
            set { ngay = value; }
        }


        private string noidung;

        public string Noidung
        {
            get { return noidung; }
            set { noidung = value; }
        }
        private string sdt;

        public string Sdt
        {
            get { return sdt; }
            set { sdt = value; }
        }
        private string address;

        public string Address
        {
            get { return address; }
            set { address = value; }
        }
        private string name_nv;

        public string Name_nv
        {
            get { return name_nv; }
            set { name_nv = value; }
        }
        private int gio;

        public int Gio
        {
            get { return gio; }
            set { gio = value; }
        }
        private string email;

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        private string username;

        public string Username
        {
            get { return username; }
            set { username = value; }
        }
        private int id_gio;

        public int Id_gio
        {
            get { return id_gio; }
            set { id_gio = value; }
        }
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
    }
}
