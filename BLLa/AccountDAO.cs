using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data;
using BLLa.Database;
using DAL.NghiepVu_LinQ;
namespace BLLa
{
    public class AccountDAO
    {
        private static AccountDAO instance;

        public static AccountDAO Instance
        {
            get { if (instance == null) instance = new AccountDAO(); return AccountDAO.instance; }
            private set { AccountDAO.instance = value; }
        }

        private AccountDAO() { }

        public bool islOgin(string username, string password)
        {
            return AccountDB.Instance.isLogin(username, password);
        }

        public int get_hoatdong(string username, string password)
        {
            DataTable data = AccountDB.Instance.get_account(username, password);
            foreach (DataRow item in data.Rows)
            {
                Account kh = new Account(item);
                if (kh.Hoatdong == 1)
                    return 1;
                if (kh.Hoatdong == 0)
                    return 0;
             
            }
            return 1;
           
        }

        public DataTable getListAccount()
        {
            return AccountDB.Instance.getListAccount();
        }

        public void AddnewAccount(string username, string password, int quyen)
        {
            Account_LINQ.Instance.addnewAccount(username, password, quyen);
        }

        public void BlockAccount(string username, int hoatdong)
        {
            Account_LINQ.Instance.BlockAccount(username, hoatdong);
        }

        public void reset_Account(string username, string password)
        {
            Account_LINQ.Instance.ResetAccount(username, password);
        }

        public void DeleteAccount(string username)
        {
            Account_LINQ.Instance.DeleteTaiKhoan(username);
        }

        public Account getAccount(string username, string password)
        {
            return new Account(AccountDB.Instance.getAccount(username, password).Rows[0]);
        }
    }
}
