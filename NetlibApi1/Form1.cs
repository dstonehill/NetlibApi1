﻿using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.IO;    

namespace NetlibApi1
{
    public partial class Form1 : Form
    {


        public Form1()
        {
            InitializeComponent();
        }

        /*
         * Create Customer
         */
        private void button1_Click(object sender, EventArgs e)
        {
            //testing adding a static customer - trying out SWK api's
            if (txtNewCustomer.Text != "")
            {
                int newId = ApiAccess.addSWKCustomer(txtNewCustomer.Text, "Joe", "Bigshot", "1 Main St.", "2nd Fl", "New York", "NY", "10010", "USA", "joe@acme.com", "netlibpwd??", "555-1212", "555-1313", "Joey");
                if (newId < 0)
                    MessageBox.Show("Error adding user. Error was: " + newId.ToString());
                else
                {
                    // Success!!  Maybe here add the user to the SQL database?
                }
            }
        }

        /* 
         * Retrieve SQL -- all users
         */
        private void button2_Click(object sender, EventArgs e)
        {
            DataAccess.getCustomers(lstCustomers);
        }

        private void butAddress3_Click(object sender, EventArgs e)
        {
            // If the user selected a customer AND the new address is not blank
            if (lstCustomers.SelectedIndex > -1 && txtAddressLine3.Text != "")
            {
                // Get the entry. We put the ID after the dash so split on the dash
                string entry = lstCustomers.Items[lstCustomers.SelectedIndex].ToString();
                string[] aryParts = entry.Split('\t');
                if (aryParts.Length == 2)
                {
                    string Id = aryParts[1].Trim();
                    if (Id != "")
                    {
                        DataAccess.updateAddress3(Id, txtAddressLine3.Text);
                    }

                }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }


        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            // If the user entered a Customer  ID
            if (txtSearchCustomer.Text != "")
            {
                // convert to integer and then find customer in soloserver
                //int numCustID = Convert.ToInt32(txtSearchCustomer.Text)
                XmlNode result = ApiAccess.searchSWKCustomer(CustID: txtSearchCustomer.Text);

                // Check to make sure there was a good node of data back
                XmlNode custNode = result.SelectSingleNode("Customer/CompanyName");
                if (custNode == null)
                    txtCustInfo.Text = "No data found";
                else
                    txtCustInfo.Text = custNode.InnerText;

            }
        }

        private void btnLicenses_Click(object sender, EventArgs e)
        {
            // test getting data from SQL database
            // getting licenses/Serial Numbers from SQL
            // If the user entered an Account  ID
            if (txtAcctID.Text != "")
            {
                // search for licenses based on Account ID

                DataAccess.getLicenses(lstLicenses, txtAcctID.Text);



            }
        }

        private void btnSearchLic_Click(object sender, EventArgs e)
        {
            // If the user entered a License  ID
            if (txtSearchLicense.Text != "")
            {
                // convert to integer and then find License in soloserver
                //int numCustID = Convert.ToInt32(txtSearchCustomer.Text)
                XmlNode result = ApiAccess.searchSWKLicense(LicID: txtSearchLicense.Text);

                // Check to make sure there was a good node of data back
                XmlNode LicNode = result.SelectSingleNode("ResultCode");

                if (LicNode == null)
                    txtLicInfo.Text = "No data found";
                else if (LicNode.InnerText != "0")

                { txtLicInfo.Text = "License not found. Result: " + LicNode.InnerText; }
                else

                {
                    LicNode = result.SelectSingleNode("CustomerID");
                    txtLicInfo.Text = "Company:" + LicNode.InnerText + " \n ";
                    txtLicInfo.Text += "License ID:" + txtSearchLicense.Text + " \n ";
                    LicNode = result.SelectSingleNode("ProductName");
                    txtLicInfo.Text += " Prod:" + LicNode.InnerText;
                    LicNode = result.SelectSingleNode("OptionName");
                    txtLicInfo.Text += " " + LicNode.InnerText;

                }


            }
        }

