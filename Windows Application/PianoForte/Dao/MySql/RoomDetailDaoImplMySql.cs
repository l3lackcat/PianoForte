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
    public class RoomDetailDaoImplMySql : RoomDetailDao
    {
        public bool insertRoomDetail(RoomDetail roomDetail)
        {
            string sql = "INSERT INTO " +
                         RoomDetail.tableName + " (" +
                         RoomDetail.columnRoomDetailId + ", " +
                         RoomDetail.columnRoomId + ", " +
                         RoomDetail.columnTeacherId + ", " +
                         RoomDetail.columnStartTime + ", " +
                         RoomDetail.columnEndTime + ", " +
                         RoomDetail.columnCheckInTime + ") " +
                         "VALUES(" +
                         "?" + RoomDetail.columnRoomDetailId + ", " +
                         "?" + RoomDetail.columnRoomId + ", " +
                         "?" + RoomDetail.columnTeacherId + ", " +
                         "?" + RoomDetail.columnStartTime + ", " +
                         "?" + RoomDetail.columnEndTime + ", " +
                         "?" + RoomDetail.columnCheckInTime + ")";

            return this.processInsertCommand(sql, roomDetail);
        }

        public bool updateRoomDetail(RoomDetail roomDetail)
        {
            string sql = "UPDATE " +
                         RoomDetail.tableName + " SET " +
                         RoomDetail.columnRoomId + " = ?" + RoomDetail.columnRoomId + ", " +
                         RoomDetail.columnTeacherId + " = ?" + RoomDetail.columnTeacherId + ", " +
                         RoomDetail.columnStartTime + " = ?" + RoomDetail.columnStartTime + ", " +
                         RoomDetail.columnEndTime + " = ?" + RoomDetail.columnEndTime + ", " +
                         RoomDetail.columnCheckInTime + " = ?" + RoomDetail.columnCheckInTime + " " +
                         "WHERE " + RoomDetail.columnRoomDetailId + " = ?" + RoomDetail.columnRoomDetailId;

            return this.processUpdateCommand(sql, roomDetail);
        }

        public bool deleteRoomDetail(int roomDetailId)
        {
            string sql = "DELETE " +
                         "FROM " + RoomDetail.tableName + " " +
                         "WHERE " + RoomDetail.columnRoomDetailId + " = " + roomDetailId;

            return this.processDeleteCommand(sql);
        }

        public RoomDetail findLastRoomDetail()
        {
            RoomDetail roomDetail = null;

            string sql = "SELECT * " +
                         "FROM " + RoomDetail.tableName + " " +
                         "ORDER BY " + RoomDetail.columnRoomDetailId + " DESC " +
                         "LIMIT 1";

            List<RoomDetail> roomDetailList = this.processSelectCommand(sql);
            if (roomDetailList.Count > 0)
            {
                roomDetail = roomDetailList[0];
            }

            return roomDetail;
        }

        public RoomDetail findRoomDetail(int roomDetailId)
        {
            RoomDetail roomDetail = null;

            string sql = "SELECT * " +
                         "FROM " + RoomDetail.tableName + " " +
                         "WHERE " + RoomDetail.columnRoomDetailId + " = " + roomDetailId;

            List<RoomDetail> roomDetailList = this.processSelectCommand(sql);
            if (roomDetailList.Count > 0)
            {
                roomDetail = roomDetailList[0];
            }

            return roomDetail;
        }

        public List<RoomDetail> findAllRoomDetail()
        {
            string sql = "SELECT * " +
                         "FROM " + RoomDetail.tableName + " " +
                         "ORDER BY " + RoomDetail.columnRoomDetailId + " ASC";

            return this.processSelectCommand(sql);
        }

        public List<RoomDetail> findAllRoomDetailByRoomId(int roomId)
        {
            string sql = "SELECT * " +
                         "FROM " + RoomDetail.tableName + " " +
                         "WHERE " + RoomDetail.columnRoomId + " = " + roomId + " " +
                         "ORDER BY " + RoomDetail.columnRoomDetailId + " ASC";

            return this.processSelectCommand(sql);
        }

        public List<RoomDetail> findAllRoomDetailByTeacherId(int teacherId)
        {
            string sql = "SELECT * " +
                         "FROM " + RoomDetail.tableName + " " +
                         "WHERE " + RoomDetail.columnTeacherId + " = " + teacherId + " " +
                         "ORDER BY " + RoomDetail.columnRoomDetailId + " ASC";

            return this.processSelectCommand(sql);
        }

        private bool processInsertCommand(string sql, RoomDetail roomDetail)
        {
            bool returnFlag = false;

            if (roomDetail != null)
            {
                MySqlConnection conn = null;
                try
                {
                    conn = new MySqlConnection(DatabaseManager.getMySqlConnectionString());
                    if (conn != null)
                    {
                        conn.Open();

                        MySqlCommand command = new MySqlCommand(sql, conn);
                        command.Parameters.AddWithValue(RoomDetail.columnRoomDetailId, roomDetail.RoomDetailId);
                        command.Parameters.AddWithValue(RoomDetail.columnRoomId, roomDetail.RoomId);
                        command.Parameters.AddWithValue(RoomDetail.columnTeacherId, roomDetail.TeacherId);
                        command.Parameters.AddWithValue(RoomDetail.columnStartTime, roomDetail.StartTime);
                        command.Parameters.AddWithValue(RoomDetail.columnEndTime, roomDetail.EndTime);
                        command.Parameters.AddWithValue(RoomDetail.columnCheckInTime, roomDetail.CheckInTime);

                        int affectedRow = command.ExecuteNonQuery();
                        if (affectedRow != -1)
                        {
                            returnFlag = true;
                        }
                    }
                }
                catch (System.InvalidOperationException e)
                {
                    LogManager.writeLog(e.Message);
                }
                catch (MySqlException e)
                {
                    LogManager.writeLog(e.Message);
                }
                catch (System.SystemException e)
                {
                    LogManager.writeLog(e.Message);
                }
                finally
                {
                    conn.Close();
                }
            }

            return returnFlag;
        }

        private bool processUpdateCommand(string sql, RoomDetail roomDetail)
        {
            bool returnFlag = false;

            if (roomDetail != null)
            {
                MySqlConnection conn = null;
                try
                {
                    conn = new MySqlConnection(DatabaseManager.getMySqlConnectionString());
                    if (conn != null)
                    {
                        conn.Open();

                        MySqlCommand command = new MySqlCommand(sql, conn);
                        command.Parameters.AddWithValue(RoomDetail.columnRoomId, roomDetail.RoomId);
                        command.Parameters.AddWithValue(RoomDetail.columnTeacherId, roomDetail.TeacherId);
                        command.Parameters.AddWithValue(RoomDetail.columnStartTime, roomDetail.StartTime);
                        command.Parameters.AddWithValue(RoomDetail.columnEndTime, roomDetail.EndTime);
                        command.Parameters.AddWithValue(RoomDetail.columnCheckInTime, roomDetail.CheckInTime);
                        command.Parameters.AddWithValue(RoomDetail.columnRoomDetailId, roomDetail.RoomDetailId);

                        int affectedRow = command.ExecuteNonQuery();
                        if (affectedRow != -1)
                        {
                            returnFlag = true;
                        }
                    }
                }
                catch (System.InvalidOperationException e)
                {
                    LogManager.writeLog(e.Message);
                }
                catch (MySqlException e)
                {
                    LogManager.writeLog(e.Message);
                }
                catch (System.SystemException e)
                {
                    LogManager.writeLog(e.Message);
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
                LogManager.writeLog(e.Message);
            }
            catch (MySqlException e)
            {
                LogManager.writeLog(e.Message);
            }
            catch (System.SystemException e)
            {
                LogManager.writeLog(e.Message);
            }
            finally
            {
                conn.Close();
            }

            return returnFlag;
        }

        private List<RoomDetail> processSelectCommand(string sql)
        {
            List<RoomDetail> roomDetailList = new List<RoomDetail>();

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
                    dataAdapter.Fill(data, RoomDetail.tableName);

                    for (int i = 0; i < data.Tables[RoomDetail.tableName].Rows.Count; i++)
                    {
                        roomDetailList.Add(generateRoomDetail(data, i));
                    }
                }
            }
            catch (System.InvalidOperationException e)
            {
                LogManager.writeLog(e.Message);
            }
            catch (MySqlException e)
            {
                LogManager.writeLog(e.Message);
            }
            catch (System.SystemException e)
            {
                LogManager.writeLog(e.Message);
            }
            finally
            {
                conn.Close();
            }

            return roomDetailList;
        }

        private RoomDetail generateRoomDetail(DataSet data, int index)
        {
            RoomDetail roomDetail = new RoomDetail();
            roomDetail.RoomDetailId = Convert.ToInt32(data.Tables[RoomDetail.tableName].Rows[index][RoomDetail.columnRoomDetailId].ToString());
            roomDetail.RoomId = Convert.ToInt32(data.Tables[RoomDetail.tableName].Rows[index][RoomDetail.columnRoomId].ToString());
            roomDetail.TeacherId = Convert.ToInt32(data.Tables[RoomDetail.tableName].Rows[index][RoomDetail.columnTeacherId].ToString());
            roomDetail.StartTime = data.Tables[RoomDetail.tableName].Rows[index][RoomDetail.columnStartTime].ToString();
            roomDetail.EndTime = data.Tables[RoomDetail.tableName].Rows[index][RoomDetail.columnEndTime].ToString();
            roomDetail.CheckInTime = data.Tables[RoomDetail.tableName].Rows[index][RoomDetail.columnCheckInTime].ToString();

            return roomDetail;
        }
    }
}
