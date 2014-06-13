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
    public class PaymentDetailDaoImplMySql : PaymentDetailDao
    {
        public bool insertPaymentDetail(PaymentDetail paymentDetail)
        {
            string sql = "INSERT INTO " +
                         PaymentDetail.tableName + " (" +
                         PaymentDetail.columnPaymentId + ", " +
                         PaymentDetail.columnProductId + ", " +
                         PaymentDetail.columnProductType + ", " +
                         PaymentDetail.columnProductName + ", " +
                         PaymentDetail.columnAmount + ", " +
                         PaymentDetail.columnDiscount + ", " +
                         PaymentDetail.columnProductPrice + ") " +
                         "VALUES(" +
                         "?" + PaymentDetail.columnPaymentId + ", " +
                         "?" + PaymentDetail.columnProductId + ", " +
                         "?" + PaymentDetail.columnProductType + ", " +
                         "?" + PaymentDetail.columnProductName + ", " +
                         "?" + PaymentDetail.columnAmount + ", " +
                         "?" + PaymentDetail.columnDiscount + ", " +
                         "?" + PaymentDetail.columnProductPrice + ")";

            return this.processInsertCommand(sql, paymentDetail);
        }

        public bool updatePaymentDetail(PaymentDetail paymentDetail)
        {
            string sql = "UPDATE " +
                         PaymentDetail.tableName + " SET " +
                         PaymentDetail.columnPaymentId + " = ?" + PaymentDetail.columnPaymentId + ", " +
                         PaymentDetail.columnPaymentId + " = ?" + PaymentDetail.columnPaymentId + ", " +
                         PaymentDetail.columnPaymentId + " = ?" + PaymentDetail.columnPaymentId + ", " +
                         PaymentDetail.columnPaymentId + " = ?" + PaymentDetail.columnPaymentId + ", " +
                         PaymentDetail.columnPaymentId + " = ?" + PaymentDetail.columnPaymentId + ", " +
                         PaymentDetail.columnPaymentId + " = ?" + PaymentDetail.columnPaymentId + ", " +
                         PaymentDetail.columnPaymentId + " = ?" + PaymentDetail.columnPaymentId + " " +
                         "WHERE " + PaymentDetail.columnPaymentDetailId + " = ?" + PaymentDetail.columnPaymentDetailId;

            return this.processUpdateCommand(sql, paymentDetail);
        }

        public bool deletePaymentDetail(int paymentId)
        {
            string sql = "DELETE " +
                         "FROM " + PaymentDetail.tableName + " " +
                         "WHERE " + PaymentDetail.columnPaymentId + " = " + paymentId;

            return this.processDeleteCommand(sql);
        }

        public PaymentDetail findLastPaymentDetail()
        {
            return null;
        }

        public List<PaymentDetail> findAllPaymentDetail(int paymentId)
        {
            string sql = "SELECT * " +
                         "FROM " + PaymentDetail.tableName + " " +
                         "WHERE " + PaymentDetail.columnPaymentId + " = " + paymentId;

            return this.processSelectCommand(sql);
        }

        private bool processInsertCommand(string sql, PaymentDetail paymentDetail)
        {
            bool returnFlag = false;

            if (paymentDetail != null)
            {
                MySqlConnection conn = null;
                try
                {
                    conn = new MySqlConnection(DatabaseManager.getMySqlConnectionString());
                    if (conn != null)
                    {
                        conn.Open();

                        MySqlCommand command = new MySqlCommand(sql, conn);
                        command.Parameters.AddWithValue(PaymentDetail.columnPaymentId, paymentDetail.PaymentId);
                        command.Parameters.AddWithValue(PaymentDetail.columnProductId, paymentDetail.Product.Id);
                        command.Parameters.AddWithValue(PaymentDetail.columnProductType, paymentDetail.Product.Type);
                        command.Parameters.AddWithValue(PaymentDetail.columnProductName, paymentDetail.Product.Name);
                        command.Parameters.AddWithValue(PaymentDetail.columnAmount, paymentDetail.Quantity);
                        command.Parameters.AddWithValue(PaymentDetail.columnDiscount, paymentDetail.Discount);
                        command.Parameters.AddWithValue(PaymentDetail.columnProductPrice, paymentDetail.Product.Price);

                        int affectedRow = command.ExecuteNonQuery();
                        if (affectedRow != -1)
                        {
                            returnFlag = true;
                        }
                    }
                }
                catch (System.InvalidOperationException invalidOperationException)
                {
                    LogManager.writeLog(invalidOperationException.Message);
                }
                catch (MySqlException mySqlException)
                {
                    LogManager.writeLog(mySqlException.Message);
                }
                catch (System.SystemException systemException)
                {
                    LogManager.writeLog(systemException.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
            
            return returnFlag;
        }

        private bool processUpdateCommand(string sql, PaymentDetail paymentDetail)
        {
            bool returnFlag = false;

            if (paymentDetail != null)
            {
                MySqlConnection conn = null;
                try
                {
                    conn = new MySqlConnection(DatabaseManager.getMySqlConnectionString());
                    if (conn != null)
                    {
                        conn.Open();

                        MySqlCommand command = new MySqlCommand(sql, conn);
                        command.Parameters.AddWithValue(PaymentDetail.columnPaymentId, paymentDetail.PaymentId);
                        command.Parameters.AddWithValue(PaymentDetail.columnProductId, paymentDetail.Product.Id);
                        command.Parameters.AddWithValue(PaymentDetail.columnProductType, paymentDetail.Product.Type);
                        command.Parameters.AddWithValue(PaymentDetail.columnProductName, paymentDetail.Product.Name);
                        command.Parameters.AddWithValue(PaymentDetail.columnAmount, paymentDetail.Quantity);
                        command.Parameters.AddWithValue(PaymentDetail.columnDiscount, paymentDetail.Discount);
                        command.Parameters.AddWithValue(PaymentDetail.columnProductPrice, paymentDetail.Product.Price);
                        command.Parameters.AddWithValue(PaymentDetail.columnPaymentDetailId, paymentDetail.Id);

                        int affectedRow = command.ExecuteNonQuery();
                        if (affectedRow != -1)
                        {
                            returnFlag = true;
                        }
                    }
                }
                catch (System.InvalidOperationException invalidOperationException)
                {
                    LogManager.writeLog(invalidOperationException.Message);
                }
                catch (MySqlException mySqlException)
                {
                    LogManager.writeLog(mySqlException.Message);
                }
                catch (System.SystemException systemException)
                {
                    LogManager.writeLog(systemException.Message);
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
            catch (System.InvalidOperationException invalidOperationException)
            {
                LogManager.writeLog(invalidOperationException.Message);
            }
            catch (MySqlException mySqlException)
            {
                LogManager.writeLog(mySqlException.Message);
            }
            catch (System.SystemException systemException)
            {
                LogManager.writeLog(systemException.Message);
            }
            finally
            {
                conn.Close();
            }
            
            return returnFlag;
        }

        private List<PaymentDetail> processSelectCommand(string sql)
        {
            List<PaymentDetail> paymentDetailList = new List<PaymentDetail>();

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
                    dataAdapter.Fill(data, PaymentDetail.tableName);

                    for (int i = 0; i < data.Tables[PaymentDetail.tableName].Rows.Count; i++)
                    {
                        paymentDetailList.Add(generatePaymentDetail(data, i));
                    }
                }
            }
            catch (System.InvalidOperationException invalidOperationException)
            {
                LogManager.writeLog(invalidOperationException.Message);
            }
            catch (MySqlException mySqlException)
            {
                LogManager.writeLog(mySqlException.Message);
            }
            catch (System.SystemException systemException)
            {
                LogManager.writeLog(systemException.Message);
            }
            finally
            {
                conn.Close();
            }

            return paymentDetailList;
        }

        private PaymentDetail generatePaymentDetail(DataSet data, int index)
        {
            PaymentDetail paymentDetail = new PaymentDetail();
            paymentDetail.Id = Convert.ToInt32(data.Tables[PaymentDetail.tableName].Rows[index][PaymentDetail.columnPaymentDetailId].ToString());
            paymentDetail.PaymentId = Convert.ToInt32(data.Tables[PaymentDetail.tableName].Rows[index][PaymentDetail.columnPaymentId].ToString());
            paymentDetail.Product.Id = Convert.ToInt32(data.Tables[PaymentDetail.tableName].Rows[index][PaymentDetail.columnProductId].ToString());
            paymentDetail.Product.Type = data.Tables[PaymentDetail.tableName].Rows[index][PaymentDetail.columnProductType].ToString();
            paymentDetail.Product.Name = data.Tables[PaymentDetail.tableName].Rows[index][PaymentDetail.columnProductName].ToString();
            paymentDetail.Quantity = Convert.ToInt32(data.Tables[PaymentDetail.tableName].Rows[index][PaymentDetail.columnAmount].ToString());
            paymentDetail.Discount = Convert.ToDouble(data.Tables[PaymentDetail.tableName].Rows[index][PaymentDetail.columnDiscount].ToString());
            paymentDetail.Product.Price = Convert.ToDouble(data.Tables[PaymentDetail.tableName].Rows[index][PaymentDetail.columnProductPrice].ToString());

            return paymentDetail;
        }
    }
}
