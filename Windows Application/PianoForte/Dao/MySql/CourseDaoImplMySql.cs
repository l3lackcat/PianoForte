using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using MySql.Data.MySqlClient;

using PianoForte.Dao;
using PianoForte.Manager;
using PianoForte.Model;

namespace PianoForte.Dao.MySql
{
    public class CourseDaoImplMySql : CourseDao
    {
        //--------------------------------------------------------------------------------

        public bool insertCourse(Course course)
        {
            string sql = "INSERT INTO " +
                         Course.tableName + " (" +
                         Course.columnCourseId + ", " +
                         Course.columnCourseCategoryId + ", " +
                         Course.columnCourseName + ", " +
                         Course.columnCourseLevel + ", " +
                         Course.columnNumberOfClassroom + ", " +
                         Course.columnCourseFee + ", " +
                         Course.columnClassroomDuration + ", " +
                         Course.columnStudentPerClassroom + ", " +
                         Course.columnStatus + ") " +
                         "VALUES(" +
                         "?" + Course.columnCourseId + ", " +
                         "?" + Course.columnCourseCategoryId + ", " +
                         "?" + Course.columnCourseName + ", " +
                         "?" + Course.columnCourseLevel + ", " +
                         "?" + Course.columnNumberOfClassroom + ", " +
                         "?" + Course.columnCourseFee + ", " +
                         "?" + Course.columnClassroomDuration + ", " +
                         "?" + Course.columnStudentPerClassroom + ", " +
                         "?" + Course.columnStatus + ")";

            return this.processInsertCommand(sql, course);
        }

        public bool updateCourse(Course course)
        {
            string sql = "UPDATE " +
                         Course.tableName + " SET " +
                         Course.columnCourseId_old + " = ?" + Course.columnCourseId_old + ", " +
                         Course.columnCourseCategoryId + " = ?" + Course.columnCourseCategoryId + ", " +
                         Course.columnCourseName + " = ?" + Course.columnCourseName + ", " +
                         Course.columnCourseLevel + " = ?" + Course.columnCourseLevel + ", " +
                         Course.columnNumberOfClassroom + " = ?" + Course.columnNumberOfClassroom + ", " +
                         Course.columnCourseFee + " = ?" + Course.columnCourseFee + ", " +
                         Course.columnClassroomDuration + " = ?" + Course.columnClassroomDuration + ", " +
                         Course.columnStudentPerClassroom + " = ?" + Course.columnStudentPerClassroom + ", " +
                         Course.columnStatus + " = ?" + Course.columnStatus + " " +
                         "WHERE " + Course.columnCourseId + " = ?" + Course.columnCourseId;

            return this.processUpdateCommand(sql, course);
        }

        public bool updateCourseId(int oldCourseId, int newCourseId)
        {
            string sql = "UPDATE " +
                         Course.tableName + " SET " +
                         Course.columnCourseId + " = ?" + Course.columnCourseId + " " +
                         "WHERE " + Course.columnCourseId_old + " = ?" + Course.columnCourseId_old;

            return this.processUpdateId(sql, oldCourseId, newCourseId);
        }

        public bool deleteCourse(int courseId)
        {
            string sql = "DELETE " +
                         "FROM " + Course.tableName + " " +
                         "WHERE " + Course.columnCourseId + " = " + courseId;

            return this.processDeleteCommand(sql);
        }

        public bool deleteCourse(string courseName)
        {
            string sql = "DELETE " +
                         "FROM " + Course.tableName + " " +
                         "WHERE " + Course.columnCourseName + " = '" + courseName + "'";

            return this.processDeleteCommand(sql);
        }     

        //--------------------------------------------------------------------------------

        public Course findCourse(int courseId)
        {
            Course course = null;
            string sql = "SELECT * " +
                         "FROM " + Course.tableName + " " +
                         "WHERE " + Course.columnCourseId + " = " + courseId;

            List<Course> courseList = this.processSelectCommand(sql);
            if (courseList.Count > 0)
            {
                course = courseList[0];
            }

            return course;
        }

        public Course findCourse(int courseId, Course.CourseStatus status)
        {
            Course course = null;
            string sql = "SELECT * " +
                         "FROM " + Course.tableName + " " +
                         "WHERE " + Course.columnCourseId + " = " + courseId + " " +
                         "AND " + Course.columnStatus + " = '" + status.ToString() + "'";

            List<Course> courseList = this.processSelectCommand(sql);
            if (courseList.Count > 0)
            {
                course = courseList[0];
            }

            return course;
        }

