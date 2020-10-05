using System;
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
                XmlNode LicNode = result.SelectSingleNode("LicenseInfoCheck/ProdID");
                if (LicNode == null)
                    txtLicInfo.Text = "No data found";
                else
                    txtLicInfo.Text = LicNode.InnerText;

            }
        }
    }
}
