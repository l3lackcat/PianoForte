using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using PianoForte.Constant;
using PianoForte.Manager;
using PianoForte.Model;

namespace PianoForte.View
{
    public partial class PaymentForm_Course : Form
    {
        private PaymentForm paymentForm;
        private Enrollment enrollment;
        private List<Enrollment> enrollmentList;

        public PaymentForm_Course()
        {
            InitializeComponent();
        }

        public void load(PaymentForm caller)
        {
            this.paymentForm = caller;
            this.enrollment = new Enrollment();
            this.enrollmentList = new List<Enrollment>();

            this.reset();
        }

        public void reset()
        {
            this.enrollment = null;
            this.enrollmentList.Clear();
            this.resetTextBox_Discount();
            this.resetComboBoxDiscountType();
            this.resetComboBoxUnpaidEnrollment();
            this.enableGroupBoxEnrollment(true);
            this.enalbeCheckBoxDiscount(false);
            this.resetGroupBoxCourseDetail();
            this.resetComboBoxNumberOfClassroomDetail();
            this.resetGroupBoxClassroomFrequency();
            this.resetGroupBoxClassroom1();
            this.resetGroupBoxClassroom2();
            this.enableButtonSubmit(false);
        }

        public void resetTextBox_Discount()
        {
            this.TextBox_Discount.Text = "";
        }

        public void resetComboBoxDiscountType()
        {
            if (this.ComboBox_DiscountType.Items.Count > 0)
            {
                this.ComboBox_DiscountType.SelectedIndex = 0;
            }
        }

        public void resetComboBoxUnpaidEnrollment()
        {
            this.enrollmentList.Clear();
            this.RadioButton_Unpaid_Enrollment.Visible = false;
            this.ComboBox_Unpaid_Enrollment.Visible = false;
            this.ComboBox_Unpaid_Enrollment.Items.Clear();
        }

        public void resetGroupBoxCourseDetail()
        {
            this.TextBox_CourseCategoryName.Text = "";
            this.TextBox_CourseName.Text = "";
            this.TextBox_CourseLevel.Text = "";
            this.TextBox_CourseFee.Text = "";
        }

        public void resetComboBoxNumberOfClassroomDetail()
        {
            this.ComboBox_NumberOfClassroomDetail.Items.Clear();
        }

        public void resetGroupBoxClassroomFrequency()
        {
            this.RadioButton_OneClassPerWeek.Checked = false;
            this.RadioButton_TwoClassPerWeek.Checked = false;
            this.RadioButton_TwoClassPerDay.Checked = false;
        }

        public void resetGroupBoxClassroom1()
        {
            this.DateTimePicker_Classroom1_StartDate.Value = DateTime.Today;
            this.ComboBox_Classroom2_Time.Items.Clear();
            this.TextBox_Classroom1_Duration.Text = "";
            this.ComboBox_Classroom1_Teacher.Items.Clear();
        }

        public void resetGroupBoxClassroom2()
        {
            this.DateTimePicker_Classroom2_StartDate.Value = DateTime.Today;
            this.ComboBox_Classroom1_Time.Items.Clear();
            this.TextBox_Classroom2_Duration.Text = "";
            this.ComboBox_Classroom2_Teacher.Items.Clear();
        }

        public void init(Enrollment enrollment)
        {
            this.enrollment = enrollment;
            this.enalbeCheckBoxDiscount(true);
            this.initGroupBoxCourseDetail(this.enrollment.Course);
            this.initComboBoxNumberOfClassroomDetail(this.enrollment.ClassroomIdClassroomDetailListDictionary);
            this.initGroupBoxClassroomFrequency(this.enrollment.ClassroomList);
            this.enableButtonSubmit(true);
        }

        public void initComboBoxUnpaidEnrollment(List<Enrollment> enrollmentList, int selectedEnrollmentId)
        {
            this.ComboBox_Unpaid_Enrollment.Items.Clear();

            if (enrollmentList.Count > 0)
            {
                int selectedIndex = 0;

                this.enrollmentList = enrollmentList;
                for (int i = 0; i < this.enrollmentList.Count; i++)
                {
                    string tempString = this.enrollmentList[i].Course.Name + " - " + this.enrollmentList[i].Course.Level;
                    this.ComboBox_Unpaid_Enrollment.Items.Add(tempString);

                    if ((selectedEnrollmentId != -1) && (selectedEnrollmentId == enrollmentList[i].Id))
                    {
                        selectedIndex = i;
                    }
                }

                if (this.ComboBox_Unpaid_Enrollment.Items.Count > 0)
                {
                    this.ComboBox_Unpaid_Enrollment.SelectedIndex = selectedIndex;
                }

                this.RadioButton_Unpaid_Enrollment.Visible = true;
                this.RadioButton_Unpaid_Enrollment.Checked = true;
                this.ComboBox_Unpaid_Enrollment.Visible = true;
            }
        }

