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
    public class EnrollmentDaoImplMySql : EnrollmentDao
    {
        private bool insert(string databaseName, Enrollment enrollment, string sql)
        {
            bool returnFlag = false;

            if (enrollment != null)
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
                        command.Parameters.AddWithValue(Enrollments.ColumnPaymentId, enrollment.PaymentId);
                        command.Parameters.AddWithValue(Enrollments.ColumnStudentId, enrollment.StudentId);
                        command.Parameters.AddWithValue(Enrollments.ColumnCourseId, enrollment.CourseId);
                        command.Parameters.AddWithValue(Enrollments.ColumnEnrollmentDate, enrollment.Date.ToString("yyyy-MM-dd HH:mm:ss"));
                        command.Parameters.AddWithValue(Enrollments.ColumnEnrollmentStatus, (int)enrollment.Status);

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

        private bool update(string databaseName, Enrollment enrollment, string sql)
        {
            bool returnFlag = false;

            if (enrollment != null)
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
                        command.Parameters.AddWithValue(Enrollments.ColumnPaymentId, enrollment.PaymentId);
                        command.Parameters.AddWithValue(Enrollments.ColumnStudentId, enrollment.StudentId);
                        command.Parameters.AddWithValue(Enrollments.ColumnCourseId, enrollment.CourseId);
                        command.Parameters.AddWithValue(Enrollments.ColumnEnrollmentDate, enrollment.Date.ToString("yyyy-MM-dd HH:mm:ss"));
                        command.Parameters.AddWithValue(Enrollments.ColumnEnrollmentStatus, (int)enrollment.Status);
                        command.Parameters.AddWithValue(Enrollments.ColumnEnrollmentId, enrollment.Id);

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

        private List<Enrollment> select(string databaseName, string sql)
        {
            List<Enrollment> enrollmentList = new List<Enrollment>();

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
                    dataAdapter.Fill(data, Enrollments.TableName);

                    for (int i = 0; i < data.Tables[Enrollments.TableName].Rows.Count; i++)
                    {
                        Enrollment enrollment = new Enrollment();
                        enrollment.Id = Convert.ToInt32(data.Tables[Enrollments.TableName].Rows[i][Enrollments.ColumnEnrollmentId].ToString());
                        enrollment.PaymentId = Convert.ToInt32(data.Tables[Enrollments.TableName].Rows[i][Enrollments.ColumnPaymentId].ToString());
                        enrollment.StudentId = Convert.ToInt32(data.Tables[Enrollments.TableName].Rows[i][Enrollments.ColumnStudentId].ToString());
                        enrollment.CourseId = Convert.ToInt32(data.Tables[Enrollments.TableName].Rows[i][Enrollments.ColumnCourseId].ToString());
                        enrollment.Date = Convert.ToDateTime(data.Tables[Enrollments.TableName].Rows[i][Enrollments.ColumnEnrollmentDate].ToString());
                        enrollment.Status = EnumConverter.ToStatus(data.Tables[Enrollments.TableName].Rows[i][Enrollments.ColumnEnrollmentStatus].ToString());

                        enrollmentList.Add(enrollment);
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

            return enrollmentList;
        }

        public bool insertEnrollment(string databaseName, Enrollment enrollment)
        {
            string sql = "INSERT INTO " +
                         Enrollments.TableName + " (" +
                         Enrollments.ColumnPaymentId + ", " +
                         Enrollments.ColumnStudentId + ", " +
                         Enrollments.ColumnCourseId + ", " +
                         Enrollments.ColumnEnrollmentDate + ", " +
                         Enrollments.ColumnEnrollmentStatus + ") " +
                         "VALUES(" +
                         "?" + Enrollments.ColumnPaymentId + ", " +
                         "?" + Enrollments.ColumnStudentId + ", " +
                         "?" + Enrollments.ColumnCourseId + ", " +
                         "?" + Enrollments.ColumnEnrollmentDate + ", " +
                         "?" + Enrollments.ColumnEnrollmentStatus + ")";

            return this.insert(databaseName, enrollment, sql);
        }

        public bool updateEnrollment(string databaseName, Enrollment enrollment)
        {
            string sql = "UPDATE " +
                         Enrollments.TableName + " SET " +
                         Enrollments.ColumnPaymentId + " = ?" + Enrollments.ColumnPaymentId + ", " +
                         Enrollments.ColumnStudentId + " = ?" + Enrollments.ColumnStudentId + ", " +
                         Enrollments.ColumnCourseId + " = ?" + Enrollments.ColumnCourseId + ", " +
                         Enrollments.ColumnEnrollmentDate + " = ?" + Enrollments.ColumnEnrollmentDate + ", " +
                         Enrollments.ColumnEnrollmentStatus + " = ?" + Enrollments.ColumnEnrollmentStatus + " " +
                         "WHERE " + Enrollments.ColumnEnrollmentId + " = ?" + Enrollments.ColumnEnrollmentId;

            return this.update(databaseName, enrollment, sql);
        }
    }
}