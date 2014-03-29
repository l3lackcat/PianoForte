using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PianoForte.Dao;
using PianoForte.Model;

namespace PianoForte.Manager
{
    public class ClassroomDetailManager
    {
        private static ClassroomDetailDao classroomDetailDao = DaoFactory.getDaoFactory(DaoFactory.FactoryType.MYSQL).getClassroomDetailDao();

        //--------------------------------------------------------------------------------

        public static bool insertClassroomDetail(ClassroomDetail classroomDetail)
        {
            return classroomDetailDao.insertClassroomDetail(classroomDetail);
        }

        public static bool updateClassroomDetail(ClassroomDetail classroomDetail)
        {
            return classroomDetailDao.updateClassroomDetail(classroomDetail);
        }

        public static bool deleteClassroomDetail(int classroomDetailId)
        {
            return classroomDetailDao.deleteClassroomDetail(classroomDetailId);
        }

        //--------------------------------------------------------------------------------

        public static ClassroomDetail findClassroomDetail(int classroomDetailId)
        {
            return classroomDetailDao.findClassroomDetail(classroomDetailId);
        }

        public static ClassroomDetail findClassroomDetailByRegularClassroomDetail(int regularClassroomDetailId)
        {
            return classroomDetailDao.findClassroomDetailByRegularClassroomDetail(regularClassroomDetailId);
        }

        //--------------------------------------------------------------------------------

        public static List<ClassroomDetail> findAllClassroomDetail()
        {
            return classroomDetailDao.findAllClassroomDetail();
        }

        //--------------------------------------------------------------------------------

        public static List<ClassroomDetail> findAllClassroomDetailByClassroomId(int classroomId)
        {
            return classroomDetailDao.findAllClassroomDetailByClassroomId(classroomId);
        }        

        public static List<ClassroomDetail> findAllClassroomDetailByClassroomId(int classroomId, List<ClassroomDetail.ClassroomType> typeList, string columnForArrange)
        {
            return classroomDetailDao.findAllClassroomDetailByClassroomId(classroomId, typeList, columnForArrange);
        }

        //--------------------------------------------------------------------------------

        public static List<ClassroomDetail> findAllClassroomDetailByRoomDetailId(int roomDetailId)
        {
            return classroomDetailDao.findAllClassroomDetailByRoomDetailId(roomDetailId);
        }

        //--------------------------------------------------------------------------------

        public static List<ClassroomDetail> findAllClassroomDetailByTeacherIdAndDate(int teacherId, DateTime date)
        {
            return classroomDetailDao.findAllClassroomDetailByTeacherIdAndDate(teacherId, date);
        }

        public static List<ClassroomDetail> findAllClassroomDetailByTeacherIdAndDate(int teacherId, DateTime date, List<ClassroomDetail.ClassroomStatus> statusList, string columnForArrange)
        {
            return classroomDetailDao.findAllClassroomDetailByTeacherIdAndDate(teacherId, date, statusList, columnForArrange);
        }

        //--------------------------------------------------------------------------------

        //public static List<ClassroomDetail> findAllClassroomDetailByClassroomId(int teacherId, DateTime classroomDate, string classroomStatus)
        //{
        //    return classroomDetailService.getAllClassroomDetail(teacherId, classroomDate, classroomStatus);
        //}

        //public static List<ClassroomDetail> getAllClassroomDetailByRoomDetailId(int roomDetailId)
        //{
        //    return classroomDetailService.getAllClassroomDetailByRoomDetailId(roomDetailId);
        //}

        //public static List<ClassroomDetail> getAllClassroomDetailForCheckInForm(int teacherId, DateTime classroomDate)
        //{
        //    return classroomDetailService.getAllClassroomDetailForCheckInForm(teacherId, classroomDate);
        //}

        //public static List<ClassroomDetail> getAllNormalClassroomDetail(int classroomId)
        //{
        //    return classroomDetailService.getAllNormalClassroomDetail(classroomId);
        //}        

        //public static List<ClassroomDetail> getAllNormalAndExtraClassroomDetailOrderByClassroomNo(int classroomId)
        //{
        //    return classroomDetailService.getAllNormalAndExtraClassroomDetailOrderByClassroomNo(classroomId);
        //}

        //public static List<ClassroomDetail> getAllNormalAndExtraClassroomDetailOrderByClassroomDate(int classroomId)
        //{
        //    return classroomDetailService.getAllNormalAndExtraClassroomDetailOrderByClassroomDate(classroomId);
        //}

