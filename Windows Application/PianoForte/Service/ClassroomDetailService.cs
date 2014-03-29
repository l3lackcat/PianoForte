using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PianoForte.Dao;
using PianoForte.Model;

namespace PianoForte.Service
{
    public class ClassroomDetailService
    {
        private ClassroomDetailDaoImplMySql classroomDetailDao = new ClassroomDetailDaoImplMySql();

        public bool addClassroomDetail(ClassroomDetail classroomDetail)
        {
            string sql = "INSERT INTO " +
                         ClassroomDetail.tableName + " (" +
                         ClassroomDetail.columnClassroomId + ", " +
                         ClassroomDetail.columnClassroomNo + ", " +
                         ClassroomDetail.columnTeacherId + ", " +
                         ClassroomDetail.columnClassroomDate + ", " +
                         ClassroomDetail.columnClassroomTime + ", " +
                         ClassroomDetail.columnClassroomDuration + ", " +
                         ClassroomDetail.columnClassroomType + ", " +
                         ClassroomDetail.columnCurrentStatus + ", " +
                         ClassroomDetail.columnPreviousStatus + ", " +
                         ClassroomDetail.columnRoomDetailId + ", " +
                         ClassroomDetail.columnRegularClassroomDetailId + ", " +
                         ClassroomDetail.columnCommission + ") " +
                         "VALUES(" +
                         "?" + ClassroomDetail.columnClassroomId + ", " +
                         "?" + ClassroomDetail.columnClassroomNo + ", " +
                         "?" + ClassroomDetail.columnTeacherId + ", " +
                         "?" + ClassroomDetail.columnClassroomDate + ", " +
                         "?" + ClassroomDetail.columnClassroomTime + ", " +
                         "?" + ClassroomDetail.columnClassroomDuration + ", " +
                         "?" + ClassroomDetail.columnClassroomType + ", " +
                         "?" + ClassroomDetail.columnCurrentStatus + ", " +
                         "?" + ClassroomDetail.columnPreviousStatus + ", " +
                         "?" + ClassroomDetail.columnRoomDetailId + ", " +
                         "?" + ClassroomDetail.columnRegularClassroomDetailId + "," +
                         "?" + ClassroomDetail.columnCommission + ")";

            return this.classroomDetailDao.processInsertString(sql, classroomDetail);
        }

        public bool updateClassroomDetail(ClassroomDetail classroomDetail)
        {
            string sql = "UPDATE " +
                         ClassroomDetail.tableName + " SET " +
                         ClassroomDetail.columnClassroomId + " = ?" + ClassroomDetail.columnClassroomId + ", " +
                         ClassroomDetail.columnClassroomNo + " = ?" + ClassroomDetail.columnClassroomNo + ", " +
                         ClassroomDetail.columnTeacherId + " = ?" + ClassroomDetail.columnTeacherId + ", " +
                         ClassroomDetail.columnClassroomDate + " = ?" + ClassroomDetail.columnClassroomDate + ", " +
                         ClassroomDetail.columnClassroomTime + " = ?" + ClassroomDetail.columnClassroomTime + ", " +
                         ClassroomDetail.columnClassroomDuration + " = ?" + ClassroomDetail.columnClassroomDuration + ", " +
                         ClassroomDetail.columnClassroomType + " = ?" + ClassroomDetail.columnClassroomType + ", " +
                         ClassroomDetail.columnCurrentStatus + " = ?" + ClassroomDetail.columnCurrentStatus + ", " +
                         ClassroomDetail.columnPreviousStatus + " = ?" + ClassroomDetail.columnPreviousStatus + ", " +
                         ClassroomDetail.columnRoomDetailId + " = ?" + ClassroomDetail.columnRoomDetailId + ", " +
                         ClassroomDetail.columnRegularClassroomDetailId + " = ?" + ClassroomDetail.columnRegularClassroomDetailId + ", " +
                         ClassroomDetail.columnCommission + " = ?" + ClassroomDetail.columnCommission + " " +
                         "WHERE " + ClassroomDetail.columnClassroomDetailId + " = ?" + ClassroomDetail.columnClassroomDetailId;

            return this.classroomDetailDao.processUpdateString(sql, classroomDetail);
        }

        public bool deleteClassroomDetail(int classroomDetailId)
        {
            string sql = "DELETE " +
                         "FROM " + ClassroomDetail.tableName + " " +
                         "WHERE " + ClassroomDetail.columnClassroomDetailId + " = " + classroomDetailId;

            return this.classroomDetailDao.processDeleteString(sql);
        }

        public ClassroomDetail getClassroomDetail(int classroomDetailId)
        {
            ClassroomDetail classroomDetail = null;

            string sql = "SELECT * " +
                         "FROM " + ClassroomDetail.tableName + " " +
                         "WHERE " + ClassroomDetail.columnClassroomDetailId + " = " + classroomDetailId;

            List<ClassroomDetail> classroomDetailList = this.classroomDetailDao.processQueryString(sql);
            if (classroomDetailList.Count > 0)
            {
                classroomDetail = classroomDetailList[0];
            }

            return classroomDetail;
        }

        public ClassroomDetail getNonNormalClassroomDetail(int regularClassroomDetailId)
        {
            ClassroomDetail postponedClassroomDetail = null;

            string sql = "SELECT * " +
                         "FROM " + ClassroomDetail.tableName + " " +
                         "WHERE " + ClassroomDetail.columnRegularClassroomDetailId + " = " + regularClassroomDetailId;

            List<ClassroomDetail> classroomDetailList = this.classroomDetailDao.processQueryString(sql);
            if (classroomDetailList.Count > 0)
            {
                postponedClassroomDetail = classroomDetailList[0];
            }

            return postponedClassroomDetail;
        }

