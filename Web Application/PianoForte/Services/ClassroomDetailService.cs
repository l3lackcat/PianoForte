using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using PianoForte.Dao;
using PianoForte.Models;

namespace PianoForte.Services
{
    public class ClassroomDetailService
    {
        private static ClassroomDetailDao classroomDetailDao = DaoFactory.getDaoFactory(DaoFactory.FactoryType.MYSQL).getClassroomDetailDao();

        public static bool insertClassroomDetail(string databaseName, ClassroomDetail classroomDetail)
        {
            return classroomDetailDao.insertClassroomDetail(databaseName, classroomDetail);
        }

        public static bool updateClassroomDetail(string databaseName, ClassroomDetail classroomDetail)
        {
            return classroomDetailDao.updateClassroomDetail(databaseName, classroomDetail);
        }

        public static bool updateClassroomDetailStatus(string databaseName)
        {
            return classroomDetailDao.updateClassroomDetailStatus(databaseName);
        }

        public static List<ClassroomDetail> getClassroomDetailListByTeacherId(string databaseName, int teacherId)
        {
            return classroomDetailDao.getClassroomDetailListByTeacherId(databaseName, teacherId);
        }
    }
}