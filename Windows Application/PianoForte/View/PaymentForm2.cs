using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using PianoForte.Manager;
using PianoForte.Model;
using PianoForte.Constant;
using System.Globalization;

namespace PianoForte.View
{
    public partial class PaymentForm2 : Form
    {
        private MainForm mainForm;

        private Student student;
        private OtherCost firstRegister;
        private Enrollment enrollment;
        private List<PaymentDetail> paymentDetailList;

        public PaymentForm2()
        {
            InitializeComponent();
        }

        public void load(MainForm mainForm)
        {
            this.mainForm = mainForm;

            this.student = null;            
            this.enrollment = null;
            this.paymentDetailList = new List<PaymentDetail>();

            this.firstRegister = OtherCostManager.findOtherCost(4000001);

            this.initTextBoxPaymentDate();
            this.initPaymentDetailSummaryDataGridView();
        }

        public void reload()
        {
            //Do Nothing
        }

        public void reset()
        {
            //Do Nothing
        }

        public int getProductQuantity(int productId)
        {
            int quantity = 0;

            int numberOfPaymentDetailList = this.paymentDetailList.Count;
            for (int i = 0; i < numberOfPaymentDetailList; i++)
            {
                PaymentDetail paymentDetail = this.paymentDetailList[i];
                if (paymentDetail.Product.Id == productId)
                {
                    quantity = paymentDetail.Quantity;
                    break;
                }
            }

            return quantity;
        }

        public void setStudent(Student student)
        {
            if (student != null)
            {
                this.student = student;

                this.TextBox_StudentNickname.Text = student.Nickname;
                this.TextBox_StudentFullName.Text = student.Firstname + " " + student.Lastname;
                this.TextBox_StudentPhoneNumber.Text = student.Phone1;

                this.TextBox_Barcode.Focus();
            }

            this.updateButtonPay();
        }

        public void updateFocusedTextBox()
        {
            if (this.student == null)
            {
                this.TextBox_StudentId.Focus();
            }
            else
            {
                this.TextBox_Barcode.Focus();
            }
        }

        private bool updateEnrollment(Enrollment enrollment)
        {
            Product product = null;
            double discount = 0;

            if (enrollment != null)
            {
                this.enrollment = enrollment;

                string productName = enrollment.Course.Name;
                if (enrollment.Course.Level != "")
                {
                    productName += " - ";
                    productName += enrollment.Course.Level;
                }

                product = new Product();
                product.Id = enrollment.Course.Id;
                product.Type = Product.ProductType.COURSE.ToString();
                product.Name = productName;
                product.Price = enrollment.TotalPrice;

                discount = enrollment.Discount;
            }

            if (product != null)
            {
                PaymentDetail paymentDetail = new PaymentDetail();
                paymentDetail.Product = product;
                paymentDetail.Quantity = 1;
                paymentDetail.Discount = discount;

                this.addPaymentDetail(paymentDetail);
            }

            return true;
        }

        public bool addPaymentDetail(PaymentDetail paymentDetail)
        {
            bool isSuccess = false;

            int index = this.getPaymentDetailListIndex(paymentDetail.Product.Id);
            if (index >= 0)
            {
                this.paymentDetailList[index].Quantity += paymentDetail.Quantity;
                isSuccess = true;
            }
            else
            {
                int numberOfPaymentDetail = this.paymentDetailList.Count;
                if (numberOfPaymentDetail < 12)
                {
                    this.paymentDetailList.Add(paymentDetail);
                    isSuccess = true;
                }
                else
                {
                    MessageBox.Show(Constant.Constant.OVER_12_ITEMS);
                }
            }

            if (isSuccess)
            {
                if (paymentDetail.Product.Type == Product.ProductType.COURSE.ToString())
                {
                    this.Button_SelectCourse.Enabled = false;
                }

                this.sortPaymentDetailList();
                this.updateDataGridViewPaymentDetailSummary();
                this.updateTextBoxGrandTotal();
            }

            this.updateButtonPay();

            return isSuccess;
        }

