using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PianoForte.Model;

namespace PianoForte.Dao
{
    public interface BookDao
    {
        bool insertBook(Book book);
        bool updateBook(Book book);
        bool deleteBook(int bookId);

        Book findBook(int bookId);
        Book findLastBook();        

        List<Book> findAllBook();
        List<Book> findAllBook(int startIndex, int offset);
        List<Book> findAllBook(Book.BookStatus satus);
        List<Book> findAllBook(Book.BookStatus status, int startIndex, int offset);

        Book findBookByBarcode(string barcode);
        //List<Book> findAllBookByBarcode(string barcode, int startIndex, int offset);
        //List<Book> findAllBookByBarcode(string barcode, Book.BookStatus status);
        //List<Book> findAllBookByBarcode(string barcode, Book.BookStatus status, int startIndex, int offset);

        List<Book> findAllBookByName(string bookName);
        List<Book> findAllBookByName(string bookName, int startIndex, int offset);
        List<Book> findAllBookByName(string bookName, Book.BookStatus status);
        List<Book> findAllBookByName(string bookName, Book.BookStatus status, int startIndex, int offset);

        //List<Book> findAllBookByBarcodeAndName(string barcode, string bookName);
        //List<Book> findAllBookByBarcodeAndName(string barcode, string bookName, int startIndex, int offset);
        //List<Book> findAllBookByBarcodeAndName(string barcode, string bookName, Book.BookStatus status);
        //List<Book> findAllBookByBarcodeAndName(string barcode, string bookName, Book.BookStatus status, int startIndex, int offset);
    }
}
