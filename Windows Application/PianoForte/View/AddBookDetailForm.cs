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
    public partial class AddBookDetailForm : Form
    {
        public AddBookDetailForm()
        {
            InitializeComponent();
        }

        public void showFormDialog()
        {
            this.reset();
            this.ShowDialog();
        }

        public void reset()
        {
            this.TextBox_BookId.Text = BookManager.getNewBookId().ToString();
            this.TextBox_Barcode.Text = "";
            this.TextBox_OriginalBarcode.Text = "";
            this.TextBox_BookName.Text = "";
            this.TextBox_BookPrice.Text = "";
            this.TextBox_BookAmount.Text = "";

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
            string text = "คุณต้องการเพิ่มหนังสือใช่หรือไม่?";
            if (ConfirmDialogBox.show(text))
            {
                Book newBook = new Book();
                newBook.Id = Convert.ToInt32(this.TextBox_BookId.Text);
                newBook.Type = Product.ProductType.BOOK.ToString();
                newBook.Barcode = this.TextBox_Barcode.Text;
                newBook.OriginalBarcode = this.TextBox_OriginalBarcode.Text;
                newBook.Name = this.TextBox_BookName.Text;
                newBook.Price = Convert.ToDouble(this.TextBox_BookPrice.Text);
                newBook.Quantity = Convert.ToInt32(this.TextBox_BookAmount.Text);

                if (newBook.Quantity <= 0)
                {
                    newBook.Status = Book.BookStatus.EMPTY.ToString();
                }
                else
                {
                    newBook.Status = Book.BookStatus.AVAILABLE.ToString();
                }

                if (BookManager.insertBook(newBook))
                {
                    //MessageBox.Show(PianoForte.Constant.DatabaseConstant.INSERT_DATA_SUCCESS);
                    this.Close();
                }
                else
                {
                    MessageBox.Show(PianoForte.Constant.DatabaseConstant.INSERT_DATA_FAIL);
                }
            }
        }

        private void Button_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
