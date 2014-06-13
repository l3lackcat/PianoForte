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

namespace PianoForte.View
{
    public partial class SearchCDPopUp : Form
    {
        private Form caller;
        private List<Cd> cdList;

        public SearchCDPopUp()
        {
            InitializeComponent();
        }

        public void showFormDialog(Form caller)
        {
            this.caller = caller;

            this.initialCDList();
            this.initialDataGridViewCDList();
            this.updateDataGridViewCDList();

            this.ShowDialog();
        }

        private void initialCDList()
        {
            this.cdList = CdManager.findAllCd(Cd.CdStatus.AVAILABLE);

            int numberOfBookList = this.cdList.Count;
            for (int i = 0; i < numberOfBookList; i++)
            {
                Cd cd = this.cdList[i];
                if (cd != null)
                {
                    if (this.caller is PaymentForm2)
                    {
                        PaymentForm2 paymentForm2 = (PaymentForm2)this.caller;

                        int quantity = paymentForm2.getProductQuantity(cd.Id);
                        if (quantity > 0)
                        {
                            cd.Quantity -= quantity;

                            if (cd.Quantity <= 0)
                            {
                                cd.Status = Cd.CdStatus.EMPTY.ToString();
                            }
                        }
                    }
                }
            }
        }

        private void initialDataGridViewCDList()
        {
            this.DataGridView_CDList.AutoGenerateColumns = false;
        }

        private void updateDataGridViewCDList()
        {
            this.DataGridView_CDList.DataSource = null;

            if (this.cdList.Count > 0)
            {
                this.DataGridView_CDList.DataSource = this.cdList;
            }
        }

        private void searchCD(string cdName)
        {
            if (cdName == "")
            {
                this.cdList = CdManager.findAllCd(Cd.CdStatus.AVAILABLE);
            }
            else
            {
                this.cdList = CdManager.findAllCdByName(cdName, Cd.CdStatus.AVAILABLE);
            }

            this.updateDataGridViewCDList();
        }

        private void TextBox_CDName_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.searchCD(this.TextBox_CDName.Text);
            }
        }

        private void Button_SearchCD_Click(object sender, EventArgs e)
        {
            this.searchCD(this.TextBox_CDName.Text);
        }

        private void DataGridView_CDList_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowIndex = e.RowIndex;
            if (rowIndex >= 0)
            {
                Cd cd = this.cdList[rowIndex];
                if (cd != null)
                {
                    int cdQuantity = 1;
                    if (cdQuantity <= cd.Quantity)
                    {
                        Product product = new Product();
                        product.Id = cd.Id;
                        product.Type = Product.ProductType.CD.ToString();
                        product.Name = cd.Name;
                        product.Price = cd.Price;

                        PaymentDetail paymentDetail = new PaymentDetail();
                        paymentDetail.Product = product;
                        paymentDetail.Quantity = cdQuantity;

                        if (this.caller is PaymentForm2)
                        {
                            PaymentForm2 paymentForm2 = (PaymentForm2)this.caller;

                            if (paymentForm2.addPaymentDetail(paymentDetail) == true)
                            {
                                cd.Quantity--;

                                this.updateDataGridViewCDList();
                            }
                            else
                            {
                                MessageBox.Show("ไม่สามารถทำรายการได้");
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("ไม่สามารถทำรายการได้");
                    }
                }
            }
        }
    }
}
