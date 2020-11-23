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
            // select all Accounts from SQL - fill in the passed-in list box with the names of Accounts and Account ID's
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

        /*
          * Add Account Records to SQL
          * 
          */
        public static string AddAccount(string LineInput)
        {
            // determine if Account previously added. If not, add record to SQL
            // if previous added return result
            string AddResult = "";
            string[] aryColumns = LineInput.Split('\t');
            string newAcctName = aryColumns[0].Trim('"');
            string newAcctID = aryColumns[3];
            int queryresult = 0;

            // Open connection to SQL Server
            string connectionString = ConfigurationManager.ConnectionStrings["NetlibApi1.Properties.Settings.custdb"].ConnectionString;
            SqlConnection dbCon = new SqlConnection(connectionString); // "Server= 192.168.86.33;Database=SWKExchange;User Id=swkdata;Password=MollyLinus;"
            dbCon.Open();

            // Command
            DbCommand dbCmd = dbCon.CreateCommand();
            dbCmd.CommandText =  "select * from Accounts ";
            dbCmd.CommandText += "where AccountID = '" + newAcctID +"'";

            // Get the data
            DbDataReader rsData = dbCmd.ExecuteReader();
            if (rsData.HasRows)
            {
                queryresult = 1; 
            }
            dbCon.Close();

            if (queryresult > 0)
            {
                AddResult = "Account previously added";
            }
            else
            {
                dbCon.Open();
                dbCmd = dbCon.CreateCommand();

                //Account needs to be added
                dbCmd.CommandText = "INSERT INTO [dbo].[Accounts] ([AccountName],[AcctType],[Active],[AccountID],[ClientID],[GMClientID],[AddressLine1],[AddressLine2],[City],[StateProvince],[PostalCode],[Country],[dnld_userpw],[SFReference]) VALUES (";
                dbCmd.CommandText += "@AccountName,@AcctType,@Active,@AcctID,@ClientID,@GMClientID,@AddressLine1,@AddressLine2,@City,@StateProvince,@PostalCode,@Country,@dnld_userpw,@SFReference)";
                SqlParameter AcctNameParam = new SqlParameter("@AccountName", newAcctName);
                dbCmd.Parameters.Add(AcctNameParam);
                SqlParameter AcctTypeParam = new SqlParameter("@AcctType", aryColumns[1]);
                dbCmd.Parameters.Add(AcctTypeParam);
                SqlParameter AcctActiveParam = new SqlParameter("@Active", aryColumns[2]);
                dbCmd.Parameters.Add(AcctActiveParam);
                SqlParameter AcctIDParam = new SqlParameter("@AcctID", newAcctID);
                dbCmd.Parameters.Add(AcctIDParam);
                SqlParameter AcctClientIDParam = new SqlParameter("@ClientID", aryColumns[4]);
                dbCmd.Parameters.Add(AcctClientIDParam);
                SqlParameter AcctGMClientIDParam = new SqlParameter("@GMClientID", aryColumns[5]);
                dbCmd.Parameters.Add(AcctGMClientIDParam);
                SqlParameter AcctAddress1Param = new SqlParameter("@AddressLine1", aryColumns[6].Trim('"'));
                dbCmd.Parameters.Add(AcctAddress1Param);
                SqlParameter AcctAddress2Param = new SqlParameter("@AddressLine2", aryColumns[7].Trim('"'));
                dbCmd.Parameters.Add(AcctAddress2Param);
                SqlParameter AcctCityParam = new SqlParameter("@City", aryColumns[8].Trim('"'));
                dbCmd.Parameters.Add(AcctCityParam);
                SqlParameter AcctStateParam = new SqlParameter("@StateProvince", aryColumns[9].Trim('"'));
                dbCmd.Parameters.Add(AcctStateParam);
                SqlParameter AcctZipParam = new SqlParameter("@PostalCode", aryColumns[10].Trim('"'));
                dbCmd.Parameters.Add(AcctZipParam);
                SqlParameter AcctCountryParam = new SqlParameter("@Country", aryColumns[11].Trim('"'));
                dbCmd.Parameters.Add(AcctCountryParam);
                SqlParameter AcctPWParam = new SqlParameter("@dnld_userpw", aryColumns[18].Trim('"'));
                dbCmd.Parameters.Add(AcctPWParam);
                SqlParameter AcctSFRefParam = new SqlParameter("@SFReference", aryColumns[4] + '-' + aryColumns[5]);
                dbCmd.Parameters.Add(AcctSFRefParam);

                queryresult = dbCmd.ExecuteNonQuery();

                if (queryresult == 0)
                { AddResult = "Error - Account Not Added"; }
                else if (queryresult > 1)
                { AddResult = "Error - Too many records added"; }
                else
                { AddResult = "Account Added"; }


            }

            // Close Connection
            dbCon.Close();

            return (AddResult);
        }
        
        //Add Contact to SQL Database
        public static string AddContact(string LineInput)
        {
            // determine if Account previously added. If not, skip Contact.
            // if previous added return result
            string AddResult = "";
            string[] aryColumns = LineInput.Split('\t');
            string newAcctName = aryColumns[0].Trim('"');
            string newAcctID = aryColumns[7];
            string newFirst = aryColumns[1].Trim('"');
            string newLast = aryColumns[2].Trim('"');
            string newContactID = aryColumns[10];
            int queryresult = 0;
            bool CustExists = false;
            bool AddContact = false;

            // Open connection to SQL Server
            string connectionString = ConfigurationManager.ConnectionStrings["NetlibApi1.Properties.Settings.custdb"].ConnectionString;
            SqlConnection dbCon = new SqlConnection(connectionString); // "Server= 192.168.86.33;Database=SWKExchange;User Id=swkdata;Password=MollyLinus;"

            // first lets check if the Account already exists
            // Command
            dbCon.Open();
            DbCommand dbCmd = dbCon.CreateCommand();
            dbCmd.CommandText = "select * from Accounts ";
            dbCmd.CommandText += "where AccountID = '" + newAcctID + "'";

            // Get the data
            DbDataReader rsData = dbCmd.ExecuteReader();
            if (rsData.HasRows)
            {
                CustExists = true;
            }
            dbCon.Close();

            if (CustExists)
            {
                // continue to work on contacts
                // now check if Contact previously added
                dbCon.Open();
                dbCmd = dbCon.CreateCommand();
                dbCmd.CommandText = "select * from Contacts ";
                dbCmd.CommandText += "where ContactID = '" + newContactID + "'";

                // Get the data
                rsData = dbCmd.ExecuteReader();
                if (rsData.HasRows)
                {
                    AddContact = false;
                    AddResult = "Contact Already added (" + newFirst + " " + newLast + "skipped)";
                }
                else
                {
                    AddContact = true;
                }
                dbCon.Close();
            }
            else
            {
                //discontinue working on contacts
                AddResult = "Account does not exist (" + newFirst + " " + newLast + "skipped)";
            }

            if (AddContact)
            {
                dbCon.Open();
                dbCmd = dbCon.CreateCommand();

                //Contact needs to be added
                dbCmd.CommandText = "INSERT INTO [dbo].[Contacts] ([FirstName], [LastName], [Title], [ContactType], [Email], [AccountID],[ContactID]) VALUES (";
                dbCmd.CommandText += "@FirstName, @LastName, @Title, @ContactType, @Email, @AccountID, @ContactID)";
                SqlParameter FirstNameParam = new SqlParameter("@FirstName", newFirst);
                dbCmd.Parameters.Add(FirstNameParam);
                SqlParameter LastNameParam = new SqlParameter("@LastName", newLast);
                dbCmd.Parameters.Add(LastNameParam);
                SqlParameter TitleParam = new SqlParameter("@Title", aryColumns[3].Trim('"'));
                dbCmd.Parameters.Add(TitleParam);
                SqlParameter TypeParam = new SqlParameter("@ContactType", aryColumns[4].Trim('"'));
                dbCmd.Parameters.Add(TypeParam);
                SqlParameter EmailParam = new SqlParameter("@Email", aryColumns[6].Trim('"'));
                dbCmd.Parameters.Add(EmailParam);
                SqlParameter AcctIDParam = new SqlParameter("@AccountID", newAcctID);
                dbCmd.Parameters.Add(AcctIDParam);
                SqlParameter ContactIDParam = new SqlParameter("@ContactID", newContactID);
                dbCmd.Parameters.Add(ContactIDParam);

                queryresult = dbCmd.ExecuteNonQuery();

                if (queryresult == 0)
                { AddResult = "Error - Contact Not Added (" + newFirst + " " + newLast + ")"; }
                else if (queryresult > 1)
                { AddResult = "Error - Too many records added (" + newFirst + " " + newLast + ")"; }
                else
                { AddResult = "Contact Added (" + newFirst + " " + newLast + ")"; }

                // Close Connection
                dbCon.Close();
            }

            return (AddResult);
        }

        //Add License to SQL Database
        public static string AddLicense(string LineInput)
        {
            // determine if Account previously added. If not, skip Contact.
            // if previous added return result
            string AddResult = "";
            string[] aryColumns = LineInput.Split('\t');
            string newAcctName = aryColumns[0].Trim('"');
            string newAcctID = aryColumns[1];
            string newSN = aryColumns[4];
            string newSNid = aryColumns[5];
            string newPurchase = aryColumns[6];
            string newProdName = aryColumns[7].Trim('"');
            string newExpire = aryColumns[8];
            int newPAllowed = Convert.ToInt32(aryColumns[9]);
            int newTAllowed = Convert.ToInt32(aryColumns[10]);
            string newProject = aryColumns[11].Trim('"');
            string newProdDesc = aryColumns[12].Trim('"');
            int newCores = Convert.ToInt32(aryColumns[13]);
            string newExes = aryColumns[18].Trim('"');
            int newInstances = 0;
            if (string.IsNullOrEmpty(aryColumns[19]))
                { newInstances = 31; } 
            else { newInstances = Convert.ToInt32(aryColumns[19]); }
            int newProdOption = Convert.ToInt32(aryColumns[21]);
            string newLicType = aryColumns[22];
            int newQty = Convert.ToInt32(aryColumns[23]);
            int newUnitPrice = 1;
            int newActiveCnt = Convert.ToInt32(aryColumns[24]);
            int newDeactCnt = Convert.ToInt32(aryColumns[25]);
            string newLicensee = aryColumns[26].Trim('"');
            string newCData = aryColumns[27].Trim('"');
            newCData = newCData.Replace(',',' ');
            string newNotes = aryColumns[28].Trim('"');

            int queryresult = 0;
            bool CustExists = false;
            bool AddSN = false;

            // Open connection to SQL Server
            string connectionString = ConfigurationManager.ConnectionStrings["NetlibApi1.Properties.Settings.custdb"].ConnectionString;
            SqlConnection dbCon = new SqlConnection(connectionString); // "Server= 192.168.86.33;Database=SWKExchange;User Id=swkdata;Password=MollyLinus;"

            // first lets check if the Account already exists
            // Command
            dbCon.Open();
            DbCommand dbCmd = dbCon.CreateCommand();
            dbCmd.CommandText = "select * from Accounts ";
            dbCmd.CommandText += "where AccountID = '" + newAcctID + "'";

            // Get the data
            DbDataReader rsData = dbCmd.ExecuteReader();
            if (rsData.HasRows)
            {
                CustExists = true;
            }
            dbCon.Close();

            if (CustExists)
            {
                // continue to work on Serial Numbers
                // now check if Serial Number previously added
                dbCon.Open();
                dbCmd = dbCon.CreateCommand();
                dbCmd.CommandText = "select * from SerialNumbers ";
                dbCmd.CommandText += "where SerialNumberID = '" + newSNid + "' and LicType ='" + newLicType + "'";

                // Get the data
                rsData = dbCmd.ExecuteReader();
                if (rsData.HasRows)
                {
                    AddSN = false;
                    AddResult = "SerialNum and type already added (" + newSN + " - " + newLicType + " skipped)";
                }
                else
                {
                    AddSN = true;
                }
                dbCon.Close();
            }
            else
            {
                //discontinue working on contacts
                AddResult = "Account does not exist (" + newSN + " - " + newLicType + " skipped)";
            }

            if (AddSN)
            {
                dbCon.Open();
                dbCmd = dbCon.CreateCommand();

                //Contact needs to be added
                dbCmd.CommandText = "INSERT INTO [dbo].[SerialNumbers]([AccountID],[SerialNumber],[SerialNumberID],[DatePurchased],[ProductName],[SuppExpireDate],[ProdAllowed],[TotalAllowed],[Project],[ProductDescr],[cores],[securables],[num_instances],[ProdOptionID],[LicType],[Quantity],[UnitPrice],[ActivationCount],[DeactivationCount],[LicenseeName],[CustomData],[Notes]) VALUES (";
                dbCmd.CommandText += "@AccountID, @SN, @SNID, @Purchased, @ProdName, @Expires, @PAllowed, @TAllowed, @Project, @ProdDesc, @cores, @Exes, @Instances, @OptionID, @LicType, @Qty, @Price, @ActCnt, @DeactCnt, @Licensee, @CData, @Notes)";
                SqlParameter AcctIDParam = new SqlParameter("@AccountID", newAcctID);
                dbCmd.Parameters.Add(AcctIDParam);
                SqlParameter SNParam = new SqlParameter("@SN", newSN);
                dbCmd.Parameters.Add(SNParam);
                SqlParameter SNIDParam = new SqlParameter("@SNID", newSNid);
                dbCmd.Parameters.Add(SNIDParam);
                SqlParameter PurchaseParam = new SqlParameter("@Purchased", newPurchase);
                dbCmd.Parameters.Add(PurchaseParam);
                SqlParameter ProdNameParam = new SqlParameter("@ProdName", newProdName);
                dbCmd.Parameters.Add(ProdNameParam);
                SqlParameter ExpiresParam = new SqlParameter("@Expires", newExpire);
                dbCmd.Parameters.Add(ExpiresParam);
                SqlParameter PAllowParam = new SqlParameter("@PAllowed", newPAllowed);
                dbCmd.Parameters.Add(PAllowParam);
                SqlParameter TAllowParam = new SqlParameter("@TAllowed", newTAllowed);
                dbCmd.Parameters.Add(TAllowParam);
                SqlParameter ProjectParam = new SqlParameter("@Project", newProject);
                dbCmd.Parameters.Add(ProjectParam);
                SqlParameter ProdDescParam = new SqlParameter("@ProdDesc", newProdDesc);
                dbCmd.Parameters.Add(ProdDescParam);
                SqlParameter CoresParam = new SqlParameter("@cores", newCores);
                dbCmd.Parameters.Add(CoresParam);
                SqlParameter ExesParam = new SqlParameter("@Exes", newExes);
                dbCmd.Parameters.Add(ExesParam);
                SqlParameter InstParam = new SqlParameter("@Instances", newInstances);
                dbCmd.Parameters.Add(InstParam);
                SqlParameter OptParam = new SqlParameter("@OptionID", newProdOption);
                dbCmd.Parameters.Add(OptParam);
                SqlParameter LicTypeParam = new SqlParameter("@LicType", newLicType);
                dbCmd.Parameters.Add(LicTypeParam);
                SqlParameter QtyParam = new SqlParameter("@Qty", newQty);
                dbCmd.Parameters.Add(QtyParam);
                SqlParameter PriceParam = new SqlParameter("@Price", newUnitPrice);
                dbCmd.Parameters.Add(PriceParam);
                SqlParameter ActParam = new SqlParameter("@ActCnt", newActiveCnt);
                dbCmd.Parameters.Add(ActParam);
                SqlParameter DeactParam = new SqlParameter("@DeactCnt", newDeactCnt);
                dbCmd.Parameters.Add(DeactParam);
                SqlParameter LicenseeParam = new SqlParameter("@Licensee", newLicensee);
                dbCmd.Parameters.Add(LicenseeParam);
                SqlParameter CDataParam = new SqlParameter("@CData", newCData);
                dbCmd.Parameters.Add(CDataParam);
                SqlParameter NoteParam = new SqlParameter("@Notes", newNotes);
                dbCmd.Parameters.Add(NoteParam);


                queryresult = dbCmd.ExecuteNonQuery();

                if (queryresult == 0)
                { AddResult = "Error - SerialNum Not Added (" + newSN + " - " + newLicType + ")"; }
                else if (queryresult > 1)
                { AddResult = "Error - Too many records added (" + newSN + " - " + newLicType + ")"; }
                else
                { AddResult = "SerialNum Added (" + newSN + " - " + newLicType + ")"; }

                // Close Connection
                dbCon.Close();
            }

            return (AddResult);
        }
    }
}
