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
         * getCustomers - fill the passed-in list box with the names of all of the customers and customer ids
         * 
         */
        public static void getCustomers(ListBox lstCustomers)
        {
            lstCustomers.Items.Clear();

            // Open connection to SQL Server
            string connectionString = ConfigurationManager.ConnectionStrings["NetlibApi1.Properties.Settings.custdb"].ConnectionString;
            SqlConnection dbCon = new SqlConnection(connectionString); // "Server= 192.168.86.38;Database=SWKExchange;User Id=swkdata;Password=MollyLinus;"
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
         * updateAddress3
         */
        public static void updateAddress3(string AcctId, string newAddress)
        {
            // Open connection to SQL Server
            string connectionString = ConfigurationManager.ConnectionStrings["NetlibApi1.Properties.Settings.custdb"].ConnectionString;
            SqlConnection dbCon = new SqlConnection(connectionString); // "Server= 192.168.86.38;Database=SWKExchange;User Id=swkdata;Password=MollyLinus;"
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
         * getCustomers - fill the passed-in list box with the names of all of the customers and customer ids
         * 
         */
        public static void getLicenses(ListBox lstLicenses, string AcctID)
        {
            lstLicenses.Items.Clear();

            // Open connection to SQL Server
            string connectionString = ConfigurationManager.ConnectionStrings["NetlibApi1.Properties.Settings.custdb"].ConnectionString;
            SqlConnection dbCon = new SqlConnection(connectionString); // "Server= 192.168.86.38;Database=SWKExchange;User Id=swkdata;Password=MollyLinus;"
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
