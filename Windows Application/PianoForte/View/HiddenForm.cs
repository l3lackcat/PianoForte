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
using Newtonsoft.Json;

namespace PianoForte.View
{
    public partial class HiddenForm : Form
    {
        public HiddenForm()
        {
            InitializeComponent();
        }

        private string removeApostrophe(string str)
        {
            if (str.Contains("'"))
            {
                str = str.Replace("'", "''");
            }

            return str;
        }

        private string convertToMySqlTime(string time)
        {
            time = time.Replace(".", ":");
            time += ":00";

            return time;
        }

        private void createInsertStringForStudents()
        {
            System.IO.StreamWriter studentFile = new System.IO.StreamWriter(PianoForte.Constant.Constant.STARTUP_PATH + "\\Account\\insert_students.txt");
            System.IO.StreamWriter studentContactFile = new System.IO.StreamWriter(PianoForte.Constant.Constant.STARTUP_PATH + "\\Account\\insert_student_contact.txt");
            //System.IO.StreamWriter studentAddressFile = new System.IO.StreamWriter(PianoForte.Constant.Constant.STARTUP_PATH + "\\Account\\insert_student_address.txt");

            List<Student> studentList = StudentManager.findAllStudent();
            foreach (Student student in studentList)
            {
                string insertString1 = "INSERT INTO students (firstname, lastname, nickname, birthday, registered_date, student_status) VALUES(";
                string insertString2 = "INSERT INTO student_contacts (student_id, contact_type, contact_label, contact_content, contact_status) VALUES(";
                //string insertString3 = "INSERT INTO student_address (student_id, building_name, street_address, subdistrict, district, province, postcode, country) VALUES";

                insertString1 += "'" + this.removeApostrophe(student.Firstname) + "', ";
                insertString1 += "'" + this.removeApostrophe(student.Lastname) + "', ";
                insertString1 += "'" + this.removeApostrophe(student.Nickname) + "', ";
                insertString1 += "'" + student.Birthday.ToString("yyyy-MM-dd") + "', ";
                //insertString += "'" + this.removeApostrophe(student.Address.Address1) + "', ";
                //insertString += "'" + this.removeApostrophe(student.Address.Address2) + "', ";
                //insertString += "'" + student.Address.PostCode + "', ";
                //insertString += "'" + student.Phone1 + "', ";
                //insertString += "'" + student.Phone2 + "', ";
                //insertString += "'" + student.Phone3 + "', ";
                //insertString += "'" + this.removeApostrophe(student.Email) + "', ";
                insertString1 += "'" + student.RegisteredDate.ToString("yyyy-MM-dd HH:mm:ss") + "', ";

                if (student.Status == Student.StudentStatus.ACTIVE.ToString())
                {
                    insertString1 += "'1');";
                }
                else if (student.Status == Student.StudentStatus.INACTIVE.ToString())
                {
                    insertString1 += "'2');";
                }
                else if (student.Status == Student.StudentStatus.DROPPED.ToString())
                {
                    insertString1 += "'3');";
                }
                else
                {
                    insertString1 += "'0');";
                }

                if (student.Phone1 != "")
                {
                    string temp = insertString2;
                    temp += "'" + student.Id + "', ";

                    string phonePrefix = student.Phone1.Substring(0, 2);
                    if ((phonePrefix == "08") || (phonePrefix == "09"))
                    {
                        temp += "'1', ";
                        temp += "'เบอร์มือถือ', ";
                    }
                    else
                    {
                        temp += "'1', ";
                        temp += "'เบอร์บ้าน', ";
                    }

                    temp += "'" + student.Phone1 + "', 1);";
                    studentContactFile.WriteLine(temp);
                }

                if (student.Phone2 != "")
                {
                    string temp = insertString2;
                    temp += "'" + student.Id + "', ";

                    string phonePrefix = student.Phone2.Substring(0, 2);
                    if ((phonePrefix == "08") || (phonePrefix == "09"))
                    {
                        temp += "'1', ";
                        temp += "'เบอร์มือถือ', ";
                    }
                    else
                    {
                        temp += "'1', ";
                        temp += "'เบอร์บ้าน', ";
                    }

                    temp += "'" + student.Phone2 + "', 1);";
                    studentContactFile.WriteLine(temp);
                }

                if (student.Phone3 != "")
                {
                    string temp = insertString2;
                    temp += "'" + student.Id + "', ";

                    string phonePrefix = student.Phone3.Substring(0, 2);
                    if ((phonePrefix == "08") || (phonePrefix == "09"))
                    {
                        temp += "'1', ";
                        temp += "'เบอร์มือถือ', ";
                    }
                    else
                    {
                        temp += "'1', ";
                        temp += "'เบอร์บ้าน', ";
                    }

                    temp += "'" + student.Phone3 + "', 1);";
                    studentContactFile.WriteLine(temp);
                }

                if (student.Email != "")
                {
                    string temp = insertString2;
                    temp += "'" + student.Id + "', ";
                    temp += "'2', ";
                    temp += "'อีเมล์', ";
                    temp += "'" + student.Email + "', 1);";
                    studentContactFile.WriteLine(temp);
                }

                studentFile.WriteLine(insertString1);
            }

            studentFile.Close();
            studentContactFile.Close();
        }

