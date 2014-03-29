using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Management;

using PianoForte.Interface;
using PianoForte.Manager;
using PianoForte.Model;
using MySql.Data.MySqlClient; 

namespace PianoForte.View
{
    public partial class LoginForm : Form, FormInterface
    {
        private MainForm mainForm;

        public LoginForm()
        {
            InitializeComponent();
        }

        public void load(MainForm mainForm)
        {
            this.mainForm = mainForm;
        }

        public void reload()
        {
            //Do Nothing
        }

        public void reset()
        {
            this.TextBox_Username.Text = "";
            this.TextBox_Password.Text = "";
            this.Button_Login.Enabled = false;
        }

        private void updateButton_Login()
        {
            if ((this.TextBox_Username.Text != "") && (this.TextBox_Password.Text != ""))
            {
                this.Button_Login.Enabled = true;
            }
            else
            {
                this.Button_Login.Enabled = false;
            }
        }

        private void keyPressed(KeyEventArgs keyEventArgs)
        {
            if (keyEventArgs.KeyData == Keys.Enter)
            {
                if ((this.TextBox_Username.Text != "") && (this.TextBox_Password.Text != ""))
                {
                    this.login();
                }                
                else if ((this.TextBox_Username.Text != "") && (this.TextBox_Password.Text == ""))
                {
                    MessageBox.Show("กรุณากรอกรหัสผ่าน");
                }
                else
                {
                    MessageBox.Show("กรุณากรอกชื่อผู้ใช้");
                }
            }
        }

        private void login()
        {
            string username = this.TextBox_Username.Text;
            string password = this.TextBox_Password.Text;

            User user = UserManager.findUser(username);
            if (user != null)
            {
                if (user.Password == password)
                {
                    this.mainForm.loginSuccess(user);
                }
                else
                {
                    MessageBox.Show("รหัสผ่านไม่ถูกต้อง");
                    this.reset();
                }
            }
            else
            {
                MessageBox.Show("ไม่มีชื่อผู้ใช้นี้");
                this.reset();
            }           
        }

        private void TextBox_Username_TextChanged(object sender, EventArgs e)
        {
            this.updateButton_Login();

            if (this.TextBox_Username.Text == "Admin")
            {
                //this.button1.Visible = true;
                //this.button2.Visible = true;
                //this.button3.Visible = true;
                //this.button4.Visible = true;
                //this.button5.Visible = true;
                //this.button6.Visible = true;
                //this.button7.Visible = true;
                //this.button8.Visible = true;
                //this.button9.Visible = true;
                //this.button10.Visible = true;
            }
            else
            {
                this.button1.Visible = false;
                this.button2.Visible = false;
                this.button3.Visible = false;
                this.button4.Visible = false;
                this.button5.Visible = false;
                this.button6.Visible = false;
                this.button7.Visible = false;
                this.button8.Visible = false;
                this.button9.Visible = false;
                this.button10.Visible = false;
            }
        }

        private void TextBox_Username_KeyDown(object sender, KeyEventArgs e)
        {            
            if ((e.KeyCode == Keys.G) && (e.Alt) && (e.Control))
            {
                HiddenForm hiddenForm = new HiddenForm();
                hiddenForm.Show();
            }
            else
            {
                this.keyPressed(e);
            }
        }        

        private void TextBox_Password_TextChanged(object sender, EventArgs e)
        {
            this.updateButton_Login();
        }

        private void TextBox_Password_KeyDown(object sender, KeyEventArgs e)
        {
            this.keyPressed(e);
        }

        private void Button_Login_Click(object sender, EventArgs e)
        {
            this.login();
        }

        private void Button_Cancel_Click(object sender, EventArgs e)
        {
            this.reset();
        }