        private void btnGetAccts_Click(object sender, EventArgs e)
        {
            int searchtype = 1;
            Boolean gotosearch = false;

            if (radioAll.Checked)
            {
                searchtype = 1;
                gotosearch = true;
                if (txtClientID1.Text != "")
                {
                    MessageBox.Show("Warning - client ID will be ignored");
                }
            }
            else
            if (radioSingle.Checked)
            {
                if (txtClientID1.Text == "")
                {
                    MessageBox.Show("Error - must include From clientID");
                }
                else
                {
                    searchtype = 2;
                    gotosearch = true;
                }
            }
            else
            //radioRange checked
            {
                if (txtClientID1.Text == "")
                {
                    MessageBox.Show("Error - must include From clientID");
                }
                else
                {
                    searchtype = 3;
                    gotosearch = true;
                }
            }

            if (gotosearch)
            {
                DataAccess.getAccounts(searchtype, txtClientID1.Text, txtClientID2.Text, lstCustomers);
            }

        }

        private void radioAll_CheckedChanged(object sender, EventArgs e)
        {
            if (radioAll.Checked == true)
            {
                txtClientID1.Enabled = false;
                txtClientID2.Enabled = false;
                if (txtClientID1.Text != "")
                {
                    MessageBox.Show("The 'From' Client ID will be ignored");
                }
                if (txtClientID2.Text != "")
                {
                    MessageBox.Show("The 'To:' Client ID will be ignored");
                }
            }
        }

        private void radioSingle_CheckedChanged(object sender, EventArgs e)
        {
            if (radioSingle.Checked == true)
            {
                txtClientID1.Enabled = true;
                txtClientID2.Enabled = false;
                if (txtClientID2.Text != "")
                {
                    MessageBox.Show("The 'To:' Client ID will be ignored");
                }
            }
        }

        private void radioRange_CheckedChanged(object sender, EventArgs e)
        {
            txtClientID1.Enabled = true;
            txtClientID2.Enabled = true;

        }

        private void radioAllA_CheckedChanged(object sender, EventArgs e)
        {
            if (radioAllA.Checked == true)
            {
                txtClientID1A.Enabled = false;
                txtClientID2A.Enabled = false;
                if (txtClientID1A.Text != "")
                {
                    MessageBox.Show("The 'From' Client ID will be ignored");
                }
                if (txtClientID2A.Text != "")
                {
                    MessageBox.Show("The 'To:' Client ID will be ignored");
                }
            }
        }

        private void radioSingleA_CheckedChanged(object sender, EventArgs e)
        {
            if (radioSingleA.Checked == true)
            {
                txtClientID1A.Enabled = true;
                txtClientID2A.Enabled = false;
                if (txtClientID2A.Text != "")
                {
                    MessageBox.Show("The 'To:' Client ID will be ignored");
                }
            }
        }

        private void radioRangeA_CheckedChanged(object sender, EventArgs e)
        {
            txtClientID1A.Enabled = true;
            txtClientID2A.Enabled = true;

        }

        private void btnAddCustAndLic_Click(object sender, EventArgs e)
        {
            int searchtype = 1;
            Boolean gotosearch = false;

            if (radioAllA.Checked)
            {
                searchtype = 1;
                gotosearch = true;
                if (txtClientID1A.Text != "")
                {
                    MessageBox.Show("Warning - client ID will be ignored");
                }
            }
            else
            if (radioSingleA.Checked)
            {
                if (txtClientID1A.Text == "")
                {
                    MessageBox.Show("Error - must include From clientID");
                }
                else
                {
                    searchtype = 2;
                    gotosearch = true;
                }
            }
            else
            //radioRange checked
            {
                if (txtClientID1A.Text == "")
                {
                    MessageBox.Show("Error - must include From clientID");
                }
                else
                {
                    searchtype = 3;
                    gotosearch = true;
                }
            }

            if (gotosearch)
            {
                ImportData.procAccounts(searchtype, txtClientID1A.Text, txtClientID2A.Text, lstCustomers, lstLicenses, checkBoxTestA.Checked, checkBoxCustOnly.Checked);
            }

        }