        private void createInsertStringForTeachers()
        {
            System.IO.StreamWriter teacherFile = new System.IO.StreamWriter(PianoForte.Constant.Constant.STARTUP_PATH + "\\Account\\insert_teachers.txt");
            System.IO.StreamWriter teacherContactFile = new System.IO.StreamWriter(PianoForte.Constant.Constant.STARTUP_PATH + "\\Account\\insert_teacher_contact.txt");

            List<Teacher> teacherList = TeacherManager.findAllTeacher();
            foreach (Teacher teacher in teacherList)
            {
                string insertString1 = "INSERT INTO teachers (teacher_id, firstname, lastname, nickname, teacher_status) VALUES(";
                string insertString2 = "INSERT INTO teacher_contacts (teacher_id, contact_type, contact_label, contact_content, contact_status) VALUES(";

                insertString1 += "'" + teacher.Id + "', ";
                insertString1 += "'" + this.removeApostrophe(teacher.Firstname) + "', ";
                insertString1 += "'" + this.removeApostrophe(teacher.Lastname) + "', ";
                insertString1 += "'" + this.removeApostrophe(teacher.Nickname) + "', ";
                //insertString += "'" + teacher.Phone1 + "', ";
                //insertString += "'" + teacher.Phone2 + "', ";
                //insertString += "'" + teacher.Phone3 + "', ";
                //insertString += "'" + this.removeApostrophe(teacher.Email) + "', ";
                //insertString += "'" + Convert.ToInt32(teacher.Settings) + "', ";

                if (teacher.Status == Teacher.TeacherStatus.ACTIVE.ToString())
                {
                    insertString1 += "'1');";
                }
                else if (teacher.Status == Teacher.TeacherStatus.RESIGNED.ToString())
                {
                    insertString1 += "'4');";
                }
                else
                {
                    insertString1 += "'0');";
                }

                if (teacher.Phone1 != "")
                {
                    string temp = insertString2;
                    temp += "'" + teacher.Id + "', ";

                    string phonePrefix = teacher.Phone1.Substring(0, 2);
                    if ((phonePrefix == "08") || (phonePrefix == "09"))
                    {
                        temp += "'1', ";
                        temp += "'เบอร์มือถือ', ";
                    }
                    else
                    {
                        temp += "'1', ";
                        temp += "'เบอร์บ้าน', ";
                    }

                    temp += "'" + teacher.Phone1 + "', 1);";
                    teacherContactFile.WriteLine(temp);
                }

                if (teacher.Phone2 != "")
                {
                    string temp = insertString2;
                    temp += "'" + teacher.Id + "', ";

                    string phonePrefix = teacher.Phone2.Substring(0, 2);
                    if ((phonePrefix == "08") || (phonePrefix == "09"))
                    {
                        temp += "'1', ";
                        temp += "'เบอร์มือถือ', ";
                    }
                    else
                    {
                        temp += "'1', ";
                        temp += "'เบอร์บ้าน', ";
                    }

                    temp += "'" + teacher.Phone2 + "', 1);";
                    teacherContactFile.WriteLine(temp);
                }

                if (teacher.Phone3 != "")
                {
                    string temp = insertString2;
                    temp += "'" + teacher.Id + "', ";

                    string phonePrefix = teacher.Phone3.Substring(0, 2);
                    if ((phonePrefix == "08") || (phonePrefix == "09"))
                    {
                        temp += "'1', ";
                        temp += "'เบอร์มือถือ', ";
                    }
                    else
                    {
                        temp += "'1', ";
                        temp += "'เบอร์บ้าน', ";
                    }

                    temp += "'" + teacher.Phone3 + "', 1);";
                    teacherContactFile.WriteLine(temp);
                }

                if (teacher.Email != "")
                {
                    string temp = insertString2;
                    temp += "'" + teacher.Id + "', ";
                    temp += "'2', ";
                    temp += "'อีเมล์', ";
                    temp += "'" + teacher.Email + "', 1);";
                    teacherContactFile.WriteLine(temp);
                }

                teacherFile.WriteLine(insertString1);
            }

            teacherFile.Close();
            teacherContactFile.Close();
        }

        private void createInsertStringForUsers()
        {
            System.IO.StreamWriter localUserFile = new System.IO.StreamWriter(PianoForte.Constant.Constant.STARTUP_PATH + "\\Account\\insert_local_users.txt");
            System.IO.StreamWriter globalUserFile = new System.IO.StreamWriter(PianoForte.Constant.Constant.STARTUP_PATH + "\\Account\\insert_global_users.txt");

            List<User> userList = UserManager.findAllUser();
            foreach (User user in userList)
            {
                string insertString1 = "INSERT INTO local_users (local_user_firstname, local_user_lastname, local_user_nickname, local_user_role, local_user_status) VALUES(";
                string insertString2 = "INSERT INTO global_users (global_user_username, global_user_password, global_user_display_name, global_user_role, global_user_status, branch_id, user_id, last_login) VALUES(";

                //local_users -> local_user_firstname
                insertString1 += "'" + this.removeApostrophe(user.DisplayName) + "', ";
                
                //local_users -> local_user_lastname
                insertString1 += "'', ";
                
                //local_users -> local_user_nickname
                insertString1 += "'', ";
                
                //global_users -> global_user_username
                insertString2 += "'" + this.removeApostrophe(user.Username) + "', ";
                
                //global_users -> global_user_password
                insertString2 += "'" + this.removeApostrophe(user.Password) + "', ";
                
                //global_users -> global_user_display_name
                insertString2 += "'" + this.removeApostrophe(user.DisplayName) + "', ";
                                
                if (user.Role == (int)User.UserRole.ADMIN)
                {
                    //local_users -> local_user_role
                    insertString1 += "'2', ";

                    //global_users -> global_user_role
                    insertString2 += "'2', ";
                }
                else if (user.Role == (int)User.UserRole.NORMAL)
                {
                    //local_users -> local_user_role
                    insertString1 += "'3', ";

                    //global_users -> global_user_role
                    insertString2 += "'3', ";
                }

                //local_users -> local_user_status
                insertString1 += "'1');";

                //global_users -> global_user_status
                insertString2 += "'1', ";

                //global_users -> branch_id
                insertString2 += "'1', ";

                //global_users -> user_id
                insertString2 += "'1', ";

                //global_users -> last_login
                insertString2 += "NULL);";

                localUserFile.WriteLine(insertString1);
                globalUserFile.WriteLine(insertString2);
            }

            localUserFile.Close();
            globalUserFile.Close();
        }