        private void button1_Click(object sender, EventArgs e)
        {            
            //List<Payment> paymentList = PaymentManager.getAllPayment();
            //for (int i = 0; i < paymentList.Count; i++)
            //{
            //    Enrollment enrollment = EnrollmentManager.getEnrollmentByPaymentId_old(paymentList[i].Id);
            //    if (enrollment != null)
            //    {
            //        if (enrollment.Course != null)
            //        {
            //            string name = enrollment.Course.Name;
            //            if (enrollment.Course.Level != "")
            //            {
            //                name += " - ";
            //                name += enrollment.Course.Level;
            //            }

            //            PaymentDetail paymentDetail = new PaymentDetail();
            //            paymentDetail.PaymentId = paymentList[i].Id;
            //            paymentDetail.Product.Id = enrollment.Course.Id;
            //            paymentDetail.Product.Type = Product.ProductType.COURSE.ToString();
            //            paymentDetail.Product.Name = name;
            //            paymentDetail.Amount = 1;
            //            paymentDetail.Discount = enrollment.Discount;
            //            paymentDetail.Product.Price = enrollment.CourseFee;
                        
            //            if (!PaymentDetailManager.addPaymentDetail(paymentDetail))
            //            {
            //                MessageBox.Show("INSERT INCOMPLETE");
            //                break;
            //            }
            //        }                    
            //    }

            //    List<BookOrderDetail> bookOrderDetailList = LearningMaterialManager.getAllBookOrderDetailByPaymentId(paymentList[i].Id);
            //    for (int j = 0; j < bookOrderDetailList.Count; j++)
            //    {
            //        int newBookId = BookManager.getNewBookId(bookOrderDetailList[j].LearningMaterialId);
            //        Book book = BookManager.findBook(newBookId);
            //        if (book != null)
            //        {
            //            PaymentDetail paymentDetail = new PaymentDetail();
            //            paymentDetail.PaymentId = paymentList[i].Id;
            //            paymentDetail.Product.Id = book.Id;
            //            paymentDetail.Product.Type = Product.ProductType.BOOK.ToString();
            //            paymentDetail.Product.Name = book.Name;
            //            paymentDetail.Amount = bookOrderDetailList[j].Amount;
            //            paymentDetail.Discount = 0;
            //            paymentDetail.Product.Price = book.Price;

            //            if (!PaymentDetailManager.addPaymentDetail(paymentDetail))
            //            {
            //                MessageBox.Show("INSERT INCOMPLETE");
            //                break;
            //            }
            //        }                    
            //    }

            //    List<CdOrderDetail> cdOrderDetailList = LearningMaterialManager.getAllCdOrderDetailByPaymentId(paymentList[i].Id);
            //    for (int j = 0; j < cdOrderDetailList.Count; j++)
            //    {
            //        int newCdId = CdManager.getNewCdId(cdOrderDetailList[j].LearningMaterialId);
            //        Cd cd = CdManager.getCd(newCdId);
            //        if (cd != null)
            //        {
            //            PaymentDetail paymentDetail = new PaymentDetail();
            //            paymentDetail.PaymentId = paymentList[i].Id;
            //            paymentDetail.Product.Id = cd.Id;
            //            paymentDetail.Product.Type = Product.ProductType.CD.ToString();
            //            paymentDetail.Product.Name = cd.Name;
            //            paymentDetail.Amount = cdOrderDetailList[j].Amount;
            //            paymentDetail.Discount = 0;
            //            paymentDetail.Product.Price = cd.Price;

            //            if (!PaymentDetailManager.addPaymentDetail(paymentDetail))
            //            {
            //                MessageBox.Show("INSERT INCOMPLETE");
            //                break;
            //            }
            //        }
            //    }

            //    List<OtherCostOrderDetail> otherCostOrderDetailList = PaymentManager.getAllOtherCostOrderDetailByPaymentId(paymentList[i].Id);
            //    for (int j = 0; j < otherCostOrderDetailList.Count; j++)
            //    {
            //        int newOtherCostId = OtherCostManager.getNewOtherCostId(otherCostOrderDetailList[j].OtherCostId);
            //        OtherCost otherCost = OtherCostManager.getOtherCost(newOtherCostId);
            //        if (otherCost != null)
            //        {
            //            PaymentDetail paymentDetail = new PaymentDetail();
            //            paymentDetail.PaymentId = paymentList[i].Id;
            //            paymentDetail.Product.Id = otherCost.Id;
            //            paymentDetail.Product.Type = Product.ProductType.OTHER.ToString();
            //            paymentDetail.Product.Name = otherCost.Name;
            //            paymentDetail.Amount = 1;
            //            paymentDetail.Discount = 0;
            //            paymentDetail.Product.Price = otherCost.Price;

            //            if (!PaymentDetailManager.addPaymentDetail(paymentDetail))
            //            {
            //                MessageBox.Show("INSERT INCOMPLETE");
            //                break;
            //            }
            //        }
            //    }
            //}
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //List<Book> bookList = BookManager.getAllBook_Old();
            //for (int i = 0; i < bookList.Count; i++)
            //{
            //    Book book = new Book();
            //    book.Id = BookManager.getNewBookId();
            //    book.Barcode = bookList[i].Barcode;
            //    book.OriginalBarcode = bookList[i].OriginalBarcode;
            //    book.Name = bookList[i].Name;
            //    book.Price = bookList[i].Price;
            //    book.Amount = bookList[i].Amount;
            //    book.Status = BookManager.getBookStatus(book.Amount);

            //    if (BookManager.addBook(book))
            //    {
            //        if (!BookManager.matchBookId(bookList[i].Id, book.Id))
            //        {
            //            MessageBox.Show("INSERT INCOMPLETE");
            //            break;
            //        }
            //    }
            //    else
            //    {
            //        MessageBox.Show("INSERT INCOMPLETE");
            //        break;
            //    }
            //}
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //List<Cd> cdList = CdManager.getAllCd_Old();
            //for (int i = 0; i < cdList.Count; i++)
            //{
            //    Cd cd = new Cd();
            //    cd.Id = CdManager.getNewCdId();
            //    cd.Barcode = cdList[i].Barcode;
            //    cd.Name = cdList[i].Name;
            //    cd.Price = cdList[i].Price;
            //    cd.Amount = cdList[i].Amount;
            //    cd.Status = CdManager.getCdStatus(cd.Amount);

            //    if (CdManager.addCd(cd))
            //    {
            //        if (!CdManager.matchCdId(cdList[i].Id, cd.Id))
            //        {
            //            MessageBox.Show("INSERT INCOMPLETE");
            //            break;
            //        }
            //    }
            //    else
            //    {
            //        MessageBox.Show("INSERT INCOMPLETE");
            //        break;
            //    }
            //}
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //List<OtherCost> otherCostList = OtherCostManager.getAllOtherCost_Old();
            //for (int i = 0; i < otherCostList.Count; i++)
            //{
            //    OtherCost otherCost = new OtherCost();
            //    otherCost.Id = OtherCostManager.getNewOtherCostId();
            //    otherCost.Name = otherCostList[i].Name;
            //    otherCost.Price = otherCostList[i].Price;

            //    if (OtherCostManager.addOtherCost(otherCost))
            //    {
            //        if (!OtherCostManager.matchOtherCostId(otherCostList[i].Id, otherCost.Id))
            //        {
            //            MessageBox.Show("INSERT INCOMPLETE");
            //            break;
            //        }
            //    }
            //    else
            //    {
            //        MessageBox.Show("INSERT INCOMPLETE");
            //        break;
            //    }
            //}
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //List<Course> courseList = CourseManager.getAllCourseOld();
            //for (int i = 0; i < courseList.Count; i++)
            //{
            //    int courseCategoryId = 0;
            //    if (courseList[i].CourseCategoryId == 10)
            //    {
            //        courseCategoryId = 1;
            //    }
            //    else if (courseList[i].CourseCategoryId == 20)
            //    {
            //        courseCategoryId = 2;
            //    }
            //    else if (courseList[i].CourseCategoryId == 30)
            //    {
            //        courseCategoryId = 3;
            //    }

            //    Course course = new Course();
            //    int courseLevelNumber = Convert.ToInt32(CourseManager.getCourseLevelNumber_Old(courseList[i].Id));
            //    course.Id = CourseManager.getNewCourseId(courseCategoryId, courseList[i].Name, courseLevelNumber);
            //    course.CourseCategoryId = courseCategoryId;
            //    course.Name = courseList[i].Name;
            //    course.Level = courseList[i].Level;
            //    course.NumberOfClassroom = 12;
            //    course.Price = courseList[i].Price;
            //    course.ClassroomDuration = courseList[i].ClassroomDuration;
            //    course.StudentPerClassroom = courseList[i].StudentPerClassroom;
            //    course.Status = courseList[i].Status;

            //    if (CourseManager.addCourse(course))
            //    {
            //        if (!CourseManager.matchCourseId(courseList[i].Id, course.Id))
            //        {
            //            MessageBox.Show("INSERT INCOMPLETE");
            //            break;
            //        }
            //    }
            //    else
            //    {
            //        MessageBox.Show("INSERT INCOMPLETE");
            //        break;
            //    }
            //}
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //List<Enrollment> enrollmentList = EnrollmentManager.getAllEnrollment_old();
            //for (int i = 0; i < enrollmentList.Count; i++)
            //{
            //    Enrollment enrollment = new Enrollment();
            //    enrollment.PaymentId = enrollmentList[i].PaymentId;
            //    enrollment.Student = enrollmentList[i].Student;
            //    enrollment.Course = enrollmentList[i].Course;
            //    enrollment.EnrolledDate = enrollmentList[i].EnrolledDate;
            //    enrollment.Status = enrollmentList[i].Status;
                
            //    enrollment = EnrollmentManager.addEnrollment(enrollment);
            //    if (enrollment == null)
            //    {
            //        MessageBox.Show("INSERT INCOMPLETE");
            //        break;
            //    }
            //}
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //List<Enrollment> enrollmentList = EnrollmentManager.getAllEnrollment();
            //for (int i = 0; i < enrollmentList.Count; i++)
            //{
            //    int enrollmentId = enrollmentList[i].Id;
            //    List<int> classroomIdList = ClassroomManager.getClassroomIdByEnrollmentId(enrollmentId);
            //    for (int j = 0; j < classroomIdList.Count; j++)
            //    {
            //        Classroom classroom = ClassroomManager.getClassroom_old(classroomIdList[j]);
            //        if (classroom != null)
            //        {
            //            Classroom newClassroom = new Classroom();
            //            newClassroom.EnrollmentId = enrollmentId;
            //            newClassroom.TeacherId = classroom.TeacherId;
            //            newClassroom.StartDate = classroom.StartDate;
            //            newClassroom.ClassDayOfWeek = classroom.ClassDayOfWeek;
            //            newClassroom.ClassTime = classroom.ClassTime;

            //            if (newClassroom.ClassTime.Length == 4)
            //            {
            //                newClassroom.ClassTime = "0" + newClassroom.ClassTime;
            //            }

            //            if (enrollmentList[i].Course != null)
            //            {
            //                if (enrollmentList[i].Course.CourseCategoryId == 10)
            //                {
            //                    newClassroom.ClassDuration = 30;
            //                }
            //                else
            //                {
            //                    if ((classroom.TeacherId == 1005) || (classroom.TeacherId == 1035))
            //                    {
            //                        newClassroom.ClassDuration = 45;
            //                    }
            //                    else
            //                    {
            //                        newClassroom.ClassDuration = enrollmentList[i].Course.ClassroomDuration;
            //                    }
            //                }
            //            }

            //            newClassroom.Status = classroom.Status;

            //            newClassroom = ClassroomManager.addClassroom(newClassroom);
            //            if (newClassroom == null)
            //            {
            //                MessageBox.Show("INSERT INCOMPLETE");
            //            }
            //        }
            //    }
            //}
        }

