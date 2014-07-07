using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Excel = Microsoft.Office.Interop.Excel;

using PianoForte.Constant;
using PianoForte.Manager;
using PianoForte.Model;
using PianoForte.View;

namespace PianoForte.Manager
{
    class ExportManager
    {
        private List<string> excelColumnIndexList = new List<string>() { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "AA", "AB", "AC", "AD", "AE", "AF", "AG", "AH", "AI"};

        public bool createMonthlyIncomeSummary(string filename, List<Payment> paymentList)
        {
            Excel.Application excelApplication;
            Excel.Workbook excelWorkBook;
            Excel.Worksheet excelWorkSheet;
            object missingValue = System.Reflection.Missing.Value;

            excelApplication = new Excel.ApplicationClass();
            excelWorkBook = excelApplication.Workbooks.Add(missingValue);

            excelWorkSheet = (Excel.Worksheet)excelWorkBook.Worksheets.get_Item(1);
            this.createMonthlyIncomeSummaryHeader(excelWorkSheet);
            this.createMonthlyIncomeSummaryDetail(excelWorkSheet, paymentList);
            string savePathName = PianoForte.Constant.Constant.STARTUP_PATH + "\\Account\\" + filename + ".xls";

            excelWorkBook.SaveAs(savePathName, Excel.XlFileFormat.xlWorkbookNormal, missingValue, missingValue, missingValue, missingValue, Excel.XlSaveAsAccessMode.xlExclusive, missingValue, missingValue, missingValue, missingValue, missingValue);
            excelWorkBook.Close(true, missingValue, missingValue);
            excelApplication.Quit();

            this.releaseObject(excelWorkSheet);
            this.releaseObject(excelWorkBook);
            this.releaseObject(excelApplication);

            return true;
        }

        private void createMonthlyIncomeSummaryHeader(Excel.Worksheet excelWorkSheet)
        {
            this.addCellHeader(excelWorkSheet, "A1", "A1", 15, "วัน/เดือน/ปี");
            this.addCellHeader(excelWorkSheet, "B1", "B1", 15, "ค่าวิชาเรียน");
            this.addCellHeader(excelWorkSheet, "C1", "C1", 15, "ค่าหนังสือเรียน");
            this.addCellHeader(excelWorkSheet, "D1", "D1", 15, "ค่าสมุดการบ้าน");
            this.addCellHeader(excelWorkSheet, "E1", "E1", 15, "ค่าสมัครแรกเข้า");
            this.addCellHeader(excelWorkSheet, "F1", "F1", 15, "ค่าซีดี");
            this.addCellHeader(excelWorkSheet, "G1", "G1", 15, "อื่นๆ");
            this.addCellHeader(excelWorkSheet, "H1", "H1", 15, "เงินสด");
            this.addCellHeader(excelWorkSheet, "I1", "I1", 15, "บัตรเครดิต");
        }

