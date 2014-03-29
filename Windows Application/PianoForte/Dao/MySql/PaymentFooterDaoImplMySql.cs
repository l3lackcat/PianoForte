using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.OleDb;

using PianoForte.Model;
using MySql.Data.MySqlClient;

namespace PianoForte.Dao
{
    public class PaymentFooterDao
    {
        public bool processInsertString(string sql, ReceiptFooter paymentFooter, int paymentId)
        {
            bool returnFlag = false;
            
            if (paymentFooter != null)
            {
                MySqlConnection conn = null;
                try
                {
                    conn = DatabaseManager.ConnectDatabase();
                    if (conn != null)
                    {
                        conn.Open();

                        MySqlCommand command = new MySqlCommand(sql, conn);
                        command.Parameters.Add(ReceiptFooter.columnPaymentId, paymentId);
                        command.Parameters.Add(ReceiptFooter.columnCourseName, paymentFooter.CourseName);
                        command.Parameters.Add(ReceiptFooter.columnCourseLevel, paymentFooter.CourseLevel);
                        command.Parameters.Add(ReceiptFooter.columnDate01, paymentFooter.Date01);
                        command.Parameters.Add(ReceiptFooter.columnDate02, paymentFooter.Date02);
                        command.Parameters.Add(ReceiptFooter.columnDate03, paymentFooter.Date03);
                        command.Parameters.Add(ReceiptFooter.columnDate04, paymentFooter.Date04);
                        command.Parameters.Add(ReceiptFooter.columnDate05, paymentFooter.Date05);
                        command.Parameters.Add(ReceiptFooter.columnDate06, paymentFooter.Date06);
                        command.Parameters.Add(ReceiptFooter.columnDate07, paymentFooter.Date07);
                        command.Parameters.Add(ReceiptFooter.columnDate08, paymentFooter.Date08);
                        command.Parameters.Add(ReceiptFooter.columnDate09, paymentFooter.Date09);
                        command.Parameters.Add(ReceiptFooter.columnDate10, paymentFooter.Date10);
                        command.Parameters.Add(ReceiptFooter.columnDate11, paymentFooter.Date11);
                        command.Parameters.Add(ReceiptFooter.columnDate12, paymentFooter.Date12);
                        command.Parameters.Add(ReceiptFooter.columnClassDay1, paymentFooter.ClassDayOfWeek1);
                        command.Parameters.Add(ReceiptFooter.columnClassTime1, paymentFooter.ClassTime1);
                        command.Parameters.Add(ReceiptFooter.columnTeacher1, paymentFooter.TeacherName1);
                        command.Parameters.Add(ReceiptFooter.columnClassDay2, paymentFooter.ClassDayOfWeek2);
                        command.Parameters.Add(ReceiptFooter.columnClassTime2, paymentFooter.ClassTime2);
                        command.Parameters.Add(ReceiptFooter.columnTeacher2, paymentFooter.TeacherName2);                        

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

        public bool processInsertString(string sql, int paymentId)
        {
            bool returnFlag = false;
            
            if (paymentId > 0)
            {
                MySqlConnection conn = null;
                try
                {
                    conn = DatabaseManager.ConnectDatabase();
                    if (conn != null)
                    {
                        conn.Open();

                        MySqlCommand command = new MySqlCommand(sql, conn);
                        command.Parameters.Add(ReceiptFooter.columnPaymentId, paymentId);

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

        public bool processDeleteString(string sql)
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
    }
}
