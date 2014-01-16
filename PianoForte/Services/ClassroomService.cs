using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PianoForte.Dao;
using PianoForte.Models;

namespace PianoForte.Services
{
    public class ClassroomService
    {
        private static ClassroomDao classroomDao = DaoFactory.getDaoFactory(DaoFactory.FactoryType.MYSQL).getClassroomDao();

        public static bool insertClassroom(string databaseName, Classroom classroom)
        {
            return classroomDao.insertClassroom(databaseName, classroom);
        }

        public static bool updateClassroom(string databaseName, Classroom classroom)
        {
            return classroomDao.updateClassroom(databaseName, classroom);
        }
    }
}