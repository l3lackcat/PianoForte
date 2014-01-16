using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;

using MySql.Data.MySqlClient;

using PianoForte.Models;
using PianoForte.Resourses.DatabaseStructure.MySqlTable;

namespace PianoForte.Dao
{
    public class CashPaymentDaoImplMySql : CashPaymentDao
    {
        private bool insert(string databaseName, CashPayment cashPayment, string sql)
        {
            bool returnFlag = false;

            if (cashPayment != null)
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
                        command.Parameters.AddWithValue(CashPayments.ColumnPaymentId, cashPayment.PaymentId);
                        command.Parameters.AddWithValue(CashPayments.ColumnAmount, cashPayment.Amount);

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

        private List<CashPayment> select(string databaseName, string sql)
        {
            List<CashPayment> cashPaymentList = new List<CashPayment>();

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
                    dataAdapter.Fill(data, CashPayments.TableName);

                    for (int i = 0; i < data.Tables[CashPayments.TableName].Rows.Count; i++)
                    {
                        CashPayment cashPayment = new CashPayment();
                        cashPayment.Id = Convert.ToInt32(data.Tables[CashPayments.TableName].Rows[i][CashPayments.ColumnCashPaymentId].ToString());
                        cashPayment.PaymentId = Convert.ToInt32(data.Tables[CashPayments.TableName].Rows[i][CashPayments.ColumnPaymentId].ToString());
                        cashPayment.Amount = Convert.ToDouble(data.Tables[CashPayments.TableName].Rows[i][CashPayments.ColumnAmount].ToString());

                        cashPaymentList.Add(cashPayment);
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

            return cashPaymentList;
        }

        public bool insertCashPayment(string databaseName, CashPayment cashPayment)
        {
            string sql = "INSERT INTO " +
                         CashPayments.TableName + " (" +
                         CashPayments.ColumnPaymentId + ", " +
                         CashPayments.ColumnAmount + ") " +
                         "VALUES(" +
                         "?" + CashPayments.ColumnPaymentId + ", " +
                         "?" + CashPayments.ColumnAmount + ")";

            return this.insert(databaseName, cashPayment, sql);
        }

        public List<CashPayment> getCashPaymentListByPaymentId(string databaseName, int paymentId)
        {
            string sql = "SELECT * " +
                         "FROM " + CashPayments.TableName + " " +
                         "WHERE " + CashPayments.ColumnPaymentId + " = " + paymentId;

            return this.select(databaseName, sql);
        }
    }
}