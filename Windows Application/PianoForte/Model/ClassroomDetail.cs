using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PianoForte.Model
{
    public class ClassroomDetail
    {
        public static string tableName = "classroom_detail";
        public static string columnClassroomDetailId = "classroomDetailId";
        public static string columnClassroomId = "classroomId";
        public static string columnClassroomNo = "classroomNo";
        public static string columnTeacherId = "teacherId";
        public static string columnClassroomDate = "classroomDate";
        public static string columnClassroomTime = "classroomTime";
        public static string columnClassroomDuration = "classroomDuration";
        public static string columnClassroomType = "classroomType";
        public static string columnCurrentStatus = "currentStatus";
        public static string columnPreviousStatus = "previousStatus";
        public static string columnRoomDetailId = "roomDetailId";
        public static string columnRegularClassroomDetailId = "regularClassroomDetailId";
        public static string columnCommission = "commission";
    
        public enum ClassroomType
        {
            NORMAL,
            POSTPONE1,
            POSTPONE2,
            EXTRA
        }

        public enum ClassroomStatus
        {
            WAITING,
            CHECKED_IN,
            POSTPONE1,
            POSTPONE2,
            STUDENT_ABSENT,
            TEACHER_ABSENT,
            SCHOOL_CLOSE,
            MISSING,
            CANCELED
        }

        private int classroomDetailId;
        private int classroomId;
        private double classroomNo;
        private int teacherId;
        private DateTime classroomDate;
        private string classroomTime;
        private int classroomDuration;
        private string type;
        private string currentStatus;
        private string previousStatus;
        private int roomDetailId;
        private int regularClassroomDetailId;
        private int commission;
        private string displayType;
        private string displayStatus;

        public ClassroomDetail()
        {
            //Do Nothing
        }

        public ClassroomDetail(ClassroomDetail classroomDetail)
        {
            this.classroomDetailId = classroomDetail.ClassroomDetailId;
            this.classroomId = classroomDetail.ClassroomId;
            this.classroomNo = classroomDetail.ClassroomNo;
            this.teacherId = classroomDetail.TeacherId;
            this.classroomDate = classroomDetail.ClassroomDate;
            this.classroomTime = classroomDetail.ClassroomTime;
            this.classroomDuration = classroomDetail.ClassroomDuration;
            this.type = classroomDetail.Type;
            this.currentStatus = classroomDetail.CurrentStatus;
            this.previousStatus = classroomDetail.PreviousStatus;
            this.roomDetailId = classroomDetail.RoomDetailId;
            this.regularClassroomDetailId = classroomDetail.RegularClassroomDetailId;
            this.commission = classroomDetail.Commission;
            this.displayType = classroomDetail.DisplayType;
            this.displayStatus = classroomDetail.DisplayStatus;
        }

        public int ClassroomDetailId
        {
            get
            {
                return this.classroomDetailId;
            }

            set
            {
                this.classroomDetailId = value;
            }
        }

        public int ClassroomId
        {
            get
            {
                return this.classroomId;
            }

            set
            {
                this.classroomId = value;
            }
        }

        public double ClassroomNo
        {
            get
            {
                return this.classroomNo;
            }

            set
            {
                this.classroomNo = value;
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

        public DateTime ClassroomDate
        {
            get
            {
                return this.classroomDate;
            }

            set
            {
                this.classroomDate = value;
            }
        }

        public string ClassroomTime
        {
            get
            {
                return this.classroomTime;
            }

            set
            {
                this.classroomTime = value;
            }
        }

        public int ClassroomDuration
        {
            get
            {
                return this.classroomDuration;
            }

            set
            {
                this.classroomDuration = value;
            }
        }

        public string Type
        {
            get
            {
                return this.type;
            }

            set
            {
                this.type = value;
            }
        }

        public string CurrentStatus
        {
            get
            {
                return this.currentStatus;
            }

            set
            {
                this.currentStatus = value;
            }
        }

        public string PreviousStatus
        {
            get
            {
                return this.previousStatus;
            }

            set
            {
                this.previousStatus = value;
            }
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

        public int RegularClassroomDetailId
        {
            get
            {
                return this.regularClassroomDetailId;
            }

            set
            {
                this.regularClassroomDetailId = value;
            }
        }

        public int Commission
        {
            get
            {
                return this.commission;
            }

            set
            {
                this.commission = value;
            }
        }

        public string DisplayType
        {
            get
            {
                return this.displayType;
            }

            set
            {
                this.displayType = value;
            }
        }

        public string DisplayStatus
        {
            get
            {
                return this.displayStatus;
            }

            set
            {
                this.displayStatus = value;
            }
        }
    }
}
