using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PianoForte.Dao;
using PianoForte.Model;

namespace PianoForte.Manager
{
    public class TeacherManager
    {
        private static TeacherDao teacherDao = DaoFactory.getDaoFactory(DaoFactory.FactoryType.MYSQL).getTeacherDao();

        //--------------------------------------------------------------------------------

        public static Teacher insertTeacher(Teacher teacher)
        {
            bool isInsertComplete = teacherDao.insertTeacher(teacher);
            if (isInsertComplete)
            {
                teacher.Id = teacherDao.findLastTeacher().Id;
            }
            else
            {
                teacher = null;
            }

            return teacher;
        }

        public static bool updateTeacher(Teacher teacher)
        {
            return teacherDao.updateTeacher(teacher);
        }

        public static bool deleteTeacher(int teacherId)
        {
            return teacherDao.deleteTeacher(teacherId);
        }

        //--------------------------------------------------------------------------------

        public static Teacher findTeacher(int teacherId)
        {
            return teacherDao.findTeacher(teacherId);
        }

        //--------------------------------------------------------------------------------

        public static List<Teacher> findAllTeacher()
        {
            return teacherDao.findAllTeacher();
        }

        public static List<Teacher> findAllTeacher(int startIndex, int offset)
        {
            return teacherDao.findAllTeacher(startIndex, offset);
        }

        public static List<Teacher> findAllTeacher(Teacher.TeacherStatus status)
        {
            List<Teacher> teacherList;

            if (status == Teacher.TeacherStatus.ALL)
            {
                teacherList = teacherDao.findAllTeacher();
            }
            else
            {
                teacherList = teacherDao.findAllTeacher(status);
            }

            return teacherList;
        }

        public static List<Teacher> findAllTeacher(Teacher.TeacherStatus status, int startIndex, int offset)
        {
            List<Teacher> teacherList;

            if (status == Teacher.TeacherStatus.ALL)
            {
                teacherList = teacherDao.findAllTeacher(startIndex, offset);
            }
            else
            {
                teacherList = teacherDao.findAllTeacher(status, startIndex, offset);
            }

            return teacherList;
        }

        //--------------------------------------------------------------------------------

        public static List<Teacher> findAllTeacherByFirstname(string firstname)
        {
            return teacherDao.findAllTeacherByFirstname(firstname);
        }

        public static List<Teacher> findAllTeacherByFirstname(string firstname, int startIndex, int offset)
        {
            return teacherDao.findAllTeacherByFirstname(firstname, startIndex, offset);
        }

        public static List<Teacher> findAllTeacherByFirstname(string firstname, Teacher.TeacherStatus status)
        {
            List<Teacher> teacherList;

            if (status == Teacher.TeacherStatus.ALL)
            {
                teacherList = teacherDao.findAllTeacherByFirstname(firstname);
            }
            else
            {
                teacherList = teacherDao.findAllTeacherByFirstname(firstname, status);
            }

            return teacherList;
        }

        public static List<Teacher> findAllTeacherByFirstname(string firstname, Teacher.TeacherStatus status, int startIndex, int offset)
        {
            List<Teacher> teacherList;

            if (status == Teacher.TeacherStatus.ALL)
            {
                teacherList = teacherDao.findAllTeacherByFirstname(firstname, startIndex, offset);
            }
            else
            {
                teacherList = teacherDao.findAllTeacherByFirstname(firstname, status, startIndex, offset);
            }

            return teacherList;
        }

        //--------------------------------------------------------------------------------

        public static List<Teacher> findAllTeacherByLastname(string lastname)
        {
            return teacherDao.findAllTeacherByLastname(lastname);
        }

        public static List<Teacher> findAllTeacherByLastname(string lastname, int startIndex, int offset)
        {
            return teacherDao.findAllTeacherByLastname(lastname, startIndex, offset);
        }

        public static List<Teacher> findAllTeacherByLastname(string lastname, Teacher.TeacherStatus status)
        {
            List<Teacher> teacherList;

            if (status == Teacher.TeacherStatus.ALL)
            {
                teacherList = teacherDao.findAllTeacherByLastname(lastname);
            }
            else
            {
                teacherList = teacherDao.findAllTeacherByLastname(lastname, status);
            }

            return teacherList;
        }