        private void createMonthlyIncomeSummaryDetail(Excel.Worksheet excelWorkSheet, List<Payment> paymentList)
        {
            double grandTotalCoursePrice = 0;
            double grandTotalBookPrice = 0;
            double grandTotalAssignmentBookPrice = 0;
            double grandTotalFirstRegister = 0;
            double grandTotalCDPrice = 0;
            double grandTotalOtherPrice = 0;
            double grandTotalCash = 0;
            double grandTotalCreditcard = 0;

            int index = 0;
            Dictionary<DateTime, DailyIncome> dailyIncomeDictionary = PaymentManager.generateDailyIncome(paymentList);
            foreach (var pair in dailyIncomeDictionary)
            {
                MainForm.dailyPaymentReportForm.monthlyIncomeSummary.ReportProgress((index * 100) / dailyIncomeDictionary.Count, ProgressBarManager.ProgressBarState.CREATE_FILE); 

                DailyIncome dailyReceiptSummary = pair.Value;
                if (dailyReceiptSummary != null)
                {
                    this.addCellData(excelWorkSheet, "A" + (index + 2).ToString(), "A" + (index + 2).ToString(), Excel.XlHAlign.xlHAlignCenter, pair.Key.ToShortDateString(), "DD/MM/YYYY", false, false, false, true, true);
                    this.addCellData(excelWorkSheet, "B" + (index + 2).ToString(), "B" + (index + 2).ToString(), Excel.XlHAlign.xlHAlignRight, dailyReceiptSummary.TotalCoursePrice.ToString(), "#,##0", false, false, false, false, true);
                    this.addCellData(excelWorkSheet, "C" + (index + 2).ToString(), "C" + (index + 2).ToString(), Excel.XlHAlign.xlHAlignRight, dailyReceiptSummary.TotalBookPrice.ToString(), "#,##0", false, false, false, false, true);
                    this.addCellData(excelWorkSheet, "D" + (index + 2).ToString(), "D" + (index + 2).ToString(), Excel.XlHAlign.xlHAlignRight, dailyReceiptSummary.TotalAssignmentBookPrice.ToString(), "#,##0", false, false, false, false, true);
                    this.addCellData(excelWorkSheet, "E" + (index + 2).ToString(), "E" + (index + 2).ToString(), Excel.XlHAlign.xlHAlignRight, dailyReceiptSummary.TotalFirstRegister.ToString(), "#,##0", false, false, false, false, true);
                    this.addCellData(excelWorkSheet, "F" + (index + 2).ToString(), "F" + (index + 2).ToString(), Excel.XlHAlign.xlHAlignRight, dailyReceiptSummary.TotalCdPrice.ToString(), "#,##0", false, false, false, false, true);
                    this.addCellData(excelWorkSheet, "G" + (index + 2).ToString(), "G" + (index + 2).ToString(), Excel.XlHAlign.xlHAlignRight, dailyReceiptSummary.TotalOtherPrice.ToString(), "#,##0", false, false, false, false, true);
                    this.addCellData(excelWorkSheet, "H" + (index + 2).ToString(), "H" + (index + 2).ToString(), Excel.XlHAlign.xlHAlignRight, dailyReceiptSummary.TotalCash.ToString(), "#,##0", false, false, false, false, true);
                    this.addCellData(excelWorkSheet, "I" + (index + 2).ToString(), "I" + (index + 2).ToString(), Excel.XlHAlign.xlHAlignRight, dailyReceiptSummary.TotalCreditcard.ToString(), "#,##0", false, false, false, false, true);

                    grandTotalCoursePrice += dailyReceiptSummary.TotalCoursePrice;
                    grandTotalBookPrice += dailyReceiptSummary.TotalBookPrice;
                    grandTotalAssignmentBookPrice += dailyReceiptSummary.TotalAssignmentBookPrice;
                    grandTotalFirstRegister += dailyReceiptSummary.TotalFirstRegister;
                    grandTotalCDPrice += dailyReceiptSummary.TotalCdPrice;
                    grandTotalOtherPrice += dailyReceiptSummary.TotalOtherPrice;
                    grandTotalCash += dailyReceiptSummary.TotalCash;
                    grandTotalCreditcard += dailyReceiptSummary.TotalCreditcard;
                }
                index++;
            }

            //int rowNumber = index + 2;
            this.addCellData(excelWorkSheet, "A" + (index + 2).ToString(), "A" + (index + 2).ToString(), Excel.XlHAlign.xlHAlignRight, "รวมทั้งสิ้น", true, true, false, false, false);
            this.addCellData(excelWorkSheet, "B" + (index + 2).ToString(), "B" + (index + 2).ToString(), Excel.XlHAlign.xlHAlignRight, grandTotalCoursePrice.ToString(), "#,##0", true, true, true, true, true);
            this.addCellData(excelWorkSheet, "C" + (index + 2).ToString(), "C" + (index + 2).ToString(), Excel.XlHAlign.xlHAlignRight, grandTotalBookPrice.ToString(), "#,##0", true, true, true, true, true);
            this.addCellData(excelWorkSheet, "D" + (index + 2).ToString(), "D" + (index + 2).ToString(), Excel.XlHAlign.xlHAlignRight, grandTotalAssignmentBookPrice.ToString(), "#,##0", true, true, true, true, true);
            this.addCellData(excelWorkSheet, "E" + (index + 2).ToString(), "E" + (index + 2).ToString(), Excel.XlHAlign.xlHAlignRight, grandTotalFirstRegister.ToString(), "#,##0", true, true, true, true, true);
            this.addCellData(excelWorkSheet, "F" + (index + 2).ToString(), "F" + (index + 2).ToString(), Excel.XlHAlign.xlHAlignRight, grandTotalCDPrice.ToString(), "#,##0", true, true, true, true, true);
            this.addCellData(excelWorkSheet, "G" + (index + 2).ToString(), "G" + (index + 2).ToString(), Excel.XlHAlign.xlHAlignRight, grandTotalOtherPrice.ToString(), "#,##0", true, true, true, true, true);
            this.addCellData(excelWorkSheet, "H" + (index + 2).ToString(), "H" + (index + 2).ToString(), Excel.XlHAlign.xlHAlignRight, grandTotalCash.ToString(), "#,##0", true, true, true, true, true);
            this.addCellData(excelWorkSheet, "I" + (index + 2).ToString(), "I" + (index + 2).ToString(), Excel.XlHAlign.xlHAlignRight, grandTotalCreditcard.ToString(), "#,##0", true, true, true, true, true);
        }

        public bool createCourseIncomeSummary(string filename, List<Enrollment> enrollmentList)
        {
            Excel.Application excelApplication;
            Excel.Workbook excelWorkBook;
            Excel.Worksheet excelWorkSheet;
            object missingValue = System.Reflection.Missing.Value;

            excelApplication = new Excel.ApplicationClass();
            excelWorkBook = excelApplication.Workbooks.Add(missingValue);

            excelWorkSheet = (Excel.Worksheet)excelWorkBook.Worksheets.get_Item(1);
            int commonYear = getYearOfMostClassroomStartDate(enrollmentList);

            this.createCourseIncomeSummaryHeader(excelWorkSheet, commonYear);
            this.createCourseIncomeSummaryDetail(excelWorkSheet, enrollmentList);            

            string savePathName = PianoForte.Constant.Constant.STARTUP_PATH + "\\Account\\" + filename + ".xls";

            excelWorkBook.SaveAs(savePathName, Excel.XlFileFormat.xlWorkbookNormal, missingValue, missingValue, missingValue, missingValue, Excel.XlSaveAsAccessMode.xlExclusive, missingValue, missingValue, missingValue, missingValue, missingValue);
            excelWorkBook.Close(true, missingValue, missingValue);
            excelApplication.Quit();

            this.releaseObject(excelWorkSheet);
            this.releaseObject(excelWorkBook);
            this.releaseObject(excelApplication);

            return true;
        }

