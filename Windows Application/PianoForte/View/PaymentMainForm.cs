using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using PianoForte.Constant;
using PianoForte.Interface;
using PianoForte.Manager;
using PianoForte.Model;
using System.IO;
using System.Text.RegularExpressions;

namespace PianoForte.View
{
    public partial class PaymentMainForm : Form, FormInterface
    {
        private enum SearchType
        {
            ALL,
            PAYMENT_ID,
            INFO
        };

        private MainForm mainForm;        
        private List<DisplayPayment> paymentList1;
        private List<DisplayPayment> paymentList2;                
        private readonly BackgroundWorker backgroundWorker = new BackgroundWorker();

        private SearchType searchType;
        private int paymentId = -1;
        private int studentId = -1;
        private String creditCardNumber = "";
        private bool isEnableStartDate = false;
        private DateTime startDate = DateTime.Today;
        private DateTime endDate = DateTime.Today;
        private Payment.PaymentStatus paymentStatus = Payment.PaymentStatus.ALL;

        public PaymentMainForm()
        {
            InitializeComponent();
        }

        private void PaymentMainForm_Load(object sender, EventArgs e)
        {
            //Do Nothing
        }

        public void load(MainForm mainForm)
        {
            this.mainForm = mainForm;
            this.paymentList1 = new List<DisplayPayment>();
            this.paymentList2 = new List<DisplayPayment>();

            this.ComboBox_Status.Items.Clear();
            this.ComboBox_Status.Items.Add(Payment.PaymentStatus.ALL.ToString());
            this.ComboBox_Status.Items.Add(Payment.PaymentStatus.PAID.ToString());
            this.ComboBox_Status.Items.Add(Payment.PaymentStatus.CANCELED.ToString());
            this.ComboBox_Status.Items.Add(Payment.PaymentStatus.NOT_PAID.ToString());

            this.DataGridView_PaymentInfo.AutoGenerateColumns = false;            

            this.ComboBox_NumberPerPage.Items.Clear();
            this.ComboBox_NumberPerPage.Items.Add("20");
            this.ComboBox_NumberPerPage.Items.Add("40");
            this.ComboBox_NumberPerPage.Items.Add("60");

            this.DataGridView_PrintTab_PaymentInfo.AutoGenerateColumns = false;
        }

        public void reload()
        {
            //Do Nothing
        }

        public void reset()
        {
            this.paymentList1.Clear();
            this.paymentList2.Clear();

            this.searchType = SearchType.ALL;
            this.paymentId = -1;
            this.studentId = -1;
            this.creditCardNumber = "";
            this.isEnableStartDate = false;
            this.startDate = DateTime.Today.AddDays(1);
            this.endDate = DateTime.Today.AddDays(1);
            this.paymentStatus = Payment.PaymentStatus.ALL;

            this.RadioButton_Show_AllPayment.Checked = true;
            this.RadioButton_Search_PaymentID.Checked = false;
            this.RadioButton_Search_Info.Checked = false;            

            this.TextBox_StudentID.Text = "";
            this.TextBox_PaymentID.Text = "";
            this.TextBox_CreditCardNumber.Text = "";

            if (this.ComboBox_Status.Items.Count > 0)
            {
                this.ComboBox_Status.SelectedIndex = 0;
            }

            if (this.ComboBox_NumberPerPage.Items.Count > 0)
            {
                this.ComboBox_NumberPerPage.SelectedIndex = 0;                
            }

            this.CheckBox_Enable_StartDate.Checked = false;
            
            this.DateTimePicker_StartDate.Value = DateTime.Today;
            this.DateTimePicker_StartDate.Enabled = false;

            this.DateTimePicker_EndDate.MaxDate = DateTime.Today;
            this.DateTimePicker_EndDate.Value = DateTime.Today;
            this.DateTimePicker_EndDate.Enabled = false;

            this.refreshDataGridView_PaymentInfo();

            this.RadioButton_Search_Date.Checked = false;
            this.RadioButton_Search_File.Checked = true;

            this.DateTimePicker_PrintTab_StartDate.Value = DateTime.Today;
            this.DateTimePicker_PrintTab_StartDate.Enabled = false;

            this.DateTimePicker_PrintTab_EndDate.MaxDate = DateTime.Today;
            this.DateTimePicker_PrintTab_EndDate.Value = DateTime.Today;
            this.DateTimePicker_PrintTab_EndDate.Enabled = false;

            this.TextBox_ChosenFile.Text = "";
        }

        private void keyPressed(KeyEventArgs keyEventArgs)
        {
            if (keyEventArgs.KeyData == Keys.Enter)
            {
                this.TextBox_PageNumber.Text = "1";
                this.saveSearchInfo();
                this.searchPaymentInfo();
            }
        }

