using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using PianoForte.Interface;
using PianoForte.Constant;
using PianoForte.Manager;
using PianoForte.Model;

namespace PianoForte.View
{
    public partial class BookMainForm : Form, FormInterface
    {
        private List<Book> bookList;

        public BookMainForm()
        {
            InitializeComponent();
        }

        private void BookMainForm_Load(object sender, EventArgs e)
        {
            //Do Nothing
        }

        public void load(MainForm mainForm)
        {
            this.bookList = new List<Book>();            

            this.ComboBox_Status.Items.Clear();
            this.ComboBox_Status.Items.Add(Book.BookStatus.ALL.ToString());
            this.ComboBox_Status.Items.Add(Book.BookStatus.AVAILABLE.ToString());
            this.ComboBox_Status.Items.Add(Book.BookStatus.EMPTY.ToString());
            this.ComboBox_Status.Items.Add(Book.BookStatus.CANCELED.ToString());

            this.DataGridView_BookInfo.AutoGenerateColumns = false;

            this.ComboBox_NumberPerPage.Items.Clear();
            this.ComboBox_NumberPerPage.Items.Add("20");
            this.ComboBox_NumberPerPage.Items.Add("40");
            this.ComboBox_NumberPerPage.Items.Add("60");
        }

        public void reload()
        {
            //Do Nothing
        }

        public void reset()
        {
            this.bookList.Clear();

            this.RadioButton_Show_AllBook.Checked = true;
            this.RadioButton_Search_BookId.Checked = false;
            this.RadioButton_Search_Info.Checked = false;

            this.TextBox_BookId_ForSearch.Text = "";
            this.TextBox_BookBarcode_ForSearch.Text = "";
            this.TextBox_BookName_ForSearch.Text = "";

            if (this.ComboBox_Status.Items.Count > 0)
            {
                this.ComboBox_Status.SelectedIndex = 0;
            }

            if (this.ComboBox_NumberPerPage.Items.Count > 0)
            {
                this.ComboBox_NumberPerPage.SelectedIndex = 0;
            }

            this.TextBox_PageNumber.Text = "1";

            this.refreshDataGridView_BookInfo();
        }        

        private void keyPressed(KeyEventArgs keyEventArgs)
        {
            if (keyEventArgs.KeyData == Keys.Enter)
            {
                this.TextBox_PageNumber.Text = "1";
                this.search();
            }
        }

        private void refreshDataGridView_BookInfo()
        {
            this.DataGridView_BookInfo.DataSource = null;

            if (this.bookList.Count > 0)
            {
                this.DataGridView_BookInfo.DataSource = this.bookList;
            }

            this.DataGridView_BookInfo.ClearSelection();
        }