        private void btnAddLicense_Click(object sender, EventArgs e)
        {

            //AddSWKLicense(string OptionID, string Qty, string expire, string ActCount, string DeactCount, string cores, string note, string custID, bool test)
            XmlNode resultAdd = ApiAccess.AddSWKLicense("1036", "3", "12/31/2020", "1", "0", "12", "a note goes here", "4400028", "", checkBoxTest.Checked);

            // Check to make sure there was a good node of data back
            XmlNode LicNode = resultAdd.SelectSingleNode("ResultCode");

            if (LicNode == null)
                txtLicInfo.Text = "No data found";
            else if (LicNode.InnerText != "0")
                txtLicInfo.Text = "Insert Error: " + LicNode.InnerText;
            else

            {
                LicNode = resultAdd.SelectSingleNode("LicenseID");
                txtLicInfo.Text = "LicenseID: " + LicNode.InnerText + " \n ";
                string LicID = LicNode.InnerText;
                LicNode = resultAdd.SelectSingleNode("ActivationPassword");
                txtLicInfo.Text += "ActivationPassword: " + LicNode.InnerText;
                string LicPwd = LicNode.InnerText;

                // update User Defined fields
                //UpdateSWKLicenseFields(string LicID, string LicPwd, string UDF1, string UDF2, string UDF3)
                XmlNode resultUpdUDF = ApiAccess.UpdateSWKLicenseFields(LicID, LicPwd, "Previous Serial Number: 001-204290-001-001-0", "udf2", "udf3");

                //Check results of update
                XmlNode LicUpdUDF = resultUpdUDF.SelectSingleNode("ResultCode");
                if (LicUpdUDF == null)
                    txtLicInfo.Text += " UDF result: null";
                else if (LicUpdUDF.InnerText != "0")
                    txtLicInfo.Text += " UDF Error: " + LicUpdUDF.InnerText;
                else
                    txtLicInfo.Text += " UDF Added";

                // update CustomData
                //UpdateSWKLicenseCData(string LicID, string cdata)

                //build Custom Data
                string inputCData = "<CustomParameters><IsServer>True</IsServer><IsExecsOverride>False</IsExecsOverride><ExecsAllowed>Example String Value</ExecsAllowed><SQLEdition>4</SQLEdition><IsWholeDB>True</IsWholeDB><IsColumn>True</IsColumn><KeyLength>256</KeyLength><IsFolder>True</IsFolder><Instances>31</Instances><SysIdent>True</SysIdent></CustomParameters>";

                // make the call to update custom data
                XmlNode resultUpdCData = ApiAccess.UpdateSWKLicenseCData(LicID, inputCData);

                //Check results of update
                XmlNode LicUpdCData = resultUpdCData.SelectSingleNode("ResultCode");
                if (LicUpdCData == null)
                    txtLicInfo.Text += " CData result: null";
                else if (LicUpdCData.InnerText != "0")
                    txtLicInfo.Text += " CData Error: " + LicUpdCData.InnerText;
                else
                    txtLicInfo.Text += " CData Added";


            }

        }

        // testing adding Custom Data to a license
        private void button3_Click(object sender, EventArgs e)
        {
            //License ID hardcoded for now
            string LicID = "6000090";
            txtLicInfo.Text = "License ID:" + LicID;

            //build Custom Data
            string inputCData = "<CustomParameters><IsLease>False</IsLease><IsExecsOverride>False</IsExecsOverride><KeyLength>256</KeyLength><Instances>31</Instances><MaxSize>65536</MaxSize><NumProcesses>63</NumProcesses><NumFiles>128</NumFiles><IsGUIsAllowed>True</IsGUIsAllowed><IsCLIAllowed>True</IsCLIAllowed><IsTimeLtd>False</IsTimeLtd></CustomParameters>";

            // make the call to update custom data
            XmlNode resultUpdCData = ApiAccess.UpdateSWKLicenseCData(LicID, inputCData);

            //Check results of update
            XmlNode LicUpdCData = resultUpdCData.SelectSingleNode("ResultCode");
            if (LicUpdCData == null)
                txtLicInfo.Text += " CData result: null";
            else if (LicUpdCData.InnerText != "0")
                txtLicInfo.Text += " CData Error: " + LicUpdCData.InnerText;
            else
                txtLicInfo.Text += " CData Added";

        }