        private void createInsertStringForCourses()
        {
            System.IO.StreamWriter file = new System.IO.StreamWriter(PianoForte.Constant.Constant.STARTUP_PATH + "\\Account\\insert_courses.txt");

            List<Course> courseList = CourseManager.findAllCourse();
            foreach (Course course in courseList)
            {
                string insertString = "INSERT INTO courses (course_id, course_category_id, course_name, course_level, course_fee, number_of_times, classroom_duration, student_per_classroom, course_status) VALUES(";
                insertString += "'" + course.Id + "', ";
                insertString += "'" + course.CourseCategoryId + "', ";
                insertString += "'" + this.removeApostrophe(course.Name) + "', ";
                insertString += "'" + this.removeApostrophe(course.Level) + "', ";
                insertString += "'" + course.Price + "', ";
                insertString += "'" + course.NumberOfClassroom + "', ";
                insertString += "'" + course.ClassroomDuration + "', ";
                insertString += "'" + course.StudentPerClassroom + "', ";

                if (course.Status == Course.CourseStatus.ACTIVE.ToString())
                {
                    insertString += "'1');";
                }
                else if (course.Status == Course.CourseStatus.INACTIVE.ToString())
                {
                    insertString += "'2');";
                }
                else
                {
                    insertString += "'0');";
                }

                file.WriteLine(insertString);
            }

            file.Close();
        }

        private void createInsertStringForCourseCategories()
        {
            System.IO.StreamWriter file = new System.IO.StreamWriter(PianoForte.Constant.Constant.STARTUP_PATH + "\\Account\\insert_course_categories.txt");

            List<CourseCategory> courseCategoryList = CourseCategoryManager.findAllCourseCategory();
            foreach (CourseCategory courseCategory in courseCategoryList)
            {
                string insertString = "INSERT INTO course_categories (course_category_name, course_category_status) VALUES(";
                insertString += "'" + this.removeApostrophe(courseCategory.Name) + "', ";

                if (courseCategory.Status == CourseCategory.CourseCategoryStatus.ACTIVE.ToString())
                {
                    insertString += "'1');";
                }
                else if (courseCategory.Status == CourseCategory.CourseCategoryStatus.INACTIVE.ToString())
                {
                    insertString += "'2');";
                }
                else
                {
                    insertString += "'0');";
                }

                file.WriteLine(insertString);
            }

            file.Close();
        }

        private void createInsertStringForBooks()
        {
            System.IO.StreamWriter file = new System.IO.StreamWriter(PianoForte.Constant.Constant.STARTUP_PATH + "\\Account\\insert_books.txt");

            List<Book> bookList = BookManager.findAllBook();
            foreach (Book book in bookList)
            {
                string insertString = "INSERT INTO books (book_id, book_internal_barcode, book_original_barcode, book_name, book_unit_price, book_quantity, book_status) VALUES(";
                insertString += "'" + book.Id + "', ";
                insertString += "'" + book.Barcode + "', ";
                insertString += "'" + book.OriginalBarcode + "', ";
                insertString += "'" + this.removeApostrophe(book.Name) + "', ";
                insertString += "'" + book.Price + "', ";
                insertString += "'" + book.Quantity + "', ";

                if (book.Status == Book.BookStatus.AVAILABLE.ToString())
                {
                    insertString += "'5');";
                }
                else if (book.Status == Book.BookStatus.EMPTY.ToString())
                {
                    insertString += "'6');";
                }
                else if (book.Status == Book.BookStatus.CANCELED.ToString())
                {
                    insertString += "'7');";
                }
                else
                {
                    insertString += "'0');";
                }

                file.WriteLine(insertString);
            }

            file.Close();
        }

        private void createInsertStringForCds()
        {
            System.IO.StreamWriter file = new System.IO.StreamWriter(PianoForte.Constant.Constant.STARTUP_PATH + "\\Account\\insert_cds.txt");

            List<Cd> cdList = CdManager.findAllCd();
            foreach (Cd cd in cdList)
            {
                string insertString = "INSERT INTO cds (cd_id, cd_internal_barcode, cd_original_barcode, cd_name, cd_unit_price, cd_quantity, cd_status) VALUES(";
                insertString += "'" + cd.Id + "', ";
                insertString += "'" + cd.Barcode + "', ";
                insertString += "'', ";
                insertString += "'" + this.removeApostrophe(cd.Name) + "', ";
                insertString += "'" + cd.Price + "', ";
                insertString += "'" + cd.Quantity + "', ";

                if (cd.Status == Cd.CdStatus.AVAILABLE.ToString())
                {
                    insertString += "'5');";
                }
                else if (cd.Status == Cd.CdStatus.EMPTY.ToString())
                {
                    insertString += "'6');";
                }
                else if (cd.Status == Cd.CdStatus.CANCELED.ToString())
                {
                    insertString += "'7');";
                }
                else
                {
                    insertString += "'0');";
                }

                file.WriteLine(insertString);
            }

            file.Close();
        }

        private void createInsertStringForOtherProducts()
        {
            System.IO.StreamWriter file = new System.IO.StreamWriter(PianoForte.Constant.Constant.STARTUP_PATH + "\\Account\\insert_other_products.txt");

            List<OtherCost> otherProductList = OtherCostManager.findAllOtherCost();
            foreach (OtherCost otherProduct in otherProductList)
            {
                string insertString = "INSERT INTO other_products (other_product_id, other_product_name, other_product_unit_price) VALUES(";
                insertString += "'" + otherProduct.Id + "', ";
                insertString += "'" + this.removeApostrophe(otherProduct.Name) + "', ";
                insertString += "'" + otherProduct.Price + "');";

                file.WriteLine(insertString);
            }

            file.Close();
        }

