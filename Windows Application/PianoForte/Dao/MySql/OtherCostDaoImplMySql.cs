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
    public class OtherCostDaoImplMySql : OtherCostDao
    {
        public bool insertOtherCost(OtherCost otherCost)
        {
            string sql = "INSERT INTO " +
                         OtherCost.tableName + " (" +
                         OtherCost.columnOtherCostId + ", " +
                         OtherCost.columnOtherCostName + ", " +
                         OtherCost.columnOtherCostPrice + ") " +
                         "VALUES(" +
                         "?" + OtherCost.columnOtherCostId + ", " +
                         "?" + OtherCost.columnOtherCostName + ", " +
                         "?" + OtherCost.columnOtherCostPrice + ")";

            return this.processInsertCommand(sql, otherCost);
        }

        public bool updateOtherCost(OtherCost otherCost)
        {
            string sql = "UPDATE " +
                         OtherCost.tableName + " SET " +
                         OtherCost.columnOtherCostName + " = ?" + OtherCost.columnOtherCostName + ", " +
                         OtherCost.columnOtherCostPrice + " = ?" + OtherCost.columnOtherCostPrice + " " +
                         "WHERE " + OtherCost.columnOtherCostId + " = ?" + OtherCost.columnOtherCostId;

            return this.processUpdateCommand(sql, otherCost);
        }

        public bool deleteOtherCost(int otherCostId)
        {
            string sql = "DELETE " +
                         "FROM " + OtherCost.tableName + " " +
                         "WHERE " + OtherCost.columnOtherCostId + " = " + otherCostId;

            return this.processDeleteCommand(sql);
        }

        public OtherCost findLastOtherCost()
        {
            OtherCost otherCost = null;

            string sql = "SELECT * " +
                         "FROM " + OtherCost.tableName + " " +
                         "ORDER BY " + OtherCost.columnOtherCostId + " DESC " +
                         "LIMIT 1";

            List<OtherCost> otherCostList = this.processSelectCommand(sql);
            if (otherCostList.Count > 0)
            {
                otherCost = otherCostList[0];
            }

            return otherCost;
        }

        public OtherCost findOtherCost(int otherCostId)
        {
            OtherCost otherCost = null;

            string sql = "SELECT * " +
                         "FROM " + OtherCost.tableName + " " +
                         "WHERE " + OtherCost.columnOtherCostId + " = " + otherCostId;

            List<OtherCost> otherCostList = this.processSelectCommand(sql);
            if (otherCostList.Count > 0)
            {
                otherCost = otherCostList[0];
            }

            return otherCost;
        }

        public OtherCost findOtherCost(string otherCostName, double otherCostPrice)
        {
            OtherCost otherCost = null;

            string sql = "SELECT * " +
                         "FROM " + OtherCost.tableName + " " +
                         "WHERE " + OtherCost.columnOtherCostName + " = '" + otherCostName + "' " +
                         "AND " + OtherCost.columnOtherCostPrice + " = " + otherCostPrice;

            List<OtherCost> otherCostList = this.processSelectCommand(sql);
            if (otherCostList.Count > 0)
            {
                otherCost = otherCostList[0];
            }

            return otherCost;
        }

        public List<OtherCost> findAllOtherCost()
        {
            string sql = "SELECT * " +
                         "FROM " + OtherCost.tableName + " " +
                         "ORDER BY " + OtherCost.columnOtherCostId + " ASC";

            return this.processSelectCommand(sql);
        }

        private bool processInsertCommand(string sql, OtherCost otherCost)
        {
            bool returnFlag = false;
            
            if (otherCost != null)
            {
                MySqlConnection conn = null;
                try
                {
                    conn = new MySqlConnection(DatabaseManager.getMySqlConnectionString());
                    if (conn != null)
                    {
                        conn.Open();

                        MySqlCommand command = new MySqlCommand(sql, conn);
                        command.Parameters.AddWithValue(OtherCost.columnOtherCostId, otherCost.Id);
                        command.Parameters.AddWithValue(OtherCost.columnOtherCostName, otherCost.Name);
                        command.Parameters.AddWithValue(OtherCost.columnOtherCostPrice, otherCost.Price);

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

        private bool processUpdateCommand(string sql, OtherCost otherCost)
        {
            bool returnFlag = false;
            
            if (otherCost != null)
            {
                MySqlConnection conn = null;
                try
                {
                    conn = new MySqlConnection(DatabaseManager.getMySqlConnectionString());
                    if (conn != null)
                    {
                        conn.Open();

                        MySqlCommand command = new MySqlCommand(sql, conn);
                        command.Parameters.AddWithValue(OtherCost.columnOtherCostName, otherCost.Name);
                        command.Parameters.AddWithValue(OtherCost.columnOtherCostPrice, otherCost.Price);
                        command.Parameters.AddWithValue(OtherCost.columnOtherCostId, otherCost.Id);

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

        private List<OtherCost> processSelectCommand(string sql)
        {
            List<OtherCost> otherCostList = new List<OtherCost>();
            
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
                    dataAdapter.Fill(data, OtherCost.tableName);

                    for (int i = 0; i < data.Tables[OtherCost.tableName].Rows.Count; i++)
                    {
                        otherCostList.Add(generateOtherCost(data, i));
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
            
            return otherCostList;
        }

        private OtherCost generateOtherCost(DataSet data, int index)
        {
            OtherCost otherCost = new OtherCost();
            otherCost.Id = Convert.ToInt32(data.Tables[OtherCost.tableName].Rows[index][OtherCost.columnOtherCostId].ToString());
            otherCost.Type = Product.ProductType.OTHER.ToString();
            otherCost.Name = data.Tables[OtherCost.tableName].Rows[index][OtherCost.columnOtherCostName].ToString();
            otherCost.Price = Convert.ToDouble(data.Tables[OtherCost.tableName].Rows[index][OtherCost.columnOtherCostPrice].ToString());
            return otherCost;
        }

        //Temporary
        private bool processInsertStringForMathching(string sql, int oldOtherCostId, int newOtherCostId)
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
                    command.Parameters.AddWithValue(OtherCost.columnOldOtherCostId, oldOtherCostId);
                    command.Parameters.AddWithValue(OtherCost.columnNewOtherCostId, newOtherCostId);

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

        private int processQueryStringForMatching(string sql)
        {
            int newOtherCostId = 0;

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
                    dataAdapter.Fill(data, OtherCost.matchingTableName);

                    for (int i = 0; i < data.Tables[OtherCost.matchingTableName].Rows.Count; i++)
                    {
                        newOtherCostId = Convert.ToInt32(data.Tables[OtherCost.matchingTableName].Rows[i][OtherCost.columnNewOtherCostId].ToString());
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

            return newOtherCostId;
        }
    }
}
