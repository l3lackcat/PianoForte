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
    public class TeachingCourseDaoImplMySql : TeachingCourseDao
    {
        public bool insertTeachingCourse(int teacherId, int courseId)
        {
            string sql = "INSERT INTO " +
                         TeachingCourse.tableName + " (" +
                         TeachingCourse.columnTeacherId + ", " +
                         TeachingCourse.columnCourseId + ") " +
                         "VALUES(" +
                         "?" + TeachingCourse.columnTeacherId + ", " +
                         "?" + TeachingCourse.columnCourseId + ")";

            return this.processInsertCommand(sql, teacherId, courseId);
        }

        public bool updateTeachingCourse(int teacherId, int courseId)
        {
            string sql = "UPDATE " +
                         TeachingCourse.tableName + " SET " +
                         TeachingCourse.columnCourseId + " = ?" + TeachingCourse.columnCourseId + " " +
                         "WHERE " + TeachingCourse.columnTeacherId + " = ?" + TeachingCourse.columnTeacherId;

            return this.processUpdateCommand(sql, teacherId, courseId);
        }

        public bool deleteTeachingCourse(int teacherId, int courseId)
        {
            string sql = "DELETE " +
                         "FROM " + TeachingCourse.tableName + " " +
                         "WHERE " + TeachingCourse.columnTeacherId + " = " + teacherId + " " +
                         "AND " + TeachingCourse.columnCourseId + " = " + courseId;

            return this.processDeleteCommand(sql);
        }

        public bool deleteTeachingCourseByTeacherId(int teacherId)
        {
            string sql = "DELETE " +
                         "FROM " + TeachingCourse.tableName + " " +
                         "WHERE " + TeachingCourse.columnTeacherId + " = " + teacherId;

            return this.processDeleteCommand(sql);
        }

        public bool deleteTeachingCourseByCourseId(int courseId)
        {
            string sql = "DELETE " +
                         "FROM " + TeachingCourse.tableName + " " +
                         "WHERE " + TeachingCourse.columnCourseId + " = '" + courseId + "'";

            return this.processDeleteCommand(sql);
        }

        public List<int> findCourseIdByTeacherId(int teacherId)
        {
            string sql = "SELECT * " +
                         "FROM " + TeachingCourse.tableName + " " +
                         "WHERE " + TeachingCourse.columnTeacherId + " = " + teacherId;

            return this.processSelectCommandByTeacherId(sql);
        }

        public List<int> findTeacherIdByCourseId(int courseId)
        {
            string sql = "SELECT * " +
                         "FROM " + TeachingCourse.tableName + " " +
                         "WHERE " + TeachingCourse.columnCourseId + " = '" + courseId + "'";

            return this.processSelectCommandByCourseId(sql);
        }

        private bool processInsertCommand(string sql, int teacherId, int courseId)
        {
            bool returnFlag = false;
            
            if ((teacherId > 0) && (courseId > 0))
            {
                MySqlConnection conn = null;
                try
                {
                    conn = new MySqlConnection(DatabaseManager.getMySqlConnectionString());
                    if (conn != null)
                    {
                        conn.Open();

                        MySqlCommand command = new MySqlCommand(sql, conn);
                        command.Parameters.AddWithValue(TeachingCourse.columnTeacherId, teacherId);
                        command.Parameters.AddWithValue(TeachingCourse.columnCourseId, courseId);

                        int affectedRow = command.ExecuteNonQuery();
                        if (affectedRow != -1)
                        {
                            returnFlag = true;
                        }
                    }
                }
                catch (System.InvalidOperationException e)
                {
                    LogManager.writeLog(e.Message);
                }
                catch (MySqlException e)
                {
                    LogManager.writeLog(e.Message);
                }
                catch (System.SystemException e)
                {
                    LogManager.writeLog(e.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
            
            return returnFlag;
        }

        private bool processUpdateCommand(string sql, int teacherId, int courseId)
        {
            bool returnFlag = false;
            
            if ((teacherId > 0) && (courseId > 0))
            {
                MySqlConnection conn = null;
                try
                {
                    conn = new MySqlConnection(DatabaseManager.getMySqlConnectionString());
                    if (conn != null)
                    {
                        conn.Open();

                        MySqlCommand command = new MySqlCommand(sql, conn);
                        command.Parameters.AddWithValue(TeachingCourse.columnTeacherId, teacherId);
                        command.Parameters.AddWithValue(TeachingCourse.columnCourseId, courseId);                                               

                        int affectedRow = command.ExecuteNonQuery();
                        if (affectedRow != -1)
                        {
                            returnFlag = true;
                        }
                    }
                }
                catch (System.InvalidOperationException e)
                {
                    LogManager.writeLog(e.Message);
                }
                catch (MySqlException e)
                {
                    LogManager.writeLog(e.Message);
                }
                catch (System.SystemException e)
                {
                    LogManager.writeLog(e.Message);
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
                LogManager.writeLog(e.Message);
            }
            catch (MySqlException e)
            {
                LogManager.writeLog(e.Message);
            }
            catch (System.SystemException e)
            {
                LogManager.writeLog(e.Message);
            }
            finally
            {
                conn.Close();
            }
            
            return returnFlag;
        }

        private List<int> processSelectCommandByCourseId(string sql)
        {
            List<int> teacherIdList = new List<int>();
            
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
                    dataAdapter.Fill(data, TeachingCourse.tableName);

                    for (int i = 0; i < data.Tables[TeachingCourse.tableName].Rows.Count; i++)
                    {
                        teacherIdList.Add(generateTeacherId(data, i));
                    }
                }
            }
            catch (System.InvalidOperationException e)
            {
                LogManager.writeLog(e.Message);
            }
            catch (MySqlException e)
            {
                LogManager.writeLog(e.Message);
            }
            catch (System.SystemException e)
            {
                LogManager.writeLog(e.Message);
            }
            finally
            {
                conn.Close();
            }
            
            return teacherIdList;
        }

        private List<int> processSelectCommandByTeacherId(string sql)
        {
            List<int> courseIdList = new List<int>();
            
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
                    dataAdapter.Fill(data, TeachingCourse.tableName);

                    for (int i = 0; i < data.Tables[TeachingCourse.tableName].Rows.Count; i++)
                    {
                        courseIdList.Add(generateCourseId(data, i));
                    }
                }
            }
            catch (System.InvalidOperationException e)
            {
                LogManager.writeLog(e.Message);
            }
            catch (MySqlException e)
            {
                LogManager.writeLog(e.Message);
            }
            catch (System.SystemException e)
            {
                LogManager.writeLog(e.Message);
            }
            finally
            {
                conn.Close();
            }
            
            return courseIdList;
        }

        private int generateCourseId(DataSet data, int index)
        {
            return Convert.ToInt32(data.Tables[TeachingCourse.tableName].Rows[index][TeachingCourse.columnCourseId]);
        }

        private int generateTeacherId(DataSet data, int index)
        {
            return Convert.ToInt32(data.Tables[TeachingCourse.tableName].Rows[index][TeachingCourse.columnTeacherId].ToString());
        }

        //Temporary
        private List<string> processSelectCommandByCourseName(string sql)
        {
            List<string> courseNameList = new List<string>();

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
                    dataAdapter.Fill(data, "teaching_course_old");

                    for (int i = 0; i < data.Tables["teaching_course_old"].Rows.Count; i++)
                    {
                        courseNameList.Add(generateCourseName(data, i));
                    }
                }
            }
            catch (System.InvalidOperationException e)
            {
                LogManager.writeLog(e.Message);
            }
            catch (MySqlException e)
            {
                LogManager.writeLog(e.Message);
            }
            catch (System.SystemException e)
            {
                LogManager.writeLog(e.Message);
            }
            finally
            {
                conn.Close();
            }

            return courseNameList;
        }

        private string generateCourseName(DataSet data, int index)
        {
            return data.Tables["teaching_course_old"].Rows[index]["courseName"].ToString();
        }
    }
}