        private void createInsertStringForPayments()
        {
            System.IO.StreamWriter file = new System.IO.StreamWriter(PianoForte.Constant.Constant.STARTUP_PATH + "\\Account\\insert_payments.txt");

            bool flag = false;

            List<Payment> paymentList = PaymentManager.findAllPayment();
            foreach (Payment payment in paymentList)
            {
                string insertString = "INSERT INTO payments (student_id, receiver_id, payment_date, payment_status) VALUES(";
                
                if (payment.Id == 96)
                {
                    flag = true;
                }
                else
                {
                    flag = false;
                }

                insertString += "'" + payment.StudentId + "', ";
                insertString += "'" + payment.ReceiverId + "', ";
                insertString += "'" + payment.PaymentDate.ToString("yyyy-MM-dd HH:mm:ss") + "', ";

                if (payment.Status == Payment.PaymentStatus.PAID.ToString())
                {
                    insertString += "'8');";
                }
                else if (payment.Status == Payment.PaymentStatus.CANCELED.ToString())
                {
                    insertString += "'7');";
                }
                else
                {
                    insertString += "'0');";
                }

                file.WriteLine(insertString);

                if (flag)
                {
                    insertString = "INSERT INTO payments (student_id, receiver_id, payment_date, payment_status) VALUES(";
                    insertString += "'1', ";
                    insertString += "'1', ";
                    insertString += "'" + payment.PaymentDate.ToString("yyyy-MM-dd HH:mm:ss") + "', ";
                    insertString += "'0');";

                    file.WriteLine(insertString);
                }                               
            }

            file.Close();
        }

        private void createInsertStringForPaymentMethods()
        {
            System.IO.StreamWriter file = new System.IO.StreamWriter(PianoForte.Constant.Constant.STARTUP_PATH + "\\Account\\insert_payment_methods.txt");

            List<Payment> paymentList = PaymentManager.findAllPayment();
            foreach (Payment payment in paymentList)
            {
                string insertString = "INSERT INTO payment_methods (payment_id, payment_method, credit_card_number, amount) VALUES(";
                insertString += "'" + payment.Id + "', ";

                if (payment.CreditCardNumber == "")
                {
                    insertString += "'1', ";
                    insertString += "'', ";
                }
                else
                {
                    insertString += "'2', ";
                    insertString += "'" + payment.CreditCardNumber + "', ";
                }

                insertString += "'" + payment.TotalPrice + "');";

                file.WriteLine(insertString);
            }

            file.Close();   
        }

        private void createInsertStringForPrintedPayments()
        {
            System.IO.StreamWriter file = new System.IO.StreamWriter(PianoForte.Constant.Constant.STARTUP_PATH + "\\Account\\insert_printed_payments.txt");

            List<Payment> paymentList = PaymentManager.findAllPayment();
            foreach (Payment payment in paymentList)
            {
                if (payment.PrintPaymentId != 0)
                {
                    string insertString = "INSERT INTO printed_payments (printed_payment_id, payment_id, printed_date) VALUES(";
                    insertString += "'" + payment.PrintPaymentId + "', ";
                    insertString += "'" + payment.Id + "', ";
                    insertString += "'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "');";

                    file.WriteLine(insertString);
                }
            }

            file.Close(); 
        }

        private void createInsertStringForPaymentDetails()
        {
            System.IO.StreamWriter file = new System.IO.StreamWriter(PianoForte.Constant.Constant.STARTUP_PATH + "\\Account\\insert_payment_details.txt");

            List<Payment> paymentList = PaymentManager.findAllPayment();
            foreach (Payment payment in paymentList)
            {                
                List<PaymentDetail> paymentDetailList = PaymentDetailManager.findAllPaymentDetail(payment.Id);
                foreach (PaymentDetail paymentDetail in paymentDetailList)
                {
                    string insertString = "INSERT INTO payment_details (payment_id, product_id, product_type, product_name, product_unit_price, quantity, discount) VALUES(";

                    insertString += "'" + paymentDetail.PaymentId + "', ";
                    insertString += "'" + paymentDetail.Product.Id + "', ";

                    if (paymentDetail.Product.Type == Product.ProductType.COURSE.ToString())
                    {
                        insertString += "'1', ";
                    }
                    else if (paymentDetail.Product.Type == Product.ProductType.BOOK.ToString())
                    {
                        insertString += "'2', ";
                    }
                    else if (paymentDetail.Product.Type == Product.ProductType.CD.ToString())
                    {
                        insertString += "'3', ";
                    }
                    else if (paymentDetail.Product.Type == Product.ProductType.OTHER.ToString())
                    {
                        insertString += "'4', ";
                    }
                    else
                    {
                        insertString += "'0', ";
                    }
                    
                    insertString += "'" + this.removeApostrophe(paymentDetail.Product.Name) + "', ";
                    insertString += "'" + paymentDetail.Product.Price + "', ";
                    insertString += "'" + paymentDetail.Quantity + "', ";
                    insertString += "'" + paymentDetail.Discount + "');";

                    file.WriteLine(insertString);
                }                
            }

            file.Close();
        }

        private void createInsertStringForEnrollments()
        {
            System.IO.StreamWriter file = new System.IO.StreamWriter(PianoForte.Constant.Constant.STARTUP_PATH + "\\Account\\insert_enrollments.txt");

            List<Enrollment> enrollmentList = EnrollmentManager.findAllEnrollment();
            foreach (Enrollment enrollment in enrollmentList)
            {
                string insertString = "INSERT INTO enrollments (payment_id, student_id, course_id, enrollment_date, enrollment_status) VALUES(";

                insertString += "'" + enrollment.PaymentId + "', ";
                insertString += "'" + enrollment.Student.Id + "', ";
                insertString += "'" + enrollment.Course.Id + "', ";
                insertString += "'" + enrollment.EnrolledDate.ToString("yyyy-MM-dd HH:mm:ss") + "', ";

                if (enrollment.Status == Enrollment.EnrollmentStatus.PAID.ToString())
                {
                    insertString += "'8');";
                }
                else if (enrollment.Status == Enrollment.EnrollmentStatus.NOT_PAID.ToString())
                {
                    insertString += "'9');";
                }
                else if (enrollment.Status == Enrollment.EnrollmentStatus.CANCELED.ToString())
                {
                    insertString += "'7');";
                }
                else
                {
                    insertString += "'0');";
                }

                file.WriteLine(insertString);
            }

            file.Close();
        }

