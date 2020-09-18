using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class AccountDB
    {
        private static AccountDB instance;

        public static AccountDB Instance
        {
            get { if (instance == null) instance = new AccountDB(); return AccountDB.instance; }
            private set { AccountDB.instance = value; }
        }

        private AccountDB() { }

        public bool isLogin(string username, string password)
        {
            string query = "EXEC dbo.USP_GetAccount @username = N'"+username+"', @password = N'"+password+"'";
            DataTable data = DataProvider.Instance.ExcuteQuery(query);
            return data.Rows.Count > 0;
        }

        public DataTable get_account(string username, string password)
        {
            string query = "EXEC dbo.USP_GetAccount @username = N'" + username + "', @password = N'" + password + "'";
            DataTable data = DataProvider.Instance.ExcuteQuery(query);
            return data;
        }

        public DataTable getListAccount()
        {
            string query = "SELECT * FROM dbo.ACCOUNT";
            DataTable data = DataProvider.Instance.ExcuteQuery(query);
            return data;
        }


        public DataTable getAccount(string username, string password)
        {
            string query = "EXEC dbo.USP_GetAccount @username = N'" + username + "', @password = N'" + password + "'";
            DataTable data = DataProvider.Instance.ExcuteQuery(query);
            return data;
        }
    }
}
