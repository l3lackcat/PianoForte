using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;

using PianoForte.DatasetModel;
using PianoForte.Manager;
using PianoForte.Model;
using PianoForte.Report;
using CrystalDecisions.Shared;
using System.Drawing.Printing;

namespace PianoForte.Manager
{
    public class ReceiptManager
    {
        public static DataSet initReceiptReportTable(int paymentId)
        {
            DataSet dataSet = new DataSet();

            DataTable dataTablePayment = ReceiptManager.initDataTablePayment();
            DataTable dataTablePaymentDetail = ReceiptManager.initDataTablePaymentDetail();
            DataTable dataTableReceiptFooter = ReceiptManager.initDataTableReceiptFooter();
            DataTable dataTableStudent = ReceiptManager.initDataTableStudent();
            DataTable dataTableUser = ReceiptManager.initDataTableUser();

            Payment payment = PaymentManager.findPayment(paymentId);
            if (payment != null)
            {
                dataTablePayment = ReceiptManager.addDataToDataTablePayment(dataTablePayment, payment);
                dataTableStudent = ReceiptManager.addDataToDataTableStudent(dataTableStudent, payment.StudentId);
                dataTablePaymentDetail = ReceiptManager.addDataToDataTablePaymentDetail(dataTablePaymentDetail, paymentId);
                dataTableReceiptFooter = ReceiptManager.addDataToDataTableReceiptFooter(dataTableReceiptFooter, paymentId);
                dataTableUser = ReceiptManager.addDataToDataTableUser(dataTableUser, payment.ReceiverId);

                dataSet.Tables.Add(dataTablePayment);
                dataSet.Tables.Add(dataTablePaymentDetail);
                dataSet.Tables.Add(dataTableStudent);
                dataSet.Tables.Add(dataTableUser);
                if (dataTableReceiptFooter.Rows.Count > 0)
                {
                    dataSet.Tables.Add(dataTableReceiptFooter);
                }
            }

            return dataSet;
        }

        public static DataSet initReceiptReportTable(Payment payment)
        {
            DataSet dataSet = new DataSet();

            DataTable dataTablePayment = ReceiptManager.initDataTablePayment();
            DataTable dataTablePaymentDetail = ReceiptManager.initDataTablePaymentDetail();
            DataTable dataTableReceiptFooter = ReceiptManager.initDataTableReceiptFooter();
            DataTable dataTableStudent = ReceiptManager.initDataTableStudent();
            DataTable dataTableUser = ReceiptManager.initDataTableUser();

            if (payment != null)
            {
                dataTablePayment = ReceiptManager.addDataToDataTablePayment(dataTablePayment, payment);
                dataTableStudent = ReceiptManager.addDataToDataTableStudent(dataTableStudent, payment.StudentId);
                dataTablePaymentDetail = ReceiptManager.addDataToDataTablePaymentDetail(dataTablePaymentDetail, payment.Id);
                dataTableReceiptFooter = ReceiptManager.addDataToDataTableReceiptFooter(dataTableReceiptFooter, payment.Id);
                dataTableUser = ReceiptManager.addDataToDataTableUser(dataTableUser, payment.ReceiverId);

                dataSet.Tables.Add(dataTablePayment);
                dataSet.Tables.Add(dataTablePaymentDetail);
                dataSet.Tables.Add(dataTableStudent);
                dataSet.Tables.Add(dataTableUser);
                if (dataTableReceiptFooter.Rows.Count > 0)
                {
                    dataSet.Tables.Add(dataTableReceiptFooter);
                }
            }

            return dataSet;
        }

