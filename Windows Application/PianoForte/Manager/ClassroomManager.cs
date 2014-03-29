using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PianoForte.Dao;
using PianoForte.Model;

namespace PianoForte.Manager
{
    class ClassroomManager
    {
        private static ClassroomDao classroomDao = DaoFactory.getDaoFactory(DaoFactory.FactoryType.MYSQL).getClassroomDao();

        //--------------------------------------------------------------------------------

        public static Classroom insertClassroom(Classroom classroom)
        {
            bool isInsertComplete = classroomDao.insertClassroom(classroom);
            if (isInsertComplete)
            {
                classroom.Id = classroomDao.findLastClassroom().Id;
            }
            else
            {
                classroom = null;
            }

            return classroom;
        }

        public static bool updateClassroom(Classroom classroom)
        {
            return classroomDao.updateClassroom(classroom);
        }

        public static bool deleteClassroom(int classroomId)
        {
            return classroomDao.deleteClassroom(classroomId);
        }

        //--------------------------------------------------------------------------------

        public static Classroom findClassroom(int classroomId)
        {
            return classroomDao.findClassroom(classroomId);
        }

        //--------------------------------------------------------------------------------

        //public static Classroom getClassroom_old(int classroomId)
        //{
        //    return classroomService.getClassroom_old(classroomId);
        //}
        
        //public static Classroom getClassroom(Classroom classroom)
        //{
        //    return classroomService.getClassroom(classroom);
        //}
        
        public static List<Classroom> findAllClassroom()
        {
            return classroomDao.findAllClassroom();
        }

        public static List<Classroom> findAllClassroom(int enrollmentId)
        {
            return classroomDao.findAllClassroom(enrollmentId);
        }

        //--------------------------------------------------------------------------------

        //public static List<Classroom> getAllClassroom_old()
        //{
        //    return classroomService.getAllClassroom_old();
        //}
        
        //public static bool isHaveClassroom(Classroom classroom)
        //{
        //    bool returnFlag = false;

        //    if (classroomService.getClassroom(classroom) != null)
        //    {
        //        returnFlag = true;
        //    }

        //    return returnFlag;
        //}

        //public static bool pairClassroomAndEnrollmentId(int classroomId, int enrollmentId)
        //{
        //    return classroomEnrollmentService.addClassroomEnrollment(classroomId, enrollmentId);
        //}

        //public static List<int> getClassroomIdByEnrollmentId(int enrollmentId)
        //{
        //    return classroomEnrollmentService.getClassroomIdByEnrollmentId(enrollmentId);
        //}

        public static List<Classroom> arrangeClassroomByDateTime(List<Classroom> classroomList)
        {
            if (classroomList[0].StartDate > classroomList[1].StartDate)
            {
                Classroom tempClassroom = classroomList[0];
                classroomList[0] = classroomList[1];
                classroomList[1] = tempClassroom;
            }
            else if (classroomList[0].StartDate == classroomList[1].StartDate)
            {
                string minTime = DateTimeManager.getMinTime(classroomList[0].ClassTime, classroomList[1].ClassTime);
                if (minTime == classroomList[1].ClassTime)
                {
                    Classroom tempClassroom = classroomList[0];
                    classroomList[0] = classroomList[1];
                    classroomList[1] = tempClassroom;
                }
            }

            return classroomList;
        }
    }
}
