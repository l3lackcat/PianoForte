using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO;

using MySql.Data.MySqlClient;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

using PianoForte.Constant;
using PianoForte.Interface;
using PianoForte.Manager;
using PianoForte.Model;
using PianoForte.Report;

namespace PianoForte.View
{
    public partial class DailyPaymentReportForm : Form, FormInterface
    {
        private MainForm mainForm;

        public DailyPaymentReportForm()
        {
            InitializeComponent();
        }

        private void DailyPaymentReportForm_Load(object sender, EventArgs e)
        {
            //Do Nothing
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
            this.DateTimePicker_Daily_Income_Date.Value = DateTime.Today;
        }

        public void loadUnpaidPayments()
        {
            List<Payment> unpaidPaymentList = PaymentManager.findAllPayment(Payment.PaymentStatus.NOT_PAID);
            int numberOfUnpaidPayment = unpaidPaymentList.Count;

            if (numberOfUnpaidPayment > 0)
            {
                this.DataGridView_UnpaidPaymentInfo.Rows.Clear();

                for (int i = 0; i < numberOfUnpaidPayment; i++)
                {
                    Student student = StudentManager.findStudent(unpaidPaymentList[i].StudentId);
                    User receiver = UserManager.findUser(unpaidPaymentList[i].ReceiverId);

                    if ((student != null) && (receiver != null))
                    {
                        string studentName = student.Firstname + " " + student.Lastname + " (" + student.Nickname + ")";
                        int n = this.DataGridView_UnpaidPaymentInfo.Rows.Add();

                        this.DataGridView_UnpaidPaymentInfo.Rows[n].Cells["PaymentId"].Value = unpaidPaymentList[i].Id;
                        this.DataGridView_UnpaidPaymentInfo.Rows[n].Cells["StudentName"].Value = studentName;
                        this.DataGridView_UnpaidPaymentInfo.Rows[n].Cells["TransactionDate"].Value = unpaidPaymentList[i].PaymentDate;
                        this.DataGridView_UnpaidPaymentInfo.Rows[n].Cells["TotalPrice"].Value = unpaidPaymentList[i].TotalPrice;
                        this.DataGridView_UnpaidPaymentInfo.Rows[n].Cells["ReceiverName"].Value = receiver.DisplayName;
                    }
                }

                this.DataGridView_UnpaidPaymentInfo.ClearSelection();
            }
        }

        public void init(int userRole)
        {
            if (userRole == (int)User.UserRole.ADMIN)
            {
                this.tabControl1.TabPages[1].Enabled = true;
            }
            else
            {
                this.tabControl1.TabPages[2].Enabled = false;
            }
        }

