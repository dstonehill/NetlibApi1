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

        private void textBox1_TextChanged(object sender, EventArgs e)
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

            if (radioAll.Checked)
            {
                searchtype = 1;
                gotosearch = true;
                if (txtClientID1A.Text != "")
                {
                    MessageBox.Show("Warning - client ID will be ignored");
                }
            }
            else
            if (radioSingle.Checked)
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
                DataAccess.getAccounts(searchtype, txtClientID1A.Text, txtClientID2A.Text, lstCustomers);
            }

        }

        private void btnAddLicense_Click(object sender, EventArgs e)
        {
            XmlNode result = ApiAccess.AddSWKLicense("1057","1","12/31/2020","5","4","12","a note goes here","4400022",checkBoxTest.Checked);

            // Check to make sure there was a good node of data back
            XmlNode LicNode = result.SelectSingleNode("ResultCode");

            if (LicNode == null)
                txtLicInfo.Text = "No data found";
            else if (LicNode.InnerText != "0")

            { txtLicInfo.Text = "Insert Error: " + LicNode.InnerText; }
            else

            {
                LicNode = result.SelectSingleNode("LicenseID");
                txtLicInfo.Text = "LicenseID: " + LicNode.InnerText + " \n ";
                LicNode = result.SelectSingleNode("Password");
                txtLicInfo.Text += " CustPassword: " + LicNode.InnerText;
                LicNode = result.SelectSingleNode("SerialNumber");
                txtLicInfo.Text += "Serial Number: " + LicNode.InnerText;
                LicNode = result.SelectSingleNode("ActivationPassword");
                txtLicInfo.Text += "ActivationPassword: " + LicNode.InnerText;

            }
        }

       
    }
}
