using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using PianoForte.Interface;
using PianoForte.Constant;
using PianoForte.Manager;
using PianoForte.Model;

namespace PianoForte.View
{
    public partial class CdMainForm : Form, FormInterface
    {
        private List<Cd> cdList;

        public CdMainForm()
        {
            InitializeComponent();
        }

        private void CDMainForm_Load(object sender, EventArgs e)
        {

        }

        public void load(MainForm mainForm)
        {
            this.cdList = new List<Cd>();            

            this.ComboBox_Status.Items.Clear();
            this.ComboBox_Status.Items.Add(Cd.CdStatus.ALL.ToString());
            this.ComboBox_Status.Items.Add(Cd.CdStatus.AVAILABLE.ToString());
            this.ComboBox_Status.Items.Add(Cd.CdStatus.EMPTY.ToString());
            this.ComboBox_Status.Items.Add(Cd.CdStatus.CANCELED.ToString());

            this.DataGridView_CdInfo.AutoGenerateColumns = false;

            this.ComboBox_NumberPerPage.Items.Clear();
            this.ComboBox_NumberPerPage.Items.Add("20");
            this.ComboBox_NumberPerPage.Items.Add("40");
            this.ComboBox_NumberPerPage.Items.Add("60");
        }

        public void reload()
        {
            //Do Nothing
        }

        public void reset()
        {
            this.cdList.Clear();

            this.RadioButton_Show_AllCd.Checked = true;
            this.RadioButton_Search_CdId.Checked = false;
            this.RadioButton_Search_Info.Checked = false;

            this.TextBox_CdId_ForSearch.Text = "";
            this.TextBox_Barcode_ForSearch.Text = "";
            this.TextBox_CdName_ForSearch.Text = "";

            if (this.ComboBox_Status.Items.Count > 0)
            {
                this.ComboBox_Status.SelectedIndex = 0;
            }

            if (this.ComboBox_NumberPerPage.Items.Count > 0)
            {
                this.ComboBox_NumberPerPage.SelectedIndex = 0;
            }

            this.TextBox_PageNumber.Text = "1";

            this.refreshDataGridView_CdInfo();
        }

        private void keyPressed(KeyEventArgs keyEventArgs)
        {
            if (keyEventArgs.KeyData == Keys.Enter)
            {
                this.TextBox_PageNumber.Text = "1";
                this.search();
            }
        }

        private void refreshDataGridView_CdInfo()
        {
            this.DataGridView_CdInfo.DataSource = null;

            if (this.cdList.Count > 0)
            {
                this.DataGridView_CdInfo.DataSource = this.cdList;
            }

            this.DataGridView_CdInfo.ClearSelection();
        }

