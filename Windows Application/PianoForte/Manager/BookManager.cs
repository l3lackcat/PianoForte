using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PianoForte.Dao;
using PianoForte.Model;

namespace PianoForte.Manager
{
    public class BookManager
    {
        private static BookDao bookDao = DaoFactory.getDaoFactory(DaoFactory.FactoryType.MYSQL).getBookDao();

        //--------------------------------------------------------------------------------

        public static int getNewBookId()
        {
            int newBookId = 0;

            Book book = bookDao.findLastBook();
            if (book != null)
            {
                newBookId = book.Id + 1;
            }
            else
            {
                newBookId = ((int)Product.ProductType.BOOK * 1000000) + 1;
            }

            return newBookId;
        }

        //--------------------------------------------------------------------------------

        public static bool insertBook(Book book)
        {
            return bookDao.insertBook(book);
        }

        public static bool updateBook(Book book)
        {
            return bookDao.updateBook(book);
        }

        public static bool deleteBook(int bookId)
        {
            return bookDao.deleteBook(bookId);
        }

        //--------------------------------------------------------------------------------

        public static Book findBook(int bookId)
        {
            return bookDao.findBook(bookId);
        }

        //--------------------------------------------------------------------------------

        public static List<Book> findAllBook()
        {
            return bookDao.findAllBook();           
        }      

        public static List<Book> findAllBook(int startIndex, int offset)
        {
            return bookDao.findAllBook(startIndex, offset);
        }

        public static List<Book> findAllBook(Book.BookStatus status)
        {
            List<Book> bookList;

            if (status == Book.BookStatus.ALL)
            {
                bookList = bookDao.findAllBook();
            }
            else
            {
                bookList = bookDao.findAllBook(status);
            }

            return bookList;
        }

        public static List<Book> findAllBook(Book.BookStatus status, int startIndex, int offset)
        {
            List<Book> bookList;

            if (status == Book.BookStatus.ALL)
            {
                bookList = bookDao.findAllBook(startIndex, offset);
            }
            else
            {
                bookList = bookDao.findAllBook(status, startIndex, offset);
            }

            return bookList;
        }

        //--------------------------------------------------------------------------------

        public static Book findBookByBarcode(string barcode)
        {
            return bookDao.findBookByBarcode(barcode);
        }

        //public static List<Book> findAllBookByBarcode(string barcode, int startIndex, int offset)
        //{
        //    return bookDao.findAllBookByBarcode(barcode, startIndex, offset);
        //}

        //public static List<Book> findAllBookByBarcode(string barcode, Book.BookStatus status)
        //{
        //    List<Book> bookList;

        //    if (status == Book.BookStatus.ALL)
        //    {
        //        bookList = bookDao.findAllBookByBarcode(barcode);
        //    }
        //    else
        //    {
        //        bookList = bookDao.findAllBookByBarcode(barcode, status);
        //    }

        //    return bookList;
        //}

        //public static List<Book> findAllBookByBarcode(string barcode, Book.BookStatus status, int startIndex, int offset)
        //{
        //    List<Book> bookList;

        //    if (status == Book.BookStatus.ALL)
        //    {
        //        bookList = bookDao.findAllBookByBarcode(barcode, startIndex, offset);
        //    }
        //    else
        //    {
        //        bookList = bookDao.findAllBookByBarcode(barcode, status, startIndex, offset);
        //    }

        //    return bookList;
        //}

        //--------------------------------------------------------------------------------

        public static List<Book> findAllBookByName(string bookName)
        {
            return bookDao.findAllBookByName(bookName);
        }

        public static List<Book> findAllBookByName(string bookName, int startIndex, int offset)
        {
            return bookDao.findAllBookByName(bookName, startIndex, offset);
        }

        public static List<Book> findAllBookByName(string bookName, Book.BookStatus status)
        {
            List<Book> bookList;

            if (status == Book.BookStatus.ALL)
            {
                bookList = bookDao.findAllBookByName(bookName);
            }
            else
            {
                bookList = bookDao.findAllBookByName(bookName, status);
            }

            return bookList;
        }

        public static List<Book> findAllBookByName(string bookName, Book.BookStatus status, int startIndex, int offset)
        {
            List<Book> bookList;

            if (status == Book.BookStatus.ALL)
            {
                bookList = bookDao.findAllBookByName(bookName, startIndex, offset);
            }
            else
            {
                bookList = bookDao.findAllBookByName(bookName, status, startIndex, offset);
            }

            return bookList;
        }

        //--------------------------------------------------------------------------------

        //public static List<Book> findAllBookByBarcodeAndName(string barcode, string bookName)
        //{
        //    return bookDao.findAllBookByBarcodeAndName(barcode, bookName);
        //}

        //public static List<Book> findAllBookByBarcodeAndName(string barcode, string bookName, int startIndex, int offset)
        //{
        //    return bookDao.findAllBookByBarcodeAndName(barcode, bookName, startIndex, offset);
        //}

        //public static List<Book> findAllBookByBarcodeAndName(string barcode, string bookName, Book.BookStatus status)
        //{
        //    List<Book> bookList;

        //    if (status == Book.BookStatus.ALL)
        //    {
        //        bookList = bookDao.findAllBookByBarcodeAndName(barcode, bookName);
        //    }
        //    else
        //    {
        //        bookList = bookDao.findAllBookByBarcodeAndName(barcode, bookName, status);
        //    }

        //    return bookList;
        //}

        //public static List<Book> findAllBookByBarcodeAndName(string barcode, string bookName, Book.BookStatus status, int startIndex, int offset)
        //{
        //    List<Book> bookList;

        //    if (status == Book.BookStatus.ALL)
        //    {
        //        bookList = bookDao.findAllBookByBarcodeAndName(barcode, bookName, startIndex, offset);
        //    }
        //    else
        //    {
        //        bookList = bookDao.findAllBookByBarcodeAndName(barcode, bookName, status, startIndex, offset);
        //    }

        //    return bookList;
        //}

        //--------------------------------------------------------------------------------

        //public static int getNewBookId(int oldBookId)
        //{
        //    return bookDao.getNewBookId(oldBookId);
        //}

        //Temporary
        //public static List<Book> getAllBook_Old()
        //{
        //    return bookService.getAllBook_Old();
        //}

        //public static bool matchBookId(int oldBookId, int newBookId)
        //{
        //    return bookService.matchBookId(oldBookId, newBookId);
        //}        
    }
}
