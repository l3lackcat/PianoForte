using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PianoForte.Model;

namespace PianoForte.Dao
{
    public interface RoomDao
    {
        bool insertRoom(Room room);
        bool updateRoom(Room room);
        bool deleteRoom(int roomId);

        Room findLastRoom();

        Room findRoom(int roomId);

        Room findRoom(int roomNumber, DateTime date);

        List<Room> findAllRoom();

        List<Room> findAllRoom(DateTime date);

        List<Room> findAllRoom(DateTime date, int teacherId);
    }
}