        private static DataTable initDataTablePayment()
        {
            DataTable dataTablePayment = new DataTable(Payment.tableName);
            dataTablePayment.Columns.Add(DataSetManager.createDataColumn(new DataColumn(), DataSetManager.DATA_TYPE_INT32, Payment.columnPaymentId));
            dataTablePayment.Columns.Add(DataSetManager.createDataColumn(new DataColumn(), DataSetManager.DATA_TYPE_STRING, Payment.columnPrintPaymentId));
            dataTablePayment.Columns.Add(DataSetManager.createDataColumn(new DataColumn(), DataSetManager.DATA_TYPE_INT32, Payment.columnStudentId));
            dataTablePayment.Columns.Add(DataSetManager.createDataColumn(new DataColumn(), DataSetManager.DATA_TYPE_INT32, Payment.columnReceiverId));
            dataTablePayment.Columns.Add(DataSetManager.createDataColumn(new DataColumn(), DataSetManager.DATA_TYPE_STRING, Payment.columnCreditCardNumber));
            dataTablePayment.Columns.Add(DataSetManager.createDataColumn(new DataColumn(), DataSetManager.DATA_TYPE_DOUBLE, Payment.columnTotalPrice));
            dataTablePayment.Columns.Add(DataSetManager.createDataColumn(new DataColumn(), DataSetManager.DATA_TYPE_STRING, Payment.columnTotalPriceText));
            dataTablePayment.Columns.Add(DataSetManager.createDataColumn(new DataColumn(), DataSetManager.DATA_TYPE_DATETIME, Payment.columnPaymentDate));
            dataTablePayment.Columns.Add(DataSetManager.createDataColumn(new DataColumn(), DataSetManager.DATA_TYPE_STRING, Payment.columnStatus));

            return dataTablePayment;
        }

        private static DataTable initDataTablePaymentDetail()
        {
            DataTable dataTablePaymentDetail = new DataTable(PaymentDetail.tableName);
            dataTablePaymentDetail.Columns.Add(DataSetManager.createDataColumn(new DataColumn(), DataSetManager.DATA_TYPE_INT32, PaymentDetail.columnPaymentDetailId));
            dataTablePaymentDetail.Columns.Add(DataSetManager.createDataColumn(new DataColumn(), DataSetManager.DATA_TYPE_INT32, PaymentDetail.columnPaymentId));
            dataTablePaymentDetail.Columns.Add(DataSetManager.createDataColumn(new DataColumn(), DataSetManager.DATA_TYPE_INT32, PaymentDetail.columnProductId));
            dataTablePaymentDetail.Columns.Add(DataSetManager.createDataColumn(new DataColumn(), DataSetManager.DATA_TYPE_STRING, PaymentDetail.columnProductType));
            dataTablePaymentDetail.Columns.Add(DataSetManager.createDataColumn(new DataColumn(), DataSetManager.DATA_TYPE_STRING, PaymentDetail.columnProductName));
            dataTablePaymentDetail.Columns.Add(DataSetManager.createDataColumn(new DataColumn(), DataSetManager.DATA_TYPE_INT32, PaymentDetail.columnAmount));
            dataTablePaymentDetail.Columns.Add(DataSetManager.createDataColumn(new DataColumn(), DataSetManager.DATA_TYPE_DOUBLE, PaymentDetail.columnDiscount));
            dataTablePaymentDetail.Columns.Add(DataSetManager.createDataColumn(new DataColumn(), DataSetManager.DATA_TYPE_DOUBLE, PaymentDetail.columnProductPrice));

            return dataTablePaymentDetail;
        }