        public List<ClassroomDetail> getAllClassroomDetail()
        {
            string sql = "SELECT * " +
                         "FROM " + ClassroomDetail.tableName + " " +
                         "ORDER BY " + ClassroomDetail.columnClassroomDetailId + " ASC";

            return this.classroomDetailDao.processQueryString(sql);
        }

        public List<ClassroomDetail> getAllClassroomDetail(int classroomId)
        {
            string sql = "SELECT * " +
                         "FROM " + ClassroomDetail.tableName + " " +
                         "WHERE " + ClassroomDetail.columnClassroomId + " = " + classroomId + " " +
                         "ORDER BY " + ClassroomDetail.columnClassroomNo + " ASC";

            return this.classroomDetailDao.processQueryString(sql);
        }

        public List<ClassroomDetail> getAllClassroomDetail(int teacherId, DateTime classroomDate, string classroomStatus)
        {
            string sql = "SELECT * " +
                         "FROM " + ClassroomDetail.tableName + " " +
                         "WHERE " + ClassroomDetail.columnTeacherId + " = " + teacherId + " " +
                         "AND " + ClassroomDetail.columnClassroomDate + " = '" + classroomDate.ToString(DatabaseManager.DATABASE_DATE_FORMAT) + "' " +
                         "AND " + ClassroomDetail.columnCurrentStatus + " = '" + classroomStatus + "' " +
                         "ORDER BY " + ClassroomDetail.columnClassroomTime + " ASC";

            return this.classroomDetailDao.processQueryString(sql);
        }

        public List<ClassroomDetail> getAllClassroomDetailByRoomDetailId(int roomDetailId)
        {
            string sql = "SELECT * " +
                         "FROM " + ClassroomDetail.tableName + " " +
                         "WHERE " + ClassroomDetail.columnRoomDetailId + " = " + roomDetailId + " " +
                         "ORDER BY " + ClassroomDetail.columnClassroomTime + " ASC";

            return this.classroomDetailDao.processQueryString(sql);
        }

        public List<ClassroomDetail> getAllClassroomDetailForCheckInForm(int teacherId, DateTime classroomDate)
        {
            string sql = "SELECT * " +
                         "FROM " + ClassroomDetail.tableName + " " +
                         "WHERE " + ClassroomDetail.columnTeacherId + " = " + teacherId + " " +
                         "AND " + ClassroomDetail.columnClassroomDate + " = '" + classroomDate.ToString(DatabaseManager.DATABASE_DATE_FORMAT) + "' " +
                         "AND (" + ClassroomDetail.columnCurrentStatus + " = '" + ClassroomDetail.ClassroomStatus.WAITING.ToString() + "' " +
                         "OR " + ClassroomDetail.columnCurrentStatus + " = '" + ClassroomDetail.ClassroomStatus.CHECKED_IN.ToString() + "' " +
                         "OR " + ClassroomDetail.columnCurrentStatus + " = '" + ClassroomDetail.ClassroomStatus.MISSING.ToString() + "') " +
                         "ORDER BY " + ClassroomDetail.columnClassroomTime + " ASC";

            return this.classroomDetailDao.processQueryString(sql);
        }

        public List<ClassroomDetail> getAllNormalClassroomDetail(int classroomId)
        {
            string sql = "SELECT * " +
                         "FROM " + ClassroomDetail.tableName + " " +
                         "WHERE " + ClassroomDetail.columnClassroomId + " = " + classroomId + " " +
                         "AND " + ClassroomDetail.columnClassroomType + " = '" + ClassroomDetail.ClassroomType.NORMAL.ToString() + "' " +
                         "ORDER BY " + ClassroomDetail.columnClassroomNo + " ASC";

            return this.classroomDetailDao.processQueryString(sql);
        }

        public List<ClassroomDetail> getAllNormalAndExtraClassroomDetailOrderByClassroomNo(int classroomId)
        {
            string sql = "SELECT * " +
                         "FROM " + ClassroomDetail.tableName + " " +
                         "WHERE " + ClassroomDetail.columnClassroomId + " = " + classroomId + " " +
                         "AND (" + ClassroomDetail.columnClassroomType + " = '" + ClassroomDetail.ClassroomType.NORMAL.ToString() + "' " +
                         "OR " + ClassroomDetail.columnClassroomType + " = '" + ClassroomDetail.ClassroomType.EXTRA.ToString() + "') " +
                         "ORDER BY " + ClassroomDetail.columnClassroomNo + " ASC";

            return this.classroomDetailDao.processQueryString(sql);
        }

        public List<ClassroomDetail> getAllNormalAndExtraClassroomDetailOrderByClassroomDate(int classroomId)
        {
            string sql = "SELECT * " +
                         "FROM " + ClassroomDetail.tableName + " " +
                         "WHERE " + ClassroomDetail.columnClassroomId + " = " + classroomId + " " +
                         "AND (" + ClassroomDetail.columnClassroomType + " = '" + ClassroomDetail.ClassroomType.NORMAL.ToString() + "' " +
                         "OR " + ClassroomDetail.columnClassroomType + " = '" + ClassroomDetail.ClassroomType.EXTRA.ToString() + "') " +
                         "ORDER BY " + ClassroomDetail.columnClassroomDate + " ASC";

            return this.classroomDetailDao.processQueryString(sql);
        } 
    }
}