        //public static ClassroomDetail getNonNormalClassroomDetail(int regularClassroomDetailId)
        //{
        //    return classroomDetailService.getNonNormalClassroomDetail(regularClassroomDetailId);
        //}

        public static Dictionary<int, List<ClassroomDetail>> generateClassroomDetail(List<Classroom> classroomList, Course course, int totalClassroomDetail)
        {
            Dictionary<int, List<ClassroomDetail>> classroomDetailDictionary = new Dictionary<int, List<ClassroomDetail>>();

            int numberOfClassroom = classroomList.Count;

            for (int i = 0; i < numberOfClassroom; i++)
            {
                List<ClassroomDetail> classroomDetailList = new List<ClassroomDetail>();

                int numberOfClassroomDetail = totalClassroomDetail / numberOfClassroom;
                int fraction = totalClassroomDetail % numberOfClassroom;
                if ((fraction != 0) && (i < fraction))
                {
                    numberOfClassroomDetail++;
                }

                int dayMultiplier = 0;
                DateTime startDate = classroomList[i].StartDate;
                for (int j = 0; j < numberOfClassroomDetail; j++)
                {
                    ClassroomDetail classroomDetail = new ClassroomDetail();
                    classroomDetail.ClassroomId = classroomList[i].Id;
                    classroomDetail.ClassroomNo = (((numberOfClassroom * j) + 1) + i) + 0.1;
                    classroomDetail.TeacherId = classroomList[i].TeacherId;
                    classroomDetail.ClassroomDate = classroomList[i].StartDate.AddDays(dayMultiplier * 7);
                    classroomDetail.ClassroomTime = classroomList[i].ClassTime;
                    classroomDetail.ClassroomDuration = classroomList[i].ClassDuration;
                    classroomDetail.Commission = UtilityManager.getCommissionRate(course, classroomList[i].TeacherId);
                    classroomDetail = ClassroomDetailManager.updateClassroomDetailType(ClassroomDetail.ClassroomType.NORMAL.ToString(), classroomDetail);
                    classroomDetail = ClassroomDetailManager.updateClassroomDetailStatus(ClassroomDetail.ClassroomStatus.WAITING.ToString(), classroomDetail);
                    classroomDetail.PreviousStatus = "";

                    while (HolidayManager.isHoliday(classroomDetail.ClassroomDate))
                    {
                        dayMultiplier++;
                        classroomDetail.ClassroomDate = classroomList[i].StartDate.AddDays(dayMultiplier * 7);
                    }

                    classroomDetailList.Add(classroomDetail);

                    dayMultiplier++;
                }

                classroomDetailDictionary.Add(classroomList[i].Id, classroomDetailList);
            }

            return classroomDetailDictionary;
        }

        public static int getNumberOfClassroomDetail(int enrollmentId)
        {
            int numberOfClassroomDetail = 0;

            List<Classroom> tempClassroomList = ClassroomManager.findAllClassroom(enrollmentId);
            for (int i = 0; i < tempClassroomList.Count; i++)
            {
                Classroom tempClassroom = tempClassroomList[i];
                if (tempClassroom != null)
                {
                    if (tempClassroom.Status != Classroom.ClassroomStatus.CANCELED.ToString())
                    {
                        List<ClassroomDetail> tempClassroomDetailList = ClassroomDetailManager.findAllClassroomDetailByClassroomId(tempClassroom.Id);
                        for (int j = 0; j < tempClassroomDetailList.Count; j++)
                        {
                            numberOfClassroomDetail++;
                        }
                    }
                }
            }

            return numberOfClassroomDetail;
        }

        public static ClassroomDetail getLastClassroomNoOfNormalAndExtraClassroomDetail(int classroomId)
        {
            ClassroomDetail lastClassroomDetail = null;

            //List<ClassroomDetail> tempClassroomDetailList = ClassroomDetailManager.getAllNormalAndExtraClassroomDetailOrderByClassroomNo(classroomId);
            List<ClassroomDetail.ClassroomType> classroomTypeList = new List<ClassroomDetail.ClassroomType>();
            classroomTypeList.Add(ClassroomDetail.ClassroomType.NORMAL);
            classroomTypeList.Add(ClassroomDetail.ClassroomType.EXTRA);
            List<ClassroomDetail> tempClassroomDetailList = ClassroomDetailManager.findAllClassroomDetailByClassroomId(classroomId, classroomTypeList, ClassroomDetail.columnClassroomNo);
            if (tempClassroomDetailList.Count > 0)
            {
                lastClassroomDetail = tempClassroomDetailList[tempClassroomDetailList.Count - 1];
            }

            return lastClassroomDetail;
        }

