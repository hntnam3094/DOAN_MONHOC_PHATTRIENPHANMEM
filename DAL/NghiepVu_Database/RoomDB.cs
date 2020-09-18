using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.NghiepVu_Database
{
    public class RoomDB
    {
        private static RoomDB instance;

        public static RoomDB Instance
        {
            get { if (instance == null) instance = new RoomDB(); return RoomDB.instance; }
            private set { RoomDB.instance = value; }
        }

        private RoomDB() { }

        public DataTable getListRoom()
        {
            DataTable data = new DataTable();
            data = DataProvider.Instance.ExcuteQuery("SELECT * FROM dbo.Room");
            return data;
        }

        public DataTable getListRoomUnCheck()
        {
            DataTable data = new DataTable();
            data = DataProvider.Instance.ExcuteQuery("SELECT * FROM dbo.Room WHERE Status = 0");
            return data;
        }

        public bool ChuyenPhong(int idroom1, int idroom2)
        {
            int result = DataProvider.Instance.ExcuteNonQuery("	EXEC dbo.USP_ChuyenPhong @idRoom1 , @idRoom2 ", new object[] { idroom1, idroom2 });
            return result > 0;
        }

         public DataTable getRoom_byIDUnCheck(int idRoom)
        {
            string query = "SELECT * FROM dbo.Room WHERE Status = 0 AND ID = "+idRoom;
            DataTable data = DataProvider.Instance.ExcuteQuery(query);
            return data;
        }

         public bool Dongphong(int idroom)
         {
             string query = "EXEC dbo.USP_XoaPhong @idRoom = " + idroom;
             int rs = DataProvider.Instance.ExcuteNonQuery(query);
             return rs > 0;
         }

    }
}
