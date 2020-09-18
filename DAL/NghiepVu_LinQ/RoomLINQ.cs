using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.NghiepVu_LinQ
{
    public class RoomLINQ
    {
        qlyspaDataContext spa = new qlyspaDataContext();
        private static RoomLINQ instance;

        public static RoomLINQ Instance
        {
            get { if (instance == null) instance = new RoomLINQ(); return RoomLINQ.instance; }
            private set { RoomLINQ.instance = value; }
        }

        private RoomLINQ() { }
        public void UpdateRoomStatus(int id, int status)
        {
            Room room = spa.Rooms.Where(t => t.ID == id).FirstOrDefault();
            if (room != null)
            {
                room.Status = status;
                spa.SubmitChanges();
            }
        }

        public void AddnewRoom(string name, int vip)
        {
            Room romm = new Room();
            romm.Name = name;
            romm.VIP = vip;
            spa.Rooms.InsertOnSubmit(romm);
            spa.SubmitChanges();
        }
    }
}
