using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using PianoForte.Model;

namespace PianoForte.View
{
    public partial class SearchCdResultForm : Form
    {
        private Form caller;
        private List<Cd> cdList;

        public SearchCdResultForm()
        {
            InitializeComponent();
        }

        public void load(Form caller, List<Cd> cdList)
        {
            this.caller = caller;
            this.cdList = cdList;
            for (int i = 0; i < this.cdList.Count; i++)
            {
                Cd temCd = this.cdList[i];
                if (temCd != null)
                {
                    int amount = MainForm.paymentForm.getProductAmount(temCd.Id);
                    if (amount > 0)
                    {
                        this.cdList[i].Quantity -= amount;
                    }
                }
            }


            this.DataGridView_CdInfo.AutoGenerateColumns = false;

            this.reload();
        }

        public void reload()
        {
            this.DataGridView_CdInfo.DataSource = null;

            if (this.cdList.Count > 0)
            {
                this.DataGridView_CdInfo.DataSource = this.cdList;
            }
        }

        public void reset()
        {
            this.DataGridView_CdInfo.DataSource = null;
            this.DataGridView_CdInfo.ClearSelection();
        }

        private void DataGridView_CdInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                Cd tempCd = this.cdList[e.RowIndex];
                if (tempCd != null)
                {
                    if (this.caller is CdMainForm)
                    {
                        CdMainForm cdMainForm = (CdMainForm)this.caller;
                    }
                }
            }
        }

        private void DataGridView_CdInfo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                Cd tempCd = this.cdList[e.RowIndex];
                if (tempCd != null)
                {
                    int cdAmount = 1;
                    if (cdAmount <= tempCd.Quantity)
                    {
                        Product product = new Product();
                        product.Id = tempCd.Id;
                        product.Type = Product.ProductType.CD.ToString();
                        product.Name = tempCd.Name;
                        product.Price = tempCd.Price;

                        PaymentDetail paymentDetail = new PaymentDetail();
                        paymentDetail.Product = product;
                        paymentDetail.Quantity = cdAmount;

                        if (MainForm.paymentForm.addPaymentDetail(paymentDetail))
                        {
                            this.cdList[e.RowIndex].Quantity--;

                            this.reload();
                        }
                        else
                        {
                            MessageBox.Show("ไม่สามารถทำรายการได้");
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
