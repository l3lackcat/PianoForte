using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;

using MySql.Data.MySqlClient;

using PianoForte.Enum;
using PianoForte.Models;
using PianoForte.Resourses.DatabaseStructure.MySqlTable;

namespace PianoForte.Dao
{
    public class CourseDaoImplMySql : CourseDao
    {
        private bool insert(string databaseName, Course course, string sql)
        {
            bool returnFlag = false;

            if (course != null)
            {
                MySqlConnection conn = null;
                try
                {
                    string connectionString = ConfigurationManager.ConnectionStrings[databaseName].ConnectionString;

                    conn = new MySqlConnection(connectionString);
                    if (conn != null)
                    {
                        conn.Open();

                        MySqlCommand command = new MySqlCommand(sql, conn);
                        command.Parameters.AddWithValue(Courses.ColumnCourseCategoryId, course.CourseCategoryId);
                        command.Parameters.AddWithValue(Courses.ColumnCourseName, course.Name);
                        command.Parameters.AddWithValue(Courses.ColumnCourseLevel, course.Level);
                        command.Parameters.AddWithValue(Courses.ColumnCourseFee, course.UnitPrice);
                        command.Parameters.AddWithValue(Courses.ColumnNumberOfTimes, course.NumberOfTimes);
                        command.Parameters.AddWithValue(Courses.ColumnClassroomDuration, course.ClassroomDuration);
                        command.Parameters.AddWithValue(Courses.ColumnStudentPerClassroom, course.StudentPerClassroom);
                        command.Parameters.AddWithValue(Courses.ColumnCourseStatus, (int)course.Status);

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

        private bool update(string databaseName, Course course, string sql)
        {
            bool returnFlag = false;

            if (course != null)
            {
                MySqlConnection conn = null;
                try
                {
                    string connectionString = ConfigurationManager.ConnectionStrings[databaseName].ConnectionString;

                    conn = new MySqlConnection(connectionString);
                    if (conn != null)
                    {
                        conn.Open();

                        MySqlCommand command = new MySqlCommand(sql, conn);
                        command.Parameters.AddWithValue(Courses.ColumnCourseCategoryId, course.CourseCategoryId);
                        command.Parameters.AddWithValue(Courses.ColumnCourseName, course.Name);
                        command.Parameters.AddWithValue(Courses.ColumnCourseLevel, course.Level);
                        command.Parameters.AddWithValue(Courses.ColumnCourseFee, course.UnitPrice);
                        command.Parameters.AddWithValue(Courses.ColumnNumberOfTimes, course.NumberOfTimes);
                        command.Parameters.AddWithValue(Courses.ColumnClassroomDuration, course.ClassroomDuration);
                        command.Parameters.AddWithValue(Courses.ColumnStudentPerClassroom, course.StudentPerClassroom);
                        command.Parameters.AddWithValue(Courses.ColumnCourseStatus, (int)course.Status);
                        command.Parameters.AddWithValue(Courses.ColumnCourseId, course.Id);

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

        private Course selectCourse(string databaseName, string sql)
        {
            Course course = null;

            MySqlConnection conn = null;
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings[databaseName].ConnectionString;

                conn = new MySqlConnection(connectionString);
                if (conn != null)
                {
                    conn.Open();
                    MySqlCommand command = new MySqlCommand(sql, conn);
                    MySqlDataAdapter dataAdapter = new MySqlDataAdapter(command);

                    DataSet data = new DataSet();
                    dataAdapter.Fill(data, Courses.TableName);

                    for (int i = 0; i < data.Tables[Courses.TableName].Rows.Count; i++)
                    {
                        course = new Course();
                        course.Id = Convert.ToInt32(data.Tables[Courses.TableName].Rows[i][Courses.ColumnCourseId].ToString());
                        course.CourseCategoryId = Convert.ToInt32(data.Tables[Courses.TableName].Rows[i][Courses.ColumnCourseCategoryId].ToString());
                        course.Name = data.Tables[Courses.TableName].Rows[i][Courses.ColumnCourseName].ToString();
                        course.Level = data.Tables[Courses.TableName].Rows[i][Courses.ColumnCourseLevel].ToString();
                        course.UnitPrice = Convert.ToDouble(data.Tables[Courses.TableName].Rows[i][Courses.ColumnCourseFee].ToString());
                        course.NumberOfTimes = Convert.ToInt32(data.Tables[Courses.TableName].Rows[i][Courses.ColumnNumberOfTimes].ToString());
                        course.ClassroomDuration = Convert.ToInt32(data.Tables[Courses.TableName].Rows[i][Courses.ColumnClassroomDuration].ToString());
                        course.StudentPerClassroom = Convert.ToInt32(data.Tables[Courses.TableName].Rows[i][Courses.ColumnStudentPerClassroom].ToString());
                        course.Status = EnumConverter.ToStatus(data.Tables[Courses.TableName].Rows[i][Courses.ColumnCourseStatus].ToString());
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

            return course;
        }

        private List<Course> selectCourseList(string databaseName, string sql)
        {
            List<Course> courseList = new List<Course>();

            MySqlConnection conn = null;
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings[databaseName].ConnectionString;

                conn = new MySqlConnection(connectionString);
                if (conn != null)
                {
                    conn.Open();
                    MySqlCommand command = new MySqlCommand(sql, conn);
                    MySqlDataAdapter dataAdapter = new MySqlDataAdapter(command);

                    DataSet data = new DataSet();
                    dataAdapter.Fill(data, Courses.TableName);

                    for (int i = 0; i < data.Tables[Courses.TableName].Rows.Count; i++)
                    {
                        Course course = new Course();
                        course.Id = Convert.ToInt32(data.Tables[Courses.TableName].Rows[i][Courses.ColumnCourseId].ToString());
                        course.CourseCategoryId = Convert.ToInt32(data.Tables[Courses.TableName].Rows[i][Courses.ColumnCourseCategoryId].ToString());
                        course.Name = data.Tables[Courses.TableName].Rows[i][Courses.ColumnCourseName].ToString();
                        course.Level = data.Tables[Courses.TableName].Rows[i][Courses.ColumnCourseLevel].ToString();
                        course.UnitPrice = Convert.ToDouble(data.Tables[Courses.TableName].Rows[i][Courses.ColumnCourseFee].ToString());
                        course.NumberOfTimes = Convert.ToInt32(data.Tables[Courses.TableName].Rows[i][Courses.ColumnNumberOfTimes].ToString());
                        course.ClassroomDuration = Convert.ToInt32(data.Tables[Courses.TableName].Rows[i][Courses.ColumnClassroomDuration].ToString());
                        course.StudentPerClassroom = Convert.ToInt32(data.Tables[Courses.TableName].Rows[i][Courses.ColumnStudentPerClassroom].ToString());
                        course.Status = EnumConverter.ToStatus(data.Tables[Courses.TableName].Rows[i][Courses.ColumnCourseStatus].ToString());

                        courseList.Add(course);
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

        private List<string> selectCourseNameList(string databaseName, string sql)
        {
            List<string> courseNameList = new List<string>();

            MySqlConnection conn = null;
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings[databaseName].ConnectionString;

                conn = new MySqlConnection(connectionString);
                if (conn != null)
                {
                    conn.Open();
                    MySqlCommand command = new MySqlCommand(sql, conn);
                    MySqlDataAdapter dataAdapter = new MySqlDataAdapter(command);

                    DataSet data = new DataSet();
                    dataAdapter.Fill(data, Courses.TableName);

                    for (int i = 0; i < data.Tables[Courses.TableName].Rows.Count; i++)
                    {
                        string courseName = data.Tables[Courses.TableName].Rows[i][Courses.ColumnCourseName].ToString();
                        courseNameList.Add(courseName);
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

            return courseNameList;
        }

        public bool insertCourse(string databaseName, Course course)
        {
            string sql = "INSERT INTO " +
                         Courses.TableName + " (" +
                         Courses.ColumnCourseCategoryId + ", " +
                         Courses.ColumnCourseName + ", " +
                         Courses.ColumnCourseLevel + ", " +
                         Courses.ColumnCourseFee + ", " +
                         Courses.ColumnNumberOfTimes + ", " +
                         Courses.ColumnClassroomDuration + ", " +
                         Courses.ColumnStudentPerClassroom + ", " +
                         Courses.ColumnCourseStatus + ") " +
                         "VALUES(" +
                         "?" + Courses.ColumnCourseCategoryId + ", " +
                         "?" + Courses.ColumnCourseName + ", " +
                         "?" + Courses.ColumnCourseLevel + ", " +
                         "?" + Courses.ColumnCourseFee + ", " +
                         "?" + Courses.ColumnNumberOfTimes + ", " +
                         "?" + Courses.ColumnClassroomDuration + ", " +
                         "?" + Courses.ColumnStudentPerClassroom + ", " +
                         "?" + Courses.ColumnCourseStatus + ")";

            return this.insert(databaseName, course, sql);
        }

        public bool updateCourse(string databaseName, Course course)
        {
            string sql = "UPDATE " +
                         Courses.TableName + " SET " +
                         Courses.ColumnCourseCategoryId + " = ?" + Courses.ColumnCourseCategoryId + ", " +
                         Courses.ColumnCourseName + " = ?" + Courses.ColumnCourseName + ", " +
                         Courses.ColumnCourseLevel + " = ?" + Courses.ColumnCourseLevel + ", " +
                         Courses.ColumnCourseFee + " = ?" + Courses.ColumnCourseFee + ", " +
                         Courses.ColumnNumberOfTimes + " = ?" + Courses.ColumnNumberOfTimes + ", " +
                         Courses.ColumnClassroomDuration + " = ?" + Courses.ColumnClassroomDuration + ", " +
                         Courses.ColumnStudentPerClassroom + " = ?" + Courses.ColumnStudentPerClassroom + ", " +
                         Courses.ColumnCourseStatus + " = ?" + Courses.ColumnCourseStatus + " " +
                         "WHERE " + Courses.ColumnCourseId + " = ?" + Courses.ColumnCourseId;

            return this.update(databaseName, course, sql);
        }

        public Course getCourse(string databaseName, int courseId)
        {
            string sql = "SELECT * " +
                         "FROM " + Courses.TableName + " " +
                         "WHERE " + Courses.ColumnCourseId + " = " + courseId;

            return this.selectCourse(databaseName, sql);
        }

        public List<Course> getCourseList(string databaseName)
        {
            string sql = "SELECT * " +
                         "FROM " + Courses.TableName + " " +
                         "ORDER BY " + Courses.ColumnCourseId + " ASC";

            return this.selectCourseList(databaseName, sql);
        }

        public List<Course> getCourseList(string databaseName, string keyword)
        {
            string sql = "SELECT * " +
                         "FROM " + Courses.TableName + " " +
                         "WHERE " + Courses.ColumnCourseName + " LIKE '%" + keyword + "%' " +
                         "ORDER BY " + Courses.ColumnCourseId + " ASC";

            return this.selectCourseList(databaseName, sql);
        }

        public List<Course> getCourseListByName(string databaseName, string courseName)
        {
            string sql = "SELECT * " +
                         "FROM " + Courses.TableName + " " +
                         "WHERE " + Courses.ColumnCourseName + " = '" + courseName + "' " +
                         "ORDER BY " + Courses.ColumnCourseId + " ASC";

            return this.selectCourseList(databaseName, sql);
        }

        public List<Course> getCourseListByName(string databaseName, string courseName, Status status)
        {
            string sql = "SELECT * " +
                         "FROM " + Courses.TableName + " " +
                         "WHERE " + Courses.ColumnCourseName + " = '" + courseName + "' " +
                         "AND " + Courses.ColumnCourseStatus + " = " + (int)status + " " +
                         "ORDER BY " + Courses.ColumnCourseId + " ASC";

            return this.selectCourseList(databaseName, sql);
        }

        public List<string> getCourseNameList(string databaseName)
        {
            string sql = "SELECT DISTINCT " + Courses.ColumnCourseName + " " +
                         "FROM " + Courses.TableName + " " +
                         "ORDER BY " + Courses.ColumnCourseId + " ASC";

            return this.selectCourseNameList(databaseName, sql);
        }

        public List<string> getCourseNameList(string databaseName, Status status)
        {
            string sql = "SELECT DISTINCT " + Courses.ColumnCourseName + " " +
                         "FROM " + Courses.TableName + " " +
                         "WHERE " + Courses.ColumnCourseStatus + " = " + (int)status + " " +
                         "ORDER BY " + Courses.ColumnCourseId + " ASC";

            return this.selectCourseNameList(databaseName, sql);
        }
    }
}