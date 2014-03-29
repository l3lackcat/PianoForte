using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MySql.Data.MySqlClient;
using System.Data;

using PianoForte.Dao;
using PianoForte.Model;

namespace PianoForte.Dao.MySql
{
    public class BookOrderDetailDaoImplMySql : BookOrderDetailDao
    {        
        public bool insertBookOrderDetail(BookOrderDetail bookOrderDetail)
        {
            string sql = "INSERT INTO " +
                         BookOrderDetail.tableName + " (" +
                         BookOrderDetail.columnPaymentId + ", " +
                         BookOrderDetail.columnStudentId + ", " +
                         BookOrderDetail.columnBookId + ", " +
                         BookOrderDetail.columnAmount + ", " +
                         BookOrderDetail.columnTotalPrice + ", " +
                         BookOrderDetail.columnOrderDate + ", " +
                         BookOrderDetail.columnStatus + ") " +
                         "VALUES(" +
                         "?" + BookOrderDetail.columnPaymentId + ", " +
                         "?" + BookOrderDetail.columnStudentId + ", " +
                         "?" + BookOrderDetail.columnBookId + ", " +
                         "?" + BookOrderDetail.columnAmount + ", " +
                         "?" + BookOrderDetail.columnTotalPrice + ", " +
                         "?" + BookOrderDetail.columnOrderDate + ", " +
                         "?" + BookOrderDetail.columnStatus + ")";

            return this.processInsertCommand(sql, bookOrderDetail);
        }

        public bool updateBookOrderDetail(BookOrderDetail bookOrderDetail)
        {
            string sql = "UPDATE " +
                         BookOrderDetail.tableName + " SET " +
                         BookOrderDetail.columnPaymentId + " = ?" + BookOrderDetail.columnPaymentId + ", " +
                         BookOrderDetail.columnStudentId + " = ?" + BookOrderDetail.columnStudentId + ", " +
                         BookOrderDetail.columnBookId + " = ?" + BookOrderDetail.columnBookId + ", " +
                         BookOrderDetail.columnAmount + " = ?" + BookOrderDetail.columnAmount + ", " +
                         BookOrderDetail.columnTotalPrice + " = ?" + BookOrderDetail.columnTotalPrice + ", " +
                         BookOrderDetail.columnOrderDate + " = ?" + BookOrderDetail.columnOrderDate + ", " +
                         BookOrderDetail.columnStatus + " = ?" + BookOrderDetail.columnStatus + ", " +
                         "WHERE " + BookOrderDetail.columnBookOrderDetailId + " = ?" + BookOrderDetail.columnBookOrderDetailId;

            return this.processUpdateCommand(sql, bookOrderDetail);
        }

        public bool deleteBookOrderDetail(int bookOrderDetailId)
        {
            string sql = "DELETE " +
                         "FROM " + BookOrderDetail.tableName + " " +
                         "WHERE " + BookOrderDetail.columnBookOrderDetailId + " = " + bookOrderDetailId;

            return this.processDeleteCommand(sql);
        }

        public BookOrderDetail findLastBookOrderDetail()
        {
            BookOrderDetail bookOrderDetail = null;

            string sql = "SELECT * " +
                         "FROM " + BookOrderDetail.tableName + " " +
                         "ORDER BY " + BookOrderDetail.columnBookOrderDetailId + " DESC " +
                         "LIMIT 1";

            List<BookOrderDetail> bookOrderDetailList = this.processSelectCommand(sql);
            if (bookOrderDetailList.Count > 0)
            {
                bookOrderDetail = bookOrderDetailList[0];
            }

            return bookOrderDetail;
        }

        public BookOrderDetail findBookOrderDetail(int bookOrderDetailId)
        {
            BookOrderDetail bookOrderDetail = null;

            string sql = "SELECT * " +
                         "FROM " + BookOrderDetail.tableName + " " +
                         "WHERE " + BookOrderDetail.columnBookOrderDetailId + " = " + bookOrderDetailId;

            List<BookOrderDetail> bookOrderDetailList = this.processSelectCommand(sql);
            if (bookOrderDetailList.Count > 0)
            {
                bookOrderDetail = bookOrderDetailList[0];
            }

            return bookOrderDetail;
        }

        public List<BookOrderDetail> findAllBookOrderDetail()
        {
            string sql = "SELECT * " +
                         "FROM " + BookOrderDetail.tableName + " " +
                         "ORDER BY " + BookOrderDetail.columnBookOrderDetailId + " ASC";

            return this.processSelectCommand(sql);
        }

        public List<BookOrderDetail> findAllBookOrderDetailByPaymentId(int paymentId)
        {
            string sql = "SELECT * " +
                         "FROM " + BookOrderDetail.tableName + " " +
                         "WHERE " + BookOrderDetail.columnPaymentId + " = " + paymentId + " " +
                         "ORDER BY " + BookOrderDetail.columnBookOrderDetailId + " ASC";

            return this.processSelectCommand(sql);
        }

        public List<BookOrderDetail> findAllBookOrderDetailByStudentId(int studentId)
        {
            string sql = "SELECT * " +
                         "FROM " + BookOrderDetail.tableName + " " +
                         "WHERE " + BookOrderDetail.columnStudentId + " = " + studentId + " " +
                         "ORDER BY " + BookOrderDetail.columnBookOrderDetailId + " ASC";

            return this.processSelectCommand(sql);
        }

