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
    public class BookDaoImplMySql : BookDao
    {
        //--------------------------------------------------------------------------------

        public bool insertBook(Book book)
        {
            string sql = "INSERT INTO " +
                         Book.tableName + " (" +
                         Book.columnBookId + ", " +
                         Book.columnBookBarcode + ", " +
                         //Book.columnOriginalBookBarcode + ", " +
                         Book.columnBookName + ", " +
                         Book.columnBookPrice + ", " +
                         Book.columnBookAmount + ", " +
                         Book.columnStatus + ") " +
                         "VALUES(" +
                         "?" + Book.columnBookId + ", " +
                         "?" + Book.columnBookBarcode + ", " +
                         //"?" + Book.columnOriginalBookBarcode + ", " +
                         "?" + Book.columnBookName + ", " +
                         "?" + Book.columnBookPrice + ", " +
                         "?" + Book.columnBookAmount + ", " +
                         "?" + Book.columnStatus + ")";

            return this.processInsertCommand(sql, book);
        }

        public bool updateBook(Book book)
        {
            string sql = "UPDATE " +
                         Book.tableName + " SET " +
                         Book.columnBookBarcode + " = ?" + Book.columnBookBarcode + ", " +
                         //Book.columnOriginalBookBarcode + " = ?" + Book.columnOriginalBookBarcode + ", " +
                         Book.columnBookName + " = ?" + Book.columnBookName + ", " +
                         Book.columnBookPrice + " = ?" + Book.columnBookPrice + ", " +
                         Book.columnBookAmount + " = ?" + Book.columnBookAmount + ", " +
                         Book.columnStatus + " = ?" + Book.columnStatus + " " +
                         "WHERE " + Book.columnBookId + " = ?" + Book.columnBookId;

            return this.processUpdateCommand(sql, book);
        }

        public bool deleteBook(int bookId)
        {
            string sql = "DELETE " +
                         "FROM " + Book.tableName + " " +
                         "WHERE " + Book.columnBookId + " = " + bookId;

            return this.processDeleteCommand(sql);
        }

        //--------------------------------------------------------------------------------

        public Book findLastBook()
        {
            Book book = null;

            string sql = "SELECT * " +
                         "FROM " + Book.tableName + " " +
                         "ORDER BY " + Book.columnBookId + " DESC " +
                         "LIMIT 1";

            List<Book> bookList = this.processSelectCommand(sql);
            if (bookList.Count > 0)
            {
                book = bookList[0];
            }

            return book;
        }

        public Book findBook(int bookId)
        {
            Book book = null;

            string sql = "SELECT * " +
                         "FROM " + Book.tableName + " " +
                         "WHERE " + Book.columnBookId + " = " + bookId;

            List<Book> bookList = this.processSelectCommand(sql);
            if (bookList.Count > 0)
            {
                book = bookList[0];
            }

            return book;
        }

        //--------------------------------------------------------------------------------

        public List<Book> findAllBook()
        {
            string sql = "SELECT * " +
                         "FROM " + Book.tableName + " " +
                         "ORDER BY " + Book.columnBookId + " ASC";

            return this.processSelectCommand(sql);
        }

        public List<Book> findAllBook(int startIndex, int offset)
        {
            string sql = "SELECT * " +
                         "FROM " + Book.tableName + " " +
                         "WHERE " + Book.columnBookId + " IN (" +
                         "SELECT * " +
                         "FROM (" +
                         "SELECT " + Book.columnBookId + " " +
                         "FROM " + Book.tableName + " " +
                         "LIMIT " + startIndex + "," + offset + ") ALIAS)" +
                         "ORDER BY " + Book.columnBookId + " ASC";

            return this.processSelectCommand(sql);
        }

        public List<Book> findAllBook(Book.BookStatus status)
        {
            string sql = "SELECT * " +
                         "FROM " + Book.tableName + " " +
                         "WHERE " + Book.columnStatus + " = '" + status.ToString() + "' " +
                         "ORDER BY " + Book.columnBookId + " ASC";

            return this.processSelectCommand(sql);
        }

        public List<Book> findAllBook(Book.BookStatus status, int startIndex, int offset)
        {
            string sql = "SELECT * " +
                         "FROM " + Book.tableName + " " +
                         "WHERE " + Book.columnBookId + " IN (" +
                         "SELECT * " +
                         "FROM (" +
                         "SELECT " + Book.columnBookId + " " +
                         "FROM " + Book.tableName + " " +
                         "WHERE " + Book.columnStatus + " = '" + status + "' " +
                         "LIMIT " + startIndex + "," + offset + ") ALIAS)" +
                         "ORDER BY " + Book.columnBookId + " ASC";

            return this.processSelectCommand(sql);
        }

        //--------------------------------------------------------------------------------

        public Book findBookByBarcode(string barcode)
        {
            Book book = null;

            string sql = "SELECT * " +
                         "FROM " + Book.tableName + " " +
                         "WHERE " + Book.columnBookBarcode + " LIKE '" + barcode + "' " +
                         "ORDER BY " + Book.columnBookId + " ASC";

            List<Book> bookList = this.processSelectCommand(sql);
            if (bookList.Count > 0)
            {
                book = bookList[0];
            }

            return book;
        }

        //public List<Book> findAllBookByBarcode(string barcode, int startIndex, int offset)
        //{
        //    string sql = "SELECT * " +
        //                 "FROM " + Book.tableName + " " +
        //                 "WHERE " + Book.columnBookId + " IN (" +
        //                 "SELECT * " +
        //                 "FROM (" +
        //                 "SELECT " + Book.columnBookId + " " +
        //                 "FROM " + Book.tableName + " " +
        //                 "WHERE " + Book.columnBookBarcode + " LIKE '%" + barcode + "%' " +
        //                 "LIMIT " + startIndex + "," + offset + ") ALIAS)" +
        //                 "ORDER BY " + Book.columnBookBarcode + " ASC";

        //    return this.processSelectCommand(sql);
        //}

        //public List<Book> findAllBookByBarcode(string barcode, Book.BookStatus status)
        //{
        //    string sql = "SELECT * " +
        //                 "FROM " + Book.tableName + " " +
        //                 "WHERE " + Book.columnBookBarcode + " LIKE '%" + barcode + "%' " +
        //                 "AND " + Book.columnStatus + " = '" + status.ToString() + "' " +
        //                 "ORDER BY " + Book.columnBookBarcode + " ASC";

        //    return this.processSelectCommand(sql);
        //}

        //public List<Book> findAllBookByBarcode(string barcode, Book.BookStatus status, int startIndex, int offset)
        //{
        //    string sql = "SELECT * " +
        //                 "FROM " + Book.tableName + " " +
        //                 "WHERE " + Book.columnBookId + " IN (" +
        //                 "SELECT * " +
        //                 "FROM (" +
        //                 "SELECT " + Book.columnBookId + " " +
        //                 "FROM " + Book.tableName + " " +
        //                 "WHERE " + Book.columnBookBarcode + " LIKE '%" + barcode + "%' " +
        //                 "AND " + Book.columnStatus + " = '" + status + "' " +
        //                 "LIMIT " + startIndex + "," + offset + ") ALIAS)" +
        //                 "ORDER BY " + Book.columnBookBarcode + " ASC";

        //    return this.processSelectCommand(sql);
        //}

        //--------------------------------------------------------------------------------

        public List<Book> findAllBookByName(string bookName)
        {
            string sql = "SELECT * " +
                         "FROM " + Book.tableName + " " +
                         "WHERE " + Book.columnBookName + " LIKE '%" + bookName + "%' " +
                         "ORDER BY " + Book.columnBookId + " ASC";

            return this.processSelectCommand(sql);
        }

        public List<Book> findAllBookByName(string bookName, int startIndex, int offset)
        {
            string sql = "SELECT * " +
                         "FROM " + Book.tableName + " " +
                         "WHERE " + Book.columnBookId + " IN (" +
                         "SELECT * " +
                         "FROM (" +
                         "SELECT " + Book.columnBookId + " " +
                         "FROM " + Book.tableName + " " +
                         "WHERE " + Book.columnBookName + " LIKE '%" + bookName + "%' " +
                         "LIMIT " + startIndex + "," + offset + ") ALIAS)" +
                         "ORDER BY " + Book.columnBookId + " ASC";

            return this.processSelectCommand(sql);
        }

        public List<Book> findAllBookByName(string bookName, Book.BookStatus status)
        {
            string sql = "SELECT * " +
                         "FROM " + Book.tableName + " " +
                         "WHERE " + Book.columnBookName + " LIKE '%" + bookName + "%' " +
                         "AND " + Book.columnStatus + " = '" + status.ToString() + "' " +
                         "ORDER BY " + Book.columnBookId + " ASC";

            return this.processSelectCommand(sql);
        }

        public List<Book> findAllBookByName(string bookName, Book.BookStatus status, int startIndex, int offset)
        {
            string sql = "SELECT * " +
                         "FROM " + Book.tableName + " " +
                         "WHERE " + Book.columnBookId + " IN (" +
                         "SELECT * " +
                         "FROM (" +
                         "SELECT " + Book.columnBookId + " " +
                         "FROM " + Book.tableName + " " +
                         "WHERE " + Book.columnBookName + " LIKE '%" + bookName + "%' " +
                         "AND " + Book.columnStatus + " = '" + status.ToString() + "' " +
                         "LIMIT " + startIndex + "," + offset + ") ALIAS)" +
                         "ORDER BY " + Book.columnBookId + " ASC";

            return this.processSelectCommand(sql);
        }

        //--------------------------------------------------------------------------------

        //public List<Book> findAllBookByBarcodeAndName(string barcode, string bookName)
        //{
        //    string sql = "SELECT * " +
        //                 "FROM " + Book.tableName + " " +
        //                 "WHERE " + Book.columnBookBarcode + " LIKE '%" + barcode + "%' " +
        //                 "AND " + Book.columnBookName + " LIKE '%" + bookName + "%' " +
        //                 "ORDER BY " + Book.columnBookBarcode + " ASC";

        //    return this.processSelectCommand(sql);
        //}

        //public List<Book> findAllBookByBarcodeAndName(string barcode, string bookName, int startIndex, int offset)
        //{
        //    string sql = "SELECT * " +
        //                 "FROM " + Book.tableName + " " +
        //                 "WHERE " + Book.columnBookId + " IN (" +
        //                 "SELECT * " +
        //                 "FROM (" +
        //                 "SELECT " + Book.columnBookId + " " +
        //                 "FROM " + Book.tableName + " " +
        //                 "WHERE " + Book.columnBookBarcode + " LIKE '%" + barcode + "%' " +
        //                 "AND " + Book.columnBookName + " LIKE '%" + bookName + "%' " +
        //                 "LIMIT " + startIndex + "," + offset + ") ALIAS)" +
        //                 "ORDER BY " + Book.columnBookBarcode + " ASC";

        //    return this.processSelectCommand(sql);
        //}

        //public List<Book> findAllBookByBarcodeAndName(string barcode, string bookName, Book.BookStatus status)
        //{
        //    string sql = "SELECT * " +
        //                 "FROM " + Book.tableName + " " +
        //                 "WHERE " + Book.columnBookBarcode + " LIKE '%" + barcode + "%' " +
        //                 "AND " + Book.columnBookName + " LIKE '%" + bookName + "%' " +
        //                 "AND " + Book.columnStatus + " = '" + status + "' " +
        //                 "ORDER BY " + Book.columnBookBarcode + " ASC";

        //    return this.processSelectCommand(sql);
        //}

        //public List<Book> findAllBookByBarcodeAndName(string barcode, string bookName, Book.BookStatus status, int startIndex, int offset)
        //{
        //    string sql = "SELECT * " +
        //                 "FROM " + Book.tableName + " " +
        //                 "WHERE " + Book.columnBookId + " IN (" +
        //                 "SELECT * " +
        //                 "FROM (" +
        //                 "SELECT " + Book.columnBookId + " " +
        //                 "FROM " + Book.tableName + " " +
        //                 "WHERE " + Book.columnBookBarcode + " LIKE '%" + barcode + "%' " +
        //                 "AND " + Book.columnBookName + " LIKE '%" + bookName + "%' " +
        //                 "AND " + Book.columnStatus + " = '" + status + "' " +
        //                 "LIMIT " + startIndex + "," + offset + ") ALIAS)" +
        //                 "ORDER BY " + Book.columnBookBarcode + " ASC";

        //    return this.processSelectCommand(sql);
        //}

        //--------------------------------------------------------------------------------

        private bool processInsertCommand(string sql, Book book)
        {
            bool returnFlag = false;

            if (book != null)
            {
                MySqlConnection conn = null;
                try
                {
                    conn = new MySqlConnection(DatabaseManager.getMySqlConnectionString());
                    if (conn != null)
                    {
                        conn.Open();

                        MySqlCommand command = new MySqlCommand(sql, conn);
                        command.Parameters.AddWithValue(Book.columnBookId, book.Id);
                        command.Parameters.AddWithValue(Book.columnBookBarcode, book.Barcode);
                        //command.Parameters.AddWithValue(Book.columnOriginalBookBarcode, book.OriginalBarcode);
                        command.Parameters.AddWithValue(Book.columnBookName, book.Name);
                        command.Parameters.AddWithValue(Book.columnBookPrice, book.Price);
                        command.Parameters.AddWithValue(Book.columnBookAmount, book.Quantity);
                        command.Parameters.AddWithValue(Book.columnStatus, book.Status);

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

        private bool processUpdateCommand(string sql, Book book)
        {
            bool returnFlag = false;

            if (book != null)
            {
                MySqlConnection conn = null;
                try
                {
                    conn = new MySqlConnection(DatabaseManager.getMySqlConnectionString());
                    if (conn != null)
                    {
                        conn.Open();

                        MySqlCommand command = new MySqlCommand(sql, conn);
                        command.Parameters.AddWithValue(Book.columnBookBarcode, book.Barcode);
                        //command.Parameters.AddWithValue(Book.columnOriginalBookBarcode, book.OriginalBarcode);
                        command.Parameters.AddWithValue(Book.columnBookName, book.Name);
                        command.Parameters.AddWithValue(Book.columnBookPrice, book.Price);
                        command.Parameters.AddWithValue(Book.columnBookAmount, book.Quantity);
                        command.Parameters.AddWithValue(Book.columnStatus, book.Status);
                        command.Parameters.AddWithValue(Book.columnBookId, book.Id);

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

        private List<Book> processSelectCommand(string sql)
        {
            List<Book> bookList = new List<Book>();

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
                    dataAdapter.Fill(data, Book.tableName);

                    for (int i = 0; i < data.Tables[Book.tableName].Rows.Count; i++)
                    {
                        bookList.Add(generateBook(data, i));
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

        private Book generateBook(DataSet data, int index)
        {
            Book book = new Book();
            book.Id = Convert.ToInt32(data.Tables[Book.tableName].Rows[index][Book.columnBookId].ToString());
            book.Type = Product.ProductType.BOOK.ToString();
            book.Barcode = data.Tables[Book.tableName].Rows[index][Book.columnBookBarcode].ToString();
            //book.OriginalBarcode = data.Tables[Book.tableName].Rows[index][Book.columnOriginalBookBarcode].ToString();
            book.Name = data.Tables[Book.tableName].Rows[index][Book.columnBookName].ToString();

            string price = data.Tables[Book.tableName].Rows[index][Book.columnBookPrice].ToString();
            if (ValidateManager.isNumber(price))
            {
                book.Price = Convert.ToDouble(price);
            }

            string amount = data.Tables[Book.tableName].Rows[index][Book.columnBookAmount].ToString();
            if (ValidateManager.isNumber(amount))
            {
                book.Quantity = Convert.ToInt32(amount);
            }

            book.Status = data.Tables[Book.tableName].Rows[index][Book.columnStatus].ToString();
            
            return book;
        }

        //--------------------------------------------------------------------------------

        //Temporary
        public bool processInsertStringForMathching(string sql, int oldBookId, int newBookId)
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
                    command.Parameters.AddWithValue(Book.columnOldBookId, oldBookId);
                    command.Parameters.AddWithValue(Book.columnNewBookId, newBookId);

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

        public int processQueryStringForMatching(string sql)
        {
            int newBookId = 0;

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
                    dataAdapter.Fill(data, Book.matchingTableName);

                    for (int i = 0; i < data.Tables[Book.matchingTableName].Rows.Count; i++)
                    {
                        newBookId = Convert.ToInt32(data.Tables[Book.matchingTableName].Rows[i][Book.columnNewBookId].ToString());
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

            return newBookId;
        }
    }
}
