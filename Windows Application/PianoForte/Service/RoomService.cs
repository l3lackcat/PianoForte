using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PianoForte.Dao;
using PianoForte.Model;

namespace PianoForte.Service
{
    public class RoomService
    {
        private RoomDao roomDao = new RoomDao();

        public bool addRoom(Room room)
        {
            string sql = "INSERT INTO " +
                         Room.tableName + " (" +
                         Room.columnRoomId + ", " +
                         Room.columnRoomNumber + ", " +
                         Room.columnDate + ") " +
                         "VALUES(" +
                         "?" + Room.columnRoomId + ", " +
                         "?" + Room.columnRoomNumber + ", " +
                         "?" + Room.columnDate + ")";

            return this.roomDao.processInsertString(sql, room);
        }

        public bool updateRoom(Room room)
        {
            string sql = "UPDATE " +
                         Room.tableName + " SET " +
                         Room.columnRoomNumber + " = ?" + Room.columnRoomNumber + ", " +
                         Room.columnDate + " = ?" + Room.columnDate + " " +
                         "WHERE " + Room.columnRoomId + " = ?" + Room.columnRoomId;

            return this.roomDao.processUpdateString(sql, room);
        }

        public bool deleteRoom(int roomId)
        {
            string sql = "DELETE " +
                         "FROM " + Room.tableName + " " +
                         "WHERE " + Room.columnRoomId + " = " + roomId;

            return this.roomDao.processDeleteString(sql);
        }

        public Room getLastRoom()
        {
            Room room = null;

            string sql = "SELECT * " +
                         "FROM " + Room.tableName + " " +
                         "ORDER BY " + Room.columnRoomId + " DESC " +
                         "LIMIT 1";

            List<Room> roomList = this.roomDao.processQueryString(sql);
            if (roomList.Count > 0)
            {
                room = roomList[0];
            }

            return room;
        }

        public Room getRoom(int roomId)
        {
            Room room = null;

            string sql = "SELECT * " +
                         "FROM " + Room.tableName + " " +
                         "WHERE " + Room.columnRoomId + " = " + roomId;

            List<Room> roomList = this.roomDao.processQueryString(sql);
            if (roomList.Count > 0)
            {
                room = roomList[0];
            }

            return room;
        }

        public Room getRoom(int roomNumber, DateTime date)
        {
            Room room = null;

            string sql = "SELECT * " +
                         "FROM " + Room.tableName + " " +
                         "WHERE " + Room.columnRoomNumber + " = " + roomNumber + " " +
                         "AND " + Room.columnDate + " = '" + date.ToString(DatabaseManager.DATABASE_DATE_FORMAT) + "'";

            List<Room> roomList = this.roomDao.processQueryString(sql);
            if (roomList.Count > 0)
            {
                room = roomList[0];
            }

            return room;
        }

        public List<Room> getAllRoom(DateTime date, int teacherId)
        {
            string sql = "SELECT * " +
                         "FROM " + Room.tableName + " " +
                         "WHERE " + Room.columnDate + " = '" + date.ToString(DatabaseManager.DATABASE_DATE_FORMAT) + "' " +
                         "AND " + Room.columnRoomId + " = (SELECT " + RoomDetail.columnRoomId + " " +
                         "FROM " + RoomDetail.tableName + " " +
                         "WHERE " + RoomDetail.columnTeacherId + " = " + teacherId + ")";

            return this.roomDao.processQueryString(sql);
        }

        public List<Room> getAllRoom()
        {
            string sql = "SELECT * " +
                         "FROM " + Room.tableName + " " +
                         "ORDER BY " + Room.columnRoomId + " ASC";

            return this.roomDao.processQueryString(sql);
        }

        public List<Room> getAllRoom(DateTime date)
        {
            string sql = "SELECT * " +
                         "FROM " + Room.tableName + " " +
                         "WHERE " + Room.columnDate + " = '" + date.ToString(DatabaseManager.DATABASE_DATE_FORMAT) + "' " +
                         "ORDER BY " + Room.columnRoomId + " ASC";

            return this.roomDao.processQueryString(sql);
        }
    }
}
