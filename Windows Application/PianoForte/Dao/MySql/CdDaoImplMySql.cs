using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MySql.Data.MySqlClient;
using System.Data;

using PianoForte.Dao;
using PianoForte.Manager;
using PianoForte.Model;


namespace PianoForte.Dao.MySql
{
    public class CdDaoImplMySql : CdDao
    {
        //--------------------------------------------------------------------------------

        public bool insertCd(Cd cd)
        {
            string sql = "INSERT INTO " +
                         Cd.tableName + " (" +
                         Cd.columnCdId + ", " +
                         Cd.columnCdBarcode + ", " +
                         Cd.columnCdName + ", " +
                         Cd.columnCdPrice + ", " +
                         Cd.columnCdAmount + ", " +
                         Cd.columnStatus + ") " +
                         "VALUES(" +
                         "?" + Cd.columnCdId + ", " +
                         "?" + Cd.columnCdBarcode + ", " +
                         "?" + Cd.columnCdName + ", " +
                         "?" + Cd.columnCdPrice + ", " +
                         "?" + Cd.columnCdAmount + ", " +
                         "?" + Cd.columnStatus + ")";

            return this.processInsertCommand(sql, cd);
        }

        public bool updateCd(Cd cd)
        {
            string sql = "UPDATE " +
                         Cd.tableName + " SET " +
                         Cd.columnCdBarcode + " = ?" + Cd.columnCdBarcode + ", " +
                         Cd.columnCdName + " = ?" + Cd.columnCdName + ", " +
                         Cd.columnCdPrice + " = ?" + Cd.columnCdPrice + ", " +
                         Cd.columnCdAmount + " = ?" + Cd.columnCdAmount + ", " +
                         Cd.columnStatus + " = ?" + Cd.columnStatus + " " +
                         "WHERE " + Cd.columnCdId + " = ?" + Cd.columnCdId;

            return this.processUpdateCommand(sql, cd);
        }

        public bool deleteCd(int cdId)
        {
            string sql = "DELETE " +
                         "FROM " + Cd.tableName + " " +
                         "WHERE " + Cd.columnCdId + " = " + cdId;

            return this.processDeleteCommand(sql);
        }

        //--------------------------------------------------------------------------------

        public Cd findCd(int cdId)
        {
            Cd cd = null;

            string sql = "SELECT * " +
                         "FROM " + Cd.tableName + " " +
                         "WHERE " + Cd.columnCdId + " = " + cdId;

            List<Cd> cdList = this.processSelectCommand(sql);
            if (cdList.Count > 0)
            {
                cd = cdList[0];
            }

            return cd;
        }

        public Cd findLastCd()
        {
            Cd cd = null;

            string sql = "SELECT * " +
                         "FROM " + Cd.tableName + " " +
                         "ORDER BY " + Cd.columnCdId + " DESC " +
                         "LIMIT 1";

            List<Cd> cdList = this.processSelectCommand(sql);
            if (cdList.Count > 0)
            {
                cd = cdList[0];
            }

            return cd;
        }        

        //--------------------------------------------------------------------------------

        public List<Cd> findAllCd()
        {
            string sql = "SELECT * " +
                         "FROM " + Cd.tableName + " " +
                         "ORDER BY " + Cd.columnCdBarcode + " ASC";

            return this.processSelectCommand(sql);
        }

        public List<Cd> findAllCd(int startIndex, int offset)
        {
            string sql = "SELECT * " +
                         "FROM " + Cd.tableName + " " +
                         "WHERE " + Cd.columnCdId + " IN (" +
                         "SELECT * " +
                         "FROM (" +
                         "SELECT " + Cd.columnCdId + " " +
                         "FROM " + Cd.tableName + " " +
                         "LIMIT " + startIndex + "," + offset + ") ALIAS)" +
                         "ORDER BY " + Cd.columnCdBarcode + " ASC";

            return this.processSelectCommand(sql);
        }

        public List<Cd> findAllCd(Cd.CdStatus status)
        {
            string sql = "SELECT * " +
                         "FROM " + Cd.tableName + " " +
                         "WHERE " + Cd.columnStatus + " LIKE '%" + status.ToString() + "%' " +
                         "ORDER BY " + Cd.columnCdBarcode + " ASC";

            return this.processSelectCommand(sql);
        }

