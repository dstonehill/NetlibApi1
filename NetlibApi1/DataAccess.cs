using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.Common;
using System.Windows.Forms;
using System.Configuration;

namespace NetlibApi1 
{
    class DataAccess
    {
     
        /*
         * getCustomers from SQL - fill the passed-in list box with the names of all of the customers and customer ids
         * 
         */
        public static void getCustomers(ListBox lstCustomers)
        {
            lstCustomers.Items.Clear();

            // Open connection to SQL Server
            string connectionString = ConfigurationManager.ConnectionStrings["NetlibApi1.Properties.Settings.custdb"].ConnectionString;
            SqlConnection dbCon = new SqlConnection(connectionString); // "Server= 192.168.86.33;Database=SWKExchange;User Id=swkdata;Password=MollyLinus;"
            dbCon.Open();

            // Command
            DbCommand dbCmd = dbCon.CreateCommand();
            dbCmd.CommandText = "select * from Accounts order by AccountID";

            // Get the data
            DbDataReader rsData = dbCmd.ExecuteReader();
            if (rsData.HasRows)
            {
                while (rsData.Read())
                {
                    string custName = rsData["AccountName"].ToString();
                    string custID = rsData["AccountID"].ToString();

                    lstCustomers.Items.Add(custName + " \t " + custID);
                }
            }
            
            // Close Connection
            dbCon.Close();

        }

        /*
         * getAccounts by range, single or allfrom SQL - fill the passed-in list box with the names of all of the customers and customer ids
         * 
         */
        public static void getAccounts(int searchtype, string clientid1, string clientid2, ListBox lstCustomers)
        {
            lstCustomers.Items.Clear();

            // Open connection to SQL Server
            string connectionString = ConfigurationManager.ConnectionStrings["NetlibApi1.Properties.Settings.custdb"].ConnectionString;
            SqlConnection dbCon = new SqlConnection(connectionString); // "Server= 192.168.86.33;Database=SWKExchange;User Id=swkdata;Password=MollyLinus;"
            dbCon.Open();

            // Command
            DbCommand dbCmd = dbCon.CreateCommand();
            // search all
            if (searchtype == 1)
            {
                dbCmd.CommandText = "select * from Accounts order by AccountID";
            }
            else
            //search single
            if (searchtype == 2)
            {
                dbCmd.CommandText = "select * from Accounts";
                dbCmd.CommandText += " where ClientID = '" + clientid1 + "'";
                dbCmd.CommandText += " order by ClientID";
            }
            else
            //search Range
            {
                dbCmd.CommandText = "select * from Accounts";
                dbCmd.CommandText += " where ClientID BETWEEN '" + clientid1 + "' and '" + clientid2 + "'";
                dbCmd.CommandText += " order by ClientID";
            }

            // Get the data
            DbDataReader rsData = dbCmd.ExecuteReader();
            if (rsData.HasRows)
            {
                while (rsData.Read())
                {
                    string custName = rsData["AccountName"].ToString();
                    string custID = rsData["ClientID"].ToString();
                    string Acctid = rsData["AccountID"].ToString();

                    lstCustomers.Items.Add(custName + " \t " + custID + " \t " + Acctid);
                }
            }

            // Close Connection
            dbCon.Close();

        }

        /*
         * updateAddress3
         */
        public static void updateAddress3(string AcctId, string newAddress)
        {
            // Open connection to SQL Server
            string connectionString = ConfigurationManager.ConnectionStrings["NetlibApi1.Properties.Settings.custdb"].ConnectionString;
            SqlConnection dbCon = new SqlConnection(connectionString); // "Server= 192.168.86.33;Database=SWKExchange;User Id=swkdata;Password=MollyLinus;"
            dbCon.Open();

            // Command
            DbCommand dbCmd = dbCon.CreateCommand();
            dbCmd.CommandText = "update Accounts set AddressLine3 = @addr where AccountID = @id ";
            SqlParameter custParam = new SqlParameter("@id", AcctId);
            dbCmd.Parameters.Add(custParam);
            SqlParameter addressParam = new SqlParameter("@addr", newAddress);
            dbCmd.Parameters.Add(addressParam);

            // Update the data
            int result = dbCmd.ExecuteNonQuery();

            if (result ==0)
                

            // Close Connection
            dbCon.Close();
        }


