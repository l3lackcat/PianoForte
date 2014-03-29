using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PianoForte.Model;

namespace PianoForte.Dao
{
    public interface RoomDetailDao
    {
        bool insertRoomDetail(RoomDetail roomDetail);
        bool updateRoomDetail(RoomDetail roomDetail);
        bool deleteRoomDetail(int roomDetailId);

        RoomDetail findLastRoomDetail();

        RoomDetail findRoomDetail(int roomDetailId);

        List<RoomDetail> findAllRoomDetail();

        List<RoomDetail> findAllRoomDetailByRoomId(int roomId);

        List<RoomDetail> findAllRoomDetailByTeacherId(int teacherId);
    }
}