        private void refreshDataGridView_PaymentInfo()
        {
            this.DataGridView_PaymentInfo.Rows.Clear();

            for (int i = 0; i < this.paymentList1.Count; i++)
            {
                int n = this.DataGridView_PaymentInfo.Rows.Add();

                if ((this.paymentList1[i].Status == Payment.PaymentStatus.CANCELED.ToString()) ||
                    (this.paymentList1[i].Status == Payment.PaymentStatus.NOT_PAID.ToString()))
                {
                    ((DataGridViewImageCell)this.DataGridView_PaymentInfo.Rows[n].Cells["DeleteButton"]).Value = new Bitmap(20, 16);
                }

                this.DataGridView_PaymentInfo.Rows[n].Cells["PaymentId"].Value = this.paymentList1[i].Id;
                this.DataGridView_PaymentInfo.Rows[n].Cells["StudentName"].Value = this.paymentList1[i].StudentName;
                this.DataGridView_PaymentInfo.Rows[n].Cells["TotalPrice"].Value = this.paymentList1[i].TotalPrice;
                this.DataGridView_PaymentInfo.Rows[n].Cells["PaymentType"].Value = this.paymentList1[i].PaymentType;
                this.DataGridView_PaymentInfo.Rows[n].Cells["PaymentDate"].Value = this.paymentList1[i].PaymentDate;
                //this.DataGridView_PaymentInfo.Rows[n].Cells["ClassroomStartDate"].Value = this.paymentList1[i].ClassroomStartDate;
                this.DataGridView_PaymentInfo.Rows[n].Cells["ReceiverName"].Value = this.paymentList1[i].ReceiverName;
                this.DataGridView_PaymentInfo.Rows[n].Cells["Status"].Value = this.paymentList1[i].Status;
            }

            this.DataGridView_PaymentInfo.ClearSelection();
        }

        private void refreshDataGridView_PrintTab_PaymentInfo()
        {
            this.DataGridView_PrintTab_PaymentInfo.Rows.Clear();

            for (int i = 0; i < this.paymentList2.Count; i++)
            {
                int n = this.DataGridView_PrintTab_PaymentInfo.Rows.Add();
                this.DataGridView_PrintTab_PaymentInfo.Rows[n].Cells[0].Value = false;
                this.DataGridView_PrintTab_PaymentInfo.Rows[n].Cells[1].Value = this.paymentList2[i].Id;
                this.DataGridView_PrintTab_PaymentInfo.Rows[n].Cells[2].Value = this.paymentList2[i].StudentName;
                this.DataGridView_PrintTab_PaymentInfo.Rows[n].Cells[3].Value = this.paymentList2[i].TotalPrice;
                this.DataGridView_PrintTab_PaymentInfo.Rows[n].Cells[4].Value = this.paymentList2[i].PaymentType;
                this.DataGridView_PrintTab_PaymentInfo.Rows[n].Cells[5].Value = this.paymentList2[i].PaymentDate;
                //this.DataGridView_PrintTab_PaymentInfo.Rows[n].Cells[6].Value = this.paymentList2[i].ClassroomStartDate;
                this.DataGridView_PrintTab_PaymentInfo.Rows[n].Cells[7].Value = this.paymentList2[i].ReceiverName;
                this.DataGridView_PrintTab_PaymentInfo.Rows[n].Cells[8].Value = this.paymentList2[i].Status;

                if (this.paymentList2[i].PrintPaymentId > 0)
                {
                    this.DataGridView_PrintTab_PaymentInfo.Rows[n].DefaultCellStyle.ForeColor = Color.Red;
                }
            }

            this.DataGridView_PrintTab_PaymentInfo.ClearSelection();
            this.Button_PrintTab_Print.Enabled = false;
        }

        private void addPaymentList(int paymentListNumber, Payment payment)
        {
            if (payment != null)
            {
                string studentName = "";
                string paymentType = "เงินสด";
                string classStartDate = "";
                string receiverName = "";

                Student student = StudentManager.findStudent(payment.StudentId);
                if (student != null)
                {
                    studentName = student.Firstname + " " + student.Lastname + " (" + student.Nickname + ")";
                }

                if (payment.CreditCardNumber != "")
                {
                    paymentType = "บัตรเครดิต";
                }

                //Enrollment tempEnrollment = EnrollmentManager.findAllEnrollmentByPaymentId(payment.Id);
                //if (tempEnrollment != null)
                //{
                //    List<Classroom> tempClassroomList = ClassroomManager.findAllClassroom(tempEnrollment.Id);
                //    if (tempClassroomList.Count > 0)
                //    {
                //        classStartDate = tempClassroomList[0].StartDate.ToShortDateString();
                //    }
                //}

                User user = UserManager.findUser(payment.ReceiverId);
                if (user != null)
                {
                    receiverName = user.DisplayName;
                }

                DisplayPayment displayPayment = new DisplayPayment(payment);
                displayPayment.StudentName = studentName;
                displayPayment.PaymentType = paymentType;
                displayPayment.ClassroomStartDate = classStartDate;
                displayPayment.ReceiverName = receiverName;

                if (paymentListNumber == 1)
                {
                    this.paymentList1.Add(displayPayment); 
                }
                else if (paymentListNumber == 2)
                {
                    this.paymentList2.Add(displayPayment); 
                }                              
            }            
        }