        private void createInsertStringForClassrooms()
        {
            System.IO.StreamWriter file = new System.IO.StreamWriter(PianoForte.Constant.Constant.STARTUP_PATH + "\\Account\\insert_classrooms.txt");

            List<Enrollment> enrollmentList = EnrollmentManager.findAllEnrollment();
            foreach (Enrollment enrollment in enrollmentList)
            {
                List<Classroom> classroomList = ClassroomManager.findAllClassroom(enrollment.Id);
                foreach (Classroom classroom in classroomList)
                {
                    string insertString = "INSERT INTO classrooms (enrollment_id, teacher_id, classroom_start_date, classroom_time, classroom_duration, classroom_status) VALUES(";
                    insertString += "'" + classroom.EnrollmentId + "', ";
                    insertString += "'" + classroom.TeacherId + "', ";
                    insertString += "'" + classroom.StartDate.ToString("yyyy-MM-dd HH:mm:ss") + "', ";
                    insertString += "'" + classroom.ClassTime + "', ";
                    insertString += "'" + classroom.ClassDuration + "', ";

                    if (classroom.Status == Classroom.ClassroomStatus.ACTIVE.ToString())
                    {
                        insertString += "'1');";
                    }
                    else if (classroom.Status == Classroom.ClassroomStatus.INACTIVE.ToString())
                    {
                        insertString += "'2');";
                    }
                    else if (classroom.Status == Enrollment.EnrollmentStatus.CANCELED.ToString())
                    {
                        insertString += "'7');";
                    }
                    else
                    {
                        insertString += "'0');";
                    }

                    file.WriteLine(insertString);
                }                
            }

            file.Close();
        }

        private void createInsertStringForClassroomDetails()
        {
            System.IO.StreamWriter file = new System.IO.StreamWriter(PianoForte.Constant.Constant.STARTUP_PATH + "\\Account\\insert_classroom_details.txt");

            List<Enrollment> enrollmentList = EnrollmentManager.findAllEnrollment();
            foreach (Enrollment enrollment in enrollmentList)
            {
                List<Classroom> classroomList = ClassroomManager.findAllClassroom(enrollment.Id);
                foreach (Classroom classroom in classroomList)
                {
                    List<ClassroomDetail> classroomDetailList = ClassroomDetailManager.findAllClassroomDetailByClassroomId(classroom.Id);
                    foreach (ClassroomDetail classroomDetail in classroomDetailList)
                    {
                        DateTime classroomTime = Convert.ToDateTime(this.convertToMySqlTime(classroomDetail.ClassroomTime));
                        DateTime classroomStart = classroomDetail.ClassroomDate.AddHours(classroomTime.Hour).AddMinutes(classroomTime.Minute);
                        DateTime classroomEnd = classroomStart.AddMinutes(classroomDetail.ClassroomDuration);

                        string insertString = "INSERT INTO classroom_details (classroom_id, teacher_id, classroom_number, classroom_start, classroom_end, classroom_type, classroom_status, previous_classroom_detail_id, absence_id, holiday_id) VALUES(";
                        insertString += "'" + classroomDetail.ClassroomId + "', ";
                        insertString += "'" + classroomDetail.TeacherId + "', ";
                        insertString += "'" + (int)classroomDetail.ClassroomNo + "', ";
                        insertString += "'" + classroomStart.ToString("yyyy-MM-dd HH:mm:ss") + "', ";
                        insertString += "'" + classroomEnd.ToString("yyyy-MM-dd HH:mm:ss") + "', ";

                        if (classroomDetail.Type == ClassroomDetail.ClassroomType.NORMAL.ToString())
                        {
                            insertString += "'1', ";
                        }
                        else if (classroomDetail.Type == ClassroomDetail.ClassroomType.POSTPONE1.ToString())
                        {
                            insertString += "'2', ";
                        }
                        else if (classroomDetail.Type == ClassroomDetail.ClassroomType.POSTPONE2.ToString())
                        {
                            insertString += "'3', ";
                        }
                        else if (classroomDetail.Type == ClassroomDetail.ClassroomType.EXTRA.ToString())
                        {
                            insertString += "'4', ";
                        }
                        else
                        {
                            insertString += "'0', ";
                        }

                        if (classroomDetail.CurrentStatus == ClassroomDetail.ClassroomStatus.WAITING.ToString())
                        {
                            insertString += "'10', ";
                        }
                        else if (classroomDetail.CurrentStatus == ClassroomDetail.ClassroomStatus.CHECKED_IN.ToString())
                        {
                            insertString += "'11', ";
                        }
                        else if (classroomDetail.CurrentStatus == ClassroomDetail.ClassroomStatus.POSTPONE1.ToString())
                        {
                            insertString += "'12', ";
                        }
                        else if (classroomDetail.CurrentStatus == ClassroomDetail.ClassroomStatus.POSTPONE2.ToString())
                        {
                            insertString += "'13', ";
                        }
                        else if (classroomDetail.CurrentStatus == ClassroomDetail.ClassroomStatus.STUDENT_ABSENT.ToString())
                        {
                            insertString += "'14', ";
                        }
                        else if (classroomDetail.CurrentStatus == ClassroomDetail.ClassroomStatus.MISSING.ToString())
                        {
                            insertString += "'15', ";
                        }
                        else if (classroomDetail.CurrentStatus == ClassroomDetail.ClassroomStatus.TEACHER_ABSENT.ToString())
                        {
                            insertString += "'16', ";
                        }
                        else if (classroomDetail.CurrentStatus == ClassroomDetail.ClassroomStatus.SCHOOL_CLOSE.ToString())
                        {
                            insertString += "'19', ";
                        }
                        else if (classroomDetail.CurrentStatus == ClassroomDetail.ClassroomStatus.CANCELED.ToString())
                        {
                            insertString += "'7', ";
                        }
                        else
                        {
                            insertString += "'0', ";
                        }

                        insertString += "'0', ";
                        insertString += "'0', ";
                        insertString += "'0');";

                        file.WriteLine(insertString);
                    }                    
                }
            }

            file.Close();
        }

