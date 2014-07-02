using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using PianoForte.Dao;
using PianoForte.Enum;
using PianoForte.Models;

namespace PianoForte.Services
{
    public class BookService
    {
        private static BookDao bookDao = DaoFactory.getDaoFactory(DaoFactory.FactoryType.MYSQL).getBookDao();

        public static int getNewBookId(string databaseName)
        {
            int newBookId = 0;

            Book book = bookDao.getLastBook(databaseName);
            if (book != null)
            {
                newBookId = book.Id + 1;
            }
            else
            {
                newBookId = ((int)Enum.ProductType.BOOK * 1000000) + 1;
            }

            return newBookId;
        }

        public static bool insertBook(string databaseName, Book book)
        {
            return bookDao.insertBook(databaseName, book);
        }

        public static bool updateBook(string databaseName, Book book)
        {
            return bookDao.updateBook(databaseName, book);
        }

        public static Book getBook(string databaseName, int id)
        {
            return bookDao.getBook(databaseName, id);
        }

        public static Book getBook(string databaseName, string barcode)
        {
            return bookDao.getBook(databaseName, barcode);
        }

        public static Book getLastBook(string databaseName)
        {
            return bookDao.getLastBook(databaseName);
        }

        public static List<Book> getBookList(string databaseName)
        {
            return bookDao.getBookList(databaseName);
        }

        public static List<Book> getBookList(string databaseName, int startIndex, int offset)
        {
            return bookDao.getBookList(databaseName, startIndex, offset);
        }

        public static List<Book> getBookList(string databaseName, int startIndex, int offset, string keyword)
        {
            return bookDao.getBookList(databaseName, startIndex, offset, keyword);
        }

        public static List<Book> getBookListByName(string databaseName, string name)
        {
            return bookDao.getBookListByName(databaseName, name);
        }
    }
}