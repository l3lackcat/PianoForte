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
    public class TeacherContactDaoImplMySql : TeacherContactDao
    {
        private bool insert(string databaseName, TeacherContact teacherContact, string sql)
        {
            bool returnFlag = false;

            if (teacherContact != null)
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
                        command.Parameters.AddWithValue(TeacherContacts.ColumnTeacherId, teacherContact.TeacherId);
                        command.Parameters.AddWithValue(TeacherContacts.ColumnContactType, (int)teacherContact.Type);
                        command.Parameters.AddWithValue(TeacherContacts.ColumnContactLabel, teacherContact.Label);
                        command.Parameters.AddWithValue(TeacherContacts.ColumnContactContent, teacherContact.Content);
                        command.Parameters.AddWithValue(TeacherContacts.ColumnContactStatus, teacherContact.Status);
                        command.Parameters.AddWithValue(TeacherContacts.ColumnContactIsPrimary, teacherContact.IsPrimary);

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

        private bool update(string databaseName, TeacherContact teacherContact, string sql)
        {
            bool returnFlag = false;

            if (teacherContact != null)
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
                        command.Parameters.AddWithValue(TeacherContacts.ColumnTeacherId, teacherContact.TeacherId);
                        command.Parameters.AddWithValue(TeacherContacts.ColumnContactType, (int)teacherContact.Type);
                        command.Parameters.AddWithValue(TeacherContacts.ColumnContactLabel, teacherContact.Label);
                        command.Parameters.AddWithValue(TeacherContacts.ColumnContactContent, teacherContact.Content);
                        command.Parameters.AddWithValue(TeacherContacts.ColumnContactStatus, teacherContact.Status);
                        command.Parameters.AddWithValue(TeacherContacts.ColumnContactIsPrimary, teacherContact.IsPrimary);
                        command.Parameters.AddWithValue(TeacherContacts.ColumnTeacherContactId, teacherContact.Id);

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

        private TeacherContact selectTeacherContact(string databaseName, string sql)
        {
            TeacherContact teacherContact = null;

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
                    dataAdapter.Fill(data, TeacherContacts.TableName);

                    if (data.Tables[TeacherContacts.TableName].Rows.Count == 1)
                    {
                        teacherContact = new TeacherContact();
                        teacherContact.Id = Convert.ToInt32(data.Tables[TeacherContacts.TableName].Rows[0][TeacherContacts.ColumnTeacherContactId]);
                        teacherContact.TeacherId = Convert.ToInt32(data.Tables[TeacherContacts.TableName].Rows[0][TeacherContacts.ColumnTeacherId]);
                        teacherContact.Type = EnumConverter.ToContactType(data.Tables[TeacherContacts.TableName].Rows[0][TeacherContacts.ColumnContactType].ToString());
                        teacherContact.Label = data.Tables[TeacherContacts.TableName].Rows[0][TeacherContacts.ColumnContactLabel].ToString();
                        teacherContact.Content = data.Tables[TeacherContacts.TableName].Rows[0][TeacherContacts.ColumnContactContent].ToString();
                        teacherContact.Status = EnumConverter.ToStatus(data.Tables[TeacherContacts.TableName].Rows[0][TeacherContacts.ColumnContactStatus].ToString());
                        teacherContact.IsPrimary = Convert.ToBoolean(data.Tables[TeacherContacts.TableName].Rows[0][TeacherContacts.ColumnContactIsPrimary]);
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

            return teacherContact;
        }

        private List<TeacherContact> selectTeacherContactList(string databaseName, string sql)
        {
            List<TeacherContact> teacherContactList = new List<TeacherContact>();

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
                    dataAdapter.Fill(data, TeacherContacts.TableName);

                    for (int i = 0; i < data.Tables[TeacherContacts.TableName].Rows.Count; i++)
                    {
                        TeacherContact teacherContact = new TeacherContact();
                        teacherContact.Id = Convert.ToInt32(data.Tables[TeacherContacts.TableName].Rows[i][TeacherContacts.ColumnTeacherContactId]);
                        teacherContact.TeacherId = Convert.ToInt32(data.Tables[TeacherContacts.TableName].Rows[i][TeacherContacts.ColumnTeacherId]);
                        teacherContact.Type = EnumConverter.ToContactType(data.Tables[TeacherContacts.TableName].Rows[i][TeacherContacts.ColumnContactType].ToString());
                        teacherContact.Label = data.Tables[TeacherContacts.TableName].Rows[i][TeacherContacts.ColumnContactLabel].ToString();
                        teacherContact.Content = data.Tables[TeacherContacts.TableName].Rows[i][TeacherContacts.ColumnContactContent].ToString();
                        teacherContact.Status = EnumConverter.ToStatus(data.Tables[TeacherContacts.TableName].Rows[i][TeacherContacts.ColumnContactStatus].ToString());
                        teacherContact.IsPrimary = Convert.ToBoolean(data.Tables[TeacherContacts.TableName].Rows[i][TeacherContacts.ColumnContactIsPrimary]);

                        teacherContactList.Add(teacherContact);
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

            return teacherContactList;
        }

        public bool insertTeacherContact(string databaseName, TeacherContact teacherContact)
        {
            string sql = "INSERT INTO " +
                         TeacherContacts.TableName + " (" +
                         TeacherContacts.ColumnTeacherId + ", " +
                         TeacherContacts.ColumnContactType + ", " +
                         TeacherContacts.ColumnContactLabel + ", " +
                         TeacherContacts.ColumnContactContent + ", " +
                         TeacherContacts.ColumnContactStatus + ", " +
                         TeacherContacts.ColumnContactIsPrimary + ") " +
                         "VALUES(" +
                         "?" + TeacherContacts.ColumnTeacherId + ", " +
                         "?" + TeacherContacts.ColumnContactType + ", " +
                         "?" + TeacherContacts.ColumnContactLabel + ", " +
                         "?" + TeacherContacts.ColumnContactContent + ", " +
                         "?" + TeacherContacts.ColumnContactStatus + ", " +
                         "?" + TeacherContacts.ColumnContactIsPrimary + ")";

            return this.insert(databaseName, teacherContact, sql);
        }

        public bool updateTeacherContact(string databaseName, TeacherContact teacherContact)
        {
            string sql = "UPDATE " +
                         TeacherContacts.TableName + " SET " +
                         TeacherContacts.ColumnTeacherId + " = ?" + TeacherContacts.ColumnTeacherId + ", " +
                         TeacherContacts.ColumnContactType + " = ?" + TeacherContacts.ColumnContactType + ", " +
                         TeacherContacts.ColumnContactLabel + " = ?" + TeacherContacts.ColumnContactLabel + ", " +
                         TeacherContacts.ColumnContactContent + " = ?" + TeacherContacts.ColumnContactContent + ", " +
                         TeacherContacts.ColumnContactStatus + " = ?" + TeacherContacts.ColumnContactStatus + ", " +
                         TeacherContacts.ColumnContactIsPrimary + " = ?" + TeacherContacts.ColumnContactIsPrimary + " " +
                         "WHERE " + TeacherContacts.ColumnTeacherContactId + " = ?" + TeacherContacts.ColumnTeacherContactId;

            return this.update(databaseName, teacherContact, sql);
        }

        public bool deleteTeacherContact(string databaseName, int contactId)
        {
            string sql = "DELETE " +
                         "FROM " + TeacherContacts.TableName + " " +
                         "WHERE " + TeacherContacts.ColumnTeacherContactId + " = " + contactId;

            return this.executeQuery(databaseName, sql);
        }

        public bool deleteTeacherContactList(string databaseName, int teacherId)
        {
            string sql = "DELETE " +
                         "FROM " + TeacherContacts.TableName + " " +
                         "WHERE " + TeacherContacts.ColumnTeacherId + " = " + teacherId;

            return this.executeQuery(databaseName, sql);
        }

        public TeacherContact getTeacherContact(string databaseName, int contactId)
        {
            string sql = "SELECT * " +
                         "FROM " + TeacherContacts.TableName + " " +
                         "WHERE " + TeacherContacts.ColumnTeacherContactId + " = " + contactId;

            return this.selectTeacherContact(databaseName, sql);
        }

        public TeacherContact getTeacherContact(string databaseName, int teacherId, ContactType type, string label, string content)
        {
            string sql = "SELECT * " +
                         "FROM " + TeacherContacts.TableName + " " +
                         "WHERE " + TeacherContacts.ColumnTeacherId + " = " + teacherId + " " +
                         "AND " + TeacherContacts.ColumnContactType + " = " + (int)type + " " +
                         "AND " + TeacherContacts.ColumnContactLabel + " = '" + label + "' " +
                         "AND " + TeacherContacts.ColumnContactContent + " = '" + content + "'";

            return this.selectTeacherContact(databaseName, sql);
        }

        public List<TeacherContact> getTeacherContactList(string databaseName, int teacherId)
        {
            string sql = "SELECT * " +
                         "FROM " + TeacherContacts.TableName + " " +
                         "WHERE " + TeacherContacts.ColumnTeacherId + " = " + teacherId + " " +
                         "ORDER BY " + TeacherContacts.ColumnTeacherContactId + " ASC";

            return this.selectTeacherContactList(databaseName, sql);
        }

        public List<TeacherContact> getTeacherContactList(string databaseName, int teacherId, Status status)
        {
            string sql = "SELECT * " +
                         "FROM " + TeacherContacts.TableName + " " +
                         "WHERE " + TeacherContacts.ColumnTeacherId + " = " + teacherId + " " +
                         "AND " + TeacherContacts.ColumnContactStatus + " = " + (int)status + " " +
                         "ORDER BY " + TeacherContacts.ColumnTeacherContactId + " ASC";

            return this.selectTeacherContactList(databaseName, sql);
        }
    }
}