        private void createInsertStringForTeachedCourses()
        {
            System.IO.StreamWriter file = new System.IO.StreamWriter(PianoForte.Constant.Constant.STARTUP_PATH + "\\Account\\insert_teached_courses.txt");

            List<Teacher> teacherList = TeacherManager.findAllTeacher();
            foreach (Teacher teacher in teacherList)
            {
                List<int> courseIdList = TeachingCourseManager.getCourseIdByTeacherId(teacher.Id);
                foreach (int courseId in courseIdList)
                {
                    string insertString = "INSERT INTO teached_courses (teacher_id, course_id) VALUES(";
                    insertString += "'" + teacher.Id + "', ";
                    insertString += "'" + courseId + "');";

                    file.WriteLine(insertString);
                }                
            }

            file.Close();
        }

        private void Button_start_Click(object sender, EventArgs e)
        {
            if (this.CheckBox_generate_students.Checked)
            {
                this.createInsertStringForStudents();
            }

            if (this.CheckBox_generate_teachers.Checked)
            {
                this.createInsertStringForTeachers();
            }

            if (this.CheckBox_generate_users.Checked)
            {
                this.createInsertStringForUsers();
            }

            if (this.CheckBox_generate_courses.Checked)
            {
                this.createInsertStringForCourses();
            }

            if (this.CheckBox_generate_course_categories.Checked)
            {
                this.createInsertStringForCourseCategories();
            }

            if (this.CheckBox_generate_books.Checked)
            {
                this.createInsertStringForBooks();
            }

            if (this.CheckBox_generate_cds.Checked)
            {
                this.createInsertStringForCds();
            }

            if (this.CheckBox_generate_other_products.Checked)
            {
                this.createInsertStringForOtherProducts();
            }

            if (this.CheckBox_generate_payments.Checked)
            {
                this.createInsertStringForPayments();
            }

            if (this.CheckBox_generate_payment_types.Checked)
            {
                this.createInsertStringForPaymentMethods();
            }

            if (this.CheckBox_generate_printed_payments.Checked)
            {
                this.createInsertStringForPrintedPayments();
            }

            if (this.CheckBox_generate_payment_details.Checked)
            {
                this.createInsertStringForPaymentDetails();
            }

            if (this.CheckBox_generate_enrollments.Checked)
            {
                this.createInsertStringForEnrollments();
            }

            if (this.CheckBox_generate_classrooms.Checked)
            {
                this.createInsertStringForClassrooms();
            }

            if (this.CheckBox_generate_classroom_detail.Checked)
            {
                this.createInsertStringForClassroomDetails();
            }

            if (this.CheckBox_generate_teached_courses.Checked)
            {
                this.createInsertStringForTeachedCourses();
            }

            MessageBox.Show("Done!");
        }