        private void init(DateTime date)
        {
            DataColumn dataColumnDailyIncomeId = new DataColumn();
            dataColumnDailyIncomeId.DataType = System.Type.GetType("System.Int32");
            dataColumnDailyIncomeId.ColumnName = DailyIncome.columnDailyIncomeId;

            DataColumn dataColumnDailyIncomeDate = new DataColumn();
            dataColumnDailyIncomeDate.DataType = System.Type.GetType("System.DateTime");
            dataColumnDailyIncomeDate.ColumnName = DailyIncome.columnDailyIncomeDate;

            DataColumn dataColumnTotalCoursePrice = new DataColumn();
            dataColumnTotalCoursePrice.DataType = System.Type.GetType("System.Double");
            dataColumnTotalCoursePrice.ColumnName = DailyIncome.columnTotalCoursePrice;

            DataColumn dataColumnTotalBookPrice = new DataColumn();
            dataColumnTotalBookPrice.DataType = System.Type.GetType("System.Double");
            dataColumnTotalBookPrice.ColumnName = DailyIncome.columnTotalBookPrice;

            DataColumn dataColumnTotalAssignmentBookPrice = new DataColumn();
            dataColumnTotalAssignmentBookPrice.DataType = System.Type.GetType("System.Double");
            dataColumnTotalAssignmentBookPrice.ColumnName = DailyIncome.columnTotalAssignmentBookPrice;

            DataColumn dataColumnTotalFirstRegister = new DataColumn();
            dataColumnTotalFirstRegister.DataType = System.Type.GetType("System.Double");
            dataColumnTotalFirstRegister.ColumnName = DailyIncome.columnTotalFirstRegister;

            DataColumn dataColumnTotalCdPrice = new DataColumn();
            dataColumnTotalCdPrice.DataType = System.Type.GetType("System.Double");
            dataColumnTotalCdPrice.ColumnName = DailyIncome.columnTotalCdPrice;

            DataColumn dataColumnTotalOtherPrice = new DataColumn();
            dataColumnTotalOtherPrice.DataType = System.Type.GetType("System.Double");
            dataColumnTotalOtherPrice.ColumnName = DailyIncome.columnTotalOtherPrice;

            DataColumn dataColumnTotalCash = new DataColumn();
            dataColumnTotalCash.DataType = System.Type.GetType("System.Double");
            dataColumnTotalCash.ColumnName = DailyIncome.columnTotalCash;

            DataColumn dataColumnTotalCreditcard = new DataColumn();
            dataColumnTotalCreditcard.DataType = System.Type.GetType("System.Double");
            dataColumnTotalCreditcard.ColumnName = DailyIncome.columnTotalCreditcard;

            DataTable dataTable = new DataTable(DailyIncome.tableName);
            dataTable.Columns.Add(dataColumnDailyIncomeId);
            dataTable.Columns.Add(dataColumnDailyIncomeDate);
            dataTable.Columns.Add(dataColumnTotalCoursePrice);
            dataTable.Columns.Add(dataColumnTotalBookPrice);
            dataTable.Columns.Add(dataColumnTotalAssignmentBookPrice);
            dataTable.Columns.Add(dataColumnTotalFirstRegister); 
            dataTable.Columns.Add(dataColumnTotalCdPrice);                       
            dataTable.Columns.Add(dataColumnTotalOtherPrice);
            dataTable.Columns.Add(dataColumnTotalCash);
            dataTable.Columns.Add(dataColumnTotalCreditcard);

            User tempUser = this.mainForm.getUser();
            if (tempUser != null)
            {
                //List<Payment> tempPaymentList = PaymentManager.findAllPayment(Payment.PaymentStatus.PAID.ToString(), date, date);
                List<Payment> tempPaymentList = PaymentManager.findAllPaymentByDate(date, date, Payment.PaymentStatus.PAID);

                double totalCoursePrice = 0;
                double totalAssignmentBookPrice = 0;
                double totalBookPrice = 0;
                double totalCdPrice = 0;
                double totalFirstRegisterPrice = 0;
                double totalOtherPrice = 0;
                double totalCash = 0;
                double totalCreditCard = 0;

                for (int i = 0; i < tempPaymentList.Count; i++)
                {
                    Payment tempPayment = tempPaymentList[i];
                    if (tempPayment != null)
                    {
                        if (tempPayment.CreditCardNumber == "")
                        {
                            totalCash += tempPayment.TotalPrice;
                        }
                        else
                        {
                            totalCreditCard += tempPayment.TotalPrice;
                        }

                        List<PaymentDetail> tempPaymentDetailList = PaymentDetailManager.findAllPaymentDetail(tempPayment.Id);
                        for (int j = 0; j < tempPaymentDetailList.Count; j++)
                        {
                            PaymentDetail tempPaymentDetail = tempPaymentDetailList[j];
                            if (tempPaymentDetail != null)
                            {
                                string productType = tempPaymentDetail.Product.Type;
                                if (productType == Product.ProductType.COURSE.ToString())
                                {
                                    totalCoursePrice += ((tempPaymentDetail.Product.Price * tempPaymentDetail.Quantity) - tempPaymentDetail.Discount);
                                }
                                else if (productType == Product.ProductType.BOOK.ToString())
                                {
                                    if (tempPaymentDetail.Product.Id == 2000001)
                                    {
                                        totalAssignmentBookPrice += (tempPaymentDetail.Product.Price * tempPaymentDetail.Quantity);
                                    }
                                    else
                                    {
                                        totalBookPrice += (tempPaymentDetail.Product.Price * tempPaymentDetail.Quantity);
                                    }
                                }
                                else if (productType == Product.ProductType.CD.ToString())
                                {
                                    totalCdPrice += (tempPaymentDetail.Product.Price * tempPaymentDetail.Quantity);
                                }
                                else if (productType == Product.ProductType.OTHER.ToString())
                                {
                                    if (tempPaymentDetail.Product.Id == 4000001)
                                    {
                                        totalFirstRegisterPrice += (tempPaymentDetail.Product.Price * tempPaymentDetail.Quantity);
                                    }
                                    else
                                    {
                                        totalOtherPrice += (tempPaymentDetail.Product.Price * tempPaymentDetail.Quantity);
                                    }
                                }
                            }
                        }
                    }
                }

                dataTable.Rows.Add(0,
                                   date,
                                   totalCoursePrice,
                                   totalBookPrice,
                                   totalAssignmentBookPrice,
                                   totalFirstRegisterPrice,
                                   totalCdPrice,
                                   totalOtherPrice,
                                   totalCash,
                                   totalCreditCard);

                DataSet dataSet = new DataSet(DailyIncome.tableName);
                dataSet.Tables.Add(dataTable);

                DailyIncomeReport dailyIncomeReport = new DailyIncomeReport();
                dailyIncomeReport.SetDataSource(dataSet);

                CrystalReportViewer_DailyIncome.ReportSource = dailyIncomeReport;
            }            
        }