        private void search()
        {
            if (MainForm.currentForm is BookMainForm)
            {
                List<Book> tempBookList = new List<Book>();

                int numberPerPage = Convert.ToInt32(this.ComboBox_NumberPerPage.Text);
                int pageNumber = Convert.ToInt32(this.TextBox_PageNumber.Text);
                int startIndex = (pageNumber - 1) * numberPerPage;

                if (this.RadioButton_Show_AllBook.Checked)
                {
                    this.bookList = BookManager.findAllBook(startIndex, numberPerPage);
                    tempBookList = BookManager.findAllBook(startIndex + numberPerPage, numberPerPage);
                }
                else if (this.RadioButton_Search_BookId.Checked)
                {
                    this.bookList.Clear();

                    string temp = this.TextBox_BookId_ForSearch.Text;
                    if (temp != "")
                    {
                        int bookId = Convert.ToInt32(temp);

                        Book book = BookManager.findBook(bookId);
                        if (book != null)
                        {
                            this.bookList.Add(book);
                        }
                    }
                }
                else if (this.RadioButton_Search_BookBarcode.Checked)
                {
                    this.bookList.Clear();

                    string bookBarcode = this.TextBox_BookBarcode_ForSearch.Text;
                    if (bookBarcode != "")
                    {
                        Book book = BookManager.findBookByBarcode(bookBarcode);
                        if (book != null)
                        {
                            this.bookList.Add(book);
                        }
                    }
                }
                else if (this.RadioButton_Search_Info.Checked)
                {
                    //string barcode = this.TextBox_Barcode_ForSearch.Text;
                    string bookName = this.TextBox_BookName_ForSearch.Text;
                    Book.BookStatus status = (Book.BookStatus)this.ComboBox_Status.SelectedIndex;

                    if (bookName == "")
                    {
                        this.bookList = BookManager.findAllBook(status, startIndex, numberPerPage);
                        tempBookList = BookManager.findAllBook(status, startIndex + numberPerPage, numberPerPage);
                    }
                    else
                    {
                        this.bookList = BookManager.findAllBookByName(bookName, status, startIndex, numberPerPage);
                        tempBookList = BookManager.findAllBookByName(bookName, status, startIndex + numberPerPage, numberPerPage);
                    }
                }

                if (this.bookList.Count == 0)
                {
                    MessageBox.Show(DatabaseConstant.DATA_NOT_FOUND);
                }
                else if (this.bookList.Count < numberPerPage)
                {
                    this.Button_NextPage.Enabled = false;
                }
                else if (this.bookList.Count == numberPerPage)
                {
                    this.refreshButton_NextPage(tempBookList);
                }

                this.refreshDataGridView_BookInfo();
            }

            this.TextBox_BookId_ForSearch.Text = "";
            this.TextBox_BookBarcode_ForSearch.Text = "";
            this.TextBox_BookName_ForSearch.Text = "";

            if (this.ComboBox_Status.Items.Count > 0)
            {
                this.ComboBox_Status.SelectedIndex = 0;
            }
        }

        private void refreshButton_NextPage(List<Book> bookList)
        {
            if (bookList.Count > 0)
            {
                this.Button_NextPage.Enabled = true;
            }
            else
            {
                this.Button_NextPage.Enabled = false;
            }
        }

        private void RadioButton_Show_AllBook_CheckedChanged(object sender, EventArgs e)
        {
            this.TextBox_BookId_ForSearch.Enabled = false;
            this.TextBox_BookBarcode_ForSearch.Enabled = false;
            this.TextBox_BookName_ForSearch.Enabled = false;            
            this.ComboBox_Status.Enabled = false;
        }

        private void RadioButton_Show_AllBook_KeyDown(object sender, KeyEventArgs e)
        {
            this.keyPressed(e);
        }

        private void RadioButton_Search_BookId_CheckedChanged(object sender, EventArgs e)
        {
            this.TextBox_BookId_ForSearch.Enabled = true;
            this.TextBox_BookBarcode_ForSearch.Enabled = false;
            this.TextBox_BookName_ForSearch.Enabled = false;            
            this.ComboBox_Status.Enabled = false;

            this.TextBox_BookBarcode_ForSearch.Text = "";
            this.TextBox_BookName_ForSearch.Text = "";

            if (this.ComboBox_Status.Items.Count > 0)
            {
                this.ComboBox_Status.SelectedIndex = 0;
            }
        }

        private void RadioButton_Search_BookId_KeyDown(object sender, KeyEventArgs e)
        {
            this.keyPressed(e);
        }

        private void RadioButton_Search_BookBarcode_CheckedChanged(object sender, EventArgs e)
        {
            this.TextBox_BookId_ForSearch.Enabled = false;
            this.TextBox_BookBarcode_ForSearch.Enabled = true;
            this.TextBox_BookName_ForSearch.Enabled = false;
            this.ComboBox_Status.Enabled = false;

            this.TextBox_BookId_ForSearch.Text = "";
            this.TextBox_BookName_ForSearch.Text = "";

            if (this.ComboBox_Status.Items.Count > 0)
            {
                this.ComboBox_Status.SelectedIndex = 0;
            }
        }