        private void updateStudent()
        {
            bool haveActiveClassroom = false;

            List<Student> studentList = StudentManager.findAllStudent();
            foreach (Student student in studentList)
            {
                haveActiveClassroom = false;

                List<Enrollment> enrollmentList = EnrollmentManager.findAllEnrollmentByStudentId(student.Id);
                foreach (Enrollment enrollment in enrollmentList)
                {                    
                    if (!haveActiveClassroom)
                    {
                        List<Classroom> classroomList = ClassroomManager.findAllClassroom(enrollment.Id);
                        foreach (Classroom classroom in classroomList)
                        {
                            if (!haveActiveClassroom)
                            {
                                List<ClassroomDetail> classroomDetailList = ClassroomDetailManager.findAllClassroomDetailByClassroomId(classroom.Id);
                                foreach (ClassroomDetail classroomDetail in classroomDetailList)
                                {
                                    if (classroomDetail.ClassroomDate >= DateTime.Today)
                                    {
                                        haveActiveClassroom = true;
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }

                if (haveActiveClassroom)
                {
                    if (student.Status != Student.StudentStatus.ACTIVE.ToString())
                    {
                        student.Status = Student.StudentStatus.ACTIVE.ToString();
                        StudentManager.updateStudent(student);
                    }
                }
                else
                {
                    if (student.Status != Student.StudentStatus.INACTIVE.ToString())
                    {
                        student.Status = Student.StudentStatus.INACTIVE.ToString();
                        StudentManager.updateStudent(student);
                    }
                }
            }
        }

        private void Button_Generate_Json_Click(object sender, EventArgs e)
        {
            if (this.CheckBox_generate_teachers.Checked)
            {
                this.generateTeacherJson();
                Console.WriteLine("generateTeacherJson done.");
            }

            if (this.CheckBox_generate_students.Checked)
            {
                this.generateStudentJson();
                Console.WriteLine("generateStudentJson done.");
            }

            if (this.CheckBox_generate_books.Checked)
            {
                this.generateBookJson();
                Console.WriteLine("generateBookJson done.");
            }

            if (this.CheckBox_generate_cds.Checked)
            {
                this.generateCdJson();
                Console.WriteLine("generatecdJson done.");
            }

            if (this.CheckBox_generate_course_categories.Checked)
            {
                this.generatCourseCategoryJson();
                Console.WriteLine("generatCourseCategoryJson done.");
            }

            if (this.CheckBox_generate_courses.Checked)
            {
                this.generatCourseJson();
                Console.WriteLine("generatCourseJson done.");
            }

            if (this.CheckBox_generate_other_products.Checked)
            {
                this.generateOtherItemJson();
                Console.WriteLine("generateOtherItemJson done.");
            }
        }

        private void generateTeacherJson()
        {
            List<Teacher> teacherList = TeacherManager.findAllTeacher();
            List<Object> newTeacherList = new List<Object>();

            foreach (Teacher teacher in teacherList)
            {
                int status = 0;
                if (teacher.Status == Teacher.TeacherStatus.ACTIVE.ToString())
                {
                    status = 1;
                }
                else if (teacher.Status == "QUITED")
                {
                    status = 4;
                }

                List<Object> phones = new List<Object>();
                List<Object> emails = new List<Object>();

                Object phone1 = null;
                if (teacher.Phone1 != "")
                {
                    string label = "เบอร์โทร";
                    string value = teacher.Phone1.Replace("-", "");

                    string phonePrefix = teacher.Phone1.Substring(0, 2);
                    if ((phonePrefix == "08") || (phonePrefix == "09"))
                    {
                        label = "เบอร์โทร";
                    }

                    phone1 = new
                    {
                        label = label,
                        value = value,
                        primary = false
                    };
                }

                Object phone2 = null;
                if (teacher.Phone2 != "")
                {
                    string label = "เบอร์โทร";
                    string value = teacher.Phone2.Replace("-", "");

                    string phonePrefix = teacher.Phone2.Substring(0, 2);
                    if ((phonePrefix == "08") || (phonePrefix == "09"))
                    {
                        label = "เบอร์โทร";
                    }

                    phone2 = new
                    {
                        label = label,
                        value = value,
                        primary = false
                    };
                }

                Object phone3 = null;
                if (teacher.Phone3 != "")
                {
                    string label = "เบอร์โทร";
                    string value = teacher.Phone3.Replace("-", "");

                    string phonePrefix = teacher.Phone3.Substring(0, 2);
                    if ((phonePrefix == "08") || (phonePrefix == "09"))
                    {
                        label = "เบอร์โทร";
                    }

                    phone3 = new
                    {
                        label = label,
                        value = value,
                        primary = false
                    };
                }

                if (phone1 != null)
                {
                    phones.Add(phone1);
                }

                if (phone2 != null)
                {
                    phones.Add(phone2);
                }

                if (phone3 != null)
                {
                    phones.Add(phone3);
                }

                Object email = null;
                if (teacher.Email != "")
                {
                    string label = "อีเมล์";
                    string value = teacher.Email;

                    email = new
                    {
                        label = label,
                        value = value,
                        primary = false
                    };
                }

                if (email != null)
                {
                    emails.Add(email);
                }

                teacher.TeachingCourseIdList = TeachingCourseManager.getCourseIdByTeacherId(teacher.Id);

                List<int> properties = new List<int>();
                if (teacher.Settings == Teacher.TeacherSettings.TEACHES_45_MIN)
                {
                    properties.Add(1);
                }

                Object newTeacher = new {
                    branchId = 1,
                    id = teacher.Id,
                    firstname = this.removeApostrophe(teacher.Firstname),
                    lastname = this.removeApostrophe(teacher.Lastname),
                    nickname = this.removeApostrophe(teacher.Nickname),
                    birthDate = "",
                    registeredDate = "",
                    resignedDate = "",
                    status = status,
                    contacts = new {
                        phones = phones,
                        emails = emails
                    },
                    address = new {
                        buildingName = "",
                        streetAddress = "",
                        subDistrict = "",
                        district = "",
                        province = "",
                        zipCode = ""
                    },
                    teachingCourses = teacher.TeachingCourseIdList,
                    properties = properties
                };

                newTeacherList.Add(newTeacher);
            }

            string json = JsonConvert.SerializeObject(newTeacherList);
            System.IO.File.WriteAllText(PianoForte.Constant.Constant.STARTUP_PATH + "\\json\\teachers.json", json);
        }

        private void generateStudentJson()
        {
            List<Student> studentList = StudentManager.findAllStudent();
            List<Object> newStudentList = new List<Object>();
            int currentYear = 0;
            int count = 0;

            foreach (Student student in studentList)
            {
                if (currentYear != student.RegisteredDate.Year)
                {
                    currentYear = student.RegisteredDate.Year;
                    count = 0;
                }

                int registeredYear = (currentYear + 543) - 2500;
                int studentId = (registeredYear * 1000000) + 200000 + (1 * 1000) + (++count);

                int status = 0;
                if (student.Status == Student.StudentStatus.ACTIVE.ToString())
                {
                    status = 1;
                }
                else if (student.Status == Student.StudentStatus.INACTIVE.ToString())
                {
                    status = 2;
                }
                else if (student.Status == Student.StudentStatus.DROPPED.ToString())
                {
                    status = 3;
                }

                List<Object> phones = new List<Object>();
                List<Object> emails = new List<Object>();

                Object phone1 = null;
                if (student.Phone1 != "")
                {
                    string label = "เบอร์บ้าน";
                    string value = student.Phone1.Replace("-", "");

                    string phonePrefix = student.Phone1.Substring(0, 2);
                    if ((phonePrefix == "08") || (phonePrefix == "09"))
                    {
                        label = "เบอร์มือถือ";
                    }

                    phone1 = new
                    {
                        label = label,
                        value = value,
                        primary = false
                    };
                }

                Object phone2 = null;
                if (student.Phone2 != "")
                {
                    string label = "เบอร์บ้าน";
                    string value = student.Phone2.Replace("-", "");

                    string phonePrefix = student.Phone2.Substring(0, 2);
                    if ((phonePrefix == "08") || (phonePrefix == "09"))
                    {
                        label = "เบอร์มือถือ";
                    }

                    phone2 = new
                    {
                        label = label,
                        value = value,
                        primary = false
                    };
                }

                Object phone3 = null;
                if (student.Phone3 != "")
                {
                    string label = "เบอร์บ้าน";
                    string value = student.Phone3.Replace("-", "");

                    string phonePrefix = student.Phone3.Substring(0, 2);
                    if ((phonePrefix == "08") || (phonePrefix == "09"))
                    {
                        label = "เบอร์มือถือ";
                    }

                    phone3 = new
                    {
                        label = label,
                        value = value,
                        primary = false
                    };
                }

                if (phone1 != null)
                {
                    phones.Add(phone1);
                }

                if (phone2 != null)
                {
                    phones.Add(phone2);
                }

                if (phone3 != null)
                {
                    phones.Add(phone3);
                }

                Object email = null;
                if (student.Email != "")
                {
                    string label = "อีเมล์";
                    string value = student.Email;

                    email = new
                    {
                        label = label,
                        value = value,
                        primary = false
                    };
                }

                if (email != null)
                {
                    emails.Add(email);
                }

                Object newStudent = new
                {
                    branchId = 1,
                    id = studentId,
                    firstname = this.removeApostrophe(student.Firstname),
                    lastname = this.removeApostrophe(student.Lastname),
                    nickname = this.removeApostrophe(student.Nickname),
                    birthDate = student.Birthday.ToString("yyyy-MM-dd"),
                    registeredDate = student.RegisteredDate.ToString("yyyy-MM-dd"),
                    lastClassDate = "",
                    status = status,
                    contacts = new {
                        phones = phones,
                        emails = emails
                    },
                    address = new {
                        buildingName = student.Address.Address1,
                        streetAddress = student.Address.Address2,
                        subDistrict = "",
                        district = "",
                        province = "",
                        zipCode = student.Address.PostCode
                    },
                };

                newStudentList.Add(newStudent);
            }

            string json = JsonConvert.SerializeObject(newStudentList);
            System.IO.File.WriteAllText(PianoForte.Constant.Constant.STARTUP_PATH + "\\json\\students.json", json);
        }

        private void generateBookJson()
        {
            List<Book> bookList = BookManager.findAllBook();
            List<Object> newBookList = new List<Object>();

            foreach (Book book in bookList)
            {
                int status = 0;
                if (book.Status == Book.BookStatus.AVAILABLE.ToString())
                {
                    status = 5;
                }
                else if (book.Status == Book.BookStatus.EMPTY.ToString())
                {
                    status = 6;
                }
                else if (book.Status == Book.BookStatus.CANCELED.ToString())
                {
                    status = 7;
                }

                Object newBook = new
                {
                    branchId = 1,
                    id = book.Id,
                    barcode = book.Barcode,
                    name = book.Name,
                    price = book.Price,
                    quantity = book.Quantity,
                    status = status,
                    keywords = new List<String>(),
                    activityLog = new List<Object>()
                };

                newBookList.Add(newBook);
            }

            string json = JsonConvert.SerializeObject(newBookList);
            System.IO.File.WriteAllText(PianoForte.Constant.Constant.STARTUP_PATH + "\\json\\books.json", json);
        }

        private void generateCdJson()
        {
            List<Cd> cdList = CdManager.findAllCd();
            List<Object> newCdList = new List<Object>();

            foreach (Cd cd in cdList)
            {
                int status = 0;
                if (cd.Status == Cd.CdStatus.AVAILABLE.ToString())
                {
                    status = 5;
                }
                else if (cd.Status == Cd.CdStatus.EMPTY.ToString())
                {
                    status = 6;
                }
                else if (cd.Status == Cd.CdStatus.CANCELED.ToString())
                {
                    status = 7;
                }

                Object newCd = new
                {
                    branchId = 1,
                    id = cd.Id,
                    barcode = cd.Barcode,
                    name = cd.Name,
                    price = cd.Price,
                    quantity = cd.Quantity,
                    status = status,
                    keywords = new List<String>(),
                    activityLog = new List<Object>()
                };

                newCdList.Add(newCd);
            }

            string json = JsonConvert.SerializeObject(newCdList);
            System.IO.File.WriteAllText(PianoForte.Constant.Constant.STARTUP_PATH + "\\json\\cds.json", json);
        }

        private void generatCourseCategoryJson()
        {
            List<CourseCategory> courseCategoryList = CourseCategoryManager.findAllCourseCategory();
            List<Object> newCourseCategoryList = new List<Object>();

            foreach (CourseCategory courseCategory in courseCategoryList)
            {
                int status = 0;
                if (courseCategory.Status == CourseCategory.CourseCategoryStatus.ACTIVE.ToString())
                {
                    status = 1;
                }
                else if (courseCategory.Status == CourseCategory.CourseCategoryStatus.INACTIVE.ToString())
                {
                    status = 7;
                }

                Object newCourseCategory = new
                {
                    branchId = 1,
                    id = courseCategory.Id,
                    name = courseCategory.Name,
                    status = status
                };

                newCourseCategoryList.Add(newCourseCategory);
            }

            string json = JsonConvert.SerializeObject(newCourseCategoryList);
            System.IO.File.WriteAllText(PianoForte.Constant.Constant.STARTUP_PATH + "\\json\\course_categories.json", json);
        }

        private void generatCourseJson()
        {
            List<Course> courseList = CourseManager.findAllCourse();
            List<Object> newCourseList = new List<Object>();

            foreach (Course course in courseList)
            {
                int status = 0;
                if (course.Status == Course.CourseStatus.ACTIVE.ToString())
                {
                    status = 1;
                }
                else if (course.Status == Course.CourseStatus.INACTIVE.ToString())
                {
                    status = 7;
                }

                Object newCourse = new
                {
                    branchId = 1,
                    id = course.Id,
                    couseCategoryId = course.CourseCategoryId,
                    name = course.Name,
                    level = course.Level,
                    fee = course.Price,
                    classroom = new {
                        count = course.NumberOfClassroom,
                        minutes = course.ClassroomDuration,
                        students = course.StudentPerClassroom
                    },
                    status = status,
                    keywords = new List<String>(),
                    activityLog = new List<Object>()
                };

                newCourseList.Add(newCourse);
            }

            string json = JsonConvert.SerializeObject(newCourseList);
            System.IO.File.WriteAllText(PianoForte.Constant.Constant.STARTUP_PATH + "\\json\\course.json", json);
        }

        private void generateOtherItemJson()
        {
            List<OtherCost> otherCostList = OtherCostManager.findAllOtherCost();
            List<Object> newOtherItemList = new List<Object>();

            foreach (OtherCost otherItem in otherCostList)
            {
                Object newOtherCost = new
                {
                    branchId = 1,
                    id = otherItem.Id,
                    name = otherItem.Name,
                    price = otherItem.Price
                };

                newOtherItemList.Add(newOtherCost);
            }

            string json = JsonConvert.SerializeObject(newOtherItemList);
            System.IO.File.WriteAllText(PianoForte.Constant.Constant.STARTUP_PATH + "\\json\\other_items.json", json);
        }
    }
}
