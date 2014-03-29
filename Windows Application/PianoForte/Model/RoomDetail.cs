using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PianoForte.Model
{
    public class RoomDetail
    {
        public static string tableName = "room_detail";
        public static string columnRoomDetailId = "roomDetailId";
        public static string columnRoomId = "roomId";
        public static string columnTeacherId = "teacherId";
        public static string columnStartTime = "startTime";
        public static string columnEndTime = "endTime";
        public static string columnCheckInTime = "checkInTime";

        private int roomDetailId;
        private int roomId;
        private int teacherId;
        private string startTime;
        private string endTime;
        private string checkInTime;

        public RoomDetail()
        {
            //Do Nothing;
        }

        public RoomDetail(RoomDetail roomDetail)
        {
            this.roomDetailId = roomDetail.RoomDetailId;
            this.roomId = roomDetail.RoomId;
            this.teacherId = roomDetail.TeacherId;
            this.startTime = roomDetail.StartTime;
            this.endTime = roomDetail.EndTime;
            this.checkInTime = roomDetail.CheckInTime;
        }

        public int RoomDetailId
        {
            get
            {
                return this.roomDetailId;
            }

            set
            {
                this.roomDetailId = value;
            }
        }

        public int RoomId
        {
            get
            {
                return this.roomId;
            }

            set
            {
                this.roomId = value;
            }
        }

        public int TeacherId
        {
            get
            {
                return this.teacherId;
            }

            set
            {
                this.teacherId = value;
            }
        }

        public string StartTime
        {
            get
            {
                return this.startTime;
            }

            set
            {
                this.startTime = value;
            }
        }

        public string EndTime
        {
            get
            {
                return this.endTime;
            }

            set
            {
                this.endTime = value;
            }
        }

        public string CheckInTime
        {
            get
            {
                return this.checkInTime;
            }

            set
            {
                this.checkInTime = value;
            }
        }
    }
}
