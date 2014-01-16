using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;

using MySql.Data.MySqlClient;

using PianoForte.Enum;
using PianoForte.Models;
using PianoForte.Resourses.DatabaseStructure.MySqlTable;

namespace PianoForte.Dao
{
    public class OtherProductDaoImplMySql : OtherProductDao
    {
        private bool insert(string databaseName, OtherProduct otherProduct, string sql)
        {
            bool returnFlag = false;

            if (otherProduct != null)
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
                        command.Parameters.AddWithValue(OtherProducts.ColumnOtherProductName, otherProduct.Name);
                        command.Parameters.AddWithValue(OtherProducts.ColumnOtherProductUnitPrice, otherProduct.UnitPrice);

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

        private bool update(string databaseName, OtherProduct otherProduct, string sql)
        {
            bool returnFlag = false;

            if (otherProduct != null)
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
                        command.Parameters.AddWithValue(OtherProducts.ColumnOtherProductName, otherProduct.Name);
                        command.Parameters.AddWithValue(OtherProducts.ColumnOtherProductUnitPrice, otherProduct.UnitPrice);
                        command.Parameters.AddWithValue(OtherProducts.ColumnOtherProductId, otherProduct.Id);

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

        private List<OtherProduct> select(string databaseName, string sql)
        {
            List<OtherProduct> otherProductList = new List<OtherProduct>();

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
                    dataAdapter.Fill(data, OtherProducts.TableName);

                    for (int i = 0; i < data.Tables[OtherProducts.TableName].Rows.Count; i++)
                    {
                        OtherProduct otherProduct = new OtherProduct();
                        otherProduct.Id = Convert.ToInt32(data.Tables[OtherProducts.TableName].Rows[i][OtherProducts.ColumnOtherProductId].ToString());
                        otherProduct.Name = data.Tables[OtherProducts.TableName].Rows[i][OtherProducts.ColumnOtherProductName].ToString();
                        otherProduct.UnitPrice = Convert.ToDouble(data.Tables[OtherProducts.TableName].Rows[i][OtherProducts.ColumnOtherProductUnitPrice].ToString());

                        otherProductList.Add(otherProduct);
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

            return otherProductList;
        }

        public bool insertOtherProduct(string databaseName, OtherProduct otherProduct)
        {
            string sql = "INSERT INTO " +
                         OtherProducts.TableName + " (" +
                         OtherProducts.ColumnOtherProductName + ", " +
                         OtherProducts.ColumnOtherProductUnitPrice + ") " +
                         "VALUES(" +
                         "?" + OtherProducts.ColumnOtherProductName + ", " +
                         "?" + OtherProducts.ColumnOtherProductUnitPrice + ")";

            return this.insert(databaseName, otherProduct, sql);
        }

        public bool updateOtherProduct(string databaseName, OtherProduct otherProduct)
        {
            string sql = "UPDATE " +
                         OtherProducts.TableName + " SET " +
                         OtherProducts.ColumnOtherProductName + " = ?" + OtherProducts.ColumnOtherProductName + ", " +
                         OtherProducts.ColumnOtherProductUnitPrice + " = ?" + OtherProducts.ColumnOtherProductUnitPrice + ", " +
                         "WHERE " + OtherProducts.ColumnOtherProductId + " = ?" + OtherProducts.ColumnOtherProductId;

            return this.update(databaseName, otherProduct, sql);
        }

        public List<OtherProduct> getOtherProductList(string databaseName, int otherProductId)
        {
            string sql = "SELECT * " +
                         "FROM " + OtherProducts.TableName + " " +
                         "WHERE " + OtherProducts.ColumnOtherProductId + " = " + otherProductId;

            return this.select(databaseName, sql);
        }

        public List<OtherProduct> getOtherProductList(string databaseName, int startIndex, int offset, string keyword)
        {
            string sql = "SELECT * " +
                         "FROM " + OtherProducts.TableName + " " +
                         "WHERE " + OtherProducts.ColumnOtherProductName + " LIKE '%" + keyword + "%' " +
                         "ORDER BY " + OtherProducts.ColumnOtherProductId + " ASC " +
                         "LIMIT " + startIndex + "," + offset;

            return this.select(databaseName, sql);
        }
    }
}