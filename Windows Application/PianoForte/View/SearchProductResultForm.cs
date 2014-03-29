using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using PianoForte.Interface;
using PianoForte.Model;

namespace PianoForte.View
{
    public partial class SearchProductResultForm : Form, SearchCourseResultFormInterface, SearchBookResultFormInterface, SearchCdResultFormInterface
    {
        public SearchProductResultForm()
        {
            InitializeComponent();
        }

        public void onClickCellContent(Course course)
        {
            //Do Nothing
        }

        public void onClickCellContent(Book book)
        {
            //Do Nothing
        }

        public void onClickCellContent(Cd cd)
        {
            //Do Nothing
        }

        public void showFormDialog(List<Course> courseList)
        {
            SearchCourseResultForm searchCourseResultForm = new SearchCourseResultForm();

            this.Width = searchCourseResultForm.Width + 6;
            this.Height = searchCourseResultForm.Height + 24;

            this.panel1.Width = searchCourseResultForm.Width;
            this.panel1.Height = searchCourseResultForm.Height;

            searchCourseResultForm.load(this, courseList);

            this.initialForm(searchCourseResultForm);
            this.ShowDialog();
        }

        public void showFormDialog(List<Course> courseList, EnrollmentForm enrollmentForm)
        {
            SearchCourseResultForm searchCourseResultForm = new SearchCourseResultForm();

            this.Width = searchCourseResultForm.Width + 6;
            this.Height = searchCourseResultForm.Height + 24;

            this.panel1.Width = searchCourseResultForm.Width;
            this.panel1.Height = searchCourseResultForm.Height;

            searchCourseResultForm.load(this, courseList, enrollmentForm);

            this.initialForm(searchCourseResultForm);
            this.ShowDialog();
        }

        public void showFormDialog(List<Book> bookList)
        {
            SearchBookResultForm searchBookResultForm = new SearchBookResultForm();

            this.Width = searchBookResultForm.Width + 6;
            this.Height = searchBookResultForm.Height + 24;

            this.panel1.Width = searchBookResultForm.Width;
            this.panel1.Height = searchBookResultForm.Height;

            searchBookResultForm.load(this, bookList);

            this.initialForm(searchBookResultForm);
            this.ShowDialog();
        }

        public void showFormDialog(List<Cd> cdList)
        {
            SearchCdResultForm searchCdResultForm = new SearchCdResultForm();

            this.Width = searchCdResultForm.Width + 6;
            this.Height = searchCdResultForm.Height + 24;

            this.panel1.Width = searchCdResultForm.Width;
            this.panel1.Height = searchCdResultForm.Height;

            searchCdResultForm.load(this, cdList);

            this.initialForm(searchCdResultForm);
            this.ShowDialog();
        }

        public void closeFormDialog()
        {
            this.Close();
        }

        private void initialForm(Form form)
        {
            form.TopLevel = false;
            form.Dock = DockStyle.Fill;
            form.Show();
            this.panel1.Controls.Add(form);
        }
    }
}
