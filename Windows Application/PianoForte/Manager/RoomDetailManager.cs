using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PianoForte.Dao;
using PianoForte.Model;

namespace PianoForte.Manager
{
    public class RoomDetailManager
    {
        private static RoomDetailDao roomDetailDao = DaoFactory.getDaoFactory(DaoFactory.FactoryType.MYSQL).getRoomDetailDao();

        public static RoomDetail insertRoomDetail(RoomDetail roomDetail)
        {
            bool isInsertComplete = roomDetailDao.insertRoomDetail(roomDetail);
            if (isInsertComplete)
            {
                roomDetail.RoomDetailId = roomDetailDao.findLastRoomDetail().RoomDetailId;
            }
            else
            {
                roomDetail = null;
            }

            return roomDetail;
        }

        public static bool updateRoomDetail(RoomDetail roomDetail)
        {
            return roomDetailDao.updateRoomDetail(roomDetail);
        }

        public static bool deleteRoomDetail(int roomDetailId)
        {
            return roomDetailDao.deleteRoomDetail(roomDetailId);
        }

        public static RoomDetail findRoomDetail(int roomDetailId)
        {
            return roomDetailDao.findRoomDetail(roomDetailId);
        }

        public static List<RoomDetail> findAllRoomDetail()
        {
            return roomDetailDao.findAllRoomDetail();
        }

        public static List<RoomDetail> findAllRoomDetailByRoomId(int roomId)
        {
            return roomDetailDao.findAllRoomDetailByRoomId(roomId);
        }

        public static List<RoomDetail> findAllRoomDetailByTeacherId(int teacherId)
        {
            return roomDetailDao.findAllRoomDetailByTeacherId(teacherId);
        }

        public static RoomDetail getEarliestRoomDetail(List<RoomDetail> roomDetailList, DateTime date)
        {
            RoomDetail earliestRoomDetail = null;

            for (int i = 0; i < roomDetailList.Count; i++)
            {
                Room tempRoom = RoomManager.findRoom(roomDetailList[i].RoomId);
                if (tempRoom != null)
                {
                    if (tempRoom.Date == date)
                    {
                        if (earliestRoomDetail == null)
                        {
                            earliestRoomDetail = roomDetailList[i];
                        }
                        else
                        {
                            string minTime = DateTimeManager.getMinTime(earliestRoomDetail.StartTime, roomDetailList[i].StartTime);
                            if (minTime == roomDetailList[i].StartTime)
                            {
                                earliestRoomDetail = roomDetailList[i];
                            }
                        }
                    }
                }
            }

            return earliestRoomDetail;
        }
    }
}