        private void search()
        {
            if (MainForm.currentForm is CdMainForm)
            {
                List<Cd> tempCdList = new List<Cd>();

                int numberPerPage = Convert.ToInt32(this.ComboBox_NumberPerPage.Text);
                int pageNumber = Convert.ToInt32(this.TextBox_PageNumber.Text);
                int startIndex = (pageNumber - 1) * numberPerPage;

                if (this.RadioButton_Show_AllCd.Checked)
                {
                    this.cdList = CdManager.findAllCd(startIndex, numberPerPage);
                    tempCdList = CdManager.findAllCd(startIndex + numberPerPage, numberPerPage);
                }
                else if (this.RadioButton_Search_CdId.Checked)
                {
                    this.cdList.Clear();

                    string temp = this.TextBox_CdId_ForSearch.Text;
                    if (temp != "")
                    {
                        int cdId = Convert.ToInt32(temp);

                        Cd cd = CdManager.findCd(cdId);
                        if (cd != null)
                        {
                            this.cdList.Add(cd);
                        }
                    }
                }
                else if (this.RadioButton_Search_CdBarcode.Checked)
                {
                    this.cdList.Clear();

                    string barcode = this.TextBox_Barcode_ForSearch.Text;
                    if (barcode != "")
                    {
                        Cd cd = CdManager.findCdByBarcode(barcode);
                        if (cd != null)
                        {
                            this.cdList.Add(cd);
                        }
                    }
                }
                else if (this.RadioButton_Search_Info.Checked)
                {
                    string barcode = this.TextBox_Barcode_ForSearch.Text;
                    string cdName = this.TextBox_CdName_ForSearch.Text;
                    Cd.CdStatus status = (Cd.CdStatus)this.ComboBox_Status.SelectedIndex;

                    if (cdName == "")
                    {
                        this.cdList = CdManager.findAllCd(status, startIndex, numberPerPage);
                        tempCdList = CdManager.findAllCd(status, startIndex + numberPerPage, numberPerPage);
                    } 
                    else
                    {
                        this.cdList = CdManager.findAllCdByName(cdName, status, startIndex, numberPerPage);
                        tempCdList = CdManager.findAllCdByName(cdName, status, startIndex + numberPerPage, numberPerPage);
                    }                    
                }

                if (this.cdList.Count == 0)
                {
                    MessageBox.Show(DatabaseConstant.DATA_NOT_FOUND);
                }
                else if (this.cdList.Count < numberPerPage)
                {
                    this.Button_NextPage.Enabled = false;
                }
                else if (this.cdList.Count == numberPerPage)
                {
                    this.refreshButton_NextPage(tempCdList);
                }

                this.refreshDataGridView_CdInfo();
            }

            this.TextBox_CdId_ForSearch.Text = "";
            this.TextBox_Barcode_ForSearch.Text = "";
            this.TextBox_CdName_ForSearch.Text = "";

            if (this.ComboBox_Status.Items.Count > 0)
            {
                this.ComboBox_Status.SelectedIndex = 0;
            }
        }

        private void refreshButton_NextPage(List<Cd> cdList)
        {
            if (cdList.Count > 0)
            {
                this.Button_NextPage.Enabled = true;
            }
            else
            {
                this.Button_NextPage.Enabled = false;
            }
        }

        private void RadioButton_Show_AllCd_CheckedChanged(object sender, EventArgs e)
        {
            this.TextBox_CdId_ForSearch.Enabled = false;
            this.TextBox_Barcode_ForSearch.Enabled = false;
            this.TextBox_CdName_ForSearch.Enabled = false;
            this.ComboBox_Status.Enabled = false;
        }

        private void RadioButton_Show_AllCd_KeyDown(object sender, KeyEventArgs e)
        {
            this.keyPressed(e);
        }

        private void RadioButton_Search_CdId_CheckedChanged(object sender, EventArgs e)
        {
            this.TextBox_CdId_ForSearch.Enabled = true;
            this.TextBox_Barcode_ForSearch.Enabled = false;
            this.TextBox_CdName_ForSearch.Enabled = false;
            this.ComboBox_Status.Enabled = false;

            this.TextBox_Barcode_ForSearch.Text = "";
            this.TextBox_CdName_ForSearch.Text = "";

            if (this.ComboBox_Status.Items.Count > 0)
            {
                this.ComboBox_Status.SelectedIndex = 0;
            }
        }

        private void RadioButton_Search_CdId_KeyDown(object sender, KeyEventArgs e)
        {
            this.keyPressed(e);
        }

        private void RadioButton_Search_CdBarcode_CheckedChanged(object sender, EventArgs e)
        {
            this.TextBox_CdId_ForSearch.Enabled = false;
            this.TextBox_Barcode_ForSearch.Enabled = true;
            this.TextBox_CdName_ForSearch.Enabled = false;
            this.ComboBox_Status.Enabled = false;

            this.TextBox_CdId_ForSearch.Text = "";
            this.TextBox_CdName_ForSearch.Text = "";

            if (this.ComboBox_Status.Items.Count > 0)
            {
                this.ComboBox_Status.SelectedIndex = 0;
            }
        }

