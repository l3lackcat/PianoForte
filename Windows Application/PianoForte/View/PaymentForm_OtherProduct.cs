using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using PianoForte.Constant;
using PianoForte.Manager;
using PianoForte.Model;

namespace PianoForte.View
{
    public partial class PaymentForm_OtherProduct : Form
    {
        private PaymentForm paymentForm;

        public PaymentForm_OtherProduct()
        {
            InitializeComponent();
        }

        public void load(PaymentForm paymentForm)
        {
            this.paymentForm = paymentForm;
        }

        public void reset()
        {
            this.TextBox_OtherCostName.Text = "";
            this.TextBox_OtherCostPrice.Text = "";
            this.Button_Add_OtherCost.Enabled = false;
        }

        private OtherCost searchOtherProduct()
        {
            string otherProductName = this.TextBox_OtherCostName.Text;

            double otherProductPrice = 0;
            if (ValidateManager.isNumber(this.TextBox_OtherCostPrice.Text))
            {
                otherProductPrice = Convert.ToDouble(this.TextBox_OtherCostPrice.Text);
            }

            return this.searchOtherProduct(otherProductName, otherProductPrice);
        }

        private OtherCost searchOtherProduct(string name, double price)
        {
            OtherCost otherProduct = OtherCostManager.findOtherCost(name, price);
            if (otherProduct == null)
            {
                otherProduct = new OtherCost();
                otherProduct.Id = OtherCostManager.getNewOtherCostId();
                otherProduct.Name = name;
                otherProduct.Price = price;

                bool isAddOtherCostComplete = OtherCostManager.insertOtherCost(otherProduct);
                if (!isAddOtherCostComplete)
                {
                    otherProduct = null;
                }
            }

            return otherProduct;
        }

        private void TextBox_OtherCostName_TextChanged(object sender, EventArgs e)
        {
            if ((this.TextBox_OtherCostName.Text != "") &&
                (this.TextBox_OtherCostPrice.Text != ""))
            {
                this.Button_Add_OtherCost.Enabled = true;
            }
            else
            {
                this.Button_Add_OtherCost.Enabled = false;
            }
        }

        private void TextBox_OtherCostName_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.Button_Add_OtherCost.Enabled)
            {
                if (e.KeyData == Keys.Enter)
                {
                    //To Do
                }
            }
        }

        private void TextBox_OtherCostPrice_TextChanged(object sender, EventArgs e)
        {
            if ((this.TextBox_OtherCostName.Text != "") &&
                (this.TextBox_OtherCostPrice.Text != ""))
            {
                this.Button_Add_OtherCost.Enabled = true;
            }
            else
            {
                this.Button_Add_OtherCost.Enabled = false;
            }
        }

        private void TextBox_OtherCostPrice_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.Button_Add_OtherCost.Enabled)
            {
                if (e.KeyData == Keys.Enter)
                {
                    //To Do
                }
            }
        }

        private void Button_Add_OtherCost_Click(object sender, EventArgs e)
        {
            OtherCost otherProduct = this.searchOtherProduct();

            if (otherProduct != null)
            {
                Product product = new Product();
                product.Id = otherProduct.Id;
                product.Type = Product.ProductType.OTHER.ToString();
                product.Name = otherProduct.Name;
                product.Price = otherProduct.Price;

                PaymentDetail paymentDetail = new PaymentDetail();
                paymentDetail.Product = product;
                paymentDetail.Amount = 1;

                this.paymentForm.addPaymentDetail(paymentDetail);
            }            
        }

        private void TextBox_OtherCostName_TextChanged_1(object sender, EventArgs e)
        {
            if ((this.TextBox_OtherCostName.Text != "") &&
                (this.TextBox_OtherCostPrice.Text != ""))
            {
                this.Button_Add_OtherCost.Enabled = true;
            }
            else
            {
                this.Button_Add_OtherCost.Enabled = false;
            }
        }               
    }
}