        private void saveSearchInfo()
        {
            this.paymentId = -1;
            this.studentId = -1;
            this.creditCardNumber = "";
            this.startDate = DateTime.Today.AddDays(1);
            this.endDate = DateTime.Today.AddDays(1);

            if (this.RadioButton_Show_AllPayment.Checked)
            {
                this.searchType = SearchType.ALL;                
            }
            else if (this.RadioButton_Search_PaymentID.Checked)
            {
                this.searchType = SearchType.PAYMENT_ID;

                if (ValidateManager.isNumber(this.TextBox_PaymentID.Text))
                {
                    this.paymentId = Convert.ToInt32(this.TextBox_PaymentID.Text);
                }
            }
            else if (this.RadioButton_Search_Info.Checked)
            {
                this.searchType = SearchType.INFO;

                if (this.TextBox_StudentID.Text != "")
                {
                    if (ValidateManager.isNumber(this.TextBox_StudentID.Text))
                    {
                        this.studentId = Convert.ToInt32(this.TextBox_StudentID.Text);
                    }
                }

                if (this.TextBox_CreditCardNumber.Text != "")
                {
                    this.creditCardNumber = ConvertManager.toDisplayCreditCardNumber(this.TextBox_CreditCardNumber.Text);
                }

                this.isEnableStartDate = this.CheckBox_Enable_StartDate.Checked;
                this.startDate = this.DateTimePicker_StartDate.Value;
                this.endDate = this.DateTimePicker_EndDate.Value;
                this.paymentStatus = (Payment.PaymentStatus)this.ComboBox_Status.SelectedIndex;
            }
        }