        public static ClassroomDetail getLastClassroomDateOfNormalAndExtraClassroomDetail(int classroomId)
        {
            ClassroomDetail lastClassroomDetail = null;

            //List<ClassroomDetail> tempClassroomDetailList = ClassroomDetailManager.getAllNormalAndExtraClassroomDetailOrderByClassroomDate(classroomId);
            List<ClassroomDetail.ClassroomType> classroomTypeList = new List<ClassroomDetail.ClassroomType>();
            classroomTypeList.Add(ClassroomDetail.ClassroomType.NORMAL);
            classroomTypeList.Add(ClassroomDetail.ClassroomType.EXTRA);
            List<ClassroomDetail> tempClassroomDetailList = ClassroomDetailManager.findAllClassroomDetailByClassroomId(classroomId, classroomTypeList, ClassroomDetail.columnClassroomDate);
            if (tempClassroomDetailList.Count > 0)
            {
                lastClassroomDetail = tempClassroomDetailList[tempClassroomDetailList.Count - 1];
            }

            return lastClassroomDetail;
        }

        public static int getNumberOfAbsenceByStudent(int classroomId)
        {
            int numberOfAbsence = 0;

            List<ClassroomDetail> tempClassroomDetailList = ClassroomDetailManager.findAllClassroomDetailByClassroomId(classroomId);
            for (int i = 0; i < tempClassroomDetailList.Count; i++)
            {
                if (tempClassroomDetailList[i].CurrentStatus == ClassroomDetail.ClassroomStatus.STUDENT_ABSENT.ToString())
                {
                    numberOfAbsence++;
                }
            }

            return numberOfAbsence;
        }

        public static DateTime getMinClassroomDate(List<ClassroomDetail> classroomDetailList)
        {
            int minIndex = 0;

            for (int i = 0; i < classroomDetailList.Count; i++)
            {
                if (i > 0)
                {
                    if (classroomDetailList[i].ClassroomDate < classroomDetailList[minIndex].ClassroomDate)
                    {
                        minIndex = i;
                    }
                    else if (classroomDetailList[i].ClassroomDate == classroomDetailList[minIndex].ClassroomDate)
                    {
                        string minTime = DateTimeManager.getMinTime(classroomDetailList[i].ClassroomTime, classroomDetailList[minIndex].ClassroomTime);
                        if (minTime == classroomDetailList[i].ClassroomTime)
                        {
                            minIndex = i;
                        }
                    }
                }
            }

            return classroomDetailList[minIndex].ClassroomDate;
        }

        public static DateTime getMaxClassroomDate(List<ClassroomDetail> classroomDetailList)
        {
            int maxIndex = 0;

            for (int i = 0; i < classroomDetailList.Count; i++)
            {
                if (i > 0)
                {
                    if (classroomDetailList[i].ClassroomDate > classroomDetailList[maxIndex].ClassroomDate)
                    {
                        maxIndex = i;
                    }
                    else if (classroomDetailList[i].ClassroomDate == classroomDetailList[maxIndex].ClassroomDate)
                    {
                        string minTime = DateTimeManager.getMinTime(classroomDetailList[i].ClassroomTime, classroomDetailList[maxIndex].ClassroomTime);
                        if (minTime == classroomDetailList[maxIndex].ClassroomTime)
                        {
                            maxIndex = i;
                        }
                    }
                }
            }

            return classroomDetailList[maxIndex].ClassroomDate;
        }

        public static ClassroomDetail updateClassroomDetailType(string newType, ClassroomDetail classroomDetail)
        {
            classroomDetail.Type = newType;
            if (classroomDetail.Type == ClassroomDetail.ClassroomType.NORMAL.ToString())
            {
                classroomDetail.DisplayType = "ปกติ";
            }
            else if (classroomDetail.Type == ClassroomDetail.ClassroomType.POSTPONE1.ToString())
            {
                classroomDetail.DisplayType = "เลื่อนครั้งที่ 1";
            }
            else if (classroomDetail.Type == ClassroomDetail.ClassroomType.POSTPONE2.ToString())
            {
                classroomDetail.DisplayType = "เลื่อนครั้ง 2";
            }
            else if (classroomDetail.Type == ClassroomDetail.ClassroomType.EXTRA.ToString())
            {
                classroomDetail.DisplayType = "ชดเชย";
            }

            return classroomDetail;
        }

