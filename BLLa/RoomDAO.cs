using BLLa.Database;
using DAL.NghiepVu_Database;
using DAL.NghiepVu_LinQ;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLa
{
    public class RoomDAO
    {
        private static RoomDAO instance;

        public static RoomDAO Instance
        {
            get { if (instance == null) instance = new RoomDAO(); return RoomDAO.instance; }
            private set { RoomDAO.instance = value; }
        }

        private RoomDAO() { }

        public List<BLLa.Database.Room> getListRoom()
        {
            List<BLLa.Database.Room> listRoom = new List<BLLa.Database.Room>();
            DataTable data = RoomDB.Instance.getListRoom();
            foreach (DataRow item in data.Rows)
            {
                BLLa.Database.Room r = new BLLa.Database.Room(item);
                listRoom.Add(r);
            }

            return listRoom;
        }

        public void UpdateRoomStatus(int id, int status)
        {
            RoomLINQ.Instance.UpdateRoomStatus(id, status);
        }

        public DataTable getListRoom_uncheck()
        {
            return RoomDB.Instance.getListRoomUnCheck();
        }

        public bool ChuyenPhong(int idroom1, int idroom2)
        {
            return RoomDB.Instance.ChuyenPhong(idroom1, idroom2);
        }

        public BLLa.Database.Room getRoom_byUncheckID(int idroom)
        {
            DataTable data = RoomDB.Instance.getRoom_byIDUnCheck(idroom);
            return new Database.Room(data.Rows[0]);
        }

        public bool DongPhong(int idroom)
        {
            return RoomDB.Instance.Dongphong(idroom);
        }

        public void AddNewRoom(string name, int vip)
        {
            RoomLINQ.Instance.AddnewRoom(name, vip);
        }
    }


}