        private void button8_Click(object sender, EventArgs e)
        {
            //List<Enrollment> enrollmentList = EnrollmentManager.getAllEnrollment();
            //for (int i = 0; i < enrollmentList.Count; i++)
            //{
            //    int enrollmentId = enrollmentList[i].Id;
            //    List<Classroom> classroomList = ClassroomManager.getAllClassroom(enrollmentId);
            //    Dictionary<int, List<ClassroomDetail>> classroomDetailDictionary = ClassroomDetailManager.generateClassroomDetail(classroomList, enrollmentList[i].Course, enrollmentList[i].Course.NumberOfClassroom);
            //    for (int j = 0; j < classroomList.Count; j++)
            //    {
            //        if (classroomList[j] != null)
            //        {
            //            List<ClassroomDetail> classroomDetailList = classroomDetailDictionary[classroomList[j].Id];
            //            for (int k = 0; k < classroomDetailList.Count; k++)
            //            {
            //                if (classroomDetailList[k].ClassroomDate < DateTime.Today)
            //                {
            //                    classroomDetailList[k] = ClassroomDetailManager.updateClassroomDetailStatus(ClassroomDetail.ClassroomStatus.CHECKED_IN.ToString(), classroomDetailList[k]);
            //                }

            //                bool isAddSuccess = ClassroomDetailManager.addClassroomDetail(classroomDetailList[k]);
            //                if (!isAddSuccess)
            //                {
            //                    LogManager.writeLog("Error occur : INSERT ClassroomDetail failed at LoginForm.button8_Click");
            //                }
            //            }
            //        }
            //    }
            //}
        }

