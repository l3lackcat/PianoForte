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
    public partial class AddOtherProductPopUp : Form
    {
        private OtherCost otherProduct;

        public AddOtherProductPopUp()
        {
            InitializeComponent();
        }

        public OtherCost showFormDialog()
        {
            this.reset();
            this.ShowDialog();

            return this.otherProduct;
        }

        private void reset()
        {
            this.TextBox_OtherProductName.Text = "";
            this.TextBox_OtherProductPrice.Text = "";
        }

        private void updateButtonAdd()
        {
            string name = this.TextBox_OtherProductName.Text;
            string textPrice = this.TextBox_OtherProductPrice.Text;

            if ((name != "") && (textPrice != ""))
            {
                this.Button_Add.Enabled = true;
            }
            else
            {
                this.Button_Add.Enabled = false;
            }
        }

        private void TextBox_OtherProductName_TextChanged(object sender, EventArgs e)
        {
            this.updateButtonAdd();
        }

        private void TextBox_OtherProductPrice_TextChanged(object sender, EventArgs e)
        {
            this.updateButtonAdd();
        }

        private void Button_Add_Click(object sender, EventArgs e)
        {
            string name = this.TextBox_OtherProductName.Text;
            string textPrice = this.TextBox_OtherProductPrice.Text;

            double price = 0;
            if (ValidateManager.isNumber(textPrice))
            {
                price = Convert.ToDouble(textPrice);

                OtherCost otherProduct = OtherCostManager.findOtherCost(name, price);
                if (otherProduct == null)
                {
                    otherProduct = new OtherCost();
                    otherProduct.Id = OtherCostManager.getNewOtherCostId();
                    otherProduct.Name = name;
                    otherProduct.Price = price;

                    OtherCostManager.insertOtherCost(otherProduct);
                }

                this.otherProduct = otherProduct;
                this.Close();
            }
            else
            {
                MessageBox.Show("กรุณากรอกข้อมูลให้ถูกต้อง");
            }          
        }

        private void Button_Reset_Click(object sender, EventArgs e)
        {
            this.reset();
        }
    }
}
