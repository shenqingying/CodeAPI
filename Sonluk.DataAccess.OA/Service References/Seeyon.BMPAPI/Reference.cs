﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Sonluk.DataAccess.OA.Seeyon.BMPAPI {
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.79.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://impl.flow.services.v3x.seeyon.com")]
    public partial class ServiceException : object, System.ComponentModel.INotifyPropertyChanged {
        
        private ServiceException1 serviceException1Field;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ServiceException", IsNullable=true, Order=0)]
        public ServiceException1 ServiceException1 {
            get {
                return this.serviceException1Field;
            }
            set {
                this.serviceException1Field = value;
                this.RaisePropertyChanged("ServiceException1");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.79.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(TypeName="ServiceException", Namespace="http://services.v3x.seeyon.com/xsd")]
    public partial class ServiceException1 : Exception {
        
        private long errorNumberField;
        
        private bool errorNumberFieldSpecified;
        
        private string messageField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public long errorNumber {
            get {
                return this.errorNumberField;
            }
            set {
                this.errorNumberField = value;
                this.RaisePropertyChanged("errorNumber");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool errorNumberSpecified {
            get {
                return this.errorNumberFieldSpecified;
            }
            set {
                this.errorNumberFieldSpecified = value;
                this.RaisePropertyChanged("errorNumberSpecified");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Order=1)]
        public string message {
            get {
                return this.messageField;
            }
            set {
                this.messageField = value;
                this.RaisePropertyChanged("message");
            }
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(ServiceException1))]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.79.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://impl.flow.services.v3x.seeyon.com")]
    public partial class Exception : object, System.ComponentModel.INotifyPropertyChanged {
        
        private object exception1Field;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Exception", IsNullable=true, Order=0)]
        public object Exception1 {
            get {
                return this.exception1Field;
            }
            set {
                this.exception1Field = value;
                this.RaisePropertyChanged("Exception1");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.79.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://services.v3x.seeyon.com/xsd")]
    public partial class ServiceResponse : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string errorMessageField;
        
        private long errorNumberField;
        
        private bool errorNumberFieldSpecified;
        
        private long resultField;
        
        private bool resultFieldSpecified;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Order=0)]
        public string errorMessage {
            get {
                return this.errorMessageField;
            }
            set {
                this.errorMessageField = value;
                this.RaisePropertyChanged("errorMessage");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public long errorNumber {
            get {
                return this.errorNumberField;
            }
            set {
                this.errorNumberField = value;
                this.RaisePropertyChanged("errorNumber");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool errorNumberSpecified {
            get {
                return this.errorNumberFieldSpecified;
            }
            set {
                this.errorNumberFieldSpecified = value;
                this.RaisePropertyChanged("errorNumberSpecified");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public long result {
            get {
                return this.resultField;
            }
            set {
                this.resultField = value;
                this.RaisePropertyChanged("result");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool resultSpecified {
            get {
                return this.resultFieldSpecified;
            }
            set {
                this.resultFieldSpecified = value;
                this.RaisePropertyChanged("resultSpecified");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="www.seeyon.com", ConfigurationName="Seeyon.BMPAPI.BPMServicePortType")]
    public interface BPMServicePortType {
        
        // CODEGEN: 消息 receiveThirdpartyFormRequest 的包装命名空间(http://impl.flow.services.v3x.seeyon.com)以后生成的消息协定与默认值(www.seeyon.com)不匹配
        [System.ServiceModel.OperationContractAttribute(Action="urn:receiveThirdpartyForm", ReplyAction="urn:receiveThirdpartyFormResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(Sonluk.DataAccess.OA.Seeyon.BMPAPI.ServiceException), Action="urn:receiveThirdpartyFormServiceException", Name="ServiceException", Namespace="http://impl.flow.services.v3x.seeyon.com")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ServiceResponse))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Exception))]
        Sonluk.DataAccess.OA.Seeyon.BMPAPI.receiveThirdpartyFormResponse receiveThirdpartyForm(Sonluk.DataAccess.OA.Seeyon.BMPAPI.receiveThirdpartyFormRequest request);
        
        // CODEGEN: 消息 getFlowStateRequest 的包装命名空间(http://impl.flow.services.v3x.seeyon.com)以后生成的消息协定与默认值(www.seeyon.com)不匹配
        [System.ServiceModel.OperationContractAttribute(Action="urn:getFlowState", ReplyAction="urn:getFlowStateResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(Sonluk.DataAccess.OA.Seeyon.BMPAPI.ServiceException), Action="urn:getFlowStateServiceException", Name="ServiceException", Namespace="http://impl.flow.services.v3x.seeyon.com")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ServiceResponse))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Exception))]
        Sonluk.DataAccess.OA.Seeyon.BMPAPI.getFlowStateResponse getFlowState(Sonluk.DataAccess.OA.Seeyon.BMPAPI.getFlowStateRequest request);
        
        // CODEGEN: 消息 launchFormCollaborationRequest 的包装命名空间(http://impl.flow.services.v3x.seeyon.com)以后生成的消息协定与默认值(www.seeyon.com)不匹配
        [System.ServiceModel.OperationContractAttribute(Action="urn:launchFormCollaboration", ReplyAction="urn:launchFormCollaborationResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(Sonluk.DataAccess.OA.Seeyon.BMPAPI.ServiceException), Action="urn:launchFormCollaborationServiceException", Name="ServiceException", Namespace="http://impl.flow.services.v3x.seeyon.com")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ServiceResponse))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Exception))]
        Sonluk.DataAccess.OA.Seeyon.BMPAPI.launchFormCollaborationResponse launchFormCollaboration(Sonluk.DataAccess.OA.Seeyon.BMPAPI.launchFormCollaborationRequest request);
        
        // CODEGEN: 消息 getTemplateDefinitionRequest 的包装命名空间(http://impl.flow.services.v3x.seeyon.com)以后生成的消息协定与默认值(www.seeyon.com)不匹配
        [System.ServiceModel.OperationContractAttribute(Action="urn:getTemplateDefinition", ReplyAction="urn:getTemplateDefinitionResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(Sonluk.DataAccess.OA.Seeyon.BMPAPI.ServiceException), Action="urn:getTemplateDefinitionServiceException", Name="ServiceException", Namespace="http://impl.flow.services.v3x.seeyon.com")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ServiceResponse))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Exception))]
        Sonluk.DataAccess.OA.Seeyon.BMPAPI.getTemplateDefinitionResponse getTemplateDefinition(Sonluk.DataAccess.OA.Seeyon.BMPAPI.getTemplateDefinitionRequest request);
        
        // CODEGEN: 消息 getFormCollIdsByDateTimeRequest 的包装命名空间(http://impl.flow.services.v3x.seeyon.com)以后生成的消息协定与默认值(www.seeyon.com)不匹配
        [System.ServiceModel.OperationContractAttribute(Action="urn:getFormCollIdsByDateTime", ReplyAction="urn:getFormCollIdsByDateTimeResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(Sonluk.DataAccess.OA.Seeyon.BMPAPI.ServiceException), Action="urn:getFormCollIdsByDateTimeServiceException", Name="ServiceException", Namespace="http://impl.flow.services.v3x.seeyon.com")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ServiceResponse))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Exception))]
        Sonluk.DataAccess.OA.Seeyon.BMPAPI.getFormCollIdsByDateTimeResponse getFormCollIdsByDateTime(Sonluk.DataAccess.OA.Seeyon.BMPAPI.getFormCollIdsByDateTimeRequest request);
        
        // CODEGEN: 消息 launchHtmlCollaborationRequest 的包装命名空间(http://impl.flow.services.v3x.seeyon.com)以后生成的消息协定与默认值(www.seeyon.com)不匹配
        [System.ServiceModel.OperationContractAttribute(Action="urn:launchHtmlCollaboration", ReplyAction="urn:launchHtmlCollaborationResponse")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ServiceResponse))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Exception))]
        Sonluk.DataAccess.OA.Seeyon.BMPAPI.launchHtmlCollaborationResponse launchHtmlCollaboration(Sonluk.DataAccess.OA.Seeyon.BMPAPI.launchHtmlCollaborationRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="receiveThirdpartyForm", WrapperNamespace="http://impl.flow.services.v3x.seeyon.com", IsWrapped=true)]
    public partial class receiveThirdpartyFormRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://impl.flow.services.v3x.seeyon.com", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string token;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://impl.flow.services.v3x.seeyon.com", Order=1)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string xmlData;
        
        public receiveThirdpartyFormRequest() {
        }
        
        public receiveThirdpartyFormRequest(string token, string xmlData) {
            this.token = token;
            this.xmlData = xmlData;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="receiveThirdpartyFormResponse", WrapperNamespace="http://impl.flow.services.v3x.seeyon.com", IsWrapped=true)]
    public partial class receiveThirdpartyFormResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://impl.flow.services.v3x.seeyon.com", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string @return;
        
        public receiveThirdpartyFormResponse() {
        }
        
        public receiveThirdpartyFormResponse(string @return) {
            this.@return = @return;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="getFlowState", WrapperNamespace="http://impl.flow.services.v3x.seeyon.com", IsWrapped=true)]
    public partial class getFlowStateRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://impl.flow.services.v3x.seeyon.com", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string token;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://impl.flow.services.v3x.seeyon.com", Order=1)]
        public long flowId;
        
        public getFlowStateRequest() {
        }
        
        public getFlowStateRequest(string token, long flowId) {
            this.token = token;
            this.flowId = flowId;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="getFlowStateResponse", WrapperNamespace="http://impl.flow.services.v3x.seeyon.com", IsWrapped=true)]
    public partial class getFlowStateResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://impl.flow.services.v3x.seeyon.com", Order=0)]
        public long @return;
        
        public getFlowStateResponse() {
        }
        
        public getFlowStateResponse(long @return) {
            this.@return = @return;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="launchFormCollaboration", WrapperNamespace="http://impl.flow.services.v3x.seeyon.com", IsWrapped=true)]
    public partial class launchFormCollaborationRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://impl.flow.services.v3x.seeyon.com", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string token;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://impl.flow.services.v3x.seeyon.com", Order=1)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string senderLoginName;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://impl.flow.services.v3x.seeyon.com", Order=2)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string templateCode;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://impl.flow.services.v3x.seeyon.com", Order=3)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string subject;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://impl.flow.services.v3x.seeyon.com", Order=4)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string data;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://impl.flow.services.v3x.seeyon.com", Order=5)]
        [System.Xml.Serialization.XmlElementAttribute("attachments")]
        public long[] attachments;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://impl.flow.services.v3x.seeyon.com", Order=6)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string param;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://impl.flow.services.v3x.seeyon.com", Order=7)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string relateDoc;
        
        public launchFormCollaborationRequest() {
        }
        
        public launchFormCollaborationRequest(string token, string senderLoginName, string templateCode, string subject, string data, long[] attachments, string param, string relateDoc) {
            this.token = token;
            this.senderLoginName = senderLoginName;
            this.templateCode = templateCode;
            this.subject = subject;
            this.data = data;
            this.attachments = attachments;
            this.param = param;
            this.relateDoc = relateDoc;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="launchFormCollaborationResponse", WrapperNamespace="http://impl.flow.services.v3x.seeyon.com", IsWrapped=true)]
    public partial class launchFormCollaborationResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://impl.flow.services.v3x.seeyon.com", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public Sonluk.DataAccess.OA.Seeyon.BMPAPI.ServiceResponse @return;
        
        public launchFormCollaborationResponse() {
        }
        
        public launchFormCollaborationResponse(Sonluk.DataAccess.OA.Seeyon.BMPAPI.ServiceResponse @return) {
            this.@return = @return;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="getTemplateDefinition", WrapperNamespace="http://impl.flow.services.v3x.seeyon.com", IsWrapped=true)]
    public partial class getTemplateDefinitionRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://impl.flow.services.v3x.seeyon.com", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string token;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://impl.flow.services.v3x.seeyon.com", Order=1)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string templateCode;
        
        public getTemplateDefinitionRequest() {
        }
        
        public getTemplateDefinitionRequest(string token, string templateCode) {
            this.token = token;
            this.templateCode = templateCode;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="getTemplateDefinitionResponse", WrapperNamespace="http://impl.flow.services.v3x.seeyon.com", IsWrapped=true)]
    public partial class getTemplateDefinitionResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://impl.flow.services.v3x.seeyon.com", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute("return", IsNullable=true)]
        public string[] @return;
        
        public getTemplateDefinitionResponse() {
        }
        
        public getTemplateDefinitionResponse(string[] @return) {
            this.@return = @return;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="getFormCollIdsByDateTime", WrapperNamespace="http://impl.flow.services.v3x.seeyon.com", IsWrapped=true)]
    public partial class getFormCollIdsByDateTimeRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://impl.flow.services.v3x.seeyon.com", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string token;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://impl.flow.services.v3x.seeyon.com", Order=1)]
        [System.Xml.Serialization.XmlElementAttribute("templateCode", IsNullable=true)]
        public string[] templateCode;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://impl.flow.services.v3x.seeyon.com", Order=2)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string beginDateTime;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://impl.flow.services.v3x.seeyon.com", Order=3)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string endDateTime;
        
        public getFormCollIdsByDateTimeRequest() {
        }
        
        public getFormCollIdsByDateTimeRequest(string token, string[] templateCode, string beginDateTime, string endDateTime) {
            this.token = token;
            this.templateCode = templateCode;
            this.beginDateTime = beginDateTime;
            this.endDateTime = endDateTime;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="getFormCollIdsByDateTimeResponse", WrapperNamespace="http://impl.flow.services.v3x.seeyon.com", IsWrapped=true)]
    public partial class getFormCollIdsByDateTimeResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://impl.flow.services.v3x.seeyon.com", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute("return")]
        public long[] @return;
        
        public getFormCollIdsByDateTimeResponse() {
        }
        
        public getFormCollIdsByDateTimeResponse(long[] @return) {
            this.@return = @return;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="launchHtmlCollaboration", WrapperNamespace="http://impl.flow.services.v3x.seeyon.com", IsWrapped=true)]
    public partial class launchHtmlCollaborationRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://impl.flow.services.v3x.seeyon.com", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string token;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://impl.flow.services.v3x.seeyon.com", Order=1)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string senderLoginName;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://impl.flow.services.v3x.seeyon.com", Order=2)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string templateCode;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://impl.flow.services.v3x.seeyon.com", Order=3)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string subject;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://impl.flow.services.v3x.seeyon.com", Order=4)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string bodyContent;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://impl.flow.services.v3x.seeyon.com", Order=5)]
        [System.Xml.Serialization.XmlElementAttribute("attachments")]
        public long[] attachments;
        
        public launchHtmlCollaborationRequest() {
        }
        
        public launchHtmlCollaborationRequest(string token, string senderLoginName, string templateCode, string subject, string bodyContent, long[] attachments) {
            this.token = token;
            this.senderLoginName = senderLoginName;
            this.templateCode = templateCode;
            this.subject = subject;
            this.bodyContent = bodyContent;
            this.attachments = attachments;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="launchHtmlCollaborationResponse", WrapperNamespace="http://impl.flow.services.v3x.seeyon.com", IsWrapped=true)]
    public partial class launchHtmlCollaborationResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://impl.flow.services.v3x.seeyon.com", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public Sonluk.DataAccess.OA.Seeyon.BMPAPI.ServiceResponse @return;
        
        public launchHtmlCollaborationResponse() {
        }
        
        public launchHtmlCollaborationResponse(Sonluk.DataAccess.OA.Seeyon.BMPAPI.ServiceResponse @return) {
            this.@return = @return;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface BPMServicePortTypeChannel : Sonluk.DataAccess.OA.Seeyon.BMPAPI.BPMServicePortType, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class BPMServicePortTypeClient : System.ServiceModel.ClientBase<Sonluk.DataAccess.OA.Seeyon.BMPAPI.BPMServicePortType>, Sonluk.DataAccess.OA.Seeyon.BMPAPI.BPMServicePortType {
        
        public BPMServicePortTypeClient() {
        }
        
        public BPMServicePortTypeClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public BPMServicePortTypeClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public BPMServicePortTypeClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public BPMServicePortTypeClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        Sonluk.DataAccess.OA.Seeyon.BMPAPI.receiveThirdpartyFormResponse Sonluk.DataAccess.OA.Seeyon.BMPAPI.BPMServicePortType.receiveThirdpartyForm(Sonluk.DataAccess.OA.Seeyon.BMPAPI.receiveThirdpartyFormRequest request) {
            return base.Channel.receiveThirdpartyForm(request);
        }
        
        public string receiveThirdpartyForm(string token, string xmlData) {
            Sonluk.DataAccess.OA.Seeyon.BMPAPI.receiveThirdpartyFormRequest inValue = new Sonluk.DataAccess.OA.Seeyon.BMPAPI.receiveThirdpartyFormRequest();
            inValue.token = token;
            inValue.xmlData = xmlData;
            Sonluk.DataAccess.OA.Seeyon.BMPAPI.receiveThirdpartyFormResponse retVal = ((Sonluk.DataAccess.OA.Seeyon.BMPAPI.BPMServicePortType)(this)).receiveThirdpartyForm(inValue);
            return retVal.@return;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        Sonluk.DataAccess.OA.Seeyon.BMPAPI.getFlowStateResponse Sonluk.DataAccess.OA.Seeyon.BMPAPI.BPMServicePortType.getFlowState(Sonluk.DataAccess.OA.Seeyon.BMPAPI.getFlowStateRequest request) {
            return base.Channel.getFlowState(request);
        }
        
        public long getFlowState(string token, long flowId) {
            Sonluk.DataAccess.OA.Seeyon.BMPAPI.getFlowStateRequest inValue = new Sonluk.DataAccess.OA.Seeyon.BMPAPI.getFlowStateRequest();
            inValue.token = token;
            inValue.flowId = flowId;
            Sonluk.DataAccess.OA.Seeyon.BMPAPI.getFlowStateResponse retVal = ((Sonluk.DataAccess.OA.Seeyon.BMPAPI.BPMServicePortType)(this)).getFlowState(inValue);
            return retVal.@return;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        Sonluk.DataAccess.OA.Seeyon.BMPAPI.launchFormCollaborationResponse Sonluk.DataAccess.OA.Seeyon.BMPAPI.BPMServicePortType.launchFormCollaboration(Sonluk.DataAccess.OA.Seeyon.BMPAPI.launchFormCollaborationRequest request) {
            return base.Channel.launchFormCollaboration(request);
        }
        
        public Sonluk.DataAccess.OA.Seeyon.BMPAPI.ServiceResponse launchFormCollaboration(string token, string senderLoginName, string templateCode, string subject, string data, long[] attachments, string param, string relateDoc) {
            Sonluk.DataAccess.OA.Seeyon.BMPAPI.launchFormCollaborationRequest inValue = new Sonluk.DataAccess.OA.Seeyon.BMPAPI.launchFormCollaborationRequest();
            inValue.token = token;
            inValue.senderLoginName = senderLoginName;
            inValue.templateCode = templateCode;
            inValue.subject = subject;
            inValue.data = data;
            inValue.attachments = attachments;
            inValue.param = param;
            inValue.relateDoc = relateDoc;
            Sonluk.DataAccess.OA.Seeyon.BMPAPI.launchFormCollaborationResponse retVal = ((Sonluk.DataAccess.OA.Seeyon.BMPAPI.BPMServicePortType)(this)).launchFormCollaboration(inValue);
            return retVal.@return;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        Sonluk.DataAccess.OA.Seeyon.BMPAPI.getTemplateDefinitionResponse Sonluk.DataAccess.OA.Seeyon.BMPAPI.BPMServicePortType.getTemplateDefinition(Sonluk.DataAccess.OA.Seeyon.BMPAPI.getTemplateDefinitionRequest request) {
            return base.Channel.getTemplateDefinition(request);
        }
        
        public string[] getTemplateDefinition(string token, string templateCode) {
            Sonluk.DataAccess.OA.Seeyon.BMPAPI.getTemplateDefinitionRequest inValue = new Sonluk.DataAccess.OA.Seeyon.BMPAPI.getTemplateDefinitionRequest();
            inValue.token = token;
            inValue.templateCode = templateCode;
            Sonluk.DataAccess.OA.Seeyon.BMPAPI.getTemplateDefinitionResponse retVal = ((Sonluk.DataAccess.OA.Seeyon.BMPAPI.BPMServicePortType)(this)).getTemplateDefinition(inValue);
            return retVal.@return;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        Sonluk.DataAccess.OA.Seeyon.BMPAPI.getFormCollIdsByDateTimeResponse Sonluk.DataAccess.OA.Seeyon.BMPAPI.BPMServicePortType.getFormCollIdsByDateTime(Sonluk.DataAccess.OA.Seeyon.BMPAPI.getFormCollIdsByDateTimeRequest request) {
            return base.Channel.getFormCollIdsByDateTime(request);
        }
        
        public long[] getFormCollIdsByDateTime(string token, string[] templateCode, string beginDateTime, string endDateTime) {
            Sonluk.DataAccess.OA.Seeyon.BMPAPI.getFormCollIdsByDateTimeRequest inValue = new Sonluk.DataAccess.OA.Seeyon.BMPAPI.getFormCollIdsByDateTimeRequest();
            inValue.token = token;
            inValue.templateCode = templateCode;
            inValue.beginDateTime = beginDateTime;
            inValue.endDateTime = endDateTime;
            Sonluk.DataAccess.OA.Seeyon.BMPAPI.getFormCollIdsByDateTimeResponse retVal = ((Sonluk.DataAccess.OA.Seeyon.BMPAPI.BPMServicePortType)(this)).getFormCollIdsByDateTime(inValue);
            return retVal.@return;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        Sonluk.DataAccess.OA.Seeyon.BMPAPI.launchHtmlCollaborationResponse Sonluk.DataAccess.OA.Seeyon.BMPAPI.BPMServicePortType.launchHtmlCollaboration(Sonluk.DataAccess.OA.Seeyon.BMPAPI.launchHtmlCollaborationRequest request) {
            return base.Channel.launchHtmlCollaboration(request);
        }
        
        public Sonluk.DataAccess.OA.Seeyon.BMPAPI.ServiceResponse launchHtmlCollaboration(string token, string senderLoginName, string templateCode, string subject, string bodyContent, long[] attachments) {
            Sonluk.DataAccess.OA.Seeyon.BMPAPI.launchHtmlCollaborationRequest inValue = new Sonluk.DataAccess.OA.Seeyon.BMPAPI.launchHtmlCollaborationRequest();
            inValue.token = token;
            inValue.senderLoginName = senderLoginName;
            inValue.templateCode = templateCode;
            inValue.subject = subject;
            inValue.bodyContent = bodyContent;
            inValue.attachments = attachments;
            Sonluk.DataAccess.OA.Seeyon.BMPAPI.launchHtmlCollaborationResponse retVal = ((Sonluk.DataAccess.OA.Seeyon.BMPAPI.BPMServicePortType)(this)).launchHtmlCollaboration(inValue);
            return retVal.@return;
        }
    }
}
