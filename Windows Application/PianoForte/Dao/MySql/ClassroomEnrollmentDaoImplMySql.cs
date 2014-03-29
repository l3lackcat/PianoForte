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
    public class ClassroomEnrollmentDaoImplMySql : ClassroomEnrollmentDao
    {
        public bool insertClassroomEnrollment(int classroomId, int enrollmentId)
        {
            string sql = "INSERT INTO " +
                         ClassroomEnrollment.tableName + " (" +
                         ClassroomEnrollment.columnClassroomId + ", " +
                         ClassroomEnrollment.columnEnrollmentId + ") " +
                         "VALUES(" +
                         "?" + ClassroomEnrollment.columnClassroomId + ", " +
                         "?" + ClassroomEnrollment.columnEnrollmentId + ")";

            return this.processInsertCommand(sql, classroomId, enrollmentId);
        }

        public bool updateClassroomEnrollment(int classroomId, int enrollmentId)
        {
            string sql = "UPDATE " +
                         ClassroomEnrollment.tableName + " SET " +
                         ClassroomEnrollment.columnEnrollmentId + " = ?" + ClassroomEnrollment.columnEnrollmentId + " " +
                         "WHERE " + ClassroomEnrollment.columnClassroomId + " = ?" + ClassroomEnrollment.columnClassroomId;

            return this.processUpdateCommand(sql, classroomId, enrollmentId);
        }

        public bool deleteClassroomEnrollmentByClassroomId(int classroomId)
        {
            string sql = "DELETE " +
                         "FROM " + ClassroomEnrollment.tableName + " " +
                         "WHERE " + ClassroomEnrollment.columnClassroomId + " = " + classroomId;

            return this.processDeleteCommand(sql);
        }

        public bool deleteClassroomEnrollmentByEnrollmentId(int enrollmentId)
        {
            string sql = "DELETE FROM " +
                         ClassroomEnrollment.tableName + " " +
                         "WHERE " + ClassroomEnrollment.columnEnrollmentId + " = " + enrollmentId;

            return this.processDeleteCommand(sql);
        }

        public List<int> findClassroomIdByEnrollmentId(int enrollmentId)
        {
            string sql = "SELECT " + ClassroomEnrollment.columnClassroomId + " " +
                         "FROM " + ClassroomEnrollment.tableName + " " +
                         "WHERE " + ClassroomEnrollment.columnEnrollmentId + " = " + enrollmentId;

            return this.processSelectCommand(sql);
        }

        private bool processInsertCommand(string sql, int classroomId, int enrollmentId)
        {
            bool returnFlag = false;
            
            if ((classroomId > 0) && (enrollmentId > 0))
            {
                MySqlConnection conn = null;
                try
                {
                    conn = DatabaseManager.ConnectDatabase();
                    if (conn != null)
                    {
                        conn.Open();

                        MySqlCommand command = new MySqlCommand(sql, conn);
                        command.Parameters.Add(ClassroomEnrollment.columnClassroomId, classroomId);
                        command.Parameters.Add(ClassroomEnrollment.columnEnrollmentId, enrollmentId);

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

        private bool processUpdateCommand(string sql, int classroomId, int enrollmentId)
        {
            bool returnFlag = false;
            
            if ((classroomId > 0) && (enrollmentId > 0))
            {
                MySqlConnection conn = null;
                try
                {
                    conn = DatabaseManager.ConnectDatabase();
                    if (conn != null)
                    {
                        conn.Open();

                        MySqlCommand command = new MySqlCommand(sql, conn);
                        command.Parameters.Add(ClassroomEnrollment.columnClassroomId, classroomId);
                        command.Parameters.Add(ClassroomEnrollment.columnEnrollmentId, enrollmentId);                        

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

        private List<int> processSelectCommand(string sql)
        {
            List<int> enrollmentIdList = new List<int>();
            
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
                    dataAdapter.Fill(data, ClassroomEnrollment.tableName);

                    for (int i = 0; i < data.Tables[ClassroomEnrollment.tableName].Rows.Count; i++)
                    {
                        enrollmentIdList.Add(generateEnrollmentId(data, i));
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
            
            return enrollmentIdList;
        }

        private int generateEnrollmentId(DataSet data, int index)
        {
            return Convert.ToInt32(data.Tables[ClassroomEnrollment.tableName].Rows[index][ClassroomEnrollment.columnEnrollmentId].ToString());
        }

        //private List<int> processSelectCommandForClassroomId(string sql)
        //{
        //    List<int> classroomIdList = new List<int>();
            
        //    MySqlConnection conn = null;
        //    try
        //    {
        //        conn = DatabaseManager.ConnectDatabase();
        //        if (conn != null)
        //        {
        //            conn.Open();
        //            MySqlCommand command = new MySqlCommand(sql, conn);
        //            MySqlDataAdapter dataAdapter = new MySqlDataAdapter(command);

        //            DataSet data = new DataSet();
        //            dataAdapter.Fill(data, ClassroomEnrollment.tableName);

        //            for (int i = 0; i < data.Tables[ClassroomEnrollment.tableName].Rows.Count; i++)
        //            {
        //                classroomIdList.Add(generateClassroomId(data, i));
        //            }
        //        }
        //    }
        //    catch (System.InvalidOperationException e)
        //    {
        //        Console.Write(e.Message);
        //    }
        //    catch (MySqlException e)
        //    {
        //        Console.Write(e.Message);
        //    }
        //    catch (System.SystemException e)
        //    {
        //        Console.Write(e.Message);
        //    }
        //    finally
        //    {
        //        conn.Close();
        //    }
            
        //    return classroomIdList;
        //}

        //private int generateClassroomId(DataSet data, int index)
        //{
        //    return Convert.ToInt32(data.Tables[ClassroomEnrollment.tableName].Rows[index][ClassroomEnrollment.columnClassroomId].ToString());
        //}
    }
}
