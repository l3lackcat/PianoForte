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
    public partial class SearchCoursePopUp : Form
    {
        private Form caller;
        private List<Course> courseList;
        private Course course = null;

        public SearchCoursePopUp()
        {
            InitializeComponent();
        }

        public Course showFormDialog(Form caller)
        {
            this.caller = caller;

            this.initialCourseList();
            this.initialDataGridViewCourseList();
            this.updateDataGridViewCourseList();

            this.ShowDialog();

            return this.course;
        }

        private void initialCourseList()
        {
            this.courseList = CourseManager.findAllCourse(Course.CourseStatus.ACTIVE);
        }

        private void initialDataGridViewCourseList()
        {
            this.DataGridView_CourseList.AutoGenerateColumns = false;
        }

        private void updateDataGridViewCourseList()
        {
            this.DataGridView_CourseList.DataSource = null;

            if (this.courseList.Count > 0)
            {
                this.DataGridView_CourseList.DataSource = this.courseList;
            }
        }

        private void searchCourse(string courseName)
        {
            if (courseName == "")
            {
                this.courseList = CourseManager.findAllCourse(Course.CourseStatus.ACTIVE);
            }
            else
            {
                this.courseList = CourseManager.findAllCourseByCourseName(courseName, Course.CourseStatus.ACTIVE);
            }

            this.updateDataGridViewCourseList();
        }

        private void TextBox_CourseName_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.searchCourse(this.TextBox_CourseName.Text);
            }
        }

        private void Button_SearchCourse_Click(object sender, EventArgs e)
        {
            this.searchCourse(this.TextBox_CourseName.Text);
        }

        private void DataGridView_CourseList_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowIndex = e.RowIndex;
            if (rowIndex >= 0)
            {
                this.course = this.courseList[rowIndex];

                this.Close();
            }
        }        
    }
}
