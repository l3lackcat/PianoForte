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
    public partial class Form1 : Form
    {
        private Dictionary<string, LocationData> postcodeDictionary = new Dictionary<string, LocationData>();
        private List<string> provinceList = new List<string>();
        private List<string> districtList = new List<string>();
        private List<string> subDistrictList = new List<string>();

        public Form1()
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
            for (int i = 3; i <= rowCount; i++)
            {
                string postcode = xlRange.Cells[i, 5].Value2.ToString();
                string province = xlRange.Cells[i, 2].Value2.ToString();
                string district = xlRange.Cells[i, 3].Value2.ToString();
                string subDistrict = xlRange.Cells[i, 4].Value2.ToString();

                updatePostcodeDictionary(postcode, province, district, subDistrict);
                updateProvinceList(province);
                updateDistrictList(district);
                updateSubDistrictList(subDistrict);                

                this.ProgressBar.Value = i;
            }

            createPostcodeJsonFile(this.postcodeDictionary);
            createProvinceJsonFile(this.provinceList);
            createDistrictJsonFile(this.districtList);
            createSubDistrictJsonFile(this.subDistrictList);

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

        private void updatePostcodeDictionary(string postcode, string province, string district, string subDistrict)
        {
            if (this.postcodeDictionary.ContainsKey(postcode) == false)
            {
                LocationData locationData = new LocationData();

                locationData.Provinces.Add(province);
                locationData.Districts.Add(district);
                locationData.SubDistricts.Add(subDistrict);

                this.postcodeDictionary.Add(postcode, locationData);
            }
            else
            {
                LocationData locationData = this.postcodeDictionary[postcode];

                if (locationData != null)
                {
                    if (locationData.Provinces.Contains(province) == false)
                    {
                        locationData.Provinces.Add(province);
                    }

                    if (locationData.Districts.Contains(district) == false)
                    {
                        locationData.Districts.Add(district);
                    }

                    if (locationData.SubDistricts.Contains(subDistrict) == false)
                    {
                        locationData.SubDistricts.Add(subDistrict);
                    }
                }
            }
        }

        private void updateProvinceList(string province)
        {
            if (this.provinceList.Contains(province) == false)
            {
                this.provinceList.Add(province);
            }
        }

        private void updateDistrictList(string district)
        {            
            if (this.districtList.Contains(district) == false)
            {
                this.districtList.Add(district);
            }
        }

        private void updateSubDistrictList(string subDistrict)
        {            
            if (this.subDistrictList.Contains(subDistrict) == false)
            {
                this.subDistrictList.Add(subDistrict);
            }
        }

        private void createPostcodeJsonFile(Dictionary<string, LocationData> postcodeDictionary)
        {
            string postcodeJson = JsonConvert.SerializeObject(this.postcodeDictionary);

            System.IO.File.WriteAllText(@"postcode.json", postcodeJson);
        }

        private void createProvinceJsonFile(List<string> provinceList)
        {
            string provinceJson = JsonConvert.SerializeObject(this.provinceList);

            System.IO.File.WriteAllText(@"province.json", provinceJson);
        }

        private void createDistrictJsonFile(List<string> districtList)
        {
            string districtJson = JsonConvert.SerializeObject(this.districtList);

            System.IO.File.WriteAllText(@"district.json", districtJson);
        }

        private void createSubDistrictJsonFile(List<string> subDistrictList)
        {
            string subDistrictJson = JsonConvert.SerializeObject(this.subDistrictList);

            System.IO.File.WriteAllText(@"sub-district.json", subDistrictJson);
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
