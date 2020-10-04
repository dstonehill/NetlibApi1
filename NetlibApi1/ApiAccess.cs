using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using NetlibApi1.CustomerServiceReference;
using NetlibApi1.XMLCustomerService;

namespace NetlibApi1
{
    class ApiAccess
    {

        const int author = 2451871;
        static string authorstring = author.ToString();
        const string userID = "4aaf144d-4176-40fc-8aa1-53a1ce6c2db6";
        const string userPassword = "77BD524A44574298113DE7D9B5654E0235F3571ABD657DA39A0A53FA671C07B71F9F8E8D9A4D4AFE1232CC9F614C48E68EFFCDD95EA9C72836046EE47B14E133";

        /*
        ** addSWKCustomer
        */
        public static int addSWKCustomer(string Customer, string First, string Last, string Address1, string Address2, string City, string State, string Zipcode, string Country, string Email, string Password, string Phone, string Fax, string Nickname)
        {
            // Open the connection to the API
            CustomerServiceReference.CustomerServerSoapClient cx = new CustomerServerSoapClient();
            cx.Open();

            // Insert the data
            int result = cx.CreateCustomer(author, userID, userPassword, Customer, First, Last, Address1, Address2,
                                           City, State, Zipcode, Country, Email, Password, Phone, Fax, Nickname, false, false);
          

            // We're done here.
            cx.Close();
            return (result);
        }
        
        /*
        ** searchSWKCustomer
        */
        public static XmlNode searchSWKCustomer(string CustID)
        {
            
            
            //Build XML
            string CSearchXML = "<?xml version='1.0' encoding='UTF-8'?><GetCustomerDataByAuthor xmlns=''><AuthorID>" + authorstring + "</AuthorID><UserID>" + userID + "</UserID><UserPassword>" + userPassword + "</UserPassword><CustomerID>" + CustID + "</CustomerID></GetCustomerDataByAuthor> ";
            // Open the connection to the API
            XMLCustomerService.XmlCustomerServiceSoapClient cx = new XMLCustomerService.XmlCustomerServiceSoapClient();
            cx.Open();

            // Search for Customer on SoloServer
            XmlNode result = cx.GetCustomerDataByAuthorS(CSearchXML);


            // We're done here.
            cx.Close();
            return (result);
            }
        }
}
