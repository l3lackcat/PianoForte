using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace PianoForte.View.Component
{
    public class PianoForteDataGridViewDateTimePickerColumn : DataGridTextBoxColumn//DataGridColumnStyle 
    {
        private DateTimePicker dateTimePicker = new DateTimePicker();
        // The isEditing field tracks whether or not the user is
        // editing data with the hosted control.
        private bool isEditing;

        public PianoForteDataGridViewDateTimePickerColumn()
            : base()
        {
            dateTimePicker.Visible = false;
        }

        protected override void Abort(int rowNum)
        {
            isEditing = false;
            dateTimePicker.ValueChanged -= new EventHandler(TimePickerValueChanged);
            Invalidate();
        }

        protected override bool Commit
            (CurrencyManager dataSource, int rowNum)
        {
            dateTimePicker.Bounds = Rectangle.Empty;

            dateTimePicker.ValueChanged -= new EventHandler(TimePickerValueChanged);

            if (!isEditing)
                return true;

            isEditing = false;

            try
            {
                DateTime value = dateTimePicker.Value;
                SetColumnValueAtRow(dataSource, rowNum, value);
            }
            catch (Exception)
            {
                Abort(rowNum);
                return false;
            }

            Invalidate();
            return true;
        }

        protected override void Edit(
            CurrencyManager source,
            int rowNum,
            Rectangle bounds,
            bool readOnly,
            string instantText,
            bool cellIsVisible)
        {
            DateTime value = DateTime.Parse(GetColumnValueAtRow(source, rowNum).ToString());
            if (cellIsVisible)
            {
                dateTimePicker.Bounds = new Rectangle
                    (bounds.X + 2, bounds.Y + 2,
                    bounds.Width - 4, bounds.Height - 4);
                dateTimePicker.Value = value;
                dateTimePicker.Visible = true;
                dateTimePicker.ValueChanged +=
                    new EventHandler(TimePickerValueChanged);
            }
            else
            {
                dateTimePicker.Value = value;
                dateTimePicker.Visible = false;
            }

            if (dateTimePicker.Visible)
                DataGridTableStyle.DataGrid.Invalidate(bounds);
        }

        protected override Size GetPreferredSize(
            Graphics g,
            object value)
        {
            return new Size(100, dateTimePicker.PreferredHeight + 4);
        }

        protected override int GetMinimumHeight()
        {
            return dateTimePicker.PreferredHeight + 4;
        }

        protected override int GetPreferredHeight(Graphics g,
            object value)
        {
            return dateTimePicker.PreferredHeight + 4;
        }

        protected override void Paint(Graphics g,
            Rectangle bounds,
            CurrencyManager source,
            int rowNum)
        {
            Paint(g, bounds, source, rowNum, false);
        }
        protected override void Paint(
            Graphics g,
            Rectangle bounds,
            CurrencyManager source,
            int rowNum,
            bool alignToRight)
        {
            Paint(
                g, bounds,
                source,
                rowNum,
                Brushes.Red,
                Brushes.Blue,
                alignToRight);
        }
        protected override void Paint(
            Graphics g,
            Rectangle bounds,
            CurrencyManager source,
            int rowNum,
            Brush backBrush,
            Brush foreBrush,
            bool alignToRight)
        {

            DateTime date = DateTime.Parse(GetColumnValueAtRow(source, rowNum).ToString());

            Rectangle rect = bounds;
            g.FillRectangle(backBrush, rect);
            rect.Offset(0, 2);
            rect.Height -= 2;
            g.DrawString(date.ToString("d"),
                this.DataGridTableStyle.DataGrid.Font,
                foreBrush, rect);

        }

        protected override void SetDataGridInColumn(DataGrid value)
        {
            base.SetDataGridInColumn(value);
            if (dateTimePicker.Parent != null)
            {
                dateTimePicker.Parent.Controls.Remove
                    (dateTimePicker);
            }
            if (value != null)
            {
                value.Controls.Add(dateTimePicker);
            }
        }

        private void TimePickerValueChanged(object sender, EventArgs e)
        {
            this.isEditing = true;
            base.ColumnStartedEditing(dateTimePicker);
        }
    }
}
