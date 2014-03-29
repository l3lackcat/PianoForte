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
    public partial class ProgressBarDialogBox : Form
    {
        public ProgressBarDialogBox()
        {
            InitializeComponent();
        }

        public void show()
        {
            this.ShowDialog();
        }     

        public void update(string text)
        {
            this.Text = text;
        }

        public void update(int percentage)
        {
            this.progressBar.Value = percentage;
        }

        public void changeColor(Color color)
        {
            
        }

        public void setProgressBarStyle(ProgressBarStyle progressBarStyle)
        {
            this.progressBar.Style = progressBarStyle;
            if (progressBarStyle == ProgressBarStyle.Continuous)
            {
                this.progressBar.Minimum = 0;
                this.progressBar.Maximum = 100;
            }
        }

        public void hide()
        {
            this.Close();
        }
    }
}
