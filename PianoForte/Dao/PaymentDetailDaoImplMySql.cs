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
    public class PaymentDetailDaoImplMySql : PaymentDetailDao
    {
        private bool insert(string databaseName, PaymentDetail paymentDetail, string sql)
        {
            bool returnFlag = false;

            if (paymentDetail != null)
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
                        command.Parameters.AddWithValue(PaymentDetails.ColumnPaymentId, paymentDetail.PaymentId);
                        command.Parameters.AddWithValue(PaymentDetails.ColumnProductId, paymentDetail.Product.Id);
                        command.Parameters.AddWithValue(PaymentDetails.ColumnProductType, (int)paymentDetail.Product.Type);
                        command.Parameters.AddWithValue(PaymentDetails.ColumnProductName, paymentDetail.Product.Name);
                        command.Parameters.AddWithValue(PaymentDetails.ColumnProductUnitPrice, paymentDetail.Product.UnitPrice);
                        command.Parameters.AddWithValue(PaymentDetails.ColumnProductQuantity, paymentDetail.Quantity);
                        command.Parameters.AddWithValue(PaymentDetails.ColumnDiscount, paymentDetail.Discount);

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

        private List<PaymentDetail> select(string databaseName, string sql)
        {
            List<PaymentDetail> paymentDetailList = new List<PaymentDetail>();

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
                    dataAdapter.Fill(data, PaymentDetails.TableName);

                    for (int i = 0; i < data.Tables[PaymentDetails.TableName].Rows.Count; i++)
                    {
                        PaymentDetail paymentDetail = new PaymentDetail();
                        paymentDetail.Id = Convert.ToInt32(data.Tables[PaymentDetails.TableName].Rows[i][PaymentDetails.ColumnPaymentDetailId].ToString());
                        paymentDetail.PaymentId = Convert.ToInt32(data.Tables[PaymentDetails.TableName].Rows[i][PaymentDetails.ColumnPaymentId].ToString());
                        paymentDetail.Product.Id = Convert.ToInt32(data.Tables[PaymentDetails.TableName].Rows[i][PaymentDetails.ColumnProductId].ToString());
                        paymentDetail.Product.Type = EnumConverter.ToProductType(data.Tables[PaymentDetails.TableName].Rows[i][PaymentDetails.ColumnProductType].ToString());
                        paymentDetail.Product.Name = data.Tables[PaymentDetails.TableName].Rows[i][PaymentDetails.ColumnProductName].ToString();
                        paymentDetail.Product.UnitPrice = Convert.ToDouble(data.Tables[PaymentDetails.TableName].Rows[i][PaymentDetails.ColumnProductUnitPrice].ToString());
                        paymentDetail.Quantity = Convert.ToInt32(data.Tables[PaymentDetails.TableName].Rows[i][PaymentDetails.ColumnProductQuantity].ToString());
                        paymentDetail.Discount = Convert.ToDouble(data.Tables[PaymentDetails.TableName].Rows[i][PaymentDetails.ColumnDiscount].ToString());

                        paymentDetailList.Add(paymentDetail);
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

            return paymentDetailList;
        }

        public bool insertPaymentDetail(string databaseName, PaymentDetail paymentDetail)
        {
            string sql = "INSERT INTO " +
                         PaymentDetails.TableName + " (" +
                         PaymentDetails.ColumnPaymentId + ", " +
                         PaymentDetails.ColumnProductId + ", " +
                         PaymentDetails.ColumnProductType + ", " +
                         PaymentDetails.ColumnProductName + ", " +
                         PaymentDetails.ColumnProductUnitPrice + ", " +
                         PaymentDetails.ColumnProductQuantity + ", " +
                         PaymentDetails.ColumnDiscount + ") " +
                         "VALUES(" +
                         "?" + PaymentDetails.ColumnPaymentId + ", " +
                         "?" + PaymentDetails.ColumnProductId + ", " +
                         "?" + PaymentDetails.ColumnProductType + ", " +
                         "?" + PaymentDetails.ColumnProductName + ", " +
                         "?" + PaymentDetails.ColumnProductUnitPrice + ", " +
                         "?" + PaymentDetails.ColumnProductQuantity + ", " +
                         "?" + PaymentDetails.ColumnDiscount + ")";

            return this.insert(databaseName, paymentDetail, sql);
        }

        public List<PaymentDetail> getPaymentDetailListByPaymentId(string databaseName, int paymentId)
        {
            string sql = "SELECT * " +
                         "FROM " + PaymentDetails.TableName + " " +
                         "WHERE " + PaymentDetails.ColumnPaymentId + " = " + paymentId + " " +
                         "ORDER BY " + PaymentDetails.ColumnPaymentDetailId + " ASC";

            return this.select(databaseName, sql);
        }
    }
}