        public List<Cd> findAllCd(Cd.CdStatus status, int startIndex, int offset)
        {
            string sql = "SELECT * " +
                         "FROM " + Cd.tableName + " " +
                         "WHERE " + Cd.columnCdId + " IN (" +
                         "SELECT * " +
                         "FROM (" +
                         "SELECT " + Cd.columnCdId + " " +
                         "FROM " + Cd.tableName + " " +
                         "WHERE " + Cd.columnStatus + " LIKE '%" + status.ToString() + "%' " +
                         "LIMIT " + startIndex + "," + offset + ") ALIAS)" +
                         "ORDER BY " + Cd.columnCdBarcode + " ASC";

            return this.processSelectCommand(sql);
        }

        //--------------------------------------------------------------------------------

        public Cd findCdByBarcode(string barcode)
        {
            Cd cd = null;

            string sql = "SELECT * " +
                         "FROM " + Cd.tableName + " " +
                         "WHERE " + Cd.columnCdBarcode + " LIKE '" + barcode + "' " +
                         "ORDER BY " + Cd.columnCdBarcode + " ASC";

            List<Cd> cdList = this.processSelectCommand(sql);
            if (cdList.Count > 0)
            {
                cd = cdList[0];
            }

            return cd;
        }

        //public List<Cd> findAllCdByBarcode(string barcode, int startIndex, int offset)
        //{
        //    string sql = "SELECT * " +
        //                 "FROM " + Cd.tableName + " " +
        //                 "WHERE " + Cd.columnCdId + " IN (" +
        //                 "SELECT * " +
        //                 "FROM (" +
        //                 "SELECT " + Cd.columnCdId + " " +
        //                 "FROM " + Cd.tableName + " " +
        //                 "WHERE " + Cd.columnCdBarcode + " LIKE '%" + barcode + "%' " +
        //                 "LIMIT " + startIndex + "," + offset + ") ALIAS)" +
        //                 "ORDER BY " + Cd.columnCdBarcode + " ASC";

        //    return this.processSelectCommand(sql);
        //}

        //public List<Cd> findAllCdByBarcode(string barcode, Cd.CdStatus status)
        //{
        //    string sql = "SELECT * " +
        //                 "FROM " + Cd.tableName + " " +
        //                 "WHERE " + Cd.columnCdBarcode + " LIKE '%" + barcode + "%' " +
        //                 "AND " + Cd.columnStatus + " = '" + status.ToString() + "' " +
        //                 "ORDER BY " + Cd.columnCdBarcode + " ASC";

        //    return this.processSelectCommand(sql);
        //}

        //public List<Cd> findAllCdByBarcode(string barcode, Cd.CdStatus status, int startIndex, int offset)
        //{
        //    string sql = "SELECT * " +
        //                 "FROM " + Cd.tableName + " " +
        //                 "WHERE " + Cd.columnCdId + " IN (" +
        //                 "SELECT * " +
        //                 "FROM (" +
        //                 "SELECT " + Cd.columnCdId + " " +
        //                 "FROM " + Cd.tableName + " " +
        //                 "WHERE " + Cd.columnCdBarcode + " LIKE '%" + barcode + "%' " +
        //                 "AND " + Cd.columnStatus + " = '" + status.ToString() + "' " +
        //                 "LIMIT " + startIndex + "," + offset + ") ALIAS)" +
        //                 "ORDER BY " + Cd.columnCdBarcode + " ASC";

        //    return this.processSelectCommand(sql);
        //}

        //--------------------------------------------------------------------------------

        public List<Cd> findAllCdByName(string cdName)
        {
            string sql = "SELECT * " +
                         "FROM " + Cd.tableName + " " +
                         "WHERE " + Cd.columnCdName + " LIKE '%" + cdName + "%' " +
                         "ORDER BY " + Cd.columnCdBarcode + " ASC";

            return this.processSelectCommand(sql);
        }

        public List<Cd> findAllCdByName(string cdName, int startIndex, int offset)
        {
            string sql = "SELECT * " +
                         "FROM " + Cd.tableName + " " +
                         "WHERE " + Cd.columnCdId + " IN (" +
                         "SELECT * " +
                         "FROM (" +
                         "SELECT " + Cd.columnCdId + " " +
                         "FROM " + Cd.tableName + " " +
                         "WHERE " + Cd.columnCdName + " LIKE '%" + cdName + "%' " +
                         "LIMIT " + startIndex + "," + offset + ") ALIAS)" +
                         "ORDER BY " + Cd.columnCdBarcode + " ASC";

            return this.processSelectCommand(sql);
        }