        /*
         * Update SWK fields on Customer SQL Record
         */
        public static string updateCustSWKData(string AcctId, string newSWId, string newSWPwd, string newSWEmail, string UpdMode)
        {
            // Open connection to SQL Server
            string connectionString = ConfigurationManager.ConnectionStrings["NetlibApi1.Properties.Settings.custdb"].ConnectionString;
            SqlConnection dbCon = new SqlConnection(connectionString); // "Server= 192.168.86.33;Database=SWKExchange;User Id=swkdata;Password=MollyLinus;"
            dbCon.Open();

            // Command
            DbCommand dbCmd = dbCon.CreateCommand();
            dbCmd.CommandText = "update Accounts set ";
            dbCmd.CommandText += " SWCustomerID = @CustID,";
            dbCmd.CommandText += " SWCustomerPW = @CustPW,";

            if (UpdMode == "Insert")
            {
                dbCmd.CommandText += " SWEmail = @CustEmail,";
                dbCmd.CommandText += " SWDateInserted = GETDATE(),";
            }
            dbCmd.CommandText += " SWDateModified = GETDATE()";
            dbCmd.CommandText += " where AccountID = @id ";
            
            // set parameters
            SqlParameter IDParam = new SqlParameter("@id", AcctId);
            dbCmd.Parameters.Add(IDParam);
            SqlParameter CustIDParam = new SqlParameter("@CustID", newSWId);
            dbCmd.Parameters.Add(CustIDParam);
            SqlParameter CustPWParam = new SqlParameter("@CustPW", newSWPwd);
            dbCmd.Parameters.Add(CustPWParam);
            SqlParameter EmailParam = new SqlParameter("@CustEmail", newSWEmail);
            dbCmd.Parameters.Add(EmailParam);

            // Update the data
           int queryresult = dbCmd.ExecuteNonQuery();
           string updateresult = "";

            if (queryresult == 0)
            { updateresult = "Cust SWK - no rows updated"; }
            else if (queryresult > 1)
            { updateresult = "Cust SWK - too many rows updated"; }
            else
            { updateresult = "Cust SWk updated"; }

            // Close Connection
            dbCon.Close();

            return (updateresult);
        }

        /*
         * getLicenses - get all licenses for an AcctID
         * 
         */
        public static void getLicenses(ListBox lstLicenses, string AcctID)
        {
            lstLicenses.Items.Clear();

            // Open connection to SQL Server
            string connectionString = ConfigurationManager.ConnectionStrings["NetlibApi1.Properties.Settings.custdb"].ConnectionString;
            SqlConnection dbCon = new SqlConnection(connectionString); // "Server= 192.168.86.33;Database=SWKExchange;User Id=swkdata;Password=MollyLinus;"
            dbCon.Open();

            // Command
            DbCommand dbCmdSN = dbCon.CreateCommand();
            dbCmdSN.CommandText = "select * from SerialNumbers where AccountID = @id ";
            dbCmdSN.CommandText += "order by SerialNumber";
            SqlParameter custParam = new SqlParameter("@id", AcctID);
            dbCmdSN.Parameters.Add(custParam);

            // Get the data
            DbDataReader rsDataSN = dbCmdSN.ExecuteReader();
            if (rsDataSN.HasRows)
            {
                while (rsDataSN.Read())
                {
                    //assign sql data to variables
                    string custName = rsDataSN["AccountName"].ToString();
                    string custID = rsDataSN["ClientID"].ToString();
                    string SerialNum = rsDataSN["SerialNumber"].ToString();

                    //add items to list
                    lstLicenses.Items.Add(custName + " \t " + custID + " \t " + SerialNum);
                }
            }
            rsDataSN.Close();

            // Close Connection
            dbCon.Close();

        }

         /*
         * Update SWK fields on License/SerialNumber SQL Record
         */
        public static string updateLicSWKData(string SerialNumId, string LicType, string newSWId, string newSWPwd, string UpdMode)
        {
            // Open connection to SQL Server
            string connectionString = ConfigurationManager.ConnectionStrings["NetlibApi1.Properties.Settings.custdb"].ConnectionString;
            SqlConnection dbCon = new SqlConnection(connectionString); // "Server= 192.168.86.33;Database=SWKExchange;User Id=swkdata;Password=MollyLinus;"
            dbCon.Open();

            // Command
            DbCommand dbCmd = dbCon.CreateCommand();
            dbCmd.CommandText = "update SerialNumbers set ";
            dbCmd.CommandText += " SWLicenseID = @LicID,";
            dbCmd.CommandText += " SWLicensePW = @LicPW,";

            if (UpdMode == "Insert")
            {
                dbCmd.CommandText += " SWDateInserted = GETDATE(),";
            }
            dbCmd.CommandText += " SWDateModified = GETDATE()";
            dbCmd.CommandText += " where SerialNumberID = @id and LicType = @lictype";

            // set parameters
            SqlParameter LicIDParam = new SqlParameter("@LicID", newSWId);
            dbCmd.Parameters.Add(LicIDParam);
            SqlParameter LicPWParam = new SqlParameter("@LicPW", newSWPwd);
            dbCmd.Parameters.Add(LicPWParam);
            SqlParameter IDParam = new SqlParameter("@id", SerialNumId);
            dbCmd.Parameters.Add(IDParam);
            SqlParameter LicTypeParam = new SqlParameter("@lictype", LicType);
            dbCmd.Parameters.Add(LicTypeParam);

            // Update the data
            int queryresult = dbCmd.ExecuteNonQuery();
            string updateresult = "";

            if (queryresult == 0)
            { updateresult = "Lic SWK - no rows updated"; }
            else if (queryresult > 1)
            { updateresult = "Lic SWK - too many rows updated"; }
            else
            { updateresult = "Lic SWk updated"; }

            // Close Connection
            dbCon.Close();

            return (updateresult);
        }


    }
}
