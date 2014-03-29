using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using MySql.Data.MySqlClient;

using PianoForte.Dao;
using PianoForte.Model;

namespace PianoForte.Dao.MySql
{
    public class OtherCostOrderDetailDaoImplMySql : OtherCostOrderDetailDao
    {
        public bool insertOtherCostOrderDetail(OtherCostOrderDetail otherCostOrderDetail)
        {
            string sql = "INSERT INTO " +
                         OtherCostOrderDetail.tableName + " (" +
                         OtherCostOrderDetail.columnPaymentId + ", " +
                         OtherCostOrderDetail.columnStudentId + ", " +
                         OtherCostOrderDetail.columnOtherCostId + ", " +
                         OtherCostOrderDetail.columnTotalPrice + ", " +
                         OtherCostOrderDetail.columnOrderDate + ", " +
                         OtherCostOrderDetail.columnStatus + ") " +
                         "VALUES(" +
                         "?" + OtherCostOrderDetail.columnPaymentId + ", " +
                         "?" + OtherCostOrderDetail.columnStudentId + ", " +
                         "?" + OtherCostOrderDetail.columnOtherCostId + ", " +
                         "?" + OtherCostOrderDetail.columnTotalPrice + ", " +
                         "?" + OtherCostOrderDetail.columnOrderDate + ", " +
                         "?" + OtherCostOrderDetail.columnStatus + ")";

            return this.processInsertCommand(sql, otherCostOrderDetail);
        }

        public bool updateOtherCostOrderDetail(OtherCostOrderDetail otherCostOrderDetail)
        {
            string sql = "UPDATE " +
                         OtherCostOrderDetail.tableName + " SET " +
                         OtherCostOrderDetail.columnPaymentId + " = ?" + OtherCostOrderDetail.columnPaymentId + ", " +
                         OtherCostOrderDetail.columnStudentId + " = ?" + OtherCostOrderDetail.columnStudentId + ", " +
                         OtherCostOrderDetail.columnOtherCostId + " = ?" + OtherCostOrderDetail.columnOtherCostId + ", " +
                         OtherCostOrderDetail.columnTotalPrice + " = ?" + OtherCostOrderDetail.columnTotalPrice + ", " +
                         OtherCostOrderDetail.columnOrderDate + " = ?" + OtherCostOrderDetail.columnOrderDate + ", " +
                         OtherCostOrderDetail.columnStatus + " = ?" + OtherCostOrderDetail.columnStatus + " " +
                         "WHERE " + OtherCostOrderDetail.columnOtherCostOrderDetailId + " = ?" + OtherCostOrderDetail.columnOtherCostOrderDetailId;

            return this.processUpdateCommand(sql, otherCostOrderDetail);
        }

        public bool deleteOtherCostOrderDetail(int otherCostOrderDetailId)
        {
            string sql = "DELETE " +
                         "FROM " + OtherCostOrderDetail.tableName + " " +
                         "WHERE " + OtherCostOrderDetail.columnOtherCostOrderDetailId + " = " + otherCostOrderDetailId;

            return this.processDeleteCommand(sql);
        }

        public OtherCostOrderDetail findLastOtherCostOrderDetail()
        {
            OtherCostOrderDetail otherCostOrderDetail = null;

            string sql = "SELECT * " +
                         "FROM " + OtherCostOrderDetail.tableName + " " +
                         "ORDER BY " + OtherCostOrderDetail.columnOtherCostOrderDetailId + " DESC" +
                         "LIMIT 1,1";

            List<OtherCostOrderDetail> otherCostOrderDetailList = this.processSelectCommand(sql);
            if (otherCostOrderDetailList.Count > 0)
            {
                otherCostOrderDetail = otherCostOrderDetailList[0];
            }

            return otherCostOrderDetail;
        }

        public OtherCostOrderDetail findOtherCostOrderDetail(int otherCostOrderDetailId)
        {
            OtherCostOrderDetail otherCostOrderDetail = null;

            string sql = "SELECT * " +
                         "FROM " + OtherCostOrderDetail.tableName + " " +
                         "WHERE " + OtherCostOrderDetail.columnOtherCostOrderDetailId + " = " + otherCostOrderDetailId;

            List<OtherCostOrderDetail> otherCostOrderDetailList = this.processSelectCommand(sql);
            if (otherCostOrderDetailList.Count > 0)
            {
                otherCostOrderDetail = otherCostOrderDetailList[0];
            }

            return otherCostOrderDetail;
        }

        public List<OtherCostOrderDetail> findAllOtherCost()
        {
            string sql = "SELECT * " +
                         "FROM " + OtherCostOrderDetail.tableName + " " +
                         "ORDER BY " + OtherCostOrderDetail.columnOtherCostOrderDetailId + " ASC";

            return this.processSelectCommand(sql);
        }

