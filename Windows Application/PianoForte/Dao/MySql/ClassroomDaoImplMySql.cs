using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MySql.Data.MySqlClient;
using System.Data;

using PianoForte.Dao;
using PianoForte.Manager;
using PianoForte.Model;

namespace PianoForte.Dao.MySql
{
    public class ClassroomDaoImplMySql : ClassroomDao
    {
        //--------------------------------------------------------------------------------

        public bool insertClassroom(Classroom classroom)
        {
            string sql = "INSERT INTO " +
                         Classroom.tableName + " (" +
                         Classroom.columnEnrollmentId + ", " +
                         Classroom.columnTeacherId + ", " +
                         Classroom.columnStartDate + ", " +
                         Classroom.columnClassDayOfWeek + ", " +
                         Classroom.columnClassTime + ", " +
                         Classroom.columnClassDuration + ", " +
                         Classroom.columnStatus + ") " +
                         "VALUES(" +
                         "?" + Classroom.columnEnrollmentId + ", " +
                         "?" + Classroom.columnTeacherId + ", " +
                         "?" + Classroom.columnStartDate + ", " +
                         "?" + Classroom.columnClassDayOfWeek + ", " +
                         "?" + Classroom.columnClassTime + ", " +
                         "?" + Classroom.columnClassDuration + ", " +
                         "?" + Classroom.columnStatus + ")";

            return this.processInsertCommand(sql, classroom);
        }

        public bool updateClassroom(Classroom classroom)
        {
            string sql = "UPDATE " +
                         Classroom.tableName + " SET " +
                         Classroom.columnEnrollmentId + " = ?" + Classroom.columnEnrollmentId + ", " +
                         Classroom.columnTeacherId + " = ?" + Classroom.columnTeacherId + ", " +
                         Classroom.columnStartDate + " = ?" + Classroom.columnStartDate + ", " +
                         Classroom.columnClassDayOfWeek + " = ?" + Classroom.columnClassDayOfWeek + ", " +
                         Classroom.columnClassTime + " = ?" + Classroom.columnClassTime + ", " +
                         Classroom.columnClassDuration + " = ?" + Classroom.columnClassDuration + ", " +
                         Classroom.columnStatus + " = ?" + Classroom.columnStatus + " " +
                         "WHERE " + Classroom.columnClassroomId + " = ?" + Classroom.columnClassroomId;

            return this.processUpdateCommand(sql, classroom);
        }

        public bool deleteClassroom(int classroomId)
        {
            string sql = "DELETE " +
                         "FROM " + Classroom.tableName + " " +
                         "WHERE " + Classroom.columnClassroomId + " = " + classroomId;

            return this.processDeleteCommand(sql);
        }

        //--------------------------------------------------------------------------------

        public Classroom findLastClassroom()
        {
            Classroom classroom = null;

            string sql = "SELECT * " +
                         "FROM " + Classroom.tableName + " " +
                         "ORDER BY " + Classroom.columnClassroomId + " DESC " +
                         "LIMIT 1";

            List<Classroom> classroomList = this.processSelectCommand(sql);
            if (classroomList.Count > 0)
            {
                classroom = classroomList[0];
            }

            return classroom;
        }

        public Classroom findClassroom(int classroomId)
        {
            Classroom classroom = null;

            string sql = "SELECT * " +
                         "FROM " + Classroom.tableName + " " +
                         "WHERE " + Classroom.columnClassroomId + " = " + classroomId;

            List<Classroom> classroomList = this.processSelectCommand(sql);
            if (classroomList.Count > 0)
            {
                classroom = classroomList[0];
            }

            return classroom;
        }

        //--------------------------------------------------------------------------------

        public List<Classroom> findAllClassroom()
        {
            string sql = "SELECT * " +
                         "FROM " + Classroom.tableName + " " +
                         "ORDER BY " + Classroom.columnClassroomId + " ASC";

            return this.processSelectCommand(sql);
        }

        public List<Classroom> findAllClassroom(int enrollmentId)
        {
            string sql = "SELECT * " +
                         "FROM " + Classroom.tableName + " " +
                         "WHERE " + Classroom.columnEnrollmentId + " = " + enrollmentId + " " +
                         "ORDER BY " + Classroom.columnClassroomId + " ASC";

            return this.processSelectCommand(sql);
        }

        //--------------------------------------------------------------------------------

