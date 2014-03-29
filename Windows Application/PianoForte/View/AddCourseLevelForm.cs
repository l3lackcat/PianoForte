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
    public partial class AddCourseLevelForm : Form
    {
        private Form caller;
        private Course course;

        public AddCourseLevelForm()
        {
            InitializeComponent();
        }

        public Course showFormDialog(Form caller)
        {
            this.caller = caller;
            this.course = null;

            try
            {
                this.ComboBox_NumberOfClassroom.SelectedIndex = 11;
            }
            catch (System.Exception ex)
            {
                this.ComboBox_NumberOfClassroom.SelectedIndex = 0;
                LogManager.writeLog(ex.Message);
            }

            this.ComboBox_CourseStatus.Items.Clear();
            this.ComboBox_CourseStatus.Items.Add(Course.CourseStatus.ACTIVE.ToString());
            this.ComboBox_CourseStatus.Items.Add(Course.CourseStatus.INACTIVE.ToString());

            this.ComboBox_CourseStatus.Enabled = false;
            if (this.ComboBox_CourseStatus.Items.Count > 0)
            {
                this.ComboBox_CourseStatus.SelectedIndex = 0;
            }

            this.Button_Submit_CourseLevel.Enabled = false;

            this.ShowDialog();

            return this.course;
        }

        public void reset()
        {
            this.course = null;
            this.TextBox_CourseLevelName.Text = "";
            this.TextBox_CourseFee.Text = "";
            this.TextBox_ClassroomDuration.Text = "";
            this.RadioButton_Individual.Checked = true;
            this.TextBox_NumberOfStudent.Text = "";
            this.TextBox_NumberOfStudent.Enabled = false;
            this.Button_Submit_CourseLevel.Enabled = false;
        }

        private void refreshButton_Submit_CourseLevel()
        {
            if ((this.TextBox_CourseFee.Text != "") &&
                (this.TextBox_ClassroomDuration.Text != "") &&
                (!(this.RadioButton_Group.Checked) || (this.TextBox_NumberOfStudent.Text != "")))
            {
                this.Button_Submit_CourseLevel.Enabled = true;
            }
            else
            {
                this.Button_Submit_CourseLevel.Enabled = false;
            }
        }

        private void TextBox_CourseFee_TextChanged(object sender, EventArgs e)
        {
            this.refreshButton_Submit_CourseLevel();
        }

        private void Button_Submit_CourseLevel_Click(object sender, EventArgs e)
        {
            bool isDuplicateCourseLevel = false;

            if (this.caller is AddCourseForm)
            {
                isDuplicateCourseLevel = ((AddCourseForm)this.caller).isDuplicateCourseLevel(this.TextBox_CourseLevelName.Text, -1);
            }
            else if (this.caller is CourseDetailForm)
            {
                isDuplicateCourseLevel = ((CourseDetailForm)this.caller).isDuplicateCourseLevel(this.TextBox_CourseLevelName.Text, -1);
            }

            if (isDuplicateCourseLevel)
            {
                MessageBox.Show(Constant.Constant.DUPLICATE_COURSE_LEVEL);
            }
            else
            {
                this.course = new Course();
                this.course.Level = this.TextBox_CourseLevelName.Text;
                this.course.NumberOfClassroom = Convert.ToInt32(this.ComboBox_NumberOfClassroom.Text);
                this.course.Price = Convert.ToDouble(this.TextBox_CourseFee.Text);

                if (ValidateManager.isNumber(this.TextBox_ClassroomDuration.Text))
                {
                    this.course.ClassroomDuration = Convert.ToInt32(this.TextBox_ClassroomDuration.Text);
                }
                else
                {
                    this.course.ClassroomDuration = 0;
                }
                 
                this.course.Status = Course.CourseStatus.ACTIVE.ToString();

                if (this.RadioButton_Individual.Checked)
                {
                    this.course.StudentPerClassroom = 1;
                }
                else
                {
                    if (ValidateManager.isNumber(this.TextBox_NumberOfStudent.Text))
                    {
                        this.course.StudentPerClassroom = Convert.ToInt32(this.TextBox_NumberOfStudent.Text);
                    }
                }

                this.Close();
            }            
        }

        private void Button_Cancel_CourseLevel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TextBox_ClassroomDuration_TextChanged(object sender, EventArgs e)
        {
            this.refreshButton_Submit_CourseLevel();
        }

        private void TextBox_NumberOfStudent_TextChanged(object sender, EventArgs e)
        {
            this.refreshButton_Submit_CourseLevel();
        }

        private void RadioButton_Individual_CheckedChanged(object sender, EventArgs e)
        {
            this.TextBox_NumberOfStudent.Enabled = false;
        }

        private void RadioButton_Group_CheckedChanged(object sender, EventArgs e)
        {
            this.TextBox_NumberOfStudent.Enabled = true;
            this.refreshButton_Submit_CourseLevel();
        }
    }
}
