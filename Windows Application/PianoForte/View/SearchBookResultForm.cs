using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using PianoForte.Model;

namespace PianoForte.View
{
    public partial class SearchBookResultForm : Form
    {
        private Form caller;
        private List<Book> bookList;

        public SearchBookResultForm()
        {
            InitializeComponent();
        }

        public void load(Form caller, List<Book> bookList)
        {
            this.caller = caller;
            this.bookList = bookList;
            for (int i = 0; i < this.bookList.Count; i++)
            {
                Book temBook = this.bookList[i];
                if (temBook != null)
                {
                    int amount = MainForm.paymentForm.getProductAmount(temBook.Id);
                    if (amount > 0)
                    {
                        this.bookList[i].Amount -= amount;
                    }
                }
            }

            this.DataGridView_BookInfo.AutoGenerateColumns = false;

            this.reload();
        }

        public void reload()
        {
            this.DataGridView_BookInfo.DataSource = null;

            if (this.bookList.Count > 0)
            {
                this.DataGridView_BookInfo.DataSource = this.bookList;
            }        
        }

        public void reset()
        {
            this.DataGridView_BookInfo.DataSource = null;
            this.DataGridView_BookInfo.ClearSelection();
        }

        private void DataGridView_BookInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                Book tempBook = this.bookList[e.RowIndex];
                if (tempBook != null)
                {
                    if (this.caller is BookMainForm)
                    {
                        BookMainForm bookMainForm = (BookMainForm)this.caller;
                    }
                } 
            }
        }

        private void DataGridView_BookInfo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                Book tempBook = this.bookList[e.RowIndex];
                if (tempBook != null)
                {
                    int bookAmount = 1;
                    if (bookAmount <= tempBook.Amount)
                    {
                        Product product = new Product();
                        product.Id = tempBook.Id;
                        product.Type = Product.ProductType.BOOK.ToString();
                        product.Name = tempBook.Name;
                        product.Price = tempBook.Price;

                        PaymentDetail paymentDetail = new PaymentDetail();
                        paymentDetail.Product = product;
                        paymentDetail.Amount = bookAmount;

                        if (MainForm.paymentForm.addPaymentDetail(paymentDetail))
                        {
                            this.bookList[e.RowIndex].Amount--;

                            this.reload();
                        }
                        else
                        {
                            MessageBox.Show("ไม่สามารถทำรายการได้");
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