        public static List<Teacher> findAllTeacherByLastname(string lastname, Teacher.TeacherStatus status, int startIndex, int offset)
        {
            List<Teacher> teacherList;

            if (status == Teacher.TeacherStatus.ALL)
            {
                teacherList = teacherDao.findAllTeacherByLastname(lastname, startIndex, offset);
            }
            else
            {
                teacherList = teacherDao.findAllTeacherByLastname(lastname, status, startIndex, offset);
            }

            return teacherList;
        }

        //--------------------------------------------------------------------------------

        public static List<Teacher> findAllTeacherByNickname(string nickname)
        {
            return teacherDao.findAllTeacherByNickname(nickname);
        }

        public static List<Teacher> findAllTeacherByNickname(string nickname, int startIndex, int offset)
        {
            return teacherDao.findAllTeacherByNickname(nickname, startIndex, offset);
        }

        public static List<Teacher> findAllTeacherByNickname(string nickname, Teacher.TeacherStatus status)
        {
            List<Teacher> teacherList;

            if (status == Teacher.TeacherStatus.ALL)
            {
                teacherList = teacherDao.findAllTeacherByNickname(nickname);
            }
            else
            {
                teacherList = teacherDao.findAllTeacherByNickname(nickname, status);
            }

            return teacherList;
        }

        public static List<Teacher> findAllTeacherByNickname(string nickname, Teacher.TeacherStatus status, int startIndex, int offset)
        {
            List<Teacher> teacherList;

            if (status == Teacher.TeacherStatus.ALL)
            {
                teacherList = teacherDao.findAllTeacherByNickname(nickname, startIndex, offset);
            }
            else
            {
                teacherList = teacherDao.findAllTeacherByNickname(nickname, status, startIndex, offset);
            }

            return teacherList;
        }

        //--------------------------------------------------------------------------------

        public static List<Teacher> findAllTeacherByFirstnameAndLastname(string firstname, string lastname)
        {
            return teacherDao.findAllTeacherByFirstnameAndLastname(firstname, lastname);
        }

        public static List<Teacher> findAllTeacherByFirstnameAndLastname(string firstname, string lastname, int startIndex, int offset)
        {
            return teacherDao.findAllTeacherByFirstnameAndLastname(firstname, lastname, startIndex, offset);
        }

        public static List<Teacher> findAllTeacherByFirstnameAndLastname(string firstname, string lastname, Teacher.TeacherStatus status)
        {
            List<Teacher> teacherList;

            if (status == Teacher.TeacherStatus.ALL)
            {
                teacherList = teacherDao.findAllTeacherByFirstnameAndLastname(firstname, lastname);
            }
            else
            {
                teacherList = teacherDao.findAllTeacherByFirstnameAndLastname(firstname, lastname, status);
            }

            return teacherList;
        }

        public static List<Teacher> findAllTeacherByFirstnameAndLastname(string firstname, string lastname, Teacher.TeacherStatus status, int startIndex, int offset)
        {
            List<Teacher> teacherList;

            if (status == Teacher.TeacherStatus.ALL)
            {
                teacherList = teacherDao.findAllTeacherByFirstnameAndLastname(firstname, lastname, startIndex, offset);
            }
            else
            {
                teacherList = teacherDao.findAllTeacherByFirstnameAndLastname(firstname, lastname, status, startIndex, offset);
            }

            return teacherList;
        }

        //--------------------------------------------------------------------------------

        public static List<Teacher> findAllTeacherByFirstnameAndNickname(string firstname, string nickname)
        {
            return teacherDao.findAllTeacherByFirstnameAndNickname(firstname, nickname);
        }

        public static List<Teacher> findAllTeacherByFirstnameAndNickname(string firstname, string nickname, int startIndex, int offset)
        {
            return teacherDao.findAllTeacherByFirstnameAndNickname(firstname, nickname, startIndex, offset);
        }

        public static List<Teacher> findAllTeacherByFirstnameAndNickname(string firstname, string nickname, Teacher.TeacherStatus status)
        {
            List<Teacher> teacherList;

            if (status == Teacher.TeacherStatus.ALL)
            {
                teacherList = teacherDao.findAllTeacherByFirstnameAndNickname(firstname, nickname);
            }
            else
            {
                teacherList = teacherDao.findAllTeacherByFirstnameAndNickname(firstname, nickname, status);
            }

            return teacherList;
        }