        private void Button_Generate_Course_Income_Click(object sender, EventArgs e)
        {
            string filename = InputDialogBox.show("กรุณาตั้งชื่อไฟล์");
            if (filename != "")
            {
                courseIncomeSummary.RunWorkerAsync(filename);
                ProgressBarManager.showProgressBar(true);
            }            
        }

        private void Button_Generate_Monthly_Income_Click(object sender, EventArgs e)
        {
            string filename = InputDialogBox.show("กรุณาตั้งชื่อไฟล์");
            if (filename != "")
            {
                monthlyIncomeSummary.RunWorkerAsync(filename);
                ProgressBarManager.showProgressBar(true);
            }            
        }

        private void Button_Search_Daily_Income_Click(object sender, EventArgs e)
        {
            this.init(this.DateTimePicker_Daily_Income_Date.Value);
        }

        private void Button_Generate_Total_Income_Click(object sender, EventArgs e)
        {
            string filename = InputDialogBox.show("กรุณาตั้งชื่อไฟล์");
            if (filename != "")
            {                
                totalIncomeSummary.RunWorkerAsync(filename);
                ProgressBarManager.showProgressBar(true);
            }            
        }        

        private void monthlyIncomeSummary_DoWork(object sender, DoWorkEventArgs e)
        {
            DateTime startDate = this.DateTimePicker2_StartDate.Value;
            DateTime endDate = this.DateTimePicker2_EndDate.Value;
            //List<Payment> paymentList = PaymentManager.findAllPayment(Payment.PaymentStatus.PAID.ToString(), startDate, endDate);
            monthlyIncomeSummary.ReportProgress(0, ProgressBarManager.ProgressBarState.QUERY);
            List<Payment> paymentList = PaymentManager.findAllPaymentByDate(startDate, endDate, Payment.PaymentStatus.PAID);

            ExportManager exportManager = new ExportManager();
            if (exportManager.createMonthlyIncomeSummary(e.Argument as string, paymentList))
            {
                monthlyIncomeSummary.ReportProgress(100, ProgressBarManager.ProgressBarState.CREATE_FILE);
                MessageBox.Show("สร้างไฟล์เรียบร้อยแล้ว");
            }
        }

        private void monthlyIncomeSummary_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            ProgressBarManager.ProgressBarState progressBarState = (ProgressBarManager.ProgressBarState)e.UserState;
            ProgressBarManager.updateProgressBar(e.ProgressPercentage, progressBarState); 
        }

        private void monthlyIncomeSummary_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {            
            ProgressBarManager.showProgressBar(false);
        }

        private void courseIncomeSummary_DoWork(object sender, DoWorkEventArgs e)
        {
            DateTime startDate = this.DateTimePicker1_StartDate.Value;
            DateTime endDate = this.DateTimePicker1_EndDate.Value;
            //List<Enrollment> enrollmentList = EnrollmentManager.getAllPaidEnrollment(startDate, endDate);
            courseIncomeSummary.ReportProgress(0, ProgressBarManager.ProgressBarState.QUERY);
            List<Enrollment> enrollmentList = EnrollmentManager.findAllEnrollmentByDate(startDate, endDate, Enrollment.EnrollmentStatus.PAID);

            ExportManager exportManager = new ExportManager();
            if (exportManager.createCourseIncomeSummary(e.Argument as string, enrollmentList))
            {
                courseIncomeSummary.ReportProgress(100, ProgressBarManager.ProgressBarState.CREATE_FILE);
                MessageBox.Show("สร้างไฟล์เรียบร้อยแล้ว");
            }
        }