        private void createCourseIncomeSummaryHeader(Excel.Worksheet excelWorkSheet, int commonYear)
        {
            this.addCellHeader(excelWorkSheet, "A1", "A2", 10, "ลำดับที่");
            this.addCellHeader(excelWorkSheet, "B1", "B2", 10, "รหัสนักเรียน");
            this.addCellHeader(excelWorkSheet, "C1", "C2", 40, "วิชา");
            this.addCellHeader(excelWorkSheet, "D1", "D2", 10, "ค่าวิชาเรียน");
            this.addCellHeader(excelWorkSheet, "E1", "E2", 10, "เลขที่ใบเสร็จ");
            this.addCellHeader(excelWorkSheet, "F1", "H1", 15, "วันที่เริ่มเรียน");
            this.addCellHeader(excelWorkSheet, "F2", "F2", 5, "วัน");
            this.addCellHeader(excelWorkSheet, "G2", "G2", 5, "เดือน");
            this.addCellHeader(excelWorkSheet, "H2", "H2", 5, "ปี");
            this.addCellHeader(excelWorkSheet, "I1", "J1", 20, (commonYear - 1).ToString());
            this.addCellHeader(excelWorkSheet, "I2", "I2", 10, "NOV");
            this.addCellHeader(excelWorkSheet, "J2", "J2", 10, "DEC");
            this.addCellHeader(excelWorkSheet, "K1", "V1", 120, commonYear.ToString());
            this.addCellHeader(excelWorkSheet, "K2", "K2", 10, "JAN");
            this.addCellHeader(excelWorkSheet, "L2", "L2", 10, "FEB");
            this.addCellHeader(excelWorkSheet, "M2", "M2", 10, "MAR");
            this.addCellHeader(excelWorkSheet, "N2", "N2", 10, "APR");
            this.addCellHeader(excelWorkSheet, "O2", "O2", 10, "MAY");
            this.addCellHeader(excelWorkSheet, "P2", "P2", 10, "JUN");
            this.addCellHeader(excelWorkSheet, "Q2", "Q2", 10, "JUL");
            this.addCellHeader(excelWorkSheet, "R2", "R2", 10, "AUG");
            this.addCellHeader(excelWorkSheet, "S2", "S2", 10, "SEP");
            this.addCellHeader(excelWorkSheet, "T2", "T2", 10, "OCT");
            this.addCellHeader(excelWorkSheet, "U2", "U2", 10, "NOV");
            this.addCellHeader(excelWorkSheet, "V2", "V2", 10, "DEC");
            this.addCellHeader(excelWorkSheet, "W1", "Y1", 20, (commonYear + 1).ToString());
            this.addCellHeader(excelWorkSheet, "W2", "W2", 10, "JAN");
            this.addCellHeader(excelWorkSheet, "X2", "X2", 10, "FEB");
            this.addCellHeader(excelWorkSheet, "Y2", "Y2", 10, "MAR");
        }        

        private void createCourseIncomeSummaryDetail(Excel.Worksheet excelWorkSheet, List<Enrollment> enrollmentList)
        {
            Dictionary<string, double> totalIncomeDictionary = new Dictionary<string, double>();
            totalIncomeDictionary.Add("D", 0);
            for (int i = 8; i < excelColumnIndexList.Count; i++)
            {
                totalIncomeDictionary.Add(excelColumnIndexList[i], 0);
            }

            for (int i = 0; i < enrollmentList.Count; i++)
            {
                MainForm.dailyPaymentReportForm.courseIncomeSummary.ReportProgress((i * 100) / enrollmentList.Count, ProgressBarManager.ProgressBarState.CREATE_FILE); 

                Enrollment tempEnrollment = enrollmentList[i];
                if (tempEnrollment != null)
                {
                    bool isLastRow = false;
                    if (i == (enrollmentList.Count - 1))
                    {
                        isLastRow = true;
                    }

                    double totalCoursePrice = 0;

                    Payment tempPayment = PaymentManager.findPayment(tempEnrollment.PaymentId);
                    if (tempPayment != null)
                    {
                        List<PaymentDetail> tempPaymentDetailList = PaymentDetailManager.findAllPaymentDetail(tempPayment.Id);
                        for (int j = 0; j < tempPaymentDetailList.Count; j++)
                        {
                            PaymentDetail tempPaymentDetail = tempPaymentDetailList[j];
                            if (tempPaymentDetail != null)
                            {
                                if (tempPaymentDetail.Product.Type == Product.ProductType.COURSE.ToString())
                                {
                                    totalCoursePrice = (tempPaymentDetail.Product.Price * tempPaymentDetail.Quantity) - tempPaymentDetail.Discount;
                                    break;
                                }
                            }
                        }
                    }

                    List<Classroom> tempClassroomList = ClassroomManager.findAllClassroom(tempEnrollment.Id);
                    if (tempClassroomList.Count > 0)
                    {
                        string courseName = this.getCourseName(tempEnrollment);
                        string classStartDay = this.getDay(tempClassroomList[0].StartDate);
                        string classStartMonth = this.getMonth(tempClassroomList[0].StartDate);
                        string classStartYear = this.getYear(tempClassroomList[0].StartDate);
                        double dividedTotalPrice = totalCoursePrice / 3;
                        this.addCellData(excelWorkSheet, "A" + (i + 3).ToString(), "A" + (i + 3).ToString(), Excel.XlHAlign.xlHAlignCenter, (i + 1).ToString(), false, false, isLastRow, true, true);
                        this.addCellData(excelWorkSheet, "B" + (i + 3).ToString(), "B" + (i + 3).ToString(), Excel.XlHAlign.xlHAlignCenter, tempEnrollment.Student.Id.ToString(), false, false, isLastRow, false, true);
                        this.addCellData(excelWorkSheet, "C" + (i + 3).ToString(), "C" + (i + 3).ToString(), Excel.XlHAlign.xlHAlignLeft, courseName, false, false, isLastRow, false, true);
                        this.addCellData(excelWorkSheet, "D" + (i + 3).ToString(), "D" + (i + 3).ToString(), Excel.XlHAlign.xlHAlignRight, totalCoursePrice.ToString(), "#,##0", false, false, isLastRow, false, true);
                        this.addCellData(excelWorkSheet, "E" + (i + 3).ToString(), "E" + (i + 3).ToString(), Excel.XlHAlign.xlHAlignCenter, tempEnrollment.PaymentId.ToString(), false, false, isLastRow, false, true);
                        this.addCellData(excelWorkSheet, "F" + (i + 3).ToString(), "F" + (i + 3).ToString(), Excel.XlHAlign.xlHAlignCenter, classStartDay, false, false, isLastRow, false, true);
                        this.addCellData(excelWorkSheet, "G" + (i + 3).ToString(), "G" + (i + 3).ToString(), Excel.XlHAlign.xlHAlignCenter, classStartMonth, false, false, isLastRow, false, true);
                        this.addCellData(excelWorkSheet, "H" + (i + 3).ToString(), "H" + (i + 3).ToString(), Excel.XlHAlign.xlHAlignCenter, classStartYear, false, false, isLastRow, false, true);

                        totalIncomeDictionary["D"] += totalCoursePrice;

                        string columnIndex = this.getColumnIndexForCourseIncomeSummary(tempClassroomList[0].StartDate.Month);
                        for (int j = 8; j < excelColumnIndexList.Count - 10; )
                        {
                            if (excelColumnIndexList[j] == columnIndex)
                            {
                                this.addCellData(excelWorkSheet, excelColumnIndexList[j] + (i + 3).ToString(), excelColumnIndexList[j] + (i + 3).ToString(), Excel.XlHAlign.xlHAlignCenter, dividedTotalPrice.ToString(), "#,##0", false, false, isLastRow, false, true);
                                totalIncomeDictionary[excelColumnIndexList[j]] += dividedTotalPrice;
                                j++;
                                this.addCellData(excelWorkSheet, excelColumnIndexList[j] + (i + 3).ToString(), excelColumnIndexList[j] + (i + 3).ToString(), Excel.XlHAlign.xlHAlignCenter, dividedTotalPrice.ToString(), "#,##0", false, false, isLastRow, false, true);
                                totalIncomeDictionary[excelColumnIndexList[j]] += dividedTotalPrice;
                                j++;
                                this.addCellData(excelWorkSheet, excelColumnIndexList[j] + (i + 3).ToString(), excelColumnIndexList[j] + (i + 3).ToString(), Excel.XlHAlign.xlHAlignCenter, dividedTotalPrice.ToString(), "#,##0", false, false, isLastRow, false, true);
                                totalIncomeDictionary[excelColumnIndexList[j]] += dividedTotalPrice;
                                j++;
                            }
                            else
                            {
                                this.addCellData(excelWorkSheet, excelColumnIndexList[j] + (i + 3).ToString(), excelColumnIndexList[j] + (i + 3).ToString(), Excel.XlHAlign.xlHAlignCenter, "", "", false, false, isLastRow, false, true);
                                j++;
                            }
                        } 
                    }                                       
                }
            }

            this.addCellData(excelWorkSheet, "C" + (enrollmentList.Count + 3).ToString(), "C" + (enrollmentList.Count + 3).ToString(), Excel.XlHAlign.xlHAlignRight, "รวมทั้งสิ้น", "", true, true, false, false, true);
            this.addCellData(excelWorkSheet, "D" + (enrollmentList.Count + 3).ToString(), "D" + (enrollmentList.Count + 3).ToString(), Excel.XlHAlign.xlHAlignRight, totalIncomeDictionary["D"].ToString(), "#,##0", true, true, true, true, true);
            for (int i = 8; i < excelColumnIndexList.Count; i++)
            {
                this.addCellData(excelWorkSheet, excelColumnIndexList[i] + (enrollmentList.Count + 3).ToString(), excelColumnIndexList[i] + (enrollmentList.Count + 3).ToString(), Excel.XlHAlign.xlHAlignCenter, totalIncomeDictionary[excelColumnIndexList[i]].ToString(), "#,##0", true, true, true, true, true);
            }
        }

