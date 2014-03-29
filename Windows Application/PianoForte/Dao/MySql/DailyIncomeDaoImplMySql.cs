using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MySql.Data.MySqlClient;
using System.Data;

using PianoForte.Model;

namespace PianoForte.Dao
{
    public class DailyIncomeDao
    {
        public bool processInsertString(string sql, DailyIncome dailyIncome)
        {
            bool returnFlag = false;
            
            if (dailyIncome != null)
            {
                MySqlConnection conn = null;
                try
                {
                    conn = DatabaseManager.ConnectDatabase();
                    if (conn != null)
                    {
                        conn.Open();

                        MySqlCommand command = new MySqlCommand(sql, conn);
                        command.Parameters.Add(DailyIncome.columnDailyIncomeDate, dailyIncome.Date);
                        command.Parameters.Add(DailyIncome.columnTotalCoursePrice, dailyIncome.TotalCoursePrice);
                        command.Parameters.Add(DailyIncome.columnTotalBookPrice, dailyIncome.TotalBookPrice);
                        command.Parameters.Add(DailyIncome.columnTotalAssignmentBookPrice, dailyIncome.TotalAssignmentBookPrice);
                        command.Parameters.Add(DailyIncome.columnTotalFirstRegister, dailyIncome.TotalFirstRegister);
                        command.Parameters.Add(DailyIncome.columnTotalCdPrice, dailyIncome.TotalCdPrice);
                        command.Parameters.Add(DailyIncome.columnTotalOtherPrice, dailyIncome.TotalOtherPrice);
                        command.Parameters.Add(DailyIncome.columnTotalCash, dailyIncome.TotalCash);
                        command.Parameters.Add(DailyIncome.columnTotalCreditcard, dailyIncome.TotalCreditcard);

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

        public bool processUpdateString(string sql, DailyIncome dailyIncome)
        {
            bool returnFlag = false;

            if (dailyIncome != null)
            {
                MySqlConnection conn = null;
                try
                {
                    conn = DatabaseManager.ConnectDatabase();
                    if (conn != null)
                    {
                        conn.Open();

                        MySqlCommand command = new MySqlCommand(sql, conn);
                        command.Parameters.Add(DailyIncome.columnDailyIncomeDate, dailyIncome.Date);
                        command.Parameters.Add(DailyIncome.columnTotalCoursePrice, dailyIncome.TotalCoursePrice);
                        command.Parameters.Add(DailyIncome.columnTotalBookPrice, dailyIncome.TotalBookPrice);
                        command.Parameters.Add(DailyIncome.columnTotalAssignmentBookPrice, dailyIncome.TotalAssignmentBookPrice);
                        command.Parameters.Add(DailyIncome.columnTotalFirstRegister, dailyIncome.TotalFirstRegister);
                        command.Parameters.Add(DailyIncome.columnTotalCdPrice, dailyIncome.TotalCdPrice);
                        command.Parameters.Add(DailyIncome.columnTotalOtherPrice, dailyIncome.TotalOtherPrice);
                        command.Parameters.Add(DailyIncome.columnTotalCash, dailyIncome.TotalCash);
                        command.Parameters.Add(DailyIncome.columnTotalCreditcard, dailyIncome.TotalCreditcard);

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

        public List<DailyIncome> processQueryString(string sql)
        {
            List<DailyIncome> dailyIncomeList = new List<DailyIncome>();
            
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
                    dataAdapter.Fill(data, DailyIncome.tableName);

                    for (int i = 0; i < data.Tables[DailyIncome.tableName].Rows.Count; i++)
                    {
                        dailyIncomeList.Add(generateDailyIncome(data, i));
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
            
            return dailyIncomeList;
        }

        private DailyIncome generateDailyIncome(DataSet data, int index)
        {
            DailyIncome dailyIncome = new DailyIncome();
            dailyIncome.Id = Convert.ToInt32(data.Tables[DailyIncome.tableName].Rows[index][DailyIncome.columnDailyIncomeId].ToString());
            dailyIncome.Date = Convert.ToDateTime(data.Tables[DailyIncome.tableName].Rows[index][DailyIncome.columnDailyIncomeDate].ToString());
            dailyIncome.TotalCoursePrice = Convert.ToDouble(data.Tables[DailyIncome.tableName].Rows[index][DailyIncome.columnTotalCoursePrice].ToString());
            dailyIncome.TotalBookPrice = Convert.ToDouble(data.Tables[DailyIncome.tableName].Rows[index][DailyIncome.columnTotalBookPrice].ToString());
            dailyIncome.TotalAssignmentBookPrice = Convert.ToDouble(data.Tables[DailyIncome.tableName].Rows[index][DailyIncome.columnTotalAssignmentBookPrice].ToString());
            dailyIncome.TotalFirstRegister = Convert.ToDouble(data.Tables[DailyIncome.tableName].Rows[index][DailyIncome.columnTotalFirstRegister].ToString());
            dailyIncome.TotalCdPrice = Convert.ToDouble(data.Tables[DailyIncome.tableName].Rows[index][DailyIncome.columnTotalCdPrice].ToString());
            dailyIncome.TotalOtherPrice = Convert.ToDouble(data.Tables[DailyIncome.tableName].Rows[index][DailyIncome.columnTotalOtherPrice].ToString());
            dailyIncome.TotalCash = Convert.ToDouble(data.Tables[DailyIncome.tableName].Rows[index][DailyIncome.columnTotalCash].ToString());
            dailyIncome.TotalCreditcard = Convert.ToDouble(data.Tables[DailyIncome.tableName].Rows[index][DailyIncome.columnTotalCreditcard].ToString());

            return dailyIncome;
        }
    }
}