        public Course findLastCourse()
        {
            Course course = null;

            string sql = "SELECT * " +
                         "FROM " + Course.tableName + " " +
                         "ORDER BY " + Course.columnCourseId + " DESC " +
                         "LIMIT 1";

            List<Course> courseList = this.processSelectCommand(sql);
            if (courseList.Count > 0)
            {
                course = courseList[0];
            }

            return course;
        }

        //--------------------------------------------------------------------------------

        public Course findCourseByNameAndLevel(string courseName, string courseLevel)
        {
            Course course = null;
            string sql = "SELECT * " +
                         "FROM " + Course.tableName + " " +
                         "WHERE " + Course.columnCourseName + " = '" + courseName + "' " +
                         "AND " + Course.columnCourseLevel + " = '" + courseLevel + "'";

            List<Course> courseList = this.processSelectCommand(sql);
            if (courseList.Count > 0)
            {
                course = courseList[0];
            }

            return course;
        }

        public Course findCourseByNameAndLevel(string courseName, string courseLevel, Course.CourseStatus status)
        {
            Course course = null;
            string sql = "SELECT * " +
                         "FROM " + Course.tableName + " " +
                         "WHERE " + Course.columnCourseName + " = '" + courseName + "' " +
                         "AND " + Course.columnCourseLevel + " = '" + courseLevel + "' " +
                         "AND " + Course.columnStatus + " = '" + status + "'";

            List<Course> courseList = this.processSelectCommand(sql);
            if (courseList.Count > 0)
            {
                course = courseList[0];
            }

            return course;
        }

        //--------------------------------------------------------------------------------

        public List<Course> findAllCourse()
        {
            string sql = "SELECT * " +
                         "FROM " + Course.tableName + " " +
                         "ORDER BY " + Course.columnCourseId + " ASC";

            return this.processSelectCommand(sql);
        }

        public List<Course> findAllCourse(int startIndex, int offset)
        {
            string sql = "SELECT * " +
                         "FROM " + Course.tableName + " " +
                         "WHERE " + Course.columnCourseId + " IN (" +
                         "SELECT * " +
                         "FROM (" +
                         "SELECT " + Course.columnCourseId + " " +
                         "FROM " + Course.tableName + " " +
                         "LIMIT " + startIndex + "," + offset + ") ALIAS)" +
                         "ORDER BY " + Course.columnCourseId + " ASC";

            return this.processSelectCommand(sql);
        }

        public List<Course> findAllCourse(Course.CourseStatus status)
        {
            string sql = "SELECT * " +
                         "FROM " + Course.tableName + " " +
                         "WHERE " + Course.columnStatus + " = '" + status.ToString() + "' " +
                         "ORDER BY " + Course.columnCourseId + " ASC";

            return this.processSelectCommand(sql);
        }

        public List<Course> findAllCourse(Course.CourseStatus status, int startIndex, int offset)
        {
            string sql = "SELECT * " +
                         "FROM " + Course.tableName + " " +
                         "WHERE " + Course.columnCourseId + " IN (" +
                         "SELECT * " +
                         "FROM (" +
                         "SELECT " + Course.columnCourseId + " " +
                         "FROM " + Course.tableName + " " +
                         "WHERE " + Course.columnStatus + " = '" + status.ToString() + "' " +
                         "LIMIT " + startIndex + "," + offset + ") ALIAS)" +
                         "ORDER BY " + Course.columnCourseId + " ASC";

            return this.processSelectCommand(sql);
        }

        //--------------------------------------------------------------------------------

        public List<Course> findAllCourseByCourseCategoryId(int courseCategoryId)
        {
            string sql = "SELECT * " +
                         "FROM " + Course.tableName + " " +
                         "WHERE " + Course.columnCourseCategoryId + " = " + courseCategoryId + " " +
                         "ORDER BY " + Course.columnCourseId + " ASC";

            return this.processSelectCommand(sql);
        }