        public List<Cd> findAllCdByName(string cdName, Cd.CdStatus status)
        {
            string sql = "SELECT * " +
                         "FROM " + Cd.tableName + " " +
                         "WHERE " + Cd.columnCdName + " LIKE '%" + cdName + "%' " +
                         "AND " + Cd.columnStatus + " = '" + status.ToString() + "' " +
                         "ORDER BY " + Cd.columnCdBarcode + " ASC";

            return this.processSelectCommand(sql);
        }

        public List<Cd> findAllCdByName(string cdName, Cd.CdStatus status, int startIndex, int offset)
        {
            string sql = "SELECT * " +
                         "FROM " + Cd.tableName + " " +
                         "WHERE " + Cd.columnCdId + " IN (" +
                         "SELECT * " +
                         "FROM (" +
                         "SELECT " + Cd.columnCdId + " " +
                         "FROM " + Cd.tableName + " " +
                         "WHERE " + Cd.columnCdName + " LIKE '%" + cdName + "%' " +
                         "AND " + Cd.columnStatus + " = '" + status.ToString() + "' " +
                         "LIMIT " + startIndex + "," + offset + ") ALIAS)" +
                         "ORDER BY " + Cd.columnCdBarcode + " ASC";

            return this.processSelectCommand(sql);
        }

        //--------------------------------------------------------------------------------

        //public List<Cd> findAllCdByBarcodeAndName(string barcode, string cdName)
        //{
        //    string sql = "SELECT * " +
        //                 "FROM " + Cd.tableName + " " +
        //                 "WHERE " + Cd.columnCdBarcode + " LIKE '%" + barcode + "%' " +
        //                 "AND " + Cd.columnCdName + " LIKE '%" + cdName + "%' " +
        //                 "ORDER BY " + Cd.columnCdBarcode + " ASC";

        //    return this.processSelectCommand(sql);
        //}

        //public List<Cd> findAllCdByBarcodeAndName(string barcode, string cdName, int startIndex, int offset)
        //{
        //    string sql = "SELECT * " +
        //                 "FROM " + Cd.tableName + " " +
        //                 "WHERE " + Cd.columnCdId + " IN (" +
        //                 "SELECT * " +
        //                 "FROM (" +
        //                 "SELECT " + Cd.columnCdId + " " +
        //                 "FROM " + Cd.tableName + " " +
        //                 "WHERE " + Cd.columnCdBarcode + " LIKE '%" + barcode + "%' " +
        //                 "AND " + Cd.columnCdName + " LIKE '%" + cdName + "%' " +
        //                 "LIMIT " + startIndex + "," + offset + ") ALIAS)" +
        //                 "ORDER BY " + Cd.columnCdBarcode + " ASC";

        //    return this.processSelectCommand(sql);
        //}

        //public List<Cd> findAllCdByBarcodeAndName(string barcode, string cdName, Cd.CdStatus status)
        //{
        //    string sql = "SELECT * " +
        //                 "FROM " + Cd.tableName + " " +
        //                 "WHERE " + Cd.columnCdBarcode + " LIKE '%" + barcode + "%' " +
        //                 "AND " + Cd.columnCdName + " LIKE '%" + cdName + "%' " +
        //                 "AND " + Cd.columnStatus + " = '" + status.ToString() + "' " +
        //                 "ORDER BY " + Cd.columnCdBarcode + " ASC";

        //    return this.processSelectCommand(sql);
        //}

        //public List<Cd> findAllCdByBarcodeAndName(string barcode, string cdName, Cd.CdStatus status, int startIndex, int offset)
        //{
        //    string sql = "SELECT * " +
        //                 "FROM " + Cd.tableName + " " +
        //                 "WHERE " + Cd.columnCdId + " IN (" +
        //                 "SELECT * " +
        //                 "FROM (" +
        //                 "SELECT " + Cd.columnCdId + " " +
        //                 "FROM " + Cd.tableName + " " +
        //                 "WHERE " + Cd.columnCdBarcode + " LIKE '%" + barcode + "%' " +
        //                 "AND " + Cd.columnCdName + " LIKE '%" + cdName + "%' " +
        //                 "AND " + Cd.columnStatus + " = '" + status.ToString() + "' " +
        //                 "LIMIT " + startIndex + "," + offset + ") ALIAS)" +
        //                 "ORDER BY " + Cd.columnCdBarcode + " ASC";

