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
    public partial class HolidayMainForm : Form
    {
        private MainForm mainForm;
        private List<Holiday> holidayList;

        public HolidayMainForm()
        {
            InitializeComponent();
        }

        public void showFormDialog(MainForm mainForm)
        {
            this.mainForm = mainForm;
            this.holidayList = new List<Holiday>();

            this.ComboBox_Month.SelectedIndex = 0;
            this.ComboBox_Year.Text = DateTime.Today.Year.ToString();

            this.ShowDialog();
        }

        private void refreshDataGridView_Holiday()
        {
            this.DataGridView_Holiday.Rows.Clear();

            for (int i = 0; i < this.holidayList.Count; i++)
            {
                int n = this.DataGridView_Holiday.Rows.Add();
                this.DataGridView_Holiday.Rows[n].Cells["No"].Value = n + 1;
                this.DataGridView_Holiday.Rows[n].Cells["Date"].Value = this.holidayList[i].Date.ToShortDateString();
                this.DataGridView_Holiday.Rows[n].Cells["AdderName"].Value = this.holidayList[i].Comment;

                if (this.holidayList[i].Date < DateTime.Today)
                {
                    ((DataGridViewImageCell)this.DataGridView_Holiday.Rows[n].Cells["DeleteButton"]).Value = new Bitmap(20, 16);
                }
                //else
                //{
                //    ((DataGridViewImageCell)this.DataGridView_Holiday.Rows[n].Cells["DeleteButton"]).Value = Image.FromFile("..\\..\\Images\\Delete.png");
                //}
            } 

            this.DataGridView_Holiday.ClearSelection();
        }

        private void DataGridView_Holiday_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (e.ColumnIndex == 3)
                {
                    if (this.holidayList[e.RowIndex].Date >= DateTime.Today)
                    {
                        string text = "คุณต้องการยกเลิกวันหยุดวันที่ " + this.holidayList[e.RowIndex].Date.ToShortDateString() + " ใช่หรือไม่";
                        if (ConfirmDialogBox.show(text))
                        {
                            int id = this.holidayList[e.RowIndex].Id;
                            if (HolidayManager.deleteHoliday(id))
                            {
                                //MessageBox.Show(PianoForte.Constant.DatabaseConstant.DELETE_DATA_SUCCESS);
                                this.holidayList.Remove(this.holidayList[e.RowIndex]);
                                this.refreshDataGridView_Holiday();
                            }
                            else
                            {
                                MessageBox.Show(PianoForte.Constant.DatabaseConstant.DELETE_DATA_FAIL);
                            }
                        }
                    }
                }
            }

            this.Cursor = Cursors.Arrow;
        } 

        private void DataGridView_Holiday_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {                
                if (e.RowIndex >= 0)
                {
                    if (this.holidayList[e.RowIndex].Date >= DateTime.Today)
                    {
                        this.Cursor = Cursors.Hand;
                    }
                    else
                    {
                        this.Cursor = Cursors.Arrow;
                    }
                }                
            }
        }

        private void DataGridView_Holiday_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            this.Cursor = Cursors.Arrow;
        }

        private void Button_Add_Holiday_Click(object sender, EventArgs e)
        {            
            List<DateTime> dateList = DateTimePickerDialogBox.show();
            if (dateList.Count > 0)
            {
                bool isAddHolidayComplete = false;
                for (int i = 0; i < dateList.Count; i++)
                {
                    Holiday holiday = HolidayManager.findHoliday(dateList[i]);
                    if (holiday == null)
                    {
                        holiday = new Holiday();
                        holiday.Date = dateList[i];
                        holiday.Comment = this.mainForm.getUser().DisplayName;

                        isAddHolidayComplete = HolidayManager.insertHoliday(holiday);
                        if (!isAddHolidayComplete)
                        {
                            LogManager.writeLog("Add SchoolClosingDate Failed.");
                            break;
                        }
                    }
                    else
                    {
                        isAddHolidayComplete = true;
                    }
                }

                if (isAddHolidayComplete)
                {
                    MessageBox.Show("Add closing date success.");
                }
                else
                {
                    MessageBox.Show("Add closing date failed.");
                }
            }            
        }

        private void Button_Search_Click(object sender, EventArgs e)
        {
            this.holidayList.Clear();            

            int month = this.ComboBox_Month.SelectedIndex;
            int year = Convert.ToInt32(this.ComboBox_Year.Text);

            if (month == 0)
            {
                this.holidayList = HolidayManager.findAllHoliday(year);
            }
            else if ((month >= 1) && (month <= 12))
            {
                this.holidayList = HolidayManager.findAllHoliday(year, month);
            }

            if (this.holidayList.Count > 0)
            {
                this.refreshDataGridView_Holiday();                               
            }
            else
            {
                MessageBox.Show(PianoForte.Constant.DatabaseConstant.DATA_NOT_FOUND);
            }
        }                     
    }
}