        private void searchPaymentInfo()
        {
            if (MainForm.currentForm is PaymentMainForm)
            {
                this.paymentList1.Clear();

                List<Payment> tempPaymentList1 = new List<Payment>();
                List<Payment> tempPaymentList2 = new List<Payment>();
                
                int numberPerPage = Convert.ToInt32(this.ComboBox_NumberPerPage.Text);
                int pageNumber = Convert.ToInt32(this.TextBox_PageNumber.Text);
                int startIndex = (pageNumber - 1) * numberPerPage;

                if (this.searchType == SearchType.ALL)
                {
                    tempPaymentList1 = PaymentManager.findAllPayment(startIndex, numberPerPage);
                    tempPaymentList2 = PaymentManager.findAllPayment(startIndex + numberPerPage, numberPerPage);

                    for (int i = 0; i < tempPaymentList1.Count; i++)
                    {
                        this.addPaymentList(1, tempPaymentList1[i]);
                    }
                }
                else if (this.searchType == SearchType.PAYMENT_ID)
                {
                    //string temp = this.TextBox_PaymentID.Text;
                    //if (temp != "")
                    //{
                    //    int paymentId = Convert.ToInt32(temp);

                    //    Payment tempPayment = tempPayment = PaymentManager.findPayment(paymentId);

                    //    this.addPaymentList(1, tempPayment);
                    //}
                    Payment tempPayment = tempPayment = PaymentManager.findPayment(this.paymentId);
                    this.addPaymentList(1, tempPayment);
                }
                else if (this.searchType == SearchType.INFO)
                {
                    //string textBoxStudentId = this.TextBox_StudentID.Text;
                    //string textBoxCreditCardNumber = this.TextBox_CreditCardNumber.Text;

                    //int studentId = -1;
                    //string creditCardNumber = ConvertManager.toDisplayCreditCardNumber(textBoxCreditCardNumber);
                    //DateTime startDate = this.DateTimePicker_StartDate.Value;
                    //DateTime endDate = this.DateTimePicker_EndDate.Value;
                    //Payment.PaymentStatus status = (Payment.PaymentStatus)this.ComboBox_Status.SelectedIndex;

                    //if (ValidateManager.isNumber(textBoxStudentId))
                    //{
                    //    studentId = Convert.ToInt32(textBoxStudentId);
                    //}

                    //if ((textBoxStudentId == "") && (creditCardNumber == ""))
                    //{
                    //    if (this.CheckBox_Enable_StartDate.Checked)
                    //    {
                    //        tempPaymentList1 = PaymentManager.findAllPaymentByDate(startDate, endDate, status, startIndex, numberPerPage);
                    //        tempPaymentList2 = PaymentManager.findAllPaymentByDate(startDate, endDate, status, startIndex + numberPerPage, numberPerPage);
                    //    }
                    //    else
                    //    {
                    //        tempPaymentList1 = PaymentManager.findAllPayment(status, startIndex, numberPerPage);
                    //        tempPaymentList2 = PaymentManager.findAllPayment(status, startIndex + numberPerPage, numberPerPage);
                    //    }
                    //}
                    //else if ((textBoxStudentId != "") && (creditCardNumber == ""))
                    //{
                    //    if (this.CheckBox_Enable_StartDate.Checked)
                    //    {
                    //        tempPaymentList1 = PaymentManager.findAllPaymentByStudentIdAndDate(studentId, startDate, endDate, status, startIndex, numberPerPage);
                    //        tempPaymentList2 = PaymentManager.findAllPaymentByStudentIdAndDate(studentId, startDate, endDate, status, startIndex + numberPerPage, numberPerPage);
                    //    }
                    //    else
                    //    {
                    //        tempPaymentList1 = PaymentManager.findAllPaymentByStudentId(studentId, status, startIndex, numberPerPage);
                    //        tempPaymentList2 = PaymentManager.findAllPaymentByStudentId(studentId, status, startIndex + numberPerPage, numberPerPage);
                    //    }
                    //}
                    //else if ((textBoxStudentId == "") && (creditCardNumber != ""))
                    //{
                    //    if (this.CheckBox_Enable_StartDate.Checked)
                    //    {
                    //        tempPaymentList1 = PaymentManager.findAllPaymentByCreditCardNumberAndDate(creditCardNumber, startDate, endDate, status, startIndex, numberPerPage);
                    //        tempPaymentList2 = PaymentManager.findAllPaymentByCreditCardNumberAndDate(creditCardNumber, startDate, endDate, status, startIndex + numberPerPage, numberPerPage);
                    //    }
                    //    else
                    //    {
                    //        tempPaymentList1 = PaymentManager.findAllPaymentByCreditCardNumber(creditCardNumber, status, startIndex, numberPerPage);
                    //        tempPaymentList2 = PaymentManager.findAllPaymentByCreditCardNumber(creditCardNumber, status, startIndex + numberPerPage, numberPerPage);
                    //    }
                    //}
                    //else if ((textBoxStudentId != "") && (creditCardNumber != ""))
                    //{
                    //    if (this.CheckBox_Enable_StartDate.Checked)
                    //    {
                    //        tempPaymentList1 = PaymentManager.findAllPaymentByStudentIdAndCreditCardNumberAndDate(studentId, creditCardNumber, startDate, endDate, status, startIndex, numberPerPage);
                    //        tempPaymentList2 = PaymentManager.findAllPaymentByStudentIdAndCreditCardNumberAndDate(studentId, creditCardNumber, startDate, endDate, status, startIndex + numberPerPage, numberPerPage);
                    //    }
                    //    else
                    //    {
                    //        tempPaymentList1 = PaymentManager.findAllPaymentByStudentIdAndCreditCardNumber(studentId, creditCardNumber, status, startIndex, numberPerPage);
                    //        tempPaymentList2 = PaymentManager.findAllPaymentByStudentIdAndCreditCardNumber(studentId, creditCardNumber, status, startIndex + numberPerPage, numberPerPage);
                    //    }
                    //}                    

                    if ((this.studentId == -1) && (this.creditCardNumber == ""))
                    {
                        if (this.isEnableStartDate)
                        {
                            tempPaymentList1 = PaymentManager.findAllPaymentByDate(this.startDate, this.endDate, this.paymentStatus, startIndex, numberPerPage);
                            tempPaymentList2 = PaymentManager.findAllPaymentByDate(this.startDate, this.endDate, this.paymentStatus, startIndex + numberPerPage, numberPerPage);
                        }
                        else
                        {
                            tempPaymentList1 = PaymentManager.findAllPayment(this.paymentStatus, startIndex, numberPerPage);
                            tempPaymentList2 = PaymentManager.findAllPayment(this.paymentStatus, startIndex + numberPerPage, numberPerPage);
                        }
                    }
                    else if ((this.studentId != -1) && (this.creditCardNumber == ""))
                    {
                        if (this.isEnableStartDate)
                        {
                            tempPaymentList1 = PaymentManager.findAllPaymentByStudentIdAndDate(this.studentId, this.startDate, this.endDate, this.paymentStatus, startIndex, numberPerPage);
                            tempPaymentList2 = PaymentManager.findAllPaymentByStudentIdAndDate(this.studentId, this.startDate, this.endDate, this.paymentStatus, startIndex + numberPerPage, numberPerPage);
                        }
                        else
                        {
                            tempPaymentList1 = PaymentManager.findAllPaymentByStudentId(this.studentId, this.paymentStatus, startIndex, numberPerPage);
                            tempPaymentList2 = PaymentManager.findAllPaymentByStudentId(this.studentId, this.paymentStatus, startIndex + numberPerPage, numberPerPage);
                        }
                    }
                    else if ((this.studentId == -1) && (this.creditCardNumber != ""))
                    {
                        if (this.isEnableStartDate)
                        {
                            tempPaymentList1 = PaymentManager.findAllPaymentByCreditCardNumberAndDate(this.creditCardNumber, this.startDate, this.endDate, this.paymentStatus, startIndex, numberPerPage);
                            tempPaymentList2 = PaymentManager.findAllPaymentByCreditCardNumberAndDate(this.creditCardNumber, this.startDate, this.endDate, this.paymentStatus, startIndex + numberPerPage, numberPerPage);
                        }
                        else
                        {
                            tempPaymentList1 = PaymentManager.findAllPaymentByCreditCardNumber(this.creditCardNumber, this.paymentStatus, startIndex, numberPerPage);
                            tempPaymentList2 = PaymentManager.findAllPaymentByCreditCardNumber(this.creditCardNumber, this.paymentStatus, startIndex + numberPerPage, numberPerPage);
                        }
                    }
                    else if ((this.studentId != -1) && (this.creditCardNumber != ""))
                    {
                        if (this.isEnableStartDate)
                        {
                            tempPaymentList1 = PaymentManager.findAllPaymentByStudentIdAndCreditCardNumberAndDate(this.studentId, this.creditCardNumber, this.startDate, this.endDate, this.paymentStatus, startIndex, numberPerPage);
                            tempPaymentList2 = PaymentManager.findAllPaymentByStudentIdAndCreditCardNumberAndDate(this.studentId, this.creditCardNumber, this.startDate, this.endDate, this.paymentStatus, startIndex + numberPerPage, numberPerPage);
                        }
                        else
                        {
                            tempPaymentList1 = PaymentManager.findAllPaymentByStudentIdAndCreditCardNumber(this.studentId, this.creditCardNumber, this.paymentStatus, startIndex, numberPerPage);
                            tempPaymentList2 = PaymentManager.findAllPaymentByStudentIdAndCreditCardNumber(this.studentId, this.creditCardNumber, this.paymentStatus, startIndex + numberPerPage, numberPerPage);
                        }
                    }

                    for (int i = 0; i < tempPaymentList1.Count; i++)
                    {
                        this.addPaymentList(1, tempPaymentList1[i]);
                    }
                }

                if (this.paymentList1.Count == 0)
                {
                    MessageBox.Show(DatabaseConstant.DATA_NOT_FOUND);
                }
                else if (this.paymentList1.Count < numberPerPage)
                {
                    this.Button_NextPage.Enabled = false;
                }
                else if (this.paymentList1.Count == numberPerPage)
                {
                    this.refreshButton_NextPage(tempPaymentList2);
                }

                this.refreshDataGridView_PaymentInfo();
            }

            this.TextBox_StudentID.Text = "";
            this.TextBox_PaymentID.Text = "";
            this.TextBox_CreditCardNumber.Text = "";

            if (this.ComboBox_Status.Items.Count > 0)
            {
                this.ComboBox_Status.SelectedIndex = 0;
            }

            this.CheckBox_Enable_StartDate.Checked = false;

            this.DateTimePicker_StartDate.Value = DateTime.Today;
            this.DateTimePicker_StartDate.Enabled = false;

            this.DateTimePicker_EndDate.MaxDate = DateTime.Today;
            this.DateTimePicker_EndDate.Value = DateTime.Today;
            this.DateTimePicker_EndDate.Enabled = false;
        }

