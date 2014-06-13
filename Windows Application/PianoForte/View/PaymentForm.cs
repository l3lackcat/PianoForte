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
using PianoForte.Report;

namespace PianoForte.View
{
    public partial class PaymentForm : Form, FormInterface
    {
        private MainForm mainForm;

        private Student student;
        private OtherCost firstRegister;
        private List<PaymentDetail> paymentDetailList;

        private PaymentForm_Student studentForm;
        private PaymentForm_Course courseForm;
        private PaymentForm_OtherProduct otherProductForm;

        public PaymentForm()
        {
            InitializeComponent();
        }

        public void load(MainForm mainForm)
        {
            this.mainForm = mainForm;

            this.student = new Student();
            this.firstRegister = new OtherCost();
            this.paymentDetailList = new List<PaymentDetail>();

            this.student = null;
            this.firstRegister = null;

            this.studentForm = new PaymentForm_Student();
            this.studentForm.load(this);
            this.initialForm(this.studentForm);
            this.Panel_StudentForm.Controls.Add(this.studentForm);

            this.courseForm = new PaymentForm_Course();
            this.courseForm.load(this);
            this.initialForm(this.courseForm);
            this.Panel_CourseForm.Controls.Add(this.courseForm);

            this.otherProductForm = new PaymentForm_OtherProduct();
            this.otherProductForm.load(this);
            this.initialForm(this.otherProductForm);
            this.Panel_OtherProductForm.Controls.Add(this.otherProductForm);
        }        

        public void reload()
        {
            //Do Nothing
        }

        public void reset()
        {
            //Do Nothing
        }

        public void reset(bool isResetAll)
        {
            this.student = null;
            this.paymentDetailList.Clear();

            this.CheckBox_AddFirstRegisterCost.Checked = false;

            this.TextBox_GrandTotal.Text = "0";
            this.RadioButton_CreditCard.Checked = true;
            this.TextBox_CreditCardNumber.Text = "";
            this.TextBox_CreditCardNumber.Enabled = true;
            this.Button_Pay.Enabled = false;

            if (isResetAll)
            {
                this.studentForm.reset();
                this.courseForm.reset();
                this.otherProductForm.reset();
            }

            this.refreshDataGridView_PaymentDetail_Summary();
        }

        private void initialForm(Form form)
        {
            form.TopLevel = false;
            form.Dock = DockStyle.Fill;
            form.Show();
        }

        private void refreshDataGridView_PaymentDetail_Summary()
        {
            this.DataGridView_PaymentDetail_Summary.Rows.Clear();

            for (int i = 0; i < this.paymentDetailList.Count; i++)
            {
                int n = this.DataGridView_PaymentDetail_Summary.Rows.Add();
                this.DataGridView_PaymentDetail_Summary.Rows[n].Cells["No"].Value = i + 1;
                this.DataGridView_PaymentDetail_Summary.Rows[n].Cells["ItemName"].Value = this.paymentDetailList[i].Product.Name;
                this.DataGridView_PaymentDetail_Summary.Rows[n].Cells["Quantity"].Value = this.paymentDetailList[i].Quantity;
                this.DataGridView_PaymentDetail_Summary.Rows[n].Cells["Discount"].Value = this.paymentDetailList[i].Discount;
                this.DataGridView_PaymentDetail_Summary.Rows[n].Cells["Price"].Value = this.paymentDetailList[i].Product.Price;
                this.DataGridView_PaymentDetail_Summary.Rows[n].Cells["TotalPrice"].Value = (this.paymentDetailList[i].Quantity * this.paymentDetailList[i].Product.Price) - this.paymentDetailList[i].Discount;
            }

            this.DataGridView_PaymentDetail_Summary.ClearSelection();

            this.refreshTextBox_GrandTotal();
        }

        private void refreshTextBox_GrandTotal()
        {
            double grandTotal = 0;

            for (int i = 0; i < this.paymentDetailList.Count; i++)
            {
                double price = (this.paymentDetailList[i].Quantity * this.paymentDetailList[i].Product.Price) - this.paymentDetailList[i].Discount;
                grandTotal += price;
            }

            this.TextBox_GrandTotal.Text = grandTotal.ToString();
        }