        private void RadioButton_Search_Info_CheckedChanged(object sender, EventArgs e)
        {
            this.TextBox_BookId_ForSearch.Enabled = false;
            this.TextBox_BookBarcode_ForSearch.Enabled = false;
            this.TextBox_BookName_ForSearch.Enabled = true;            
            this.ComboBox_Status.Enabled = true;

            this.TextBox_BookId_ForSearch.Text = "";
        }

        private void RadioButton_Search_Info_KeyDown(object sender, KeyEventArgs e)
        {
            this.keyPressed(e);
        }

        private void TextBox_BookId_ForSearch_KeyDown(object sender, KeyEventArgs e)
        {
            this.keyPressed(e);
        }

        private void TextBox_Barcode_ForSearch_KeyDown(object sender, KeyEventArgs e)
        {
            this.keyPressed(e);
        }

        private void TextBox_BookName_ForSearch_KeyDown(object sender, KeyEventArgs e)
        {
            this.keyPressed(e);
        }

        private void ComboBox_Status_KeyDown(object sender, KeyEventArgs e)
        {
            this.keyPressed(e);
        }

        private void Button_Search_Click(object sender, EventArgs e)
        {
            this.TextBox_PageNumber.Text = "1";
            this.search();
        }  

        private void DataGridView_BookInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                Book book = new Book();
                bool isNeedToUpdate = false;

                switch (e.ColumnIndex)
                {
                    case 6:
                        {                            
                            BookDetailForm bookDetailForm = new BookDetailForm();
                            book = bookDetailForm.showFormDialog(this.bookList[e.RowIndex], false);
                            isNeedToUpdate = true;
                        }
                        break;
                    case 7:
                        {
                            BookDetailForm bookDetailForm = new BookDetailForm();
                            book = bookDetailForm.showFormDialog(this.bookList[e.RowIndex], true);
                            isNeedToUpdate = true;
                        }
                        break;
                }

                if (isNeedToUpdate)
                {
                    for (int i = 0; i < this.bookList.Count; i++)
                    {
                        if (this.bookList[i].Id == book.Id)
                        {
                            this.bookList[i] = book;
                        }
                    }

                    this.refreshDataGridView_BookInfo();
                }                
            }            

            this.Cursor = Cursors.Arrow;
        }

        private void DataGridView_BookInfo_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                switch (e.ColumnIndex)
                {
                    case 6:
                        this.Cursor = Cursors.Hand;
                        this.DataGridView_BookInfo.Rows[e.RowIndex].Cells[e.ColumnIndex].ToolTipText = "View";
                        break;
                    case 7:
                        this.Cursor = Cursors.Hand;
                        this.DataGridView_BookInfo.Rows[e.RowIndex].Cells[e.ColumnIndex].ToolTipText = "Edit";
                        break;
                }
            }
        }

        private void DataGridView_BookInfo_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            this.Cursor = Cursors.Arrow;
        }               

        private void ComboBox_NumberPerPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.TextBox_PageNumber.Text = "1";
            this.search();
        }

        private void Button_PreviousPage_Click(object sender, EventArgs e)
        {
            int currentPageNumber = Convert.ToInt32(this.TextBox_PageNumber.Text) - 1;
            this.TextBox_PageNumber.Text = currentPageNumber.ToString();
            this.search();
        }

        private void TextBox_PageNumber_TextChanged(object sender, EventArgs e)
        {
            if (this.TextBox_PageNumber.Text == "1")
            {
                this.Button_PreviousPage.Enabled = false;
            }
            else
            {
                this.Button_PreviousPage.Enabled = true;
            }
        }

        private void Button_NextPage_Click(object sender, EventArgs e)
        {
            int currentPageNumber = Convert.ToInt32(this.TextBox_PageNumber.Text) + 1;
            this.TextBox_PageNumber.Text = currentPageNumber.ToString();
            this.search();
        }

        private void Button_Add_Book_Click(object sender, EventArgs e)
        {
            AddBookDetailForm addBookDetailForm = new AddBookDetailForm();
            addBookDetailForm.showFormDialog();
        }
    }
}
