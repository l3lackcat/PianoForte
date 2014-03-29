using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PianoForte.Dao;
using PianoForte.Model;

namespace PianoForte.Service
{
    public class RoomDetailService
    {
        private RoomDetailDao roomDetailDao = new RoomDetailDao();

        public bool addRoomDetail(RoomDetail roomDetail)
        {
            string sql = "INSERT INTO " +
                         RoomDetail.tableName + " (" +
                         RoomDetail.columnRoomDetailId + ", " +
                         RoomDetail.columnRoomId + ", " +
                         RoomDetail.columnTeacherId + ", " +
                         RoomDetail.columnStartTime + ", " +
                         RoomDetail.columnEndTime + ", " +
                         RoomDetail.columnCheckInTime + ") " +
                         "VALUES(" +
                         "?" + RoomDetail.columnRoomDetailId + ", " +
                         "?" + RoomDetail.columnRoomId + ", " +
                         "?" + RoomDetail.columnTeacherId + ", " +
                         "?" + RoomDetail.columnStartTime + ", " +
                         "?" + RoomDetail.columnEndTime + ", " +
                         "?" + RoomDetail.columnCheckInTime + ")";

            return this.roomDetailDao.processInsertString(sql, roomDetail);
        }

        public bool updateRoomDetail(RoomDetail roomDetail)
        {
            string sql = "UPDATE " +
                         RoomDetail.tableName + " SET " +
                         RoomDetail.columnRoomId + " = ?" + RoomDetail.columnRoomId + ", " +
                         RoomDetail.columnTeacherId + " = ?" + RoomDetail.columnTeacherId + ", " +
                         RoomDetail.columnStartTime + " = ?" + RoomDetail.columnStartTime + ", " +
                         RoomDetail.columnEndTime + " = ?" + RoomDetail.columnEndTime + ", " +
                         RoomDetail.columnCheckInTime + " = ?" + RoomDetail.columnCheckInTime + " " +
                         "WHERE " + RoomDetail.columnRoomDetailId + " = ?" + RoomDetail.columnRoomDetailId;

            return this.roomDetailDao.processUpdateString(sql, roomDetail);
        }

        public bool deleteRoomDetail(int roomDetailId)
        {
            string sql = "DELETE " +
                         "FROM " + RoomDetail.tableName + " " +
                         "WHERE " + RoomDetail.columnRoomDetailId + " = " + roomDetailId;

            return this.roomDetailDao.processDeleteString(sql);
        }

        public RoomDetail getLastRoomDetail()
        {
            RoomDetail roomDetail = null;

            string sql = "SELECT * " +
                         "FROM " + RoomDetail.tableName + " " +
                         "ORDER BY " + RoomDetail.columnRoomDetailId + " DESC " +
                         "LIMIT 1";

            List<RoomDetail> roomDetailList = this.roomDetailDao.processQueryString(sql);
            if (roomDetailList.Count > 0)
            {
                roomDetail = roomDetailList[0];
            }

            return roomDetail;
        }

        public RoomDetail getRoomDetail(int roomDetailId)
        {
            RoomDetail roomDetail = null;

            string sql = "SELECT * " +
                         "FROM " + RoomDetail.tableName + " " +
                         "WHERE " + RoomDetail.columnRoomDetailId + " = " + roomDetailId;

            List<RoomDetail> roomDetailList = this.roomDetailDao.processQueryString(sql);
            if (roomDetailList.Count > 0)
            {
                roomDetail = roomDetailList[0];
            }

            return roomDetail;
        }

        public List<RoomDetail> getAllRoomDetail()
        {
            string sql = "SELECT * " +
                         "FROM " + RoomDetail.tableName + " " +
                         "ORDER BY " + RoomDetail.columnRoomDetailId + " ASC";

            return this.roomDetailDao.processQueryString(sql);
        }

        public List<RoomDetail> getAllRoomDetailByRoomId(int roomId)
        {
            string sql = "SELECT * " +
                         "FROM " + RoomDetail.tableName + " " +
                         "WHERE " + RoomDetail.columnRoomId + " = " + roomId + " " +
                         "ORDER BY " + RoomDetail.columnRoomDetailId + " ASC";

            return this.roomDetailDao.processQueryString(sql);
        }

        public List<RoomDetail> getAllRoomDetailByTeacherId(int teacherId)
        {
            string sql = "SELECT * " +
                         "FROM " + RoomDetail.tableName + " " +
                         "WHERE " + RoomDetail.columnTeacherId + " = " + teacherId + " " +
                         "ORDER BY " + RoomDetail.columnRoomDetailId + " ASC";

            return this.roomDetailDao.processQueryString(sql);
        }
    }
}