        public static ClassroomDetail updateClassroomDetailStatus(string newStatus, ClassroomDetail classroomDetail)
        {
            classroomDetail.CurrentStatus = newStatus;

            if (classroomDetail.CurrentStatus == ClassroomDetail.ClassroomStatus.WAITING.ToString())
            {
                classroomDetail.DisplayStatus = "รอเช็คอิน";
            }
            else if (classroomDetail.CurrentStatus == ClassroomDetail.ClassroomStatus.CHECKED_IN.ToString())
            {
                classroomDetail.DisplayStatus = "เช็คอินแล้ว";
            }
            else if (classroomDetail.CurrentStatus == ClassroomDetail.ClassroomStatus.POSTPONE1.ToString())
            {
                classroomDetail.DisplayStatus = "เลื่อนครั้งที่ 1";
            }
            else if (classroomDetail.CurrentStatus == ClassroomDetail.ClassroomStatus.POSTPONE2.ToString())
            {
                classroomDetail.DisplayStatus = "เลื่อนครั้งที่ 2";
            }
            else if (classroomDetail.CurrentStatus == ClassroomDetail.ClassroomStatus.STUDENT_ABSENT.ToString())
            {
                classroomDetail.DisplayStatus = "นักเรียนลา";
            }
            else if (classroomDetail.CurrentStatus == ClassroomDetail.ClassroomStatus.TEACHER_ABSENT.ToString())
            {
                classroomDetail.DisplayStatus = "ครูลา";
            }
            else if (classroomDetail.CurrentStatus == ClassroomDetail.ClassroomStatus.SCHOOL_CLOSE.ToString())
            {
                classroomDetail.DisplayStatus = "โรงเรียนหยุด";
            }
            else if (classroomDetail.CurrentStatus == ClassroomDetail.ClassroomStatus.MISSING.ToString())
            {
                classroomDetail.DisplayStatus = "นักเรียนขาด";
            }

            return classroomDetail;
        }

        public static bool createPostponedClassroomDetail(string newStatus, ClassroomDetail classroomDetail, Course course, DateTime newClassroomDate, string newClassroomTime)
        {
            bool returnFlag = false;

            if (ClassroomDetailManager.checkAvailable(classroomDetail, course, newClassroomDate, newClassroomTime).Result)
            {
                classroomDetail = ClassroomDetailManager.updateClassroomDetailStatus(newStatus, classroomDetail);
                bool isUpdateSuccess = ClassroomDetailManager.updateClassroomDetail(classroomDetail);
                if (isUpdateSuccess)
                {
                    ClassroomDetail newClassroomDetail = new ClassroomDetail(classroomDetail);
                    newClassroomDetail.ClassroomNo = classroomDetail.ClassroomNo + 0.1;
                    newClassroomDetail.ClassroomDate = newClassroomDate;
                    newClassroomDetail.ClassroomTime = newClassroomTime;
                    newClassroomDetail.ClassroomDuration = classroomDetail.ClassroomDuration;

                    if (classroomDetail.Type == ClassroomDetail.ClassroomType.NORMAL.ToString())
                    {
                        newClassroomDetail = ClassroomDetailManager.updateClassroomDetailType(ClassroomDetail.ClassroomType.POSTPONE1.ToString(), newClassroomDetail);
                    }
                    else if (classroomDetail.Type == ClassroomDetail.ClassroomType.POSTPONE1.ToString())
                    {
                        newClassroomDetail = ClassroomDetailManager.updateClassroomDetailType(ClassroomDetail.ClassroomType.POSTPONE2.ToString(), newClassroomDetail);
                    }

                    newClassroomDetail = ClassroomDetailManager.updateClassroomDetailStatus(ClassroomDetail.ClassroomStatus.WAITING.ToString(), newClassroomDetail);
                    newClassroomDetail.RoomDetailId = -1;
                    newClassroomDetail.RegularClassroomDetailId = classroomDetail.ClassroomDetailId;

                    returnFlag = ClassroomDetailManager.insertClassroomDetail(newClassroomDetail);
                }
            }                        

            return returnFlag;
        }

