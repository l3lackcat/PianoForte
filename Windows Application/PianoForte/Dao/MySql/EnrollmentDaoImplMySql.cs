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
    public class EnrollmentDaoImplMySql : EnrollmentDao
    {
        public bool insertEnrollment(Enrollment enrollment)
        {
            string sql = "INSERT INTO " +
                         Enrollment.tableName + " (" +
                         Enrollment.columnPaymentId + ", " +
                         Enrollment.columnStudentId + ", " +
                         Enrollment.columnCourseId + ", " +
                         Enrollment.columnEnrollmentDate + ", " +
                         Enrollment.columnStatus + ") " +
                         "VALUES(" +
                         "?" + Enrollment.columnPaymentId + ", " +
                         "?" + Enrollment.columnStudentId + ", " +
                         "?" + Enrollment.columnCourseId + ", " +
                         "?" + Enrollment.columnEnrollmentDate + ", " +
                         "?" + Enrollment.columnStatus + ")";

            return this.processInsertCommand(sql, enrollment);
        }

        public bool updateEnrollment(Enrollment enrollment)
        {
            string sql = "UPDATE " +
                         Enrollment.tableName + " SET " +
                         Enrollment.columnPaymentId + " = ?" + Enrollment.columnPaymentId + ", " +
                         Enrollment.columnStudentId + " = ?" + Enrollment.columnStudentId + ", " +
                         Enrollment.columnCourseId + " = ?" + Enrollment.columnCourseId + ", " +
                         Enrollment.columnEnrollmentDate + " = ?" + Enrollment.columnEnrollmentDate + ", " +
                         Enrollment.columnStatus + " = ?" + Enrollment.columnStatus + " " +
                         "WHERE " + Enrollment.columnEnrollmentId + " = ?" + Enrollment.columnEnrollmentId;

            return this.processUpdateCommand(sql, enrollment);
        }

        public bool deleteEnrollment(int enrollmentId)
        {
            string sql = "DELETE " +
                         "FROM " + Enrollment.tableName + " " +
                         "WHERE " + Enrollment.columnEnrollmentId + " = " + enrollmentId;

            return this.processDeleteCommand(sql);
        }

        public Enrollment findLastEnrollment()
        {
            Enrollment enrollment = null;

            string sql = "SELECT * " +
                         "FROM " + Enrollment.tableName + " " +
                         "ORDER BY " + Enrollment.columnEnrollmentId + " DESC " +
                         "LIMIT 1";

            List<Enrollment> enrollmentList = this.processSelectCommand(sql);
            if (enrollmentList.Count > 0)
            {
                enrollment = enrollmentList[0];
            }

            return enrollment;
        }

        public Enrollment findEnrollment(int enrollmentId)
        {
            Enrollment enrollment = null;

            string sql = "SELECT * " +
                         "FROM " + Enrollment.tableName + " " +
                         "WHERE " + Enrollment.columnEnrollmentId + " = " + enrollmentId;

            List<Enrollment> enrollmentList = this.processSelectCommand(sql);
            if (enrollmentList.Count > 0)
            {
                enrollment = enrollmentList[0];
            }

            return enrollment;
        }

        public Enrollment findEnrollmentByPaymentId(int paymentId)
        {
            Enrollment enrollment = null;

            string sql = "SELECT * " +
                         "FROM " + Enrollment.tableName + " " +
                         "WHERE " + Enrollment.columnPaymentId + " = " + paymentId;

            List<Enrollment> enrollmentList = this.processSelectCommand(sql);
            if (enrollmentList.Count > 0)
            {
                enrollment = enrollmentList[0];
            }

            return enrollment;
        }

        public List<Enrollment> findAllEnrollment()
        {
            string sql = "SELECT * " +
                         "FROM " + Enrollment.tableName + " " +
                         "ORDER BY " + Enrollment.columnEnrollmentId + " ASC";

            return this.processSelectCommand(sql);
        }

        public List<Enrollment> findAllEnrollmentByPaymentId(int paymentId)
        {
            string sql = "SELECT * " +
                         "FROM " + Enrollment.tableName + " " +
                         "WHERE " + Enrollment.columnPaymentId + " = " + paymentId + " " +
                         "ORDER BY " + Enrollment.columnEnrollmentId + " ASC";

            return this.processSelectCommand(sql);
        }

        public List<Enrollment> findAllEnrollmentByStudentId(int studentId)
        {
            string sql = "SELECT * " +
                         "FROM " + Enrollment.tableName + " " +
                         "WHERE " + Enrollment.columnStudentId + " = " + studentId + " " +
                         "ORDER BY " + Enrollment.columnEnrollmentId + " ASC";

            return this.processSelectCommand(sql);
        }

        public List<Enrollment> findAllEnrollmentByStudentId(int studentId, Enrollment.EnrollmentStatus status)
        {
            string sql = "SELECT * " +
                         "FROM " + Enrollment.tableName + " " +
                         "WHERE " + Enrollment.columnStudentId + " = " + studentId + " " +
                         "AND " + Enrollment.columnStatus + " = '" + status.ToString() + "' " +
                         "ORDER BY " + Enrollment.columnEnrollmentId + " ASC";

            return this.processSelectCommand(sql);
        }

        public List<Enrollment> findAllEnrollmentByCourseId(int courseId)
        {
            string sql = "SELECT * " +
                         "FROM " + Enrollment.tableName + " " +
                         "WHERE " + Enrollment.columnCourseId + " = " + courseId + " " +
                         "ORDER BY " + Enrollment.columnEnrollmentId + " ASC";

            return this.processSelectCommand(sql);
        }

        public List<Enrollment> findAllEnrollmentByCourseId(int courseId, Enrollment.EnrollmentStatus status)
        {
            string sql = "SELECT * " +
                         "FROM " + Enrollment.tableName + " " +
                         "WHERE " + Enrollment.columnCourseId + " = " + courseId + " " +
                         "AND " + Enrollment.columnStatus + " = '" + status.ToString() + "' " +
                         "ORDER BY " + Enrollment.columnEnrollmentId + " ASC";

            return this.processSelectCommand(sql);
        }

        public List<Enrollment> findAllEnrollmentByDate(DateTime startDate, DateTime endDate)
        {
            string sql = "SELECT * " +
                         "FROM " + Enrollment.tableName + " " +
                         "WHERE " + Enrollment.columnEnrollmentDate + " >= '" + startDate.ToString(DatabaseManager.DATABASE_DATE_FORMAT) + "' " +
                         "AND " + Enrollment.columnEnrollmentDate + " <= '" + endDate.ToString(DatabaseManager.DATABASE_DATE_FORMAT) + "' " +
                         "ORDER BY " + Enrollment.columnEnrollmentId + " ASC";

            return this.processSelectCommand(sql);
        }

        public List<Enrollment> findAllEnrollmentByDate(DateTime startDate, DateTime endDate, Enrollment.EnrollmentStatus status)
        {
            string sql = "SELECT * " +
                         "FROM " + Enrollment.tableName + " " +
                         "WHERE " + Enrollment.columnEnrollmentDate + " >= '" + startDate.ToString(DatabaseManager.DATABASE_DATE_FORMAT) + "' " +
                         "AND " + Enrollment.columnEnrollmentDate + " <= '" + endDate.ToString(DatabaseManager.DATABASE_DATE_FORMAT) + "' " +
                         "AND " + Enrollment.columnStatus + " = '" + status.ToString() + "' " +
                         "ORDER BY " + Enrollment.columnEnrollmentId + " ASC";

            return this.processSelectCommand(sql);
        }

        private bool processInsertCommand(string sql, Enrollment enrollment)
        {
            bool returnFlag = false;
            
            if (enrollment != null)
            {
                MySqlConnection conn = null;
                try
                {
                    conn = new MySqlConnection(DatabaseManager.getMySqlConnectionString());
                    if (conn != null)
                    {
                        conn.Open();

                        MySqlCommand command = new MySqlCommand(sql, conn);
                        command.Parameters.AddWithValue(Enrollment.columnPaymentId, enrollment.PaymentId);
                        command.Parameters.AddWithValue(Enrollment.columnStudentId, enrollment.Student.Id);
                        command.Parameters.AddWithValue(Enrollment.columnCourseId, enrollment.Course.Id);
                        command.Parameters.AddWithValue(Enrollment.columnEnrollmentDate, enrollment.EnrolledDate);
                        command.Parameters.AddWithValue(Enrollment.columnStatus, enrollment.Status); 

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

        private bool processUpdateCommand(string sql, Enrollment enrollment)
        {
            bool returnFlag = false;
            
            if (enrollment != null)
            {
                MySqlConnection conn = null;
                try
                {
                    conn = new MySqlConnection(DatabaseManager.getMySqlConnectionString());
                    if (conn != null)
                    {
                        conn.Open();

                        MySqlCommand command = new MySqlCommand(sql, conn);
                        command.Parameters.AddWithValue(Enrollment.columnPaymentId, enrollment.PaymentId);
                        command.Parameters.AddWithValue(Enrollment.columnStudentId, enrollment.Student.Id);
                        command.Parameters.AddWithValue(Enrollment.columnCourseId, enrollment.Course.Id);
                        command.Parameters.AddWithValue(Enrollment.columnEnrollmentDate, enrollment.EnrolledDate);
                        command.Parameters.AddWithValue(Enrollment.columnStatus, enrollment.Status);
                        command.Parameters.AddWithValue(Enrollment.columnEnrollmentId, enrollment.Id);

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

        private List<Enrollment> processSelectCommand(string sql)
        {
            List<Enrollment> enrollmentList = new List<Enrollment>();

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
                    dataAdapter.Fill(data, Enrollment.tableName);

                    for (int i = 0; i < data.Tables[Enrollment.tableName].Rows.Count; i++)
                    {
                        enrollmentList.Add(generateEnrollment(data, i));
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

        private Enrollment generateEnrollment(DataSet data, int index)
        {
            Enrollment enrollment = new Enrollment();
            enrollment.Id = Convert.ToInt32(data.Tables[Enrollment.tableName].Rows[index][Enrollment.columnEnrollmentId].ToString());
            enrollment.PaymentId = Convert.ToInt32(data.Tables[Enrollment.tableName].Rows[index][Enrollment.columnPaymentId].ToString());
            enrollment.Student.Id = Convert.ToInt32(data.Tables[Enrollment.tableName].Rows[index][Enrollment.columnStudentId].ToString());
            enrollment.Course.Id = Convert.ToInt32(data.Tables[Enrollment.tableName].Rows[index][Enrollment.columnCourseId].ToString());
            enrollment.EnrolledDate = (DateTime)data.Tables[Enrollment.tableName].Rows[index][Enrollment.columnEnrollmentDate];
            enrollment.Status = data.Tables[Enrollment.tableName].Rows[index][Enrollment.columnStatus].ToString();

            return enrollment;
        }

        public List<Enrollment> processQueryString_old(string sql)
        {
            List<Enrollment> enrollmentList = new List<Enrollment>();
            
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
                    dataAdapter.Fill(data, Enrollment.tableName);

                    for (int i = 0; i < data.Tables[Enrollment.tableName].Rows.Count; i++)
                    {
                        enrollmentList.Add(generateEnrollment_old(data, i));
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

        private Enrollment generateEnrollment_old(DataSet data, int index)
        {
            Enrollment enrollment = new Enrollment();
            enrollment.Id = Convert.ToInt32(data.Tables[Enrollment.tableName].Rows[index][Enrollment.columnEnrollmentId].ToString());
            enrollment.PaymentId = Convert.ToInt32(data.Tables[Enrollment.tableName].Rows[index][Enrollment.columnPaymentId].ToString());
            enrollment.Student.Id = Convert.ToInt32(data.Tables[Enrollment.tableName].Rows[index][Enrollment.columnStudentId].ToString());
            enrollment.Course.Id = Convert.ToInt32(data.Tables[Enrollment.tableName].Rows[index][Enrollment.columnCourseId].ToString());
            enrollment.EnrolledDate = (DateTime)data.Tables[Enrollment.tableName].Rows[index][Enrollment.columnEnrollmentDate];
            enrollment.CourseFee = Convert.ToDouble(data.Tables[Enrollment.tableName].Rows[index][Enrollment.columnCourseFee].ToString());
            enrollment.Discount = Convert.ToDouble(data.Tables[Enrollment.tableName].Rows[index][Enrollment.columnDiscount].ToString());
            enrollment.TotalPrice = Convert.ToDouble(data.Tables[Enrollment.tableName].Rows[index][Enrollment.columnTotalPrice].ToString());
            enrollment.Status = data.Tables[Enrollment.tableName].Rows[index][Enrollment.columnStatus].ToString();

            return enrollment;
        }
    }
}
