using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PianoForte.Dao;
using PianoForte.Model;

namespace PianoForte.Service
{
    public class BookService
    {
        private BookDao bookDao = new BookDao();

        public bool addBook(Book book)
        {
            string sql = "INSERT INTO " +
                         Book.tableName + " (" +
                         Book.columnBookId + ", " +
                         Book.columnBookBarcode + ", " +
                         Book.columnOriginalBookBarcode + ", " +
                         Book.columnBookName + ", " +
                         Book.columnBookPrice + ", " +
                         Book.columnBookAmount + ", " +
                         Book.columnStatus + ") " +
                         "VALUES(" +
                         "?" + Book.columnBookId + ", " +
                         "?" + Book.columnBookBarcode + ", " +
                         "?" + Book.columnOriginalBookBarcode + ", " +
                         "?" + Book.columnBookName + ", " +
                         "?" + Book.columnBookPrice + ", " +
                         "?" + Book.columnBookAmount + ", " +
                         "?" + Book.columnStatus + ")";

            return this.bookDao.processInsertString(sql, book);
        }

        public bool updateBook(Book book)
        {
            string sql = "UPDATE " + 
                         Book.tableName + " SET " +
                         Book.columnBookBarcode + " = ?" + Book.columnBookBarcode + ", " +
                         Book.columnOriginalBookBarcode + " = ?" + Book.columnOriginalBookBarcode + ", " +
                         Book.columnBookName + " = ?" + Book.columnBookName + ", " +
                         Book.columnBookPrice + " = ?" + Book.columnBookPrice + ", " +
                         Book.columnBookAmount + " = ?" + Book.columnBookAmount + ", " +
                         Book.columnStatus + " = ?" + Book.columnStatus + " " +
                         "WHERE " + Book.columnBookId + " = ?" + Book.columnBookId;

            return this.bookDao.processUpdateString(sql, book);
        }

        public bool deleteBook(int bookId)
        {
            string sql = "DELETE " +
                         "FROM " + Book.tableName + " " +
                         "WHERE " + Book.columnBookId + " = " + bookId;

            return this.bookDao.processDeleteString(sql);
        }

        public Book getLastBook()
        {
            Book book = null;

            string sql = "SELECT * " +
                         "FROM " + Book.tableName + " " +
                         "ORDER BY " + Book.columnBookId + " DESC " +
                         "LIMIT 1";

            List<Book> bookList = this.bookDao.processQueryString(sql);
            if (bookList.Count > 0)
            {
                book = bookList[0];
            }

            return book;
        }

        public Book getBook(int bookId)
        {
            Book book = null;

            string sql = "SELECT * " +
                         "FROM " + Book.tableName + " " +
                         "WHERE " + Book.columnBookId + " = " + bookId;

            List<Book> bookList = this.bookDao.processQueryString(sql);
            if (bookList.Count > 0)
            {
                book = bookList[0];
            }

            return book;
        }

        public List<Book> getAllBook()
        {
            string sql = "SELECT * " +
                         "FROM " + Book.tableName + " " +
                         "ORDER BY " + Book.columnBookBarcode + " ASC";

            return this.bookDao.processQueryString(sql);
        }

        public List<Book> getAllBook(int startIndex, int offset)
        {
            string sql = "SELECT * " +
                         "FROM " + Book.tableName + " " +
                         "WHERE " + Book.columnBookId + " IN (" +
                         "SELECT * " +
                         "FROM (" +
                         "SELECT " + Book.columnBookId + " " +
                         "FROM " + Book.tableName + " " +
                         "LIMIT " + startIndex + "," + offset + ") ALIAS)" +
                         "ORDER BY " + Book.columnBookBarcode + " ASC"; 

            return this.bookDao.processQueryString(sql);
        }        

        public List<Book> getAllBook(string status)
        {
            string sql = "SELECT * " +
                         "FROM " + Book.tableName + " " +
                         "WHERE " + Book.columnStatus + " = '" + status + "' " +
                         "ORDER BY " + Book.columnBookBarcode + " ASC";
 
            return this.bookDao.processQueryString(sql);
        }