        //    return this.processSelectCommand(sql);
        //}

        //--------------------------------------------------------------------------------

        private bool processInsertCommand(string sql, Cd cd)
        {
            bool returnFlag = false;
            
            if (cd != null)
            {
                MySqlConnection conn = null;
                try
                {
                    conn = new MySqlConnection(DatabaseManager.getMySqlConnectionString());
                    if (conn != null)
                    {
                        conn.Open();

                        MySqlCommand command = new MySqlCommand(sql, conn);
                        command.Parameters.AddWithValue(Cd.columnCdId, cd.Id);
                        command.Parameters.AddWithValue(Cd.columnCdBarcode, cd.Barcode);
                        command.Parameters.AddWithValue(Cd.columnCdName, cd.Name);
                        command.Parameters.AddWithValue(Cd.columnCdPrice, cd.Price);
                        command.Parameters.AddWithValue(Cd.columnCdAmount, cd.Amount);
                        command.Parameters.AddWithValue(Cd.columnStatus, cd.Status);

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

        private bool processUpdateCommand(string sql, Cd cd)
        {
            bool returnFlag = false;
            
            if (cd != null)
            {
                MySqlConnection conn = null;
                try
                {
                    conn = new MySqlConnection(DatabaseManager.getMySqlConnectionString());
                    if (conn != null)
                    {
                        conn.Open();

                        MySqlCommand command = new MySqlCommand(sql, conn);
                        command.Parameters.AddWithValue(Cd.columnCdBarcode, cd.Barcode);
                        command.Parameters.AddWithValue(Cd.columnCdName, cd.Name);
                        command.Parameters.AddWithValue(Cd.columnCdPrice, cd.Price);
                        command.Parameters.AddWithValue(Cd.columnCdAmount, cd.Amount);
                        command.Parameters.AddWithValue(Cd.columnStatus, cd.Status);
                        command.Parameters.AddWithValue(Cd.columnCdId, cd.Id);

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

        private List<Cd> processSelectCommand(string sql)
        {
            List<Cd> cdList = new List<Cd>();

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
                    dataAdapter.Fill(data, Cd.tableName);

                    for (int i = 0; i < data.Tables[Cd.tableName].Rows.Count; i++)
                    {
                        cdList.Add(generateCD(data, i));
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
            
            return cdList;
        }

        private Cd generateCD(DataSet data, int index)
        {
            Cd cd = new Cd();
            cd.Id = Convert.ToInt32(data.Tables[Cd.tableName].Rows[index][Cd.columnCdId].ToString());
            cd.Type = Product.ProductType.CD.ToString();
            cd.Barcode = data.Tables[Cd.tableName].Rows[index][Cd.columnCdBarcode].ToString();
            cd.Name = data.Tables[Cd.tableName].Rows[index][Cd.columnCdName].ToString();

            string price = data.Tables[Cd.tableName].Rows[index][Cd.columnCdPrice].ToString();
            if (ValidateManager.isNumber(price))
            {
                cd.Price = Convert.ToDouble(price);
            }

            string amount = data.Tables[Cd.tableName].Rows[index][Cd.columnCdAmount].ToString();
            if (ValidateManager.isNumber(amount))
            {
                cd.Amount = Convert.ToInt32(amount);
            }

            cd.Status = data.Tables[Cd.tableName].Rows[index][Cd.columnStatus].ToString();

            return cd;
        }

        //--------------------------------------------------------------------------------

        //Temporary
        public bool processInsertStringForMathching(string sql, int oldCdId, int newCdId)
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
                    command.Parameters.AddWithValue(Cd.columnOldCdId, oldCdId);
                    command.Parameters.AddWithValue(Cd.columnNewCdId, newCdId);

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

        public int processQueryStringForMatching(string sql)
        {
            int newCdId = 0;

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
                    dataAdapter.Fill(data, Cd.matchingTableName);

                    for (int i = 0; i < data.Tables[Cd.matchingTableName].Rows.Count; i++)
                    {
                        newCdId = Convert.ToInt32(data.Tables[Cd.matchingTableName].Rows[i][Cd.columnNewCdId].ToString());
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

            return newCdId;
        }
    }
}