        private void courseIncomeSummary_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            ProgressBarManager.ProgressBarState progressBarState = (ProgressBarManager.ProgressBarState)e.UserState;
            ProgressBarManager.updateProgressBar(e.ProgressPercentage, progressBarState); 
        }

        private void courseIncomeSummary_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ProgressBarManager.showProgressBar(false);
        } 

        private void totalIncomeSummary_DoWork(object sender, DoWorkEventArgs e)
        {
            DateTime startDate = this.DateTimePicker3_StartDate.Value;
            DateTime endDate = this.DateTimePicker3_EndDate.Value;
            //List<Payment> paymentList = PaymentManager.findAllPayment(Payment.PaymentStatus.PAID.ToString(), startDate, endDate);
            totalIncomeSummary.ReportProgress(0, ProgressBarManager.ProgressBarState.QUERY);
            List<Payment> paymentList = PaymentManager.findAllPaymentByDate(startDate, endDate, Payment.PaymentStatus.PAID);

            ExportManager exportManager = new ExportManager();
            if (exportManager.createTotalIncomeSummary(e.Argument as string, paymentList))
            {
                totalIncomeSummary.ReportProgress(100, ProgressBarManager.ProgressBarState.CREATE_FILE);
                MessageBox.Show("สร้างไฟล์เรียบร้อยแล้ว");
            }
        }

        private void totalIncomeSummary_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            ProgressBarManager.ProgressBarState progressBarState = (ProgressBarManager.ProgressBarState)e.UserState;
            ProgressBarManager.updateProgressBar(e.ProgressPercentage, progressBarState);                       
        }

        private void totalIncomeSummary_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ProgressBarManager.showProgressBar(false);
        }

        private void button_Export_UnpaidPayment_Excel_Click(object sender, EventArgs e)
        {
            string filename = InputDialogBox.show("กรุณาตั้งชื่อไฟล์");
            if (filename != "")
            {
                unpaidPaymentSummary.RunWorkerAsync(filename);
                ProgressBarManager.showProgressBar(true);
            }
        }

        private void unpaidPaymentSummary_DoWork(object sender, DoWorkEventArgs e)
        {
            List<DisplayPayment> unpaidPaymentList = new List<DisplayPayment>();
            int numberOfRow = this.DataGridView_UnpaidPaymentInfo.Rows.Count;

            for (int i = 0; i < numberOfRow; i++)
            {
                DisplayPayment displayPayment = new DisplayPayment();

                displayPayment.Id = Convert.ToInt32(this.DataGridView_UnpaidPaymentInfo.Rows[i].Cells["PaymentId"].Value.ToString());
                displayPayment.StudentName = this.DataGridView_UnpaidPaymentInfo.Rows[i].Cells["StudentName"].Value.ToString();
                displayPayment.PaymentDate = Convert.ToDateTime(this.DataGridView_UnpaidPaymentInfo.Rows[i].Cells["TransactionDate"].Value.ToString());
                displayPayment.TotalPrice = Convert.ToDouble(this.DataGridView_UnpaidPaymentInfo.Rows[i].Cells["TotalPrice"].Value.ToString());
                displayPayment.ReceiverName = this.DataGridView_UnpaidPaymentInfo.Rows[i].Cells["ReceiverName"].Value.ToString();

                unpaidPaymentList.Add(displayPayment);
            }

            if (unpaidPaymentList.Count > 0)
            {
                ExportManager exportManager = new ExportManager();
                if (exportManager.createUnpaidPaymentSummary(e.Argument as string, unpaidPaymentList))
                {
                    unpaidPaymentSummary.ReportProgress(100, ProgressBarManager.ProgressBarState.CREATE_FILE);
                    MessageBox.Show("สร้างไฟล์เรียบร้อยแล้ว");
                }
            }
        }

        private void unpaidPaymentSummary_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            ProgressBarManager.ProgressBarState progressBarState = (ProgressBarManager.ProgressBarState)e.UserState;
            ProgressBarManager.updateProgressBar(e.ProgressPercentage, progressBarState); 
        }

        private void unpaidPaymentSummary_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ProgressBarManager.showProgressBar(false);
        }                  
    }
}
