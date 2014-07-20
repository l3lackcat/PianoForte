using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using PianoForte.Dao;
using PianoForte.Models;

namespace PianoForte.Services
{
    public class TeacherService
    {
        private static TeacherDao teacherDao = DaoFactory.getDaoFactory(DaoFactory.FactoryType.MYSQL).getTeacherDao();

        public static int getNextTeacherId(string databaseName)
        {
            int teacherId = 1001;

            Teacher teacher = teacherDao.getLastTeacher(databaseName);
            if (teacher != null)
            {
                teacherId = teacher.Id + 1;
            }

            return teacherId;
        }

        public static bool insertTeacher(string databaseName, Teacher teacher)
        {
            return teacherDao.insertTeacher(databaseName, teacher);
        }

        public static bool updateTeacher(string databaseName, Teacher teacher)
        {
            return teacherDao.updateTeacher(databaseName, teacher);
        }

        public static Teacher getTeacher(string databaseName, int id)
        {
            return teacherDao.getTeacher(databaseName, id);
        }

        public static List<Teacher> getTeacherList(string databaseName)
        {
            return teacherDao.getTeacherList(databaseName);
        }
    }
}