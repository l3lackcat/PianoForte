using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PianoForte.Models;

namespace PianoForte.Dao
{
    public interface BookDao
    {
        bool insertBook(string databaseName, Book book);

        bool updateBook(string databaseName, Book book);

        Book getBook(string databaseName, int id);

        Book getBook(string databaseName, string barcode);

        Book getLastBook(string databaseName);

        List<Book> getBookList(string databaseName);

        List<Book> getBookList(string databaseName, int startIndex, int offset);

        List<Book> getBookList(string databaseName, int startIndex, int offset, string keyword);

        List<Book> getBookListByName(string databaseName, string name);
    }
}