        private void refreshButton_Pay()
        {
            if ((this.student != null) && (this.paymentDetailList.Count > 0))
            {
                this.Button_Pay.Enabled = true;
            }
            else
            {
                this.Button_Pay.Enabled = false;
            }
        }

        public void initGroupbox_Student(int studentId)
        {
            this.studentForm.searchStudent(studentId);
        }

        public void initGroupbox_Student(Student student)
        {
            this.studentForm.initGroupBox_Student(student);
        }

        public void initComboBox_Not_Paid_Enrollment(List<Enrollment> enrollmentList, int selectedEnrollmentId)
        {
            this.courseForm.initComboBoxUnpaidEnrollment(enrollmentList, selectedEnrollmentId);
        }

        public void initGroupbox_Course(Course course)
        {
            //To Do
        }

        public void searchEnrollment(int enrollmentId)
        {
            //this.courseForm.searchEnrollment(enrollmentId);
            Enrollment enrollment = EnrollmentManager.getEnrollment(enrollmentId);
            if (enrollment != null)
            {
                this.initGroupbox_Student(enrollment.Student);
                this.initComboBox_Not_Paid_Enrollment(EnrollmentManager.findAllEnrollmentByStudentId(enrollment.Student.Id, Enrollment.EnrollmentStatus.NOT_PAID), enrollmentId);
            }
        }

        public bool isHaveCourseInPaymentDetailList()
        {
            bool returnFlag = false;

            for (int i = 0; i < this.paymentDetailList.Count; i++)
            {
                if (paymentDetailList[i].Product.Type == Product.ProductType.COURSE.ToString())
                {
                    returnFlag = true;
                    break;
                }
            }

            return returnFlag;
        }

        public void enableGroupBoxStudent(bool isEnable)
        {
            this.studentForm.enableGroupBoxStudent(isEnable);
        }

        public void setStudent(Student student)
        {
            this.student = student;
            this.refreshButton_Pay();
        }

        public bool addPaymentDetail(PaymentDetail paymentDetail)
        {
            bool isAddSuccess = false;

            if (this.canAddMoreProduct())
            {
                if (this.paymentDetailList.Count == 0)
                {
                    this.paymentDetailList.Add(paymentDetail);
                    isAddSuccess = true;
                }
                else
                {
                    int index = this.haveProduct(paymentDetail.Product.Id);
                    if (index == -1)
                    {
                        this.paymentDetailList.Add(paymentDetail);
                        isAddSuccess = true;
                    }
                    else if (index >= 0)
                    {
                        this.paymentDetailList[index].Quantity += paymentDetail.Quantity;
                        isAddSuccess = true;
                    }
                }
            }

            if (isAddSuccess)
            {
                this.sortPaymentDetailList();
                this.refreshDataGridView_PaymentDetail_Summary();
            }

            this.refreshButton_Pay();

            return isAddSuccess;
        }

        public bool deletePaymentDetail(int productId)
        {
            bool isDeleteComplete = false;

            string tempProductType = "";

            int index = this.haveProduct(productId);            
            if ((index >= 0) && (index < 12))
            {
                tempProductType = this.paymentDetailList[index].Product.Type;

                int tempProductId = this.paymentDetailList[index].Product.Id;

                this.paymentDetailList.Remove(this.paymentDetailList[index]);
                isDeleteComplete = true;

                if (tempProductId == 4000001)
                {
                    this.CheckBox_AddFirstRegisterCost.Checked = false;
                }
            }
            
            if (isDeleteComplete)
            {
                if (tempProductType == Product.ProductType.COURSE.ToString())
                {
                    this.courseForm.enableGroupBoxEnrollment(true);
                }

                this.refreshDataGridView_PaymentDetail_Summary();
            }

            this.refreshButton_Pay();

            return isDeleteComplete;
        }

        private void sortPaymentDetailList()
        {
            for (int i = 0; i < this.paymentDetailList.Count; i++)
            {
                for (int j = i + 1; j < this.paymentDetailList.Count; j++)
                {
                    if (this.paymentDetailList[j].Product.Id < this.paymentDetailList[i].Product.Id)
                    {
                        PaymentDetail tempPaymentDetail = this.paymentDetailList[i];
                        this.paymentDetailList[i] = this.paymentDetailList[j];
                        this.paymentDetailList[j] = tempPaymentDetail;

                        break;
                    }
                }
            }
        }

