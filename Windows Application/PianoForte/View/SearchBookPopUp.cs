using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using PianoForte.Model;
using PianoForte.Manager;

namespace PianoForte.View
{
    public partial class SearchBookPopUp : Form
    {
        private Form caller;
        private List<Book> bookList;

        public SearchBookPopUp()
        {
            InitializeComponent();
        }

        public void showFormDialog(Form caller)
        {
            this.caller = caller;

            this.initialBookList();
            this.initialDataGridViewBookList();
            this.updateDataGridViewBookList();
            
            this.ShowDialog();
        }

        private void initialBookList()
        {
            this.bookList = BookManager.findAllBook(Book.BookStatus.AVAILABLE);

            int numberOfBookList = this.bookList.Count;
            for (int i = 0; i < numberOfBookList; i++)
            {
                Book book = this.bookList[i];
                if (book != null)
                {
                    if (this.caller is PaymentForm2)
                    {
                        PaymentForm2 paymentForm2 = (PaymentForm2)this.caller;

                        int quantity = paymentForm2.getProductQuantity(book.Id);
                        if (quantity > 0)
                        {
                            book.Quantity -= quantity;

                            if (book.Quantity <= 0)
                            {
                                book.Status = Book.BookStatus.EMPTY.ToString();
                            }
                        }
                    }
                }
            }
        }

        private void initialDataGridViewBookList()
        {
            this.DataGridView_BookList.AutoGenerateColumns = false;            
        }

        private void updateDataGridViewBookList()
        {
            this.DataGridView_BookList.DataSource = null;

            if (this.bookList.Count > 0)
            {
                this.DataGridView_BookList.DataSource = this.bookList;
            }
        }

        private void searchBook(string bookName)
        {
            if (bookName == "")
            {
                this.bookList = BookManager.findAllBook(Book.BookStatus.AVAILABLE);
            }
            else
            {
                this.bookList = BookManager.findAllBookByName(bookName, Book.BookStatus.AVAILABLE);
            }

            this.updateDataGridViewBookList();
        }

        private void TextBox_BookName_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.searchBook(this.TextBox_BookName.Text);
            }
        }

        private void Button_SearchBook_Click(object sender, EventArgs e)
        {
            this.searchBook(this.TextBox_BookName.Text);
        }

        private void DataGridView_BookList_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowIndex = e.RowIndex;
            if (rowIndex >= 0)
            {
                Book book = this.bookList[rowIndex];
                if (book != null)
                {
                    int bookQuantity = 1;
                    if (bookQuantity <= book.Quantity)
                    {
                        Product product = new Product();
                        product.Id = book.Id;
                        product.Type = Product.ProductType.BOOK.ToString();
                        product.Name = book.Name;
                        product.Price = book.Price;

                        PaymentDetail paymentDetail = new PaymentDetail();
                        paymentDetail.Product = product;
                        paymentDetail.Quantity = bookQuantity;

                        if (this.caller is PaymentForm2)
                        {
                            PaymentForm2 paymentForm2 = (PaymentForm2)this.caller;
                            
                            if (paymentForm2.addPaymentDetail(paymentDetail) == true)
                            {
                                book.Quantity--;

                                this.updateDataGridViewBookList();
                            }
                            else
                            {
                                MessageBox.Show("ไม่สามารถทำรายการได้");
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("ไม่สามารถทำรายการได้");
                    }
                }
            }
        }        
    }
}