        private void button9_Click(object sender, EventArgs e)
        {
            //List<Classroom> classroomList = ClassroomManager.getAllClassroom();
            //for (int i = 0; i < classroomList.Count; i++)
            //{
            //    Classroom classroom = classroomList[i];
            //    List<ClassroomDetail> classroomDetailList = ClassroomDetailManager.getAllClassroomDetail(classroom.Id);
            //    int lastIndex = classroomDetailList.Count - 1;
            //    if (classroomDetailList[lastIndex].ClassroomDate < DateTime.Today)
            //    {
            //        classroom.Status = Classroom.ClassroomStatus.INACTIVE.ToString();
            //    }
            //    else
            //    {
            //        classroom.Status = Classroom.ClassroomStatus.ACTIVE.ToString();
            //    }

            //    ClassroomManager.updateClassroom(classroom);
            //}
        }

        private void button10_Click(object sender, EventArgs e)
        {
            //List<Teacher> teacherList = TeacherManager.getAllTeacher();
            //for (int i = 0; i < teacherList.Count; i++)
            //{
            //    List<string> courseNameList = TeacherManager.getCourseNameByTeacherId(teacherList[i].Id);
            //    for (int j = 0; j < courseNameList.Count; j++)
            //    {
            //        List<Course> courseList = CourseManager.getAllCourseByCourseNameWithoutWildard(courseNameList[j]);
            //        for (int k = 0; k < courseList.Count; k++)
            //        {
            //            TeacherManager.addTeachingCourse(teacherList[i].Id, courseList[k].Id);
            //        }
            //    }
            //}
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Dictionary<string, List<Course>> courseMapping = new Dictionary<string, List<Course>>();

            List<Course> tempCourseList = CourseManager.findAllCourse();
            foreach (Course tempCourse in tempCourseList)
            {
                if (courseMapping.Count == 0)
                {
                    List<Course> courseList = new List<Course>();
                    courseList.Add(tempCourse);
                    courseMapping.Add(tempCourse.Name, courseList);
                }
                else
                {
                    if (courseMapping.ContainsKey(tempCourse.Name))
                    {
                        courseMapping[tempCourse.Name].Add(tempCourse);
                    }
                    else
                    {
                        List<Course> courseList = new List<Course>();
                        courseList.Add(tempCourse);
                        courseMapping.Add(tempCourse.Name, courseList);
                    }
                }
            }

            System.IO.StreamWriter file = new System.IO.StreamWriter(PianoForte.Constant.Constant.STARTUP_PATH + "\\Account\\update_enrollment.txt");
            int courseNumber = 1;

            foreach (string courseName in courseMapping.Keys)
            {                
                int courseLevel = 1;

                foreach (Course course in courseMapping[courseName])
                {                    
                    int newCourseId = 1000000 + (courseNumber * 100) + courseLevel;

                    course.CourseId_old = course.Id;

                    CourseManager.updateCourse(course);
                    CourseManager.updateCourseId(course.Id, newCourseId);

                    file.WriteLine("UPDATE enrollment SET enrollment.courseId = " + newCourseId.ToString() + " WHERE enrollment.courseId = " + course.CourseId_old + ";");
                    file.WriteLine("UPDATE teaching_course SET teaching_course.courseId = " + newCourseId.ToString() + " WHERE teaching_course.courseId = " + course.CourseId_old + ";");
                    file.WriteLine("UPDATE payment_detail SET payment_detail.productId = " + newCourseId.ToString() + " WHERE payment_detail.productId = " + course.CourseId_old + ";");  

                    courseLevel++;
                }

                courseNumber++;
            }

            file.Close();
        }
    }
}