        private void refreshButton_NextPage(List<Payment> paymentList)
        {
            if (paymentList.Count > 0)
            {
                this.Button_NextPage.Enabled = true;
            }
            else
            {
                this.Button_NextPage.Enabled = false;
            }
        }

        private void cancelPayment(int paymentId)
        {
            Payment payment = PaymentManager.findPayment(paymentId);
            if (payment != null)
            {
                payment.Status = Payment.PaymentStatus.CANCELED.ToString();

                bool isUpdatePaymentComplete = PaymentManager.updatePayment(payment);
                if (isUpdatePaymentComplete)
                {
                    bool isCancelPaymentDetailComplete = this.cancelPaymentDetail(paymentId);
                    if (isCancelPaymentDetailComplete)
                    {
                        MessageBox.Show("ยกเลิกใบเสร็จเรียบร้อย");
                        this.searchPaymentInfo();
                    }
                    else
                    {
                        MessageBox.Show("ยกเลิกใบเสร็จล้มเหลว");
                    }
                }
                else
                {
                    MessageBox.Show("ยกเลิกใบเสร็จล้มเหลว");
                }
            }
        }

        private bool cancelPaymentDetail(int paymentId)
        {
            bool returnFlag = false;

            List<PaymentDetail> tempPaymentDetailList = PaymentDetailManager.findAllPaymentDetail(paymentId);
            for (int i = 0; i < tempPaymentDetailList.Count; i++)
            {
                PaymentDetail paymentDetail = tempPaymentDetailList[i];
                if (paymentDetail != null)
                {
                    string productType = paymentDetail.Product.Type;
                    if (productType == Product.ProductType.COURSE.ToString())
                    {
                        returnFlag = EnrollmentManager.cancelEnrollment(paymentId);
                    }
                    else if (productType == Product.ProductType.BOOK.ToString())
                    {
                        Book tempBook = BookManager.findBook(paymentDetail.Product.Id);
                        if (tempBook != null)
                        {
                            tempBook.Quantity = tempBook.Quantity - paymentDetail.Quantity;
                            returnFlag = BookManager.updateBook(tempBook);
                        }
                    }
                    else if (productType == Product.ProductType.CD.ToString())
                    {
                        Cd tempCd = CdManager.findCd(paymentDetail.Product.Id);
                        if (tempCd != null)
                        {
                            tempCd.Quantity = tempCd.Quantity - paymentDetail.Quantity;
                            returnFlag = CdManager.updateCd(tempCd);
                        }
                    }
                    else if (productType == Product.ProductType.OTHER.ToString())
                    {
                        returnFlag = true;
                    }

                    if (!returnFlag)
                    {
                        break;
                    }
                }
            }

            return returnFlag;
        }

