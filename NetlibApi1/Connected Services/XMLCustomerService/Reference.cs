﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NetlibApi1.XMLCustomerService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://secure.softwarekey.com/solo/webservices/", ConfigurationName="XMLCustomerService.XmlCustomerServiceSoap")]
    public interface XmlCustomerServiceSoap {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://secure.softwarekey.com/solo/webservices/GetCustomerDataByAuthor", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Xml.XmlNode GetCustomerDataByAuthor(System.Xml.XmlNode xml);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://secure.softwarekey.com/solo/webservices/GetCustomerDataByAuthor", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Xml.XmlNode> GetCustomerDataByAuthorAsync(System.Xml.XmlNode xml);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://secure.softwarekey.com/solo/webservices/GetCustomerDataByAuthorS", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Xml.XmlNode GetCustomerDataByAuthorS(string xml);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://secure.softwarekey.com/solo/webservices/GetCustomerDataByAuthorS", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Xml.XmlNode> GetCustomerDataByAuthorSAsync(string xml);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://secure.softwarekey.com/solo/webservices/CustomerSearch", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Xml.XmlNode CustomerSearch(System.Xml.XmlNode xml);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://secure.softwarekey.com/solo/webservices/CustomerSearch", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Xml.XmlNode> CustomerSearchAsync(System.Xml.XmlNode xml);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://secure.softwarekey.com/solo/webservices/CustomerSearchS", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Xml.XmlNode CustomerSearchS(string xml);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://secure.softwarekey.com/solo/webservices/CustomerSearchS", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Xml.XmlNode> CustomerSearchSAsync(string xml);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://secure.softwarekey.com/solo/webservices/CustomerLogin", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Xml.XmlNode CustomerLogin(System.Xml.XmlNode xml);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://secure.softwarekey.com/solo/webservices/CustomerLogin", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Xml.XmlNode> CustomerLoginAsync(System.Xml.XmlNode xml);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://secure.softwarekey.com/solo/webservices/CustomerLoginS", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Xml.XmlNode CustomerLoginS(string xml);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://secure.softwarekey.com/solo/webservices/CustomerLoginS", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Xml.XmlNode> CustomerLoginSAsync(string xml);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface XmlCustomerServiceSoapChannel : NetlibApi1.XMLCustomerService.XmlCustomerServiceSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class XmlCustomerServiceSoapClient : System.ServiceModel.ClientBase<NetlibApi1.XMLCustomerService.XmlCustomerServiceSoap>, NetlibApi1.XMLCustomerService.XmlCustomerServiceSoap {
        
        public XmlCustomerServiceSoapClient() {
        }
        
        public XmlCustomerServiceSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public XmlCustomerServiceSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public XmlCustomerServiceSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public XmlCustomerServiceSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.Xml.XmlNode GetCustomerDataByAuthor(System.Xml.XmlNode xml) {
            return base.Channel.GetCustomerDataByAuthor(xml);
        }
        
        public System.Threading.Tasks.Task<System.Xml.XmlNode> GetCustomerDataByAuthorAsync(System.Xml.XmlNode xml) {
            return base.Channel.GetCustomerDataByAuthorAsync(xml);
        }
        
        public System.Xml.XmlNode GetCustomerDataByAuthorS(string xml) {
            return base.Channel.GetCustomerDataByAuthorS(xml);
        }
        
        public System.Threading.Tasks.Task<System.Xml.XmlNode> GetCustomerDataByAuthorSAsync(string xml) {
            return base.Channel.GetCustomerDataByAuthorSAsync(xml);
        }
        
        public System.Xml.XmlNode CustomerSearch(System.Xml.XmlNode xml) {
            return base.Channel.CustomerSearch(xml);
        }
        
        public System.Threading.Tasks.Task<System.Xml.XmlNode> CustomerSearchAsync(System.Xml.XmlNode xml) {
            return base.Channel.CustomerSearchAsync(xml);
        }
        
        public System.Xml.XmlNode CustomerSearchS(string xml) {
            return base.Channel.CustomerSearchS(xml);
        }
        
        public System.Threading.Tasks.Task<System.Xml.XmlNode> CustomerSearchSAsync(string xml) {
            return base.Channel.CustomerSearchSAsync(xml);
        }
        
        public System.Xml.XmlNode CustomerLogin(System.Xml.XmlNode xml) {
            return base.Channel.CustomerLogin(xml);
        }
        
        public System.Threading.Tasks.Task<System.Xml.XmlNode> CustomerLoginAsync(System.Xml.XmlNode xml) {
            return base.Channel.CustomerLoginAsync(xml);
        }
        
        public System.Xml.XmlNode CustomerLoginS(string xml) {
            return base.Channel.CustomerLoginS(xml);
        }
        
        public System.Threading.Tasks.Task<System.Xml.XmlNode> CustomerLoginSAsync(string xml) {
            return base.Channel.CustomerLoginSAsync(xml);
        }
    }
}