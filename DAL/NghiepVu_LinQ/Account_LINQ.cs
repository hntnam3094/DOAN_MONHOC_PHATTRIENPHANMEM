using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.NghiepVu_LinQ
{
    public class Account_LINQ
    {
          qlyspaDataContext spa = new qlyspaDataContext();
        private static Account_LINQ instance;

        public static Account_LINQ Instance
        {
            get { if (instance == null) instance = new Account_LINQ(); return Account_LINQ.instance; }
            private set { Account_LINQ.instance = value; }
        }

        private Account_LINQ() { }

        public void addnewAccount(string username, string password, int quyen)
        {
            ACCOUNT acc = new ACCOUNT();
            acc.USERNAME = username;
            acc.PASSWORD = password;
            acc.HoatDong = 0;
            acc.TYPE = quyen;
            spa.ACCOUNTs.InsertOnSubmit(acc);
            spa.SubmitChanges();
        }

        public void ResetAccount(string username, string password)
        {
            ACCOUNT acc = spa.ACCOUNTs.Where(t => t.USERNAME == username).FirstOrDefault();
            if (acc != null)
            {
                acc.PASSWORD = password;
                spa.SubmitChanges();
            }
        }

        public void BlockAccount(string username, int hoatdong)
        {
            ACCOUNT acc = spa.ACCOUNTs.Where(t => t.USERNAME == username).FirstOrDefault();
            if (acc != null)
            {
                acc.HoatDong = hoatdong;
                spa.SubmitChanges();
            }
        }

        public void DeleteTaiKhoan(string username)
        {
             ACCOUNT acc = spa.ACCOUNTs.Where(t => t.USERNAME == username).FirstOrDefault();
             if (acc != null)
             {
                 spa.ACCOUNTs.DeleteOnSubmit(acc);
                 spa.SubmitChanges();
             }
        }
    }
}