        private static DataTable initDataTableReceiptFooter()
        {
            DataTable dataTableReceiptFooter = new DataTable("receipt_footer");
            dataTableReceiptFooter.Columns.Add(DataSetManager.createDataColumn(new DataColumn(), DataSetManager.DATA_TYPE_INT32, "paymentId"));
            dataTableReceiptFooter.Columns.Add(DataSetManager.createDataColumn(new DataColumn(), DataSetManager.DATA_TYPE_STRING, "courseName"));
            dataTableReceiptFooter.Columns.Add(DataSetManager.createDataColumn(new DataColumn(), DataSetManager.DATA_TYPE_STRING, "courseLevel"));
            dataTableReceiptFooter.Columns.Add(DataSetManager.createDataColumn(new DataColumn(), DataSetManager.DATA_TYPE_STRING, "classDayOfWeek1"));
            dataTableReceiptFooter.Columns.Add(DataSetManager.createDataColumn(new DataColumn(), DataSetManager.DATA_TYPE_STRING, "classTime1"));
            dataTableReceiptFooter.Columns.Add(DataSetManager.createDataColumn(new DataColumn(), DataSetManager.DATA_TYPE_STRING, "teacherName1"));
            dataTableReceiptFooter.Columns.Add(DataSetManager.createDataColumn(new DataColumn(), DataSetManager.DATA_TYPE_STRING, "classDayOfWeek2"));
            dataTableReceiptFooter.Columns.Add(DataSetManager.createDataColumn(new DataColumn(), DataSetManager.DATA_TYPE_STRING, "classTime2"));
            dataTableReceiptFooter.Columns.Add(DataSetManager.createDataColumn(new DataColumn(), DataSetManager.DATA_TYPE_STRING, "teacherName2"));
            dataTableReceiptFooter.Columns.Add(DataSetManager.createDataColumn(new DataColumn(), DataSetManager.DATA_TYPE_DATETIME, "date01"));
            dataTableReceiptFooter.Columns.Add(DataSetManager.createDataColumn(new DataColumn(), DataSetManager.DATA_TYPE_DATETIME, "date02"));
            dataTableReceiptFooter.Columns.Add(DataSetManager.createDataColumn(new DataColumn(), DataSetManager.DATA_TYPE_DATETIME, "date03"));
            dataTableReceiptFooter.Columns.Add(DataSetManager.createDataColumn(new DataColumn(), DataSetManager.DATA_TYPE_DATETIME, "date04"));
            dataTableReceiptFooter.Columns.Add(DataSetManager.createDataColumn(new DataColumn(), DataSetManager.DATA_TYPE_DATETIME, "date05"));
            dataTableReceiptFooter.Columns.Add(DataSetManager.createDataColumn(new DataColumn(), DataSetManager.DATA_TYPE_DATETIME, "date06"));
            dataTableReceiptFooter.Columns.Add(DataSetManager.createDataColumn(new DataColumn(), DataSetManager.DATA_TYPE_DATETIME, "date07"));
            dataTableReceiptFooter.Columns.Add(DataSetManager.createDataColumn(new DataColumn(), DataSetManager.DATA_TYPE_DATETIME, "date08"));
            dataTableReceiptFooter.Columns.Add(DataSetManager.createDataColumn(new DataColumn(), DataSetManager.DATA_TYPE_DATETIME, "date09"));
            dataTableReceiptFooter.Columns.Add(DataSetManager.createDataColumn(new DataColumn(), DataSetManager.DATA_TYPE_DATETIME, "date10"));
            dataTableReceiptFooter.Columns.Add(DataSetManager.createDataColumn(new DataColumn(), DataSetManager.DATA_TYPE_DATETIME, "date11"));
            dataTableReceiptFooter.Columns.Add(DataSetManager.createDataColumn(new DataColumn(), DataSetManager.DATA_TYPE_DATETIME, "date12"));

            return dataTableReceiptFooter;
        }

        private static DataTable initDataTableStudent()
        {
            DataTable dataTableStudent = new DataTable(Student.tableName);
            dataTableStudent.Columns.Add(DataSetManager.createDataColumn(new DataColumn(), DataSetManager.DATA_TYPE_INT32, Student.columnStudentId));
            dataTableStudent.Columns.Add(DataSetManager.createDataColumn(new DataColumn(), DataSetManager.DATA_TYPE_STRING, Student.columnFirstname));
            dataTableStudent.Columns.Add(DataSetManager.createDataColumn(new DataColumn(), DataSetManager.DATA_TYPE_STRING, Student.columnLastname));
            dataTableStudent.Columns.Add(DataSetManager.createDataColumn(new DataColumn(), DataSetManager.DATA_TYPE_STRING, Student.columnNickname));
            dataTableStudent.Columns.Add(DataSetManager.createDataColumn(new DataColumn(), DataSetManager.DATA_TYPE_STRING, Student.columnPhone1));
            dataTableStudent.Columns.Add(DataSetManager.createDataColumn(new DataColumn(), DataSetManager.DATA_TYPE_STRING, Student.columnPhone2));
            dataTableStudent.Columns.Add(DataSetManager.createDataColumn(new DataColumn(), DataSetManager.DATA_TYPE_STRING, Student.columnPhone3));
            dataTableStudent.Columns.Add(DataSetManager.createDataColumn(new DataColumn(), DataSetManager.DATA_TYPE_DATETIME, Student.columnBirthday));
            dataTableStudent.Columns.Add(DataSetManager.createDataColumn(new DataColumn(), DataSetManager.DATA_TYPE_STRING, Student.columnAddress1));
            dataTableStudent.Columns.Add(DataSetManager.createDataColumn(new DataColumn(), DataSetManager.DATA_TYPE_STRING, Student.columnAddress2));
            dataTableStudent.Columns.Add(DataSetManager.createDataColumn(new DataColumn(), DataSetManager.DATA_TYPE_STRING, Student.columnPostCode));
            dataTableStudent.Columns.Add(DataSetManager.createDataColumn(new DataColumn(), DataSetManager.DATA_TYPE_STRING, Student.columnEmail));
            dataTableStudent.Columns.Add(DataSetManager.createDataColumn(new DataColumn(), DataSetManager.DATA_TYPE_DATETIME, Student.columnRegisterDate));
            dataTableStudent.Columns.Add(DataSetManager.createDataColumn(new DataColumn(), DataSetManager.DATA_TYPE_STRING, Student.columnStatus));

            return dataTableStudent;
        }

