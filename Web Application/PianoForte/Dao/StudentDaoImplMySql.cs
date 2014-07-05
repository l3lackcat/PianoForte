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
    public class StudentDaoImplMySql : StudentDao
    {
        private bool insert(string databaseName, Student student, string sql)
        {
            bool returnFlag = false;

            if (student != null)
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
                        command.Parameters.AddWithValue(Students.ColumnFirstname, student.Firstname);
                        command.Parameters.AddWithValue(Students.ColumnLastname, student.Lastname);
                        command.Parameters.AddWithValue(Students.ColumnNickname, student.Nickname);
                        command.Parameters.AddWithValue(Students.ColumnBirthday, student.BirthDate.ToString("yyyy-MM-dd"));
                        command.Parameters.AddWithValue(Students.ColumnRegisteredDate, student.RegisteredDate.ToString("yyyy-MM-dd HH:mm:ss"));
                        command.Parameters.AddWithValue(Students.ColumnStudentStatus, (int)student.Status);

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

        private bool update(string databaseName, Student student, string sql)
        {
            bool returnFlag = false;

            if (student != null)
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
                        command.Parameters.AddWithValue(Students.ColumnFirstname, student.Firstname);
                        command.Parameters.AddWithValue(Students.ColumnLastname, student.Lastname);
                        command.Parameters.AddWithValue(Students.ColumnNickname, student.Nickname);
                        command.Parameters.AddWithValue(Students.ColumnBirthday, student.BirthDate.ToString("yyyy-MM-dd"));
                        command.Parameters.AddWithValue(Students.ColumnRegisteredDate, student.RegisteredDate.ToString("yyyy-MM-dd HH:mm:ss"));
                        command.Parameters.AddWithValue(Students.ColumnStudentStatus, (int)student.Status);
                        command.Parameters.AddWithValue(Students.ColumnStudentId, student.Id);

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

        private Student selectStudent(string databaseName, string sql)
        {
            Student student = null;

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
                    dataAdapter.Fill(data, Students.TableName);

                    if (data.Tables[Students.TableName].Rows.Count > 0)
                    {
                        int index = 0;
                        student = new Student();
                        student.Id = Convert.ToInt32(data.Tables[Students.TableName].Rows[index][Students.ColumnStudentId].ToString());
                        student.Firstname = data.Tables[Students.TableName].Rows[index][Students.ColumnFirstname].ToString();
                        student.Lastname = data.Tables[Students.TableName].Rows[index][Students.ColumnLastname].ToString();
                        student.Nickname = data.Tables[Students.TableName].Rows[index][Students.ColumnNickname].ToString();
                        student.BirthDate = Convert.ToDateTime(data.Tables[Students.TableName].Rows[index][Students.ColumnBirthday].ToString());
                        student.RegisteredDate = Convert.ToDateTime(data.Tables[Students.TableName].Rows[index][Students.ColumnRegisteredDate].ToString());
                        student.Status = EnumConverter.ToStatus(data.Tables[Students.TableName].Rows[index][Students.ColumnStudentStatus].ToString());
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

            return student;
        }

        private List<Student> selectStudentList(string databaseName, string sql)
        {
            List<Student> studentList = new List<Student>();

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
                    dataAdapter.Fill(data, Students.TableName);

                    for (int i = 0; i < data.Tables[Students.TableName].Rows.Count; i++)
                    {
                        Student student = new Student();

                        student.Id = Convert.ToInt32(data.Tables[Students.TableName].Rows[i][Students.ColumnStudentId].ToString());
                        student.Firstname = data.Tables[Students.TableName].Rows[i][Students.ColumnFirstname].ToString();
                        student.Lastname = data.Tables[Students.TableName].Rows[i][Students.ColumnLastname].ToString();
                        student.Nickname = data.Tables[Students.TableName].Rows[i][Students.ColumnNickname].ToString();
                        student.BirthDate = Convert.ToDateTime(data.Tables[Students.TableName].Rows[i][Students.ColumnBirthday].ToString());
                        student.RegisteredDate = Convert.ToDateTime(data.Tables[Students.TableName].Rows[i][Students.ColumnRegisteredDate].ToString());
                        student.Status = EnumConverter.ToStatus(data.Tables[Students.TableName].Rows[i][Students.ColumnStudentStatus].ToString());

                        //if (data.Tables[Students.TableName].Columns.Contains(Students.ColumnStudentId))
                        //{
                        //    student.Id = Convert.ToInt32(data.Tables[Students.TableName].Rows[i][Students.ColumnStudentId].ToString());
                        //}

                        //if (data.Tables[Students.TableName].Columns.Contains(Students.ColumnFirstname))
                        //{
                        //    student.Firstname = data.Tables[Students.TableName].Rows[i][Students.ColumnFirstname].ToString();
                        //}

                        //if (data.Tables[Students.TableName].Columns.Contains(Students.ColumnLastname))
                        //{
                        //    student.Lastname = data.Tables[Students.TableName].Rows[i][Students.ColumnLastname].ToString();
                        //}

                        //if (data.Tables[Students.TableName].Columns.Contains(Students.ColumnNickname))
                        //{
                        //    student.Nickname = data.Tables[Students.TableName].Rows[i][Students.ColumnNickname].ToString();
                        //}

                        //if (data.Tables[Students.TableName].Columns.Contains(Students.ColumnBirthday))
                        //{
                        //    student.Birthdate = Convert.ToDateTime(data.Tables[Students.TableName].Rows[i][Students.ColumnBirthday].ToString());
                        //}

                        //if (data.Tables[Students.TableName].Columns.Contains(Students.ColumnRegisteredDate))
                        //{
                        //    student.RegisteredDate = Convert.ToDateTime(data.Tables[Students.TableName].Rows[i][Students.ColumnRegisteredDate].ToString());
                        //}

                        //if (data.Tables[Students.TableName].Columns.Contains(Students.ColumnStudentStatus))
                        //{
                        //    student.Status = EnumConverter.ToStatus(data.Tables[Students.TableName].Rows[i][Students.ColumnStudentStatus].ToString());
                        //}                                                                                                                      

                        studentList.Add(student);
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

            return studentList;
        }

        public bool insertStudent(string databaseName, Student student)
        {
            string sql = "INSERT INTO " +
                         Students.TableName + " (" +
                         Students.ColumnFirstname + ", " +
                         Students.ColumnLastname + ", " +
                         Students.ColumnNickname + ", " +
                         Students.ColumnBirthday + ", " +
                         Students.ColumnRegisteredDate + ", " +
                         Students.ColumnStudentStatus + ") " +
                         "VALUES(" +
                         "?" + Students.ColumnFirstname + ", " +
                         "?" + Students.ColumnLastname + ", " +
                         "?" + Students.ColumnNickname + ", " +
                         "?" + Students.ColumnBirthday + ", " +
                         "?" + Students.ColumnRegisteredDate + ", " +
                         "?" + Students.ColumnStudentStatus + ")";

            return this.insert(databaseName, student, sql);
        }

        public bool updateStudent(string databaseName, Student student)
        {
            string sql = "UPDATE " +
                         Students.TableName + " SET " +
                         Students.ColumnFirstname + " = ?" + Students.ColumnFirstname + ", " +
                         Students.ColumnLastname + " = ?" + Students.ColumnLastname + ", " +
                         Students.ColumnNickname + " = ?" + Students.ColumnNickname + ", " +
                         Students.ColumnBirthday + " = ?" + Students.ColumnBirthday + ", " +
                         Students.ColumnRegisteredDate + " = ?" + Students.ColumnRegisteredDate + ", " +
                         Students.ColumnStudentStatus + " = ?" + Students.ColumnStudentStatus + " " +
                         "WHERE " + Students.ColumnStudentId + " = ?" + Students.ColumnStudentId;

            return this.update(databaseName, student, sql);
        }

        public Student getStudent(string databaseName, int id)
        {
            string sql = "SELECT * " +
                         "FROM " + Students.TableName + " " +
                         "WHERE " + Students.ColumnStudentId + " = " + id;

            return this.selectStudent(databaseName, sql);
        }

        public List<Student> getStudentList(string databaseName)
        {
            string sql = "SELECT * " +
                         "FROM " + Students.TableName + " " +
                         "ORDER BY " + Students.ColumnStudentId + " ASC ";

            return this.selectStudentList(databaseName, sql);
        }

        public List<Student> getStudentList(string databaseName, int startIndex, int offset)
        {
            string sql = "SELECT * " +
                         "FROM " + Students.TableName + " " +
                         "ORDER BY " + Students.ColumnStudentId + " ASC " +
                         "LIMIT " + startIndex + "," + offset;

            return this.selectStudentList(databaseName, sql);
        }
    }
}