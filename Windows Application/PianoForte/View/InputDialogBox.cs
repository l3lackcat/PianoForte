using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using PianoForte.Constant;

namespace PianoForte.View
{
    public partial class InputDialogBox : Form
    {
        private static InputDialogBox inputDialogBox;
        private static string inputText;

        public InputDialogBox()
        {
            InitializeComponent();
        }

        public static string show(string title)
        {
            inputDialogBox = new InputDialogBox();
            inputDialogBox.Text = title;
            inputDialogBox.ShowDialog();

            return inputText;
        }

        private void Button_OK_Click(object sender, EventArgs e)
        {
            if (TextBox_Input.Text != "")
            {
                inputText = this.TextBox_Input.Text;
                inputDialogBox.Dispose();
            }
        }

        private void Button_Cancel_Click(object sender, EventArgs e)
        {
            inputText = "";
            inputDialogBox.Dispose();
        }

        private void TextBox_Input_TextChanged(object sender, EventArgs e)
        {
            if (this.TextBox_Input.Text == "")
            {
                this.Button_OK.Enabled = false;
            }
            else
            {
                this.Button_OK.Enabled = true;
            }
        }

        private void TextBox_Input_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                if (this.TextBox_Input.Text != "")
                {
                    inputText = this.TextBox_Input.Text;
                    inputDialogBox.Dispose();
                }
            }
            else if (e.KeyData == Keys.Escape)
            {
                inputText = "";
                inputDialogBox.Dispose();
            }
        }
    }
}