        public static List<Teacher> findAllTeacherByFirstnameAndNickname(string firstname, string nickname, Teacher.TeacherStatus status, int startIndex, int offset)
        {
            List<Teacher> teacherList;

            if (status == Teacher.TeacherStatus.ALL)
            {
                teacherList = teacherDao.findAllTeacherByFirstnameAndNickname(firstname, nickname, startIndex, offset);
            }
            else
            {
                teacherList = teacherDao.findAllTeacherByFirstnameAndNickname(firstname, nickname, status, startIndex, offset);
            }

            return teacherList;
        }

        //--------------------------------------------------------------------------------

        public static List<Teacher> findAllTeacherByLastnameAndNickname(string lastname, string nickname)
        {
            return teacherDao.findAllTeacherByLastnameAndNickname(lastname, nickname);
        }

        public static List<Teacher> findAllTeacherByLastnameAndNickname(string lastname, string nickname, int startIndex, int offset)
        {
            return teacherDao.findAllTeacherByLastnameAndNickname(lastname, nickname, startIndex, offset);
        }

        public static List<Teacher> findAllTeacherByLastnameAndNickname(string lastname, string nickname, Teacher.TeacherStatus status)
        {
            List<Teacher> teacherList;

            if (status == Teacher.TeacherStatus.ALL)
            {
                teacherList = teacherDao.findAllTeacherByLastnameAndNickname(lastname, nickname);
            }
            else
            {
                teacherList = teacherDao.findAllTeacherByLastnameAndNickname(lastname, nickname, status);
            }

            return teacherList;
        }

        public static List<Teacher> findAllTeacherByLastnameAndNickname(string lastname, string nickname, Teacher.TeacherStatus status, int startIndex, int offset)
        {
            List<Teacher> teacherList;

            if (status == Teacher.TeacherStatus.ALL)
            {
                teacherList = teacherDao.findAllTeacherByLastnameAndNickname(lastname, nickname, startIndex, offset);
            }
            else
            {
                teacherList = teacherDao.findAllTeacherByLastnameAndNickname(lastname, nickname, status, startIndex, offset);
            }

            return teacherList;
        }

        //--------------------------------------------------------------------------------

        public static List<Teacher> findAllTeacherByFirstnameAndLastnameAndNickname(string firstname, string lastname, string nickname)
        {
            return teacherDao.findAllTeacherByFirstnameAndLastnameAndNickname(firstname, lastname, nickname);
        }

        public static List<Teacher> findAllTeacherByFirstnameAndLastnameAndNickname(string firstname, string lastname, string nickname, int startIndex, int offset)
        {
            return teacherDao.findAllTeacherByFirstnameAndLastnameAndNickname(firstname, lastname, nickname, startIndex, offset);
        }

        public static List<Teacher> findAllTeacherByFirstnameAndLastnameAndNickname(string firstname, string lastname, string nickname, Teacher.TeacherStatus status)
        {
            List<Teacher> teacherList;

            if (status == Teacher.TeacherStatus.ALL)
            {
                teacherList = teacherDao.findAllTeacherByFirstnameAndLastnameAndNickname(firstname, lastname, nickname);
            }
            else
            {
                teacherList = teacherDao.findAllTeacherByFirstnameAndLastnameAndNickname(firstname, lastname, nickname, status);
            }

            return teacherList;
        }

        public static List<Teacher> findAllTeacherByFirstnameAndLastnameAndNickname(string firstname, string lastname, string nickname, Teacher.TeacherStatus status, int startIndex, int offset)
        {
            List<Teacher> teacherList;

            if (status == Teacher.TeacherStatus.ALL)
            {
                teacherList = teacherDao.findAllTeacherByFirstnameAndLastnameAndNickname(firstname, lastname, nickname, startIndex, offset);
            }
            else
            {
                teacherList = teacherDao.findAllTeacherByFirstnameAndLastnameAndNickname(firstname, lastname, nickname, status, startIndex, offset);
            }

            return teacherList;
        }

        //--------------------------------------------------------------------------------

        public static int generateNextTeacherId()
        {
            int teacherId = 0;

            Teacher teacher = teacherDao.findLastTeacher();
            if (teacher == null)
            {
                teacherId = 1001;
            }
            else
            {
                teacherId = teacher.Id + 1;
            }

            return teacherId;
        }        
    }
}