        private bool removePaymentDetail(int productId)
        {
            bool isSuccess = false;
            PaymentDetail paymentDetail = null;

            int index = this.getPaymentDetailListIndex(productId);
            if (index >= 0)
            {
                paymentDetail = this.paymentDetailList[index];

                this.paymentDetailList.Remove(this.paymentDetailList[index]);
                isSuccess = true;
            }

            if (isSuccess)
            {
                if (paymentDetail != null)
                {
                    if (paymentDetail.Product.Type == Product.ProductType.COURSE.ToString())
                    {
                        this.enrollment = null;
                        this.Button_SelectCourse.Enabled = true;
                    }
                }

                this.sortPaymentDetailList();
                this.updateDataGridViewPaymentDetailSummary();
                this.updateTextBoxGrandTotal();
            }

            this.updateButtonPay();

            return isSuccess;
        }

        private void reset(bool isResetAll)
        {
            this.student = null;
            this.enrollment = null;
            this.paymentDetailList.Clear();

            this.TextBox_StudentId.Text = "";
            this.TextBox_StudentId.Focus();

            this.CheckBox_AddFirstRegisterCost.Checked = false;

            this.TextBox_StudentNickname.Text = "";
            this.TextBox_StudentFullName.Text = "";
            this.TextBox_StudentPhoneNumber.Text = "";
            this.TextBox_PaymentDate.Text = DateTime.Today.ToShortDateString();

            this.TextBox_Barcode.Text = "";

            this.TextBox_GrandTotalText.Text = "";
            this.TextBox_GrandTotal.Text = "0.00";

            this.TextBox_CreditCardNumber1.Text = "";
            this.TextBox_CreditCardNumber2.Text = "";
            this.TextBox_CreditCardNumber3.Text = "";
            this.TextBox_CreditCardNumber4.Text = "";

            this.RadioButton_Cash.Checked = true;

            this.Button_Pay.Enabled = false;

            this.updateDataGridViewPaymentDetailSummary();
        }

        private void initTextBoxPaymentDate()
        {
            this.TextBox_PaymentDate.Text = DateTime.Today.ToShortDateString();
        }

        private void initPaymentDetailSummaryDataGridView()
        {
            for (int i = 1; i <= 12; i++)
            {
                int n = this.DataGridView_PaymentDetail_Summary.Rows.Add();
                this.DataGridView_PaymentDetail_Summary.Rows[n].Cells["No"].Value = "";
                this.DataGridView_PaymentDetail_Summary.Rows[n].Cells["ItemName"].Value = "";
                this.DataGridView_PaymentDetail_Summary.Rows[n].Cells["Quantity"].Value = "";
                this.DataGridView_PaymentDetail_Summary.Rows[n].Cells["Discount"].Value = "";
                this.DataGridView_PaymentDetail_Summary.Rows[n].Cells["Price"].Value = "";
                this.DataGridView_PaymentDetail_Summary.Rows[n].Cells["TotalPrice"].Value = "";               
            }
        }

        private void resetPaymentDetailSummaryDataGridView()
        {
            for (int i = 0; i < 12; i++)
            {
                this.DataGridView_PaymentDetail_Summary.Rows[i].Cells["No"].Value = "";
                this.DataGridView_PaymentDetail_Summary.Rows[i].Cells["ItemName"].Value = "";
                this.DataGridView_PaymentDetail_Summary.Rows[i].Cells["Quantity"].Value = "";
                this.DataGridView_PaymentDetail_Summary.Rows[i].Cells["Discount"].Value = "";
                this.DataGridView_PaymentDetail_Summary.Rows[i].Cells["Price"].Value = "";
                this.DataGridView_PaymentDetail_Summary.Rows[i].Cells["TotalPrice"].Value = "";
            }
        }

