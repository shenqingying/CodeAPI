using Sonluk.Utility;
using Sonluk.Utility.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;

namespace Sonluk.BusinessLogic.OA
{
    public class SSO
    {
        private string _Key;
        private string _Host;
        private string _Form;
        private HttpClient _HttpClient;

        public SSO() 
        {
            _Key = @"A|rF=)OA";
            _Host = AppConfig.Settings("OA");
            _Form = MD5Hash.GetMd5Hash(AppConfig.Settings("OA.SSO", _Key));
            _HttpClient = new HttpClient();
        }

        public bool Login(string ticketID)
        {
            HttpResponseMessage response = _HttpClient.GetAsync(new Uri(_Host + "seeyon/login/sso?from=" + _Form + "&ticket=" + ticketID)).Result;
            return true;
        }

        public bool Logout(string ticketID)
        {

            HttpResponseMessage response = _HttpClient.GetAsync(new Uri(_Host + "seeyon/login/sso?from=" + _Form + "&ticket=" + ticketID)).Result;
            return true;
        }
    }
}
