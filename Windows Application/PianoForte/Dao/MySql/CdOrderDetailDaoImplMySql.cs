using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MySql.Data.MySqlClient;
using System.Data;

using PianoForte.Dao;
using PianoForte.Model;

namespace PianoForte.Dao.MySql
{
    public class CdOrderDetailDaoImplMySql : CdOrderDetailDao
    {
        public bool insertCdOrderDetail(CdOrderDetail cdOrderDetail)
        {
            string sql = "INSERT INTO " +
                         CdOrderDetail.tableName + " (" +
                         CdOrderDetail.columnPaymentId + ", " +
                         CdOrderDetail.columnStudentId + ", " +
                         CdOrderDetail.columnCdId + ", " +
                         CdOrderDetail.columnAmount + ", " +
                         CdOrderDetail.columnTotalPrice + ", " +
                         CdOrderDetail.columnOrderDate + ", " +
                         CdOrderDetail.columnStatus + ") " +
                         "VALUES(" +
                         "?" + CdOrderDetail.columnPaymentId + ", " +
                         "?" + CdOrderDetail.columnStudentId + ", " +
                         "?" + CdOrderDetail.columnCdId + ", " +
                         "?" + CdOrderDetail.columnAmount + ", " +
                         "?" + CdOrderDetail.columnTotalPrice + ", " +
                         "?" + CdOrderDetail.columnOrderDate + ", " +
                         "?" + CdOrderDetail.columnStatus + ")";

            return this.processInsertCommand(sql, cdOrderDetail);
        }

        public bool updateCdOrderDetail(CdOrderDetail cdOrderDetail)
        {
            string sql = "UPDATE " +
                         CdOrderDetail.tableName + " SET " +
                         CdOrderDetail.columnPaymentId + " = ?" + CdOrderDetail.columnPaymentId + ", " +
                         CdOrderDetail.columnStudentId + " = ?" + CdOrderDetail.columnStudentId + ", " +
                         CdOrderDetail.columnCdId + " = ?" + CdOrderDetail.columnCdId + ", " +
                         CdOrderDetail.columnAmount + " = ?" + CdOrderDetail.columnAmount + ", " +
                         CdOrderDetail.columnTotalPrice + " = ?" + CdOrderDetail.columnTotalPrice + ", " +
                         CdOrderDetail.columnOrderDate + " = ?" + CdOrderDetail.columnOrderDate + ", " +
                         CdOrderDetail.columnStatus + " = ?" + CdOrderDetail.columnStatus + " " +
                         "WHERE " + CdOrderDetail.columnCdOrderDetailId + " = ?" + CdOrderDetail.columnCdOrderDetailId;

            return this.processUpdateCommand(sql, cdOrderDetail);
        }

        public bool deleteCdOrderDetail(int cdOrderDetailId)
        {
            string sql = "DELETE " +
                         "FROM " + CdOrderDetail.tableName + " " +
                         "WHERE " + CdOrderDetail.columnCdOrderDetailId + " = " + cdOrderDetailId;

            return this.processDeleteCommand(sql);
        }

        public CdOrderDetail findLastCdOrderDetail()
        {
            CdOrderDetail cdOrderDetail = null;

            string sql = "SELECT " +
                         "FROM " + CdOrderDetail.tableName + " " +
                         "ORDER BY " + CdOrderDetail.columnCdOrderDetailId + " DESC" +
                         "LIMIT 1,1";

            List<CdOrderDetail> cdOrderDetailList = this.processSelectCommand(sql);
            if (cdOrderDetailList.Count > 0)
            {
                cdOrderDetail = cdOrderDetailList[0];
            }

            return cdOrderDetail;
        }

        public CdOrderDetail findCdOrderDetail(int cdOrderDetailId)
        {
            CdOrderDetail cdOrderDetail = null;

            string sql = "SELECT * " +
                         "FROM " + CdOrderDetail.tableName + " " +
                         "WHERE " + CdOrderDetail.columnCdOrderDetailId + " = " + cdOrderDetailId + " " +
                         "ORDER BY " + CdOrderDetail.columnCdOrderDetailId + " ASC";

            List<CdOrderDetail> cdOrderDetailList = this.processSelectCommand(sql);
            if (cdOrderDetailList.Count > 0)
            {
                cdOrderDetail = cdOrderDetailList[0];
            }

            return cdOrderDetail;
        }

        public List<CdOrderDetail> findAllCdOrderDetail()
        {
            string sql = "SELECT * " +
                         "FROM " + CdOrderDetail.tableName + " " +
                         "ORDER BY " + CdOrderDetail.columnCdOrderDetailId + " ASC";

            return this.processSelectCommand(sql);
        }

        public List<CdOrderDetail> findAllCdOrderDetailByPaymentId(int paymentId)
        {
            string sql = "SELECT * " +
                         "FROM " + CdOrderDetail.tableName + " " +
                         "WHERE " + CdOrderDetail.columnPaymentId + " = " + paymentId + " " +
                         "ORDER BY " + CdOrderDetail.columnCdOrderDetailId + " ASC";

            return this.processSelectCommand(sql);
        }

        public List<CdOrderDetail> findAllCdOrderDetailByStudentId(int studentId)
        {
            string sql = "SELECT * " +
                         "FROM " + CdOrderDetail.tableName + " " +
                         "WHERE " + CdOrderDetail.columnStudentId + " = " + studentId + " " +
                         "ORDER BY " + CdOrderDetail.columnCdOrderDetailId + " ASC";

            return this.processSelectCommand(sql);
        }

