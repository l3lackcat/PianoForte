using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;

using MySql.Data.MySqlClient;

using PianoForte.Enum;
using PianoForte.Models;
using PianoForte.Resourses.DatabaseStructure.MySqlTable;

namespace PianoForte.Dao
{
    public class BookDaoImplMySql : BookDao
    {
        private bool insert(string databaseName, Book book, string sql)
        {
            bool returnFlag = false;

            if (book != null)
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
                        command.Parameters.AddWithValue(Books.ColumnBookId, book.Id);
                        command.Parameters.AddWithValue(Books.ColumnBookInternalBarcode, book.InternalBarcode);
                        command.Parameters.AddWithValue(Books.ColumnBookOriginalBarcode, book.OriginalBarcode);
                        command.Parameters.AddWithValue(Books.ColumnBookName, book.Name);
                        command.Parameters.AddWithValue(Books.ColumnBookUnitPrice, book.UnitPrice);
                        command.Parameters.AddWithValue(Books.ColumnBookQuantity, book.Quantity);
                        command.Parameters.AddWithValue(Books.ColumnBookStatus, (int)book.Status);

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

        private bool update(string databaseName, Book book, string sql)
        {
            bool returnFlag = false;

            if (book != null)
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
                        command.Parameters.AddWithValue(Books.ColumnBookInternalBarcode, book.InternalBarcode);
                        command.Parameters.AddWithValue(Books.ColumnBookOriginalBarcode, book.OriginalBarcode);
                        command.Parameters.AddWithValue(Books.ColumnBookName, book.Name);
                        command.Parameters.AddWithValue(Books.ColumnBookUnitPrice, book.UnitPrice);
                        command.Parameters.AddWithValue(Books.ColumnBookQuantity, book.Quantity);
                        command.Parameters.AddWithValue(Books.ColumnBookStatus, (int)book.Status);
                        command.Parameters.AddWithValue(Books.ColumnBookId, book.Id);

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

        private Book selectBook(string databaseName, string sql)
        {
            Book book = null;

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
                    dataAdapter.Fill(data, Books.TableName);

                    for (int i = 0; i < data.Tables[Books.TableName].Rows.Count; i++)
                    {
                        book = new Book();
                        book.Id = Convert.ToInt32(data.Tables[Books.TableName].Rows[i][Books.ColumnBookId].ToString());
                        book.InternalBarcode = data.Tables[Books.TableName].Rows[i][Books.ColumnBookInternalBarcode].ToString();
                        book.OriginalBarcode = data.Tables[Books.TableName].Rows[i][Books.ColumnBookOriginalBarcode].ToString();
                        book.Name = data.Tables[Books.TableName].Rows[i][Books.ColumnBookName].ToString();
                        book.UnitPrice = Convert.ToDouble(data.Tables[Books.TableName].Rows[i][Books.ColumnBookUnitPrice].ToString());
                        book.Quantity = Convert.ToInt32(data.Tables[Books.TableName].Rows[i][Books.ColumnBookQuantity].ToString());
                        book.Status = EnumConverter.ToStatus(data.Tables[Books.TableName].Rows[i][Books.ColumnBookStatus].ToString());
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

            return book;
        }

        private List<Book> selectBookList(string databaseName, string sql)
        {
            List<Book> bookList = new List<Book>();

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
                    dataAdapter.Fill(data, Books.TableName);

                    for (int i = 0; i < data.Tables[Books.TableName].Rows.Count; i++)
                    {
                        Book book = new Book();
                        book.Id = Convert.ToInt32(data.Tables[Books.TableName].Rows[i][Books.ColumnBookId].ToString());
                        book.InternalBarcode = data.Tables[Books.TableName].Rows[i][Books.ColumnBookInternalBarcode].ToString();
                        book.OriginalBarcode = data.Tables[Books.TableName].Rows[i][Books.ColumnBookOriginalBarcode].ToString();
                        book.Name = data.Tables[Books.TableName].Rows[i][Books.ColumnBookName].ToString();
                        book.UnitPrice = Convert.ToDouble(data.Tables[Books.TableName].Rows[i][Books.ColumnBookUnitPrice].ToString());
                        book.Quantity = Convert.ToInt32(data.Tables[Books.TableName].Rows[i][Books.ColumnBookQuantity].ToString());
                        book.Status = EnumConverter.ToStatus(data.Tables[Books.TableName].Rows[i][Books.ColumnBookStatus].ToString());

                        bookList.Add(book);
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

            return bookList;
        }

        public bool insertBook(string databaseName, Book book)
        {
            string sql = "INSERT INTO " +
                         Books.TableName + " (" +
                         Books.ColumnBookId + ", " +
                         Books.ColumnBookInternalBarcode + ", " +
                         Books.ColumnBookOriginalBarcode + ", " +
                         Books.ColumnBookName + ", " +
                         Books.ColumnBookUnitPrice + ", " +
                         Books.ColumnBookQuantity + ", " +
                         Books.ColumnBookStatus + ") " +
                         "VALUES(" +
                         "?" + Books.ColumnBookId + ", " +
                         "?" + Books.ColumnBookInternalBarcode + ", " +
                         "?" + Books.ColumnBookOriginalBarcode + ", " +
                         "?" + Books.ColumnBookName + ", " +
                         "?" + Books.ColumnBookUnitPrice + ", " +
                         "?" + Books.ColumnBookQuantity + ", " +
                         "?" + Books.ColumnBookStatus + ")";

            return this.insert(databaseName, book, sql);
        }

        public bool updateBook(string databaseName, Book book)
        {
            string sql = "UPDATE " +
                         Books.TableName + " SET " +
                         Books.ColumnBookInternalBarcode + " = ?" + Books.ColumnBookInternalBarcode + ", " +
                         Books.ColumnBookOriginalBarcode + " = ?" + Books.ColumnBookOriginalBarcode + ", " +
                         Books.ColumnBookName + " = ?" + Books.ColumnBookName + ", " +
                         Books.ColumnBookUnitPrice + " = ?" + Books.ColumnBookUnitPrice + ", " +
                         Books.ColumnBookQuantity + " = ?" + Books.ColumnBookQuantity + ", " +
                         Books.ColumnBookStatus + " = ?" + Books.ColumnBookStatus + " " +
                         "WHERE " + Books.ColumnBookId + " = ?" + Books.ColumnBookId;

            return this.update(databaseName, book, sql);
        }

        public Book getBook(string databaseName, int bookId)
        {
            string sql = "SELECT * " +
                         "FROM " + Books.TableName + " " +
                         "WHERE " + Books.ColumnBookId + " = " + bookId;

            return this.selectBook(databaseName, sql);
        }

        public Book getLastBook(string databaseName)
        {
            string sql = "SELECT * " +
                         "FROM " + Books.TableName + " " +
                         "ORDER BY " + Books.ColumnBookId + " DESC " +
                         "LIMIT 1";

            return this.selectBook(databaseName, sql);
        }

        public List<Book> getBookList(string databaseName)
        {
            string sql = "SELECT * " +
                         "FROM " + Books.TableName + " " +
                         "ORDER BY " + Books.ColumnBookId + " ASC";

            return this.selectBookList(databaseName, sql);
        }

        public List<Book> getBookList(string databaseName, int startIndex, int offset)
        {
            string sql = "SELECT * " +
                         "FROM " + Books.TableName + " " +
                         "ORDER BY " + Books.ColumnBookId + " ASC " +
                         "LIMIT " + startIndex + "," + offset;

            return this.selectBookList(databaseName, sql);
        }

        public List<Book> getBookList(string databaseName, int startIndex, int offset, string keyword)
        {
            string sql = "SELECT * " +
                         "FROM " + Books.TableName + " " +
                         "WHERE " + Books.ColumnBookName + " LIKE '%" + keyword + "%' " +
                         "ORDER BY " + Books.ColumnBookId + " ASC " +
                         "LIMIT " + startIndex + "," + offset;

            return this.selectBookList(databaseName, sql);
        }

        public List<Book> getBookListByName(string databaseName, string bookName)
        {
            string sql = "SELECT * " +
                         "FROM " + Books.TableName + " " +
                         "WHERE " + Books.ColumnBookName + " = '" + bookName + "' " +
                         "ORDER BY " + Books.ColumnBookId + " ASC";

            return this.selectBookList(databaseName, sql);
        }
    }
}