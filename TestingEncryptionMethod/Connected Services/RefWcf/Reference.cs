﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TestingEncryptionMethod.RefWcf {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Variables", Namespace="http://schemas.datacontract.org/2004/07/WCFTestEncryptionMethod")]
    [System.SerializableAttribute()]
    public partial class Variables : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string EncryptField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private byte[] EncryptByteField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int NumberMethodMsSQLField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int NumberMethodWCFField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int NumberMethodWinFormsField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int SizeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string StartWinFormsField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string StopWinformsField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Encrypt {
            get {
                return this.EncryptField;
            }
            set {
                if ((object.ReferenceEquals(this.EncryptField, value) != true)) {
                    this.EncryptField = value;
                    this.RaisePropertyChanged("Encrypt");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public byte[] EncryptByte {
            get {
                return this.EncryptByteField;
            }
            set {
                if ((object.ReferenceEquals(this.EncryptByteField, value) != true)) {
                    this.EncryptByteField = value;
                    this.RaisePropertyChanged("EncryptByte");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int NumberMethodMsSQL {
            get {
                return this.NumberMethodMsSQLField;
            }
            set {
                if ((this.NumberMethodMsSQLField.Equals(value) != true)) {
                    this.NumberMethodMsSQLField = value;
                    this.RaisePropertyChanged("NumberMethodMsSQL");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int NumberMethodWCF {
            get {
                return this.NumberMethodWCFField;
            }
            set {
                if ((this.NumberMethodWCFField.Equals(value) != true)) {
                    this.NumberMethodWCFField = value;
                    this.RaisePropertyChanged("NumberMethodWCF");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int NumberMethodWinForms {
            get {
                return this.NumberMethodWinFormsField;
            }
            set {
                if ((this.NumberMethodWinFormsField.Equals(value) != true)) {
                    this.NumberMethodWinFormsField = value;
                    this.RaisePropertyChanged("NumberMethodWinForms");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Size {
            get {
                return this.SizeField;
            }
            set {
                if ((this.SizeField.Equals(value) != true)) {
                    this.SizeField = value;
                    this.RaisePropertyChanged("Size");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string StartWinForms {
            get {
                return this.StartWinFormsField;
            }
            set {
                if ((object.ReferenceEquals(this.StartWinFormsField, value) != true)) {
                    this.StartWinFormsField = value;
                    this.RaisePropertyChanged("StartWinForms");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string StopWinforms {
            get {
                return this.StopWinformsField;
            }
            set {
                if ((object.ReferenceEquals(this.StopWinformsField, value) != true)) {
                    this.StopWinformsField = value;
                    this.RaisePropertyChanged("StopWinforms");
                }
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="RefWcf.IService1")]
    public interface IService1 {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/WindowsFormConnect", ReplyAction="http://tempuri.org/IService1/WindowsFormConnectResponse")]
        string WindowsFormConnect(TestingEncryptionMethod.RefWcf.Variables windowsForm);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/WindowsFormConnect", ReplyAction="http://tempuri.org/IService1/WindowsFormConnectResponse")]
        System.Threading.Tasks.Task<string> WindowsFormConnectAsync(TestingEncryptionMethod.RefWcf.Variables windowsForm);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IService1Channel : TestingEncryptionMethod.RefWcf.IService1, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class Service1Client : System.ServiceModel.ClientBase<TestingEncryptionMethod.RefWcf.IService1>, TestingEncryptionMethod.RefWcf.IService1 {
        
        public Service1Client() {
        }
        
        public Service1Client(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public Service1Client(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string WindowsFormConnect(TestingEncryptionMethod.RefWcf.Variables windowsForm) {
            return base.Channel.WindowsFormConnect(windowsForm);
        }
        
        public System.Threading.Tasks.Task<string> WindowsFormConnectAsync(TestingEncryptionMethod.RefWcf.Variables windowsForm) {
            return base.Channel.WindowsFormConnectAsync(windowsForm);
        }
    }
}