        public static bool createExtraClassroomDetail(string newStatus, ClassroomDetail classroomDetail)
        {
            bool returnFlag = false;

            classroomDetail = ClassroomDetailManager.updateClassroomDetailStatus(newStatus, classroomDetail);
            bool isUpdateSuccess = ClassroomDetailManager.updateClassroomDetail(classroomDetail);
            if (isUpdateSuccess)
            {
                ClassroomDetail classroomDetailWithLastClassroomNo = ClassroomDetailManager.getLastClassroomNoOfNormalAndExtraClassroomDetail(classroomDetail.ClassroomId);
                ClassroomDetail classroomDetailWithLastClassroomDate = ClassroomDetailManager.getLastClassroomDateOfNormalAndExtraClassroomDetail(classroomDetail.ClassroomId);
                if ((classroomDetailWithLastClassroomNo != null) && (classroomDetailWithLastClassroomDate != null))
                {
                    ClassroomDetail newClassroomDetail = new ClassroomDetail();
                    newClassroomDetail.ClassroomId = classroomDetail.ClassroomId;
                    newClassroomDetail.ClassroomNo = classroomDetailWithLastClassroomNo.ClassroomNo + 1;
                    newClassroomDetail.TeacherId = classroomDetail.TeacherId;
                    newClassroomDetail.ClassroomDate = classroomDetailWithLastClassroomDate.ClassroomDate.AddDays(7);
                    newClassroomDetail.ClassroomTime = classroomDetail.ClassroomTime;
                    newClassroomDetail.ClassroomDuration = classroomDetail.ClassroomDuration;
                    newClassroomDetail = ClassroomDetailManager.updateClassroomDetailType(ClassroomDetail.ClassroomType.EXTRA.ToString(), newClassroomDetail);
                    newClassroomDetail = ClassroomDetailManager.updateClassroomDetailStatus(ClassroomDetail.ClassroomStatus.WAITING.ToString(), newClassroomDetail);
                    newClassroomDetail.RoomDetailId = -1;
                    newClassroomDetail.RegularClassroomDetailId = classroomDetail.ClassroomDetailId;

                    returnFlag = ClassroomDetailManager.insertClassroomDetail(newClassroomDetail);
                }
            }

            return returnFlag;
        }

        public static bool createExtraClassroomDetail(string newStatus, ClassroomDetail classroomDetail, int teacherId)
        {
            bool returnFlag = false;

            classroomDetail = ClassroomDetailManager.updateClassroomDetailStatus(newStatus, classroomDetail);
            bool isUpdateSuccess = ClassroomDetailManager.updateClassroomDetail(classroomDetail);
            if (isUpdateSuccess)
            {
                ClassroomDetail newClassroomDetail = new ClassroomDetail();
                newClassroomDetail.ClassroomId = classroomDetail.ClassroomId;
                newClassroomDetail.ClassroomNo = classroomDetail.ClassroomNo + 0.1;
                newClassroomDetail.TeacherId = teacherId;
                newClassroomDetail.ClassroomDate = classroomDetail.ClassroomDate;
                newClassroomDetail.ClassroomTime = classroomDetail.ClassroomTime;
                newClassroomDetail.ClassroomDuration = classroomDetail.ClassroomDuration;
                newClassroomDetail = ClassroomDetailManager.updateClassroomDetailType(ClassroomDetail.ClassroomType.EXTRA.ToString(), newClassroomDetail);
                newClassroomDetail = ClassroomDetailManager.updateClassroomDetailStatus(ClassroomDetail.ClassroomStatus.WAITING.ToString(), newClassroomDetail);
                newClassroomDetail.RoomDetailId = -1;
                newClassroomDetail.RegularClassroomDetailId = classroomDetail.ClassroomDetailId;

                returnFlag = ClassroomDetailManager.insertClassroomDetail(newClassroomDetail);
            }

            return returnFlag;
        }