        public bool createTotalIncomeSummary(string filename, List<Payment> paymentList)
        {
            Excel.Application excelApplication;
            Excel.Workbook excelWorkBook;
            Excel.Worksheet excelWorkSheet;
            object missingValue = System.Reflection.Missing.Value;

            excelApplication = new Excel.ApplicationClass();
            excelWorkBook = excelApplication.Workbooks.Add(missingValue);

            excelWorkSheet = (Excel.Worksheet)excelWorkBook.Worksheets.get_Item(1);
            this.createTotalIncomeHeader(excelWorkSheet);
            this.createTotalIncomeDetail(excelWorkSheet, paymentList);

            string savePathName = PianoForte.Constant.Constant.STARTUP_PATH + "\\Account\\" + filename + ".xls";

            excelWorkBook.SaveAs(savePathName, Excel.XlFileFormat.xlWorkbookNormal, missingValue, missingValue, missingValue, missingValue, Excel.XlSaveAsAccessMode.xlExclusive, missingValue, missingValue, missingValue, missingValue, missingValue);
            excelWorkBook.Close(true, missingValue, missingValue);
            excelApplication.Quit();

            this.releaseObject(excelWorkSheet);
            this.releaseObject(excelWorkBook);
            this.releaseObject(excelApplication);

            return true;
        }

