using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Drawing.Printing;

using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

using PianoForte.DatasetModel;
using PianoForte.Interface;
using PianoForte.Model;
using PianoForte.Report;
using PianoForte.Manager;
using PianoForte.Dao;

namespace PianoForte.View
{
    public partial class ReceiptForm : Form
    {
        private int paymentId;

        public ReceiptForm()
        {
            InitializeComponent();
        }

        public void showFormDialog(int paymentId, string paymentStatus)
        {
            this.paymentId = paymentId;

            DataSet dataSet = ReceiptManager.initReceiptReportTable(paymentId);
            if (paymentStatus == Payment.PaymentStatus.PAID.ToString())
            {
                ReceiptViewPaid receiptViewPaid = new ReceiptViewPaid();
                receiptViewPaid.Database.Tables[Payment.tableName].SetDataSource(dataSet.Tables[Payment.tableName]);
                receiptViewPaid.Database.Tables[PaymentDetail.tableName].SetDataSource(dataSet.Tables[PaymentDetail.tableName]);
                receiptViewPaid.Database.Tables[Student.tableName].SetDataSource(dataSet.Tables[Student.tableName]);
                receiptViewPaid.Database.Tables[User.tableName].SetDataSource(dataSet.Tables[User.tableName]);
                if (dataSet.Tables.Count > 4)
                {
                    if (dataSet.Tables[ReceiptFooter.tableName].Rows.Count > 0)
                    {
                        receiptViewPaid.Database.Tables[ReceiptFooter.tableName].SetDataSource(dataSet.Tables[ReceiptFooter.tableName]);
                    }
                }

                crystalReportViewer1.ReportSource = receiptViewPaid;

                this.Button_Print.Enabled = true;
            }
            else if (paymentStatus == Payment.PaymentStatus.CANCELED.ToString())
            {
                ReceiptViewCancel receiptViewCancel = new ReceiptViewCancel();
                receiptViewCancel.Database.Tables[Payment.tableName].SetDataSource(dataSet.Tables[Payment.tableName]);
                receiptViewCancel.Database.Tables[PaymentDetail.tableName].SetDataSource(dataSet.Tables[PaymentDetail.tableName]);
                receiptViewCancel.Database.Tables[Student.tableName].SetDataSource(dataSet.Tables[Student.tableName]);
                receiptViewCancel.Database.Tables[User.tableName].SetDataSource(dataSet.Tables[User.tableName]);
                if (dataSet.Tables.Count > 4)
                {
                    if (dataSet.Tables[ReceiptFooter.tableName].Rows.Count > 0)
                    {
                        receiptViewCancel.Database.Tables[ReceiptFooter.tableName].SetDataSource(dataSet.Tables[ReceiptFooter.tableName]);
                    }
                }

                crystalReportViewer1.ReportSource = receiptViewCancel;

                this.Button_Print.Enabled = false;
            }
            else if (paymentStatus == Payment.PaymentStatus.NOT_PAID.ToString())
            {
                ReceiptViewUnpaid receiptViewUnpaid = new ReceiptViewUnpaid();
                receiptViewUnpaid.Database.Tables[Payment.tableName].SetDataSource(dataSet.Tables[Payment.tableName]);
                receiptViewUnpaid.Database.Tables[PaymentDetail.tableName].SetDataSource(dataSet.Tables[PaymentDetail.tableName]);
                receiptViewUnpaid.Database.Tables[Student.tableName].SetDataSource(dataSet.Tables[Student.tableName]);
                receiptViewUnpaid.Database.Tables[User.tableName].SetDataSource(dataSet.Tables[User.tableName]);
                if (dataSet.Tables.Count > 4)
                {
                    if (dataSet.Tables[ReceiptFooter.tableName].Rows.Count > 0)
                    {
                        receiptViewUnpaid.Database.Tables[ReceiptFooter.tableName].SetDataSource(dataSet.Tables[ReceiptFooter.tableName]);
                    }
                }

                crystalReportViewer1.ReportSource = receiptViewUnpaid;

                this.Button_Print.Enabled = false;
            }

            this.ShowDialog();
        }     

        private void Button_Print_Click(object sender, EventArgs e)
        {
            if (!ReceiptManager.printReceipt(paymentId))
            {
                MessageBox.Show(PianoForte.Constant.Constant.PRINTER_NOT_FOUND);
            }          
        }
    }
}