        private void btnSearchName_Click(object sender, EventArgs e)
        {

            // If the user entered a Customer  ID
            if (txtSearchName.Text != "")
            {
                XmlNode result = ApiAccess.searchSWKCustName(txtSearchName.Text);

                // Check to make sure there was a good node of data back
                XmlNode custNode = result.SelectSingleNode("ResultCode");

                if (custNode == null)
                    txtCustInfo.Text = "No data found";
                else if (custNode.InnerText != "0")
                {
                    txtCustInfo.Text = "Customer Name not found" + txtSearchName.Text;
                }
                else
                {
                    custNode = result.SelectSingleNode("Customer/CompanyName");
                    txtCustInfo.Text = "Company: " + custNode.InnerText;
                    custNode = result.SelectSingleNode("Customer/CustomerID");
                    txtCustInfo.Text += " Customer ID: " + custNode.InnerText;

                }

            }
        }

        private void btnTest1_Click(object sender, EventArgs e)
        {
            DataAccess.updateCustSWKData("00130000011dtto1", "10", "apassword", "newmail", "Modify");
        }

        private void btnTest2_Click(object sender, EventArgs e)
        {
            DataAccess.updateLicSWKData("a063000000V7LSi", "", "410", "apassword1", "Modify");
        }

        private void btnTestDate_Click(object sender, EventArgs e)
        {
            string timetest = "5/1/2020 12:00 AM";
            string[] aryParts = timetest.Split(' ');
            if (aryParts.Length > 1)
            {
                txtCustInfo.Text = aryParts[0].Trim();

            }
        }

        private void btnWrite_Click(object sender, EventArgs e)
        {
            //testing writing to a file
            // Set a variable to the Documents path.
            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            //create file name
            DateTime d = DateTime.Now;
            string dateString = d.ToString("yyyyMMddHHmmss");
            string filename1 = "customers-" + dateString + ".txt";
            string fullpath = Path.Combine(docPath, filename1);

            // Create a string with a line of text.
            string text1 = txtAddressLine3.Text + Environment.NewLine;


            // Write the text to a new file named "WriteFile.txt".
            File.WriteAllText(fullpath, text1);

            // create new line and append that
            text1 += " more text" + Environment.NewLine;

            // Append new lines of text to the file
            File.AppendAllText(fullpath, text1);
        }