        public static bool deleteExtraClassroomDetail(string newStatus, ClassroomDetail classroomDetail, Course course, DateTime newClassroomDate, string newClassroomTime)
        {
            bool returnFlag = false;

            if (ClassroomDetailManager.checkAvailable(classroomDetail, course, newClassroomDate, newClassroomTime).Result)
            {
                classroomDetail = ClassroomDetailManager.updateClassroomDetailStatus(newStatus, classroomDetail);

                if (newClassroomDate != classroomDetail.ClassroomDate)
                {
                    classroomDetail.ClassroomDate = newClassroomDate;
                }

                if (newClassroomTime != classroomDetail.ClassroomTime)
                {
                    classroomDetail.ClassroomTime = newClassroomTime;
                }

                bool isUpdateSuccess = ClassroomDetailManager.updateClassroomDetail(classroomDetail);
                if (isUpdateSuccess)
                {
                    //ClassroomDetail extraClassroomDetail = ClassroomDetailManager.getNonNormalClassroomDetail(classroomDetail.ClassroomDetailId);
                    ClassroomDetail tempExtraClassroomDetail = ClassroomDetailManager.findClassroomDetailByRegularClassroomDetail(classroomDetail.ClassroomDetailId);
                    while (tempExtraClassroomDetail != null)
                    {
                        returnFlag = ClassroomDetailManager.deleteClassroomDetail(tempExtraClassroomDetail.ClassroomDetailId);
                        if (returnFlag)
                        {
                            //tempExtraClassroomDetail = ClassroomDetailManager.getNonNormalClassroomDetail(tempExtraClassroomDetail.ClassroomDetailId);
                            tempExtraClassroomDetail = ClassroomDetailManager.findClassroomDetailByRegularClassroomDetail(tempExtraClassroomDetail.ClassroomDetailId);
                        }
                        else
                        {
                            tempExtraClassroomDetail = null;
                        }
                    }
                }
            }            

            return returnFlag;
        }

        public static List<ClassroomDetail> sortClassroomDetailListByClassroomNo(List<ClassroomDetail> classroomDetailList)
        {
            for (int i = 0; i < classroomDetailList.Count; i++)
            {
                for (int j = i + 1; j < classroomDetailList.Count; j++)
                {
                    if (classroomDetailList[j].ClassroomNo < classroomDetailList[i].ClassroomNo)
                    {
                        ClassroomDetail tempClassroomDetail = classroomDetailList[i];
                        classroomDetailList[i] = classroomDetailList[j];
                        classroomDetailList[j] = tempClassroomDetail;
                    }
                }
            }

            return classroomDetailList;
        }

        public static List<ClassroomDetail> sortClassroomDetailListByClassroomTime(List<ClassroomDetail> classroomDetailList)
        {
            for (int i = 0; i < classroomDetailList.Count; i++)
            {
                for (int j = i + 1; j < classroomDetailList.Count; j++)
                {
                    string time1 = classroomDetailList[i].ClassroomTime;
                    string time2 = classroomDetailList[j].ClassroomTime;
                    if (classroomDetailList[j].ClassroomTime == DateTimeManager.getMinTime(time1, time2))
                    {
                        ClassroomDetail tempClassroomDetail = classroomDetailList[i];
                        classroomDetailList[i] = classroomDetailList[j];
                        classroomDetailList[j] = tempClassroomDetail;
                    }
                }
            }

            return classroomDetailList;
        }

        public static List<DateTime> generateClassroomDate(List<Classroom> classroomList, int numberOfClassroom)
        {
            List<DateTime> classroomDateList = new List<DateTime>();
            List<ClassroomDetail> classroomDetailList = new List<ClassroomDetail>();

            for (int i = 0; i < classroomList.Count; i++)
            {
                DateTime startDate = classroomList[i].StartDate;
                for (int j = 1; j <= (numberOfClassroom / classroomList.Count); j++)
                {
                    classroomDateList.Add(startDate.AddDays(7 * (j - 1)));
                }
            }

            classroomDetailList = ClassroomDetailManager.sortClassroomDetailListByClassroomNo(classroomDetailList);
            for (int i = 0; i < classroomDetailList.Count; i++)
            {
                classroomDateList.Add(classroomDetailList[i].ClassroomDate);
            }

            return classroomDateList;
        }

