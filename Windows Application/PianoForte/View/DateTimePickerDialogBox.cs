using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PianoForte.View
{
    public partial class DateTimePickerDialogBox : Form
    {
        private static DateTimePickerDialogBox dateTimePickerDialogBox;
        private static List<DateTime> dateList = new List<DateTime>();

        public DateTimePickerDialogBox()
        {
            InitializeComponent();
        }

        public static List<DateTime> show()
        {
            dateTimePickerDialogBox = new DateTimePickerDialogBox();
            dateTimePickerDialogBox.ShowDialog();

            return dateList;
        }

        private void processAnswer(bool answer)
        {
            dateList.Clear();

            if (answer)
            {                
                dateList.Add(this.MonthCalendar.SelectionStart.Date);
                while (dateList[dateList.Count - 1] != this.MonthCalendar.SelectionEnd.Date)
                {
                    dateList.Add(dateList[dateList.Count - 1].AddDays(1));
                }
            }

            dateTimePickerDialogBox.Dispose();
        }

        private void Button_OK_Click(object sender, EventArgs e)
        {
            this.processAnswer(true);
        }

        private void Button_Cancel_Click(object sender, EventArgs e)
        {
            this.processAnswer(false);
        }
    }
}
