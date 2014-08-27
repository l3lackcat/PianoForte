using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;
using Newtonsoft.Json;

namespace LocationXlsToJson
{
    public partial class Form2 : Form
    {
        private Dictionary<string, TradewebData> dealerCodeDictionary = new Dictionary<string, TradewebData>();

        public Form2()
        {
            InitializeComponent();
        }

        private void createJsonFiles(string filename)
        {
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(filename);
            Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
            Excel.Range xlRange = xlWorksheet.UsedRange;

            int rowCount = xlRange.Rows.Count;
            int colCount = xlRange.Columns.Count;

            this.ProgressBar.Maximum = rowCount;

            //iterate over the rows and columns and print to the console as it appears in the file
            //excel is not zero based!!
            for (int i = 2; i <= rowCount; i++)
            {
                string dealerCode = "";
                TradewebData tradewebData = new TradewebData();

                for (int j = 1; j <= colCount; j++)
                {
                    if (j == 1)
                    {
                        dealerCode = xlRange.Cells[i, j].Value2.ToString();
                    }
                    else if (j == 2)
                    {
                        tradewebData.ContributorName = xlRange.Cells[i, j].Value2.ToString();
                    }
                    else
                    {
                        if (xlRange.Cells[i, j].Value2 != null)
                        {
                            string contributorId = xlRange.Cells[i, j].Value2.ToString();

                            if (contributorId != "")
                            {
                                if (tradewebData.ContributorIdList.Contains(contributorId) == false)
                                {
                                    tradewebData.ContributorIdList.Add(contributorId);
                                }
                            }
                        }
                    }
                }

                updateDealerCodeDictionary(dealerCode, tradewebData);

                this.ProgressBar.Value = i;
            }

            createPath("json");
            createDealerCodeDictionaryJsonFile();

            //cleanup
            GC.Collect();
            GC.WaitForPendingFinalizers();

            //rule of thumb for releasing com objects:
            //  never use two dots, all COM objects must be referenced and released individually
            //  ex: [somthing].[something].[something] is bad

            //release com objects to fully kill excel process from running in the background
            Marshal.ReleaseComObject(xlRange);
            Marshal.ReleaseComObject(xlWorksheet);

            //close and release
            xlWorkbook.Close();
            Marshal.ReleaseComObject(xlWorkbook);

            //quit and release
            xlApp.Quit();
            Marshal.ReleaseComObject(xlApp);
        }

        private void updateDealerCodeDictionary(string dealerCode, TradewebData tradewebData)
        {
            if (tradewebData != null)
            {
                if (this.dealerCodeDictionary.ContainsKey(dealerCode) == false)
                {
                    this.dealerCodeDictionary.Add(dealerCode, tradewebData);
                }
                else
                {
                    this.dealerCodeDictionary[dealerCode] = tradewebData;
                }
            }            
        }

        private void createPath(string path)
        {
            if (Directory.Exists(path) == false)
            {
                Directory.CreateDirectory(path);
            }
        }

        private void createDealerCodeDictionaryJsonFile()
        {
            string json = JsonConvert.SerializeObject(this.dealerCodeDictionary);

            System.IO.File.WriteAllText(@"json\\dealerCodeMapping.json", json);
        }

        private void BrowseButton_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {
                this.PathTextbox.Text = openFileDialog1.FileName;
            }
        }

        private void GenerateButton_Click(object sender, EventArgs e)
        {
            this.BrowseButton.Visible = false;
            this.GenerateButton.Visible = false;
            this.ProgressBar.Visible = true;

            this.createJsonFiles(this.PathTextbox.Text);

            this.ProgressBar.Visible = false;
            this.BrowseButton.Visible = true;
            this.GenerateButton.Visible = true;
        }
    }
}