        public List<Course> findAllCourseByCourseCategoryId(int courseCategoryId, int startIndex, int offset)
        {
            string sql = "SELECT * " +
                         "FROM " + Course.tableName + " " +
                         "WHERE " + Course.columnCourseId + " IN (" +
                         "SELECT * " +
                         "FROM (" +
                         "SELECT " + Course.columnCourseId + " " +
                         "FROM " + Course.tableName + " " +
                         "WHERE " + Course.columnCourseCategoryId + " = " + courseCategoryId + " " +
                         "LIMIT " + startIndex + "," + offset + ") ALIAS)" +
                         "ORDER BY " + Course.columnCourseId + " ASC";

            return this.processSelectCommand(sql);
        }

        public List<Course> findAllCourseByCourseCategoryId(int courseCategoryId, Course.CourseStatus status)
        {
            string sql = "SELECT * " +
                         "FROM " + Course.tableName + " " +
                         "WHERE " + Course.columnCourseCategoryId + " = " + courseCategoryId + " " +
                         "AND " + Course.columnStatus + " = '" + status.ToString() + "' " +
                         "ORDER BY " + Course.columnCourseId + " ASC";

            return this.processSelectCommand(sql);
        }

        public List<Course> findAllCourseByCourseCategoryId(int courseCategoryId, Course.CourseStatus status, int startIndex, int offset)
        {
            string sql = "SELECT * " +
                         "FROM " + Course.tableName + " " +
                         "WHERE " + Course.columnCourseId + " IN (" +
                         "SELECT * " +
                         "FROM (" +
                         "SELECT " + Course.columnCourseId + " " +
                         "FROM " + Course.tableName + " " +
                         "WHERE " + Course.columnCourseCategoryId + " = " + courseCategoryId + " " +
                         "AND " + Course.columnStatus + " = '" + status.ToString() + "' " +
                         "LIMIT " + startIndex + "," + offset + ") ALIAS)" +
                         "ORDER BY " + Course.columnCourseId + " ASC";

            return this.processSelectCommand(sql);
        }

        //--------------------------------------------------------------------------------

        public List<Course> findAllCourseByCourseName(string courseName)
        {
            string sql = "SELECT * " +
                         "FROM " + Course.tableName + " " +
                         "WHERE " + Course.columnCourseName + " LIKE '%" + courseName + "%' " +
                         "ORDER BY " + Course.columnCourseId + " ASC";

            return this.processSelectCommand(sql);
        }

        public List<Course> findAllCourseByCourseName(string courseName, int startIndex, int offset)
        {
            string sql = "SELECT * " +
                         "FROM " + Course.tableName + " " +
                         "WHERE " + Course.columnCourseId + " IN (" +
                         "SELECT * " +
                         "FROM (" +
                         "SELECT " + Course.columnCourseId + " " +
                         "FROM " + Course.tableName + " " +
                         "WHERE " + Course.columnCourseName + " LIKE '%" + courseName + "%' " +
                         "LIMIT " + startIndex + "," + offset + ") ALIAS)" +
                         "ORDER BY " + Course.columnCourseId + " ASC";

            return this.processSelectCommand(sql);
        }

        public List<Course> findAllCourseByCourseName(string courseName, Course.CourseStatus status)
        {
            string sql = "SELECT * " +
                         "FROM " + Course.tableName + " " +
                         "WHERE " + Course.columnCourseName + " LIKE '%" + courseName + "%' " +
                         "AND " + Course.columnStatus + " = '" + status.ToString() + "' " +
                         "ORDER BY " + Course.columnCourseId + " ASC";

            return this.processSelectCommand(sql);
        }

        public List<Course> findAllCourseByCourseName(string courseName, Course.CourseStatus status, int startIndex, int offset)
        {
            string sql = "SELECT * " +
                         "FROM " + Course.tableName + " " +
                         "WHERE " + Course.columnCourseId + " IN (" +
                         "SELECT * " +
                         "FROM (" +
                         "SELECT " + Course.columnCourseId + " " +
                         "FROM " + Course.tableName + " " +
                         "WHERE " + Course.columnCourseName + " LIKE '%" + courseName + "%' " +
                         "AND " + Course.columnStatus + " = '" + status.ToString() + "' " +
                         "LIMIT " + startIndex + "," + offset + ") ALIAS)" +
                         "ORDER BY " + Course.columnCourseId + " ASC";

            return this.processSelectCommand(sql);
        }

        //--------------------------------------------------------------------------------

        public List<Course> findAllCourseByCourseCategoryIdAndCourseName(int courseCategoryId, string courseName)
        {
            string sql = "SELECT * " +
                         "FROM " + Course.tableName + " " +
                         "WHERE " + Course.columnCourseCategoryId + " = " + courseCategoryId + " " +
                         "AND " + Course.columnCourseName + " LIKE '%" + courseName + "%' " +
                         "ORDER BY " + Course.columnCourseId + " ASC";

            return this.processSelectCommand(sql);
        }