        private void createTotalIncomeHeader(Excel.Worksheet excelWorkSheet)
        {
            this.addCellHeader(excelWorkSheet, "A1", "A2", 10, "ลำดับที่");
            this.addCellHeader(excelWorkSheet, "B1", "D1", 15, "วันที่ออกใบเสร็จ");
            this.addCellHeader(excelWorkSheet, "B2", "B2", 5, "วัน");
            this.addCellHeader(excelWorkSheet, "C2", "C2", 5, "เดือน");
            this.addCellHeader(excelWorkSheet, "D2", "D2", 5, "ปี");
            this.addCellHeader(excelWorkSheet, "E1", "E2", 10, "เลขที่ใบเสร็จ");
            this.addCellHeader(excelWorkSheet, "F1", "F2", 10, "รหัสนักเรียน");
            this.addCellHeader(excelWorkSheet, "G1", "G2", 25, "ชื่อนักเรียน");
            this.addCellHeader(excelWorkSheet, "H1", "H2", 10, "ค่าเล่าเรียน");
            this.addCellHeader(excelWorkSheet, "I1", "I2", 10, "ค่าหนังสือ");
            this.addCellHeader(excelWorkSheet, "J1", "J2", 10, "ค่าสมุด");
            this.addCellHeader(excelWorkSheet, "K1", "K2", 10, "อื่นๆ");
            this.addCellHeader(excelWorkSheet, "L1", "N1", 15, "วันที่เริ่มต้น");
            this.addCellHeader(excelWorkSheet, "L2", "L2", 5, "วัน");
            this.addCellHeader(excelWorkSheet, "M2", "M2", 5, "เดือน");
            this.addCellHeader(excelWorkSheet, "N2", "N2", 5, "ปี");
            this.addCellHeader(excelWorkSheet, "O1", "O2", 10, "รวม");
            this.addCellHeader(excelWorkSheet, "P1", "Q1", 20, "ชำระโดย");
            this.addCellHeader(excelWorkSheet, "P2", "P2", 10, "บัตรเครดิต");
            this.addCellHeader(excelWorkSheet, "Q2", "Q2", 10, "เงินสด");
            this.addCellHeader(excelWorkSheet, "R1", "R2", 10, "ค่าเล่าเรียนทั้งหมด");
            this.addCellHeader(excelWorkSheet, "S1", "S2", 10, "NOV");
            this.addCellHeader(excelWorkSheet, "T1", "T2", 10, "DEC");
            this.addCellHeader(excelWorkSheet, "U1", "U2", 10, "JAN");
            this.addCellHeader(excelWorkSheet, "V1", "V2", 10, "FEB");
            this.addCellHeader(excelWorkSheet, "W1", "W2", 10, "MAR");
            this.addCellHeader(excelWorkSheet, "X1", "X2", 10, "APR");
            this.addCellHeader(excelWorkSheet, "Y1", "Y2", 10, "MAY");
            this.addCellHeader(excelWorkSheet, "Z1", "Z2", 10, "JUN");
            this.addCellHeader(excelWorkSheet, "AA1", "AA2", 10, "JUL");
            this.addCellHeader(excelWorkSheet, "AB1", "AB2", 10, "AUG");
            this.addCellHeader(excelWorkSheet, "AC1", "AC2", 10, "SEP");
            this.addCellHeader(excelWorkSheet, "AD1", "AD2", 10, "OCT");
            this.addCellHeader(excelWorkSheet, "AE1", "AE2", 10, "NOV");
            this.addCellHeader(excelWorkSheet, "AF1", "AF2", 10, "DEC");
            this.addCellHeader(excelWorkSheet, "AG1", "AG2", 10, "JAN");
            this.addCellHeader(excelWorkSheet, "AH1", "AH2", 10, "FEB");
            this.addCellHeader(excelWorkSheet, "AI1", "AI2", 10, "MAR");
        }

