using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;

using MySql.Data.MySqlClient;

using PianoForte.Enum;
using PianoForte.Models;
using PianoForte.Resourses.DatabaseStructure.MySqlTable;

namespace PianoForte.Dao
{
    public class PaymentDaoImplMySql : PaymentDao
    {
        private bool insert(string databaseName, Payment payment, string sql)
        {
            bool returnFlag = false;

            if (payment != null)
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
                        command.Parameters.AddWithValue(Payments.ColumnStudentId, payment.StudentId);
                        command.Parameters.AddWithValue(Payments.ColumnReceiverId, payment.ReceiverId);
                        command.Parameters.AddWithValue(Payments.ColumnPaymentDate, payment.Date.ToString("yyyy-MM-dd"));
                        command.Parameters.AddWithValue(Payments.ColumnPaymentStatus, (int)payment.Status);

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

        private bool update(string databaseName, Payment payment, string sql)
        {
            bool returnFlag = false;

            if (payment != null)
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
                        command.Parameters.AddWithValue(Payments.ColumnStudentId, payment.StudentId);
                        command.Parameters.AddWithValue(Payments.ColumnReceiverId, payment.ReceiverId);
                        command.Parameters.AddWithValue(Payments.ColumnPaymentDate, payment.Date.ToString("yyyy-MM-dd"));
                        command.Parameters.AddWithValue(Payments.ColumnPaymentStatus, (int)payment.Status);
                        command.Parameters.AddWithValue(Payments.ColumnPaymentId, payment.Id);

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

        private List<Payment> select(string databaseName, string sql)
        {
            List<Payment> paymentList = new List<Payment>();

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
                    dataAdapter.Fill(data, Payments.TableName);

                    for (int i = 0; i < data.Tables[Payments.TableName].Rows.Count; i++)
                    {
                        Payment payment = new Payment();
                        payment.Id = Convert.ToInt32(data.Tables[Payments.TableName].Rows[i][Payments.ColumnPaymentId].ToString());
                        payment.StudentId = Convert.ToInt32(data.Tables[Payments.TableName].Rows[i][Payments.ColumnStudentId].ToString());
                        payment.ReceiverId = Convert.ToInt32(data.Tables[Payments.TableName].Rows[i][Payments.ColumnReceiverId].ToString());
                        payment.Date = Convert.ToDateTime(data.Tables[Payments.TableName].Rows[i][Payments.ColumnPaymentDate].ToString());
                        payment.Status = EnumConverter.ToStatus(data.Tables[Payments.TableName].Rows[i][Payments.ColumnPaymentStatus].ToString());

                        paymentList.Add(payment);
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

            return paymentList;
        }

        public bool insertPayment(string databaseName, Payment payment)
        {
            string sql = "INSERT INTO " +
                         Payments.TableName + " (" +
                         Payments.ColumnStudentId + ", " +
                         Payments.ColumnReceiverId + ", " +
                         Payments.ColumnPaymentDate + ", " +
                         Payments.ColumnPaymentStatus + ") " +
                         "VALUES(" +
                         "?" + Payments.ColumnStudentId + ", " +
                         "?" + Payments.ColumnReceiverId + ", " +
                         "?" + Payments.ColumnPaymentDate + ", " +
                         "?" + Payments.ColumnPaymentStatus + ")";

            return this.insert(databaseName, payment, sql);
        }

        public bool updatePayment(string databaseName, Payment payment)
        {
            string sql = "UPDATE " +
                         Payments.TableName + " SET " +
                         Payments.ColumnStudentId + " = ?" + Payments.ColumnStudentId + ", " +
                         Payments.ColumnReceiverId + " = ?" + Payments.ColumnReceiverId + ", " +
                         Payments.ColumnPaymentDate + " = ?" + Payments.ColumnPaymentDate + ", " +
                         Payments.ColumnPaymentStatus + " = ?" + Payments.ColumnPaymentStatus + " " +
                         "WHERE " + Payments.ColumnPaymentId + " = ?" + Payments.ColumnPaymentId;

            return this.update(databaseName, payment, sql);
        }

        public List<Payment> getPaymentList(string databaseName, int paymentId)
        {
            string sql = "SELECT * " +
                         "FROM " + Payments.TableName + " " +
                         "WHERE " + Payments.ColumnPaymentId + " = " + paymentId;

            return this.select(databaseName, sql);
        }

        public List<Payment> getPaymentList(string databaseName, int startIndex, int offset)
        {
            string sql = "SELECT * " +
                         "FROM " + Payments.TableName + " " +
                         "ORDER BY " + Payments.ColumnPaymentId + " ASC " +
                         "LIMIT " + startIndex + "," + offset;

            return this.select(databaseName, sql);
        }

        public List<Payment> getPaymentList(string databaseName, int startIndex, int offset, Status status)
        {
            string sql = "SELECT * " +
                         "FROM " + Payments.TableName + " " +
                         "WHERE " + Payments.ColumnPaymentStatus + " = " + (int)status + " " +
                         "ORDER BY " + Payments.ColumnPaymentId + " ASC " +
                         "LIMIT " + startIndex + "," + offset;

            return this.select(databaseName, sql);
        }

        public List<Payment> getPaymentList(string databaseName, int startIndex, int offset, int studentId)
        {
            string sql = "SELECT * " +
                         "FROM " + Payments.TableName + " " +
                         "WHERE " + Payments.ColumnStudentId + " = " + studentId + " " +
                         "ORDER BY " + Payments.ColumnPaymentId + " ASC " +
                         "LIMIT " + startIndex + "," + offset;

            return this.select(databaseName, sql);
        }

        public List<Payment> getPaymentList(string databaseName, int startIndex, int offset, int studentId, Status status)
        {
            string sql = "SELECT * " +
                         "FROM " + Payments.TableName + " " +
                         "WHERE " + Payments.ColumnStudentId + " = " + studentId + " " +
                         "AND " + Payments.ColumnPaymentStatus + " = " + (int)status + " " +
                         "ORDER BY " + Payments.ColumnPaymentId + " ASC " +
                         "LIMIT " + startIndex + "," + offset;

            return this.select(databaseName, sql);
        }        

        public List<Payment> getPaymentList(string databaseName, int startIndex, int offset, int studentId, DateTime startDate, DateTime endDate)
        {
            string sql = "SELECT * " +
                         "FROM " + Payments.TableName + " " +
                         "WHERE " + Payments.ColumnStudentId + " = " + studentId + " " +
                         "AND " + Payments.ColumnPaymentDate + " >= '" + startDate.ToString("yyyy-MM-dd") + "' " +
                         "AND " + Payments.ColumnPaymentDate + " <= '" + endDate.ToString("yyyy-MM-dd") + "' " +
                         "ORDER BY " + Payments.ColumnPaymentId + " ASC " +
                         "LIMIT " + startIndex + "," + offset;

            return this.select(databaseName, sql);
        }

        public List<Payment> getPaymentList(string databaseName, int startIndex, int offset, int studentId, DateTime startDate, DateTime endDate, Status status)
        {
            string sql = "SELECT * " +
                         "FROM " + Payments.TableName + " " +
                         "WHERE " + Payments.ColumnStudentId + " = " + studentId + " " +
                         "AND " + Payments.ColumnPaymentDate + " >= '" + startDate.ToString("yyyy-MM-dd") + "' " +
                         "AND " + Payments.ColumnPaymentDate + " <= '" + endDate.ToString("yyyy-MM-dd") + "' " +
                         "AND " + Payments.ColumnPaymentStatus + " = " + (int)status + " " +
                         "ORDER BY " + Payments.ColumnPaymentId + " ASC " +
                         "LIMIT " + startIndex + "," + offset;

            return this.select(databaseName, sql);
        }

        public List<Payment> getPaymentList(string databaseName, int startIndex, int offset, DateTime startDate, DateTime endDate)
        {
            string sql = "SELECT * " +
                         "FROM " + Payments.TableName + " " +
                         "WHERE " + Payments.ColumnPaymentDate + " >= '" + startDate.ToString("yyyy-MM-dd") + "' " +
                         "AND " + Payments.ColumnPaymentDate + " <= '" + endDate.ToString("yyyy-MM-dd") + "' " +
                         "ORDER BY " + Payments.ColumnPaymentId + " ASC " +
                         "LIMIT " + startIndex + "," + offset;

            return this.select(databaseName, sql);
        }

        public List<Payment> getPaymentList(string databaseName, int startIndex, int offset, DateTime startDate, DateTime endDate, Status status)
        {
            string sql = "SELECT * " +
                         "FROM " + Payments.TableName + " " +
                         "WHERE " + Payments.ColumnPaymentDate + " >= '" + startDate.ToString("yyyy-MM-dd") + "' " +
                         "AND " + Payments.ColumnPaymentDate + " <= '" + endDate.ToString("yyyy-MM-dd") + "' " +
                         "AND " + Payments.ColumnPaymentStatus + " = " + (int)status + " " +
                         "ORDER BY " + Payments.ColumnPaymentId + " ASC " +
                         "LIMIT " + startIndex + "," + offset;

            return this.select(databaseName, sql);
        }
    }
}