        public void initGroupBoxCourseDetail(Course course)
        {
            CourseCategory courseCategory = CourseCategoryManager.findCourseCategory(course.CourseCategoryId);
            if (courseCategory != null)
            {
                this.TextBox_CourseCategoryName.Text = courseCategory.Name;
            }
            this.TextBox_CourseName.Text = course.Name;
            this.TextBox_CourseLevel.Text = course.Level;
            this.TextBox_CourseFee.Text = course.Price.ToString();
        }

        public void initComboBoxNumberOfClassroomDetail(Dictionary<int, List<ClassroomDetail>> classroomIdClassroomDetailListDictionary)
        {
            int numberOfClassroomDetail = 0;

            foreach (var pair in classroomIdClassroomDetailListDictionary)
            {
                numberOfClassroomDetail += pair.Value.Count;
            }

            this.ComboBox_NumberOfClassroomDetail.Items.Add(numberOfClassroomDetail.ToString());
            this.ComboBox_NumberOfClassroomDetail.Text = numberOfClassroomDetail.ToString();
        }

        public void initGroupBoxClassroomFrequency(List<Classroom> classroomList)
        {
            if (classroomList.Count == 1)
            {
                this.RadioButton_OneClassPerWeek.Checked = true;
                this.initGroupBoxClassroom1(classroomList[0]);
            }
            else if (classroomList.Count == 2)
            {
                if (classroomList[0].StartDate != classroomList[1].StartDate)
                {
                    this.RadioButton_TwoClassPerWeek.Checked = true;
                }
                else
                {
                    this.RadioButton_TwoClassPerDay.Checked = true;
                }
                this.initGroupBoxClassroom1(classroomList[0]);
                this.initGroupBoxClassroom2(classroomList[1]);
            }
        }

        public void initGroupBoxClassroom1(Classroom classroom)
        {
            this.DateTimePicker_Classroom1_StartDate.Value = classroom.StartDate;
            this.ComboBox_Classroom1_Time.Items.Add(classroom.ClassTime);
            this.ComboBox_Classroom1_Time.Text = classroom.ClassTime;
            this.TextBox_Classroom1_Duration.Text = classroom.ClassDuration.ToString();

            Teacher tempTeacher = TeacherManager.findTeacher(classroom.TeacherId);
            if (tempTeacher != null)
            {
                //string teacherName = "อ." + tempTeacher.Firstname + " (ครู" + tempTeacher.Nickname + ")";
                this.ComboBox_Classroom1_Teacher.Items.Add(tempTeacher.ToString());
                this.ComboBox_Classroom1_Teacher.Text = tempTeacher.ToString();
            }            
        }

        public void initGroupBoxClassroom2(Classroom classroom)
        {
            this.DateTimePicker_Classroom2_StartDate.Value = classroom.StartDate;
            this.ComboBox_Classroom2_Time.Items.Add(classroom.ClassTime);
            this.ComboBox_Classroom2_Time.Text = classroom.ClassTime;
            this.TextBox_Classroom2_Duration.Text = classroom.ClassDuration.ToString();

            Teacher tempTeacher = TeacherManager.findTeacher(classroom.TeacherId);
            if (tempTeacher != null)
            {
                //string teacherName = "อ." + tempTeacher.Firstname + " (ครู" + tempTeacher.Nickname + ")";
                this.ComboBox_Classroom2_Teacher.Items.Add(tempTeacher.ToString());
                this.ComboBox_Classroom2_Teacher.Text = tempTeacher.ToString();
            }
        }

        public void enableGroupBoxEnrollment(bool isEnable)
        {
            this.GroupBox_Enrollment.Enabled = isEnable;
        }

        public void enalbeCheckBoxDiscount(bool isEnable)
        {
            this.CheckBox_Discount.Checked = false;
            this.CheckBox_Discount.Enabled = isEnable;
        }

        //Enable and disable TextBox_Discount and ComboBox_DiscountType.
        public void enableDiscount(bool isEnable)
        {
            this.TextBox_Discount.Enabled = isEnable;
            this.ComboBox_DiscountType.Enabled = isEnable;
        }        

        public void enableButtonSubmit(bool isEnable)
        {
            this.Button_Submit.Enabled = isEnable;
        }

