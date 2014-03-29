using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PianoForte.View
{
    public partial class ConfirmDialogBox : Form
    {
        private static ConfirmDialogBox confirmDialogBox;
        private static bool answer;

        public ConfirmDialogBox()
        {
            InitializeComponent();
        }

        public static bool show(string message)
        {
            confirmDialogBox = new ConfirmDialogBox();
            confirmDialogBox.Label_Text.Text = message;
            confirmDialogBox.ShowDialog();           

            return answer;
        }

        public static bool show(string message, string title)
        {
            confirmDialogBox = new ConfirmDialogBox();
            confirmDialogBox.Label_Text.Text = message;
            confirmDialogBox.Text = title;
            confirmDialogBox.ShowDialog();

            return answer;
        }

        private void Button_OK_Click(object sender, EventArgs e)
        {
            answer = true;
            confirmDialogBox.Dispose();
        }

        private void Button_Cancel_Click(object sender, EventArgs e)
        {
            answer = false;
            confirmDialogBox.Dispose();
        }

        private void ConfirmDialogBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                answer = true;
                confirmDialogBox.Dispose();
            }
            else if (e.KeyData == Keys.Escape)
            {
                answer = false;
                confirmDialogBox.Dispose();
            }
        }
    }
}