        private void RadioButton_Search_Info_CheckedChanged(object sender, EventArgs e)
        {
            this.TextBox_CdId_ForSearch.Enabled = false;
            this.TextBox_Barcode_ForSearch.Enabled = false;
            this.TextBox_CdName_ForSearch.Enabled = true;
            this.ComboBox_Status.Enabled = true;

            this.TextBox_CdId_ForSearch.Text = "";
            this.TextBox_Barcode_ForSearch.Text = "";            
        }

        private void RadioButton_Search_Info_KeyDown(object sender, KeyEventArgs e)
        {
            this.keyPressed(e);
        }

        private void TextBox_CdId_ForSearch_KeyDown(object sender, KeyEventArgs e)
        {
            this.keyPressed(e);
        }

        private void TextBox_Barcode_ForSearch_KeyDown(object sender, KeyEventArgs e)
        {
            this.keyPressed(e);
        }

        private void TextBox_CdName_ForSearch_KeyDown(object sender, KeyEventArgs e)
        {
            this.keyPressed(e);
        }

        private void ComboBox_Status_KeyDown(object sender, KeyEventArgs e)
        {
            this.keyPressed(e);
        }

        private void Button_Search_Click(object sender, EventArgs e)
        {
            this.TextBox_PageNumber.Text = "1";
            this.search();
        }

        private void DataGridView_CdInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                Cd cd = new Cd();
                bool isNeedToUpdate = false;

                switch (e.ColumnIndex)
                {
                    case 6:
                        {
                            CdDetailForm cdDetailForm = new CdDetailForm();
                            cd = cdDetailForm.showFormDialog(this.cdList[e.RowIndex], false);
                            isNeedToUpdate = true;
                        }
                        break;
                    case 7:
                        {
                            CdDetailForm cdDetailForm = new CdDetailForm();
                            cd = cdDetailForm.showFormDialog(this.cdList[e.RowIndex], true);
                            isNeedToUpdate = true;
                        }
                        break;
                }

                if (isNeedToUpdate)
                {
                    for (int i = 0; i < this.cdList.Count; i++)
                    {
                        if (this.cdList[i].Id == cd.Id)
                        {
                            this.cdList[i] = cd;
                        }
                    }

                    this.refreshDataGridView_CdInfo();
                }                
            }

            this.Cursor = Cursors.Arrow;
        }

        private void DataGridView_CdInfo_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                switch (e.ColumnIndex)
                {
                    case 6:
                        this.Cursor = Cursors.Hand;
                        this.DataGridView_CdInfo.Rows[e.RowIndex].Cells[e.ColumnIndex].ToolTipText = "View";
                        break;
                    case 7:
                        this.Cursor = Cursors.Hand;
                        this.DataGridView_CdInfo.Rows[e.RowIndex].Cells[e.ColumnIndex].ToolTipText = "Edit";
                        break;
                }
            }
        }

        private void DataGridView_CdInfo_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            this.Cursor = Cursors.Arrow;
        }        

        private void ComboBox_NumberPerPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.TextBox_PageNumber.Text = "1";
            this.search();
        }

        private void Button_PreviousPage_Click(object sender, EventArgs e)
        {
            int currentPageNumber = Convert.ToInt32(this.TextBox_PageNumber.Text) - 1;
            this.TextBox_PageNumber.Text = currentPageNumber.ToString();
            this.search();
        }

        private void TextBox_PageNumber_TextChanged(object sender, EventArgs e)
        {
            if (this.TextBox_PageNumber.Text == "1")
            {
                this.Button_PreviousPage.Enabled = false;
            }
            else
            {
                this.Button_PreviousPage.Enabled = true;
            }
        }

        private void Button_NextPage_Click(object sender, EventArgs e)
        {
            int currentPageNumber = Convert.ToInt32(this.TextBox_PageNumber.Text) + 1;
            this.TextBox_PageNumber.Text = currentPageNumber.ToString();
            this.search();
        }

        private void Button_Add_Cd_Click(object sender, EventArgs e)
        {
            AddCdDetailForm addCdDetailForm = new AddCdDetailForm();
            addCdDetailForm.showFormDialog();
        }        
    }
}
