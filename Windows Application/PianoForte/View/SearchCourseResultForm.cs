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
    public partial class SearchCourseResultForm : Form
    {
        private Form caller;
        private EnrollmentForm enrollmentForm;
        private List<Course> courseList;

        public SearchCourseResultForm()
        {
            InitializeComponent();
        }

        public void load(Form caller, List<Course> courseList)
        {
            this.caller = caller;
            this.enrollmentForm = null;
            this.courseList = courseList;

            this.DataGridView_CourseInfo.AutoGenerateColumns = false;

            this.reload();
        }

        public void load(Form caller, List<Course> courseList, EnrollmentForm enrollmentForm)
        {
            this.caller = caller;
            this.enrollmentForm = enrollmentForm;
            this.courseList = courseList;

            this.DataGridView_CourseInfo.AutoGenerateColumns = false;

            this.reload();
        }
        
        public void reload()
        {
            this.DataGridView_CourseInfo.DataSource = null;

            if (this.courseList.Count > 0)
            {
                this.DataGridView_CourseInfo.DataSource = this.courseList;
            }

            this.DataGridView_CourseInfo.ClearSelection();
        }

        public void reset()
        {
            this.DataGridView_CourseInfo.DataSource = null;
            this.DataGridView_CourseInfo.ClearSelection();
        }

        private void DataGridView_CourseInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                Course tempCourse = this.courseList[e.RowIndex];
                if (tempCourse != null)
                {
                    if (this.caller is CourseMainForm)
                    {
                        CourseMainForm courseMainForm = (CourseMainForm)this.caller;
                        //courseMainForm.onClickCellContent(tempCourse);
                    }
                }
            }
        }

        private void DataGridView_CourseInfo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                Course tempCourse = this.courseList[e.RowIndex];
                if (tempCourse != null)
                {
                    if (this.enrollmentForm != null)
                    {
                        this.enrollmentForm.setup(tempCourse);
                        this.caller.Close();
                    }
                }
            }
        }        
    }
}