        private void updateDataGridViewPaymentDetailSummary()
        {
            int numberOfPaymentDetailList = this.paymentDetailList.Count;

            for (int i = 0; i < 12; i++)
            {
                if (i < numberOfPaymentDetailList)
                {
                    PaymentDetail paymentDetail = this.paymentDetailList[i];
                    Product product = paymentDetail.Product;

                    this.DataGridView_PaymentDetail_Summary.Rows[i].Cells["No"].Value = i + 1;
                    this.DataGridView_PaymentDetail_Summary.Rows[i].Cells["ItemName"].Value = product.Name;
                    this.DataGridView_PaymentDetail_Summary.Rows[i].Cells["Quantity"].Value = paymentDetail.Quantity;
                    this.DataGridView_PaymentDetail_Summary.Rows[i].Cells["Discount"].Value = paymentDetail.Discount;
                    this.DataGridView_PaymentDetail_Summary.Rows[i].Cells["Price"].Value = product.Price;
                    this.DataGridView_PaymentDetail_Summary.Rows[i].Cells["TotalPrice"].Value = (product.Price * paymentDetail.Quantity) - paymentDetail.Discount;

                    ((DataGridViewImageCell)this.DataGridView_PaymentDetail_Summary.Rows[i].Cells["DeleteButton"]).Value = PianoForte.Properties.Resources.Delete;
                }
                else
                {
                    this.DataGridView_PaymentDetail_Summary.Rows[i].Cells["No"].Value = "";
                    this.DataGridView_PaymentDetail_Summary.Rows[i].Cells["ItemName"].Value = "";
                    this.DataGridView_PaymentDetail_Summary.Rows[i].Cells["Quantity"].Value = "";
                    this.DataGridView_PaymentDetail_Summary.Rows[i].Cells["Discount"].Value = "";
                    this.DataGridView_PaymentDetail_Summary.Rows[i].Cells["Price"].Value = "";
                    this.DataGridView_PaymentDetail_Summary.Rows[i].Cells["TotalPrice"].Value = "";

                    ((DataGridViewImageCell)this.DataGridView_PaymentDetail_Summary.Rows[i].Cells["DeleteButton"]).Value = PianoForte.Properties.Resources.Empty;
                }
            }
        }

        private void updateTextBoxGrandTotal()
        {
            double grandTotalPrice = 0;

            int numberOfPaymentDetailList = this.paymentDetailList.Count;

            for (int i = 0; i < numberOfPaymentDetailList; i++)
            {
                PaymentDetail paymentDetail = this.paymentDetailList[i];
                Product product = paymentDetail.Product;

                grandTotalPrice += ((product.Price * paymentDetail.Quantity) - paymentDetail.Discount);
            }

            this.TextBox_GrandTotal.Text = grandTotalPrice.ToString("N", new CultureInfo("en-US"));

            if (grandTotalPrice > 0)
            {
                this.TextBox_GrandTotalText.Text = ConvertManager.toBahtText(grandTotalPrice);
            }
            else
            {
                this.TextBox_GrandTotalText.Text = "";
            }
        }

        private void searchStudent(int studentId)
        {
            Student searchedStudent = StudentManager.findStudent(studentId);

            this.TextBox_StudentNickname.Text = "";
            this.TextBox_StudentFullName.Text = "";
            this.TextBox_StudentPhoneNumber.Text = "";

            setStudent(searchedStudent);
        }        

        private void searchProduct(string barcode)
        {
            Product product = null;
            bool isCourse = false;
            int courseIndex = -1;

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
                else
                {
                    if (ValidateManager.isNumber(barcode) == true)
                    {
                        OtherCost otherProduct = OtherCostManager.findOtherCost(Convert.ToInt32(barcode));
                        if (otherProduct != null)
                        {
                            product = new Product();
                            product.Id = otherProduct.Id;
                            product.Type = Product.ProductType.OTHER.ToString();
                            product.Name = otherProduct.Name;
                            product.Price = otherProduct.Price;
                        }
                        else
                        {
                            Course course = CourseManager.findCourse(Convert.ToInt32(barcode));
                            if (course != null)
                            {
                                isCourse = true;
                                courseIndex = this.getCourseIndexInPaymentDetailList();
                                if (courseIndex == -1)
                                {
                                    EnrollmentPopUp enrollmentPopUp = new EnrollmentPopUp();
                                    Enrollment enrollment = enrollmentPopUp.showFormDialog(this, course);
                                    if (enrollment != null)
                                    {
                                        this.updateEnrollment(enrollment);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("ไม่สามารถเพิ่มวิชาเรียนมากกว่า 1 วิชาได้");
                                }
                            }
                        }
                    }
                }
            }

            if (product != null)
            {
                if (product.Type != Product.ProductType.COURSE.ToString())
                {
                    PaymentDetail paymentDetail = new PaymentDetail();
                    paymentDetail.Product = product;
                    paymentDetail.Quantity = 1;

                    this.addPaymentDetail(paymentDetail);
                }
            }
            else
            {
                if (isCourse == false)
                {
                    if (courseIndex == -1)
                    {
                        MessageBox.Show(DatabaseConstant.DATA_NOT_FOUND);
                    }
                }
            }

            this.TextBox_Barcode.Text = "";
            this.TextBox_Barcode.Focus();
        }        