        public List<Book> getAllBook(string status, int startIndex, int offset)
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
                         "ORDER BY " + Book.columnBookBarcode + " ASC";

            return this.bookDao.processQueryString(sql);
        }

        public List<Book> getAllBookByBarcode(string bookBarcode)
        {
            string sql = "SELECT * " +
                         "FROM " + Book.tableName + " " +
                         "WHERE " + Book.columnBookBarcode + " LIKE '%" + bookBarcode + "%' " +
                         "ORDER BY " + Book.columnBookBarcode + " ASC";

            return this.bookDao.processQueryString(sql);
        }

        public List<Book> getAllBookByBarcode(string bookBarcode, int startIndex, int offset)
        {
            string sql = "SELECT * " +
                         "FROM " + Book.tableName + " " +
                         "WHERE " + Book.columnBookId + " IN (" +
                         "SELECT * " +
                         "FROM (" +
                         "SELECT " + Book.columnBookId + " " +
                         "FROM " + Book.tableName + " " +
                         "WHERE " + Book.columnBookBarcode + " LIKE '%" + bookBarcode + "%' " +
                         "LIMIT " + startIndex + "," + offset + ") ALIAS)" +
                         "ORDER BY " + Book.columnBookBarcode + " ASC";

            return this.bookDao.processQueryString(sql);
        }

        public List<Book> getAllBookByBarcode(string bookBarcode, string status)
        {
            string sql = "SELECT * " +
                         "FROM " + Book.tableName + " " +
                         "WHERE " + Book.columnBookBarcode + " LIKE '%" + bookBarcode + "%' " +
                         "AND " + Book.columnStatus + " = '" + status + "' " +
                         "ORDER BY " + Book.columnBookBarcode + " ASC";

            return this.bookDao.processQueryString(sql);
        }

        public List<Book> getAllBookByBarcode(string bookBarcode, string status, int startIndex, int offset)
        {
            string sql = "SELECT * " +
                         "FROM " + Book.tableName + " " +
                         "WHERE " + Book.columnBookId + " IN (" +
                         "SELECT * " +
                         "FROM (" +
                         "SELECT " + Book.columnBookId + " " +
                         "FROM " + Book.tableName + " " +
                         "WHERE " + Book.columnBookBarcode + " LIKE '%" + bookBarcode + "%' " +
                         "AND " + Book.columnStatus + " = '" + status + "' " +
                         "LIMIT " + startIndex + "," + offset + ") ALIAS)" +
                         "ORDER BY " + Book.columnBookBarcode + " ASC";

            return this.bookDao.processQueryString(sql);
        }

        public List<Book> getAllBookByName(string bookName)
        {
            string sql = "SELECT * " +
                         "FROM " + Book.tableName + " " +
                         "WHERE " + Book.columnBookName + " LIKE '%" + bookName + "%' " +
                         "ORDER BY " + Book.columnBookBarcode + " ASC";

            return this.bookDao.processQueryString(sql);
        }                

        public List<Book> getAllBookByName(string bookName, int startIndex, int offset)
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
                         "ORDER BY " + Book.columnBookBarcode + " ASC";

