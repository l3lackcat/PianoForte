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
    public class HolidayDaoImplMySql : HolidayDao
    {
        private bool insert(string databaseName, Holiday holiday, string sql)
        {
            bool returnFlag = false;

            if (holiday != null)
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
                        command.Parameters.AddWithValue(Holidays.ColumnHolidayDate, holiday.Date.ToString("yyyy-MM-dd"));
                        command.Parameters.AddWithValue(Holidays.ColumnHolidayComment, holiday.Comment);

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

        private bool update(string databaseName, Holiday holiday, string sql)
        {
            bool returnFlag = false;

            if (holiday != null)
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
                        command.Parameters.AddWithValue(Holidays.ColumnHolidayDate, holiday.Date.ToString("yyyy-MM-dd"));
                        command.Parameters.AddWithValue(Holidays.ColumnHolidayComment, holiday.Comment);
                        command.Parameters.AddWithValue(Holidays.ColumnHolidayId, holiday.Id);

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

        private List<Holiday> select(string databaseName, string sql)
        {
            List<Holiday> holidayList = new List<Holiday>();

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
                    dataAdapter.Fill(data, Holidays.TableName);

                    for (int i = 0; i < data.Tables[Holidays.TableName].Rows.Count; i++)
                    {
                        Holiday holiday = new Holiday();
                        holiday.Id = Convert.ToInt32(data.Tables[Holidays.TableName].Rows[i][Holidays.ColumnHolidayId].ToString());
                        holiday.Date = Convert.ToDateTime(data.Tables[Holidays.TableName].Rows[i][Holidays.ColumnHolidayDate].ToString());
                        holiday.Comment = data.Tables[Holidays.TableName].Rows[i][Holidays.ColumnHolidayComment].ToString();

                        holidayList.Add(holiday);
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

            return holidayList;
        }

        public bool insertHoliday(string databaseName, Holiday holiday)
        {
            string sql = "INSERT INTO " +
                         Holidays.TableName + " (" +
                         Holidays.ColumnHolidayDate + ", " +
                         Holidays.ColumnHolidayComment + ") " +
                         "VALUES(" +
                         "?" + Holidays.ColumnHolidayDate + ", " +
                         "?" + Holidays.ColumnHolidayComment + ")";

            return this.insert(databaseName, holiday, sql);
        }

        public bool updateHoliday(string databaseName, Holiday holiday)
        {
            string sql = "UPDATE " +
                         Holidays.TableName + " SET " +
                         Holidays.ColumnHolidayDate + " = ?" + Holidays.ColumnHolidayDate + ", " +
                         Holidays.ColumnHolidayComment + " = ?" + Holidays.ColumnHolidayComment + ", " + " " +
                         "WHERE " + Holidays.ColumnHolidayId + " = ?" + Holidays.ColumnHolidayId;

            return this.update(databaseName, holiday, sql);
        }

        public List<Holiday> getHolidayList(string databaseName, int holidayId)
        {
            string sql = "SELECT * " +
                         "FROM " + Holidays.TableName + " " +
                         "WHERE " + Holidays.ColumnHolidayId + " = " + holidayId;

            return this.select(databaseName, sql);
        }

        public List<Holiday> getHolidayList(string databaseName)
        {
            string sql = "SELECT * " +
                         "FROM " + Holidays.TableName + " " +
                         "ORDER BY " + Holidays.ColumnHolidayId + " ASC";

            return this.select(databaseName, sql);
        }
    }
}