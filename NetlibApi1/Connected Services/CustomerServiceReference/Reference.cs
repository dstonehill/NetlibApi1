﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NetlibApi1.CustomerServiceReference {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://secure.softwarekey.com/solo/webservices/", ConfigurationName="CustomerServiceReference.CustomerServerSoap")]
    public interface CustomerServerSoap {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://secure.softwarekey.com/solo/webservices/CreateCustomer", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        int CreateCustomer(
                    int authorID, 
                    string userID, 
                    string userPassword, 
                    string companyName, 
                    string firstName, 
                    string lastName, 
                    string address1, 
                    string address2, 
                    string city, 
                    string stateProvince, 
                    string postalCode, 
                    string country, 
                    string email, 
                    string password, 
                    string phone, 
                    string fax, 
                    string nickname, 
                    bool offerProduct, 
                    bool offerPartners);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://secure.softwarekey.com/solo/webservices/CreateCustomer", ReplyAction="*")]
        System.Threading.Tasks.Task<int> CreateCustomerAsync(
                    int authorID, 
                    string userID, 
                    string userPassword, 
                    string companyName, 
                    string firstName, 
                    string lastName, 
                    string address1, 
                    string address2, 
                    string city, 
                    string stateProvince, 
                    string postalCode, 
                    string country, 
                    string email, 
                    string password, 
                    string phone, 
                    string fax, 
                    string nickname, 
                    bool offerProduct, 
                    bool offerPartners);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface CustomerServerSoapChannel : NetlibApi1.CustomerServiceReference.CustomerServerSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class CustomerServerSoapClient : System.ServiceModel.ClientBase<NetlibApi1.CustomerServiceReference.CustomerServerSoap>, NetlibApi1.CustomerServiceReference.CustomerServerSoap {
        
        public CustomerServerSoapClient() {
        }
        
        public CustomerServerSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public CustomerServerSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CustomerServerSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CustomerServerSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public int CreateCustomer(
                    int authorID, 
                    string userID, 
                    string userPassword, 
                    string companyName, 
                    string firstName, 
                    string lastName, 
                    string address1, 
                    string address2, 
                    string city, 
                    string stateProvince, 
                    string postalCode, 
                    string country, 
                    string email, 
                    string password, 
                    string phone, 
                    string fax, 
                    string nickname, 
                    bool offerProduct, 
                    bool offerPartners) {
            return base.Channel.CreateCustomer(authorID, userID, userPassword, companyName, firstName, lastName, address1, address2, city, stateProvince, postalCode, country, email, password, phone, fax, nickname, offerProduct, offerPartners);
        }
        
        public System.Threading.Tasks.Task<int> CreateCustomerAsync(
                    int authorID, 
                    string userID, 
                    string userPassword, 
                    string companyName, 
                    string firstName, 
                    string lastName, 
                    string address1, 
                    string address2, 
                    string city, 
                    string stateProvince, 
                    string postalCode, 
                    string country, 
                    string email, 
                    string password, 
                    string phone, 
                    string fax, 
                    string nickname, 
                    bool offerProduct, 
                    bool offerPartners) {
            return base.Channel.CreateCustomerAsync(authorID, userID, userPassword, companyName, firstName, lastName, address1, address2, city, stateProvince, postalCode, country, email, password, phone, fax, nickname, offerProduct, offerPartners);
        }
    }
}