        private static DataTable initDataTableUser()
        {
            DataTable dataTableUser = new DataTable(User.tableName);
            dataTableUser.Columns.Add(DataSetManager.createDataColumn(new DataColumn(), DataSetManager.DATA_TYPE_INT32, User.columnUser_id));
            dataTableUser.Columns.Add(DataSetManager.createDataColumn(new DataColumn(), DataSetManager.DATA_TYPE_STRING, User.columnUser_username));
            dataTableUser.Columns.Add(DataSetManager.createDataColumn(new DataColumn(), DataSetManager.DATA_TYPE_STRING, User.columnUser_password));
            dataTableUser.Columns.Add(DataSetManager.createDataColumn(new DataColumn(), DataSetManager.DATA_TYPE_INT32, User.columnUser_role));
            dataTableUser.Columns.Add(DataSetManager.createDataColumn(new DataColumn(), DataSetManager.DATA_TYPE_STRING, User.columnUser_displayName));

            return dataTableUser;
        }

        private static DataTable addDataToDataTablePayment(DataTable dataTablePayment, Payment payment)
        {
            string printPaymentId = payment.Id.ToString();
            if (payment.PrintPaymentId > 0)
            {
                printPaymentId = payment.PrintPaymentId.ToString();
            }

            dataTablePayment.Rows.Add(payment.Id,
                                      printPaymentId,
                                      payment.StudentId,
                                      payment.ReceiverId,
                                      payment.CreditCardNumber,
                                      payment.TotalPrice,
                                      payment.TotalPriceText,
                                      payment.PaymentDate,
                                      payment.Status);

            return dataTablePayment;
        }

        private static DataTable addDataToDataTablePaymentDetail(DataTable dataTablePaymentDetail, int paymentId)
        {
            List<PaymentDetail> paymentDetailList = PaymentDetailManager.findAllPaymentDetail(paymentId);
            for (int i = 0; i < paymentDetailList.Count; i++)
            {
                dataTablePaymentDetail.Rows.Add(paymentDetailList[i].Id,
                                                paymentDetailList[i].PaymentId,
                                                paymentDetailList[i].Product.Id,
                                                paymentDetailList[i].Product.Type,
                                                paymentDetailList[i].Product.Name,
                                                paymentDetailList[i].Quantity,
                                                paymentDetailList[i].Discount,
                                                paymentDetailList[i].Product.Price);
            }

            return dataTablePaymentDetail;
        }