            return this.bookDao.processQueryString(sql);
        }

        public List<Book> getAllBookByName(string bookName, string status)
        {
            string sql = "SELECT * " +
                         "FROM " + Book.tableName + " " +
                         "WHERE " + Book.columnBookName + " LIKE '%" + bookName + "%' " +
                         "AND " + Book.columnStatus + " = '" + status + "' " +
                         "ORDER BY " + Book.columnBookBarcode + " ASC";

            return this.bookDao.processQueryString(sql);
        }

        public List<Book> getAllBookByName(string bookName, string status, int startIndex, int offset)
        {
            string sql = "SELECT * " +
                         "FROM " + Book.tableName + " " +
                         "WHERE " + Book.columnBookId + " IN (" +
                         "SELECT * " +
                         "FROM (" +
                         "SELECT " + Book.columnBookId + " " +
                         "FROM " + Book.tableName + " " +
                         "WHERE " + Book.columnBookName + " LIKE '%" + bookName + "%' " +
                         "AND " + Book.columnStatus + " = '" + status + "' " +
                         "LIMIT " + startIndex + "," + offset + ") ALIAS)" +
                         "ORDER BY " + Book.columnBookBarcode + " ASC";

            return this.bookDao.processQueryString(sql);

        }

        public List<Book> getAllBookByBarcodeAndName(string bookBarcode, string bookName)
        {
            string sql = "SELECT * " +
                         "FROM " + Book.tableName + " " +
                         "WHERE " + Book.columnBookBarcode + " LIKE '%" + bookBarcode + "%' " +
                         "AND " + Book.columnBookName + " LIKE '%" + bookName + "%' " +
                         "ORDER BY " + Book.columnBookBarcode + " ASC";

            return this.bookDao.processQueryString(sql);
        }

        public List<Book> getAllBookByBarcodeAndName(string bookBarcode, string bookName, int startIndex, int offset)
        {
            string sql = "SELECT * " +
                         "FROM " + Book.tableName + " " +
                         "WHERE " + Book.columnBookId + " IN (" +
                         "SELECT * " +
                         "FROM (" +
                         "SELECT " + Book.columnBookId + " " +
                         "FROM " + Book.tableName + " " +
                         "WHERE " + Book.columnBookBarcode + " LIKE '%" + bookBarcode + "%' " +
                         "AND " + Book.columnBookName + " LIKE '%" + bookName + "%' " +
                         "LIMIT " + startIndex + "," + offset + ") ALIAS)" +
                         "ORDER BY " + Book.columnBookBarcode + " ASC";

            return this.bookDao.processQueryString(sql);
        }

        public List<Book> getAllBookByBarcodeAndName(string bookBarcode, string bookName, string status)
        {
            string sql = "SELECT * " +
                         "FROM " + Book.tableName + " " +
                         "WHERE " + Book.columnBookBarcode + " LIKE '%" + bookBarcode + "%' " +
                         "AND " + Book.columnBookName + " LIKE '%" + bookName + "%' " +
                         "AND " + Book.columnStatus + " = '" + status + "' " +
                         "ORDER BY " + Book.columnBookBarcode + " ASC";

            return this.bookDao.processQueryString(sql);
        }

        public List<Book> getAllBookByBarcodeAndName(string bookBarcode, string bookName, string status, int startIndex, int offset)
        {
            string sql = "SELECT * " +
                         "FROM " + Book.tableName + " " +
                         "WHERE " + Book.columnBookId + " IN (" +
                         "SELECT * " +
                         "FROM (" +
                         "SELECT " + Book.columnBookId + " " +
                         "FROM " + Book.tableName + " " +
                         "WHERE " + Book.columnBookBarcode + " LIKE '%" + bookBarcode + "%' " +
                         "AND " + Book.columnBookName + " LIKE '%" + bookName + "%' " +
                         "AND " + Book.columnStatus + " = '" + status + "' " +
                         "LIMIT " + startIndex + "," + offset + ") ALIAS)" +
                         "ORDER BY " + Book.columnBookBarcode + " ASC";

            return this.bookDao.processQueryString(sql);
        }

        public int getNewBookId(int oldBookId)
        {
            string sql = "SELECT * " +
                         "FROM " + Book.matchingTableName + " " +
                         "WHERE " + Book.columnOldBookId + " = " + oldBookId;

            return this.bookDao.processQueryStringForMatching(sql);
        }

        //Temporary
        public List<Book> getAllBook_Old()
        {
            string sql = "SELECT * " +
                         "FROM " + Book.tableName + "_old " +
                         "ORDER BY " + Book.columnBookId + " ASC";

            return this.bookDao.processQueryString(sql);
        }

        public bool matchBookId(int oldBookId, int newBookId)
        {
            string sql = "INSERT INTO " +
                         Book.matchingTableName + " (" +
                         Book.columnOldBookId + ", " +
                         Book.columnNewBookId + ") " +
                         "VALUES(" +
                         "?" + Book.columnOldBookId + ", " +
                         "?" + Book.columnNewBookId + ")";

            return this.bookDao.processInsertStringForMathching(sql, oldBookId, newBookId);
        }        
    }
}