        public List<Course> findAllCourseByCourseCategoryIdAndCourseName(int courseCategoryId, string courseName, int startIndex, int offset)
        {
            string sql = "SELECT * " +
                         "FROM " + Course.tableName + " " +
                         "WHERE " + Course.columnCourseId + " IN (" +
                         "SELECT * " +
                         "FROM (" +
                         "SELECT " + Course.columnCourseId + " " +
                         "FROM " + Course.tableName + " " +
                         "WHERE " + Course.columnCourseCategoryId + " = " + courseCategoryId + " " +
                         "AND " + Course.columnCourseName + " LIKE '%" + courseName + "%' " +
                         "LIMIT " + startIndex + "," + offset + ") ALIAS)" +
                         "ORDER BY " + Course.columnCourseId + " ASC";

            return this.processSelectCommand(sql);
        }

        public List<Course> findAllCourseByCourseCategoryIdAndCourseName(int courseCategoryId, string courseName, Course.CourseStatus status)
        {
            string sql = "SELECT * " +
                         "FROM " + Course.tableName + " " +
                         "WHERE " + Course.columnCourseCategoryId + " = " + courseCategoryId + " " +
                         "AND " + Course.columnCourseName + " LIKE '%" + courseName + "%' " +
                         "AND " + Course.columnStatus + " = '" + status.ToString() + "' " +
                         "ORDER BY " + Course.columnCourseId + " ASC";

            return this.processSelectCommand(sql);
        }

        public List<Course> findAllCourseByCourseCategoryIdAndCourseName(int courseCategoryId, string courseName, Course.CourseStatus status, int startIndex, int offset)
        {
            string sql = "SELECT * " +
                         "FROM " + Course.tableName + " " +
                         "WHERE " + Course.columnCourseId + " IN (" +
                         "SELECT * " +
                         "FROM (" +
                         "SELECT " + Course.columnCourseId + " " +
                         "FROM " + Course.tableName + " " +
                         "WHERE " + Course.columnCourseCategoryId + " = " + courseCategoryId + " " +
                         "AND " + Course.columnCourseName + " LIKE '%" + courseName + "%' " +
                         "AND " + Course.columnStatus + " = '" + status.ToString() + "' " +
                         "LIMIT " + startIndex + "," + offset + ") ALIAS)" +
                         "ORDER BY " + Course.columnCourseId + " ASC";

            return this.processSelectCommand(sql);
        }

        //--------------------------------------------------------------------------------

        public List<Course> findAllCourseByCourseNameWithoutWildcard(string courseName)
        {
            string sql = "SELECT * " +
                         "FROM " + Course.tableName + " " +
                         "WHERE " + Course.columnCourseName + " LIKE '" + courseName + "' " +
                         "ORDER BY " + Course.columnCourseId + " ASC";

            return this.processSelectCommand(sql);
        }

        //--------------------------------------------------------------------------------