        private static DataTable addDataToDataTableReceiptFooter(DataTable dataTableReceiptFooter, int paymentId)
        {
            List<Enrollment> enrollmentList = EnrollmentManager.findAllEnrollmentByPaymentId(paymentId);
            for (int i = 0; i < enrollmentList.Count; i++)
            {
                Enrollment enrollment = enrollmentList[i];
                if (enrollment != null)
                {
                    if (enrollment.Course != null)
                    {
                        ReceiptFooter receiptFooter = new ReceiptFooter();
                        receiptFooter.PaymentId = paymentId;
                        receiptFooter.CourseName = enrollment.Course.Name;
                        receiptFooter.CourseLevel = enrollment.Course.Level;
                        //List<Classroom> classroomList = ClassroomManager.getAllClassroom(enrollment.Id);
                        if (enrollment.ClassroomList.Count > 0)
                        {
                            receiptFooter.ClassDayOfWeek1 = enrollment.ClassroomList[0].ClassDayOfWeek;
                            receiptFooter.ClassTime1 = enrollment.ClassroomList[0].ClassTime;
                            Teacher teacher1 = TeacherManager.findTeacher(enrollment.ClassroomList[0].TeacherId);
                            if (teacher1 != null)
                            {
                                receiptFooter.TeacherName1 = teacher1.Firstname + " " +
                                                             teacher1.Lastname + "(" +
                                                             teacher1.Nickname + ")";
                            }

                            if (enrollment.ClassroomList.Count == 2)
                            {
                                receiptFooter.ClassDayOfWeek2 = enrollment.ClassroomList[1].ClassDayOfWeek;
                                receiptFooter.ClassTime2 = enrollment.ClassroomList[1].ClassTime;
                                if (enrollment.ClassroomList[0].TeacherId == enrollment.ClassroomList[1].TeacherId)
                                {
                                    receiptFooter.TeacherName2 = receiptFooter.TeacherName1;
                                }
                                else
                                {
                                    Teacher teacher2 = TeacherManager.findTeacher(enrollment.ClassroomList[1].TeacherId);
                                    if (teacher2 != null)
                                    {
                                        receiptFooter.TeacherName2 = teacher2.Firstname + " " +
                                                                     teacher2.Lastname + "(" +
                                                                     teacher2.Nickname + ")";
                                    }
                                }
                            }

                            foreach (var pair in enrollment.ClassroomIdClassroomDetailListDictionary)
                            {
                                for (int j = 0; j < pair.Value.Count; j++)
                                {
                                    receiptFooter.ClassroomDateList.Add(pair.Value[j].ClassroomDate);
                                }
                            }

                            receiptFooter.ClassroomDateList = DateTimeManager.sortDate(receiptFooter.ClassroomDateList);
                        }

                        Object[] receiptFooterObjectArray = new Object[21];
                        receiptFooterObjectArray[0] = receiptFooter.PaymentId;
                        receiptFooterObjectArray[1] = receiptFooter.CourseName;
                        receiptFooterObjectArray[2] = receiptFooter.CourseLevel;
                        receiptFooterObjectArray[3] = receiptFooter.ClassDayOfWeek1;
                        receiptFooterObjectArray[4] = receiptFooter.ClassTime1;
                        receiptFooterObjectArray[5] = receiptFooter.TeacherName1;
                        receiptFooterObjectArray[6] = receiptFooter.ClassDayOfWeek2;
                        receiptFooterObjectArray[7] = receiptFooter.ClassTime2;
                        receiptFooterObjectArray[8] = receiptFooter.TeacherName2;

                        for (int j = 0; j < receiptFooter.ClassroomDateList.Count; j++)
                        {
                            receiptFooterObjectArray[9 + j] = receiptFooter.ClassroomDateList[j];
                        }

                        dataTableReceiptFooter.Rows.Add(receiptFooterObjectArray);
                    }
                }
            }            

            return dataTableReceiptFooter;
        }

        private static DataTable addDataToDataTableStudent(DataTable dataTableStudent, int studentId)
        {
            Student student = StudentManager.findStudent(studentId);
            if (student != null)
            {
                dataTableStudent.Rows.Add(student.Id,
                                          student.Firstname,
                                          student.Lastname,
                                          student.Nickname,
                                          student.Phone1,
                                          student.Phone2,
                                          student.Phone3,
                                          student.Birthday,
                                          student.Address.Address1,
                                          student.Address.Address2,
                                          student.Address.PostCode,
                                          student.Email,
                                          student.RegisteredDate,
                                          student.Status);
            }            

            return dataTableStudent;
        }

        private static DataTable addDataToDataTableUser(DataTable dataTableUser, int userId)
        {
            User user = UserManager.findUser(userId);
            if (user != null)
            {
                dataTableUser.Rows.Add(user.Id,
                                       user.Username,
                                       user.Password,
                                       user.Role,
                                       user.DisplayName);
            }

            return dataTableUser;
        }

