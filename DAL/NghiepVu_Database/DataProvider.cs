using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataProvider
    {
        private static DataProvider instance;

        public static DataProvider Instance
        {
            get { if (instance == null) instance = new DataProvider(); return DataProvider.instance; }
            private set { DataProvider.instance = value; }
        }

        private DataProvider() { }

        private String connectionSTR = "Data Source=LAPTOP-74GA35JN;Initial Catalog=SALON_AND_SPA;User ID=sa;Password=123";

        public DataTable ExcuteQuery(String query, object[] Paremeter = null)
        {
            DataTable data = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionSTR))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                if (Paremeter != null)
                {
                    String[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (String para in listPara)
                    {
                        if (para.Contains("@"))
                        {
                            cmd.Parameters.AddWithValue(para, Paremeter[i]);
                            i++;
                        }
                    }
                }

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(data);
                connection.Close();
            }
            return data;
        }

        public int ExcuteNonQuery(string query, object[] Parameter = null)
        {
            int data = 0;
            using (SqlConnection connection = new SqlConnection(connectionSTR))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                if (Parameter != null)
                {
                    String[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (String para in listPara)
                    {
                        if (para.Contains("@"))
                        {
                            cmd.Parameters.AddWithValue(para, Parameter[i]);
                            i++;
                        }
                    }
                }
                data = cmd.ExecuteNonQuery();
                connection.Close();
            }
            return data;
        }


        public object ExcuteScalar(string query, object[] Parameter = null)
        {
            object data = 0;
            using (SqlConnection connection = new SqlConnection(connectionSTR))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                if (Parameter != null)
                {
                    String[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (String para in listPara)
                    {
                        if (para.Contains("@"))
                        {
                            cmd.Parameters.AddWithValue(para, Parameter[i]);
                            i++;
                        }
                    }
                }
                data = cmd.ExecuteScalar();
                connection.Close();
            }
            return data;
        }
    }
}