        private void RadioButton_Show_AllPayment_CheckedChanged(object sender, EventArgs e)
        {
            this.TextBox_PaymentID.Enabled = false;
            this.TextBox_StudentID.Enabled = false;
            this.TextBox_CreditCardNumber.Enabled = false;
            this.ComboBox_Status.Enabled = false;
            this.CheckBox_Enable_StartDate.Enabled = false;
        }

        private void RadioButton_Show_AllPayment_KeyDown(object sender, KeyEventArgs e)
        {
            this.keyPressed(e);
        }        

        private void RadioButton_Search_PaymentID_CheckedChanged(object sender, EventArgs e)
        {
            this.TextBox_PaymentID.Enabled = true;
            this.TextBox_StudentID.Enabled = false;
            this.TextBox_CreditCardNumber.Enabled = false;
            this.ComboBox_Status.Enabled = false;
            this.CheckBox_Enable_StartDate.Enabled = false;

            this.TextBox_StudentID.Text = "";
            this.TextBox_CreditCardNumber.Text = "";

            if (this.ComboBox_Status.Items.Count > 0)
            {
                this.ComboBox_Status.SelectedIndex = 0;
            }

            if (this.ComboBox_NumberPerPage.Items.Count > 0)
            {
                this.ComboBox_NumberPerPage.SelectedIndex = 0;
            }

            this.CheckBox_Enable_StartDate.Checked = false;

            this.DateTimePicker_StartDate.Value = DateTime.Today;
            this.DateTimePicker_StartDate.Enabled = false;

            this.DateTimePicker_EndDate.MaxDate = DateTime.Today;
            this.DateTimePicker_EndDate.Value = DateTime.Today;
            this.DateTimePicker_EndDate.Enabled = false;
        }

        private void RadioButton_Search_PaymentID_KeyDown(object sender, KeyEventArgs e)
        {
            this.keyPressed(e);
        }

        private void TextBox_PaymentID_KeyDown(object sender, KeyEventArgs e)
        {
            this.keyPressed(e);
        }        

        private void RadioButton_Search_Info_CheckedChanged(object sender, EventArgs e)
        {
            this.TextBox_PaymentID.Enabled = false;
            this.TextBox_StudentID.Enabled = true;
            this.TextBox_CreditCardNumber.Enabled = true;
            this.ComboBox_Status.Enabled = true;
            this.CheckBox_Enable_StartDate.Enabled = true;

            this.TextBox_PaymentID.Text = "";            
        }

        private void RadioButton_Search_Info_KeyDown(object sender, KeyEventArgs e)
        {
            this.keyPressed(e);
        }

        private void TextBox_StudentID_KeyDown(object sender, KeyEventArgs e)
        {
            this.keyPressed(e);
        }

        private void TextBox_CreditCardNumber_KeyDown(object sender, KeyEventArgs e)
        {
            this.keyPressed(e);
        }

        private void ComboBox_Status_KeyDown(object sender, KeyEventArgs e)
        {
            this.keyPressed(e);
        }

        private void CheckBox_Enable_StartDate_KeyDown(object sender, KeyEventArgs e)
        {
            this.keyPressed(e);
        }        

        private void CheckBox_Enable_StartDate_CheckedChanged(object sender, EventArgs e)
        {
            this.DateTimePicker_StartDate.Enabled = CheckBox_Enable_StartDate.Checked;
            this.DateTimePicker_EndDate.Enabled = CheckBox_Enable_StartDate.Checked;
        }

        private void DateTimePicker_StartDate_KeyDown(object sender, KeyEventArgs e)
        {
            this.keyPressed(e);
        }
        
        private void DateTimePicker_StartDate_ValueChanged(object sender, EventArgs e)
        {
            this.DateTimePicker_EndDate.MinDate = this.DateTimePicker_StartDate.Value;
        }

        private void DateTimePicker_EndDate_KeyDown(object sender, KeyEventArgs e)
        {
            this.keyPressed(e);
        }

        private void Button_Search_Click(object sender, EventArgs e)
        {
            this.TextBox_PageNumber.Text = "1";
            this.saveSearchInfo();
            this.searchPaymentInfo();
        }

        private void DataGridView_PaymentInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                switch (e.ColumnIndex)
                {
                    case 8:
                        {
                            ReceiptForm receiptForm = new ReceiptForm();
                            receiptForm.showFormDialog(this.paymentList1[e.RowIndex].Id, this.paymentList1[e.RowIndex].Status);
                        }
                        break;
                    case 9:
                        {
                            if (this.paymentList1[e.RowIndex].Status == Payment.PaymentStatus.PAID.ToString())
                            {
                                string text = "คุณต้องการยกเลิกใบเสร็จหมายเลข " + this.paymentList1[e.RowIndex].Id.ToString() + " ใช่หรือไม่";
                                if (ConfirmDialogBox.show(text))
                                {
                                    this.cancelPayment(this.paymentList1[e.RowIndex].Id);
                                }
                            }                            
                        }                        
                        break;
                }
            }