        private void createTotalIncomeDetail(Excel.Worksheet excelWorkSheet, List<Payment> paymentList)
        {
            int offset = 3;

            Dictionary<string, double> columnIndexGrandTotalDictionary = new Dictionary<string, double>();
            
            for (int i = 0; i < paymentList.Count; i++)
            {
                MainForm.dailyPaymentReportForm.totalIncomeSummary.ReportProgress((i * 100) / paymentList.Count, ProgressBarManager.ProgressBarState.CREATE_FILE);                

                Payment tempPayment = paymentList[i];
                if (tempPayment != null)
                {
                    bool isLastRow = false;
                    if (i == (paymentList.Count - 1))
                    {
                        isLastRow = true;
                    }

                    string paymentDay = this.getDay(tempPayment.PaymentDate);
                    string paymentMonth = this.getMonth(tempPayment.PaymentDate);
                    string paymentYear = this.getYear(tempPayment.PaymentDate);
                    this.addCellData(excelWorkSheet, "A" + (i + offset).ToString(), "A" + (i + offset).ToString(), Excel.XlHAlign.xlHAlignCenter, (i + 1).ToString(), false, false, isLastRow, true, true);
                    this.addCellData(excelWorkSheet, "B" + (i + offset).ToString(), "B" + (i + offset).ToString(), Excel.XlHAlign.xlHAlignCenter, paymentDay, false, false, isLastRow, true, true);
                    this.addCellData(excelWorkSheet, "C" + (i + offset).ToString(), "C" + (i + offset).ToString(), Excel.XlHAlign.xlHAlignCenter, paymentMonth, false, false, isLastRow, true, true);
                    this.addCellData(excelWorkSheet, "D" + (i + offset).ToString(), "D" + (i + offset).ToString(), Excel.XlHAlign.xlHAlignCenter, paymentYear, false, false, isLastRow, true, true);
                    this.addCellData(excelWorkSheet, "E" + (i + offset).ToString(), "E" + (i + offset).ToString(), Excel.XlHAlign.xlHAlignCenter, tempPayment.Id.ToString(), false, false, isLastRow, true, true);

                    Student tempStudent = StudentManager.findStudent(tempPayment.StudentId);
                    if (tempStudent != null)
                    {
                        string studentName = tempStudent.Firstname + " " + tempStudent.Lastname;
                        if (tempStudent.Nickname != "")
                        {
                            studentName += "(" + tempStudent.Nickname + ")";
                        }

                        this.addCellData(excelWorkSheet, "F" + (i + offset).ToString(), "F" + (i + offset).ToString(), Excel.XlHAlign.xlHAlignCenter, tempStudent.Id.ToString(), false, false, isLastRow, true, true);
                        this.addCellData(excelWorkSheet, "G" + (i + offset).ToString(), "G" + (i + offset).ToString(), Excel.XlHAlign.xlHAlignLeft, studentName, false, false, isLastRow, true, true);
                    }

                    double totalCoursePrice = 0;
                    double totalBookPrice = 0;
                    double totalAssignmentBookPrice = 0;
                    double totalOtherPrice = 0;

                    List<PaymentDetail> tempPaymentDetailList = PaymentDetailManager.findAllPaymentDetail(tempPayment.Id);
                    for (int j = 0; j < tempPaymentDetailList.Count; j++)
                    {
                        PaymentDetail tempPaymentDetail = tempPaymentDetailList[j];
                        if (tempPaymentDetail != null)
                        {
                            if (tempPaymentDetail.Product.Type == Product.ProductType.COURSE.ToString())
                            {
                                totalCoursePrice += (tempPaymentDetail.Product.Price * tempPaymentDetail.Quantity) - tempPaymentDetail.Discount;
                            }
                            else if (tempPaymentDetail.Product.Type == Product.ProductType.BOOK.ToString())
                            {
                                if (tempPaymentDetail.Product.Id == 2000001)
                                {
                                    totalAssignmentBookPrice += (tempPaymentDetail.Product.Price * tempPaymentDetail.Quantity) - tempPaymentDetail.Discount;
                                }
                                else
                                {
                                    totalBookPrice += (tempPaymentDetail.Product.Price * tempPaymentDetail.Quantity) - tempPaymentDetail.Discount;
                                }
                            }
                            else
                            {
                                totalOtherPrice += (tempPaymentDetail.Product.Price * tempPaymentDetail.Quantity) - tempPaymentDetail.Discount;
                            }
                        }
                    }

                    if (totalCoursePrice == 0)
                    {
                        this.addCellData(excelWorkSheet, "H" + (i + offset).ToString(), "H" + (i + offset).ToString(), Excel.XlHAlign.xlHAlignRight, "", false, false, isLastRow, true, true);
                    }
                    else
                    {
                        this.addCellData(excelWorkSheet, "H" + (i + offset).ToString(), "H" + (i + offset).ToString(), Excel.XlHAlign.xlHAlignRight, totalCoursePrice.ToString(), "#,##0", false, false, isLastRow, true, true);
                        columnIndexGrandTotalDictionary = this.addValueToColumnIndexGrandTotalDictionary(columnIndexGrandTotalDictionary, "H", totalCoursePrice);
                    }

                    if (totalBookPrice == 0)
                    {
                        this.addCellData(excelWorkSheet, "I" + (i + offset).ToString(), "I" + (i + offset).ToString(), Excel.XlHAlign.xlHAlignRight, "", false, false, isLastRow, true, true);
                    }
                    else
                    {
                        this.addCellData(excelWorkSheet, "I" + (i + offset).ToString(), "I" + (i + offset).ToString(), Excel.XlHAlign.xlHAlignRight, totalBookPrice.ToString(), "#,##0", false, false, isLastRow, true, true);
                        columnIndexGrandTotalDictionary = this.addValueToColumnIndexGrandTotalDictionary(columnIndexGrandTotalDictionary, "I", totalBookPrice);
                    }

                    if (totalAssignmentBookPrice == 0)
                    {
                        this.addCellData(excelWorkSheet, "J" + (i + offset).ToString(), "J" + (i + offset).ToString(), Excel.XlHAlign.xlHAlignRight, "", false, false, isLastRow, true, true);
                    }
                    else
                    {
                        this.addCellData(excelWorkSheet, "J" + (i + offset).ToString(), "J" + (i + offset).ToString(), Excel.XlHAlign.xlHAlignRight, totalAssignmentBookPrice.ToString(), "#,##0", false, false, isLastRow, true, true);
                        columnIndexGrandTotalDictionary = this.addValueToColumnIndexGrandTotalDictionary(columnIndexGrandTotalDictionary, "J", totalAssignmentBookPrice);
                    }

                    if (totalOtherPrice == 0)
                    {
                        this.addCellData(excelWorkSheet, "K" + (i + offset).ToString(), "K" + (i + offset).ToString(), Excel.XlHAlign.xlHAlignRight, "", false, false, isLastRow, true, true);
                    }
                    else
                    {
                        this.addCellData(excelWorkSheet, "K" + (i + offset).ToString(), "K" + (i + offset).ToString(), Excel.XlHAlign.xlHAlignRight, totalOtherPrice.ToString(), "#,##0", false, false, isLastRow, true, true);
                        columnIndexGrandTotalDictionary = this.addValueToColumnIndexGrandTotalDictionary(columnIndexGrandTotalDictionary, "K", totalOtherPrice);
                    }

                    string classStartDay = "";
                    string classStartMonth = "";
                    string classStartYear = "";
                    Classroom tempClassroom = null;

                    //Enrollment tempEnrollment = EnrollmentManager.findAllEnrollmentByPaymentId(tempPayment.Id);
                    List<Enrollment> tempEnrollmentList = EnrollmentManager.findAllEnrollmentByPaymentId(tempPayment.Id);
                    for (int j = 0; j < tempEnrollmentList.Count; j++)
                    {
                        Enrollment tempEnrollment = tempEnrollmentList[j];
                        if (tempEnrollment != null)
                        {
                            List<Classroom> tempClassroomList = ClassroomManager.findAllClassroom(tempEnrollment.Id);
                            if (tempClassroomList.Count > 0)
                            {
                                classStartDay = this.getDay(tempClassroomList[0].StartDate);
                                classStartMonth = this.getMonth(tempClassroomList[0].StartDate);
                                classStartYear = this.getYear(tempClassroomList[0].StartDate);
                                tempClassroom = tempClassroomList[0];
                            }
                        }
                    }                    

                    this.addCellData(excelWorkSheet, "L" + (i + offset).ToString(), "L" + (i + offset).ToString(), Excel.XlHAlign.xlHAlignCenter, classStartDay, false, false, isLastRow, true, true);
                    this.addCellData(excelWorkSheet, "M" + (i + offset).ToString(), "M" + (i + offset).ToString(), Excel.XlHAlign.xlHAlignCenter, classStartMonth, false, false, isLastRow, true, true);
                    this.addCellData(excelWorkSheet, "N" + (i + offset).ToString(), "N" + (i + offset).ToString(), Excel.XlHAlign.xlHAlignCenter, classStartYear, false, false, isLastRow, true, true);
                    this.addCellData(excelWorkSheet, "O" + (i + offset).ToString(), "O" + (i + offset).ToString(), Excel.XlHAlign.xlHAlignRight, tempPayment.TotalPrice.ToString(), "#,##0", false, false, isLastRow, true, true);
                    columnIndexGrandTotalDictionary = this.addValueToColumnIndexGrandTotalDictionary(columnIndexGrandTotalDictionary, "O", tempPayment.TotalPrice);

                    if (tempPayment.CreditCardNumber != "")
                    {
                        this.addCellData(excelWorkSheet, "P" + (i + offset).ToString(), "P" + (i + offset).ToString(), Excel.XlHAlign.xlHAlignRight, tempPayment.TotalPrice.ToString(), "#,##0", false, false, isLastRow, true, true);
                        this.addCellData(excelWorkSheet, "Q" + (i + offset).ToString(), "Q" + (i + offset).ToString(), Excel.XlHAlign.xlHAlignRight, "", false, false, isLastRow, true, true);
                        columnIndexGrandTotalDictionary = this.addValueToColumnIndexGrandTotalDictionary(columnIndexGrandTotalDictionary, "P", tempPayment.TotalPrice);
                    }
                    else
                    {
                        this.addCellData(excelWorkSheet, "P" + (i + offset).ToString(), "P" + (i + offset).ToString(), Excel.XlHAlign.xlHAlignRight, "", false, false, isLastRow, true, true);
                        this.addCellData(excelWorkSheet, "Q" + (i + offset).ToString(), "Q" + (i + offset).ToString(), Excel.XlHAlign.xlHAlignRight, tempPayment.TotalPrice.ToString(), "#,##0", false, false, isLastRow, true, true);
                        columnIndexGrandTotalDictionary = this.addValueToColumnIndexGrandTotalDictionary(columnIndexGrandTotalDictionary, "Q", tempPayment.TotalPrice);
                    }

                    if (totalCoursePrice == 0)
                    {
                        this.addCellData(excelWorkSheet, "R" + (i + offset).ToString(), "R" + (i + offset).ToString(), Excel.XlHAlign.xlHAlignRight, "", false, false, isLastRow, true, true);
                    }
                    else
                    {
                        this.addCellData(excelWorkSheet, "R" + (i + offset).ToString(), "R" + (i + offset).ToString(), Excel.XlHAlign.xlHAlignRight, totalCoursePrice.ToString(), "#,##0", false, false, isLastRow, true, true);
                        columnIndexGrandTotalDictionary = this.addValueToColumnIndexGrandTotalDictionary(columnIndexGrandTotalDictionary, "R", totalCoursePrice);
                    }

                    if (tempClassroom != null)
                    {
                        double dividedTotalCoursePrice = totalCoursePrice / 3;

                        string columnIndex = this.getColumnIndexForTotalIncomeSummary(tempClassroom.StartDate.Month);
                        for (int j = 18; j < excelColumnIndexList.Count; )
                        {
                            if (excelColumnIndexList[j] == columnIndex)
                            {
                                this.addCellData(excelWorkSheet, excelColumnIndexList[j] + (i + offset).ToString(), excelColumnIndexList[j] + (i + offset).ToString(), Excel.XlHAlign.xlHAlignCenter, dividedTotalCoursePrice.ToString(), "#,##0", false, false, isLastRow, false, true);
                                columnIndexGrandTotalDictionary = this.addValueToColumnIndexGrandTotalDictionary(columnIndexGrandTotalDictionary, excelColumnIndexList[j], dividedTotalCoursePrice);
                                j++;

                                this.addCellData(excelWorkSheet, excelColumnIndexList[j] + (i + offset).ToString(), excelColumnIndexList[j] + (i + offset).ToString(), Excel.XlHAlign.xlHAlignCenter, dividedTotalCoursePrice.ToString(), "#,##0", false, false, isLastRow, false, true);
                                columnIndexGrandTotalDictionary = this.addValueToColumnIndexGrandTotalDictionary(columnIndexGrandTotalDictionary, excelColumnIndexList[j], dividedTotalCoursePrice);
                                j++;

                                this.addCellData(excelWorkSheet, excelColumnIndexList[j] + (i + offset).ToString(), excelColumnIndexList[j] + (i + offset).ToString(), Excel.XlHAlign.xlHAlignCenter, dividedTotalCoursePrice.ToString(), "#,##0", false, false, isLastRow, false, true);
                                columnIndexGrandTotalDictionary = this.addValueToColumnIndexGrandTotalDictionary(columnIndexGrandTotalDictionary, excelColumnIndexList[j], dividedTotalCoursePrice);
                                j++;
                            }
                            else
                            {
                                this.addCellData(excelWorkSheet, excelColumnIndexList[j] + (i + offset).ToString(), excelColumnIndexList[j] + (i + offset).ToString(), Excel.XlHAlign.xlHAlignCenter, "", "", false, false, isLastRow, false, true);
                                j++;
                            }
                        }
                    }
                    else
                    {
                        for (int j = 18; j < excelColumnIndexList.Count; )
                        {
                            this.addCellData(excelWorkSheet, excelColumnIndexList[j] + (i + offset).ToString(), excelColumnIndexList[j] + (i + offset).ToString(), Excel.XlHAlign.xlHAlignCenter, "", "", false, false, isLastRow, false, true);
                            j++;
                        }
                    }
                }
            }
            
            foreach (var pair in columnIndexGrandTotalDictionary)
            {
                this.addCellData(excelWorkSheet, pair.Key + (paymentList.Count + offset).ToString(), pair.Key + (paymentList.Count + offset).ToString(), Excel.XlHAlign.xlHAlignRight, pair.Value.ToString(), "#,##0", true, true, true, true, true);
            }
        }