        private bool canAddMoreProduct()
        {
            bool canAdd = false;

            if (this.paymentDetailList.Count < 12)
            {
                canAdd = true;
            }
            else
            {
                MessageBox.Show(PianoForte.Constant.Constant.OVER_12_ITEMS);
            }

            return canAdd;
        }

        public int haveProduct(int productId)
        {
            int index = -1;

            for (int i = 0; i < this.paymentDetailList.Count; i++)
            {
                if (this.paymentDetailList[i].Product.Id == productId)
                {
                    index = i;
                    break;
                }
            }

            return index;
        }

        public int getProductAmount(int productId)
        {
            int productAmount = 0;

            for (int i = 0; i < this.paymentDetailList.Count; i++)
            {
                if (this.paymentDetailList[i].Product.Id == productId)
                {
                    productAmount = this.paymentDetailList[i].Quantity;
                    break;
                }
            }

            return productAmount;
        }

        private List<PaymentDetail> getSpecificPaymentDetail(Product.ProductType productType)
        {
            List<PaymentDetail> specificPaymentDetailList = new List<PaymentDetail>();

            for (int i = 0; i < this.paymentDetailList.Count; i++)
            {
                if (this.paymentDetailList[i].Product.Type == productType.ToString())
                {
                    specificPaymentDetailList.Add(this.paymentDetailList[i]);
                }
            }

            return specificPaymentDetailList;
        }

        private void processPayment()
        {
            int receiverId = this.mainForm.getUser().Id;
            string creditCardNumber = this.TextBox_CreditCardNumber.Text;
            double totalPrice = Convert.ToDouble(this.TextBox_GrandTotal.Text);

            Payment newPayment = PaymentManager.processPayment(this.student.Id, receiverId, creditCardNumber, totalPrice);
            if (newPayment != null)
            {
                if (this.processPaymentDetail(newPayment.Id))
                {
                    this.printReceipt(newPayment.Id);
                    MessageBox.Show(PianoForte.Constant.Constant.PAYMENT_SUCCESS);
                    this.reset(true);
                }
                else
                {
                    MessageBox.Show(PianoForte.Constant.Constant.PAYMENT_FAIL);
                }
            }
            else
            {
                MessageBox.Show(PianoForte.Constant.Constant.PAYMENT_FAIL);
            }
        }        