        private void btnOpenCust_Click(object sender, EventArgs e)
        {
            lstCustomers.Items.Clear();
            labelCustProcessed.Text = "";
            string AddCustResult = "";
            string NewLine = "";
            int AcctsProcessed = 0;
            bool FormatOK = false;

            // Show the dialog box
            OpenFileDialog fCustDialog = new OpenFileDialog();
            fCustDialog.Title = "Open Text File";
            fCustDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            //fCustDialog.InitialDirectory = @"C:\";
            fCustDialog.RestoreDirectory = true;


            if (fCustDialog.ShowDialog() == DialogResult.OK)
            {

                // Get the filename
                string strFilename = fCustDialog.FileName.ToString();

                //create log file name
                //set datetime of processing
                DateTime d = DateTime.Now;
                string dateString = d.ToString("yyyyMMddHHmmss");
                string strFileNameStub = fCustDialog.SafeFileName.ToString();
                string strLogFileNameStub = "ResultLog-" + strFileNameStub + "-" + dateString + ".log";
                string strLogFileName = strFilename.Replace(strFileNameStub, strLogFileNameStub);

                // Write header line to a new results file
                string logfiletext = "AcctName \t AcctID:  \t Add Result" + Environment.NewLine;
                File.WriteAllText(strLogFileName, logfiletext);


                // open import file
                StreamReader fp = new StreamReader(strFilename);
                int linecounter = 1;

                // first check if correct format if not, discontinue
                NewLine = fp.ReadLine();
                string[] aryFields = NewLine.Split('\t');
                int columns = aryFields.Length;
                if (aryFields.Length == 19)
                {
                    FormatOK = true;
                    linecounter += 1;
                }
                else
                {
                    string message = "Incorrect Format for Account File";
                    string title = "Error";
                    MessageBox.Show(message, title);
                    lstCustomers.Items.Add("Incorrect Account File Format. Columns =" + columns.ToString());
                    File.AppendAllText(strLogFileName, "Incorrect Account File Format. Columns =" + columns.ToString() + Environment.NewLine);

                }
                // For each line in the file...
                while (!fp.EndOfStream & FormatOK)
                {
                    // Split the line by Tab
                    NewLine = fp.ReadLine();
                    aryFields = NewLine.Split('\t');
                    columns = aryFields.Length;

                    // Check there are the right number of fields, otherwise ignore
                    if (aryFields.Length == 19)
                    {
                        if (linecounter == 1)
                        {
                            //header line - skip
                        }
                        else
                        {
                            //add record
                            string AccountName = aryFields[0].Trim('"');

                            //check if data in record
                            if (string.IsNullOrEmpty(AccountName))
                            {
                                //skip processing. probably last few blank records in tab delimited file
                            }
                            else
                            {
                                string AcctID = aryFields[3];

                                AddCustResult = DataAccess.AddAccount(NewLine);

                                lstCustomers.Items.Add(AccountName + " \t " + AcctID + " \t " + AddCustResult);
                                File.AppendAllText(strLogFileName, AccountName + " \t " + AcctID + " \t " + AddCustResult + Environment.NewLine);
                                AcctsProcessed += 1;
                            }
                        }
                    }
                    else
                    {
                        FormatOK = false;
                        lstCustomers.Items.Add("Incorrect Account File Format. Columns =" + columns.ToString());
                        File.AppendAllText(strLogFileName, "Incorrect Account File Format. Columns =" + columns.ToString() + Environment.NewLine);
                    }
                    linecounter += 1;
                }

                // Close the file
                fp.Close();

                lstCustomers.Items.Add("Customers Processed =" + AcctsProcessed.ToString());
                labelCustProcessed.Text = "Customers Processed =" + AcctsProcessed.ToString();

            }
        }

