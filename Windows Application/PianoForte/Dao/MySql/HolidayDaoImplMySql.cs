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
    class HolidayDaoImplMySql : HolidayDao
    {
        public bool insertHoliday(Holiday holiday)
        {
            string sql = "INSERT INTO " +
                         Holiday.tableName + " (" +
                         Holiday.columnHolidayDate + ", " +
                         Holiday.columnComment + ") " +
                         "VALUES(" +
                         "?" + Holiday.columnHolidayDate + ", " +
                         "?" + Holiday.columnComment + ")";

            return this.processInsertCommand(sql, holiday);
        }

        public bool updateHoliday(Holiday holiday)
        {
            //To Do
            return true;
        }

        public bool deleteHoliday(int holidayId)
        {
            string sql = "DELETE " +
                         "FROM " + Holiday.tableName + " " +
                         "WHERE " + Holiday.columnHolidayId + " = " + holidayId;

            return this.processDeleteCommand(sql);
        }

        public Holiday findHoliday(int holidayId)
        {
            Holiday holiday = null;

            string sql = "SELECT * " +
                         "FROM " + Holiday.tableName + " " +
                         "WHERE " + Holiday.columnHolidayId + " = " + holidayId;

            List<Holiday> holidayList = this.processSelectCommand(sql);
            if (holidayList.Count > 0)
            {
                holiday = holidayList[0];
            }

            return holiday;
        }

        public Holiday findHoliday(DateTime date)
        {
            Holiday holiday = null;

            string sql = "SELECT * " +
                         "FROM " + Holiday.tableName + " " +
                         "WHERE " + Holiday.columnHolidayDate + " = '" + date.ToString(DatabaseManager.DATABASE_DATE_FORMAT) + "'";

            List<Holiday> holidayList = this.processSelectCommand(sql);
            if (holidayList.Count > 0)
            {
                holiday = holidayList[0];
            }

            return holiday;
        }

        public List<Holiday> findAllHoliday()
        {
            string sql = "SELECT * " +
                         "FROM " + Holiday.tableName + " " +
                         "ORDER BY " + Holiday.columnHolidayDate + " ASC";

            return this.processSelectCommand(sql);
        }

        public List<Holiday> findAllHoliday(int year)
        {
            string sql = "SELECT * " +
                         "FROM " + Holiday.tableName + " " +
                         "WHERE YEAR(" + Holiday.columnHolidayDate + ") = '" + year + "' " +
                         "ORDER BY " + Holiday.columnHolidayDate + " ASC";

            return this.processSelectCommand(sql);
        }

        public List<Holiday> findAllHoliday(int year, int month)
        {
            string sql = "SELECT * " +
                         "FROM " + Holiday.tableName + " " +
                         "WHERE MONTH(" + Holiday.columnHolidayDate + ") = '" + month + "' " +
                         "AND YEAR(" + Holiday.columnHolidayDate + ") = '" + year + "' " +
                         "ORDER BY " + Holiday.columnHolidayDate + " ASC";

            return this.processSelectCommand(sql);
        }

        private bool processInsertCommand(string sql, Holiday holiday)
        {
            bool returnFlag = false;

            if (holiday != null)
            {
                MySqlConnection conn = null;
                try
                {
                    conn = new MySqlConnection(DatabaseManager.getMySqlConnectionString());
                    if (conn != null)
                    {
                        conn.Open();

                        MySqlCommand command = new MySqlCommand(sql, conn);
                        command.Parameters.AddWithValue(Holiday.columnHolidayId, holiday.Id);
                        command.Parameters.AddWithValue(Holiday.columnHolidayDate, holiday.Date);
                        command.Parameters.AddWithValue(Holiday.columnComment, holiday.Comment);

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

        private bool processUpdateCommand(string sql, Holiday holiday)
        {
            bool returnFlag = false;

            if (holiday != null)
            {
                MySqlConnection conn = null;
                try
                {
                    conn = new MySqlConnection(DatabaseManager.getMySqlConnectionString());
                    if (conn != null)
                    {
                        conn.Open();

                        MySqlCommand command = new MySqlCommand(sql, conn);
                        command.Parameters.AddWithValue(Holiday.columnHolidayId, holiday.Id);
                        command.Parameters.AddWithValue(Holiday.columnHolidayDate, holiday.Date);
                        command.Parameters.AddWithValue(Holiday.columnComment, holiday.Comment);

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

        private List<Holiday> processSelectCommand(string sql)
        {
            List<Holiday> holidayList = new List<Holiday>();

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
                    dataAdapter.Fill(data, Holiday.tableName);

                    for (int i = 0; i < data.Tables[Holiday.tableName].Rows.Count; i++)
                    {
                        holidayList.Add(generateSchoolClosingDate(data, i));
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

        private Holiday generateSchoolClosingDate(DataSet data, int index)
        {
            Holiday holiday = new Holiday();
            holiday.Id = Convert.ToInt32(data.Tables[Holiday.tableName].Rows[index][Holiday.columnHolidayId].ToString());
            holiday.Date = (DateTime)data.Tables[Holiday.tableName].Rows[index][Holiday.columnHolidayDate];
            holiday.Comment = data.Tables[Holiday.tableName].Rows[index][Holiday.columnComment].ToString();

            return holiday;
        }
    }
}
