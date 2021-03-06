﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Globalization;

using PianoForte.Enum;
using PianoForte.Models;
using PianoForte.Services;

namespace PianoForte.WebServices
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [System.Web.Script.Services.ScriptService]
    public class BookWebService : System.Web.Services.WebService
    {
        private int delay = 1500;

        [WebMethod]
        public List<Object> getBookList(string databaseName)
        {
            System.Threading.Thread.Sleep(delay);

            List<Object> displayedBookList = new List<Object>();
            List<Book> bookList = BookService.getBookList(databaseName);
            foreach (Book book in bookList)
            {
                displayedBookList.Add(new
                {
                    id = book.Id,
                    barcode = book.Barcode,
                    name = book.Name,
                    unitPrice = book.UnitPrice,
                    quantity = book.Quantity,
                    status = book.Status
                });
            }

            return displayedBookList;
        }

        [WebMethod]
        public Object getBookById(string databaseName, int id)
        {
            System.Threading.Thread.Sleep(delay);

            Object displayedBook = null;
            Book book = BookService.getBook(databaseName, id);
            if (book != null)
            {
                displayedBook = new {
                    id = book.Id,
                    barcode = book.Barcode,
                    name = book.Name,
                    unitPrice = book.UnitPrice,
                    quantity = book.Quantity,
                    status = book.Status
                };
            }

            return displayedBook;
        }

        [WebMethod]
        public Object getBookByBarcode(string databaseName, string barcode)
        {
            System.Threading.Thread.Sleep(delay);

            Object displayedBook = null;
            Book book = BookService.getBook(databaseName, barcode);
            if (book != null)
            {
                displayedBook = new
                {
                    id = book.Id,
                    barcode = book.Barcode,
                    name = book.Name,
                    unitPrice = book.UnitPrice,
                    quantity = book.Quantity,
                    status = book.Status
                };
            }

            return displayedBook;
        }

        [WebMethod]
        public int insertBookInfo(string databaseName, Book book)
        {
            System.Threading.Thread.Sleep(delay);

            book.Id = BookService.getNextBookId(databaseName);

            bool isInsertSuccess = BookService.insertBook(databaseName, book);
            if (isInsertSuccess == false)
            {
                book.Id = 0;
            }

            return book.Id;
        }

        [WebMethod]
        public bool updateBookInfo(string databaseName, Book book)
        {
            System.Threading.Thread.Sleep(delay);
            return BookService.updateBook(databaseName, book);
        }
    }
}
