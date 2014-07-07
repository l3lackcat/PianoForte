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
    public class CourseCategoryDaoImplMySql : CourseCategoryDao
    {
        //--------------------------------------------------------------------------------

        public bool insertCourseCategory(CourseCategory courseCategory)
        {
            string sql = "INSERT INTO " +
                         CourseCategory.tableName + " (" +
                         CourseCategory.columnCourseCategoryName + ", " +
                         CourseCategory.columnStatus + ") " +
                         "VALUES(" +
                         "?" + CourseCategory.columnCourseCategoryName + ", " +
                         "?" + CourseCategory.columnStatus + ")";

            return this.processInsertCommand(sql, courseCategory);
        }

        public bool updateCourseCategory(CourseCategory courseCategory)
        {
            string sql = "UPDATE " +
                         CourseCategory.tableName + " SET " +
                         CourseCategory.columnCourseCategoryName + " = ?" + CourseCategory.columnCourseCategoryName + ", " +
                         CourseCategory.columnStatus + " = ?" + CourseCategory.columnStatus + " " +
                         "WHERE " + CourseCategory.columnCourseCategoryId + " = ?" + CourseCategory.columnCourseCategoryId;

            return this.processUpdateCommand(sql, courseCategory);
        }

        public bool deleteCourseCategory(int courseCategoryId)
        {
            string sql = "DELETE " +
                         "FROM " + CourseCategory.tableName + " " +
                         "WHERE " + CourseCategory.columnCourseCategoryId + " = " + courseCategoryId;

            return this.processDeleteCommand(sql);
        }

        //--------------------------------------------------------------------------------        

        public CourseCategory findCourseCategory(int courseCategoryId)
        {
            CourseCategory courseCategory = null;

            string sql = "SELECT * " +
                         "FROM " + CourseCategory.tableName + " " +
                         "WHERE " + CourseCategory.columnCourseCategoryId + " = " + courseCategoryId;

            List<CourseCategory> courseCategoryList = this.processSelectCommand(sql);
            if (courseCategoryList.Count > 0)
            {
                courseCategory = courseCategoryList[0];
            }

            return courseCategory;
        }

        public CourseCategory findCourseCategory(int courseCategoryId, CourseCategory.CourseCategoryStatus status)
        {
            CourseCategory courseCategory = null;

            string sql = "SELECT * " +
                         "FROM " + CourseCategory.tableName + " " +
                         "WHERE " + CourseCategory.columnCourseCategoryId + " = " + courseCategoryId + " " +
                         "AND " + CourseCategory.columnStatus + " = '" + status.ToString() + "'";

            List<CourseCategory> courseCategoryList = this.processSelectCommand(sql);
            if (courseCategoryList.Count > 0)
            {
                courseCategory = courseCategoryList[0];
            }

            return courseCategory;
        }

        public CourseCategory findCourseCategory(string courseCategoryName)
        {
            CourseCategory courseCategory = null;

            string sql = "SELECT * " +
                         "FROM " + CourseCategory.tableName + " " +
                         "WHERE " + CourseCategory.columnCourseCategoryName + " = '" + courseCategoryName + "'";

            List<CourseCategory> courseCategoryList = this.processSelectCommand(sql);
            if (courseCategoryList.Count > 0)
            {
                courseCategory = courseCategoryList[0];
            }

            return courseCategory;
        }

        public CourseCategory findCourseCategory(string courseCategoryName, CourseCategory.CourseCategoryStatus status)
        {
            CourseCategory courseCategory = null;

            string sql = "SELECT * " +
                         "FROM " + CourseCategory.tableName + " " +
                         "WHERE " + CourseCategory.columnCourseCategoryName + " = '" + courseCategoryName + "' " +
                         "AND " + CourseCategory.columnStatus + " = '" + status.ToString() + "'";

            List<CourseCategory> courseCategoryList = this.processSelectCommand(sql);
            if (courseCategoryList.Count > 0)
            {
                courseCategory = courseCategoryList[0];
            }

            return courseCategory;
        }

        public CourseCategory findLastCourseCategory()
        {
            CourseCategory courseCategory = null;

            string sql = "SELECT * " +
                         "FROM " + CourseCategory.tableName + " " +
                         "ORDER BY " + CourseCategory.columnCourseCategoryId + " DESC " +
                         "LIMIT 1";

            List<CourseCategory> courseCategoryList = this.processSelectCommand(sql);
            if (courseCategoryList.Count > 0)
            {
                courseCategory = courseCategoryList[0];
            }

            return courseCategory;
        }

        //--------------------------------------------------------------------------------

        public List<CourseCategory> findAllCourseCategory()
        {
            string sql = "SELECT * " +
                         "FROM " + CourseCategory.tableName + " " +
                         "ORDER BY " + CourseCategory.columnCourseCategoryId + " ASC";

            return this.processSelectCommand(sql);
        }

        public List<CourseCategory> findAllCourseCategory(CourseCategory.CourseCategoryStatus status)
        {
            string sql = "SELECT * " +
                         "FROM " + CourseCategory.tableName + " " +
                         "WHERE " + CourseCategory.columnStatus + " = '" + status.ToString() + "' " +
                         "ORDER BY " + CourseCategory.columnCourseCategoryId + " ASC";

            return this.processSelectCommand(sql);
        }

        //--------------------------------------------------------------------------------

        private bool processInsertCommand(string sql, CourseCategory courseCategory)
        {
            bool returnFlag = false;            
            
            if (courseCategory != null)
            {
                MySqlConnection conn = null;
                try
                {
                    conn = new MySqlConnection(DatabaseManager.getMySqlConnectionString());
                    if (conn != null)
                    {
                        conn.Open();

                        MySqlCommand command = new MySqlCommand(sql, conn);
                        command.Parameters.AddWithValue(CourseCategory.columnCourseCategoryName, courseCategory.Name);
                        command.Parameters.AddWithValue(CourseCategory.columnStatus, courseCategory.Status);

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

        private bool processUpdateCommand(string sql, CourseCategory courseCategory)
        {
            bool returnFlag = false;
            
            if (courseCategory != null)
            {
                MySqlConnection conn = null;
                try
                {
                    conn = new MySqlConnection(DatabaseManager.getMySqlConnectionString());
                    if (conn != null)
                    {
                        conn.Open();

                        MySqlCommand command = new MySqlCommand(sql, conn);
                        command.Parameters.AddWithValue(CourseCategory.columnCourseCategoryName, courseCategory.Name);
                        command.Parameters.AddWithValue(CourseCategory.columnStatus, courseCategory.Status);
                        command.Parameters.AddWithValue(CourseCategory.columnCourseCategoryId, courseCategory.Id);

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

        private List<CourseCategory> processSelectCommand(string sql)
        {
            List<CourseCategory> courseCategoryList = new List<CourseCategory>();
            
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
                    dataAdapter.Fill(data, CourseCategory.tableName);

                    for (int i = 0; i < data.Tables[CourseCategory.tableName].Rows.Count; i++)
                    {
                        courseCategoryList.Add(generateCourseCategory(data, i));
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
            
            return courseCategoryList;
        }

        private CourseCategory generateCourseCategory(DataSet data, int index)
        {
            CourseCategory courseCategory = new CourseCategory();
            courseCategory.Id = Convert.ToInt32(data.Tables[CourseCategory.tableName].Rows[index][CourseCategory.columnCourseCategoryId].ToString());
            courseCategory.Name = data.Tables[CourseCategory.tableName].Rows[index][CourseCategory.columnCourseCategoryName].ToString();
            courseCategory.Status = data.Tables[CourseCategory.tableName].Rows[index][CourseCategory.columnStatus].ToString();

            return courseCategory;
        }

        //--------------------------------------------------------------------------------
    }
}
