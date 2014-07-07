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
    public class RoomDaoImplMySql : RoomDao
    {
        public bool insertRoom(Room room)
        {
            string sql = "INSERT INTO " +
                         Room.tableName + " (" +
                         Room.columnRoomId + ", " +
                         Room.columnRoomNumber + ", " +
                         Room.columnDate + ") " +
                         "VALUES(" +
                         "?" + Room.columnRoomId + ", " +
                         "?" + Room.columnRoomNumber + ", " +
                         "?" + Room.columnDate + ")";

            return this.processInsertCommand(sql, room);
        }

        public bool updateRoom(Room room)
        {
            string sql = "UPDATE " +
                         Room.tableName + " SET " +
                         Room.columnRoomNumber + " = ?" + Room.columnRoomNumber + ", " +
                         Room.columnDate + " = ?" + Room.columnDate + " " +
                         "WHERE " + Room.columnRoomId + " = ?" + Room.columnRoomId;

            return this.processUpdateCommand(sql, room);
        }

        public bool deleteRoom(int roomId)
        {
            string sql = "DELETE " +
                         "FROM " + Room.tableName + " " +
                         "WHERE " + Room.columnRoomId + " = " + roomId;

            return this.processDeleteCommand(sql);
        }

        public Room findLastRoom()
        {
            Room room = null;

            string sql = "SELECT * " +
                         "FROM " + Room.tableName + " " +
                         "ORDER BY " + Room.columnRoomId + " DESC " +
                         "LIMIT 1";

            List<Room> roomList = this.processSelectCommand(sql);
            if (roomList.Count > 0)
            {
                room = roomList[0];
            }

            return room;
        }

        public Room findRoom(int roomId)
        {
            Room room = null;

            string sql = "SELECT * " +
                         "FROM " + Room.tableName + " " +
                         "WHERE " + Room.columnRoomId + " = " + roomId;

            List<Room> roomList = this.processSelectCommand(sql);
            if (roomList.Count > 0)
            {
                room = roomList[0];
            }

            return room;
        }

        public Room findRoom(int roomNumber, DateTime date)
        {
            Room room = null;

            string sql = "SELECT * " +
                         "FROM " + Room.tableName + " " +
                         "WHERE " + Room.columnRoomNumber + " = " + roomNumber + " " +
                         "AND " + Room.columnDate + " = '" + date.ToString(DatabaseManager.DATABASE_DATE_FORMAT) + "'";

            List<Room> roomList = this.processSelectCommand(sql);
            if (roomList.Count > 0)
            {
                room = roomList[0];
            }

            return room;
        }

        public List<Room> findAllRoom()
        {
            string sql = "SELECT * " +
                         "FROM " + Room.tableName + " " +
                         "ORDER BY " + Room.columnRoomId + " ASC";

            return this.processSelectCommand(sql);
        }

        public List<Room> findAllRoom(DateTime date)
        {
            string sql = "SELECT * " +
                         "FROM " + Room.tableName + " " +
                         "WHERE " + Room.columnDate + " = '" + date.ToString(DatabaseManager.DATABASE_DATE_FORMAT) + "' " +
                         "ORDER BY " + Room.columnRoomId + " ASC";

            return this.processSelectCommand(sql);
        }

        public List<Room> findAllRoom(DateTime date, int teacherId)
        {
            string sql = "SELECT * " +
                         "FROM " + Room.tableName + " " +
                         "WHERE " + Room.columnDate + " = '" + date.ToString(DatabaseManager.DATABASE_DATE_FORMAT) + "' " +
                         "AND " + Room.columnRoomId + " = (SELECT " + RoomDetail.columnRoomId + " " +
                         "FROM " + RoomDetail.tableName + " " +
                         "WHERE " + RoomDetail.columnTeacherId + " = " + teacherId + ")";

            return this.processSelectCommand(sql);
        }

        private bool processInsertCommand(string sql, Room room)
        {
            bool returnFlag = false;

            if (room != null)
            {
                MySqlConnection conn = null;
                try
                {
                    conn = new MySqlConnection(DatabaseManager.getMySqlConnectionString());
                    if (conn != null)
                    {
                        conn.Open();

                        MySqlCommand command = new MySqlCommand(sql, conn);
                        command.Parameters.AddWithValue(Room.columnRoomId, room.Id);
                        command.Parameters.AddWithValue(Room.columnRoomNumber, room.Number);
                        command.Parameters.AddWithValue(Room.columnDate, room.Date);

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

        private bool processUpdateCommand(string sql, Room room)
        {
            bool returnFlag = false;

            if (room != null)
            {
                MySqlConnection conn = null;
                try
                {
                    conn = new MySqlConnection(DatabaseManager.getMySqlConnectionString());
                    if (conn != null)
                    {
                        conn.Open();

                        MySqlCommand command = new MySqlCommand(sql, conn);
                        command.Parameters.AddWithValue(Room.columnRoomNumber, room.Number);
                        command.Parameters.AddWithValue(Room.columnDate, room.Date);
                        command.Parameters.AddWithValue(Room.columnRoomId, room.Id);

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

        private List<Room> processSelectCommand(string sql)
        {
            List<Room> roomList = new List<Room>();

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
                    dataAdapter.Fill(data, Room.tableName);

                    for (int i = 0; i < data.Tables[Room.tableName].Rows.Count; i++)
                    {
                        roomList.Add(generateRoom(data, i));
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

            return roomList;
        }

        private Room generateRoom(DataSet data, int index)
        {
            Room room = new Room();
            room.Id = Convert.ToInt32(data.Tables[Room.tableName].Rows[index][Room.columnRoomId].ToString());
            room.Number = Convert.ToInt32(data.Tables[Room.tableName].Rows[index][Room.columnRoomNumber].ToString());
            room.Date = (DateTime)data.Tables[Room.tableName].Rows[index][Room.columnDate];

            return room;
        }
    }
}