        public List<CdOrderDetail> findAllCdOrderDetailByDate(DateTime startDate, DateTime endDate)
        {
            string sql = "SELECT * " +
                         "FROM " + CdOrderDetail.tableName + " " +
                         "WHERE " + CdOrderDetail.columnOrderDate + " >= '" + startDate.ToString(DatabaseManager.DATABASE_DATE_FORMAT) + "' " +
                         "AND " + CdOrderDetail.columnOrderDate + " <= '" + endDate.ToString(DatabaseManager.DATABASE_DATE_FORMAT) + "' " +
                         "ORDER BY " + CdOrderDetail.columnCdOrderDetailId + " ASC";

            return this.processSelectCommand(sql);
        }

        private bool processInsertCommand(string sql, CdOrderDetail cdOrderDetail)
        {
            bool returnFlag = false;
            
            if (cdOrderDetail != null)
            {
                MySqlConnection conn = null;
                try
                {
                    conn = DatabaseManager.ConnectDatabase();
                    if (conn != null)
                    {
                        conn.Open();

                        MySqlCommand command = new MySqlCommand(sql, conn);
                        command.Parameters.Add(CdOrderDetail.columnPaymentId, cdOrderDetail.PaymentId);
                        command.Parameters.Add(CdOrderDetail.columnStudentId, cdOrderDetail.CustomerId);
                        command.Parameters.Add(CdOrderDetail.columnCdId, cdOrderDetail.LearningMaterialId);
                        command.Parameters.Add(CdOrderDetail.columnAmount, cdOrderDetail.Amount);
                        command.Parameters.Add(CdOrderDetail.columnTotalPrice, cdOrderDetail.TotalPrice);
                        command.Parameters.Add(CdOrderDetail.columnOrderDate, cdOrderDetail.OrderDate);
                        command.Parameters.Add(CdOrderDetail.columnStatus, cdOrderDetail.Status);                        

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

        private bool processUpdateCommand(string sql, CdOrderDetail cdOrderDetail)
        {
            bool returnFlag = false;
            
            if (cdOrderDetail != null)
            {
                MySqlConnection conn = null;
                try
                {
                    conn = DatabaseManager.ConnectDatabase();
                    if (conn != null)
                    {
                        conn.Open();

                        MySqlCommand command = new MySqlCommand(sql, conn);
                        command.Parameters.Add(CdOrderDetail.columnPaymentId, cdOrderDetail.PaymentId);
                        command.Parameters.Add(CdOrderDetail.columnStudentId, cdOrderDetail.CustomerId);
                        command.Parameters.Add(CdOrderDetail.columnCdId, cdOrderDetail.LearningMaterialId);
                        command.Parameters.Add(CdOrderDetail.columnAmount, cdOrderDetail.Amount);
                        command.Parameters.Add(CdOrderDetail.columnTotalPrice, cdOrderDetail.TotalPrice);
                        command.Parameters.Add(CdOrderDetail.columnOrderDate, cdOrderDetail.OrderDate);
                        command.Parameters.Add(CdOrderDetail.columnStatus, cdOrderDetail.Status); 
                        command.Parameters.Add(CdOrderDetail.columnCdOrderDetailId, cdOrderDetail.Id);

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

        private List<CdOrderDetail> processSelectCommand(string sql)
        {
            List<CdOrderDetail> cdOrderDetailList = new List<CdOrderDetail>();

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
                    dataAdapter.Fill(data, CdOrderDetail.tableName);

                    for (int i = 0; i < data.Tables[CdOrderDetail.tableName].Rows.Count; i++)
                    {
                        cdOrderDetailList.Add(generateCDOrderDetail(data, i));
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
            
            return cdOrderDetailList;
        }

        private CdOrderDetail generateCDOrderDetail(DataSet data, int index)
        {
            CdOrderDetail cdOrderDetail = new CdOrderDetail();
            cdOrderDetail.Id = Convert.ToInt32(data.Tables[CdOrderDetail.tableName].Rows[index][CdOrderDetail.columnCdOrderDetailId].ToString());
            cdOrderDetail.PaymentId = Convert.ToInt32(data.Tables[CdOrderDetail.tableName].Rows[index][CdOrderDetail.columnPaymentId].ToString());
            cdOrderDetail.CustomerId = Convert.ToInt32(data.Tables[CdOrderDetail.tableName].Rows[index][CdOrderDetail.columnStudentId].ToString());
            cdOrderDetail.LearningMaterialId = Convert.ToInt32(data.Tables[CdOrderDetail.tableName].Rows[index][CdOrderDetail.columnCdId].ToString());
            cdOrderDetail.Amount = Convert.ToInt32(data.Tables[CdOrderDetail.tableName].Rows[index][CdOrderDetail.columnAmount].ToString());
            cdOrderDetail.TotalPrice = Convert.ToDouble(data.Tables[CdOrderDetail.tableName].Rows[index][CdOrderDetail.columnTotalPrice].ToString());
            cdOrderDetail.OrderDate = (DateTime)data.Tables[CdOrderDetail.tableName].Rows[index][CdOrderDetail.columnOrderDate];
            cdOrderDetail.Status = data.Tables[CdOrderDetail.tableName].Rows[index][CdOrderDetail.columnStatus].ToString();

            return cdOrderDetail;
        }
    }
}
