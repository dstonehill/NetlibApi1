using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.Common;
using System.Windows.Forms;
using System.Configuration;
using System.Xml;

namespace NetlibApi1
{
    class ImportData
    {
        /*
         * procAccounts - by range, single or allfrom SQL - fill the passed-in Cust list box with the names of processed accounts and
         * License lst box with processed licenses
         */
        public static void procAccounts(int searchtype, string clientid1, string clientid2, ListBox lstCustBox, ListBox lstLicBox, bool test )
        {
            lstCustBox.Items.Clear();
            lstLicBox.Items.Clear();
            string AddCustResult = "";
            bool SkipError = false;
            string newCustID = "";

            // Open connection to SQL Server
            string connectionString = ConfigurationManager.ConnectionStrings["NetlibApi1.Properties.Settings.custdb"].ConnectionString;
            SqlConnection dbConAcct = new SqlConnection(connectionString); // "Server= 192.168.86.33;Database=SWKExchange;User Id=swkdata;Password=MollyLinus;"
            dbConAcct.Open();

            // Command
            DbCommand dbCmdAcct = dbConAcct.CreateCommand();
            // search all
            if (searchtype == 1)
            {
                dbCmdAcct.CommandText = "select * from AcctContact order by AccountID";
            }
            else
            //search single
            if (searchtype == 2)
            {
                dbCmdAcct.CommandText = "select * from AcctContact";
                dbCmdAcct.CommandText += " where ClientID = '" + clientid1 + "'";
                dbCmdAcct.CommandText += " order by ClientID";
            }
            else
            //search Range
            {
                dbCmdAcct.CommandText = "select * from AcctContact";
                dbCmdAcct.CommandText += " where ClientID BETWEEN '" + clientid1 + "' and '" + clientid2 + "'";
                dbCmdAcct.CommandText += " order by ClientID";
            }

            // Get the data
            DbDataReader rsDataAcct = dbCmdAcct.ExecuteReader();

            if (rsDataAcct.HasRows)
            {
                while (rsDataAcct.Read())
                {
                    string AcctName = rsDataAcct["AccountName"].ToString();
                    string clientID = rsDataAcct["ClientID"].ToString();
                    string Acctid = rsDataAcct["AccountID"].ToString();


                    // Has this customer been added to Soloserver previously
                    string SWCustomerID = rsDataAcct["SWCustomerID"].ToString();
                    if (SWCustomerID == "")
                    {
                        // add Account to SoloServer
                        string firstName = rsDataAcct["FirstName"].ToString();
                        string lastName = rsDataAcct["LastName"].ToString();
                        string address1 = rsDataAcct["AddressLine1"].ToString();
                        string address2 = rsDataAcct["AddressLine2"].ToString();
                        string city = rsDataAcct["City"].ToString();
                        string state = rsDataAcct["StateProvince"].ToString();
                        string zip = rsDataAcct["PostalCode"].ToString();
                        string country = rsDataAcct["Country"].ToString();
                        string email = rsDataAcct["Email"].ToString();
                        string pwd = rsDataAcct["dnld_userpw"].ToString();
                        string nickname = "GMClientID: " + rsDataAcct["GMClientID"].ToString();



                        int newId = ApiAccess.addSWKCustomer(AcctName, firstName, lastName, address1, address2, city, state, zip, country, email, pwd, "", "", nickname);
                        if (newId < 0)
                        { 
                            // Error with SWK add
                            AddCustResult = "Add Error: " + newId.ToString();
                            SkipError = true;
                        }
                        else
                        {
                            // successful SWK add
                            newCustID = newId.ToString();
                            AddCustResult = "Added: " + newCustID;

                            // update Account record in SQL with SWK data
                            string updResult = DataAccess.updateCustSWKData(Acctid, newCustID, pwd, email, "Insert");
                            AddCustResult += " " + updResult;
                        }
                    }
                    else
                    {
                        // has been previously added according to Account Record
                        // confirm customer on SoloServer and then process licenses.
                        newCustID = SWCustomerID;
                        AddCustResult = "Prev Add";
                    }

                    string licResult = "";
                    if (SkipError)
                    { // dont process licenses 
                        licResult = "Skipped Licenses";
                    }
                    else
                    {
                        // get licenses for this AcctID
                        int licensesProcessed;
                        licensesProcessed = ImportData.procLicenses(Acctid, newCustID, lstLicBox, test);
                        licResult = "Lic: " + licensesProcessed.ToString();

                    }

                    //list customers processed in box
                    lstCustBox.Items.Add(AcctName + " \t ClientID: " + clientID + " \t Add Result: " + AddCustResult + " \t " + licResult) ;
                }
            }

            // Close Connection
            dbConAcct.Close();

        }

