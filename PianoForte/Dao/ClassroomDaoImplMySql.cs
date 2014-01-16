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
    public class ClassroomDaoImplMySql : ClassroomDao
    {
        private bool insert(string databaseName, Classroom classroom, string sql)
        {
            bool returnFlag = false;

            if (classroom != null)
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
                        command.Parameters.AddWithValue(Classrooms.ColumnEnrollmentId, classroom.EnrollmentId);
                        command.Parameters.AddWithValue(Classrooms.ColumnTeacherId, classroom.TeacherId);
                        command.Parameters.AddWithValue(Classrooms.ColumnClassroomStart, classroom.Start.ToString("yyyy-MM-dd HH:mm:ss"));
                        command.Parameters.AddWithValue(Classrooms.ColumnClassroomEnd, classroom.End.ToString("yyyy-MM-dd HH:mm:ss"));
                        command.Parameters.AddWithValue(Classrooms.ColumnClassroomStatus, (int)classroom.Status);

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

        private bool update(string databaseName, Classroom classroom, string sql)
        {
            bool returnFlag = false;

            if (classroom != null)
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
                        command.Parameters.AddWithValue(Classrooms.ColumnEnrollmentId, classroom.EnrollmentId);
                        command.Parameters.AddWithValue(Classrooms.ColumnTeacherId, classroom.TeacherId);
                        command.Parameters.AddWithValue(Classrooms.ColumnClassroomStart, classroom.Start.ToString("yyyy-MM-dd HH:mm:ss"));
                        command.Parameters.AddWithValue(Classrooms.ColumnClassroomEnd, classroom.End.ToString("yyyy-MM-dd HH:mm:ss"));
                        command.Parameters.AddWithValue(Classrooms.ColumnClassroomStatus, (int)classroom.Status);
                        command.Parameters.AddWithValue(Classrooms.ColumnClassroomId, classroom.Id);

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

        private List<Classroom> select(string databaseName, string sql)
        {
            List<Classroom> classroomList = new List<Classroom>();

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
                    dataAdapter.Fill(data, Classrooms.TableName);

                    for (int i = 0; i < data.Tables[Classrooms.TableName].Rows.Count; i++)
                    {
                        Classroom classroom = new Classroom();
                        classroom.Id = Convert.ToInt32(data.Tables[Classrooms.TableName].Rows[i][Classrooms.ColumnClassroomId].ToString());
                        classroom.EnrollmentId = Convert.ToInt32(data.Tables[Classrooms.TableName].Rows[i][Classrooms.ColumnEnrollmentId].ToString());
                        classroom.TeacherId = Convert.ToInt32(data.Tables[Classrooms.TableName].Rows[i][Classrooms.ColumnTeacherId].ToString());
                        classroom.Start = Convert.ToDateTime(data.Tables[Classrooms.TableName].Rows[i][Classrooms.ColumnClassroomStart].ToString());
                        classroom.End = Convert.ToDateTime(data.Tables[Classrooms.TableName].Rows[i][Classrooms.ColumnClassroomEnd].ToString());
                        classroom.Status = EnumConverter.ToStatus(data.Tables[Classrooms.TableName].Rows[i][Classrooms.ColumnClassroomStatus].ToString());

                        classroomList.Add(classroom);
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

            return classroomList;
        }

        public bool insertClassroom(string databaseName, Classroom classroom)
        {
            string sql = "INSERT INTO " +
                         Classrooms.TableName + " (" +
                         Classrooms.ColumnEnrollmentId + ", " +
                         Classrooms.ColumnTeacherId + ", " +
                         Classrooms.ColumnClassroomStart + ", " +
                         Classrooms.ColumnClassroomEnd + ", " +
                         Classrooms.ColumnClassroomStatus + ") " +
                         "VALUES(" +
                         "?" + Classrooms.ColumnEnrollmentId + ", " +
                         "?" + Classrooms.ColumnTeacherId + ", " +
                         "?" + Classrooms.ColumnClassroomStart + ", " +
                         "?" + Classrooms.ColumnClassroomEnd + ", " +
                         "?" + Classrooms.ColumnClassroomStatus + ")";

            return this.insert(databaseName, classroom, sql);
        }

        public bool updateClassroom(string databaseName, Classroom classroom)
        {
            string sql = "UPDATE " +
                         Classrooms.TableName + " SET " +
                         Classrooms.ColumnEnrollmentId + " = ?" + Classrooms.ColumnEnrollmentId + ", " +
                         Classrooms.ColumnTeacherId + " = ?" + Classrooms.ColumnTeacherId + ", " +
                         Classrooms.ColumnClassroomStart + " = ?" + Classrooms.ColumnClassroomStart + ", " +
                         Classrooms.ColumnClassroomEnd + " = ?" + Classrooms.ColumnClassroomEnd + ", " +
                         Classrooms.ColumnClassroomStatus + " = ?" + Classrooms.ColumnClassroomStatus + " " +
                         "WHERE " + Classrooms.ColumnClassroomId + " = ?" + Classrooms.ColumnClassroomId;

            return this.update(databaseName, classroom, sql);
        }
    }
}