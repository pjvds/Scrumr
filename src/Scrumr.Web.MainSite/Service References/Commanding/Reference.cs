﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Scrumr.Web.MainSite.Commanding {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="Commanding.IScrumrCommandService")]
    public interface IScrumrCommandService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IScrumrCommandService/ExecuteCommand", ReplyAction="http://tempuri.org/IScrumrCommandService/ExecuteCommandResponse")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Scrumr.Commands.CreateNewProject))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Ncqrs.Commanding.CommandBase))]
        void ExecuteCommand(object command);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IScrumrCommandServiceChannel : Scrumr.Web.MainSite.Commanding.IScrumrCommandService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ScrumrCommandServiceClient : System.ServiceModel.ClientBase<Scrumr.Web.MainSite.Commanding.IScrumrCommandService>, Scrumr.Web.MainSite.Commanding.IScrumrCommandService {
        
        public ScrumrCommandServiceClient() {
        }
        
        public ScrumrCommandServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ScrumrCommandServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ScrumrCommandServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ScrumrCommandServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public void ExecuteCommand(object command) {
            base.Channel.ExecuteCommand(command);
        }
    }
}