        private bool processInsertCommand(string sql, Course course) 
        {
            bool returnFlag = false;            
            
            if (course != null)
            {
                MySqlConnection conn = null;
                try
                {
                    conn = new MySqlConnection(DatabaseManager.getMySqlConnectionString());
                    if (conn != null)
                    {
                        conn.Open();

                        MySqlCommand command = new MySqlCommand(sql, conn);
                        command.Parameters.AddWithValue(Course.columnCourseId, course.Id);
                        command.Parameters.AddWithValue(Course.columnCourseCategoryId, course.CourseCategoryId);
                        command.Parameters.AddWithValue(Course.columnCourseName, course.Name);
                        command.Parameters.AddWithValue(Course.columnCourseLevel, course.Level);
                        command.Parameters.AddWithValue(Course.columnNumberOfClassroom, course.NumberOfClassroom);
                        command.Parameters.AddWithValue(Course.columnCourseFee, course.Price);
                        command.Parameters.AddWithValue(Course.columnClassroomDuration, course.ClassroomDuration);
                        command.Parameters.AddWithValue(Course.columnStudentPerClassroom, course.StudentPerClassroom);
                        command.Parameters.AddWithValue(Course.columnStatus, course.Status);

                        int affectedRow = command.ExecuteNonQuery();
                        if (affectedRow != -1)
                        {
                            returnFlag = true;
                        }
                    }
                }
                catch (System.InvalidOperationException e)
                {
                    Console.Write(e.Message);
                }
                catch (MySqlException e)
                {
                    Console.Write(e.Message);
                }
                catch (System.SystemException e)
                {
                    Console.Write(e.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
            
            return returnFlag;
        }

        private bool processUpdateId(string sql, int oldCourseId, int newCourseId)
        {
            bool returnFlag = false;

            MySqlConnection conn = null;
            try
            {
                conn = new MySqlConnection(DatabaseManager.getMySqlConnectionString());
                if (conn != null)
                {
                    conn.Open();

                    MySqlCommand command = new MySqlCommand(sql, conn);
                    command.Parameters.AddWithValue(Course.columnCourseId, newCourseId);
                    command.Parameters.AddWithValue(Course.columnCourseId_old, oldCourseId);

                    int affectedRow = command.ExecuteNonQuery();
                    if (affectedRow != -1)
                    {
                        returnFlag = true;
                    }
                }
            }
            catch (System.InvalidOperationException e)
            {
                Console.Write(e.Message);
            }
            catch (MySqlException e)
            {
                Console.Write(e.Message);
            }
            catch (System.SystemException e)
            {
                Console.Write(e.Message);
            }
            finally
            {
                conn.Close();
            }

            return returnFlag;
        }

        private bool processUpdateCommand(string sql, Course course) 
        {
            bool returnFlag = false;            
            
            if (course != null)
            {
                MySqlConnection conn = null;
                try
                {
                    conn = new MySqlConnection(DatabaseManager.getMySqlConnectionString());
                    if (conn != null)
                    {
                        conn.Open();

                        MySqlCommand command = new MySqlCommand(sql, conn);
                        command.Parameters.AddWithValue(Course.columnCourseId_old, course.CourseId_old);
                        command.Parameters.AddWithValue(Course.columnCourseCategoryId, course.CourseCategoryId);
                        command.Parameters.AddWithValue(Course.columnCourseName, course.Name);
                        command.Parameters.AddWithValue(Course.columnCourseLevel, course.Level);
                        command.Parameters.AddWithValue(Course.columnNumberOfClassroom, course.NumberOfClassroom);
                        command.Parameters.AddWithValue(Course.columnCourseFee, course.Price);
                        command.Parameters.AddWithValue(Course.columnClassroomDuration, course.ClassroomDuration);
                        command.Parameters.AddWithValue(Course.columnStudentPerClassroom, course.StudentPerClassroom);
                        command.Parameters.AddWithValue(Course.columnStatus, course.Status);
                        command.Parameters.AddWithValue(Course.columnCourseId, course.Id);

                        int affectedRow = command.ExecuteNonQuery();
                        if (affectedRow != -1)
                        {
                            returnFlag = true;
                        }
                    }
                }
                catch (System.InvalidOperationException e)
                {
                    Console.Write(e.Message);
                }
                catch (MySqlException e)
                {
                    Console.Write(e.Message);
                }
                catch (System.SystemException e)
                {
                    Console.Write(e.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
            
            return returnFlag;
        }

        private bool processDeleteCommand(string sql)
        {
            bool returnFlag = false;
            
            MySqlConnection conn = null;
            try
            {
                conn = new MySqlConnection(DatabaseManager.getMySqlConnectionString());
                if (conn != null)
                {
                    conn.Open();
                    MySqlCommand command = new MySqlCommand(sql, conn);

                    int affectedRow = command.ExecuteNonQuery();
                    if (affectedRow != -1)
                    {
                        returnFlag = true;
                    }
                }
            }
            catch (System.InvalidOperationException e)
            {
                Console.Write(e.Message);
            }
            catch (MySqlException e)
            {
                Console.Write(e.Message);
            }
            catch (System.SystemException e)
            {
                Console.Write(e.Message);
            }
            finally
            {
                conn.Close();
            }
            
            return returnFlag;
        }

        private List<Course> processSelectCommand(string sql)
        {
            List<Course> courseList = new List<Course>();
            
            MySqlConnection conn = null;
            try
            {
                conn = new MySqlConnection(DatabaseManager.getMySqlConnectionString());
                if (conn != null)
                {
                    conn.Open();
                    MySqlCommand command = new MySqlCommand(sql, conn);
                    MySqlDataAdapter dataAdapter = new MySqlDataAdapter(command);

                    DataSet data = new DataSet();
                    dataAdapter.Fill(data, Course.tableName);

                    for (int i = 0; i < data.Tables[Course.tableName].Rows.Count; i++)
                    {
                        courseList.Add(generateCourse(data, i));
                    }
                }
            }
            catch (System.InvalidOperationException e)
            {
                Console.Write(e.Message);
            }
            catch (MySqlException e)
            {
                Console.Write(e.Message);
            }
            catch (System.SystemException e)
            {
                Console.Write(e.Message);
            }
            finally
            {
                conn.Close();
            }
            
            return courseList;
        }

        private Course generateCourse(DataSet data, int index)
        {
            Course course = new Course();
            course.Id = Convert.ToInt32(data.Tables[Course.tableName].Rows[index][Course.columnCourseId].ToString());
            course.CourseId_old = Convert.ToInt32(data.Tables[Course.tableName].Rows[index][Course.columnCourseId_old].ToString());
            course.Type = Product.ProductType.COURSE.ToString();
            course.CourseCategoryId = Convert.ToInt32(data.Tables[Course.tableName].Rows[index][Course.columnCourseCategoryId].ToString());
            course.Name = data.Tables[Course.tableName].Rows[index][Course.columnCourseName].ToString();
            course.NumberOfClassroom = Convert.ToInt32(data.Tables[Course.tableName].Rows[index][Course.columnNumberOfClassroom].ToString());
            course.Level = data.Tables[Course.tableName].Rows[index][Course.columnCourseLevel].ToString();
            course.Price = Convert.ToDouble(data.Tables[Course.tableName].Rows[index][Course.columnCourseFee].ToString());
            course.ClassroomDuration = Convert.ToInt32(data.Tables[Course.tableName].Rows[index][Course.columnClassroomDuration].ToString());
            course.StudentPerClassroom = Convert.ToInt32(data.Tables[Course.tableName].Rows[index][Course.columnStudentPerClassroom].ToString());
            course.Status = data.Tables[Course.tableName].Rows[index][Course.columnStatus].ToString();

            return course;
        }

        //--------------------------------------------------------------------------------

        //Temporary
        public bool processInsertStringForMathching(string sql, int oldCourseId, int newCourseId)
        {
            bool returnFlag = false;

            MySqlConnection conn = null;
            try
            {
                conn = new MySqlConnection(DatabaseManager.getMySqlConnectionString());
                if (conn != null)
                {
                    conn.Open();

                    MySqlCommand command = new MySqlCommand(sql, conn);
                    command.Parameters.AddWithValue(Course.columnOldCourseId, oldCourseId);
                    command.Parameters.AddWithValue(Course.columnNewCourseId, newCourseId);

                    int affectedRow = command.ExecuteNonQuery();
                    if (affectedRow != -1)
                    {
                        returnFlag = true;
                    }
                }
            }
            catch (System.InvalidOperationException e)
            {
                Console.Write(e.Message);
            }
            catch (MySqlException e)
            {
                Console.Write(e.Message);
            }
            catch (System.SystemException e)
            {
                Console.Write(e.Message);
            }
            finally
            {
                conn.Close();
            }

            return returnFlag;
        }

        public int processQueryStringForMatching(string sql)
        {
            int newCourseId = 0;

            MySqlConnection conn = null;
            try
            {
                conn = new MySqlConnection(DatabaseManager.getMySqlConnectionString());
                if (conn != null)
                {
                    conn.Open();
                    MySqlCommand command = new MySqlCommand(sql, conn);
                    MySqlDataAdapter dataAdapter = new MySqlDataAdapter(command);

                    DataSet data = new DataSet();
                    dataAdapter.Fill(data, Course.matchingTableName);

                    for (int i = 0; i < data.Tables[Course.matchingTableName].Rows.Count; i++)
                    {
                        newCourseId = Convert.ToInt32(data.Tables[Course.matchingTableName].Rows[i][Course.columnNewCourseId].ToString());
                    }
                }
            }
            catch (System.InvalidOperationException e)
            {
                Console.Write(e.Message);
            }
            catch (MySqlException e)
            {
                Console.Write(e.Message);
            }
            catch (System.SystemException e)
            {
                Console.Write(e.Message);
            }
            finally
            {
                conn.Close();
            }

            return newCourseId;
        }
    }
}
