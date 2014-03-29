using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Management;

namespace PianoForte.Manager
{
    public class PrinterManager
    {
        public static bool isPrinterOnline(string printerName)
        {
            bool isOnline = false;

            ManagementScope scope = new ManagementScope(@"\root\cimv2");
            scope.Connect();

            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_Printer");

            foreach (ManagementObject printer in searcher.Get())
            {
                if (printerName == printer["Name"].ToString())
                {
                    if (printer["WorkOffline"].ToString().ToLower().Equals("true"))
                    {
                        isOnline = false;
                    }
                    else
                    {
                        isOnline = true;
                    }
                }
            }

            return isOnline;
        }
    }
}
