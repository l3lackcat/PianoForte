using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;

using MySql.Data.MySqlClient;

using PianoForte.Models;
using PianoForte.Enum;
using PianoForte.Resourses.DatabaseStructure.MySqlTable;

namespace PianoForte.Dao
{
    public class ClassroomDetailDaoImplMySql : ClassroomDetailDao
    {
        private bool insert(string databaseName, ClassroomDetail classroomDetail, string sql)
        {
            bool returnFlag = false;

            if (classroomDetail != null)
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
                        command.Parameters.AddWithValue(ClassroomDetails.ColumnClassroomId, classroomDetail.ClassroomId);
                        command.Parameters.AddWithValue(ClassroomDetails.ColumnTeacherId, classroomDetail.TeacherId);
                        command.Parameters.AddWithValue(ClassroomDetails.ColumnClassroomStart, classroomDetail.ClassroomStart.ToString("yyyy-MM-dd HH:mm:ss"));
                        command.Parameters.AddWithValue(ClassroomDetails.ColumnClassrooomEnd, classroomDetail.ClassroomEnd.ToString("yyyy-MM-dd HH:mm:ss"));
                        command.Parameters.AddWithValue(ClassroomDetails.ColumnClassroomType, (int)classroomDetail.Type);
                        command.Parameters.AddWithValue(ClassroomDetails.ColumnClassroomStatus, (int)classroomDetail.Status);
                        command.Parameters.AddWithValue(ClassroomDetails.ColumnPreviousClassroomDetailId, classroomDetail.PreviousId);

                        if (classroomDetail.HolidayId == 0)
                        {
                            command.Parameters.AddWithValue(ClassroomDetails.ColumnHolidayId, DBNull.Value);
                        }
                        else
                        {
                            command.Parameters.AddWithValue(ClassroomDetails.ColumnHolidayId, classroomDetail.HolidayId);   
                        }                        

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

        private bool update(string databaseName, ClassroomDetail classroomDetail, string sql)
        {
            bool returnFlag = false;

            if (classroomDetail != null)
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
                        command.Parameters.AddWithValue(ClassroomDetails.ColumnClassroomId, classroomDetail.ClassroomId);
                        command.Parameters.AddWithValue(ClassroomDetails.ColumnTeacherId, classroomDetail.TeacherId);
                        command.Parameters.AddWithValue(ClassroomDetails.ColumnClassroomStart, classroomDetail.ClassroomStart.ToString("yyyy-MM-dd HH:mm:ss"));
                        command.Parameters.AddWithValue(ClassroomDetails.ColumnClassrooomEnd, classroomDetail.ClassroomEnd.ToString("yyyy-MM-dd HH:mm:ss"));
                        command.Parameters.AddWithValue(ClassroomDetails.ColumnClassroomType, (int)classroomDetail.Type);
                        command.Parameters.AddWithValue(ClassroomDetails.ColumnClassroomStatus, (int)classroomDetail.Status);
                        command.Parameters.AddWithValue(ClassroomDetails.ColumnPreviousClassroomDetailId, classroomDetail.PreviousId);

                        if (classroomDetail.HolidayId == 0)
                        {
                            command.Parameters.AddWithValue(ClassroomDetails.ColumnHolidayId, DBNull.Value);
                        }
                        else
                        {
                            command.Parameters.AddWithValue(ClassroomDetails.ColumnHolidayId, classroomDetail.HolidayId);
                        }  

                        command.Parameters.AddWithValue(ClassroomDetails.ColumnClassroomDetailId, classroomDetail.Id);

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

        private List<ClassroomDetail> select(string databaseName, string sql)
        {
            List<ClassroomDetail> classroomDetailList = new List<ClassroomDetail>();

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
                    dataAdapter.Fill(data, ClassroomDetails.TableName);

                    for (int i = 0; i < data.Tables[ClassroomDetails.TableName].Rows.Count; i++)
                    {
                        ClassroomDetail classroomDetail = new ClassroomDetail();
                        classroomDetail.Id = Convert.ToInt32(data.Tables[ClassroomDetails.TableName].Rows[i][ClassroomDetails.ColumnClassroomDetailId].ToString());
                        classroomDetail.ClassroomId = Convert.ToInt32(data.Tables[ClassroomDetails.TableName].Rows[i][ClassroomDetails.ColumnClassroomId].ToString());
                        classroomDetail.TeacherId = Convert.ToInt32(data.Tables[ClassroomDetails.TableName].Rows[i][ClassroomDetails.ColumnTeacherId].ToString());
                        classroomDetail.ClassroomStart = Convert.ToDateTime(data.Tables[ClassroomDetails.TableName].Rows[i][ClassroomDetails.ColumnClassroomStart].ToString());
                        classroomDetail.ClassroomEnd = Convert.ToDateTime(data.Tables[ClassroomDetails.TableName].Rows[i][ClassroomDetails.ColumnClassrooomEnd].ToString());
                        classroomDetail.Type = EnumConverter.ToClassroomType(data.Tables[ClassroomDetails.TableName].Rows[i][ClassroomDetails.ColumnClassroomType].ToString());
                        classroomDetail.Status = EnumConverter.ToStatus(data.Tables[ClassroomDetails.TableName].Rows[i][ClassroomDetails.ColumnClassroomStatus].ToString());
                        classroomDetail.PreviousId = Convert.ToInt32(data.Tables[ClassroomDetails.TableName].Rows[i][ClassroomDetails.ColumnPreviousClassroomDetailId].ToString());
                        classroomDetail.HolidayId = Convert.ToInt32(data.Tables[ClassroomDetails.TableName].Rows[i][ClassroomDetails.ColumnHolidayId].ToString());

                        classroomDetailList.Add(classroomDetail);
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

        public bool insertClassroomDetail(string databaseName, ClassroomDetail classroomDetail)
        {
            string sql = "INSERT INTO " +
                         ClassroomDetails.TableName + " (" +
                         ClassroomDetails.ColumnClassroomId + ", " +
                         ClassroomDetails.ColumnTeacherId + ", " +
                         ClassroomDetails.ColumnClassroomStart + ", " +
                         ClassroomDetails.ColumnClassrooomEnd + ", " +
                         ClassroomDetails.ColumnClassroomType + ", " +
                         ClassroomDetails.ColumnClassroomStart + ", " +
                         ClassroomDetails.ColumnPreviousClassroomDetailId + ", " +
                         ClassroomDetails.ColumnHolidayId + ") " +
                         "VALUES(" +
                         "?" + ClassroomDetails.ColumnClassroomId + ", " +
                         "?" + ClassroomDetails.ColumnTeacherId + ", " +
                         "?" + ClassroomDetails.ColumnClassroomStart + ", " +
                         "?" + ClassroomDetails.ColumnClassrooomEnd + ", " +
                         "?" + ClassroomDetails.ColumnClassroomType + ", " +
                         "?" + ClassroomDetails.ColumnClassroomStart + ", " +
                         "?" + ClassroomDetails.ColumnPreviousClassroomDetailId + ", " +
                         "?" + ClassroomDetails.ColumnHolidayId + ")";

            return this.insert(databaseName, classroomDetail, sql);
        }

        public bool updateClassroomDetail(string databaseName, ClassroomDetail classroomDetail)
        {
            string sql = "UPDATE " +
                         ClassroomDetails.TableName + " SET " +
                         ClassroomDetails.ColumnClassroomId + " = ?" + ClassroomDetails.ColumnClassroomId + ", " +
                         ClassroomDetails.ColumnTeacherId + " = ?" + ClassroomDetails.ColumnTeacherId + ", " +
                         ClassroomDetails.ColumnClassroomStart + " = ?" + ClassroomDetails.ColumnClassroomStart + ", " +
                         ClassroomDetails.ColumnClassrooomEnd + " = ?" + ClassroomDetails.ColumnClassrooomEnd + ", " +
                         ClassroomDetails.ColumnClassroomType + " = ?" + ClassroomDetails.ColumnClassroomType + ", " +
                         ClassroomDetails.ColumnClassroomStart + " = ?" + ClassroomDetails.ColumnClassroomStart + ", " +
                         ClassroomDetails.ColumnPreviousClassroomDetailId + " = ?" + ClassroomDetails.ColumnPreviousClassroomDetailId + ", " +
                         ClassroomDetails.ColumnHolidayId + " = ?" + ClassroomDetails.ColumnHolidayId + " " +
                         "WHERE " + ClassroomDetails.ColumnClassroomDetailId + " = ?" + ClassroomDetails.ColumnClassroomDetailId;

            return this.update(databaseName, classroomDetail, sql);
        }

        public bool updateClassroomDetailStatus(string databaseName)
        {
            bool returnFlag = false;

            string sql = "UPDATE " + ClassroomDetails.TableName + " " +
                         "SET " + ClassroomDetails.ColumnClassroomStatus + " = " + Convert.ToInt32(Status.CHECKED_IN) + " " +
                         "WHERE " + ClassroomDetails.ColumnClassrooomEnd + " < '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "' " +
                         "AND " + ClassroomDetails.ColumnClassroomStatus + " = " + Convert.ToInt32(Status.WAITING);

            MySqlConnection conn = null;
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings[databaseName].ConnectionString;

                conn = new MySqlConnection(connectionString);
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

        public List<ClassroomDetail> getClassroomDetailListByTeacherId(string databaseName, int teacherId)
        {
            string sql = "SELECT * " +
                         "FROM " + ClassroomDetails.TableName + " " +
                         "WHERE " + ClassroomDetails.ColumnTeacherId + " = " + teacherId + " " +
                         "ORDER BY " + Books.ColumnBookId + " ASC";

            return this.select(databaseName, sql);
        }
    }
}