        private int getCourseIndexInPaymentDetailList()
        {
            int courseIndex = -1;
            int numberOfPaymentDetailList = this.paymentDetailList.Count;

            for (int i = 0; i < numberOfPaymentDetailList; i++)
            {
                if (this.paymentDetailList[i].Product.Type == Product.ProductType.COURSE.ToString())
                {
                    courseIndex = i;
                    break;
                }
            }

            return courseIndex;
        }

        private int getPaymentDetailListIndex(int productId)
        {
            int index = -1;
            int numberOfPaymentDetailList = this.paymentDetailList.Count;

            for (int i = 0; i < numberOfPaymentDetailList; i++)
            {
                if (this.paymentDetailList[i].Product.Id == productId)
                {
                    index = i;
                    break;
                }
            }

            return index;
        }

        private void sortPaymentDetailList()
        {
            int numberOfPaymentDetailList = this.paymentDetailList.Count;
            for (int i = 0; i < numberOfPaymentDetailList; i++)
            {
                for (int j = i + 1; j < numberOfPaymentDetailList; j++)
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

        private void updateButtonPay()
        {
            bool isEnableButtonPay = false;

            if ((this.student != null) && (this.paymentDetailList.Count > 0))
            {
                if (this.RadioButton_CreditCard.Checked == true)
                {
                    string creditCardNumber = this.getCreditCardNumber();
                    
                    if (ValidateManager.validateCreditCardNumber(creditCardNumber) == true)
                    {
                        isEnableButtonPay = true;
                    }
                }
                else
                {
                    isEnableButtonPay = true;
                }
            }

            if (isEnableButtonPay == true)
            {
                this.Button_Pay.Enabled = true;
            }
            else
            {
                this.Button_Pay.Enabled = false;
            }
        }

        private string getCreditCardNumber()
        {
            string creditCardNumber = "";
            string creditCardNumber1 = this.TextBox_CreditCardNumber1.Text;
            string creditCardNumber2 = this.TextBox_CreditCardNumber2.Text;
            string creditCardNumber3 = this.TextBox_CreditCardNumber3.Text;
            string creditCardNumber4 = this.TextBox_CreditCardNumber4.Text;

            if ((creditCardNumber1 != "") && (creditCardNumber2 != "") && (creditCardNumber3 != "") && (creditCardNumber4 != ""))
            {
                creditCardNumber += creditCardNumber1;
                creditCardNumber += creditCardNumber2;
                creditCardNumber += creditCardNumber3;
                creditCardNumber += creditCardNumber4;
            }

            return creditCardNumber;
        }

        private double getGrandTotalPrice()
        {            
            string grandTotalText = this.TextBox_GrandTotal.Text.Replace(",", "");

            return Convert.ToDouble(grandTotalText);
        }

        private void processPayment(string creditCardNumber, double grandTotalPrice)
        {
            int receiverId = this.mainForm.getUser().Id;

            Payment newPayment = PaymentManager.processPayment(this.student.Id, receiverId, creditCardNumber, grandTotalPrice);
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
                            if (this.enrollment != null)
                            {
                                this.enrollment.PaymentId = paymentId;
                                this.enrollment.Student = this.student;
                                this.enrollment.Status = Enrollment.EnrollmentStatus.PAID.ToString();
                                EnrollmentManager.processEnrollment(this.enrollment);
                            }

                            if (this.student != null)
                            {
                                if (this.student.Status != Student.StudentStatus.ACTIVE.ToString())
                                {
                                    this.student.Status = Student.StudentStatus.ACTIVE.ToString();
                                    StudentManager.updateStudent(this.student);
                                }                                
                            }
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
                        }
                        else if (productType == Product.ProductType.OTHER.ToString())
                        {
                            // Do Nothing
                        }
                    }
                }
            }

