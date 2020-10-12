using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using NetlibApi1.CustomerServiceReference;
using NetlibApi1.XMLCustomerService;
using NetlibApi1.XMLLicenseService;


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

         /*
         ** searchSWKCustName
         */
        public static XmlNode searchSWKCustName(string CustName)
        {
            //Build XML
            string CSearchXML = "<?xml version='1.0' encoding='UTF-8'?>";
            CSearchXML += "<CustomerSearch xmlns=''>";
            CSearchXML += "<AuthorID>" + authorstring + "</AuthorID>";
            CSearchXML += "<UserID>" + userID + "</UserID>";
            CSearchXML += "<UserPassword>" + userPassword + "</UserPassword>";
            CSearchXML += "<CompanyName>" + CustName + "</CompanyName>";
            CSearchXML += "</CustomerSearch> ";

            //Convert string to XML doc then node
            XmlDocument CustDoc = new XmlDocument();
            CustDoc.LoadXml(CSearchXML);
            XmlNode CustNode = CustDoc.DocumentElement;

            // Open the connection to the API
            XMLCustomerService.XmlCustomerServiceSoapClient cx = new XMLCustomerService.XmlCustomerServiceSoapClient();
            cx.Open();

            // Search for Customer on SoloServer
            XmlNode result = cx.CustomerSearch(CustNode);


            // We're done here.
            cx.Close();
            return (result);
        }


        /*
     ** searchSWKLicense
     */
        public static XmlNode searchSWKLicense(string LicID)
        {


            //Build XML
            string LicSearchXML = "<?xml version='1.0' encoding='UTF-8'?>";
            LicSearchXML += "<LicenseInfoCheck xmlns=''>";
            LicSearchXML += "<AuthorID>" + authorstring + "</AuthorID>";
            LicSearchXML += "<UserID>" + userID + "</UserID>";
            LicSearchXML += "<UserPassword>" + userPassword + "</UserPassword>";
            LicSearchXML += "<LicenseID>" + LicID + "</LicenseID>";
            LicSearchXML += "</LicenseInfoCheck> ";

            //Convert string to XML doc then node
            XmlDocument LicDoc = new XmlDocument();
            LicDoc.LoadXml(LicSearchXML);
            XmlNode LicNode = LicDoc.DocumentElement;

            // Open the connection to the API
            XMLLicenseService.XmlLicenseServiceSoapClient cx = new XMLLicenseService.XmlLicenseServiceSoapClient();
            cx.Open();

            // Search for License on SoloServer
            XmlNode result = cx.InfoCheck(LicNode);


            // We're done here.
            cx.Close();
            return (result);

        }

        /*
       ** AddSWKLicense
       */
        public static XmlNode AddSWKLicense(string OptionID, string Qty, string expire, string ActCount, string DeactCount, string cores, string note, string custID, bool test)
        {


            //Build XML
            string LicAddXML = "<?xml version='1.0' encoding='UTF-8'?>";
            LicAddXML += "<LicenseAdd xmlns=''>";
            LicAddXML += "<AuthorID>" + authorstring + "</AuthorID>";
            LicAddXML += "<UserID>" + userID + "</UserID>";
            LicAddXML += "<UserPassword>" + userPassword + "</UserPassword>";
            LicAddXML += "<ProdOptionID>" + OptionID + "</ProdOptionID>";
            LicAddXML += "<Quantity>1</Quantity>";
            LicAddXML += "<UnitPrice>1.00</UnitPrice>";
            LicAddXML += "<Expiration>" + expire + "</Expiration>";
            LicAddXML += "<ActivationCount>" + ActCount + "</ActivationCount>";
            LicAddXML += "<DeactivationCount>" + DeactCount + "</DeactivationCount>";
            LicAddXML += "<LicenseCounter>" + cores + "</LicenseCounter>";
            LicAddXML += "<Notes>" + note + "</Notes>";
            LicAddXML += "<CustomerID>" + custID + "</CustomerID>";

            if (test)
                LicAddXML += "<IsTestLicense>TRUE</IsTestLicense>";
            else
                LicAddXML += "<IsTestLicense>FALSE</IsTestLicense>";
            LicAddXML += "</LicenseAdd>";


            //Convert string to XML doc then node
            XmlDocument LicDoc = new XmlDocument();
            LicDoc.LoadXml(LicAddXML);
            XmlNode LicNode = LicDoc.DocumentElement;

            // Open the connection to the API
            XMLLicenseService.XmlLicenseServiceSoapClient cx = new XMLLicenseService.XmlLicenseServiceSoapClient();
            cx.Open();

            // Search for License on SoloServer
            XmlNode result = cx.Add(LicNode);


            // We're done here.
            cx.Close();
            return (result);
        }

        /*
        ** Update SWKLicense User Defined fields.
        */
        public static XmlNode UpdateSWKLicenseFields(string LicID, string LicPwd, string UDF1, string UDF2, string UDF3)
        {

            //Build XML
            string LicUpdXML = "<?xml version='1.0' encoding='UTF-8'?>";
            LicUpdXML += "<UpdateUserDefinedFields xmlns=''>";
            LicUpdXML += "<AuthorID>" + authorstring + "</AuthorID>";
            LicUpdXML += "<UserID>" + userID + "</UserID>";
            LicUpdXML += "<UserPassword>" + userPassword + "</UserPassword>";
            LicUpdXML += "<LicenseID>" + LicID + "</LicenseID>";
            LicUpdXML += "<Password>" + LicPwd + "</Password>";
            LicUpdXML += "<UDefChar1>" + UDF1 + "</UDefChar1>";
            LicUpdXML += "<UDefChar2>" + UDF2 + "</UDefChar2>";
            LicUpdXML += "<UDefChar3>" + UDF3 + "</UDefChar3>";
            LicUpdXML += "</UpdateUserDefinedFields>";

            //Convert string to XML doc then node
            XmlDocument LicDoc = new XmlDocument();
            LicDoc.LoadXml(LicUpdXML);
            XmlNode LicNode = LicDoc.DocumentElement;

            // Open the connection to the API
            XMLLicenseService.XmlLicenseServiceSoapClient cx = new XMLLicenseService.XmlLicenseServiceSoapClient();
            cx.Open();

            // Search for License on SoloServer
            XmlNode result = cx.UpdateUserDefinedFields(LicNode);


            // We're done here.
            cx.Close();
            return (result);
        }

        /*
        ** Update SWKLicense Custom Data.
        */
        public static XmlNode UpdateSWKLicenseCData(string LicID, string cdata)
        {

            /*
            //Build Custom Data as XML to add into API XML
            string CDataXML = "";
            CDataXML += "<?xml version='1.0' encoding='UTF-8'?>";
            CDataXML += cdata;

            //Convert string to XML doc then node
            XmlDocument CDataDoc = new XmlDocument();
            CDataDoc.LoadXml(CDataXML);
            XmlNode CDataNode = CDataDoc.DocumentElement;
            */

            //Build API XML
            string LicUpdXML = "<?xml version='1.0' encoding='UTF-8'?>";
            LicUpdXML += "<UpdateLicenseCustomData xmlns=''>";
            LicUpdXML += "<AuthorID>" + authorstring + "</AuthorID>";
            LicUpdXML += "<UserID>" + userID + "</UserID>";
            LicUpdXML += "<UserPassword>" + userPassword + "</UserPassword>";
            LicUpdXML += "<LicenseID>" + LicID + "</LicenseID>";
            LicUpdXML += "<LicenseCustomData>" + cdata + "</LicenseCustomData>";
            LicUpdXML += "<Format>XML</Format>";
            LicUpdXML += "</UpdateLicenseCustomData>";

            //Convert string to XML doc then node
            XmlDocument LicDoc = new XmlDocument();
            LicDoc.LoadXml(LicUpdXML);
            XmlNode LicNode = LicDoc.DocumentElement;

            // Open the connection to the API
            XMLLicenseService.XmlLicenseServiceSoapClient cx = new XMLLicenseService.XmlLicenseServiceSoapClient();
            cx.Open();

            // Search for License on SoloServer
            XmlNode result = cx.UpdateLicenseCustomData(LicNode);


            // We're done here.
            cx.Close();
            return (result);
        }
    }
}



