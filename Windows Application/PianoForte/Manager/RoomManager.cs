using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PianoForte.Dao;
using PianoForte.Model;

namespace PianoForte.Manager
{
    public class RoomManager
    {
        private static RoomDao roomDao = DaoFactory.getDaoFactory(DaoFactory.FactoryType.MYSQL).getRoomDao();

        public static Room insertRoom(Room room)
        {
            bool isAddSuccess = roomDao.insertRoom(room);
            if (isAddSuccess)
            {
                room.Id = roomDao.findLastRoom().Id;
            }
            else
            {
                room = null;
            }

            return room;
        }

        public static bool updateRoom(Room room)
        {
            return roomDao.updateRoom(room);
        }

        public static bool deleteRoom(int roomId)
        {
            return roomDao.deleteRoom(roomId);
        }

        public static Room findRoom(int roomId)
        {
            return roomDao.findRoom(roomId);
        }

        public static Room findRoom(int roomNumber, DateTime date)
        {
            return roomDao.findRoom(roomNumber, date);
        }

        public static List<Room> findAllRoom()
        {
            return roomDao.findAllRoom();
        }

        public static List<Room> findAllRoom(DateTime date)
        {
            return roomDao.findAllRoom(date);
        }

        public static List<Room> findAllRoom(DateTime date, int teacherId)
        {
            return roomDao.findAllRoom(date, teacherId);
        }        
    }
}
