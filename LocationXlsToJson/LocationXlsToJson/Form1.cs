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
        private List<string> postcodeList = new List<string>();
        private List<string> provinceList = new List<string>();
        private List<string> districtList = new List<string>();
        private List<string> subDistrictList = new List<string>();

        private Dictionary<string, List<string>> postCodeToProvinceDictionary = new Dictionary<string, List<string>>();
        private Dictionary<string, List<string>> provinceToDistrictDictionary = new Dictionary<string, List<string>>();
        private Dictionary<string, List<string>> districtToSubDistrictDictionary = new Dictionary<string, List<string>>();

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

                updatePostCodeToProvinceDictionary(postcode, province);
                updateProvinceToDistrictDictionary(province, district);
                updateDistrictToSubDistrictDictionary(district, subDistrict);
                updatePostcodeList(postcode);
                updateProvinceList(province);
                updateDistrictList(district);
                updateSubDistrictList(subDistrict);                

                this.ProgressBar.Value = i;
            }

            createPath("json");
            createPostCodeToProvinceDictionaryJsonFile();
            createProvinceToDistrictDictionaryJsonFile();
            createDistrictToSubDistrictDictionaryJsonFile();
            createPostcodeJsonFile();
            createProvinceJsonFile();
            createDistrictJsonFile();
            createSubDistrictJsonFile();

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

        private void updatePostCodeToProvinceDictionary(string postcode, string province)
        {
            if (this.postCodeToProvinceDictionary.ContainsKey(postcode) == false)
            {
                List<string> provinceList = new List<string>();
                provinceList.Add(province);
                this.postCodeToProvinceDictionary.Add(postcode, provinceList);
            }
            else
            {
                List<string> provinceList = this.postCodeToProvinceDictionary[postcode];

                if (provinceList != null)
                {
                    if (provinceList.Contains(province) == false)
                    {
                        provinceList.Add(province);
                    }
                }
            }
        }

        private void updateProvinceToDistrictDictionary(string province, string district)
        {
            if (this.provinceToDistrictDictionary.ContainsKey(province) == false)
            {
                List<string> districtList = new List<string>();
                districtList.Add(district);
                this.provinceToDistrictDictionary.Add(province, districtList);
            }
            else
            {
                List<string> districtList = this.provinceToDistrictDictionary[province];

                if (districtList != null)
                {
                    if (districtList.Contains(district) == false)
                    {
                        districtList.Add(district);
                    }
                }
            }
        }

        private void updateDistrictToSubDistrictDictionary(string district, string subDistrict)
        {
            if (this.districtToSubDistrictDictionary.ContainsKey(district) == false)
            {
                List<string> subDistrictList = new List<string>();
                subDistrictList.Add(subDistrict);
                this.districtToSubDistrictDictionary.Add(district, subDistrictList);
            }
            else
            {
                List<string> subDistrictList = this.districtToSubDistrictDictionary[district];

                if (subDistrictList != null)
                {
                    if (subDistrictList.Contains(subDistrict) == false)
                    {
                        subDistrictList.Add(subDistrict);
                    }
                }
            }
        }

        private void updatePostcodeList(string postcode)
        {
            if (this.postcodeList.Contains(postcode) == false)
            {
                this.postcodeList.Add(postcode);
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

        private void createPath(string path)
        {
            if (Directory.Exists(path) == false)
            {
                Directory.CreateDirectory(path);
            }                
        }

        private void createPostCodeToProvinceDictionaryJsonFile()
        {
            string json = JsonConvert.SerializeObject(this.postCodeToProvinceDictionary);

            System.IO.File.WriteAllText(@"json\\PostcodeToProvince.json", json);
        }

        private void createProvinceToDistrictDictionaryJsonFile()
        {
            string json = JsonConvert.SerializeObject(this.provinceToDistrictDictionary);

            System.IO.File.WriteAllText(@"json\\ProvinceToDistrict.json", json);
        }

        private void createDistrictToSubDistrictDictionaryJsonFile()
        {
            string json = JsonConvert.SerializeObject(this.districtToSubDistrictDictionary);

            System.IO.File.WriteAllText(@"json\\DistrictToSubDistrictDictionary.json", json);
        }

        private void createPostcodeJsonFile()
        {
            string json = JsonConvert.SerializeObject(this.postcodeList);

            System.IO.File.WriteAllText(@"json\\Postcode.json", json);
        }

        private void createProvinceJsonFile()
        {
            string json = JsonConvert.SerializeObject(this.provinceList);

            System.IO.File.WriteAllText(@"json\\Province.json", json);
        }

        private void createDistrictJsonFile()
        {
            string json = JsonConvert.SerializeObject(this.districtList);

            System.IO.File.WriteAllText(@"json\\District.json", json);
        }

        private void createSubDistrictJsonFile()
        {
            string json = JsonConvert.SerializeObject(this.subDistrictList);

            System.IO.File.WriteAllText(@"json\\SubDistrict.json", json);
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
