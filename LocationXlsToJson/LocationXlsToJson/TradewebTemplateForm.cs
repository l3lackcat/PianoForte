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
    public partial class TradewebTemplateForm : Form
    {
        private Dictionary<string, TradewebTemplate> tradewebTemplateDictionary = new Dictionary<string, TradewebTemplate>();
        public TradewebTemplateForm()
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
            for (int i = 1; i <= rowCount; i++)
            {
                string pgrp = "";
                string sgrp = "";
                int displayedTemplate = 0;
                TradewebTemplate tradewebTemplate = new TradewebTemplate();

                for (int j = 1; j <= colCount; j++)
                {
                    if (j == 1)
                    {
                        pgrp = xlRange.Cells[i, j].Value2.ToString();
                    }
                    else if (j == 2)
                    {
                        sgrp = xlRange.Cells[i, j].Value2.ToString();
                    }
                    else if (j == 3)
                    {
                        displayedTemplate = Convert.ToInt32(xlRange.Cells[i, j].Value2.ToString());
                    }
                    else if (j == 4)
                    {
                        tradewebTemplate.QuantityTemplate = xlRange.Cells[i, j].Value2.ToString();
                    }
                    else if (j == 5)
                    {
                        tradewebTemplate.MaxNoOfDealers = Convert.ToInt32(xlRange.Cells[i, j].Value2.ToString());
                    }
                }

                updateDealerTemplateDictionary(pgrp, sgrp, displayedTemplate, tradewebTemplate);

                this.ProgressBar.Value = i;
            }

            createPath("json");
            createTradewebTemplateDictionaryJsonFile();

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

        private void updateDealerTemplateDictionary(string pgrp, string sgrp, int displayedTemplate, TradewebTemplate tradewebTemplate)
        {
            if (tradewebTemplate != null)
            {
                if (this.tradewebTemplateDictionary.ContainsKey(pgrp) == false)
                {
                    tradewebTemplate.DisplayedTemplateDictioanry.Add(sgrp, displayedTemplate);
                    this.tradewebTemplateDictionary.Add(pgrp, tradewebTemplate);
                }
                else
                {
                    Dictionary<string, int> displayedTemplateDictioanry = this.tradewebTemplateDictionary[pgrp].DisplayedTemplateDictioanry;
                    displayedTemplateDictioanry.Add(sgrp, displayedTemplate);

                    this.tradewebTemplateDictionary[pgrp].DisplayedTemplateDictioanry = displayedTemplateDictioanry;
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

        private void createTradewebTemplateDictionaryJsonFile()
        {
            string json = JsonConvert.SerializeObject(this.tradewebTemplateDictionary);

            System.IO.File.WriteAllText(@"json\\tradewebTemplateMapping.json", json);
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
