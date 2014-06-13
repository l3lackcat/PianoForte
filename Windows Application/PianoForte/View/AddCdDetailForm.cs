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
    public partial class AddCdDetailForm : Form
    {
        public AddCdDetailForm()
        {
            InitializeComponent();
        }

        public void showFormDialog()
        {
            this.reset();
            this.ShowDialog();
        }

        public void reset()
        {
            this.TextBox_CdId.Text = CdManager.getNewCdId().ToString();
            this.TextBox_Barcode.Text = "";
            this.TextBox_OriginalBarcode.Text = "";
            this.TextBox_CdName.Text = "";
            this.TextBox_CdPrice.Text = "";
            this.TextBox_CdAmount.Text = "";

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
            string text = "คุณต้องการเพิ่มซีดีใช่หรือไม่?";
            if (ConfirmDialogBox.show(text))
            {
                Cd newCd = new Cd();
                newCd.Id = Convert.ToInt32(this.TextBox_CdId.Text);
                newCd.Type = Product.ProductType.CD.ToString();
                newCd.Barcode = this.TextBox_Barcode.Text;
                newCd.Name = this.TextBox_CdName.Text;
                newCd.Price = Convert.ToDouble(this.TextBox_CdPrice.Text);
                newCd.Quantity = Convert.ToInt32(this.TextBox_CdAmount.Text);

                if (newCd.Quantity <= 0)
                {
                    newCd.Status = Cd.CdStatus.EMPTY.ToString();
                }
                else
                {
                    newCd.Status = Cd.CdStatus.AVAILABLE.ToString();
                }

                if (CdManager.insertCd(newCd))
                {
                    //MessageBox.Show(PianoForte.Constant.DatabaseConstant.INSERT_DATA_SUCCESS);
                    this.Close();
                }
                else
                {
                    MessageBox.Show(PianoForte.Constant.DatabaseConstant.INSERT_DATA_FAIL);
                }
            }
        }

        private void Button_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
