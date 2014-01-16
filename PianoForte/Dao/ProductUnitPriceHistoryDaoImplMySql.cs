using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;

using MySql.Data.MySqlClient;

using PianoForte.Enum;
using PianoForte.Models;

namespace PianoForte.Dao
{
    public class ProductUnitPriceHistoryDaoImplMySql : ProductUnitPriceHistoryDao
    {
        private bool insert(string databaseName, ProductUnitPriceHistory productUnitPriceHistory, string sql)
        {
            bool returnFlag = false;

            if (productUnitPriceHistory != null)
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
                        command.Parameters.AddWithValue(PianoForte.Resourses.DatabaseStructure.MySqlTable.ProductUnitPriceHistory.ColumnProductId, productUnitPriceHistory.ProductId);
                        command.Parameters.AddWithValue(PianoForte.Resourses.DatabaseStructure.MySqlTable.ProductUnitPriceHistory.ColumnProductType, (int)productUnitPriceHistory.ProductType);
                        command.Parameters.AddWithValue(PianoForte.Resourses.DatabaseStructure.MySqlTable.ProductUnitPriceHistory.ColumnProductUnitPrice, productUnitPriceHistory.ProductUnitPrice);
                        command.Parameters.AddWithValue(PianoForte.Resourses.DatabaseStructure.MySqlTable.ProductUnitPriceHistory.ColumnModifiedDate, productUnitPriceHistory.ModifiedDate.ToString("yyyy-MM-dd HH:mm:ss"));

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

        private List<ProductUnitPriceHistory> select(string databaseName, string sql)
        {
            List<ProductUnitPriceHistory> productUnitPriceHistoryList = new List<ProductUnitPriceHistory>();

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
                    dataAdapter.Fill(data, PianoForte.Resourses.DatabaseStructure.MySqlTable.ProductUnitPriceHistory.TableName);

                    for (int i = 0; i < data.Tables[PianoForte.Resourses.DatabaseStructure.MySqlTable.ProductUnitPriceHistory.TableName].Rows.Count; i++)
                    {
                        ProductUnitPriceHistory productUnitPriceHistory = new ProductUnitPriceHistory();
                        productUnitPriceHistory.Id = Convert.ToInt32(data.Tables[PianoForte.Resourses.DatabaseStructure.MySqlTable.ProductUnitPriceHistory.TableName].Rows[i][PianoForte.Resourses.DatabaseStructure.MySqlTable.ProductUnitPriceHistory.ColumnProductUnitPriceHistoryId].ToString());
                        productUnitPriceHistory.ProductId = Convert.ToInt32(data.Tables[PianoForte.Resourses.DatabaseStructure.MySqlTable.ProductUnitPriceHistory.TableName].Rows[i][PianoForte.Resourses.DatabaseStructure.MySqlTable.ProductUnitPriceHistory.ColumnProductId].ToString());
                        productUnitPriceHistory.ProductType = EnumConverter.ToProductType(data.Tables[PianoForte.Resourses.DatabaseStructure.MySqlTable.ProductUnitPriceHistory.TableName].Rows[i][PianoForte.Resourses.DatabaseStructure.MySqlTable.ProductUnitPriceHistory.ColumnProductType].ToString());
                        productUnitPriceHistory.ProductUnitPrice = Convert.ToDouble(data.Tables[PianoForte.Resourses.DatabaseStructure.MySqlTable.ProductUnitPriceHistory.TableName].Rows[i][PianoForte.Resourses.DatabaseStructure.MySqlTable.ProductUnitPriceHistory.ColumnProductUnitPrice].ToString());
                        productUnitPriceHistory.ModifiedDate = Convert.ToDateTime(data.Tables[PianoForte.Resourses.DatabaseStructure.MySqlTable.ProductUnitPriceHistory.TableName].Rows[i][PianoForte.Resourses.DatabaseStructure.MySqlTable.ProductUnitPriceHistory.ColumnModifiedDate].ToString());

                        productUnitPriceHistoryList.Add(productUnitPriceHistory);
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

            return productUnitPriceHistoryList;
        }

        public bool insertProductUnitPriceHistory(string databaseName, ProductUnitPriceHistory productUnitPriceHistory)
        {
            string sql = "INSERT INTO " +
                         PianoForte.Resourses.DatabaseStructure.MySqlTable.ProductUnitPriceHistory.TableName + " (" +
                         PianoForte.Resourses.DatabaseStructure.MySqlTable.ProductUnitPriceHistory.ColumnProductId + ", " +
                         PianoForte.Resourses.DatabaseStructure.MySqlTable.ProductUnitPriceHistory.ColumnProductType + ", " +
                         PianoForte.Resourses.DatabaseStructure.MySqlTable.ProductUnitPriceHistory.ColumnProductUnitPrice + ", " +
                         PianoForte.Resourses.DatabaseStructure.MySqlTable.ProductUnitPriceHistory.ColumnModifiedDate + ") " +
                         "VALUES(" +
                         "?" + PianoForte.Resourses.DatabaseStructure.MySqlTable.ProductUnitPriceHistory.ColumnProductId + ", " +
                         "?" + PianoForte.Resourses.DatabaseStructure.MySqlTable.ProductUnitPriceHistory.ColumnProductType + ", " +
                         "?" + PianoForte.Resourses.DatabaseStructure.MySqlTable.ProductUnitPriceHistory.ColumnProductUnitPrice + ", " +
                         "?" + PianoForte.Resourses.DatabaseStructure.MySqlTable.ProductUnitPriceHistory.ColumnModifiedDate + ")";

            return this.insert(databaseName, productUnitPriceHistory, sql);
        }

        public List<ProductUnitPriceHistory> getProductUnitPriceHistoryList(string databaseName, int productId)
        {
            string sql = "SELECT * " +
                         "FROM " + PianoForte.Resourses.DatabaseStructure.MySqlTable.ProductUnitPriceHistory.TableName + " " +
                         "WHERE " + PianoForte.Resourses.DatabaseStructure.MySqlTable.ProductUnitPriceHistory.ColumnProductId + " = " + productId;

            return this.select(databaseName, sql);
        }
    }
}