        /* 
        * procLicenses - This procedure reads Serial Numbers from SQL for selected AcctID and calls routine to add
        * to Solo Server
        */
        public static int procLicenses(string AcctID, string CustomerID, ListBox lstLicBox, bool testLic)
        {
            /* 
             * This procedure reads Serial Numbers from SQL for selected AcctID and calls routine to add
             * to Solo Server
             */
            
            //lstLicBox.Items.Clear();
            string AddLicResult = "";
            bool SkipError = false;

            // Open connection to SQL Server
            string connectionString = ConfigurationManager.ConnectionStrings["NetlibApi1.Properties.Settings.custdb"].ConnectionString;
            SqlConnection dbConSN = new SqlConnection(connectionString); // "Server= 192.168.86.33;Database=SWKExchange;User Id=swkdata;Password=MollyLinus;"
            dbConSN.Open();

            // Command
            DbCommand dbCmdSN = dbConSN.CreateCommand();
            dbCmdSN.CommandText = "select * from SerialNumbers where AccountID = @id ";
            dbCmdSN.CommandText += "order by SerialNumber";
            SqlParameter custParam = new SqlParameter("@id", AcctID);
            dbCmdSN.Parameters.Add(custParam);

            // Get the data
            DbDataReader rsDataSN = dbCmdSN.ExecuteReader();

            int recordcounter = 0;

            if (rsDataSN.HasRows)
            {
                while (rsDataSN.Read())
                {
                    //assign sql data to variables
                    string AcctName = rsDataSN["AccountName"].ToString();
                    string clientID = rsDataSN["ClientID"].ToString();
                    string SerialNum = rsDataSN["SerialNumber"].ToString();


                    // Has this License been added to Soloserver previously
                    string SWLicID = rsDataSN["SWLicenseID"].ToString();
                    if (SWLicID == "")
                    {
                        // add License to SoloServer
                        string optionID = rsDataSN["ProdOptionID"].ToString();
                        string qty = rsDataSN["Quantity"].ToString();
                        string purchased = rsDataSN["DatePurchased"].ToString();
                        string expire = rsDataSN["SuppExpireDate"].ToString();
                        string activation = rsDataSN["ActivationCount"].ToString();
                        string deactivation = rsDataSN["DeactivationCount"].ToString();
                        string cores = rsDataSN["LicenseCounter"].ToString();
                        string notes = rsDataSN["Notes"].ToString();
                        //string acctid = rsDataSN["AcctID"].ToString();
                        string SNID = rsDataSN["SerialNumberID"].ToString();
                        string LicName = rsDataSN["LicenseeName"].ToString();
                        string CData = rsDataSN["CustomData"].ToString();


                        //addLicense function using Tuple that will return 3 values - new License ID, Lic Activation Password, result message
                        var LicIDPwd = ImportData.addLicense(lstLicBox, CustomerID, optionID, qty, purchased, expire, activation, deactivation, cores, notes, SerialNum, SNID, LicName, CData, testLic);

                        string newLicID = LicIDPwd.Item1;
                        string newLicPwd = LicIDPwd.Item2;
                        string newLicResult = LicIDPwd.Item3;


                        if (newLicID == "")
                        {
                            // Error with SWK add
                            AddLicResult = "Add Lic Error: " + newLicResult;
                            SkipError = true;
                        }
                        else
                        {
                            // successful SWK add, split up res

                            AddLicResult = "Added: " + newLicID + newLicResult;

                            // update Account record in SQL with SWK data
                            // updateLicSWKData(string SerialNumId, string newSWId, string newSWPwd, string UpdMode)
                            string updResult = DataAccess.updateLicSWKData(SNID, newLicID, newLicPwd, "Insert");
                            AddLicResult += " " + updResult;
                        }
                    }
                    else
                    {
                        // has been previously added according to Account Record
                        // confirm customer on SoloServer and then process licenses.
                        AddLicResult = "Prev Lic Add: " + SWLicID;
                    }

                    //add items to list
                    lstLicBox.Items.Add(AcctName + " \t " + clientID + " \t " + SerialNum + " \t " + AddLicResult);
                    recordcounter = recordcounter + 1;
                }
            }
            rsDataSN.Close();

            // Close Connection
            dbConSN.Close();

            // returns number of licenses processed for the Account
            return (recordcounter);

        }
       
