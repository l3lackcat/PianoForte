using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using PianoForte.Manager;
using PianoForte.Model;

namespace PianoForte.View
{
    public partial class BookDetailForm : Form
    {
        private Book originalBook;

        public BookDetailForm()
        {
            InitializeComponent();
        }

        public Book showFormDialog(Book book, bool isEditMode)
        {
            this.originalBook = new Book(book);

            this.setup(book, isEditMode);

            this.ShowDialog();

            return this.originalBook;
        }

        public void setup(Book book, bool isEditMode)
        {
            this.TextBox_BookId.Text = book.Id.ToString();
            this.TextBox_Barcode.Text = book.Barcode;
            this.TextBox_BookName.Text = book.Name;
            this.TextBox_BookPrice.Text = book.Price.ToString();
            this.TextBox_BookAmount.Text = book.Amount.ToString();

            if (book.Status == Book.BookStatus.CANCELED.ToString())
            {
                this.CheckBox_Cancel_Book.Checked = true;
            }
            else
            {
                this.CheckBox_Cancel_Book.Checked = false;
            }

            this.CheckBox_Cancel_Book.Enabled = isEditMode;
            this.TextBox_Barcode.Enabled = isEditMode;
            this.TextBox_BookName.Enabled = isEditMode;
            this.TextBox_BookPrice.Enabled = isEditMode;
            this.TextBox_BookAmount.Enabled = isEditMode;
            this.Button_Submit.Visible = isEditMode;
            this.Button_Cancel.Visible = isEditMode;
            this.Button_Edit.Visible = !isEditMode;

            this.refreshButton_Submit();
        }

        private void refreshButton_Submit()
        {
            if ((this.TextBox_Barcode.Text != "") &&
                (this.TextBox_BookName.Text != "") &&
                (ValidateManager.isNumber(this.TextBox_BookPrice.Text)) &&
                (ValidateManager.isNumber(this.TextBox_BookAmount.Text)))
            {
                this.Button_Submit.Enabled = true;
            }
            else
            {
                this.Button_Submit.Enabled = false;
            }
        }

        private void TextBox_Barcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (!ValidateManager.isPressNumber(e))
            {
                e.SuppressKeyPress = true;
            }
        }  

        private void TextBox_Barcode_TextChanged(object sender, EventArgs e)
        {
            this.refreshButton_Submit();
        }

        private void TextBox_BookName_TextChanged(object sender, EventArgs e)
        {
            this.refreshButton_Submit();
        }

        private void TextBox_BookPrice_KeyDown(object sender, KeyEventArgs e)
        {
            if (!ValidateManager.isPressNumber(e))
            {
                e.SuppressKeyPress = true;
            }
        }

        private void TextBox_BookPrice_TextChanged(object sender, EventArgs e)
        {
            this.refreshButton_Submit();
        }

        private void TextBox_BookAmount_KeyDown(object sender, KeyEventArgs e)
        {
            if (!ValidateManager.isPressNumber(e))
            {
                e.SuppressKeyPress = true;
            }
        }

        private void TextBox_BookAmount_TextChanged(object sender, EventArgs e)
        {
            this.refreshButton_Submit();
        }  

        private void Button_Submit_Click(object sender, EventArgs e)
        {
            string text = "คุณต้องการแก้ไขข้อมูลใช่หรือไม่?";
            if (ConfirmDialogBox.show(text))
            {
                Book tempBook = new Book(this.originalBook);
                tempBook.Barcode = this.TextBox_Barcode.Text;
                tempBook.Name = this.TextBox_BookName.Text;
                tempBook.Price = Convert.ToDouble(this.TextBox_BookPrice.Text);
                tempBook.Amount = Convert.ToInt32(this.TextBox_BookAmount.Text);

                if (this.CheckBox_Cancel_Book.Checked)
                {
                    tempBook.Status = Book.BookStatus.CANCELED.ToString();
                }
                else
                {
                    if (tempBook.Amount <= 0)
                    {
                        tempBook.Status = Book.BookStatus.EMPTY.ToString();
                    }
                    else
                    {
                        tempBook.Status = Book.BookStatus.AVAILABLE.ToString();
                    }
                }                

                if (BookManager.updateBook(tempBook))
                {
                    if (this.originalBook.Price != tempBook.Price)
                    {
                        ProductPriceHistory productPriceHistory = new ProductPriceHistory();
                        productPriceHistory.ProductId = this.originalBook.Id;
                        productPriceHistory.Price = this.originalBook.Price;
                        productPriceHistory.LastUsed = DateTime.Now;

                        ProductManager.addProductPriceHistory(productPriceHistory);
                    }

                    this.originalBook = tempBook;

                    //MessageBox.Show(PianoForte.Constant.DatabaseConstant.UPDATE_DATA_SUCCESS);

                    this.Close();
                }
                else
                {
                    MessageBox.Show(PianoForte.Constant.DatabaseConstant.UPDATE_DATA_FAIL);
                }
            }
        }

        private void Button_Cancel_Click(object sender, EventArgs e)
        {
            this.setup(this.originalBook, false);
        }

        private void Button_Edit_Click(object sender, EventArgs e)
        {
            this.setup(this.originalBook, true);
        }                            
    }
}
