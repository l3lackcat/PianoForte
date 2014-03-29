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
    public class ClassroomDetailDaoImplMySql : ClassroomDetailDao
    {
        //--------------------------------------------------------------------------------

        public bool insertClassroomDetail(ClassroomDetail classroomDetail)
        {
            string sql = "INSERT INTO " +
                         ClassroomDetail.tableName + " (" +
                         ClassroomDetail.columnClassroomId + ", " +
                         ClassroomDetail.columnClassroomNo + ", " +
                         ClassroomDetail.columnTeacherId + ", " +
                         ClassroomDetail.columnClassroomDate + ", " +
                         ClassroomDetail.columnClassroomTime + ", " +
                         ClassroomDetail.columnClassroomDuration + ", " +
                         ClassroomDetail.columnClassroomType + ", " +
                         ClassroomDetail.columnCurrentStatus + ", " +
                         ClassroomDetail.columnPreviousStatus + ", " +
                         ClassroomDetail.columnRoomDetailId + ", " +
                         ClassroomDetail.columnRegularClassroomDetailId + ", " +
                         ClassroomDetail.columnCommission + ") " +
                         "VALUES(" +
                         "?" + ClassroomDetail.columnClassroomId + ", " +
                         "?" + ClassroomDetail.columnClassroomNo + ", " +
                         "?" + ClassroomDetail.columnTeacherId + ", " +
                         "?" + ClassroomDetail.columnClassroomDate + ", " +
                         "?" + ClassroomDetail.columnClassroomTime + ", " +
                         "?" + ClassroomDetail.columnClassroomDuration + ", " +
                         "?" + ClassroomDetail.columnClassroomType + ", " +
                         "?" + ClassroomDetail.columnCurrentStatus + ", " +
                         "?" + ClassroomDetail.columnPreviousStatus + ", " +
                         "?" + ClassroomDetail.columnRoomDetailId + ", " +
                         "?" + ClassroomDetail.columnRegularClassroomDetailId + "," +
                         "?" + ClassroomDetail.columnCommission + ")";

            return this.processInsertCommand(sql, classroomDetail);
        }

        public bool updateClassroomDetail(ClassroomDetail classroomDetail)
        {
            string sql = "UPDATE " +
                         ClassroomDetail.tableName + " SET " +
                         ClassroomDetail.columnClassroomId + " = ?" + ClassroomDetail.columnClassroomId + ", " +
                         ClassroomDetail.columnClassroomNo + " = ?" + ClassroomDetail.columnClassroomNo + ", " +
                         ClassroomDetail.columnTeacherId + " = ?" + ClassroomDetail.columnTeacherId + ", " +
                         ClassroomDetail.columnClassroomDate + " = ?" + ClassroomDetail.columnClassroomDate + ", " +
                         ClassroomDetail.columnClassroomTime + " = ?" + ClassroomDetail.columnClassroomTime + ", " +
                         ClassroomDetail.columnClassroomDuration + " = ?" + ClassroomDetail.columnClassroomDuration + ", " +
                         ClassroomDetail.columnClassroomType + " = ?" + ClassroomDetail.columnClassroomType + ", " +
                         ClassroomDetail.columnCurrentStatus + " = ?" + ClassroomDetail.columnCurrentStatus + ", " +
                         ClassroomDetail.columnPreviousStatus + " = ?" + ClassroomDetail.columnPreviousStatus + ", " +
                         ClassroomDetail.columnRoomDetailId + " = ?" + ClassroomDetail.columnRoomDetailId + ", " +
                         ClassroomDetail.columnRegularClassroomDetailId + " = ?" + ClassroomDetail.columnRegularClassroomDetailId + ", " +
                         ClassroomDetail.columnCommission + " = ?" + ClassroomDetail.columnCommission + " " +
                         "WHERE " + ClassroomDetail.columnClassroomDetailId + " = ?" + ClassroomDetail.columnClassroomDetailId;

            return this.processUpdateCommand(sql, classroomDetail);
        }        

        public bool deleteClassroomDetail(int classroomDetailId)
        {
            string sql = "DELETE " +
                         "FROM " + ClassroomDetail.tableName + " " +
                         "WHERE " + ClassroomDetail.columnClassroomDetailId + " = " + classroomDetailId;

            return this.processDeleteCommand(sql);
        }

        //--------------------------------------------------------------------------------

        public ClassroomDetail findClassroomDetail(int classroomDetailId)
        {
            ClassroomDetail classroomDetail = null;

            string sql = "SELECT * " +
                         "FROM " + ClassroomDetail.tableName + " " +
                         "WHERE " + ClassroomDetail.columnClassroomDetailId + " = " + classroomDetailId;

            List<ClassroomDetail> classroomDetailList = this.processSelectCommand(sql);
            if (classroomDetailList.Count > 0)
            {
                classroomDetail = classroomDetailList[0];
            }

            return classroomDetail;
        }

        public ClassroomDetail findClassroomDetailByRegularClassroomDetail(int regularClassroomDetailId)
        {
            ClassroomDetail postponedClassroomDetail = null;

            string sql = "SELECT * " +
                         "FROM " + ClassroomDetail.tableName + " " +
                         "WHERE " + ClassroomDetail.columnRegularClassroomDetailId + " = " + regularClassroomDetailId;

            List<ClassroomDetail> classroomDetailList = this.processSelectCommand(sql);
            if (classroomDetailList.Count > 0)
            {
                postponedClassroomDetail = classroomDetailList[0];
            }

            return postponedClassroomDetail;
        }

        //--------------------------------------------------------------------------------

        public List<ClassroomDetail> findAllClassroomDetail()
        {
            string sql = "SELECT * " +
                         "FROM " + ClassroomDetail.tableName + " " +
                         "ORDER BY " + ClassroomDetail.columnClassroomDetailId + " ASC";

            return this.processSelectCommand(sql);
        }

        //--------------------------------------------------------------------------------

        public List<ClassroomDetail> findAllClassroomDetailByClassroomId(int classroomId)
        {
            string sql = "SELECT * " +
                         "FROM " + ClassroomDetail.tableName + " " +
                         "WHERE " + ClassroomDetail.columnClassroomId + " = " + classroomId + " " +
                         "ORDER BY " + ClassroomDetail.columnClassroomNo + " ASC";

            return this.processSelectCommand(sql);
        }

        public List<ClassroomDetail> findAllClassroomDetailByClassroomId(int classroomId, List<ClassroomDetail.ClassroomType> typeList, string columnForArrange)
        {
            string sql = "SELECT * " +
                         "FROM " + ClassroomDetail.tableName + " " +
                         "WHERE " + ClassroomDetail.columnClassroomId + " = " + classroomId + " ";

            for (int i = 0; i < typeList.Count; i++)
            {
                if (i == 0)
                {
                    sql += "AND (" + ClassroomDetail.columnClassroomType + " = '" + typeList[i].ToString() + "' ";
                }
                else
                {
                    sql += "OR " + ClassroomDetail.columnClassroomType + " = '" + typeList[i].ToString() + "') ";
                }
            }

            sql += "ORDER BY " + columnForArrange + " ASC";

            return this.processSelectCommand(sql);
        }

        //--------------------------------------------------------------------------------

        public List<ClassroomDetail> findAllClassroomDetailByRoomDetailId(int roomDetailId)
        {
            string sql = "SELECT * " +
                         "FROM " + ClassroomDetail.tableName + " " +
                         "WHERE " + ClassroomDetail.columnRoomDetailId + " = " + roomDetailId + " " +
                         "ORDER BY " + ClassroomDetail.columnClassroomTime + " ASC";

            return this.processSelectCommand(sql);
        }

        //--------------------------------------------------------------------------------

        public List<ClassroomDetail> findAllClassroomDetailByTeacherIdAndDate(int teacherId, DateTime date)
        {
            string sql = "SELECT * " +
                         "FROM " + ClassroomDetail.tableName + " " +
                         "WHERE " + ClassroomDetail.columnTeacherId + " = " + teacherId + " " +
                         "AND " + ClassroomDetail.columnClassroomDate + " = '" + date.ToString(DatabaseManager.DATABASE_DATE_FORMAT) + "' " +
                         "ORDER BY " + ClassroomDetail.columnClassroomTime + " ASC";

            return this.processSelectCommand(sql);
        }

        public List<ClassroomDetail> findAllClassroomDetailByTeacherIdAndDate(int teacherId, DateTime date, List<ClassroomDetail.ClassroomStatus> statusList, string columnForArrange)
        {
            string sql = "SELECT * " +
                         "FROM " + ClassroomDetail.tableName + " " +
                         "WHERE " + ClassroomDetail.columnTeacherId + " = " + teacherId + " " +
                         "AND " + ClassroomDetail.columnClassroomDate + " = '" + date.ToString(DatabaseManager.DATABASE_DATE_FORMAT) + "' ";

            for (int i = 0; i < statusList.Count; i++)
            {
                if (i == 0)
                {
                    sql += "AND (" + ClassroomDetail.columnCurrentStatus + " = '" + statusList[i].ToString() + "' ";
                }
                else
                {
                    sql += "OR " + ClassroomDetail.columnCurrentStatus + " = '" + statusList[i].ToString() + "' ";
                }
            }
                                                 
            sql += "ORDER BY " + ClassroomDetail.columnClassroomTime + " ASC";

            return this.processSelectCommand(sql);
        }

        //--------------------------------------------------------------------------------

        private bool processInsertCommand(string sql, ClassroomDetail classroomDetail)
        {
            bool returnFlag = false;

            if (classroomDetail != null)
            {
                MySqlConnection conn = null;
                try
                {
                    conn = new MySqlConnection(DatabaseManager.getMySqlConnectionString());
                    if (conn != null)
                    {
                        conn.Open();

                        MySqlCommand command = new MySqlCommand(sql, conn);

                        command.Parameters.AddWithValue(ClassroomDetail.columnClassroomId, classroomDetail.ClassroomId);
                        command.Parameters.AddWithValue(ClassroomDetail.columnClassroomNo, classroomDetail.ClassroomNo);
                        command.Parameters.AddWithValue(ClassroomDetail.columnTeacherId, classroomDetail.TeacherId);
                        command.Parameters.AddWithValue(ClassroomDetail.columnClassroomDate, classroomDetail.ClassroomDate);
                        command.Parameters.AddWithValue(ClassroomDetail.columnClassroomTime, classroomDetail.ClassroomTime);
                        command.Parameters.AddWithValue(ClassroomDetail.columnClassroomDuration, classroomDetail.ClassroomDuration);
                        command.Parameters.AddWithValue(ClassroomDetail.columnClassroomType, classroomDetail.Type);
                        command.Parameters.AddWithValue(ClassroomDetail.columnCurrentStatus, classroomDetail.CurrentStatus);
                        command.Parameters.AddWithValue(ClassroomDetail.columnPreviousStatus, classroomDetail.PreviousStatus);
                        command.Parameters.AddWithValue(ClassroomDetail.columnRoomDetailId, classroomDetail.RoomDetailId);
                        command.Parameters.AddWithValue(ClassroomDetail.columnRegularClassroomDetailId, classroomDetail.RegularClassroomDetailId);
                        command.Parameters.AddWithValue(ClassroomDetail.columnCommission, classroomDetail.Commission);

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

        private bool processUpdateCommand(string sql, ClassroomDetail classroomDetail)
        {
            bool returnFlag = false;

            if (classroomDetail != null)
            {
                MySqlConnection conn = null;
                try
                {
                    conn = new MySqlConnection(DatabaseManager.getMySqlConnectionString());
                    if (conn != null)
                    {
                        conn.Open();

                        MySqlCommand command = new MySqlCommand(sql, conn);

                        command.Parameters.AddWithValue(ClassroomDetail.columnClassroomId, classroomDetail.ClassroomId);
                        command.Parameters.AddWithValue(ClassroomDetail.columnClassroomNo, classroomDetail.ClassroomNo);
                        command.Parameters.AddWithValue(ClassroomDetail.columnTeacherId, classroomDetail.TeacherId);
                        command.Parameters.AddWithValue(ClassroomDetail.columnClassroomDate, classroomDetail.ClassroomDate);
                        command.Parameters.AddWithValue(ClassroomDetail.columnClassroomTime, classroomDetail.ClassroomTime);
                        command.Parameters.AddWithValue(ClassroomDetail.columnClassroomDuration, classroomDetail.ClassroomDuration);
                        command.Parameters.AddWithValue(ClassroomDetail.columnClassroomType, classroomDetail.Type);
                        command.Parameters.AddWithValue(ClassroomDetail.columnCurrentStatus, classroomDetail.CurrentStatus);
                        command.Parameters.AddWithValue(ClassroomDetail.columnPreviousStatus, classroomDetail.PreviousStatus);
                        command.Parameters.AddWithValue(ClassroomDetail.columnRoomDetailId, classroomDetail.RoomDetailId);
                        command.Parameters.AddWithValue(ClassroomDetail.columnRegularClassroomDetailId, classroomDetail.RegularClassroomDetailId);
                        command.Parameters.AddWithValue(ClassroomDetail.columnClassroomDetailId, classroomDetail.ClassroomDetailId);
                        command.Parameters.AddWithValue(ClassroomDetail.columnCommission, classroomDetail.Commission);

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

        private List<ClassroomDetail> processSelectCommand(string sql)
        {
            List<ClassroomDetail> classroomDetailList = new List<ClassroomDetail>();

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
                    dataAdapter.Fill(data, ClassroomDetail.tableName);

                    for (int i = 0; i < data.Tables[ClassroomDetail.tableName].Rows.Count; i++)
                    {
                        classroomDetailList.Add(generateClassroomDetail(data, i));
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

            return classroomDetailList;
        }

        private ClassroomDetail generateClassroomDetail(DataSet data, int index)
        {
            ClassroomDetail classroomDetail = new ClassroomDetail();
            classroomDetail.ClassroomDetailId = Convert.ToInt32(data.Tables[ClassroomDetail.tableName].Rows[index][ClassroomDetail.columnClassroomDetailId].ToString());
            classroomDetail.ClassroomId = Convert.ToInt32(data.Tables[ClassroomDetail.tableName].Rows[index][ClassroomDetail.columnClassroomId].ToString());
            classroomDetail.ClassroomNo = Convert.ToDouble(data.Tables[ClassroomDetail.tableName].Rows[index][ClassroomDetail.columnClassroomNo].ToString());
            classroomDetail.TeacherId = Convert.ToInt32(data.Tables[ClassroomDetail.tableName].Rows[index][ClassroomDetail.columnTeacherId].ToString());
            classroomDetail.ClassroomDate = (DateTime)data.Tables[ClassroomDetail.tableName].Rows[index][ClassroomDetail.columnClassroomDate];
            classroomDetail.ClassroomTime = data.Tables[ClassroomDetail.tableName].Rows[index][ClassroomDetail.columnClassroomTime].ToString();
            classroomDetail.ClassroomDuration = Convert.ToInt32(data.Tables[ClassroomDetail.tableName].Rows[index][ClassroomDetail.columnClassroomDuration].ToString());

            string classroomDetailType = data.Tables[ClassroomDetail.tableName].Rows[index][ClassroomDetail.columnClassroomType].ToString();
            classroomDetail = ClassroomDetailManager.updateClassroomDetailType(classroomDetailType, classroomDetail);
            
            string classroomDetailStatus = data.Tables[ClassroomDetail.tableName].Rows[index][ClassroomDetail.columnCurrentStatus].ToString();
            classroomDetail = ClassroomDetailManager.updateClassroomDetailStatus(classroomDetailStatus, classroomDetail);

            classroomDetail.PreviousStatus = data.Tables[ClassroomDetail.tableName].Rows[index][ClassroomDetail.columnPreviousStatus].ToString();
            classroomDetail.RoomDetailId = Convert.ToInt32(data.Tables[ClassroomDetail.tableName].Rows[index][ClassroomDetail.columnRoomDetailId].ToString());
            classroomDetail.RegularClassroomDetailId = Convert.ToInt32(data.Tables[ClassroomDetail.tableName].Rows[index][ClassroomDetail.columnRegularClassroomDetailId].ToString());
            classroomDetail.Commission = Convert.ToInt32(data.Tables[ClassroomDetail.tableName].Rows[index][ClassroomDetail.columnCommission].ToString());

            return classroomDetail;
        }

        //--------------------------------------------------------------------------------
    }
}
