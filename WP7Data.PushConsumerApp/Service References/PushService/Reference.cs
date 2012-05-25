﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.269
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This code was auto-generated by Microsoft.Silverlight.Phone.ServiceReference, version 3.7.0.0
// 
namespace WP7Data.Push.ConsumerApp.PushService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="PushService.IPushRegistration")]
    public interface IPushRegistration {
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://tempuri.org/IPushRegistration/IsPhoneSubscribed", ReplyAction="http://tempuri.org/IPushRegistration/IsPhoneSubscribedResponse")]
        System.IAsyncResult BeginIsPhoneSubscribed(System.Guid guid, string channelURI, System.AsyncCallback callback, object asyncState);
        
        int EndIsPhoneSubscribed(System.IAsyncResult result);
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://tempuri.org/IPushRegistration/SubscribePhone", ReplyAction="http://tempuri.org/IPushRegistration/SubscribePhoneResponse")]
        System.IAsyncResult BeginSubscribePhone(System.Guid guid, string channelURI, string nick, string device, System.AsyncCallback callback, object asyncState);
        
        int EndSubscribePhone(System.IAsyncResult result);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IPushRegistrationChannel : WP7Data.Push.ConsumerApp.PushService.IPushRegistration, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class IsPhoneSubscribedCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public IsPhoneSubscribedCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public int Result {
            get {
                base.RaiseExceptionIfNecessary();
                return ((int)(this.results[0]));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class SubscribePhoneCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public SubscribePhoneCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public int Result {
            get {
                base.RaiseExceptionIfNecessary();
                return ((int)(this.results[0]));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class PushRegistrationClient : System.ServiceModel.ClientBase<WP7Data.Push.ConsumerApp.PushService.IPushRegistration>, WP7Data.Push.ConsumerApp.PushService.IPushRegistration {
        
        private BeginOperationDelegate onBeginIsPhoneSubscribedDelegate;
        
        private EndOperationDelegate onEndIsPhoneSubscribedDelegate;
        
        private System.Threading.SendOrPostCallback onIsPhoneSubscribedCompletedDelegate;
        
        private BeginOperationDelegate onBeginSubscribePhoneDelegate;
        
        private EndOperationDelegate onEndSubscribePhoneDelegate;
        
        private System.Threading.SendOrPostCallback onSubscribePhoneCompletedDelegate;
        
        private BeginOperationDelegate onBeginOpenDelegate;
        
        private EndOperationDelegate onEndOpenDelegate;
        
        private System.Threading.SendOrPostCallback onOpenCompletedDelegate;
        
        private BeginOperationDelegate onBeginCloseDelegate;
        
        private EndOperationDelegate onEndCloseDelegate;
        
        private System.Threading.SendOrPostCallback onCloseCompletedDelegate;
        
        public PushRegistrationClient() {
        }
        
        public PushRegistrationClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public PushRegistrationClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public PushRegistrationClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public PushRegistrationClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.Net.CookieContainer CookieContainer {
            get {
                System.ServiceModel.Channels.IHttpCookieContainerManager httpCookieContainerManager = this.InnerChannel.GetProperty<System.ServiceModel.Channels.IHttpCookieContainerManager>();
                if ((httpCookieContainerManager != null)) {
                    return httpCookieContainerManager.CookieContainer;
                }
                else {
                    return null;
                }
            }
            set {
                System.ServiceModel.Channels.IHttpCookieContainerManager httpCookieContainerManager = this.InnerChannel.GetProperty<System.ServiceModel.Channels.IHttpCookieContainerManager>();
                if ((httpCookieContainerManager != null)) {
                    httpCookieContainerManager.CookieContainer = value;
                }
                else {
                    throw new System.InvalidOperationException("Unable to set the CookieContainer. Please make sure the binding contains an HttpC" +
                            "ookieContainerBindingElement.");
                }
            }
        }
        
        public event System.EventHandler<IsPhoneSubscribedCompletedEventArgs> IsPhoneSubscribedCompleted;
        
        public event System.EventHandler<SubscribePhoneCompletedEventArgs> SubscribePhoneCompleted;
        
        public event System.EventHandler<System.ComponentModel.AsyncCompletedEventArgs> OpenCompleted;
        
        public event System.EventHandler<System.ComponentModel.AsyncCompletedEventArgs> CloseCompleted;
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.IAsyncResult WP7Data.Push.ConsumerApp.PushService.IPushRegistration.BeginIsPhoneSubscribed(System.Guid guid, string channelURI, System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginIsPhoneSubscribed(guid, channelURI, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        int WP7Data.Push.ConsumerApp.PushService.IPushRegistration.EndIsPhoneSubscribed(System.IAsyncResult result) {
            return base.Channel.EndIsPhoneSubscribed(result);
        }
        
        private System.IAsyncResult OnBeginIsPhoneSubscribed(object[] inValues, System.AsyncCallback callback, object asyncState) {
            System.Guid guid = ((System.Guid)(inValues[0]));
            string channelURI = ((string)(inValues[1]));
            return ((WP7Data.Push.ConsumerApp.PushService.IPushRegistration)(this)).BeginIsPhoneSubscribed(guid, channelURI, callback, asyncState);
        }
        
        private object[] OnEndIsPhoneSubscribed(System.IAsyncResult result) {
            int retVal = ((WP7Data.Push.ConsumerApp.PushService.IPushRegistration)(this)).EndIsPhoneSubscribed(result);
            return new object[] {
                    retVal};
        }
        
        private void OnIsPhoneSubscribedCompleted(object state) {
            if ((this.IsPhoneSubscribedCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.IsPhoneSubscribedCompleted(this, new IsPhoneSubscribedCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void IsPhoneSubscribedAsync(System.Guid guid, string channelURI) {
            this.IsPhoneSubscribedAsync(guid, channelURI, null);
        }
        
        public void IsPhoneSubscribedAsync(System.Guid guid, string channelURI, object userState) {
            if ((this.onBeginIsPhoneSubscribedDelegate == null)) {
                this.onBeginIsPhoneSubscribedDelegate = new BeginOperationDelegate(this.OnBeginIsPhoneSubscribed);
            }
            if ((this.onEndIsPhoneSubscribedDelegate == null)) {
                this.onEndIsPhoneSubscribedDelegate = new EndOperationDelegate(this.OnEndIsPhoneSubscribed);
            }
            if ((this.onIsPhoneSubscribedCompletedDelegate == null)) {
                this.onIsPhoneSubscribedCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnIsPhoneSubscribedCompleted);
            }
            base.InvokeAsync(this.onBeginIsPhoneSubscribedDelegate, new object[] {
                        guid,
                        channelURI}, this.onEndIsPhoneSubscribedDelegate, this.onIsPhoneSubscribedCompletedDelegate, userState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.IAsyncResult WP7Data.Push.ConsumerApp.PushService.IPushRegistration.BeginSubscribePhone(System.Guid guid, string channelURI, string nick, string device, System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginSubscribePhone(guid, channelURI, nick, device, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        int WP7Data.Push.ConsumerApp.PushService.IPushRegistration.EndSubscribePhone(System.IAsyncResult result) {
            return base.Channel.EndSubscribePhone(result);
        }
        
        private System.IAsyncResult OnBeginSubscribePhone(object[] inValues, System.AsyncCallback callback, object asyncState) {
            System.Guid guid = ((System.Guid)(inValues[0]));
            string channelURI = ((string)(inValues[1]));
            string nick = ((string)(inValues[2]));
            string device = ((string)(inValues[3]));
            return ((WP7Data.Push.ConsumerApp.PushService.IPushRegistration)(this)).BeginSubscribePhone(guid, channelURI, nick, device, callback, asyncState);
        }
        
        private object[] OnEndSubscribePhone(System.IAsyncResult result) {
            int retVal = ((WP7Data.Push.ConsumerApp.PushService.IPushRegistration)(this)).EndSubscribePhone(result);
            return new object[] {
                    retVal};
        }
        
        private void OnSubscribePhoneCompleted(object state) {
            if ((this.SubscribePhoneCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.SubscribePhoneCompleted(this, new SubscribePhoneCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void SubscribePhoneAsync(System.Guid guid, string channelURI, string nick, string device) {
            this.SubscribePhoneAsync(guid, channelURI, nick, device, null);
        }
        
        public void SubscribePhoneAsync(System.Guid guid, string channelURI, string nick, string device, object userState) {
            if ((this.onBeginSubscribePhoneDelegate == null)) {
                this.onBeginSubscribePhoneDelegate = new BeginOperationDelegate(this.OnBeginSubscribePhone);
            }
            if ((this.onEndSubscribePhoneDelegate == null)) {
                this.onEndSubscribePhoneDelegate = new EndOperationDelegate(this.OnEndSubscribePhone);
            }
            if ((this.onSubscribePhoneCompletedDelegate == null)) {
                this.onSubscribePhoneCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnSubscribePhoneCompleted);
            }
            base.InvokeAsync(this.onBeginSubscribePhoneDelegate, new object[] {
                        guid,
                        channelURI,
                        nick,
                        device}, this.onEndSubscribePhoneDelegate, this.onSubscribePhoneCompletedDelegate, userState);
        }
        
        private System.IAsyncResult OnBeginOpen(object[] inValues, System.AsyncCallback callback, object asyncState) {
            return ((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(callback, asyncState);
        }
        
        private object[] OnEndOpen(System.IAsyncResult result) {
            ((System.ServiceModel.ICommunicationObject)(this)).EndOpen(result);
            return null;
        }
        
        private void OnOpenCompleted(object state) {
            if ((this.OpenCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.OpenCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void OpenAsync() {
            this.OpenAsync(null);
        }
        
        public void OpenAsync(object userState) {
            if ((this.onBeginOpenDelegate == null)) {
                this.onBeginOpenDelegate = new BeginOperationDelegate(this.OnBeginOpen);
            }
            if ((this.onEndOpenDelegate == null)) {
                this.onEndOpenDelegate = new EndOperationDelegate(this.OnEndOpen);
            }
            if ((this.onOpenCompletedDelegate == null)) {
                this.onOpenCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnOpenCompleted);
            }
            base.InvokeAsync(this.onBeginOpenDelegate, null, this.onEndOpenDelegate, this.onOpenCompletedDelegate, userState);
        }
        
        private System.IAsyncResult OnBeginClose(object[] inValues, System.AsyncCallback callback, object asyncState) {
            return ((System.ServiceModel.ICommunicationObject)(this)).BeginClose(callback, asyncState);
        }
        
        private object[] OnEndClose(System.IAsyncResult result) {
            ((System.ServiceModel.ICommunicationObject)(this)).EndClose(result);
            return null;
        }
        
        private void OnCloseCompleted(object state) {
            if ((this.CloseCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.CloseCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void CloseAsync() {
            this.CloseAsync(null);
        }
        
        public void CloseAsync(object userState) {
            if ((this.onBeginCloseDelegate == null)) {
                this.onBeginCloseDelegate = new BeginOperationDelegate(this.OnBeginClose);
            }
            if ((this.onEndCloseDelegate == null)) {
                this.onEndCloseDelegate = new EndOperationDelegate(this.OnEndClose);
            }
            if ((this.onCloseCompletedDelegate == null)) {
                this.onCloseCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnCloseCompleted);
            }
            base.InvokeAsync(this.onBeginCloseDelegate, null, this.onEndCloseDelegate, this.onCloseCompletedDelegate, userState);
        }
        
        protected override WP7Data.Push.ConsumerApp.PushService.IPushRegistration CreateChannel() {
            return new PushRegistrationClientChannel(this);
        }
        
        private class PushRegistrationClientChannel : ChannelBase<WP7Data.Push.ConsumerApp.PushService.IPushRegistration>, WP7Data.Push.ConsumerApp.PushService.IPushRegistration {
            
            public PushRegistrationClientChannel(System.ServiceModel.ClientBase<WP7Data.Push.ConsumerApp.PushService.IPushRegistration> client) : 
                    base(client) {
            }
            
            public System.IAsyncResult BeginIsPhoneSubscribed(System.Guid guid, string channelURI, System.AsyncCallback callback, object asyncState) {
                object[] _args = new object[2];
                _args[0] = guid;
                _args[1] = channelURI;
                System.IAsyncResult _result = base.BeginInvoke("IsPhoneSubscribed", _args, callback, asyncState);
                return _result;
            }
            
            public int EndIsPhoneSubscribed(System.IAsyncResult result) {
                object[] _args = new object[0];
                int _result = ((int)(base.EndInvoke("IsPhoneSubscribed", _args, result)));
                return _result;
            }
            
            public System.IAsyncResult BeginSubscribePhone(System.Guid guid, string channelURI, string nick, string device, System.AsyncCallback callback, object asyncState) {
                object[] _args = new object[4];
                _args[0] = guid;
                _args[1] = channelURI;
                _args[2] = nick;
                _args[3] = device;
                System.IAsyncResult _result = base.BeginInvoke("SubscribePhone", _args, callback, asyncState);
                return _result;
            }
            
            public int EndSubscribePhone(System.IAsyncResult result) {
                object[] _args = new object[0];
                int _result = ((int)(base.EndInvoke("SubscribePhone", _args, result)));
                return _result;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="PushService.IPushProvider")]
    public interface IPushProvider {
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://tempuri.org/IPushProvider/SendToastMessageToAllUsers", ReplyAction="http://tempuri.org/IPushProvider/SendToastMessageToAllUsersResponse")]
        System.IAsyncResult BeginSendToastMessageToAllUsers(string message, System.AsyncCallback callback, object asyncState);
        
        void EndSendToastMessageToAllUsers(System.IAsyncResult result);
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://tempuri.org/IPushProvider/SendRawMessageToAllUsers", ReplyAction="http://tempuri.org/IPushProvider/SendRawMessageToAllUsersResponse")]
        System.IAsyncResult BeginSendRawMessageToAllUsers(string message, System.AsyncCallback callback, object asyncState);
        
        void EndSendRawMessageToAllUsers(System.IAsyncResult result);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IPushProviderChannel : WP7Data.Push.ConsumerApp.PushService.IPushProvider, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class PushProviderClient : System.ServiceModel.ClientBase<WP7Data.Push.ConsumerApp.PushService.IPushProvider>, WP7Data.Push.ConsumerApp.PushService.IPushProvider {
        
        private BeginOperationDelegate onBeginSendToastMessageToAllUsersDelegate;
        
        private EndOperationDelegate onEndSendToastMessageToAllUsersDelegate;
        
        private System.Threading.SendOrPostCallback onSendToastMessageToAllUsersCompletedDelegate;
        
        private BeginOperationDelegate onBeginSendRawMessageToAllUsersDelegate;
        
        private EndOperationDelegate onEndSendRawMessageToAllUsersDelegate;
        
        private System.Threading.SendOrPostCallback onSendRawMessageToAllUsersCompletedDelegate;
        
        private BeginOperationDelegate onBeginOpenDelegate;
        
        private EndOperationDelegate onEndOpenDelegate;
        
        private System.Threading.SendOrPostCallback onOpenCompletedDelegate;
        
        private BeginOperationDelegate onBeginCloseDelegate;
        
        private EndOperationDelegate onEndCloseDelegate;
        
        private System.Threading.SendOrPostCallback onCloseCompletedDelegate;
        
        public PushProviderClient() {
        }
        
        public PushProviderClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public PushProviderClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public PushProviderClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public PushProviderClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.Net.CookieContainer CookieContainer {
            get {
                System.ServiceModel.Channels.IHttpCookieContainerManager httpCookieContainerManager = this.InnerChannel.GetProperty<System.ServiceModel.Channels.IHttpCookieContainerManager>();
                if ((httpCookieContainerManager != null)) {
                    return httpCookieContainerManager.CookieContainer;
                }
                else {
                    return null;
                }
            }
            set {
                System.ServiceModel.Channels.IHttpCookieContainerManager httpCookieContainerManager = this.InnerChannel.GetProperty<System.ServiceModel.Channels.IHttpCookieContainerManager>();
                if ((httpCookieContainerManager != null)) {
                    httpCookieContainerManager.CookieContainer = value;
                }
                else {
                    throw new System.InvalidOperationException("Unable to set the CookieContainer. Please make sure the binding contains an HttpC" +
                            "ookieContainerBindingElement.");
                }
            }
        }
        
        public event System.EventHandler<System.ComponentModel.AsyncCompletedEventArgs> SendToastMessageToAllUsersCompleted;
        
        public event System.EventHandler<System.ComponentModel.AsyncCompletedEventArgs> SendRawMessageToAllUsersCompleted;
        
        public event System.EventHandler<System.ComponentModel.AsyncCompletedEventArgs> OpenCompleted;
        
        public event System.EventHandler<System.ComponentModel.AsyncCompletedEventArgs> CloseCompleted;
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.IAsyncResult WP7Data.Push.ConsumerApp.PushService.IPushProvider.BeginSendToastMessageToAllUsers(string message, System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginSendToastMessageToAllUsers(message, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        void WP7Data.Push.ConsumerApp.PushService.IPushProvider.EndSendToastMessageToAllUsers(System.IAsyncResult result) {
            base.Channel.EndSendToastMessageToAllUsers(result);
        }
        
        private System.IAsyncResult OnBeginSendToastMessageToAllUsers(object[] inValues, System.AsyncCallback callback, object asyncState) {
            string message = ((string)(inValues[0]));
            return ((WP7Data.Push.ConsumerApp.PushService.IPushProvider)(this)).BeginSendToastMessageToAllUsers(message, callback, asyncState);
        }
        
        private object[] OnEndSendToastMessageToAllUsers(System.IAsyncResult result) {
            ((WP7Data.Push.ConsumerApp.PushService.IPushProvider)(this)).EndSendToastMessageToAllUsers(result);
            return null;
        }
        
        private void OnSendToastMessageToAllUsersCompleted(object state) {
            if ((this.SendToastMessageToAllUsersCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.SendToastMessageToAllUsersCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void SendToastMessageToAllUsersAsync(string message) {
            this.SendToastMessageToAllUsersAsync(message, null);
        }
        
        public void SendToastMessageToAllUsersAsync(string message, object userState) {
            if ((this.onBeginSendToastMessageToAllUsersDelegate == null)) {
                this.onBeginSendToastMessageToAllUsersDelegate = new BeginOperationDelegate(this.OnBeginSendToastMessageToAllUsers);
            }
            if ((this.onEndSendToastMessageToAllUsersDelegate == null)) {
                this.onEndSendToastMessageToAllUsersDelegate = new EndOperationDelegate(this.OnEndSendToastMessageToAllUsers);
            }
            if ((this.onSendToastMessageToAllUsersCompletedDelegate == null)) {
                this.onSendToastMessageToAllUsersCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnSendToastMessageToAllUsersCompleted);
            }
            base.InvokeAsync(this.onBeginSendToastMessageToAllUsersDelegate, new object[] {
                        message}, this.onEndSendToastMessageToAllUsersDelegate, this.onSendToastMessageToAllUsersCompletedDelegate, userState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.IAsyncResult WP7Data.Push.ConsumerApp.PushService.IPushProvider.BeginSendRawMessageToAllUsers(string message, System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginSendRawMessageToAllUsers(message, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        void WP7Data.Push.ConsumerApp.PushService.IPushProvider.EndSendRawMessageToAllUsers(System.IAsyncResult result) {
            base.Channel.EndSendRawMessageToAllUsers(result);
        }
        
        private System.IAsyncResult OnBeginSendRawMessageToAllUsers(object[] inValues, System.AsyncCallback callback, object asyncState) {
            string message = ((string)(inValues[0]));
            return ((WP7Data.Push.ConsumerApp.PushService.IPushProvider)(this)).BeginSendRawMessageToAllUsers(message, callback, asyncState);
        }
        
        private object[] OnEndSendRawMessageToAllUsers(System.IAsyncResult result) {
            ((WP7Data.Push.ConsumerApp.PushService.IPushProvider)(this)).EndSendRawMessageToAllUsers(result);
            return null;
        }
        
        private void OnSendRawMessageToAllUsersCompleted(object state) {
            if ((this.SendRawMessageToAllUsersCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.SendRawMessageToAllUsersCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void SendRawMessageToAllUsersAsync(string message) {
            this.SendRawMessageToAllUsersAsync(message, null);
        }
        
        public void SendRawMessageToAllUsersAsync(string message, object userState) {
            if ((this.onBeginSendRawMessageToAllUsersDelegate == null)) {
                this.onBeginSendRawMessageToAllUsersDelegate = new BeginOperationDelegate(this.OnBeginSendRawMessageToAllUsers);
            }
            if ((this.onEndSendRawMessageToAllUsersDelegate == null)) {
                this.onEndSendRawMessageToAllUsersDelegate = new EndOperationDelegate(this.OnEndSendRawMessageToAllUsers);
            }
            if ((this.onSendRawMessageToAllUsersCompletedDelegate == null)) {
                this.onSendRawMessageToAllUsersCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnSendRawMessageToAllUsersCompleted);
            }
            base.InvokeAsync(this.onBeginSendRawMessageToAllUsersDelegate, new object[] {
                        message}, this.onEndSendRawMessageToAllUsersDelegate, this.onSendRawMessageToAllUsersCompletedDelegate, userState);
        }
        
        private System.IAsyncResult OnBeginOpen(object[] inValues, System.AsyncCallback callback, object asyncState) {
            return ((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(callback, asyncState);
        }
        
        private object[] OnEndOpen(System.IAsyncResult result) {
            ((System.ServiceModel.ICommunicationObject)(this)).EndOpen(result);
            return null;
        }
        
        private void OnOpenCompleted(object state) {
            if ((this.OpenCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.OpenCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void OpenAsync() {
            this.OpenAsync(null);
        }
        
        public void OpenAsync(object userState) {
            if ((this.onBeginOpenDelegate == null)) {
                this.onBeginOpenDelegate = new BeginOperationDelegate(this.OnBeginOpen);
            }
            if ((this.onEndOpenDelegate == null)) {
                this.onEndOpenDelegate = new EndOperationDelegate(this.OnEndOpen);
            }
            if ((this.onOpenCompletedDelegate == null)) {
                this.onOpenCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnOpenCompleted);
            }
            base.InvokeAsync(this.onBeginOpenDelegate, null, this.onEndOpenDelegate, this.onOpenCompletedDelegate, userState);
        }
        
        private System.IAsyncResult OnBeginClose(object[] inValues, System.AsyncCallback callback, object asyncState) {
            return ((System.ServiceModel.ICommunicationObject)(this)).BeginClose(callback, asyncState);
        }
        
        private object[] OnEndClose(System.IAsyncResult result) {
            ((System.ServiceModel.ICommunicationObject)(this)).EndClose(result);
            return null;
        }
        
        private void OnCloseCompleted(object state) {
            if ((this.CloseCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.CloseCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void CloseAsync() {
            this.CloseAsync(null);
        }
        
        public void CloseAsync(object userState) {
            if ((this.onBeginCloseDelegate == null)) {
                this.onBeginCloseDelegate = new BeginOperationDelegate(this.OnBeginClose);
            }
            if ((this.onEndCloseDelegate == null)) {
                this.onEndCloseDelegate = new EndOperationDelegate(this.OnEndClose);
            }
            if ((this.onCloseCompletedDelegate == null)) {
                this.onCloseCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnCloseCompleted);
            }
            base.InvokeAsync(this.onBeginCloseDelegate, null, this.onEndCloseDelegate, this.onCloseCompletedDelegate, userState);
        }
        
        protected override WP7Data.Push.ConsumerApp.PushService.IPushProvider CreateChannel() {
            return new PushProviderClientChannel(this);
        }
        
        private class PushProviderClientChannel : ChannelBase<WP7Data.Push.ConsumerApp.PushService.IPushProvider>, WP7Data.Push.ConsumerApp.PushService.IPushProvider {
            
            public PushProviderClientChannel(System.ServiceModel.ClientBase<WP7Data.Push.ConsumerApp.PushService.IPushProvider> client) : 
                    base(client) {
            }
            
            public System.IAsyncResult BeginSendToastMessageToAllUsers(string message, System.AsyncCallback callback, object asyncState) {
                object[] _args = new object[1];
                _args[0] = message;
                System.IAsyncResult _result = base.BeginInvoke("SendToastMessageToAllUsers", _args, callback, asyncState);
                return _result;
            }
            
            public void EndSendToastMessageToAllUsers(System.IAsyncResult result) {
                object[] _args = new object[0];
                base.EndInvoke("SendToastMessageToAllUsers", _args, result);
            }
            
            public System.IAsyncResult BeginSendRawMessageToAllUsers(string message, System.AsyncCallback callback, object asyncState) {
                object[] _args = new object[1];
                _args[0] = message;
                System.IAsyncResult _result = base.BeginInvoke("SendRawMessageToAllUsers", _args, callback, asyncState);
                return _result;
            }
            
            public void EndSendRawMessageToAllUsers(System.IAsyncResult result) {
                object[] _args = new object[0];
                base.EndInvoke("SendRawMessageToAllUsers", _args, result);
            }
        }
    }
}
