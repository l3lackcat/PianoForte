using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PianoForte.Model
{
    public class Book : Product
    {
        public static string tableName = "book";
        public static string columnBookId = "bookId";
        public static string columnBookBarcode = "bookBarcode";
        public static string columnOriginalBookBarcode = "originalBookBarcode";
        public static string columnBookName = "bookName";
        public static string columnBookPrice = "bookPrice";
        public static string columnBookAmount = "bookAmount";
        public static string columnStatus = "status";

        //Temporary
        public static string matchingTableName = "book_id_matching";
        public static string columnOldBookId = "oldBookId";
        public static string columnNewBookId = "newBookId";

        public enum BookStatus
        {
            ALL,
            AVAILABLE,
            EMPTY,
            CANCELED
        };

        public string OriginalBarcode { get; set; }
        public int Quantity { get; set; }
        public string Status { get; set; }

        public Book()
        {
            //Do Nothing
        }

        public Book(Book book)
        {
            this.Id = book.Id;
            this.Type = book.Type;
            this.Barcode = book.Barcode;
            this.OriginalBarcode = book.OriginalBarcode;
            this.Name = book.Name;
            this.Price = book.Price;
            this.Quantity = book.Quantity;
            this.Status = book.Status;
        }

        //public string Barcode
        //{
        //    get
        //    {
        //        return this.barcode;
        //    }

        //    set
        //    {
        //        this.barcode = value;
        //    }
        //}

        //public string OriginalBarcode
        //{
        //    get
        //    {
        //        return this.originalBarcode;
        //    }

        //    set
        //    {
        //        this.originalBarcode = value;
        //    }
        //}

        //public int Amount
        //{
        //    get
        //    {
        //        return this.amount;
        //    }

        //    set
        //    {
        //        this.amount = value;
        //    }
        //}

        //public string Status
        //{
        //    get
        //    {
        //        return this.status;
        //    }

        //    set
        //    {
        //        this.status = value;
        //    }
        //}
    }
}