        public static bool printReceipt(int paymentId)
        {
            bool isPrintSuccess = false;

            try
            {
                DataSet dataSet = ReceiptManager.initReceiptReportTable(paymentId);

                ReceiptPrint receiptPrint = new ReceiptPrint();
                receiptPrint.Database.Tables[Payment.tableName].SetDataSource(dataSet.Tables[Payment.tableName]);
                receiptPrint.Database.Tables[PaymentDetail.tableName].SetDataSource(dataSet.Tables[PaymentDetail.tableName]);
                receiptPrint.Database.Tables[Student.tableName].SetDataSource(dataSet.Tables[Student.tableName]);
                receiptPrint.Database.Tables[User.tableName].SetDataSource(dataSet.Tables[User.tableName]);
                if (dataSet.Tables.Count > 4)
                {
                    if (dataSet.Tables[ReceiptFooter.tableName].Rows.Count > 0)
                    {
                        receiptPrint.Database.Tables[ReceiptFooter.tableName].SetDataSource(dataSet.Tables[ReceiptFooter.tableName]);
                    }
                }

                foreach (String printer in PrinterSettings.InstalledPrinters)
                {                    
                    string printerName = printer.ToLower();
                    LogManager.writeLog("Checking " + printerName);
                    if ((printerName == Constant.Constant.RECEIPT_PRINTER_LOCAL) ||
                        (printerName == Constant.Constant.RECEIPT_PRINTER_NETWORK1) ||
                        (printerName == Constant.Constant.RECEIPT_PRINTER_NETWORK2))
                    {
                        LogManager.writeLog(printerName + " is found");
                        if (PrinterManager.isPrinterOnline(printer))
                        {
                            LogManager.writeLog(printerName + " is connected");
                            receiptPrint.PrintOptions.PrinterName = printerName;
                            receiptPrint.PrintToPrinter(1, false, 0, 0);
                            isPrintSuccess = true;
                            break;
                        }                        
                    }
                }                
            }
            catch (System.Exception exception)
            {
                LogManager.writeLog(exception.Message);
                isPrintSuccess = false;
            }

            return isPrintSuccess;
        }

        public static bool printReceipt(Payment payment)
        {
            bool isPrintSuccess = false;

            try
            {
                DataSet dataSet = ReceiptManager.initReceiptReportTable(payment);

                ReceiptPrint receiptPrint = new ReceiptPrint();
                receiptPrint.Database.Tables[Payment.tableName].SetDataSource(dataSet.Tables[Payment.tableName]);
                receiptPrint.Database.Tables[PaymentDetail.tableName].SetDataSource(dataSet.Tables[PaymentDetail.tableName]);
                receiptPrint.Database.Tables[Student.tableName].SetDataSource(dataSet.Tables[Student.tableName]);
                receiptPrint.Database.Tables[User.tableName].SetDataSource(dataSet.Tables[User.tableName]);
                if (dataSet.Tables.Count > 4)
                {
                    if (dataSet.Tables[ReceiptFooter.tableName].Rows.Count > 0)
                    {
                        receiptPrint.Database.Tables[ReceiptFooter.tableName].SetDataSource(dataSet.Tables[ReceiptFooter.tableName]);
                    }
                }

                foreach (String printer in PrinterSettings.InstalledPrinters)
                {
                    string printerName = printer.ToLower();
                    if ((printerName == Constant.Constant.RECEIPT_PRINTER_LOCAL) ||
                        (printerName == Constant.Constant.RECEIPT_PRINTER_NETWORK1) ||
                        (printerName == Constant.Constant.RECEIPT_PRINTER_NETWORK2))
                    {
                        if (PrinterManager.isPrinterOnline(printer))
                        {
                            receiptPrint.PrintOptions.PrinterName = printerName;
                            receiptPrint.PrintToPrinter(1, false, 0, 0);
                            isPrintSuccess = true;
                            break;
                        }
                    }
                }                 
            }
            catch (System.Exception exception)
            {
                LogManager.writeLog(exception.Message);
                isPrintSuccess = false;
            }

            return isPrintSuccess;
        }
    }
}
