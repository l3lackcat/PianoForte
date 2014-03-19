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
    public class StudentContactDaoImplMySql : StudentContactDao
    {
        private bool insert(string databaseName, StudentContact studentContact, string sql)
        {
            bool returnFlag = false;

            if (studentContact != null)
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
                        command.Parameters.AddWithValue(StudentContacts.ColumnStudentId, studentContact.StudentId);
                        command.Parameters.AddWithValue(StudentContacts.ColumnContactType, (int)studentContact.Type);
                        command.Parameters.AddWithValue(StudentContacts.ColumnContactLabel, studentContact.Label);
                        command.Parameters.AddWithValue(StudentContacts.ColumnContactContent, studentContact.Content);
                        command.Parameters.AddWithValue(StudentContacts.ColumnContactStatus, studentContact.Status);
                        command.Parameters.AddWithValue(StudentContacts.ColumnContactIsPrimary, studentContact.IsPrimary);

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

        private bool update(string databaseName, StudentContact studentContact, string sql)
        {
            bool returnFlag = false;

            if (studentContact != null)
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
                        command.Parameters.AddWithValue(StudentContacts.ColumnStudentId, studentContact.StudentId);
                        command.Parameters.AddWithValue(StudentContacts.ColumnContactType, (int)studentContact.Type);
                        command.Parameters.AddWithValue(StudentContacts.ColumnContactLabel, studentContact.Label);
                        command.Parameters.AddWithValue(StudentContacts.ColumnContactContent, studentContact.Content);
                        command.Parameters.AddWithValue(StudentContacts.ColumnContactStatus, studentContact.Status);
                        command.Parameters.AddWithValue(StudentContacts.ColumnContactIsPrimary, studentContact.IsPrimary);
                        command.Parameters.AddWithValue(StudentContacts.ColumnStudentContactId, studentContact.Id);

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

        private StudentContact selectStudentContact(string databaseName, string sql)
        {
            StudentContact studentContact = null;

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
                    dataAdapter.Fill(data, StudentContacts.TableName);

                    if (data.Tables[StudentContacts.TableName].Rows.Count == 1)
                    {
                        studentContact = new StudentContact();
                        studentContact.Id = Convert.ToInt32(data.Tables[StudentContacts.TableName].Rows[0][StudentContacts.ColumnStudentContactId].ToString());
                        studentContact.StudentId = Convert.ToInt32(data.Tables[StudentContacts.TableName].Rows[0][StudentContacts.ColumnStudentId].ToString());
                        studentContact.Type = EnumConverter.ToContactType(data.Tables[StudentContacts.TableName].Rows[0][StudentContacts.ColumnContactType].ToString());
                        studentContact.Label = data.Tables[StudentContacts.TableName].Rows[0][StudentContacts.ColumnContactLabel].ToString();
                        studentContact.Content = data.Tables[StudentContacts.TableName].Rows[0][StudentContacts.ColumnContactContent].ToString();
                        studentContact.Status = EnumConverter.ToStatus(data.Tables[StudentContacts.TableName].Rows[0][StudentContacts.ColumnContactStatus].ToString());
                        studentContact.IsPrimary = Convert.ToBoolean(data.Tables[StudentContacts.TableName].Rows[0][StudentContacts.ColumnContactIsPrimary]);
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

            return studentContact;
        }

        private List<StudentContact> selectStudentContactList(string databaseName, string sql)
        {
            List<StudentContact> studentContactList = new List<StudentContact>();

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
                    dataAdapter.Fill(data, StudentContacts.TableName);

                    for (int i = 0; i < data.Tables[StudentContacts.TableName].Rows.Count; i++)
                    {
                        StudentContact studentContact = new StudentContact();
                        studentContact.Id = Convert.ToInt32(data.Tables[StudentContacts.TableName].Rows[i][StudentContacts.ColumnStudentContactId].ToString());
                        studentContact.StudentId = Convert.ToInt32(data.Tables[StudentContacts.TableName].Rows[i][StudentContacts.ColumnStudentId].ToString());
                        studentContact.Type = EnumConverter.ToContactType(data.Tables[StudentContacts.TableName].Rows[i][StudentContacts.ColumnContactType].ToString());
                        studentContact.Label = data.Tables[StudentContacts.TableName].Rows[i][StudentContacts.ColumnContactLabel].ToString();
                        studentContact.Content = data.Tables[StudentContacts.TableName].Rows[i][StudentContacts.ColumnContactContent].ToString();
                        studentContact.Status = EnumConverter.ToStatus(data.Tables[StudentContacts.TableName].Rows[i][StudentContacts.ColumnContactStatus].ToString());
                        studentContact.IsPrimary = Convert.ToBoolean(data.Tables[StudentContacts.TableName].Rows[i][StudentContacts.ColumnContactIsPrimary]);

                        studentContactList.Add(studentContact);
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

            return studentContactList;
        }

        public bool insertStudentContact(string databaseName, StudentContact studentContact)
        {
            string sql = "INSERT INTO " +
                         StudentContacts.TableName + " (" +
                         StudentContacts.ColumnStudentId + ", " +
                         StudentContacts.ColumnContactType + ", " +
                         StudentContacts.ColumnContactLabel + ", " +
                         StudentContacts.ColumnContactContent + ", " +
                         StudentContacts.ColumnContactStatus + ", " +
                         StudentContacts.ColumnContactIsPrimary + ") " +
                         "VALUES(" +
                         "?" + StudentContacts.ColumnStudentId + ", " +
                         "?" + StudentContacts.ColumnContactType + ", " +
                         "?" + StudentContacts.ColumnContactLabel + ", " +
                         "?" + StudentContacts.ColumnContactContent + ", " +
                         "?" + StudentContacts.ColumnContactStatus + ", " +
                         "?" + StudentContacts.ColumnContactIsPrimary + ")";

            return this.insert(databaseName, studentContact, sql);
        }

        public bool updateStudentContact(string databaseName, StudentContact studentContact)
        {
            string sql = "UPDATE " +
                         StudentContacts.TableName + " SET " +
                         StudentContacts.ColumnStudentId + " = ?" + StudentContacts.ColumnStudentId + ", " +
                         StudentContacts.ColumnContactType + " = ?" + StudentContacts.ColumnContactType + ", " +
                         StudentContacts.ColumnContactLabel + " = ?" + StudentContacts.ColumnContactLabel + ", " +
                         StudentContacts.ColumnContactContent + " = ?" + StudentContacts.ColumnContactContent + ", " +
                         StudentContacts.ColumnContactStatus + " = ?" + StudentContacts.ColumnContactStatus + ", " +
                         StudentContacts.ColumnContactIsPrimary + " = ?" + StudentContacts.ColumnContactIsPrimary + " " +
                         "WHERE " + StudentContacts.ColumnStudentContactId + " = ?" + StudentContacts.ColumnStudentContactId;

            return this.update(databaseName, studentContact, sql);
        }

        public bool deleteStudentContact(string databaseName, int contactId)
        {
            string sql = "DELETE " +
                         "FROM " + StudentContacts.TableName + " " +
                         "WHERE " + StudentContacts.ColumnStudentContactId + " = " + contactId;

            return this.executeQuery(databaseName, sql);
        }

        public bool deleteStudentContactList(string databaseName, int studentId)
        {
            string sql = "DELETE " +
                         "FROM " + StudentContacts.TableName + " " +
                         "WHERE " + StudentContacts.ColumnStudentId + " = " + studentId;

            return this.executeQuery(databaseName, sql);
        }

        public StudentContact getStudentContact(string databaseName, int contactId)
        {
            string sql = "SELECT * " +
                         "FROM " + StudentContacts.TableName + " " +
                         "WHERE " + StudentContacts.ColumnStudentContactId + " = " + contactId;

            return this.selectStudentContact(databaseName, sql);
        }

        public StudentContact getStudentContact(string databaseName, int studentId, ContactType type, string label, string content)
        {
            string sql = "SELECT * " +
                         "FROM " + StudentContacts.TableName + " " +
                         "WHERE " + StudentContacts.ColumnStudentId + " = " + studentId + " " +
                         "AND " + StudentContacts.ColumnContactType + " = " + (int)type + " " +
                         "AND " + StudentContacts.ColumnContactLabel + " = '" + label + "' " +
                         "AND " + StudentContacts.ColumnContactContent + " = '" + content + "'";

            return this.selectStudentContact(databaseName, sql);
        }

        public List<StudentContact> getStudentContactList(string databaseName, int studentId)
        {
            string sql = "SELECT * " +
                         "FROM " + StudentContacts.TableName + " " +
                         "WHERE " + StudentContacts.ColumnStudentId + " = " + studentId + " " +
                         "ORDER BY " + StudentContacts.ColumnStudentContactId + " ASC";

            return this.selectStudentContactList(databaseName, sql);
        }

        public List<StudentContact> getStudentContactList(string databaseName, int studentId, Status status)
        {
            string sql = "SELECT * " +
                         "FROM " + StudentContacts.TableName + " " +
                         "WHERE " + StudentContacts.ColumnStudentId + " = " + studentId + " " +
                         "AND " + StudentContacts.ColumnContactStatus + " = " + (int)status + " " +
                         "ORDER BY " + StudentContacts.ColumnStudentContactId + " ASC";

            return this.selectStudentContactList(databaseName, sql);
        }
    }
}