        private bool processInsertCommand(string sql, Classroom classroom)
        {
            bool returnFlag = false;
            
            if (classroom != null)
            {
                MySqlConnection conn = null;
                try
                {
                    conn = new MySqlConnection(DatabaseManager.getMySqlConnectionString());
                    if (conn != null)
                    {
                        conn.Open();

                        MySqlCommand command = new MySqlCommand(sql, conn);

                        command.Parameters.AddWithValue(Classroom.columnEnrollmentId, classroom.EnrollmentId);
                        command.Parameters.AddWithValue(Classroom.columnTeacherId, classroom.TeacherId);
                        command.Parameters.AddWithValue(Classroom.columnStartDate, classroom.StartDate);
                        command.Parameters.AddWithValue(Classroom.columnClassDayOfWeek, classroom.ClassDayOfWeek);
                        command.Parameters.AddWithValue(Classroom.columnClassTime, classroom.ClassTime);
                        command.Parameters.AddWithValue(Classroom.columnClassDuration, classroom.ClassDuration);
                        command.Parameters.AddWithValue(Classroom.columnStatus, classroom.Status);

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

        private bool processUpdateCommand(string sql, Classroom classroom)
        {
            bool returnFlag = false;
            
            if (classroom != null)
            {
                MySqlConnection conn = null;
                try
                {
                    conn = new MySqlConnection(DatabaseManager.getMySqlConnectionString());
                    if (conn != null)
                    {
                        conn.Open();

                        MySqlCommand command = new MySqlCommand(sql, conn);

                        command.Parameters.AddWithValue(Classroom.columnEnrollmentId, classroom.EnrollmentId);
                        command.Parameters.AddWithValue(Classroom.columnTeacherId, classroom.TeacherId);
                        command.Parameters.AddWithValue(Classroom.columnStartDate, classroom.StartDate);
                        command.Parameters.AddWithValue(Classroom.columnClassDayOfWeek, classroom.ClassDayOfWeek);
                        command.Parameters.AddWithValue(Classroom.columnClassTime, classroom.ClassTime);
                        command.Parameters.AddWithValue(Classroom.columnStatus, classroom.Status);
                        command.Parameters.AddWithValue(Classroom.columnClassDuration, classroom.ClassDuration);
                        command.Parameters.AddWithValue(Classroom.columnClassroomId, classroom.Id);

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

        private List<Classroom> processSelectCommand(string sql)
        {
            List<Classroom> classroomList = new List<Classroom>();

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
                    dataAdapter.Fill(data, Classroom.tableName);

                    for (int i = 0; i < data.Tables[Classroom.tableName].Rows.Count; i++)
                    {
                        classroomList.Add(generateClassroom(data, i));
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
            
            return classroomList;
        }        

        private Classroom generateClassroom(DataSet data, int index)
        {
            Classroom classroom = new Classroom();
            classroom.Id = Convert.ToInt32(data.Tables[Classroom.tableName].Rows[index][Classroom.columnClassroomId].ToString());
            classroom.EnrollmentId = Convert.ToInt32(data.Tables[Classroom.tableName].Rows[index][Classroom.columnEnrollmentId].ToString());
            classroom.TeacherId = Convert.ToInt32(data.Tables[Classroom.tableName].Rows[index][Classroom.columnTeacherId].ToString());
            classroom.StartDate = (DateTime)data.Tables[Classroom.tableName].Rows[index][Classroom.columnStartDate];
            classroom.ClassDayOfWeek = data.Tables[Classroom.tableName].Rows[index][Classroom.columnClassDayOfWeek].ToString();
            classroom.ClassTime = data.Tables[Classroom.tableName].Rows[index][Classroom.columnClassTime].ToString();
            classroom.ClassDuration = Convert.ToInt32(data.Tables[Classroom.tableName].Rows[index][Classroom.columnClassDuration].ToString());
            classroom.Status = data.Tables[Classroom.tableName].Rows[index][Classroom.columnStatus].ToString();

            return classroom;
        }

        //--------------------------------------------------------------------------------

        public List<Classroom> processQueryString_old(string sql)
        {
            List<Classroom> classroomList = new List<Classroom>();

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
                    dataAdapter.Fill(data, Classroom.tableName);

                    for (int i = 0; i < data.Tables[Classroom.tableName].Rows.Count; i++)
                    {
                        classroomList.Add(generateClassroom_old(data, i));
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

            return classroomList;
        }

        private Classroom generateClassroom_old(DataSet data, int index)
        {
            Classroom classroom = new Classroom();
            classroom.Id = Convert.ToInt32(data.Tables[Classroom.tableName].Rows[index][Classroom.columnClassroomId].ToString());
            classroom.TeacherId = Convert.ToInt32(data.Tables[Classroom.tableName].Rows[index][Classroom.columnTeacherId].ToString());
            classroom.StartDate = (DateTime)data.Tables[Classroom.tableName].Rows[index][Classroom.columnStartDate];
            classroom.ClassDayOfWeek = data.Tables[Classroom.tableName].Rows[index][Classroom.columnClassDayOfWeek].ToString();
            classroom.ClassTime = data.Tables[Classroom.tableName].Rows[index][Classroom.columnClassTime].ToString();
            classroom.Status = data.Tables[Classroom.tableName].Rows[index][Classroom.columnStatus].ToString();

            return classroom;
        }
    }
}
