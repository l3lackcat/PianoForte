using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;

using MySql.Data.MySqlClient;

using PianoForte.Models;
using PianoForte.Resourses.DatabaseStructure.MySqlTable;

namespace PianoForte.Dao
{
    public class StudentAddressDaoImplMySql : StudentAddressDao
    {
        private bool insert(string databaseName, StudentAddress studentAddress, string sql)
        {
            bool returnFlag = false;

            if (studentAddress != null)
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
                        command.Parameters.AddWithValue(StudentAddresses.ColumnStudentId, studentAddress.StudentId);
                        command.Parameters.AddWithValue(StudentAddresses.ColumnBuildingName, studentAddress.BuildingName);
                        command.Parameters.AddWithValue(StudentAddresses.ColumnStreetAddress, studentAddress.StreetAddress);
                        command.Parameters.AddWithValue(StudentAddresses.ColumnSubdistrict, studentAddress.SubDistrict);
                        command.Parameters.AddWithValue(StudentAddresses.ColumnDistrict, studentAddress.District);
                        command.Parameters.AddWithValue(StudentAddresses.ColumnProvince, studentAddress.Province);
                        command.Parameters.AddWithValue(StudentAddresses.ColumnPostcode, studentAddress.Postcode);
                        command.Parameters.AddWithValue(StudentAddresses.ColumnCountry, studentAddress.Country);

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

        private bool update(string databaseName, StudentAddress studentAddress, string sql)
        {
            bool returnFlag = false;

            if (studentAddress != null)
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
                        command.Parameters.AddWithValue(StudentAddresses.ColumnStudentId, studentAddress.StudentId);
                        command.Parameters.AddWithValue(StudentAddresses.ColumnBuildingName, studentAddress.BuildingName);
                        command.Parameters.AddWithValue(StudentAddresses.ColumnStreetAddress, studentAddress.StreetAddress);
                        command.Parameters.AddWithValue(StudentAddresses.ColumnSubdistrict, studentAddress.SubDistrict);
                        command.Parameters.AddWithValue(StudentAddresses.ColumnDistrict, studentAddress.District);
                        command.Parameters.AddWithValue(StudentAddresses.ColumnProvince, studentAddress.Province);
                        command.Parameters.AddWithValue(StudentAddresses.ColumnPostcode, studentAddress.Postcode);
                        command.Parameters.AddWithValue(StudentAddresses.ColumnCountry, studentAddress.Country);
                        command.Parameters.AddWithValue(StudentAddresses.ColumnStudentAddressId, studentAddress.Id);

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

        private bool delete(string databaseName, string sql)
        {
            bool returnFlag = false;

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

        private List<StudentAddress> select(string databaseName, string sql)
        {
            List<StudentAddress> studentAddressList = new List<StudentAddress>();

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
                    dataAdapter.Fill(data, StudentAddresses.TableName);

                    for (int i = 0; i < data.Tables[StudentAddresses.TableName].Rows.Count; i++)
                    {
                        StudentAddress studentAddress = new StudentAddress();
                        studentAddress.Id = Convert.ToInt32(data.Tables[StudentAddresses.TableName].Rows[i][StudentAddresses.ColumnStudentAddressId].ToString());
                        studentAddress.StudentId = Convert.ToInt32(data.Tables[StudentAddresses.TableName].Rows[i][StudentAddresses.ColumnStudentId].ToString());
                        studentAddress.BuildingName = data.Tables[StudentAddresses.TableName].Rows[i][StudentAddresses.ColumnBuildingName].ToString();
                        studentAddress.StreetAddress = data.Tables[StudentAddresses.TableName].Rows[i][StudentAddresses.ColumnStreetAddress].ToString();
                        studentAddress.SubDistrict = data.Tables[StudentAddresses.TableName].Rows[i][StudentAddresses.ColumnSubdistrict].ToString();
                        studentAddress.District = data.Tables[StudentAddresses.TableName].Rows[i][StudentAddresses.ColumnDistrict].ToString();
                        studentAddress.Province = data.Tables[StudentAddresses.TableName].Rows[i][StudentAddresses.ColumnProvince].ToString();
                        studentAddress.Postcode = data.Tables[StudentAddresses.TableName].Rows[i][StudentAddresses.ColumnPostcode].ToString();
                        studentAddress.Country = data.Tables[StudentAddresses.TableName].Rows[i][StudentAddresses.ColumnCountry].ToString();

                        studentAddressList.Add(studentAddress);
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

            return studentAddressList;
        }

        public bool insertStudentAddress(string databaseName, StudentAddress studentAddress)
        {
            string sql = "INSERT INTO " +
                         StudentAddresses.TableName + " (" +
                         StudentAddresses.ColumnStudentId + ", " +
                         StudentAddresses.ColumnBuildingName + ", " +
                         StudentAddresses.ColumnStreetAddress + ", " +
                         StudentAddresses.ColumnSubdistrict + ", " +
                         StudentAddresses.ColumnDistrict + ", " +
                         StudentAddresses.ColumnProvince + ", " +
                         StudentAddresses.ColumnPostcode + ", " +
                         StudentAddresses.ColumnCountry + ") " +
                         "VALUES(" +
                         "?" + StudentAddresses.ColumnStudentId + ", " +
                         "?" + StudentAddresses.ColumnBuildingName + ", " +
                         "?" + StudentAddresses.ColumnStreetAddress + ", " +
                         "?" + StudentAddresses.ColumnSubdistrict + ", " +
                         "?" + StudentAddresses.ColumnDistrict + ", " +
                         "?" + StudentAddresses.ColumnProvince + ", " +
                         "?" + StudentAddresses.ColumnPostcode + ", " +
                         "?" + StudentAddresses.ColumnCountry + ")";

            return this.insert(databaseName, studentAddress, sql);
        }

        public bool updateStudentAddress(string databaseName, StudentAddress studentAddress)
        {
            string sql = "UPDATE " +
                         StudentAddresses.TableName + " SET " +
                         StudentAddresses.ColumnBuildingName + " = ?" + StudentAddresses.ColumnBuildingName + ", " +
                         StudentAddresses.ColumnStreetAddress + " = ?" + StudentAddresses.ColumnStreetAddress + ", " +
                         StudentAddresses.ColumnSubdistrict + " = ?" + StudentAddresses.ColumnSubdistrict + ", " +
                         StudentAddresses.ColumnDistrict + " = ?" + StudentAddresses.ColumnDistrict + ", " +
                         StudentAddresses.ColumnProvince + " = ?" + StudentAddresses.ColumnProvince + ", " +
                         StudentAddresses.ColumnPostcode + " = ?" + StudentAddresses.ColumnPostcode + ", " +
                         StudentAddresses.ColumnCountry + " = ?" + StudentAddresses.ColumnCountry + " " +
                         "WHERE " + Students.ColumnStudentId + " = ?" + Students.ColumnStudentId;

            return this.update(databaseName, studentAddress, sql);
        }

        public bool deleteStudentAddress(string databaseName, int studentId)
        {
            string sql = "DELETE " +
                         "FROM " + StudentAddresses.TableName + " " +
                         "WHERE " + StudentAddresses.ColumnStudentId + " = " + studentId;

            return this.delete(databaseName, sql);
        }

        public List<StudentAddress> getStudentAddressList(string databaseName, int studentId)
        {
            string sql = "SELECT * " +
                         "FROM " + StudentAddresses.TableName + " " +
                         "WHERE " + StudentAddresses.ColumnStudentId + " = " + studentId + " " +
                         "ORDER BY " + StudentAddresses.ColumnStudentAddressId + " ASC";

            return this.select(databaseName, sql);
        }
    }
}