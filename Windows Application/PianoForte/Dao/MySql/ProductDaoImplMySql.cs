using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

using PianoForte.Model;
using PianoForte.Manager;

namespace PianoForte.Dao.MySql
{
    public class ProductDaoImplMySql : ProductDao
    {
        public bool addProductPriceHistory(ProductPriceHistory productPriceHistory)
        {
            bool returnFlag = false;

            string sql = "INSERT INTO " +
                         ProductPriceHistory.tableName + " (" +
                         ProductPriceHistory.columnProductId + ", " +
                         ProductPriceHistory.columnPrice + ", " +
                         ProductPriceHistory.columnLastUsed + ") " +
                         "VALUES(" +
                         "?" + ProductPriceHistory.columnProductId + ", " +
                         "?" + ProductPriceHistory.columnPrice + ", " +
                         "?" + ProductPriceHistory.columnLastUsed + ")";

            if (productPriceHistory != null)
            {
                MySqlConnection conn = null;
                try
                {
                    conn = new MySqlConnection(DatabaseManager.getMySqlConnectionString());
                    if (conn != null)
                    {
                        conn.Open();

                        MySqlCommand command = new MySqlCommand(sql, conn);
                        command.Parameters.AddWithValue(ProductPriceHistory.columnProductId, productPriceHistory.ProductId);
                        command.Parameters.AddWithValue(ProductPriceHistory.columnPrice, productPriceHistory.Price);
                        command.Parameters.AddWithValue(ProductPriceHistory.columnLastUsed, productPriceHistory.LastUsed.ToString("yyyy-MM-dd HH:mm:ss"));

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
    }
}