        private bool processPaymentDetail(int paymentId)
        {
            //Dictionary<string, double> totalProductPriceDictionary = new Dictionary<string, double>();
            //totalProductPriceDictionary.Add("TotalCoursePrice", 0);
            //totalProductPriceDictionary.Add("TotalAssignmentBookPrice", 0);
            //totalProductPriceDictionary.Add("TotalBookPrice", 0);
            //totalProductPriceDictionary.Add("TotalCdPrice", 0);
            //totalProductPriceDictionary.Add("TotalFirstRegister", 0);
            //totalProductPriceDictionary.Add("TotalOtherPrice", 0);

            bool isAddComplete = false;

            for (int i = 0; i < this.paymentDetailList.Count; i++)
            {
                PaymentDetail paymentDetail = this.paymentDetailList[i];
                if (paymentDetail != null)
                {
                    paymentDetail.PaymentId = paymentId;

                    isAddComplete = PaymentDetailManager.insertPaymentDetail(paymentDetail);
                    if (isAddComplete)
                    {
                        string productType = paymentDetail.Product.Type;
                        if (productType == Product.ProductType.COURSE.ToString())
                        {
                            Enrollment tempEnrollment = this.courseForm.getEnrollment();
                            if (tempEnrollment != null)
                            {
                                tempEnrollment.PaymentId = paymentId;
                                tempEnrollment.Student = this.student;
                                tempEnrollment.Status = Enrollment.EnrollmentStatus.PAID.ToString();
                                EnrollmentManager.processEnrollment(tempEnrollment); 
                            }

                            if (this.student != null)
                            {
                                this.student.Status = Student.StudentStatus.ACTIVE.ToString();
                                StudentManager.updateStudent(this.student);
                            }
                                                      
                            //totalProductPriceDictionary["TotalCoursePrice"] += (paymentDetail.Product.Price - paymentDetail.Discount);
                        }
                        else if (productType == Product.ProductType.BOOK.ToString())
                        {
                            Book tempBook = BookManager.findBook(paymentDetail.Product.Id);
                            if (tempBook != null)
                            {
                                tempBook.Quantity = tempBook.Quantity - paymentDetail.Quantity;
                                if (tempBook.Quantity == 0)
                                {
                                    tempBook.Status = Book.BookStatus.EMPTY.ToString();
                                }

                                BookManager.updateBook(tempBook);
                            }

                            if (paymentDetail.Product.Id == 2000001)
                            {
                                //totalProductPriceDictionary["TotalAssignmentBookPrice"] += (paymentDetail.Product.Price * paymentDetail.Amount);
                            }
                            else
                            {
                                //totalProductPriceDictionary["TotalBookPrice"] += (paymentDetail.Product.Price * paymentDetail.Amount);
                            }
                        }
                        else if (productType == Product.ProductType.CD.ToString())
                        {
                            Cd tempCd = CdManager.findCd(paymentDetail.Product.Id);
                            if (tempCd != null)
                            {
                                tempCd.Quantity = tempCd.Quantity - paymentDetail.Quantity;
                                if (tempCd.Quantity == 0)
                                {
                                    tempCd.Status = Cd.CdStatus.EMPTY.ToString();
                                }

                                CdManager.updateCd(tempCd);
                            }

                            //totalProductPriceDictionary["TotalCdPrice"] += (paymentDetail.Product.Price * paymentDetail.Amount);
                        }
                        else if (productType == Product.ProductType.OTHER.ToString())
                        {
                            if (paymentDetail.Product.Id == 4000001)
                            {
                                //totalProductPriceDictionary["TotalFirstRegister"] += (paymentDetail.Product.Price * paymentDetail.Amount);
                            }
                            else
                            {
                                //totalProductPriceDictionary["TotalOtherPrice"] += (paymentDetail.Product.Price * paymentDetail.Amount);
                            }
                        }
                    }                    
                }
            }

            return isAddComplete;
        }

        private void processStudent()
        {
            this.student.Status = Student.StudentStatus.ACTIVE.ToString();

            bool isUpdateSuccess = StudentManager.updateStudent(student);
            if (!isUpdateSuccess)
            {
                LogManager.writeLog("Error occur : UPDATE Student failed at PaymentForm.processStudent");
            }
        }

        private void printReceipt(int paymentId)
        {
            if (!ReceiptManager.printReceipt(paymentId))
            {
                MessageBox.Show(PianoForte.Constant.Constant.PRINTER_NOT_FOUND);
            }            
        }

        private void CheckBox_AddFirstRegisterCost_CheckedChanged(object sender, EventArgs e)
        {
            if (this.CheckBox_AddFirstRegisterCost.Checked)
            {
                if (this.firstRegister == null)
                {
                    this.firstRegister = OtherCostManager.findOtherCost(4000001);
                }
                
                if (this.firstRegister != null)
                {
                    Product product = new Product();
                    product.Id = this.firstRegister.Id;
                    product.Type = Product.ProductType.OTHER.ToString();
                    product.Name = this.firstRegister.Name;
                    product.Price = this.firstRegister.Price;

                    PaymentDetail paymentDetail = new PaymentDetail();
                    paymentDetail.Product = product;
                    paymentDetail.Quantity = 1;

                    this.addPaymentDetail(paymentDetail);
                }                
            }            
            else
            {
                this.deletePaymentDetail(this.firstRegister.Id);
            }
        }

        private void DataGridView_PaymentDetail_Summary_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (e.ColumnIndex == 6)
                {
                    if (ConfirmDialogBox.show("Are u sure?"))
                    {
                        int productId = this.paymentDetailList[e.RowIndex].Product.Id;
                        this.deletePaymentDetail(productId);
                    }
                }
            }