        private void btnLoadContacts_Click(object sender, EventArgs e)
        {
            //Load Contact records if Account Record exists
            lstCustomers.Items.Clear();
            labelCustProcessed.Text = "";
            string AddCustResult = "";
            string NewLine = "";
            int AcctsProcessed = 0;
            bool FormatOK = false;

            // Show the dialog box
            OpenFileDialog fCustDialog = new OpenFileDialog();
            fCustDialog.Title = "Open Text File";
            fCustDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            //fCustDialog.InitialDirectory = @"C:\";
            fCustDialog.RestoreDirectory = true;

            if (fCustDialog.ShowDialog() == DialogResult.OK)
            {

                // Get the filename
                string strFilename = fCustDialog.FileName.ToString();

                //create log file name
                //set datetime of processing
                DateTime d = DateTime.Now;
                string dateString = d.ToString("yyyyMMddHHmmss");
                string strFileNameStub = fCustDialog.SafeFileName.ToString();
                string strLogFileNameStub = "ResultLog-" + strFileNameStub + "-" + dateString + ".log";
                string strLogFileName = strFilename.Replace(strFileNameStub, strLogFileNameStub);

                // Write header line to a new results file
                string logfiletext = "AcctName \t AcctID:  \t Add Result" + Environment.NewLine;
                File.WriteAllText(strLogFileName, logfiletext);


                // open import file
                StreamReader fp = new StreamReader(strFilename);
                int linecounter = 1;

                // first check if correct format if not, discontinue
                NewLine = fp.ReadLine();
                string[] aryFields = NewLine.Split('\t');
                int columns = aryFields.Length;
                if (aryFields.Length == 12)
                {
                    FormatOK = true;
                    linecounter += 1;
                }
                else
                {
                    string message = "Incorrect Format for Contact File";
                    string title = "Error";
                    MessageBox.Show(message, title);
                    lstCustomers.Items.Add("Incorrect Contact File Format. Columns =" + columns.ToString());
                    File.AppendAllText(strLogFileName, "Incorrect Contact File Format. Columns =" + columns.ToString() + Environment.NewLine);
                }

                // For each line in the file...
                while (!fp.EndOfStream & FormatOK)
                {
                    // Split the line by Tab
                    NewLine = fp.ReadLine();
                    aryFields = NewLine.Split('\t');
                    columns = aryFields.Length;

                    // Check there are the right number of fields, otherwise ignore
                    if (aryFields.Length == 12)
                    {
                        if (linecounter == 1)
                        {
                            //header line - skip
                        }
                        else
                        {
                            //add record
                            string AccountName = aryFields[0].Trim('"');

                            //check if data in record
                            if (string.IsNullOrEmpty(AccountName))
                            {
                                //skip processing. probably last few blank records in tab delimited file
                            }
                            else
                            {
                                string AcctID = aryFields[7];
                                string ContactID = aryFields[10];

                                AddCustResult = DataAccess.AddContact(NewLine);

                                lstCustomers.Items.Add(AccountName + " \t " + AcctID + " \t " + AddCustResult);
                                File.AppendAllText(strLogFileName, AccountName + " \t " + AcctID + " \t " + AddCustResult + Environment.NewLine);

                                AcctsProcessed += 1;
                            }
                        }
                    }
                    else
                    {
                        FormatOK = false;
                        lstCustomers.Items.Add("Incorrect Contact File Format. Columns =" + columns.ToString());
                        File.AppendAllText(strLogFileName, "Incorrect Contact File Format. Columns =" + columns.ToString() + Environment.NewLine);

                    }
                    linecounter += 1;
                }

                // Close the file
                fp.Close();

                lstCustomers.Items.Add("Contacts Processed =" + AcctsProcessed.ToString());
                labelContactsProcessed.Text = "Contacts Processed =" + AcctsProcessed.ToString();

            }
        }