        private void addCellHeader(Excel.Worksheet excelWorkSheet, string topLeft, string bottomRight, int columnWidth, string text)
        {
            Excel.Range chartRange;

            excelWorkSheet.get_Range(topLeft, bottomRight).Merge(false);
            chartRange = excelWorkSheet.get_Range(topLeft, bottomRight);
            chartRange.ColumnWidth = columnWidth;
            chartRange.FormulaR1C1 = text;
            chartRange.Font.Name = "MS Sans Serif";
            chartRange.Font.Size = 10;
            chartRange.Font.Bold = true;
            chartRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            chartRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
            chartRange.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, Excel.XlColorIndex.xlColorIndexAutomatic);
        }

        private void addCellData(Excel.Worksheet excelWorkSheet, string topLeft, string bottomRight, Excel.XlHAlign horizontalAlignment, string text, bool isBold, bool hasBorderTop, bool hasBorderBottom, bool hasBorderLeft, bool hasBorderRight)
        {
            Excel.Range chartRange;

            chartRange = excelWorkSheet.get_Range(topLeft, bottomRight);
            chartRange.FormulaR1C1 = text;
            chartRange.Font.Name = "MS Sans Serif";
            chartRange.Font.Size = 10;
            chartRange.Font.Bold = isBold;
            chartRange.HorizontalAlignment = horizontalAlignment;
            chartRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

            if (hasBorderTop)
            {
                chartRange.Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeTop].LineStyle = Excel.XlLineStyle.xlContinuous;
            }
            if (hasBorderBottom)
            {
                chartRange.Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlContinuous;
            }
            if (hasBorderLeft)
            {
                chartRange.Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft].LineStyle = Excel.XlLineStyle.xlContinuous;
            }
            if (hasBorderRight)
            {
                chartRange.Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeRight].LineStyle = Excel.XlLineStyle.xlContinuous;
            }
        }

        private void addCellData(Excel.Worksheet excelWorkSheet, string topLeft, string bottomRight, Excel.XlHAlign horizontalAlignment, string text,string numberFormat,  bool isBold, bool hasBorderTop, bool hasBorderBottom, bool hasBorderLeft, bool hasBorderRight)
        {
            Excel.Range chartRange;

            chartRange = excelWorkSheet.get_Range(topLeft, bottomRight);
            chartRange.FormulaR1C1 = text;
            chartRange.NumberFormat = numberFormat;
            chartRange.Font.Name = "MS Sans Serif";
            chartRange.Font.Size = 10;
            chartRange.Font.Bold = isBold;
            chartRange.HorizontalAlignment = horizontalAlignment;
            chartRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
            
            if (hasBorderTop)
            {
                chartRange.Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeTop].LineStyle = Excel.XlLineStyle.xlContinuous;
            }
            if (hasBorderBottom)
            {
                chartRange.Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlContinuous;
            }
            if (hasBorderLeft)
            {
                chartRange.Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft].LineStyle = Excel.XlLineStyle.xlContinuous;
            }
            if (hasBorderRight)
            {
                chartRange.Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeRight].LineStyle = Excel.XlLineStyle.xlContinuous;
            }
        }

        private string getCourseName(Enrollment enrollment)
        {
            string courseName = "";

            if (enrollment != null)
            {
                if (enrollment.Course != null)
                {
                    courseName = enrollment.Course.Name + " - " + enrollment.Course.Level;
                }                
            }

            return courseName;
        }

        //private Classroom getClassroom(Enrollment enrollment)
        //{
        //    Classroom classroom = null;

        //    if (enrollment != null)
        //    {
        //        //List<int> classroomIdList = ClassroomManager.getClassroomIdByEnrollmentId(enrollment.Id);
        //        if (classroomIdList.Count > 0)
        //        {
        //            classroom = ClassroomManager.findClassroom(classroomIdList[0]);
        //        }
        //    }

        //    return classroom;
        //}

        private string getDay(DateTime date)
        {
            string day = "";

            day = date.Day.ToString();
            if (day.Length == 1)
            {
                day = "0" + day;
            }

            return day;
        }

        private string getMonth(DateTime date)
        {
            string month = "";

            month = date.Month.ToString();
            if (month.Length == 1)
            {
                month = "0" + month;
            }

            return month;
        }

        private string getYear(DateTime date)
        {
            string year = "";

            year = (date.Year + 543).ToString();
            if (year.Length == 4)
            {
                year = year.Substring(2, 2);
            }

            return year;
        }

        private string getDate(DateTime date)
        {
            string day = getDay(date);
            string month = getMonth(date);
            string year = getYear(date);

            return day + "/" + month + "/" + year;
        }

        private string getColumnIndexForCourseIncomeSummary(int month)
        {
            List<string> columnIndexList = new List<string>() { "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y" };

            return columnIndexList[month - 1];
        }

        private string getColumnIndexForTotalIncomeSummary(int month)
        {
            List<string> columnIndexList = new List<string>() { "U", "V", "W", "X", "Y", "Z", "AA", "AB", "AC", "AD", "AE", "AF", "AG", "AH", "AI" };

            return columnIndexList[month - 1];
        }

        private int getYearOfMostClassroomStartDate(List<Enrollment> enrollmentList)
        {
            int year = 0;
            Dictionary<int, int> numberOfYearDictionary = new Dictionary<int, int>();

            for (int i = 0; i < enrollmentList.Count; i++)
            {
                Enrollment tempEnrollment = enrollmentList[i];
                if (tempEnrollment != null)
                {
                    List<Classroom> tempClassroomList = ClassroomManager.findAllClassroom(tempEnrollment.Id);
                    for (int j = 0; j < tempClassroomList.Count; j++)
                    {
                        Classroom tempClassroom = tempClassroomList[j];
                        if (tempClassroom != null)
                        {
                            if (!numberOfYearDictionary.ContainsKey(tempClassroom.StartDate.Year))
                            {
                                numberOfYearDictionary.Add(tempClassroom.StartDate.Year, 1);
                            }
                            else
                            {
                                numberOfYearDictionary[tempClassroom.StartDate.Year]++;
                            }
                        }
                    }
                }                
            }

            foreach (var pair in numberOfYearDictionary)
            {
                if (year == 0)
                {
                    year = pair.Key;
                }
                else
                {
                    if (numberOfYearDictionary[year] < pair.Value)
                    {
                        year = pair.Key;
                    }
                }
            }

            return year;
        }

        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                LogManager.writeLog(ex.Message);
            }
            finally
            {
                GC.Collect();
            }
        }

        private Dictionary<string, double> addValueToColumnIndexGrandTotalDictionary(Dictionary<string, double> columnIndexGrandTotalDictionary, string columnIndex, double value)
        {
            if (columnIndexGrandTotalDictionary.ContainsKey(columnIndex))
            {
                columnIndexGrandTotalDictionary[columnIndex] += value;
            }
            else
            {
                columnIndexGrandTotalDictionary.Add(columnIndex, value);
            }

            return columnIndexGrandTotalDictionary;
        }
    }
}