            return isAddComplete;
        }

        private void printReceipt(int paymentId)
        {
            if (!ReceiptManager.printReceipt(paymentId))
            {
                MessageBox.Show(PianoForte.Constant.Constant.PRINTER_NOT_FOUND);
            }
        }

        private void TextBox_StudentId_KeyDown(object sender, KeyEventArgs e)
        {
            if (!ValidateManager.isPressNumber(e))
            {
                e.SuppressKeyPress = true;
            }
        }

        private void TextBox_StudentId_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                string text = this.TextBox_StudentId.Text;
                
                if (text != "")
                {
                    int studentId = Convert.ToInt32(text);
                    this.searchStudent(studentId);
                }                
            }
        }

        private void Button_SerachStudent_Click(object sender, EventArgs e)
        {
            string text = this.TextBox_StudentId.Text;

            if (text != "")
            {
                int studentId = Convert.ToInt32(text);
                this.searchStudent(studentId);
            }
        }

        private void TextBox_Barcode_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                string barcode = this.TextBox_Barcode.Text;

                if (barcode != "")
                {
                    this.searchProduct(barcode);
                }
            }
        }

        private void Button_SearchBarcode_Click(object sender, EventArgs e)
        {
            string barcode = this.TextBox_Barcode.Text;

            if (barcode != "")
            {
                this.searchProduct(barcode);
            }
        }

        private void DataGridView_PaymentDetail_Summary_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            int numberOfPaymentDetailList = this.paymentDetailList.Count;
            if (numberOfPaymentDetailList > 0)
            {
                int rowIndex = e.RowIndex;
                if ((rowIndex >= 0) && (rowIndex < numberOfPaymentDetailList))
                {
                    if (e.ColumnIndex == 6)
                    {
                        this.Cursor = Cursors.Hand;
                    }
                }
            }            
        }

        private void DataGridView_PaymentDetail_Summary_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            this.Cursor = Cursors.Arrow;
        }

        private void DataGridView_PaymentDetail_Summary_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int numberOfPaymentDetailList = this.paymentDetailList.Count;
            if (numberOfPaymentDetailList > 0)
            {
                int rowIndex = e.RowIndex;
                if ((rowIndex >= 0) && (rowIndex < numberOfPaymentDetailList))
                {
                    if (e.ColumnIndex == 6)
                    {
                        if (ConfirmDialogBox.show("คุณต้องการลบรายการนี้?"))
                        {
                            int productId = this.paymentDetailList[e.RowIndex].Product.Id;
                            this.removePaymentDetail(productId);
                        }
                    }
                }
            }

            this.Cursor = Cursors.Arrow;
        }

        private void DataGridView_PaymentDetail_Summary_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int numberOfPaymentDetailList = this.paymentDetailList.Count;
            if (numberOfPaymentDetailList > 0)
            {
                int rowIndex = e.RowIndex;
                if ((rowIndex >= 0) && (rowIndex < numberOfPaymentDetailList))
                {
                    PaymentDetail paymentDetail = this.paymentDetailList[rowIndex];

                    if (paymentDetail.Product.Type == Product.ProductType.COURSE.ToString())
                    {
                        EnrollmentPopUp enrollmentPopup = new EnrollmentPopUp();
                        Enrollment enrollment = enrollmentPopup.showFormDialog(this, this.enrollment);

                        if (enrollment != null)
                        {
                            this.removePaymentDetail(enrollment.Course.Id);
                            this.updateEnrollment(enrollment);
                        }
                    }
                }
            }

            this.Cursor = Cursors.Arrow;
        }

        private void RadioButton_Cash_CheckedChanged(object sender, EventArgs e)
        {
            this.TextBox_CreditCardNumber1.Text = "";
            this.TextBox_CreditCardNumber2.Text = "";
            this.TextBox_CreditCardNumber3.Text = "";
            this.TextBox_CreditCardNumber4.Text = "";

            this.TextBox_CreditCardNumber1.Enabled = false;
            this.TextBox_CreditCardNumber2.Enabled = false;
            this.TextBox_CreditCardNumber3.Enabled = false;
            this.TextBox_CreditCardNumber4.Enabled = false;
        }

        private void RadioButton_CreditCard_CheckedChanged(object sender, EventArgs e)
        {
            this.TextBox_CreditCardNumber1.Enabled = true;
            this.TextBox_CreditCardNumber2.Enabled = true;
            this.TextBox_CreditCardNumber3.Enabled = true;
            this.TextBox_CreditCardNumber4.Enabled = true;

            this.TextBox_CreditCardNumber1.Focus();
        }

        private void TextBox_CreditCardNumber1_KeyDown(object sender, KeyEventArgs e)
        {
            if (!ValidateManager.isPressNumber(e))
            {
                e.SuppressKeyPress = true;
            }
        }         

        private void TextBox_CreditCardNumber1_TextChanged(object sender, EventArgs e)
        {
            int textLength = this.TextBox_CreditCardNumber1.Text.Length;

            if (textLength == 4)
            {
                this.TextBox_CreditCardNumber2.Focus();
            }
        }

        private void TextBox_CreditCardNumber2_KeyDown(object sender, KeyEventArgs e)
        {
            if (!ValidateManager.isPressNumber(e))
            {
                e.SuppressKeyPress = true;
            }
        }        

        private void TextBox_CreditCardNumber2_TextChanged(object sender, EventArgs e)
        {
            int textLength = this.TextBox_CreditCardNumber2.Text.Length;

            if (textLength == 4)
            {
                this.TextBox_CreditCardNumber3.Focus();
            }
        }

        private void TextBox_CreditCardNumber3_KeyDown(object sender, KeyEventArgs e)
        {
            if (!ValidateManager.isPressNumber(e))
            {
                e.SuppressKeyPress = true;
            }
        }        

        private void TextBox_CreditCardNumber3_TextChanged(object sender, EventArgs e)
        {
            int textLength = this.TextBox_CreditCardNumber3.Text.Length;

            if (textLength == 4)
            {
                this.TextBox_CreditCardNumber4.Focus();
            }
        }

        private void TextBox_CreditCardNumber4_KeyDown(object sender, KeyEventArgs e)
        {
            if (!ValidateManager.isPressNumber(e))
            {
                e.SuppressKeyPress = true;
            }
        }

        private void TextBox_CreditCardNumber4_TextChanged(object sender, EventArgs e)
        {
            int textLength = this.TextBox_CreditCardNumber4.Text.Length;

            if (textLength == 4)
            {
                this.Button_Pay.Focus();
            }
        }

        private void Button_Pay_Click(object sender, EventArgs e)
        {
            double grandTotalPrice = getGrandTotalPrice();

            if (this.RadioButton_CreditCard.Checked)
            {
                string creditCardNumber = this.getCreditCardNumber();

                if (ValidateManager.validateCreditCardNumber(creditCardNumber))
                {
                    this.processPayment(creditCardNumber, grandTotalPrice);
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
                    double receiveMoney = Convert.ToDouble(temp);
                    if (receiveMoney >= grandTotalPrice)
                    {
                        double change = receiveMoney - grandTotalPrice;
                        MessageBox.Show("Change is " + change.ToString());
                        this.processPayment("", grandTotalPrice);
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
            this.updateDataGridViewPaymentDetailSummary();
        }

        private void Button_SelectCourse_Click(object sender, EventArgs e)
        {
            EnrollmentPopUp enrollmentPopUp = new EnrollmentPopUp();
            Enrollment enrollment = enrollmentPopUp.showFormDialog(this);

            this.updateEnrollment(enrollment);
        }

        private void Button_SelectBook_Click(object sender, EventArgs e)
        {
            SearchBookPopUp searchBookPopUp = new SearchBookPopUp();
            searchBookPopUp.showFormDialog(this);
        }

        private void Button_SelectCD_Click(object sender, EventArgs e)
        {
            SearchCDPopUp searchCDPopUp = new SearchCDPopUp();
            searchCDPopUp.showFormDialog(this);
        }

        private void Button_AddOther_Click(object sender, EventArgs e)
        {
            AddOtherProductPopUp addOtherProductPopUp = new AddOtherProductPopUp();

            OtherCost otherProduct = addOtherProductPopUp.showFormDialog();
            if (otherProduct != null)
            {
                Product product = new Product();
                product.Id = otherProduct.Id;
                product.Type = Product.ProductType.OTHER.ToString();
                product.Name = otherProduct.Name;
                product.Price = otherProduct.Price;

                PaymentDetail paymentDetail = new PaymentDetail();
                paymentDetail.Product = product;
                paymentDetail.Quantity = 1;

                this.addPaymentDetail(paymentDetail);
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
                this.removePaymentDetail(this.firstRegister.Id);
            }
        }                                              
    }
}