        public List<OtherCostOrderDetail> findAllOtherCostByPaymentId(int paymentId)
        {
            string sql = "SELECT * " +
                         "FROM " + OtherCostOrderDetail.tableName + " " +
                         "WHERE " + OtherCostOrderDetail.columnPaymentId + " = " + paymentId + " " +
                         "ORDER BY " + OtherCostOrderDetail.columnOtherCostOrderDetailId + " ASC";

            return this.processSelectCommand(sql);
        }

        private bool processInsertCommand(string sql, OtherCostOrderDetail otherCostOrderDetail)
        {
            bool returnFlag = false;
            
            if (otherCostOrderDetail != null)
            {
                MySqlConnection conn = null;
                try
                {
                    conn = DatabaseManager.ConnectDatabase();
                    if (conn != null)
                    {
                        conn.Open();

                        MySqlCommand command = new MySqlCommand(sql, conn);
                        command.Parameters.Add(OtherCostOrderDetail.columnPaymentId, otherCostOrderDetail.PaymentId);
                        command.Parameters.Add(OtherCostOrderDetail.columnStudentId, otherCostOrderDetail.CustomerId);
                        command.Parameters.Add(OtherCostOrderDetail.columnOtherCostId, otherCostOrderDetail.OtherCostId);
                        command.Parameters.Add(OtherCostOrderDetail.columnTotalPrice, otherCostOrderDetail.TotalPrice);
                        command.Parameters.Add(OtherCostOrderDetail.columnOrderDate, otherCostOrderDetail.OrderDate);
                        command.Parameters.Add(OtherCostOrderDetail.columnStatus, otherCostOrderDetail.Status);

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

        private bool processUpdateCommand(string sql, OtherCostOrderDetail otherCostOrderDetail)
        {
            bool returnFlag = false;
            
            if (otherCostOrderDetail != null)
            {
                MySqlConnection conn = null;
                try
                {
                    conn = DatabaseManager.ConnectDatabase();
                    if (conn != null)
                    {
                        conn.Open();

                        MySqlCommand command = new MySqlCommand(sql, conn);
                        command.Parameters.Add(OtherCostOrderDetail.columnPaymentId, otherCostOrderDetail.PaymentId);
                        command.Parameters.Add(OtherCostOrderDetail.columnStudentId, otherCostOrderDetail.CustomerId);
                        command.Parameters.Add(OtherCostOrderDetail.columnOtherCostId, otherCostOrderDetail.OtherCostId);
                        command.Parameters.Add(OtherCostOrderDetail.columnTotalPrice, otherCostOrderDetail.TotalPrice);
                        command.Parameters.Add(OtherCostOrderDetail.columnOrderDate, otherCostOrderDetail.OrderDate);
                        command.Parameters.Add(OtherCostOrderDetail.columnStatus, otherCostOrderDetail.Status);
                        command.Parameters.Add(OtherCostOrderDetail.columnOtherCostOrderDetailId, otherCostOrderDetail.Id);

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

        private List<OtherCostOrderDetail> processSelectCommand(string sql)
        {
            List<OtherCostOrderDetail> otherCostOrderDetailList = new List<OtherCostOrderDetail>();
            
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
                    dataAdapter.Fill(data, OtherCostOrderDetail.tableName);

                    for (int i = 0; i < data.Tables[OtherCostOrderDetail.tableName].Rows.Count; i++)
                    {
                        otherCostOrderDetailList.Add(generateOtherCostOrderDetail(data, i));
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
            
            return otherCostOrderDetailList;
        }

        private OtherCostOrderDetail generateOtherCostOrderDetail(DataSet data, int index)
        {
            OtherCostOrderDetail otherCostOrderDetail = new OtherCostOrderDetail();
            otherCostOrderDetail.Id = Convert.ToInt32(data.Tables[OtherCostOrderDetail.tableName].Rows[index][OtherCostOrderDetail.columnOtherCostOrderDetailId].ToString());
            otherCostOrderDetail.PaymentId = Convert.ToInt32(data.Tables[OtherCostOrderDetail.tableName].Rows[index][OtherCostOrderDetail.columnPaymentId].ToString());
            otherCostOrderDetail.CustomerId = Convert.ToInt32(data.Tables[OtherCostOrderDetail.tableName].Rows[index][OtherCostOrderDetail.columnStudentId].ToString());
            otherCostOrderDetail.OtherCostId = Convert.ToInt32(data.Tables[OtherCostOrderDetail.tableName].Rows[index][OtherCostOrderDetail.columnOtherCostId].ToString());
            otherCostOrderDetail.TotalPrice = Convert.ToDouble(data.Tables[OtherCostOrderDetail.tableName].Rows[index][OtherCostOrderDetail.columnTotalPrice].ToString());
            otherCostOrderDetail.OrderDate = (DateTime)data.Tables[OtherCostOrderDetail.tableName].Rows[index][OtherCostOrderDetail.columnOrderDate];
            otherCostOrderDetail.Status = data.Tables[OtherCostOrderDetail.tableName].Rows[index][OtherCostOrderDetail.columnStatus].ToString();
            
            return otherCostOrderDetail;
        }
    }
}
