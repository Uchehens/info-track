using InfoTrack.Core.Interface;
using InfoTrack.Core.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Web;

namespace InfoTrack.Infrastructure.Network
{
    public class WebClientWrapper 
    {

        protected AppSetting _appSetting;
         
        public string Get(string address)
        {
            var client = new RestClient(address);
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("Cookie", _appSetting.Cookies);
            if (_appSetting.Proxy.isProxy)  client.Proxy = SetupProxy();
            IRestResponse response = client.Execute(request);
            return response.Content;
        }

        public string Post(string url, string requestData)
        {
            var client = new RestClient(url);
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            var body = requestData ;
            if (_appSetting.Proxy.isProxy) client.Proxy = SetupProxy();
            request.AddParameter("text/plain", body, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            return response.Content;
        }

             
        private IWebProxy SetupProxy()
        {
            ICredentials credentials = CredentialCache.DefaultNetworkCredentials;
            IWebProxy proxy = new WebProxy(_appSetting.Proxy.Host, _appSetting.Proxy.Port);
            proxy.Credentials = credentials;
            return proxy;   
        }
    }
}