            this.Cursor = Cursors.Arrow;
        } 

        private void DataGridView_PaymentDetail_Summary_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.RowIndex >= 0) && (e.ColumnIndex == 6))
            {
                this.Cursor = Cursors.Hand;
            }
        }

        private void DataGridView_PaymentDetail_Summary_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            this.Cursor = Cursors.Arrow;
        }

        private void RadioButton_Cash_CheckedChanged(object sender, EventArgs e)
        {
            this.TextBox_CreditCardNumber.Text = "";
            this.TextBox_CreditCardNumber.Enabled = false;
        }

        private void RadioButton_CreditCard_CheckedChanged(object sender, EventArgs e)
        {
            this.TextBox_CreditCardNumber.Text = "";
            this.TextBox_CreditCardNumber.Enabled = true;
        }

        private void TextBox_CreditCardNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (!ValidateManager.isPressNumber(e))
            {
                e.SuppressKeyPress = true;
            }
        }

        private void TextBox_CreditCardNumber_TextChanged(object sender, EventArgs e)
        {
            //Do Nothing
        }

        private void Button_Pay_Click(object sender, EventArgs e)
        {
            if (RadioButton_CreditCard.Checked)
            {
                if (ValidateManager.validateCreditCardNumber(this.TextBox_CreditCardNumber.Text))
                {
                    this.processPayment();
                }
                else
                {
                    MessageBox.Show(Constant.Constant.INVALID_CREDITCARD_NUMBER);
                }
            }
            else
            {
                string temp = InputDialogBox.show("Cash");
                if (ValidateManager.isNumber(temp))
                {
                    double grandTotal = Convert.ToDouble(this.TextBox_GrandTotal.Text);
                    double receiveMoney = Convert.ToDouble(temp);
                    if (receiveMoney >= grandTotal)
                    {
                        double change = receiveMoney - grandTotal;
                        MessageBox.Show("Change is " + change.ToString());
                        this.processPayment();
                    }
                    else
                    {
                        MessageBox.Show("จำนวนเงินไม่ครบ");
                    }
                }
                else
                {
                    if (temp != "")
                    {
                        MessageBox.Show("กรุณากรอกจำนวนเงินให้ถูกต้อง");
                    }
                }
            }
        }

        private void Button_Reset_Click(object sender, EventArgs e)
        {
            this.reset(true);
        }

        private void Button_Search_Book_Click(object sender, EventArgs e)
        {
            //List<Book> tempBookList = BookManager.findAllBook(Book.BookStatus.AVAILABLE.ToString());
            List<Book> tempBookList = BookManager.findAllBook(Book.BookStatus.AVAILABLE);
            if (tempBookList.Count > 0)
            {
                SearchProductResultForm searchProductResultForm = new SearchProductResultForm();
                searchProductResultForm.showFormDialog(tempBookList);
            }
        }

        private void Button_Search_Cd_Click(object sender, EventArgs e)
        {
            //List<Cd> tempCdList = CdManager.findAllCd(Cd.CdStatus.AVAILABLE.ToString());
            List<Cd> tempCdList = CdManager.findAllCd(Cd.CdStatus.AVAILABLE);
            if (tempCdList.Count > 0)
            {
                SearchProductResultForm searchProductResultForm = new SearchProductResultForm();
                searchProductResultForm.showFormDialog(tempCdList);
            }
        }

        private void Button_Search_Product_Click(object sender, EventArgs e)
        {
            Product product = null;

            string barcode = TextBox_ProductBarcode.Text;

            Course course = null;
            if (course != null)
            {
                // Todo
            } 
            else
            {
                Book book = BookManager.findBookByBarcode(barcode);
                if (book != null)
                {
                    product = new Product();
                    product.Id = book.Id;
                    product.Type = Product.ProductType.BOOK.ToString();
                    product.Name = book.Name;
                    product.Price = book.Price;
                }
                else
                {
                    Cd cd = CdManager.findCdByBarcode(barcode);
                    if (cd != null)
                    {
                        product = new Product();
                        product.Id = cd.Id;
                        product.Type = Product.ProductType.CD.ToString();
                        product.Name = cd.Name;
                        product.Price = cd.Price;
                    }
                }
            }            

            if (product != null)
            {
                if (product.Type == Product.ProductType.COURSE.ToString())
                {
                    // Todo
                } 
                else
                {
                    PaymentDetail paymentDetail = new PaymentDetail();
                    paymentDetail.Product = product;
                    paymentDetail.Quantity = 1;

                    this.addPaymentDetail(paymentDetail);
                }                
            } 
            else
            {
                MessageBox.Show(DatabaseConstant.DATA_NOT_FOUND);
            }
        }                       
    }
}
