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

namespace PianoForte.View
{
    public partial class CdDetailForm : Form
    {
        private Cd originalCd;

        public CdDetailForm()
        {
            InitializeComponent();
        }

        public Cd showFormDialog(Cd cd, bool isEditMode)
        {
            this.originalCd = new Cd(cd);

            this.setup(cd, isEditMode);

            this.ShowDialog();

            return this.originalCd;
        }

        public void setup(Cd cd, bool isEditMode)
        {
            this.TextBox_CdId.Text = cd.Id.ToString();
            this.TextBox_Barcode.Text = cd.Barcode;
            this.TextBox_CdName.Text = cd.Name;
            this.TextBox_CdPrice.Text = cd.Price.ToString();
            this.TextBox_CdAmount.Text = cd.Amount.ToString();

            if (cd.Status == Cd.CdStatus.CANCELED.ToString())
            {
                this.CheckBox_Cancel_Cd.Checked = true;
            }
            else
            {
                this.CheckBox_Cancel_Cd.Checked = false;
            }

            this.CheckBox_Cancel_Cd.Enabled = isEditMode;
            this.TextBox_Barcode.Enabled = isEditMode;
            this.TextBox_CdName.Enabled = isEditMode;
            this.TextBox_CdPrice.Enabled = isEditMode;
            this.TextBox_CdAmount.Enabled = isEditMode;
            this.Button_Submit.Visible = isEditMode;
            this.Button_Cancel.Visible = isEditMode;
            this.Button_Edit.Visible = !isEditMode;

            this.refreshButton_Submit();
        }

        private void refreshButton_Submit()
        {
            if ((this.TextBox_Barcode.Text != "") &&
                (this.TextBox_CdName.Text != "") &&
                (ValidateManager.isNumber(this.TextBox_CdPrice.Text)) &&
                (ValidateManager.isNumber(this.TextBox_CdAmount.Text)))
            {
                this.Button_Submit.Enabled = true;
            }
            else
            {
                this.Button_Submit.Enabled = false;
            }
        }

        private void TextBox_Barcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (!ValidateManager.isPressNumber(e))
            {
                e.SuppressKeyPress = true;
            }
        }

        private void TextBox_Barcode_TextChanged(object sender, EventArgs e)
        {
            this.refreshButton_Submit();
        }

        private void TextBox_CdName_TextChanged(object sender, EventArgs e)
        {
            this.refreshButton_Submit();
        }

        private void TextBox_CdPrice_KeyDown(object sender, KeyEventArgs e)
        {
            if (!ValidateManager.isPressNumber(e))
            {
                e.SuppressKeyPress = true;
            }
        }

        private void TextBox_CdPrice_TextChanged(object sender, EventArgs e)
        {
            this.refreshButton_Submit();
        }

        private void TextBox_CdAmount_KeyDown(object sender, KeyEventArgs e)
        {
            if (!ValidateManager.isPressNumber(e))
            {
                e.SuppressKeyPress = true;
            }
        }

        private void TextBox_CdAmount_TextChanged(object sender, EventArgs e)
        {
            this.refreshButton_Submit();
        }

        private void Button_Submit_Click(object sender, EventArgs e)
        {
            string text = "คุณต้องการแก้ไขข้อมูลใช่หรือไม่?";
            if (ConfirmDialogBox.show(text))
            {
                Cd tempCd = new Cd(this.originalCd);
                tempCd.Barcode = this.TextBox_Barcode.Text;
                tempCd.Name = this.TextBox_CdName.Text;
                tempCd.Price = Convert.ToDouble(this.TextBox_CdPrice.Text);
                tempCd.Amount = Convert.ToInt32(this.TextBox_CdAmount.Text);

                if (this.CheckBox_Cancel_Cd.Checked)
                {
                    tempCd.Status = Book.BookStatus.CANCELED.ToString();
                }
                else
                {
                    if (tempCd.Amount <= 0)
                    {
                        tempCd.Status = Cd.CdStatus.EMPTY.ToString();
                    }
                    else
                    {
                        tempCd.Status = Cd.CdStatus.AVAILABLE.ToString();
                    }
                }                 

                if (CdManager.updateCd(tempCd))
                {
                    if (this.originalCd.Price != tempCd.Price)
                    {
                        ProductPriceHistory productPriceHistory = new ProductPriceHistory();
                        productPriceHistory.ProductId = this.originalCd.Id;
                        productPriceHistory.Price = this.originalCd.Price;
                        productPriceHistory.LastUsed = DateTime.Now;

                        ProductManager.addProductPriceHistory(productPriceHistory);
                    }

                    this.originalCd = tempCd;

                    //MessageBox.Show(PianoForte.Constant.DatabaseConstant.UPDATE_DATA_SUCCESS);

                    this.Close();
                }
                else
                {
                    MessageBox.Show(PianoForte.Constant.DatabaseConstant.UPDATE_DATA_FAIL);
                }
            }
        }

        private void Button_Cancel_Click(object sender, EventArgs e)
        {
            this.setup(this.originalCd, false);
        }

        private void Button_Edit_Click(object sender, EventArgs e)
        {
            this.setup(this.originalCd, true);
        }
    }
}