        //Get discount rate.
        public double getDiscountRate()
        {
            double discountRate = 0;

            try
            {
                if (this.CheckBox_Discount.Checked)
                {
                    if (this.ComboBox_DiscountType.SelectedIndex == 0)
                    {
                        discountRate = Convert.ToDouble(this.TextBox_Discount.Text);
                    }
                    else if (this.ComboBox_DiscountType.SelectedIndex == 1)
                    {
                        discountRate = (this.enrollment.Course.Price * Convert.ToDouble(this.TextBox_Discount.Text)) / 100;
                    }
                }                
            }
            catch (System.Exception ex)
            {
                discountRate = 0;
                LogManager.writeLog(ex.Message);
            }

            return discountRate;
        }

        public Enrollment getEnrollment()
        {
            return this.enrollment;
        }

        private void RadioButton_New_Enrollment_CheckedChanged(object sender, EventArgs e)
        {
            if (this.RadioButton_New_Enrollment.Checked)
            {
                this.Button_Enrollment.Enabled = true;
                this.ComboBox_Unpaid_Enrollment.Enabled = false;
                this.paymentForm.enableGroupBoxStudent(true);
            }
        }

        private void Button_Enrollment_Click(object sender, EventArgs e)
        {
            EnrollmentForm enrollmentForm = new EnrollmentForm();
            Enrollment enrollment = enrollmentForm.showFormDialog();
            if (enrollment != null)
            {
                this.init(enrollment);
            }
        }

        private void RadioButton_Unpaid_Enrollment_CheckedChanged(object sender, EventArgs e)
        {
            if (this.RadioButton_Unpaid_Enrollment.Checked)
            {
                this.Button_Enrollment.Enabled = false;
                this.ComboBox_Unpaid_Enrollment.Enabled = true;
                this.init(this.enrollmentList[this.ComboBox_Unpaid_Enrollment.SelectedIndex]);
                this.paymentForm.enableGroupBoxStudent(false);
            }
            else
            {
                this.paymentForm.enableGroupBoxStudent(true);
            }
        }

        private void ComboBox_Unpaid_Enrollment_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.init(this.enrollmentList[this.ComboBox_Unpaid_Enrollment.SelectedIndex]);
        }

        private void CheckBox_Discount_CheckedChanged(object sender, EventArgs e)
        {
            if (this.CheckBox_Discount.Checked)
            {
                this.enableDiscount(true);
            }
            else
            {
                this.enableDiscount(false);
            }
        }

        private void TextBox_Discount_KeyDown(object sender, KeyEventArgs e)
        {
            if (!ValidateManager.isPressNumber(e))
            {
                e.SuppressKeyPress = true;
            }
        }

        private void TextBox_Discount_TextChanged(object sender, EventArgs e)
        {

        }

        private void Button_Submit_Click(object sender, EventArgs e)
        {
            string name = this.enrollment.Course.Name;
            if (this.enrollment.Course.Level != "")
            {
                name += " - ";
                name += this.enrollment.Course.Level;
            }

            Product product = new Product();
            product.Id = this.enrollment.Course.Id;
            product.Type = Product.ProductType.COURSE.ToString();
            product.Name = name;

            int numberOfClass = Convert.ToInt32(this.ComboBox_NumberOfClassroomDetail.Text);
            if (numberOfClass == this.enrollment.Course.NumberOfClassroom)
            {
                product.Price = this.enrollment.Course.Price;
            }
            else
            {
                if ((this.enrollment.Course.Price % this.enrollment.Course.NumberOfClassroom) == 0)
                {
                    product.Price = (this.enrollment.Course.Price / this.enrollment.Course.NumberOfClassroom) * numberOfClass;
                }
                else
                {
                    product.Price = Math.Ceiling((this.enrollment.Course.Price / this.enrollment.Course.NumberOfClassroom) * numberOfClass);
                    //int offset = this.enrollment.Course.NumberOfClassroom - ((int)this.enrollment.Course.Price % this.enrollment.Course.NumberOfClassroom);
                    //double tempCoursePrice = this.enrollment.Course.Price + offset;
                    //product.Price = (tempCoursePrice / this.enrollment.Course.NumberOfClassroom) * numberOfClass;
                }
            }                        

            PaymentDetail paymentDetail = new PaymentDetail();
            paymentDetail.Product = product;
            paymentDetail.Quantity = 1;
            paymentDetail.Discount = this.getDiscountRate();

            if (this.paymentForm.addPaymentDetail(paymentDetail))
            {
                this.enableGroupBoxEnrollment(false);
            } 
        }                      
    }
}
