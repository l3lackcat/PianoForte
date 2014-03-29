using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;

using MySql.Data.MySqlClient;

using PianoForte.Resourses.DatabaseStructure.MySqlTable;

namespace PianoForte.Dao
{
    public class TeachedCourseDaoImplMySql : TeachedCourseDao
    {
        private bool executeQuery(string databaseName, string sql)
        {
            bool returnFlag = false;

            MySqlConnection conn = null;
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings[databaseName].ConnectionString;

                conn = new MySqlConnection(connectionString);
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

        private List<int> selectTeachedCourseIdList(string databaseName, string sql)
        {
            List<int> teachedCourseIdList = new List<int>();

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
                    dataAdapter.Fill(data, TeachedCourses.TableName);

                    for (int i = 0; i < data.Tables[TeachedCourses.TableName].Rows.Count; i++)
                    {
                        int teachedCourseId = Convert.ToInt32(data.Tables[TeachedCourses.TableName].Rows[i][TeachedCourses.ColumnCourseId].ToString());

                        teachedCourseIdList.Add(teachedCourseId);
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

            return teachedCourseIdList;
        }

        public bool insertTeachedCourse(string databaseName, int teacherId, int courseId)
        {
            string sql = "INSERT INTO " +
                         TeachedCourses.TableName + " (" +
                         TeachedCourses.ColumnTeacherId + ", " +
                         TeachedCourses.ColumnCourseId + ") " +
                         "VALUES(" +
                         teacherId + ", " +
                         courseId + ")";

            return this.executeQuery(databaseName, sql);
        }

        public bool deleteTeachedCourseListByCourseId(string databaseName, int courseId)
        {
            string sql = "DELETE " +
                         "FROM " + TeachedCourses.TableName + " " +
                         "WHERE " + TeachedCourses.ColumnTeacherId + " = " + courseId;

            return this.executeQuery(databaseName, sql);
        }

        public bool deleteTeachedCourseListByTeacherId(string databaseName, int teacherId)
        {
            string sql = "DELETE " +
                         "FROM " + TeachedCourses.TableName + " " +
                         "WHERE " + TeachedCourses.ColumnTeacherId + " = " + teacherId;

            return this.executeQuery(databaseName, sql);
        }

        public List<int> getTeachedCourseIdList(string databaseName, int teacherId)
        {
            string sql = "SELECT * " +
                         "FROM " + TeachedCourses.TableName + " " +
                         "WHERE " + TeachedCourses.ColumnTeacherId + " = " + teacherId;

            return this.selectTeachedCourseIdList(databaseName, sql);
        }
    }
}