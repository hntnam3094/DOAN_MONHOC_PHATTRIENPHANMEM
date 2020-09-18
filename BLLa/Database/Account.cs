using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLa.Database
{
    public class Account
    {
       
            public Account(string username, string password, int type, int hoatdong)
            {
                this.Username = username;
                this.Password = password;
                this.Type = type;
                this.Hoatdong = hoatdong;
            }

            public Account(DataRow Row)
            {
                this.Username = Row["USERNAME"].ToString();
                this.Password = Row["PASSWORD"].ToString();
                this.Type = (int)Row["TYPE"];
                this.Hoatdong = (int)Row["HoatDong"];
            }
            private int hoatdong;

            public int Hoatdong
            {
                get { return hoatdong; }
                set { hoatdong = value; }
            }
            private int type;

            public int Type
            {
                get { return type; }
                set { type = value; }
            }
            private string password;

            public string Password
            {
                get { return password; }
                set { password = value; }
            }
            private string username;

            public string Username
            {
                get { return username; }
                set { username = value; }
            }
        }
    }

