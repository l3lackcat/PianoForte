using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;

using MySql.Data.MySqlClient;

using PianoForte.Models;
using PianoForte.Enum;
using PianoForte.Resourses.DatabaseStructure.MySqlTable;

namespace PianoForte.Dao
{
    public class TeacherDaoImplMySql : TeacherDao
    {
        private bool insert(string databaseName, Teacher teacher, string sql)
        {
            bool returnFlag = false;

            if (teacher != null)
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
                        command.Parameters.AddWithValue(Teachers.ColumnFirstname, teacher.Firstname);
                        command.Parameters.AddWithValue(Teachers.ColumnLastname, teacher.Lastname);
                        command.Parameters.AddWithValue(Teachers.ColumnNickname, teacher.Nickname);
                        command.Parameters.AddWithValue(Teachers.ColumnTeacherStatus, (int)teacher.Status);

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

        private bool update(string databaseName, Teacher teacher, string sql)
        {
            bool returnFlag = false;

            if (teacher != null)
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
                        command.Parameters.AddWithValue(Teachers.ColumnFirstname, teacher.Firstname);
                        command.Parameters.AddWithValue(Teachers.ColumnLastname, teacher.Lastname);
                        command.Parameters.AddWithValue(Teachers.ColumnNickname, teacher.Nickname);
                        command.Parameters.AddWithValue(Teachers.ColumnTeacherStatus, (int)teacher.Status);
                        command.Parameters.AddWithValue(Teachers.ColumnTeacherId, teacher.Id);

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

        private Teacher selectTeacher(string databaseName, string sql)
        {
            Teacher teacher = null;

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
                    dataAdapter.Fill(data, Teachers.TableName);

                    for (int i = 0; i < data.Tables[Teachers.TableName].Rows.Count; i++)
                    {
                        teacher = new Teacher();
                        teacher.Id = Convert.ToInt32(data.Tables[Teachers.TableName].Rows[i][Teachers.ColumnTeacherId].ToString());
                        teacher.Firstname = data.Tables[Teachers.TableName].Rows[i][Teachers.ColumnFirstname].ToString();
                        teacher.Lastname = data.Tables[Teachers.TableName].Rows[i][Teachers.ColumnLastname].ToString();
                        teacher.Nickname = data.Tables[Teachers.TableName].Rows[i][Teachers.ColumnNickname].ToString();
                        teacher.Status = EnumConverter.ToStatus(data.Tables[Teachers.TableName].Rows[i][Teachers.ColumnTeacherStatus].ToString());
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

            return teacher;
        }

        private List<Teacher> selectTeacherList(string databaseName, string sql)
        {
            List<Teacher> teacherList = new List<Teacher>();

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
                    dataAdapter.Fill(data, Teachers.TableName);

                    for (int i = 0; i < data.Tables[Teachers.TableName].Rows.Count; i++)
                    {
                        Teacher teacher = new Teacher();
                        teacher.Id = Convert.ToInt32(data.Tables[Teachers.TableName].Rows[i][Teachers.ColumnTeacherId].ToString());
                        teacher.Firstname = data.Tables[Teachers.TableName].Rows[i][Teachers.ColumnFirstname].ToString();
                        teacher.Lastname = data.Tables[Teachers.TableName].Rows[i][Teachers.ColumnLastname].ToString();
                        teacher.Nickname = data.Tables[Teachers.TableName].Rows[i][Teachers.ColumnNickname].ToString();
                        teacher.Status = EnumConverter.ToStatus(data.Tables[Teachers.TableName].Rows[i][Teachers.ColumnTeacherStatus].ToString());

                        teacherList.Add(teacher);
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

            return teacherList;
        }

        private List<ShortTeacher> selectShortTeacherList(string databaseName, string sql)
        {
            List<ShortTeacher> shortTeacherList = new List<ShortTeacher>();

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
                    dataAdapter.Fill(data, Teachers.TableName);

                    for (int i = 0; i < data.Tables[Teachers.TableName].Rows.Count; i++)
                    {
                        ShortTeacher shortTeacher = new ShortTeacher();

                        if (data.Tables[Teachers.TableName].Columns.Contains(Teachers.ColumnTeacherId))
                        {
                            shortTeacher.Id = Convert.ToInt32(data.Tables[Teachers.TableName].Rows[i][Teachers.ColumnTeacherId].ToString());
                        }

                        if (data.Tables[Teachers.TableName].Columns.Contains(Teachers.ColumnFirstname))
                        {
                            shortTeacher.Firstname = data.Tables[Teachers.TableName].Rows[i][Teachers.ColumnFirstname].ToString();
                        }

                        if (data.Tables[Teachers.TableName].Columns.Contains(Teachers.ColumnLastname))
                        {
                            shortTeacher.Lastname = data.Tables[Teachers.TableName].Rows[i][Teachers.ColumnLastname].ToString();
                        }

                        if (data.Tables[Teachers.TableName].Columns.Contains(Teachers.ColumnNickname))
                        {
                            shortTeacher.Nickname = data.Tables[Teachers.TableName].Rows[i][Teachers.ColumnNickname].ToString();
                        }

                        shortTeacherList.Add(shortTeacher);
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

            return shortTeacherList;
        }

        public bool insertTeacher(string databaseName, Teacher teacher)
        {
            string sql = "INSERT INTO " +
                         Teachers.TableName + " (" +
                         Teachers.ColumnFirstname + ", " +
                         Teachers.ColumnLastname + ", " +
                         Teachers.ColumnNickname + ", " +
                         Teachers.ColumnTeacherStatus + ") " +
                         "VALUES(" +
                         "?" + Teachers.ColumnFirstname + ", " +
                         "?" + Teachers.ColumnLastname + ", " +
                         "?" + Teachers.ColumnNickname + ", " +
                         "?" + Teachers.ColumnTeacherStatus + ")";

            return this.insert(databaseName, teacher, sql);
        }

        public bool updateTeacher(string databaseName, Teacher teacher)
        {
            string sql = "UPDATE " +
                         Teachers.TableName + " SET " +
                         Teachers.ColumnFirstname + " = ?" + Teachers.ColumnFirstname + ", " +
                         Teachers.ColumnLastname + " = ?" + Teachers.ColumnLastname + ", " +
                         Teachers.ColumnNickname + " = ?" + Teachers.ColumnNickname + ", " +
                         Teachers.ColumnTeacherStatus + " = ?" + Teachers.ColumnTeacherStatus + " " +
                         "WHERE " + Teachers.ColumnTeacherId + " = ?" + Teachers.ColumnTeacherId;

            return this.update(databaseName, teacher, sql);
        }

        public Teacher getTeacher(string databaseName, int teacherId)
        {
            string sql = "SELECT * " +
                         "FROM " + Teachers.TableName + " " +
                         "WHERE " + Teachers.ColumnTeacherId + " = " + teacherId;

            return this.selectTeacher(databaseName, sql);
        }

        public List<Teacher> getTeacherList(string databaseName)
        {
            string sql = "SELECT * " +
                         "FROM " + Teachers.TableName + " " +
                         "ORDER BY " + Teachers.ColumnTeacherId + " ASC";

            return this.selectTeacherList(databaseName, sql);
        }

        public List<Teacher> getTeacherList(string databaseName, string keyword)
        {
            string sql = "SELECT * " +
                         "FROM " + Teachers.TableName + " " +
                         "WHERE " + Teachers.ColumnFirstname + " LIKE '%" + keyword + "%' " +
                         "OR " + Teachers.ColumnLastname + " LIKE '%" + keyword + "%' " +
                         "OR " + Teachers.ColumnNickname + " LIKE '%" + keyword + "%' " +
                         "ORDER BY " + Teachers.ColumnTeacherId + " ASC";

            return this.selectTeacherList(databaseName, sql);
        }

        public List<ShortTeacher> getShortTeacherList(string databaseName)
        {
            string sql = "SELECT " +
                         Teachers.ColumnTeacherId + ", " +
                         Teachers.ColumnFirstname + ", " +
                         Teachers.ColumnLastname + ", " +
                         Teachers.ColumnNickname + " " +
                         "FROM " + Teachers.TableName + " " +
                         "ORDER BY " + Teachers.ColumnTeacherId + " ASC";

            return this.selectShortTeacherList(databaseName, sql);
        }

        public List<ShortTeacher> getShortTeacherList(string databaseName, string keyword)
        {
            string sql = "SELECT " +
                         Teachers.ColumnTeacherId + ", " +
                         Teachers.ColumnFirstname + ", " +
                         Teachers.ColumnLastname + ", " +
                         Teachers.ColumnNickname + " " +
                         "FROM " + Teachers.TableName + " " +
                         "WHERE " + Teachers.ColumnTeacherId + " LIKE '%" + keyword + "%' " +
                         "OR " + Teachers.ColumnFirstname + " LIKE '%" + keyword + "%' " +
                         "OR " + Teachers.ColumnLastname + " LIKE '%" + keyword + "%' " +
                         "OR " + Teachers.ColumnNickname + " LIKE '%" + keyword + "%' " +
                         "ORDER BY " + Teachers.ColumnTeacherId + " ASC";

            return this.selectShortTeacherList(databaseName, sql);
        }

        public List<ShortTeacher> getShortTeacherList(string databaseName, string keyword, int startIndex, int offset)
        {
            string sql = "SELECT " +
                         Teachers.ColumnTeacherId + ", " +
                         Teachers.ColumnFirstname + ", " +
                         Teachers.ColumnLastname + ", " +
                         Teachers.ColumnNickname + " " +
                         "FROM " + Teachers.TableName + " " +
                         "WHERE " + Teachers.ColumnTeacherId + " LIKE '%" + keyword + "%' " +
                         "OR " + Teachers.ColumnFirstname + " LIKE '%" + keyword + "%' " +
                         "OR " + Teachers.ColumnLastname + " LIKE '%" + keyword + "%' " +
                         "OR " + Teachers.ColumnNickname + " LIKE '%" + keyword + "%' " +
                         "ORDER BY " + Teachers.ColumnTeacherId + " ASC " +
                         "LIMIT " + startIndex + "," + offset;

            return this.selectShortTeacherList(databaseName, sql);
        }
    }
}