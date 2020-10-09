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
            dbCmd.ExecuteNonQuery();

            // Close Connection
            dbCon.Close();
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

    }
}