            this.Cursor = Cursors.Arrow;
        }

        private void DataGridView_PaymentInfo_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                switch (e.ColumnIndex)
                {
                    case 8:
                        {
                            this.Cursor = Cursors.Hand;
                            this.DataGridView_PaymentInfo.Rows[e.RowIndex].Cells[e.ColumnIndex].ToolTipText = "View";
                        }
                        break;
                    case 9:
                        {
                            if (this.paymentList1[e.RowIndex].Status == Payment.PaymentStatus.PAID.ToString())
                            {
                                this.Cursor = Cursors.Hand;
                                this.DataGridView_PaymentInfo.Rows[e.RowIndex].Cells[e.ColumnIndex].ToolTipText = "Cancel";
                            }
                        }                       
                        break;
                }
            }
        }

        private void DataGridView_PaymentInfo_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            this.Cursor = Cursors.Arrow;
        }        

        private void ComboBox_NumberPerPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.TextBox_PageNumber.Text = "1";
            this.searchPaymentInfo();
        }

        private void TextBox_PageNumber_TextChanged(object sender, EventArgs e)
        {
            if (this.TextBox_PageNumber.Text == "1")
            {
                this.Button_PreviousPage.Enabled = false;
            }
            else
            {
                this.Button_PreviousPage.Enabled = true;
            }
        }

        private void Button_PreviousPage_Click(object sender, EventArgs e)
        {
            int currentPageNumber = Convert.ToInt32(this.TextBox_PageNumber.Text);
            currentPageNumber--;
            this.TextBox_PageNumber.Text = currentPageNumber.ToString();
            this.searchPaymentInfo();
        }

        private void Button_NextPage_Click(object sender, EventArgs e)
        {
            int currentPageNumber = Convert.ToInt32(this.TextBox_PageNumber.Text);
            currentPageNumber++;
            this.TextBox_PageNumber.Text = currentPageNumber.ToString();
            this.searchPaymentInfo();
        }
                
        private void Button_PrintTab_Search_Click(object sender, EventArgs e)
        {
            if (this.RadioButton_Search_Date.Checked)
            {
                searchPaymentInPrintTab.RunWorkerAsync();
                ProgressBarManager.showProgressBar(true);
            }
            else
            {
                searchPaymentInPrintTabFromFile.RunWorkerAsync();
                ProgressBarManager.showProgressBar(true);
            }
        }

        private void DataGridView_PrintTab_PaymentInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                bool isCheck = Convert.ToBoolean(this.DataGridView_PrintTab_PaymentInfo.Rows[e.RowIndex].Cells["CheckBox"].Value);
                if (isCheck)
                {
                    ((DataGridViewCheckBoxCell)this.DataGridView_PrintTab_PaymentInfo.Rows[e.RowIndex].Cells["CheckBox"]).Value = false;
                }
                else
                {
                    ((DataGridViewCheckBoxCell)this.DataGridView_PrintTab_PaymentInfo.Rows[e.RowIndex].Cells["CheckBox"]).Value = true;
                }
            }
        }

        private void DataGridView_PrintTab_PaymentInfo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.RowIndex >= 0)
            //{
            //    if (e.ColumnIndex == 0)
            //    {
            //        bool isCheck = Convert.ToBoolean(this.DataGridView_PrintTab_PaymentInfo.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
            //        if (isCheck)
            //        {
            //            ((DataGridViewCheckBoxCell)this.DataGridView_PrintTab_PaymentInfo.Rows[e.RowIndex].Cells[e.ColumnIndex]).Value = false;
            //        }
            //        else
            //        {
            //            ((DataGridViewCheckBoxCell)this.DataGridView_PrintTab_PaymentInfo.Rows[e.RowIndex].Cells[e.ColumnIndex]).Value = true;
            //        }
            //    }
            //}
        }

        private void DataGridView_PrintTab_PaymentInfo_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow dataGridViewRow in this.DataGridView_PrintTab_PaymentInfo.Rows)
            {
                if ((bool)dataGridViewRow.Cells["CheckBox"].Value)
                {
                    this.Button_PrintTab_Print.Enabled = true;
                    break;
                }
                else
                {
                    this.Button_PrintTab_Print.Enabled = false;
                }
            }
        }

        private void Button_PrintTab_Print_Click(object sender, EventArgs e)
        {
            if (ConfirmDialogBox.show("คุณต้องการปริ้นใบเสร็จใช่หรือไม่"))
            {                
                List<int> paymentIdList = new List<int>();
                foreach (DataGridViewRow dataGridViewRow in this.DataGridView_PrintTab_PaymentInfo.Rows)
                {
                    DataGridViewCheckBoxCell checkCell = (DataGridViewCheckBoxCell)dataGridViewRow.Cells["CheckBox"];
                    if ((Boolean)checkCell.Value)
                    {
                        if (this.paymentList2[dataGridViewRow.Index].Status != Payment.PaymentStatus.CANCELED.ToString())
                        {
                            int paymentId = Convert.ToInt32(dataGridViewRow.Cells[1].Value);
                            Payment tempPayment = PaymentManager.findPayment(paymentId);
                            if (tempPayment != null)
                            {
                                if (tempPayment.PrintPaymentId == 0)
                                {
                                    tempPayment.PrintPaymentId = PaymentManager.generateNextPrintedPaymentId(tempPayment.PaymentDate);

                                    bool isUpdateComplete = PaymentManager.updatePayment(tempPayment);
                                    if (isUpdateComplete)
                                    {
                                        ReceiptManager.printReceipt(tempPayment);
                                    }
                                }
                                else
                                {
                                    ReceiptManager.printReceipt(tempPayment);
                                }
                            }
                        }
                    }
                }
            }
        }

        private void searchPaymentInPrintTab_DoWork(object sender, DoWorkEventArgs e)
        {
            this.paymentList2.Clear();

            DateTime startDate = this.DateTimePicker_PrintTab_StartDate.Value;
            DateTime endDate = this.DateTimePicker_PrintTab_EndDate.Value;
            searchPaymentInPrintTab.ReportProgress(0, ProgressBarManager.ProgressBarState.QUERY);
            List<Payment> tempPaymentList = PaymentManager.findAllPaymentByDate(startDate, endDate, Payment.PaymentStatus.PAID);

            for (int i = 0; i < tempPaymentList.Count; i++)
            {
                this.addPaymentList(2, tempPaymentList[i]);
            } 
        }

        private void searchPaymentInPrintTab_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //Do Nothing
        }

        private void searchPaymentInPrintTab_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ProgressBarManager.showProgressBar(false);
            this.refreshDataGridView_PrintTab_PaymentInfo();            
        }

        private void searchPaymentInPrintTabFromFile_DoWork(object sender, DoWorkEventArgs e)
        {
            this.paymentList2.Clear();

            searchPaymentInPrintTabFromFile.ReportProgress(0, ProgressBarManager.ProgressBarState.QUERY);

            try
            {
                using (StreamReader sr = new StreamReader(this.TextBox_ChosenFile.Text))
                {
                    String[] temp = Regex.Split(sr.ReadToEnd(), "\r\n");
                    foreach (String str in temp)
                    {
                        if (ValidateManager.isNumber(str))
                        {
                            int paymentId = Convert.ToInt32(str);
                            Payment tempPayment = PaymentManager.findPayment(paymentId);
                            if (tempPayment != null)
                            {
                                this.addPaymentList(2, tempPayment);
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                LogManager.writeLog(exception.Message);
            }            
        }

        private void searchPaymentInPrintTabFromFile_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //Do Nothing
        }

        private void searchPaymentInPrintTabFromFile_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ProgressBarManager.showProgressBar(false);
            this.refreshDataGridView_PrintTab_PaymentInfo();
        }

        private void Button_SelectAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.DataGridView_PrintTab_PaymentInfo.Rows.Count; i++)
            {
                ((DataGridViewCheckBoxCell)this.DataGridView_PrintTab_PaymentInfo.Rows[i].Cells["CheckBox"]).Value = true;
            }                
        }

        private void Button_SelectNone_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.DataGridView_PrintTab_PaymentInfo.Rows.Count; i++)
            {
                ((DataGridViewCheckBoxCell)this.DataGridView_PrintTab_PaymentInfo.Rows[i].Cells["CheckBox"]).Value = false;
            } 
        }

        private void RadioButton_Search_Date_CheckedChanged(object sender, EventArgs e)
        {
            this.Button_Choose_File.Enabled = !this.RadioButton_Search_Date.Checked;
            this.DateTimePicker_PrintTab_StartDate.Enabled = this.RadioButton_Search_Date.Checked;
            this.DateTimePicker_PrintTab_EndDate.Enabled = this.RadioButton_Search_Date.Checked;
        }

        private void RadioButton_Search_File_CheckedChanged(object sender, EventArgs e)
        {
            this.Button_Choose_File.Enabled = this.RadioButton_Search_File.Checked;
            this.DateTimePicker_PrintTab_StartDate.Enabled = !this.RadioButton_Search_File.Checked;
            this.DateTimePicker_PrintTab_EndDate.Enabled = !this.RadioButton_Search_File.Checked;
        }

        private void Button_Choose_File_Click(object sender, EventArgs e)
        {
            openFileDialog.InitialDirectory = "C:";
            openFileDialog.Title = "Choose File";
            openFileDialog.FileName = "";
            openFileDialog.Filter = "Text Documents|*.txt";

            if (openFileDialog.ShowDialog() == DialogResult.Cancel)
            {
                this.TextBox_ChosenFile.Text = "";
            }
            else
            {
                this.TextBox_ChosenFile.Text = openFileDialog.FileName;
            }
        }     
    }
}
