using System;
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
        [WebMethod]
        public List<Object> getBookList(string databaseName)
        {
            System.Threading.Thread.Sleep(1500);

            List<Object> displayedBookList = new List<Object>();
            List<Book> bookList = BookService.getBookList(databaseName);
            foreach (Book book in bookList)
            {
                displayedBookList.Add(new
                {
                    id = book.Id,
                    barcode = book.Barcode,
                    name = book.Name,
                    unitPrice = new{
                        raw = book.UnitPrice,
                        formatted = book.UnitPrice.ToString("N", new CultureInfo("en-US"))
                    },
                    quantity = book.Quantity,
                    status = book.Status
                });
            }

            return displayedBookList;
        }

        [WebMethod]
        public Object getBookById(string databaseName, int bookId)
        {
            System.Threading.Thread.Sleep(1500);

            Object displayedBook = null;
            Book book = BookService.getBook(databaseName, bookId);
            if (book != null)
            {
                displayedBook = new {
                    id = book.Id,
                    barcode = book.Barcode,
                    name = book.Name,
                    unitPrice = new
                    {
                        raw = book.UnitPrice,
                        formatted = book.UnitPrice.ToString("N", new CultureInfo("en-US"))
                    },
                    quantity = book.Quantity,
                    status = book.Status
                };
            }

            return displayedBook;
        }

        [WebMethod]
        public Object getBookByBarcode(string databaseName, string bookBarcode)
        {
            System.Threading.Thread.Sleep(1500);

            Object displayedBook = null;
            Book book = BookService.getBook(databaseName, bookBarcode);
            if (book != null)
            {
                displayedBook = new
                {
                    id = book.Id,
                    barcode = book.Barcode,
                    name = book.Name,
                    unitPrice = new
                    {
                        raw = book.UnitPrice,
                        formatted = book.UnitPrice.ToString("N", new CultureInfo("en-US"))
                    },
                    quantity = book.Quantity,
                    status = book.Status
                };
            }

            return displayedBook;
        }

        [WebMethod]
        public bool updateBookInfo(string databaseName, Book book)
        {
            System.Threading.Thread.Sleep(1500);
            return BookService.updateBook(databaseName, book);
        }
    }
}