        private void btnLoadSN_Click(object sender, EventArgs e)
        {
            //Load SerialNumber records if Account Record exists
            lstCustomers.Items.Clear();
            lstLicenses.Items.Clear();
            labelSNProcessed.Text = "";
            string AddCustResult = "";
            string NewLine = "";
            int AcctsProcessed = 0;
            bool FormatOK = false;

            // Show the dialog box
            OpenFileDialog fCustDialog = new OpenFileDialog();
            fCustDialog.Title = "Open Text File";
            fCustDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            //fCustDialog.InitialDirectory = @"C:\";
            fCustDialog.RestoreDirectory = true;

            if (fCustDialog.ShowDialog() == DialogResult.OK)
            {

                // Get the filename
                string strFilename = fCustDialog.FileName.ToString();

                //create log file name
                //set datetime of processing
                DateTime d = DateTime.Now;
                string dateString = d.ToString("yyyyMMddHHmmss");
                string strFileNameStub = fCustDialog.SafeFileName.ToString();
                string strLogFileNameStub = "ResultLog-" + strFileNameStub + "-" + dateString + ".log";
                string strLogFileName = strFilename.Replace(strFileNameStub, strLogFileNameStub);

                // Write header line to a new results file
                string logfiletext = "AcctName \t AcctID:  \t Add Result" + Environment.NewLine;
                File.WriteAllText(strLogFileName, logfiletext);


                // open import file
                StreamReader fp = new StreamReader(strFilename);
                int linecounter = 1;

                // first check if correct format if not, discontinue
                NewLine = fp.ReadLine();
                string[] aryFields = NewLine.Split('\t');
                int columns = aryFields.Length;
                if (aryFields.Length == 29)
                {
                    FormatOK = true;
                    linecounter += 1;
                }
                else
                {
                    string message = "Incorrect Format for Serial Number File";
                    string title = "Error";
                    MessageBox.Show(message, title);
                    lstLicenses.Items.Add("Incorrect Serial Number File Format. Columns =" + columns.ToString());
                    File.AppendAllText(strLogFileName, "Incorrect Serial Number File Format. Columns =" + columns.ToString() + Environment.NewLine);

                }

                // For each line in the file...
                while (!fp.EndOfStream & FormatOK)
                {
                    // Split the line by Tab
                    NewLine = fp.ReadLine();
                    aryFields = NewLine.Split('\t');
                    columns = aryFields.Length;

                    // Check there are the right number of fields, otherwise ignore
                    if (aryFields.Length == 29)
                    {
                        if (linecounter == 1)
                        {
                            //header line - skip
                        }
                        else
                        {
                            //add record
                            string AccountName = aryFields[0].Trim('"');
                            //check if data in the new line
                            if (string.IsNullOrEmpty(AccountName))
                            {
                                //skip processing. probably last few blank records in tab delimited file
                            }
                            else
                            {
                                string AcctID = aryFields[1];

                                AddCustResult = DataAccess.AddLicense(NewLine);

                                lstLicenses.Items.Add(AccountName + " \t " + AcctID + " \t " + AddCustResult);
                                File.AppendAllText(strLogFileName, AccountName + " \t " + AcctID + " \t " + AddCustResult + Environment.NewLine);
                                AcctsProcessed += 1;
                            }
                        }
                    }
                    else
                    {
                        FormatOK = false;
                        lstLicenses.Items.Add("Incorrect Serial Number File Format. Columns =" + columns.ToString());
                        File.AppendAllText(strLogFileName, "Incorrect Serial Number File Format. Columns =" + columns.ToString() + Environment.NewLine);

                    }
                    linecounter += 1;
                }

                // Close the file
                fp.Close();

                lstLicenses.Items.Add("Licenses Processed =" + AcctsProcessed.ToString());
                labelSNProcessed.Text = "Licenses Processed =" + AcctsProcessed.ToString();


            }

        }

        private void btnTestWrite_Click(object sender, EventArgs e)
        {

            // Show the dialog box
            OpenFileDialog fCustDialog = new OpenFileDialog();
            fCustDialog.Title = "Open Text File";
            fCustDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            //fCustDialog.InitialDirectory = @"C:\";
            fCustDialog.RestoreDirectory = true;

            if (fCustDialog.ShowDialog() == DialogResult.OK)
            {

                // Get the filename and open it
                string strFileName = fCustDialog.FileName.ToString();

                //create log file name
                //set datetime of processing
                DateTime d = DateTime.Now;
                string dateString = d.ToString("yyyyMMddHHmmss");
                string strFileNameStub = fCustDialog.SafeFileName.ToString();
                string strLogFileNameStub = "ResultLog-" + strFileNameStub + "-" + dateString + ".log";
                string strLogFileName = strFileName.Replace(strFileNameStub,strLogFileNameStub);

            }


            /*
            SaveFileDialog fFileDialog = new SaveFileDialog();
            fFileDialog.Title = "Save Text File";
            fFileDialog.DefaultExt = "txt";
            fFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            fFileDialog.RestoreDirectory = true;

            // create file name for log
            DateTime d = DateTime.Now;
            string dateString = d.ToString("yyyyMMddHHmmss");
            string newfilename = "logfile-" + dateString + ".txt";
            fFileDialog.FileName = newfilename;

            if (fFileDialog.ShowDialog() == DialogResult.OK)
            {

                // Get the filename and open it
                string strLogFilename = fFileDialog.FileName.ToString();

                StreamWriter fp = new StreamWriter(strLogFilename);

                //NewLine = fp.ReadLine();
            
            }
            */
        }
    }
}