        public static PianoForteResult checkAvailable(ClassroomDetail classroomDetail, Course course, DateTime date, string time)
        {
            PianoForteResult pianoForteResult = new PianoForteResult();
            pianoForteResult.Result = true;
            //List<ClassroomDetail> tempClassroomDetailList = ClassroomDetailManager.getAllClassroomDetail(classroomDetail.TeacherId, date, ClassroomDetail.ClassroomStatus.WAITING.ToString());
            //if (tempClassroomDetailList.Count == 0)
            //{
            //    pianoForteResult.Result = true;                
            //}
            //else
            //{
            //    for (int i = 0; i < tempClassroomDetailList.Count; i++)
            //    {
            //        ClassroomDetail tempClassroomDetail = tempClassroomDetailList[i];
            //        if (tempClassroomDetail != null)
            //        {
            //            if (classroomDetail.ClassroomDetailId != tempClassroomDetail.ClassroomDetailId)
            //            {
            //                string startTime = tempClassroomDetail.ClassroomTime;
            //                string endTime = DateTimeManager.addMinute(startTime, tempClassroomDetail.ClassroomDuration);

            //                if ((!DateTimeManager.isBetweenTimeInterval(startTime, endTime, time)) &&
            //                    (!DateTimeManager.isBetweenTimeInterval(startTime, endTime, DateTimeManager.addMinute(time, classroomDetail.ClassroomDuration))))
            //                {
            //                    pianoForteResult.Result = true; 
            //                }
            //                else
            //                {
            //                    if (course.StudentPerClassroom > 1)
            //                    {
            //                        int maxNumberOfStudent = course.StudentPerClassroom;
            //                        int currentNumberOfStudent = 0;
            //                        string message = "";

            //                        for (int j = 0; j < tempClassroomDetailList.Count; j++)
            //                        {
            //                            if ((tempClassroomDetailList[j].TeacherId == tempClassroomDetail.TeacherId) &&
            //                                (tempClassroomDetailList[j].ClassroomDate == tempClassroomDetail.ClassroomDate) &&
            //                                (tempClassroomDetailList[j].ClassroomTime == tempClassroomDetail.ClassroomTime) &&
            //                                (tempClassroomDetailList[j].Status == ClassroomDetail.ClassroomStatus.WAITING.ToString()))
            //                            {
            //                                Classroom tempClassroom = ClassroomManager.getClassroom(tempClassroomDetailList[j].ClassroomId);
            //                                if (tempClassroom != null)
            //                                {
            //                                    Enrollment tempEnrollment = EnrollmentManager.getEnrollment(tempClassroom.EnrollmentId);
            //                                    if (tempEnrollment != null)
            //                                    {
            //                                        if (tempEnrollment.Course != null)
            //                                        {
            //                                            if (tempEnrollment.Course.StudentPerClassroom > 1)
            //                                            {
            //                                                if (tempEnrollment.Course.StudentPerClassroom > maxNumberOfStudent)
            //                                                {
            //                                                    maxNumberOfStudent = tempEnrollment.Course.StudentPerClassroom;
            //                                                }

            //                                                string tempMessage = "วันที่ " + String.Format("{0:dd/MM/yyyy}", tempClassroomDetail.ClassroomDate) + " " +
            //                                                                     "เวลา " + tempClassroomDetail.ClassroomTime + " - " + DateTimeManager.addMinute(tempClassroomDetail.ClassroomTime, tempClassroomDetail.ClassroomDuration) + " " +
            //                                                                     "มีนักเรียนท่านอื่นเรียนอยู่แล้ว";

            //                                                if (message == "")
            //                                                {
            //                                                    message += tempMessage;
            //                                                }
            //                                                else
            //                                                {
            //                                                    message += "\n" + tempMessage;
            //                                                }
                                                            
            //                                                currentNumberOfStudent++;
            //                                            }                                                        
            //                                        }
            //                                    }
            //                                }
            //                            }                                                                                
            //                        }

            //                        if (currentNumberOfStudent < maxNumberOfStudent)
            //                        {
            //                            pianoForteResult.Result = true;
            //                        }
            //                        else
            //                        {
            //                            pianoForteResult.Result = false;
            //                            pianoForteResult.Message = message;
            //                            break;
            //                        }
            //                    }
            //                    else
            //                    {
            //                        pianoForteResult.Result = false;
            //                        pianoForteResult.Message = "วันที่ " + String.Format("{0:dd/MM/yyyy}", tempClassroomDetail.ClassroomDate) + " " +
            //                                                   "เวลา " + tempClassroomDetail.ClassroomTime + " - " + DateTimeManager.addMinute(tempClassroomDetail.ClassroomTime, tempClassroomDetail.ClassroomDuration) + " " +
            //                                                   "มีนักเรียนท่านอื่นเรียนอยู่แล้ว";
            //                        break;
            //                    }
            //                }
            //            }                        
            //        }
            //    }
            //}

            return pianoForteResult;
        }
    }
}
