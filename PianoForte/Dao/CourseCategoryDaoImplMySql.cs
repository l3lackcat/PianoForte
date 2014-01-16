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
    public class CourseCategoryDaoImplMySql : CourseCategoryDao
    {
        private bool insert(string databaseName, CourseCategory courseCategory, string sql)
        {
            bool returnFlag = false;

            if (courseCategory != null)
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
                        command.Parameters.AddWithValue(CourseCategories.ColumnCourseCategoryName, courseCategory.Name);
                        command.Parameters.AddWithValue(CourseCategories.ColumnCourseCategoryStatus, (int)courseCategory.Status);

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

        private bool update(string databaseName, CourseCategory courseCategory, string sql)
        {
            bool returnFlag = false;

            if (courseCategory != null)
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
                        command.Parameters.AddWithValue(CourseCategories.ColumnCourseCategoryName, courseCategory.Name);
                        command.Parameters.AddWithValue(CourseCategories.ColumnCourseCategoryStatus, (int)courseCategory.Status);
                        command.Parameters.AddWithValue(CourseCategories.ColumnCourseCategoryId, courseCategory.Id);

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

        private CourseCategory selectCourseCategory(string databaseName, string sql)
        {
            CourseCategory courseCategory = null;

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
                    dataAdapter.Fill(data, CourseCategories.TableName);

                    for (int i = 0; i < data.Tables[CourseCategories.TableName].Rows.Count; i++)
                    {
                        courseCategory = new CourseCategory();
                        courseCategory.Id = Convert.ToInt32(data.Tables[CourseCategories.TableName].Rows[i][CourseCategories.ColumnCourseCategoryId].ToString());
                        courseCategory.Name = data.Tables[CourseCategories.TableName].Rows[i][CourseCategories.ColumnCourseCategoryName].ToString();
                        courseCategory.Status = EnumConverter.ToStatus(data.Tables[CourseCategories.TableName].Rows[i][CourseCategories.ColumnCourseCategoryStatus].ToString());
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

            return courseCategory;
        }

        private List<CourseCategory> selectCourseCategoryList(string databaseName, string sql)
        {
            List<CourseCategory> courseCategoryList = new List<CourseCategory>();

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
                    dataAdapter.Fill(data, CourseCategories.TableName);

                    for (int i = 0; i < data.Tables[CourseCategories.TableName].Rows.Count; i++)
                    {
                        CourseCategory courseCategory = new CourseCategory();
                        courseCategory.Id = Convert.ToInt32(data.Tables[CourseCategories.TableName].Rows[i][CourseCategories.ColumnCourseCategoryId].ToString());
                        courseCategory.Name = data.Tables[CourseCategories.TableName].Rows[i][CourseCategories.ColumnCourseCategoryName].ToString();
                        courseCategory.Status = EnumConverter.ToStatus(data.Tables[CourseCategories.TableName].Rows[i][CourseCategories.ColumnCourseCategoryStatus].ToString());

                        courseCategoryList.Add(courseCategory);
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

            return courseCategoryList;
        }

        public bool insertCourseCategory(string databaseName, CourseCategory courseCategory)
        {
            string sql = "INSERT INTO " +
                         CourseCategories.TableName + " (" +
                         CourseCategories.ColumnCourseCategoryName + ", " +
                         CourseCategories.ColumnCourseCategoryStatus + ") " +
                         "VALUES(" +
                         "?" + CourseCategories.ColumnCourseCategoryName + ", " +
                         "?" + CourseCategories.ColumnCourseCategoryStatus + ")";

            return this.insert(databaseName, courseCategory, sql);
        }

        public bool updateCourseCategory(string databaseName, CourseCategory courseCategory)
        {
            string sql = "UPDATE " +
                         CourseCategories.TableName + " SET " +
                         CourseCategories.ColumnCourseCategoryName + " = ?" + CourseCategories.ColumnCourseCategoryName + ", " +
                         CourseCategories.ColumnCourseCategoryStatus + " = ?" + CourseCategories.ColumnCourseCategoryStatus + " " +
                         "WHERE " + CourseCategories.ColumnCourseCategoryId + " = ?" + CourseCategories.ColumnCourseCategoryId;

            return this.update(databaseName, courseCategory, sql);
        }

        public CourseCategory getCourseCategory(string databaseName, int courseCategoryId)
        {
            string sql = "SELECT * " +
                         "FROM " + CourseCategories.TableName + " " +
                         "WHERE " + CourseCategories.ColumnCourseCategoryId + " = " + courseCategoryId;

            return this.selectCourseCategory(databaseName, sql);
        }

        public List<CourseCategory> getCourseCategoryList(string databaseName)
        {
            string sql = "SELECT * " +
                         "FROM " + CourseCategories.TableName + " " +
                         "ORDER BY " + CourseCategories.ColumnCourseCategoryId + " ASC";

            return this.selectCourseCategoryList(databaseName, sql);
        }

        public List<CourseCategory> getCourseCategoryList(string databaseName, Status status)
        {
            string sql = "SELECT * " +
                         "FROM " + CourseCategories.TableName + " " +
                         "WHERE " + CourseCategories.ColumnCourseCategoryStatus + " = " + (int)status + " " +
                         "ORDER BY " + CourseCategories.ColumnCourseCategoryId + " ASC";

            return this.selectCourseCategoryList(databaseName, sql);
        }
    }
}