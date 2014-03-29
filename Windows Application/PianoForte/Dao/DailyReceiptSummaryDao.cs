using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.OleDb;

using PianoForte.Model;
using MySql.Data.MySqlClient;

namespace PianoForte.Dao
{
    public class DailyReceiptSummaryDao
    {
        public bool processInsertString(string sql, DailyReceiptSummary dailyReceiptSummary)
        {
            bool returnFlag = false;
            
            if (dailyReceiptSummary != null)
            {
                MySqlConnection conn = null;
                try
                {
                    conn = DatabaseManager.ConnectDB();
                    if (conn != null)
                    {
                        conn.Open();

                        MySqlCommand command = new MySqlCommand(sql, conn);
                        command.Parameters.Add("receiptDate", dailyReceiptSummary.Date);
                        command.Parameters.Add("totalCoursePrice", dailyReceiptSummary.TotalCoursePrice);
                        command.Parameters.Add("totalBookPrice", dailyReceiptSummary.TotalBookPrice);
                        command.Parameters.Add("totalAssignmentBookPrice", dailyReceiptSummary.TotalAssignmentBookPrice);
                        command.Parameters.Add("totalFirstRegister", dailyReceiptSummary.TotalFirstRegister);
                        command.Parameters.Add("totalCDPrice", dailyReceiptSummary.TotalCDPrice);
                        command.Parameters.Add("totalOtherPrice", dailyReceiptSummary.TotalOtherPrice);
                        command.Parameters.Add("totalCash", dailyReceiptSummary.TotalCash);
                        command.Parameters.Add("totalCreditcard", dailyReceiptSummary.TotalCreditcard);

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

        public bool processUpdateString(string sql, DailyReceiptSummary dailyReceiptSummary)
        {
            bool returnFlag = false;
            
            if (dailyReceiptSummary != null)
            {
                MySqlConnection conn = null;
                try
                {
                    conn = DatabaseManager.ConnectDB();
                    if (conn != null)
                    {
                        conn.Open();

                        MySqlCommand command = new MySqlCommand(sql, conn);                        
                        command.Parameters.Add("totalCoursePrice", dailyReceiptSummary.TotalCoursePrice);
                        command.Parameters.Add("totalBookPrice", dailyReceiptSummary.TotalBookPrice);
                        command.Parameters.Add("totalAssignmentBookPrice", dailyReceiptSummary.TotalAssignmentBookPrice);
                        command.Parameters.Add("totalFirstRegister", dailyReceiptSummary.TotalFirstRegister);
                        command.Parameters.Add("totalCDPrice", dailyReceiptSummary.TotalCDPrice);
                        command.Parameters.Add("totalOtherPrice", dailyReceiptSummary.TotalOtherPrice);
                        command.Parameters.Add("totalCash", dailyReceiptSummary.TotalCash);
                        command.Parameters.Add("totalCreditcard", dailyReceiptSummary.TotalCreditcard);
                        command.Parameters.Add("receiptDate", dailyReceiptSummary.Date);

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

        public bool processDeleteString(string sql)
        {
            bool returnFlag = false;
            
            MySqlConnection conn = null;
            try
            {
                conn = DatabaseManager.ConnectDB();
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

        public List<DailyReceiptSummary> processQueryString(string sql)
        {
            List<DailyReceiptSummary> dailyReceiptSummaryList = new List<DailyReceiptSummary>();
            
            MySqlConnection conn = null;
            try
            {
                conn = DatabaseManager.ConnectDB();
                if (conn != null)
                {
                    conn.Open();
                    MySqlCommand command = new MySqlCommand(sql, conn);
                    MySqlDataAdapter dataAdapter = new MySqlDataAdapter(command);

                    DataSet data = new DataSet();
                    dataAdapter.Fill(data, "DailyReceiptSummary");

                    for (int i = 0; i < data.Tables["DailyReceiptSummary"].Rows.Count; i++)
                    {
                        dailyReceiptSummaryList.Add(generateDailyReceiptSummary(data, i));
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
            
            return dailyReceiptSummaryList;
        }

        private DailyReceiptSummary generateDailyReceiptSummary(DataSet data, int index)
        {
            DailyReceiptSummary dailyReceiptSummary = new DailyReceiptSummary();
            dailyReceiptSummary.ID = Convert.ToInt32(data.Tables["DailyReceiptSummary"].Rows[index]["id"].ToString());
            dailyReceiptSummary.Date = Convert.ToDateTime(data.Tables["DailyReceiptSummary"].Rows[index]["receiptDate"].ToString());
            dailyReceiptSummary.TotalCoursePrice = Convert.ToDouble(data.Tables["DailyReceiptSummary"].Rows[index]["totalCoursePrice"].ToString());
            dailyReceiptSummary.TotalBookPrice = Convert.ToDouble(data.Tables["DailyReceiptSummary"].Rows[index]["totalBookPrice"].ToString());
            dailyReceiptSummary.TotalAssignmentBookPrice = Convert.ToDouble(data.Tables["DailyReceiptSummary"].Rows[index]["totalAssignmentBookPrice"].ToString());
            dailyReceiptSummary.TotalFirstRegister = Convert.ToDouble(data.Tables["DailyReceiptSummary"].Rows[index]["totalFirstRegister"].ToString());
            dailyReceiptSummary.TotalCDPrice = Convert.ToDouble(data.Tables["DailyReceiptSummary"].Rows[index]["totalCDPrice"].ToString());
            dailyReceiptSummary.TotalOtherPrice = Convert.ToDouble(data.Tables["DailyReceiptSummary"].Rows[index]["totalOtherPrice"].ToString());
            dailyReceiptSummary.TotalCash = Convert.ToDouble(data.Tables["DailyReceiptSummary"].Rows[index]["totalCash"].ToString());
            dailyReceiptSummary.TotalCreditcard = Convert.ToDouble(data.Tables["DailyReceiptSummary"].Rows[index]["totalCreditcard"].ToString());

            return dailyReceiptSummary;
        }
    }
}
