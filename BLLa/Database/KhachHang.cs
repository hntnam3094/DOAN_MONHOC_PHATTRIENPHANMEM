using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLa.Database
{
    public class KhachHang
    {
        public KhachHang(string sdt, string username, string gioitinh, DateTime namsinh, string cmnd, string diachi, string email, int? hoatdong, int tichdiem)
        {
            this.Id = id;
            this.Sdt = sdt;
            this.Username = username;
            this.Gioitinh = gioitinh;
            this.Namsinh = namsinh;
            this.Cmnd = cmnd;
            this.Diachi = diachi;
            this.Email = email;
            this.Hoatdong = hoatdong;
            this.Tichdiem = tichdiem;
        }

        public KhachHang(DataRow row)
        {
            this.Id = (int)row["Id"];
            this.Sdt = row["SDT"].ToString();
            this.Username = row["USERNAME"].ToString();
            this.Gioitinh = row["GioiTinh"].ToString();
            this.Namsinh = (DateTime)row["NamSinh"];
            this.cmnd = row["CMND"].ToString();
            this.Diachi = row["ADDRESS"].ToString();
            this.Email = row["EMAIL"].ToString();
            this.Hoatdong = (int?)row["HOATDONG"];
            this.Tichdiem = (int?)row["TICHDIEM"];
        }

        private string cmnd;

        public string Cmnd
        {
            get { return cmnd; }
            set { cmnd = value; }
        }
        private DateTime namsinh;

        public DateTime Namsinh
        {
            get { return namsinh; }
            set { namsinh = value; }
        }


        private string gioitinh;

        public string Gioitinh
        {
            get { return gioitinh; }
            set { gioitinh = value; }
        }
        private int? tichdiem;

        public int? Tichdiem
        {
            get { return tichdiem; }
            set { tichdiem = value; }
        }


        private int? hoatdong;

        public int? Hoatdong
        {
            get { return hoatdong; }
            set { hoatdong = value; }
        }

        private string email;

        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        private string diachi;

        public string Diachi
        {
            get { return diachi; }
            set { diachi = value; }
        }
        private string username;

        public string Username
        {
            get { return username; }
            set { username = value; }
        }
        private string sdt;

        public string Sdt
        {
            get { return sdt; }
            set { sdt = value; }
        }

        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
    }
}
