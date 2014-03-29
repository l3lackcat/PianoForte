using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PianoForte.View;

namespace PianoForte.Manager
{
    public class ProgressBarManager
    {
        private static ProgressBarDialogBox progressBarDialogBox = new ProgressBarDialogBox();

        public enum ProgressBarState
        {
            QUERY,
            CREATE_FILE,
            GENERATE_DATE,
        }

        public static void showProgressBar(bool isVisible)
        {
            if (isVisible)
            {
                progressBarDialogBox.show();
            }
            else
            {
                progressBarDialogBox.hide();
            }            
        }

        public static void updateProgressBar(int progressPercentage, ProgressBarState progressBarState)
        {
            switch (progressBarState)
            {
                case ProgressBarState.QUERY:
                    progressBarDialogBox.setProgressBarStyle(System.Windows.Forms.ProgressBarStyle.Marquee);
                    progressBarDialogBox.update("Querying");
                    progressBarDialogBox.update(progressPercentage);
                    break;
                case ProgressBarState.CREATE_FILE:
                    progressBarDialogBox.setProgressBarStyle(System.Windows.Forms.ProgressBarStyle.Continuous);
                    progressBarDialogBox.update("Creating file " + progressPercentage.ToString() + "% Complete");
                    progressBarDialogBox.update(progressPercentage);
                    break;
                case ProgressBarState.GENERATE_DATE:
                    progressBarDialogBox.setProgressBarStyle(System.Windows.Forms.ProgressBarStyle.Continuous);
                    progressBarDialogBox.update("Generating data " + progressPercentage.ToString() + "% Complete");
                    progressBarDialogBox.update(progressPercentage);
                    break;
            }
        }
    }
}
