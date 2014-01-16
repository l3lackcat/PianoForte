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
    public class CreditCardPaymentDaoImplMySql : CreditCardPaymentDao
    {
        private bool insert(string databaseName, CreditCardPayment creditCardPayment, string sql)
        {
            bool returnFlag = false;

            if (creditCardPayment != null)
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
                        command.Parameters.AddWithValue(CreditCardPayments.ColumnPaymentId, creditCardPayment.PaymentId);
                        command.Parameters.AddWithValue(CreditCardPayments.ColumnCreditCardNumber, creditCardPayment.CreditCardNumber);
                        command.Parameters.AddWithValue(CreditCardPayments.ColumnAmount, (int)creditCardPayment.Amount);

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

        private List<CreditCardPayment> select(string databaseName, string sql)
        {
            List<CreditCardPayment> creditCardPaymentList = new List<CreditCardPayment>();

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
                    dataAdapter.Fill(data, CreditCardPayments.TableName);

                    for (int i = 0; i < data.Tables[CreditCardPayments.TableName].Rows.Count; i++)
                    {
                        CreditCardPayment creditCardPayment = new CreditCardPayment();
                        creditCardPayment.Id = Convert.ToInt32(data.Tables[CreditCardPayments.TableName].Rows[i][CreditCardPayments.ColumnCreditCardPaymentId].ToString());
                        creditCardPayment.PaymentId = Convert.ToInt32(data.Tables[CreditCardPayments.TableName].Rows[i][CreditCardPayments.ColumnPaymentId].ToString());
                        creditCardPayment.CreditCardNumber = data.Tables[CreditCardPayments.TableName].Rows[i][CreditCardPayments.ColumnCreditCardNumber].ToString();
                        creditCardPayment.Amount = Convert.ToDouble(data.Tables[CreditCardPayments.TableName].Rows[i][CreditCardPayments.ColumnAmount].ToString());

                        creditCardPaymentList.Add(creditCardPayment);
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

            return creditCardPaymentList;
        }

        public bool insertCreditCardPayment(string databaseName, CreditCardPayment creditCardPayment)
        {
            string sql = "INSERT INTO " +
                         CreditCardPayments.TableName + " (" +
                         CreditCardPayments.ColumnPaymentId + ", " +
                         CreditCardPayments.ColumnCreditCardNumber + ", " +
                         CreditCardPayments.ColumnAmount + ") " +
                         "VALUES(" +
                         "?" + CreditCardPayments.ColumnPaymentId + ", " +
                         "?" + CreditCardPayments.ColumnCreditCardNumber + ", " +
                         "?" + CreditCardPayments.ColumnAmount + ")";

            return this.insert(databaseName, creditCardPayment, sql);
        }

        public List<CreditCardPayment> getCreditCardPaymentListByPaymentId(string databaseName, int paymentId)
        {
            string sql = "SELECT * " +
                         "FROM " + CreditCardPayments.TableName + " " +
                         "WHERE " + CreditCardPayments.ColumnPaymentId + " = " + paymentId;

            return this.select(databaseName, sql);
        }
    }
}