        public List<BookOrderDetail> findAllBookOrderDetailByDate(DateTime startDate, DateTime endDate)
        {
            string sql = "SELECT * " +
                         "FROM " + BookOrderDetail.tableName + " " +
                         "WHERE " + BookOrderDetail.columnOrderDate + " >= '" + startDate.ToString(DatabaseManager.DATABASE_DATE_FORMAT) + "' " +
                         "AND " + BookOrderDetail.columnOrderDate + " <= '" + endDate.ToString(DatabaseManager.DATABASE_DATE_FORMAT) + "' " +
                         "ORDER BY " + BookOrderDetail.columnBookOrderDetailId + " ASC";

            return this.processSelectCommand(sql);
        }

        private bool processInsertCommand(string sql, BookOrderDetail bookOrderDetail)
        {
            bool returnFlag = false;

            if (bookOrderDetail != null)
            {
                MySqlConnection conn = null;
                try
                {
                    conn = DatabaseManager.ConnectDatabase();
                    if (conn != null)
                    {
                        conn.Open();

                        MySqlCommand command = new MySqlCommand(sql, conn);
                        command.Parameters.Add(BookOrderDetail.columnPaymentId, bookOrderDetail.PaymentId);
                        command.Parameters.Add(BookOrderDetail.columnStudentId, bookOrderDetail.CustomerId);
                        command.Parameters.Add(BookOrderDetail.columnBookId, bookOrderDetail.LearningMaterialId);
                        command.Parameters.Add(BookOrderDetail.columnAmount, bookOrderDetail.Amount);
                        command.Parameters.Add(BookOrderDetail.columnTotalPrice, bookOrderDetail.TotalPrice);
                        command.Parameters.Add(BookOrderDetail.columnOrderDate, bookOrderDetail.OrderDate);
                        command.Parameters.Add(BookOrderDetail.columnStatus, bookOrderDetail.Status);

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

        private bool processUpdateCommand(string sql, BookOrderDetail bookOrderDetail)
        {
            bool returnFlag = false;

            if (bookOrderDetail != null)
            {
                MySqlConnection conn = null;
                try
                {
                    conn = DatabaseManager.ConnectDatabase();
                    if (conn != null)
                    {
                        conn.Open();

                        MySqlCommand command = new MySqlCommand(sql, conn);
                        command.Parameters.Add(BookOrderDetail.columnPaymentId, bookOrderDetail.PaymentId);
                        command.Parameters.Add(BookOrderDetail.columnStudentId, bookOrderDetail.CustomerId);
                        command.Parameters.Add(BookOrderDetail.columnBookId, bookOrderDetail.LearningMaterialId);
                        command.Parameters.Add(BookOrderDetail.columnAmount, bookOrderDetail.Amount);
                        command.Parameters.Add(BookOrderDetail.columnTotalPrice, bookOrderDetail.TotalPrice);
                        command.Parameters.Add(BookOrderDetail.columnOrderDate, bookOrderDetail.OrderDate);
                        command.Parameters.Add(BookOrderDetail.columnStatus, bookOrderDetail.Status);
                        command.Parameters.Add(BookOrderDetail.columnBookOrderDetailId, bookOrderDetail.Id);

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
                conn = DatabaseManager.ConnectDatabase();
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

        private List<BookOrderDetail> processSelectCommand(string sql)
        {
            List<BookOrderDetail> bookOrderDetailList = new List<BookOrderDetail>();

            MySqlConnection conn = null;
            try
            {
                conn = DatabaseManager.ConnectDatabase();
                if (conn != null)
                {
                    conn.Open();
                    MySqlCommand command = new MySqlCommand(sql, conn);
                    MySqlDataAdapter dataAdapter = new MySqlDataAdapter(command);

                    DataSet data = new DataSet();
                    dataAdapter.Fill(data, BookOrderDetail.tableName);

                    for (int i = 0; i < data.Tables[BookOrderDetail.tableName].Rows.Count; i++)
                    {
                        bookOrderDetailList.Add(generateBookOrderDetail(data, i));
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

            return bookOrderDetailList;
        }

        private BookOrderDetail generateBookOrderDetail(DataSet data, int index)
        {
            BookOrderDetail bookOrderDetail = new BookOrderDetail();
            bookOrderDetail.Id = Convert.ToInt32(data.Tables[BookOrderDetail.tableName].Rows[index][BookOrderDetail.columnBookOrderDetailId].ToString());
            bookOrderDetail.PaymentId = Convert.ToInt32(data.Tables[BookOrderDetail.tableName].Rows[index][BookOrderDetail.columnPaymentId].ToString());
            bookOrderDetail.CustomerId = Convert.ToInt32(data.Tables[BookOrderDetail.tableName].Rows[index][BookOrderDetail.columnStudentId].ToString());
            bookOrderDetail.LearningMaterialId = Convert.ToInt32(data.Tables[BookOrderDetail.tableName].Rows[index][BookOrderDetail.columnBookId].ToString());
            bookOrderDetail.Amount = Convert.ToInt32(data.Tables[BookOrderDetail.tableName].Rows[index][BookOrderDetail.columnAmount].ToString());
            bookOrderDetail.TotalPrice = Convert.ToDouble(data.Tables[BookOrderDetail.tableName].Rows[index][BookOrderDetail.columnTotalPrice].ToString());
            bookOrderDetail.OrderDate = (DateTime)data.Tables[BookOrderDetail.tableName].Rows[index][BookOrderDetail.columnOrderDate];
            bookOrderDetail.Status = data.Tables[BookOrderDetail.tableName].Rows[index][BookOrderDetail.columnStatus].ToString();            

            return bookOrderDetail;
        }
    }
}