        /*
         * addLicense - adds single license to SoloServer, plus updates UDF and CustomData, 
         * returns LicID if assigned, LicPwd and return result
         */
        public static Tuple<string, string, string> addLicense(ListBox lstLicBox, string CustomerID, string OptionID, string qty, string purchased, string expire, string activation, string deactivation, string cores, string notes, string SN, string SNID, string LicName, string CData, bool testLic)
        {

            string LicResult = "";
            string LicID = "0";
            string LicPwd = "";

            //AddSWKLicense(string OptionID, string Qty, string expire, string ActCount, string DeactCount, string cores, string note, string custID, bool test)
            XmlNode resultAdd = ApiAccess.AddSWKLicense(OptionID, qty, expire, activation,deactivation, cores, notes, CustomerID, LicName, testLic);

            // Check to make sure there was a good node of data back
            XmlNode LicNode = resultAdd.SelectSingleNode("ResultCode");

            if (LicNode == null)
                LicResult = "Error - No data returned";
            else if (LicNode.InnerText != "0")
                LicResult = "Error - Insert : " + LicNode.InnerText;
            else

            {
                LicNode = resultAdd.SelectSingleNode("LicenseID");
                // txtLicInfo.Text = "LicenseID: " + LicNode.InnerText + " \n ";
                LicID = LicNode.InnerText;
                LicNode = resultAdd.SelectSingleNode("ActivationPassword");
                //txtLicInfo.Text += "ActivationPassword: " + LicNode.InnerText;
                LicPwd = LicNode.InnerText;
                LicResult = "Added";

                // update User Defined fields
                //UpdateSWKLicenseFields(string LicID, string LicPwd, string UDF1, string UDF2, string UDF3)
                XmlNode resultUpdUDF = ApiAccess.UpdateSWKLicenseFields(LicID, LicPwd, "Prev Serial Num: " + SN, "Originally Purchased: " + purchased, "");

                //Check results of update
                XmlNode LicUpdUDF = resultUpdUDF.SelectSingleNode("ResultCode");
                if (LicUpdUDF == null)
                    LicResult += "|UDF result: null";
                else if (LicUpdUDF.InnerText != "0")
                    LicResult += "|UDF Error: " + LicUpdUDF.InnerText;
                else
                    LicResult += "|UDF Added";

                // update CustomData
                //UpdateSWKLicenseCData(string LicID, string cdata)

                //build Custom Data
                //string inputCData = "<CustomParameters><IsLease>False</IsLease><IsExecsOverride>True</IsExecsOverride><ExecsAllowed>x</ExecsAllowed><KeyLength>256</KeyLength><Instances>31</Instances><MaxSize>65536</MaxSize><NumProcesses>63</NumProcesses><NumFiles>128</NumFiles><IsGUIsAllowed>True</IsGUIsAllowed><IsCLIAllowed>False</IsCLIAllowed><IsTimeLtd>False</IsTimeLtd></CustomParameters>";

                // make the call to update custom data
                XmlNode resultUpdCData = ApiAccess.UpdateSWKLicenseCData(LicID, CData);

                //Check results of update
                XmlNode LicUpdCData = resultUpdCData.SelectSingleNode("ResultCode");
                if (LicUpdCData == null)
                    LicResult += "|CData result: null";
                else if (LicUpdCData.InnerText != "0")
                    LicResult += "|CData Error: " + LicUpdCData.InnerText;
                else
                    LicResult += "|CData Added";


            }
            return new Tuple<string, string, string>(LicID, LicPwd, LicResult);
        }

    }
}
